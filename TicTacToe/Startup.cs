using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToe.Data.Interfaces;
using TicTacToe.Data.Classes;
using Microsoft.Extensions.Configuration;

namespace TicTacToe
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("TicTacConnectionString");
            services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);
            services.AddScoped<ITicsTacsCollection, TicsTacsCollection>(serviceProvider => new TicsTacsCollection(connectionString));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvcWithDefaultRoute();
        }
    }
}