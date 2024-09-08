using DeliveggieAPI.Models;
using DeliveggieAPI.Repository;
using DeliveggieAPI.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DeliveggieAPI.Test
{
    public class DeliveggieServiceTest
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IDeliveggieService _service;

        public DeliveggieServiceTest()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new DeliveggieService(_mockRepo.Object);
        }

        [Fact]
        public void GetAllProducts_ReturnsProductList()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { Id = "1", Name = "Product1",  Price = 100 },
            new Product { Id = "2", Name = "Product2", Price = 200 }
        };
            _mockRepo.Setup(repo => repo.Get()).Returns(products);

            // Act
            var result = _service.Get();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Product1", result[0].Name);
        }
    }
}
