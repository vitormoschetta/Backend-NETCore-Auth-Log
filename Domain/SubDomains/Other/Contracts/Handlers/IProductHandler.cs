using System;
using Domain;
using Domains.Other.Commands;

namespace Domains.Other.Contracts.Handlers
{
    public interface IProductHandler
    {
         // Write
        CommandResult Create(ProductCreateCommand command);
        CommandResult Update(ProductUpdateCommand command);
        CommandResult AddPromotion(ProductPromotionCommand command);
        CommandResult Delete(string id);
    }
}