using DeliveggieAPI.Models;
using System.Collections.Generic;

namespace DeliveggieAPI.Services
{
    public interface IDeliveggieService
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(string id, Product product);
        void Remove(string id);
    }
}
