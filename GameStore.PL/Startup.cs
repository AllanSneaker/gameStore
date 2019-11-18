using System.Collections.Generic;
using Castle.Core.Logging;
using GameStore.BLL.Configurations;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;
using GameStore.DAL.Entity.Repositories;
using GameStore.PL.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.PL
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GameStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GameStoreConnection")));

            AutoMapperConfig.Map(services);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService, GameService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "API Documentation",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                    {
                        Name = "Roman"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            app.UseMvc();
        }
    }
}
