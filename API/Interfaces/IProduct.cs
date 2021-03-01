using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getAll();
        Task<Product> getOneById(string Id);
        Task save(Product product);
        Task delete(string Id);
    }
}
