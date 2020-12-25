using Domains.Other.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Maps
{
    public class ProductMap: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.HasKey(x => x.Id);
        }
    }
}