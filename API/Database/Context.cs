using System;
using MongoDB.Driver;

namespace Database
{
    public class Context
    {
        public MongoClient client;
        public IMongoDatabase db;

        public Context()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("Blazor");
        }
    }
}
