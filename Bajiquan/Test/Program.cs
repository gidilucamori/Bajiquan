using Microsoft.Extensions.DependencyInjection;
using System;
using Bajiquan.Database;
using Microsoft.EntityFrameworkCore;

namespace Bajiquan
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<DB>(options =>
            {
                var cnnStr = "Server= localhost;Database=Bajiquan;User Id=sa; Password=0000;";
                //var cnnStr = "Server=localhost;Database=_magazzino;Uid=pi;Pwd=0000;";
                //var cnnStr = "Server=192.168.1.7;Database=_magazzino;Uid=pi;Pwd=0000;";
                options.UseSqlServer(cnnStr);
            });
            services.AddTransient<DatabaseTest>();
            var provider = services.BuildServiceProvider();
            provider.GetService<DatabaseTest>().Start();
        }
    }
}
