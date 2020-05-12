using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderApi.Data;
using OrderApi.Models;
using Common.Messaging;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext _ordersContext;
        private readonly IConfiguration _config;
        private readonly ILogger<OrdersController> _logger;
        private IPublishEndpoint _bus;

        public OrdersController(OrdersContext ordersContext, IConfiguration config, ILogger<OrdersController> logger, IPublishEndpoint bus)
        {
            _ordersContext = ordersContext ?? throw new ArgumentNullException(nameof(ordersContext));
            ordersContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _config = config;
            _logger = logger;
            _bus = bus;
        }

        [Route("new")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.OrderStatus = OrderStatus.Preparing;
            order.Date = DateTime.UtcNow;

            _logger.LogInformation("In Create Order");
            _logger.LogInformation("Order" + order.UserName);

            _ordersContext.Orders1.Add(order);
            _ordersContext.OrderItems1.AddRange(order.OrderItems);

            _logger.LogInformation("Order added to context");
            _logger.LogInformation("Saving.........");

            try
            {
                await _ordersContext.SaveChangesAsync();
                _logger.LogWarning("BuyerId is :" + order.BuyerId);
               _bus.Publish(new OrderCompletedEvent(order.BuyerId)).Wait();
                return Ok(new { order.OrderId });
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError("An error occured during order saving" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "GetOrder")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrders(int id)
        {
            var item = await _ordersContext.Orders1.

                        Include(x => x.OrderItems).
                        SingleOrDefaultAsync(c => c.OrderId == id);

            if(item != null)
            {
                return Ok(item);
            }

            return NotFound();


        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _ordersContext.Orders1.ToListAsync();
            return Ok(orders);
        }
    }
}