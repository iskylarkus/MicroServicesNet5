using MicroServicesNet5.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity,IAggregateRoot
    {
        // EF Core features
        // - Owned Types
        // - Shadow Property
        // - Backing Field

        public DateTime CreatedDate { get; set; }
        public Address Address { get; set; }

        public string BuyerId { get; set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existOrderItem = _orderItems.Any(x => x.ProductId == productId);

            if (!existOrderItem)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
