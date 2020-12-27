using System;
using System.Collections.Generic;
using Domain;
using Domains.Other.Commands;
using Domains.Other.Contracts.Handlers;
using Domains.Other.Contracts.Repositories;
using Domains.Other.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IProductHandler _handler;
        public ProductController(IProductRepository repository, IProductHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public CommandResult Create(ProductCreateCommand command)
        {
            var result = _handler.Create(command);
            return result;
        }

        [HttpPut("{id}")]
        public CommandResult Update(Guid id, ProductUpdateCommand command)
        {
            if (id != command.Id)
                return new CommandResult(false, "Id inválido. ", null);

            var result = _handler.Update(command);
            return result;
        }

        [HttpPut("AddPromotion/{id}")]
        public CommandResult AddPromotion(Guid id, ProductPromotionCommand command)
        {
            var result = _handler.AddPromotion(command);
            return result;
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles="Admin")]
        public CommandResult Delete(Guid id)
        {
            var result = _handler.Delete(id);
            return result;
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _repository.GetAll();
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(Guid id)
        {
            Product product = _repository.GetById(id);
            return Ok(product);
        }

        [HttpGet("Search/{filter}")]
        public IEnumerable<Product> Search(string filter)
        {
            filter = (filter == "empty") ? "" : filter;
            var result = _repository.Search(filter);
            return result;
        }
    }
}