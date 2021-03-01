using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Database
{
    public class ImageRepository : IImage
    {

        internal IGridFSBucket bucket;
        internal Context _repo = new Context();
        public IMongoCollection<Images> collection;

        public ImageRepository()
        {
            _repo = new Context();
            bucket = new GridFSBucket(_repo.db);
            this.collection = _repo.db.GetCollection<Images>("fs.files");
        }

        public async Task<List<Images>> getAll()
        {
            var query = await collection.Find(new BsonDocument()).ToListAsync();
            return query;
        }

        public async Task<bool> save(Images image)
        {
            await bucket.UploadFromBytesAsync(image.name, image.content);


            return true;

        }

        public async Task<bool> deleted(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> getContent(ObjectId id)
        {
            return await bucket.DownloadAsBytesAsync(id);

        }
    }
}
