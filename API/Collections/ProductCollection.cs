using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using Interfaces;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Collections
{
    public class ProductCollection : IProduct
    {
        private IMongoCollection<Product> collection;
        private Context repo = new Context();

        public ProductCollection()
        {
            collection = repo.db.GetCollection<Product>("product");
        }

        public async Task delete(string Id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, Id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Product>> getAll()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> getOneById(string Id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task save(Product product)
        {
            if (!string.IsNullOrEmpty(product.Id))
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);
                await collection.ReplaceOneAsync(filter, product);
            }
            else
            {
                await collection.InsertOneAsync(product);
            }
        }
    }
}
