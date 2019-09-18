using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.PL
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
            //services.AddDbContext<GameStoreContext>(option =>
            //{
            //    option.UseSqlServer(configuration.GetSection("GameStoreConnection").Value);
            //    option.UseLazyLoadingProxies();
            //});
            services.AddDbContext<GameStoreContext>(options => {
            options.UseSqlServer("GameStoreConnection");
        });

        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.Run(async (context) =>
			{
                var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();

                var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GameStoreDB;Trusted_Connection=True;")
                    .UseLazyLoadingProxies()
                    .Options;

                GameStoreContext db = new GameStoreContext(options);

                Game game = new Game()
                {
                    Name = "dfsf"
                };
                db.Games.Add(game);
                db.SaveChanges();

                var list = db.Games;
                foreach (var l in list)
                {
                    await context.Response.WriteAsync(l.Name);
                }

                await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
