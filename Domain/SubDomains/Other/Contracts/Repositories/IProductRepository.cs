using System;
using System.Collections.Generic;
using Domains.Other.Entities;

namespace Domains.Other.Contracts.Repositories
{
    public interface IProductRepository
    {
         // Write
        void Create(Product model);
        void Update(Product model);
        void Delete(string id);

        // Read
        Product GetById(string id);
        List<Product> GetAll();
        bool Exists(string name);       
        bool ExistsUpdate(string name, string id);
        List<Product> Search(string filter);
    }
}