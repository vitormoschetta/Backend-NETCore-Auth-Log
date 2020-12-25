using Domain;
using Domain.SubDomains.Authentication.Entities;
using Domains.Log.Entities;
using Domains.Other.Entities;
using Infra.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserAuth> UserAuth { get; set; }
        public DbSet<AccessLog> AccessLog { get; set; }       
        public DbSet<Product> Product { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Settings.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserAuthMap());
            builder.ApplyConfiguration(new AccessLogMap());    
            builder.ApplyConfiguration(new ProductMap());                       
        }
    }
}