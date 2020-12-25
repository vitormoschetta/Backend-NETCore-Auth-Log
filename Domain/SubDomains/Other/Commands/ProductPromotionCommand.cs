using System;

namespace Domains.Other.Commands
{
    public class ProductPromotionCommand
    {
        public Guid Id { get; set; }        
        public decimal Price { get; set; }
    }
}