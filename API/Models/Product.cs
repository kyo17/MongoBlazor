using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Product
    {
        public Product()
        {
            code = Guid.NewGuid().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string photo { get; set; }
        public Category? category { get; set; }
    }
}
