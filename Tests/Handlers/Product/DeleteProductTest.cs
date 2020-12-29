using System;
using System.Linq;
using Domains.Other.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;

namespace Tests.Handlers.Product
{
    [TestClass]
    public class DeleteProductTest
    {
        [TestMethod]
        public void DeleteProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            string id = repository.GetAll().FirstOrDefault().Id;
            var result = handler.Delete(id);
            Assert.IsTrue(result.Success, result.Message);
        }


        [TestMethod]
        public void DeleteProductHandler_NotExists_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            string id = Guid.NewGuid().ToString();
            var result = handler.Delete(id);
            Assert.IsFalse(result.Success, result.Message);
        }
    }
}