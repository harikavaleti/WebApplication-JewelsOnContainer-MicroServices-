using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartSrvc;
        public Cart(ICartService cartService) => _cartSrvc = cartService;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new CartComponentViewModel();
            try
            {
                var cart = await _cartSrvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch
            {
                ViewBag.IsBasketInOperative = true;
            }
            return View(vm);
        }
    }
}
