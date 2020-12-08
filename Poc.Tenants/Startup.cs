using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Poc.Tenants.Database.Repositories;
using Poc.Tenants.Interfaces;
using Poc.Tenants.Middleware;
using Poc.Tenants.Models.Commom;

namespace Poc.Tenants
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMultitenancy<AppTenant, AppTenantMiddleware>();
            
            services.AddControllers();

            services.AddSingleton<IMongoClient>(provider =>
            {
                var username = Configuration["MongoDb:Username"];
                var password = Uri.EscapeDataString(Configuration["MongoDb:Password"]);
                var connectionString = string.Format(Configuration["MongoDb:ConnectionString"], username, password);

                return new MongoClient(connectionString);
            });

            services.AddTransient<ICustomerRepository>(provider =>
            {
                var mongoClient = provider.GetService<IMongoClient>();
                var appTenant = provider.GetService<AppTenant>();

                if (appTenant == null)
                {
                    throw new InvalidOperationException("The register number of the company is required.");
                }

                var database = string.Format(Configuration["MongoDb:Database"], appTenant.RegisterNumber);

                return new CustomerRepository(mongoClient, database, "customer");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMultitenancy<AppTenant>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
