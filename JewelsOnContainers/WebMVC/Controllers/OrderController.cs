using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly.CircuitBreaker;
using Stripe;
using WebMVC.Models;
using WebMVC.Models.OrderModels;
using WebMVC.Services;
using Order = WebMVC.Models.OrderModels.Order;

namespace WebMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IIdentityService<ApplicationUser> _identityService;
        private readonly ILogger<OrderController> _logger;
        private readonly IConfiguration _config;
        
        public OrderController(IConfiguration config, ICartService cartService, IIdentityService<ApplicationUser> identityService, 
                                 IOrderService orderService, ILogger<OrderController> logger)
        {
            _identityService = identityService;
            _orderService = orderService;
            _config = config;
            _cartService = cartService;
            _logger = logger;

        }

        public async Task<IActionResult> Create()
        {
            var user = _identityService.Get(HttpContext.User);
            var cart = await _cartService.GetCart(user);
            var order = _cartService.MapCartToOrder(cart);
            ViewBag.StripePublishableKey = _config["StripePublicKey"];
            return View(order);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Order frmorder)
        {
            if (ModelState.IsValid)
            {
                var user = _identityService.Get(HttpContext.User);
                Order order = frmorder;
                order.UserName = user.Email;
                order.BuyerId = user.Email;

                var options = new RequestOptions
                {
                    ApiKey = _config["StripePrivateKey"]
                };

                var chargeOptions = new ChargeCreateOptions()
                {
                    //required
                    Amount = (int)(order.OrderTotal * 100),
                    Currency = "usd",
                    Source = order.StripeToken,
                    //optional
                    Description = string.Format("Order payment {0}", order.UserName),
                    ReceiptEmail = user.UserName,
                };

                var chargeService = new ChargeService();
                Charge stripeCharge = null;
                try
                {
                    stripeCharge = chargeService.Create(chargeOptions, options);
                    _logger.LogDebug("Stripe charge object creation" + stripeCharge.StripeResponse.ToString());
                }
                catch (StripeException stripeException)
                {

                    _logger.LogDebug("Stripe Exception" + stripeException.Message);
                    ModelState.AddModelError(string.Empty, stripeException.Message);
                    return View(frmorder);

                }
                try
                {
                    if (stripeCharge.Id != null)
                    {
                        order.PaymentAuthCode = stripeCharge.Id;
                        int orderId = await _orderService.CreateOrder(order);
                        return RedirectToAction("Complete", new { id = orderId, userName = user.UserName });
                    }
                    else
                    {
                        ViewData["message"] = "Payment cannot be processed, try again";
                        return View(frmorder);

                    }
                }
                catch (BrokenCircuitException)
                {
                    ModelState.AddModelError("Error", "It was  not possible to create new order, please try later on.(Business Msg due to Circuit Break)");
                    return View(frmorder);
                }
            }
            else
            {
                return View(frmorder);
            }

        }

        public IActionResult Complete(int id, string userName)
        {
            _logger.LogInformation("User {userName} completed checkout on order {orderId}.", userName, id);
            return View(id);
        }

        public async Task<IActionResult> Detail(string orderId)
        {
            var user = _identityService.Get(HttpContext.User);
            var order = await _orderService.GetOrder(orderId);
            return View(order);
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _orderService.GetOrders();
            return View(vm);
        }
        private decimal GetTotal(List<Models.OrderModels.OrderItem> orderItems)
        {
            return orderItems.Select(p => p.UnitPrice * p.Units).Sum();

        }
    }


    
}