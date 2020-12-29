using System;

namespace Domains.Other.Commands
{
    public class ProductUpdateCommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}