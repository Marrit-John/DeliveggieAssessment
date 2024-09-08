using DeliveggieAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly IMongoCollection<Product> _product;
        public ProductRepository(IDeliveggieDBSettings deliveggieDBSettings, IMongoClient mongoClient)
        {
            var dbName = mongoClient.GetDatabase(deliveggieDBSettings.DatabaseName);
            _product = dbName.GetCollection<Product>(deliveggieDBSettings.DeliveggieConnectionName);
        }
        

        public Product Create(Product product)
        {
            product.Id = ObjectId.GenerateNewId().ToString();
            product.ProductId = _product.Find(product => true).ToList().Count + 1;
            _product.InsertOne(product);
            return product;
        }

        public List<Product> Get()
        {
            return _product.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return _product.Find(product => product.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _product.DeleteOne(product => product.Id == id);
        }

        public void Update(string id, Product product)
        {
            _product.ReplaceOne(product => product.Id == id, product);
        }
    }
}
