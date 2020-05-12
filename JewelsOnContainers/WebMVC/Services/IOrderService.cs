using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Models.OrderModels;

namespace WebMVC.Services
{
   public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
      
    }
}
