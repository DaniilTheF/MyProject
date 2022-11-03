using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Objects.Interfaces;
using System;
using MyProject.Objects.DB;
using MyProject.Objects.Entity;


namespace MyProject
{
    public class Startup
    {
        private IConfigurationRoot configurationRoot;

        [Obsolete]
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("database.json").Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBase>(options => options.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddTransient<IGetProducts, ProductEntity>();
            services.AddTransient<IGetUser, UserEntity>();
            services.AddTransient<IGetUserAcc, UserAccEntity>();
            services.AddTransient<IProductsBusket, ProductsBasket>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(p => ProductsBasket.GetProductsBasket(p));
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Main}/{action=MainPage}/{id?}");
                routes.MapRoute("typeFilters", "Product/Page/{type?}");
            });



            using (var scope = app.ApplicationServices.CreateScope())
            {
                DataBase DB = scope.ServiceProvider.GetRequiredService<DataBase>();
                AddProducts.Db(DB);
            }

        }
    }
}
