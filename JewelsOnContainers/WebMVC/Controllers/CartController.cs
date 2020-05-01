using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(ICatalogService catalogService, ICartService cartService, IIdentityService<ApplicationUser> identityService)
        {
            _catalogService = catalogService;
            _cartService = cartService;
            _identityService = identityService;
        }

   
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if(action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "Order");
            }

            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);
            }
            catch (BrokenCircuitException)
            {
                HandleBrokenCircuitException();
            }
            return View();
        }

        public async Task<IActionResult> AddToCart(CatalogItem productDetails)
        {
            try
            {
                if(productDetails.Id > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        ProductName = productDetails.Name,
                        PictureUrl = productDetails.PictureUrl,
                        UnitPrice = productDetails.Price,
                        ProductId = productDetails.Id.ToString()
                    };
                    await _cartService.AddItemToCart(user, product);
                }
                return RedirectToAction("Index", "Catalog");    
            }
            catch (BrokenCircuitException)
            {
                HandleBrokenCircuitException();
            }
            return RedirectToAction("Index", "Catalog");
        }
        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "Cart Service is inoperative, please try later on.(Business message due to Circuit-Breaker)";
        }
    }
}