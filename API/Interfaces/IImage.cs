using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using MongoDB.Bson;

namespace Interfaces
{
    public interface IImage
    {
        Task<List<Images>> getAll();
        Task<bool> save(Images image);
        Task<bool> deleted(string id);
        Task<byte[]> getContent(ObjectId id);
    }
}
