using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;
using WebMVC.Models.OrderModels;

namespace WebMVC.Services
{
    public class CartService : ICartService
    {
        private readonly IConfiguration _config;
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public CartService(IConfiguration config, IHttpContextAccessor httpContextAccessor, IHttpClient httpClient, ILoggerFactory logger)
        {
            _config = config;
            _remoteServiceBaseUrl = $"{_config["CartUrl"]}/api/cart";
            _httpContextAccessor = httpContextAccessor;
            _apiClient = httpClient;
            _logger = logger.CreateLogger<CartService>();
        }

        public async Task AddItemToCart(ApplicationUser user, CartItem product)
        {
            var cart = await GetCart(user);
            _logger.LogDebug("UserName: " + user.Email);

            var basketItem = cart.Items.Where(p => p.ProductId == product.ProductId).FirstOrDefault();

            if(basketItem == null)
            {
                cart.Items.Add(product);
            }
            else{
                basketItem.Quantity += 1;
            }

            await UpdateCart(cart);
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var cleanBasketUri = ApiPaths.Basket.CleanBasket(_remoteServiceBaseUrl, user.Email);
            _logger.LogDebug("Clean Basket Url :" + cleanBasketUri);

            var response = await _apiClient.DeleteAsync(cleanBasketUri);
            _logger.LogDebug("Basket Cleaned");
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();

            //logging mesages
            _logger.LogInformation("We are in get basket and user id " + user.Email);
            _logger.LogInformation(_remoteServiceBaseUrl);

            var getBasketUri = ApiPaths.Basket.GetBasket(_remoteServiceBaseUrl, user.Email);
            _logger.LogInformation(getBasketUri);

            var dataString = await _apiClient.GetStringAsync(getBasketUri, token);
            _logger.LogInformation(dataString);

            var response = JsonConvert.DeserializeObject<Cart>(dataString.ToString()) ??
                new Cart()
                {
                    BuyerId = user.Email
                };

            return response;

        }

        async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }

        public async Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
            var basket = await GetCart(user);
            basket.Items.ForEach(x =>
            {
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });

            return basket;

        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var token = await GetUserTokenAsync();
            _logger.LogDebug("Service Url :" + _remoteServiceBaseUrl);

            var updateBasketUri = ApiPaths.Basket.UpdateBasket(_remoteServiceBaseUrl);
            _logger.LogDebug("Update Basket Url:" + updateBasketUri);

            var response = await _apiClient.PostAsync(updateBasketUri, cart, token);
            response.EnsureSuccessStatusCode();

            return cart;
        }

        public Order MapCartToOrder(Cart cart)
        {
            var order = new Order();
            order.OrderTotal = 0;

            cart.Items.ForEach(x =>
            {
                order.OrderItems.Add(new OrderItem()
                {
                    ProductId = int.Parse(x.ProductId),
                    PictureUrl = x.PictureUrl,
                    ProductName = x.ProductName,
                    Units = x.Quantity,
                    UnitPrice = x.UnitPrice

                });
                order.OrderTotal += (x.Quantity * x.UnitPrice);
            });
                                   
            return order;
        }
    }
}
