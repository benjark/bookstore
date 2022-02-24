using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            //Tells it to use the MVC pattern
            services.AddControllersWithViews();

            services.AddDbContext<BookStoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);

           });

            services.AddScoped<IBookStoreRepository, BookstoreRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Gives wwwroot
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",
                    "{bookCategory}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(name: "Paging", pattern: "Page{PageNum}", defaults: new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{bookCategory}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });
            
                //uses default controller route
                

            endpoints.MapDefaultControllerRoute();

            endpoints.MapRazorPages();
                
            });
        }
    }
}
