using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCrossing.Data;
using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Mocks;
using BookCrossing.Data.Models;
using BookCrossing.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCrossing
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseNpgsql(_confString.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<IBook, BookRepository>();
            services.AddTransient<IDepartment, DepartmentRepository>();
            services.AddTransient<IBooksGenre, GenreRepository>();
            services.AddTransient<IAllOrder, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => IssueBook.GetIssue(sp));


            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                routes.MapRoute(name: "genreFilter", template: "Books/{action}/{genre?}", defaults: new { Controller = "Books", action = "List" });
                routes.MapRoute(name: "departmentsList", template: "Departments/{action}/{id?}", defaults: new { Controller = "Departments", actiion = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent dbContent = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(dbContent);
            }
           
        }
    }
}
