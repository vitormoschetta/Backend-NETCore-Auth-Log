using System;
using System.Collections.Generic;
using System.Linq;
using Domains.Other.Contracts.Repositories;
using Domains.Other.Entities;

namespace Tests.Mock
{
    public class FakeProductRepository: IProductRepository
    {
        private readonly List<Product> List;
        public FakeProductRepository()
        {
            List = new List<Product>() {
                new Product("Product A", 5.99m),
                new Product("Product B", 10.00m),
                new Product("Product C", 500.00m)
            };
        }

        public void Create(Product model)
        {
            List.Add(model);
        }

        public void Delete(string id)
        {
            var item = List.FirstOrDefault(x => x.Id == id);

            if (item != null)
                List.Remove(item);
        }

        public void Update(Product model)
        {
            var item = List.FirstOrDefault(x => x.Id == model.Id);

            if (item != null)
            {
                List.Remove(item);
                List.Add(model);
            }
        }

        public bool Exists(string name)
        {
            var item = List.FirstOrDefault(x => x.Name == name);

            if (item != null)
                return true;

            return false;
        }

        public bool ExistsUpdate(string name, string id)
        {
            var item = List.FirstOrDefault(x => x.Name == name && x.Id != id);

            if (item != null)
                return true;

            return false;
        }

        public List<Product> GetAll()
        {
            return List.OrderBy(x => x.Name).ToList();
        }

        public Product GetById(string id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> Search(string filter)
        {
            var lista = List
                .Where(x => x.Name.Contains(filter) || x.Price.ToString().Contains(filter))
                .ToList();            
                
            return lista;
        }
    }
}