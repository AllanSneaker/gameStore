using System.Collections.Generic;
using GameStore.BLL.Configurations;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;
using GameStore.DAL.Entity.Repositories;
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
       // private IGameService _gameService;
        public Startup(IConfiguration config/*, IGameService gameService*/)
        {
            Configuration = config;
           // _gameService = gameService;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GameStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GameStoreConnection")));

            AutoMapperConfig.Map(services);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService, GameService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //   var list =  _gameService.GetAllGames();
            //   await list;
            //    //var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();

            //    //var options = optionsBuilder
            //    //    .UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = GameStoreDB; Trusted_Connection = True; ")
            //    //    .UseLazyLoadingProxies()
            //    //    .Options;

            //    //GameStoreContext db = new GameStoreContext(options);

            //    //var game = new Game() {Name = "fdsfsd"};
            //    //db.Games.Add(game);
            //    //db.SaveChanges();

            //    //var list = db.Games;
            //    //foreach (var l in list)
            //    //{
            //    //    await context.Response.WriteAsync(l.Name);
            //    //    //await context.Response.WriteAsync(l.Description);
            //    //}


            //    //await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
