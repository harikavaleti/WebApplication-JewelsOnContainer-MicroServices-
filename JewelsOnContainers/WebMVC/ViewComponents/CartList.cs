using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Services;

using Polly.CircuitBreaker;

namespace WebMVC.ViewComponents
{
    public class CartList : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartList(ICartService cartService) => _cartService = cartService;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new Models.Cart();
            try
            {
                vm = await _cartService.GetCart(user);
                return View(vm);
            }
            catch(BrokenCircuitException)
            {
                ViewBag.IsBasketInOperative = true;
                TempData["BasketInOperativeMessage"] = "Basket Service is inoperative, please try on.(Business message due to Circuit-Breaker)";
            }
            return View(vm);
        }
    }
}
