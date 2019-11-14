using System.Collections.Generic;
using AutoMapper;
using GameStore.BLL.Configurations;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Repositories;
using GameStore.PL.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>() { new AutoMapperConfig(), new AutoMapperConfigPL() });
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();
            app.UseMvc();
        }
    }
}
