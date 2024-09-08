using DeliveggieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Repository
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(string id, Product product);
        void Remove(string id);
    }
}
