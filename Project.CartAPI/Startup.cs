using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Business.Services;
using Project.CartAPI.Services;
using Project.Data.Entities.Mapping;
using Project.Data.EntityFramework;
using Project.CartAPI.ExtensionMethods;

namespace Project.CartAPI
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
            var connectionUrl = Configuration.GetSection("ConnectionStrings")["AzureConnection"];
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(opt =>
            opt.UseNpgsql(connectionUrl));

            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession();

            services.AddAutoMapper(typeof(Startup), typeof(MapProfile));

            services.AddSwaggerGen(e =>
            {
                e.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CartAPI",
                    Version = "v1"
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CartAPI");
            });

            app.UseMvc();
        }
    }
}
