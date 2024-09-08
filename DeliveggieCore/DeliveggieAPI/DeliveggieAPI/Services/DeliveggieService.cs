using DeliveggieAPI.Models;
using DeliveggieAPI.Repository;
using System.Collections.Generic;

namespace DeliveggieAPI.Services
{
    public class DeliveggieService : IDeliveggieService
    {
        private readonly IProductRepository _productRepository;

        public DeliveggieService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product product)
        {
            return _productRepository.Create(product);
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product Get(string id)
        {
            return _productRepository.Get(id);
        }

        public void Remove(string id)
        {
            _productRepository.Remove(id);
        }

        public void Update(string id, Product product)
        {
            _productRepository.Update(id, product);
        }

    }
}
