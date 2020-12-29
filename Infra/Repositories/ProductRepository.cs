using System;
using System.Collections.Generic;
using System.Linq;
using Domains.Other.Contracts.Repositories;
using Domains.Other.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Product model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var model = _context.Product.FirstOrDefault(x => x.Id == id);
            _context.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Product model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public bool Exists(string name)
        {
            var model = _context.Product.FirstOrDefault(x => x.Name == name);

            if (model != null) 
                return true;

            return false;
        }

        public bool ExistsUpdate(string name, string id)
        {
            var model = _context.Product.FirstOrDefault(x => x.Name == name && x.Id != id);

            if (model != null) 
                return true;
                
            return false;
        }

        public List<Product> GetAll()
        {
            return _context.Product
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Product GetById(string id)
        {
            return _context.Product
                .AsNoTracking()                
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Product> Search(string filter)
        {
            return _context.Product
                .AsNoTracking()
                .Where(x => x.Name.Contains(filter) || x.Price.ToString().Contains(filter))
                .ToList();
        }
    }
}