using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Images
    {
        public Images()
        {

        }

        [BsonId]
        
        public ObjectId Id { get; set; }
        public byte[] content { get; set; }
        [BsonElement("filename")]
        public string name { get; set; }
        [BsonElement("length")]
        public int length { get; set; }
        [BsonElement("chunkSize")]
        public int chunkSize { get; set; }
        [BsonElement("uploadDate")]
        public DateTime uploadDate { get; set; }
        [BsonElement("md5")]
        public string md5 { get; set; }
        public string url { get; set; }
    }
}
