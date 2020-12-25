using System.Linq;
using Domains.Other.Commands;
using Domains.Other.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;

namespace Tests.Handlers.Product
{
    [TestClass]
    public class UpdateProductTest
    {
        [TestMethod]
        public void UpdateProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = "Product X";
            command.Price = 9.5m;

            var result = handler.Update(command);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void UpdateProductHandler_Exists_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = "Product C";
            command.Price = 5.5m;

            var result = handler.Update(command);
            Assert.IsFalse(result.Success, result.Message);
        }

        [TestMethod]
        public void UpdateProductHandler_Null_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = null;
            command.Price = 5.5m;

            var result = handler.Update(command);
            Assert.IsFalse(result.Success, result.Message);
        }
    }
}