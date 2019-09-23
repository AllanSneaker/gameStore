using GameStore.BLL.Configurations;
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

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {

                //var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();

                //var options = optionsBuilder
                //    .UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = GameStoreDB; Trusted_Connection = True; ")
                //    .UseLazyLoadingProxies()
                //    .Options;

                //GameStoreContext db = new GameStoreContext(options);

                //var game = new Game() {Name = "fdsfsd"};
                //db.Games.Add(game);
                //db.SaveChanges();

                //var list = db.Games;
                //foreach (var l in list)
                //{
                //    await context.Response.WriteAsync(l.Name);
                //    //await context.Response.WriteAsync(l.Description);
                //}


                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
