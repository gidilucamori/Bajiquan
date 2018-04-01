using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bajiquan.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
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
            services.AddMvc();
            services.AddDbContext<DB>(options =>
            {
                var cnnStr = "Server= localhost;Database=Bajiquan;User Id=sa; Password=0000;";
                //var cnnStr = "Server=localhost;Database=_magazzino;Uid=pi;Pwd=0000;";
                //var cnnStr = "Server=192.168.1.7;Database=_magazzino;Uid=pi;Pwd=0000;";
                options.UseSqlServer(cnnStr);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Associati}/{action=NuovoAssociato}/{id?}");
            });
        }
    }
}
