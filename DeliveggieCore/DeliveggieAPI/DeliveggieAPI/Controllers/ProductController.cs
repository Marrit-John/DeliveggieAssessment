using DeliveggieAPI.Models;
using DeliveggieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveggieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDeliveggieService _deliveggieService;

        public ProductController(IDeliveggieService deliveggieService)
        {
            _deliveggieService = deliveggieService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _deliveggieService.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _deliveggieService.Get(id);
            if (product == null)
            {
                return NotFound($"Product not found for the product id {id}");
            }
            var today = DateTime.Now.DayOfWeek;
            if (product.PriceReduction != null)
            {
                var discount = product.PriceReduction.FirstOrDefault(r => r.DayOfWeek == (int)today)?.Reduction ?? 0;
                product.DiscountedPrice = (decimal)product.Price * (1 - discount);
            }
            return product;

        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            var today = DateTime.Now.DayOfWeek;
            if (product.PriceReduction != null)
            {
                var discount = product.PriceReduction.FirstOrDefault(r => r.DayOfWeek == (int)today)?.Reduction ?? 0;
                product.DiscountedPrice = (decimal)product.Price * (1 - discount);
            }
            _deliveggieService.Create(product);
            return CreatedAtAction(nameof(Get), new { id =  product.Id }, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Product products)
        {
            var existingProducts = _deliveggieService.Get(id);
            if (existingProducts == null)
            {
                return NotFound($"Product not found for the product id {id}");
            }
            _deliveggieService.Update(id, products);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingProducts = _deliveggieService.Get(id);
            if (existingProducts == null)
            {
                return NotFound($"Product not found for the product id {id}");
            }
            _deliveggieService.Remove(id);
            return Ok($"Product with product id {id} has been removed.");
        }
    }
}
