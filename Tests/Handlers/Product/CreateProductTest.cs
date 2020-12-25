using Domains.Other.Commands;
using Domains.Other.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;

namespace Tests.Handlers.Product
{
    [TestClass]
    public class CreateProductTest
    {
        [TestMethod]
        public void AddProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Product D";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void AddProductHandler_Null_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = null;
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.IsFalse(result.Success, result.Message);
        }

        [TestMethod]
        public void AddProductHandler_Empty_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.IsFalse(result.Success, result.Message);
        }

        [TestMethod]
        public void AddProductHandler_Lenght_Name_4_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Pro";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.IsFalse(result.Success, result.Message);
        }

        [TestMethod]
        public void AddProductHandler_Negative_Price_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Product D";
            command.Price = -1;            

            var result = handler.Create(command);
            Assert.IsFalse(result.Success, result.Message);
        }

        [TestMethod]
        public void AddProductHandler_Exists_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);
            
            var command = new ProductCreateCommand();
            command.Name = "Product A";
            command.Price = 5.5m;            

            var result = handler.Create(command);
            Assert.IsFalse(result.Success, result.Message);
        }
    }
}