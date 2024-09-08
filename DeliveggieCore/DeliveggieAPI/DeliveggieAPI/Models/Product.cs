using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DeliveggieAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Id")]
        public int ProductId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("EntryDate")]
        public DateTime EntryDate { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }

        public decimal DiscountedPrice { get; set; }
        public List<PriceReductionDto> PriceReduction { get; set; }
    }
}
