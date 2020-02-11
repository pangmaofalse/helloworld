using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiangLiQuery.Web.Data;
using JiangLiQuery.Web.Model;
using JiangLiQuery.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JiangLiQuery.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();//添加MVC服务

            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            });
            // services.AddScoped<IRepository<Student>, InMemoryRepository>();
            //services.AddSingleton<IRepository<Student>, InMemoryRepository>();
            services.AddScoped<IRepository<Student>, EFCoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles();//使用静态文件

            app.UseStaticFiles(new StaticFileOptions { 
                RequestPath="/node_modules"
            });

            //app.UseMvcWithDefaultRoute();//使用MVC默认框架路由
            //默认MapRoute =>{controller=Home}/{action=Index}/{id?}

            //自定义MVC路由
            app.UseMvc(builder=> {

                //  /Home/Index ->Home = HomeController , Index 方法
                builder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
            });

            /*
            app.Run(async (context) =>
            {
                var welcome = configuration["Welcome"];
                await context.Response.WriteAsync(welcome);
            });*/
        }
    }
}
