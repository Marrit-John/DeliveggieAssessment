using DeliveggieAPI.Models;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Services
{
    public class ProductMessageHandler
    {
        private readonly IBus _bus;

        public ProductMessageHandler(IBus bus)
        {
            _bus = bus;
        }

        public void SubscribeToProductMessages()
        {
            _bus.PubSub.Subscribe<Product>("productSubscription", HandleProductMessage);
        }

        private void HandleProductMessage(Product product)
        {
            // Handle the product message
            Console.WriteLine($"Received product: {product.Name}");
        }
    }
}
