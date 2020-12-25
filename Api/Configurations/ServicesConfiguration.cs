using System;
using System.Text;
using Api.Services;
using Domain;
using Domain.SubDomains.Authentication.Contracts.Handlers;
using Domain.SubDomains.Authentication.Contracts.Repositories;
using Domain.SubDomains.Authentication.Handlers;
using Domains.Other.Contracts.Handlers;
using Domains.Other.Contracts.Repositories;
using Domains.Other.Handlers;
using Domains.Subdomains.Log.Contracts.Repositories;
using Infra.Context;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            // Use in memory
            // services.AddDbContext<AppDbContext>(options =>
            //    options.UseInMemoryDatabase(Settings.ConnectionString()));

            //Use SQLite            
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlite(Settings.ConnectionString()));
            
        }  

        public static void ConfigureToken(this IServiceCollection services)
        {              
            services.AddScoped<TokenService>();    
            
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });                   

        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();  
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();                        
            services.AddScoped<IAccessLogRepository, AccessLogRepository>();   

            services.AddScoped<TokenService>();                       

        }
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.AddScoped<IProductHandler, ProductHandler>();
            services.AddScoped<IUserAuthHandler, UserAuthHandler>();
        }                                   
        
        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
            });

        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Auth Demo - API",
                    Description = "A simple example ASP.NET Core Web API",                
                    Contact = new OpenApiContact
                    {
                        Name = "Vitor Moschetta",
                        Email = string.Empty,
                        Url = new Uri("https://vitormoschetta.github.io/")
                    }                   
                });
            });
        } 
    }
}