using DeliveggieAPI.Configurations;
using DeliveggieAPI.Models;
using EasyNetQ;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Services
{
    public class MessageBusService
    {
        private readonly IBus _bus;

        public MessageBusService(IBus bus)
        {
            _bus = bus;
        }
        public async Task PublishProductAdded(Product product)
        {
           await  _bus.PubSub.PublishAsync(product);
        }
    }
}
