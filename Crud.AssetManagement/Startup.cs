using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.Extensions;
using Crud.AssetManagement.Infrastructure.Extensions;
using Crud.AssetManagement.Integration.Extensions;
using Crud.AssetManagement.Queries.Extensions;

namespace Crud.AssetManagement
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServices();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCommandServices();
            services.AddQueriesServices();
            services.AddInfrastructureServices();
            services.AddIntegrationServices();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.MapControllers();
        }
    }
}
