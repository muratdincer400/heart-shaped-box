using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOApplication1.Models;

namespace TODOApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddDbContext<TODOContext>(options=>options.UseSqlServer("Server=localhost;Database=TODO;Trusted_Connection=True;"));
            //services.AddTransient<IToDoListRepository, MockToDoListRepository>();
            //services.AddDbContext<TODOContext>(options => options.UseSqlServer("Server=localhost;Database=TODO;Trusted_Connection=True;"));
            services.AddDbContext<InMemDbContext>(opt => opt.UseInMemoryDatabase("MockDB"));
            services.AddTransient<IToDoListRepository, InMemoryToDoListRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            //var context = app.ApplicationServices.GetService<InMemDbContext>();
            //Utility.Utils.AddTestData(context);
            app.UseRouting();

            app.UseAuthorization();
            //app.UseMvcWithDefaultRoute();
                app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ToDoLists}/{action=Index}/{id?}");
            });
        }
    }
}
