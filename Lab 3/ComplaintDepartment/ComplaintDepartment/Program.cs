using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ComplaintDepartment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /*  USE THIS TO DO LOCAL REVIEW  
            public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false)
                .Build();
        */
        //   PRODUCTION - SET SSL / HOST

       // COMMENT THIS OUT TO RUN LOCAL
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseKestrel(options =>
             {
                 // Only host SSL
                 //options.Listen(IPAddress.Loopback, 5000);
                 options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                 {
                     listenOptions.UseHttps("/var/www/eugeneprogramming.com/ssl/eugeneprogramming.crt");
                 });
             })
         .UseStartup<Startup>();


        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .UseUrls("https://lab2.cs296.eugeneprogramming.com/")
               .UseDefaultServiceProvider(options =>
               options.ValidateScopes = false)
               .Build();
       // ALL THE WAY TO HERE
    }
}
