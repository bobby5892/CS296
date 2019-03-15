using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ComplaintDepartment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("https_port", "5004")
                .UseUrls("https://localhost:5004/")
                .UseStartup<Startup>();
    }
    /*public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddEnvironmentVariables()
           .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            BuildWebHost(args).Run();
        }

        /*public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:5004/")
                .UseStartup<Startup>();

        public static IConfigurationRoot Configuration { get; set; }
        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args).UseKestrel(options =>
          {
              options.Listen(System.Net.IPAddress.Loopback, 5003, listenOptions =>
              {
                  listenOptions.UseHttps("/var/www/eugeneprogramming.com/ssl/private.pfx", "secret");
              });
          })
                .UseStartup<Startup>()
                .Build();
    }
    */
}
