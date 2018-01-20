using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MMA_site_app.Data;

namespace MMA_site_app {
    public class Program {

        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false)
                .Build();
    }

    //public static void Main(string[] args) {
    //    var host = BuildWebHost(args);

    //    using (var scope = host.Services.CreateScope()) {
    //        var services = scope.ServiceProvider;
    //        try {
    //            var context = services.GetRequiredService<FighterContext>();
    //            DbInitializer.Initialize(context);
    //        }
    //        catch (Exception ex) {
    //            var logger = services.GetRequiredService<ILogger<Program>>();
    //            logger.LogError(ex, "An error occurred while seeding the database.");
    //        }
    //    }

    //    host.Run();
    //}

    //public static IWebHost BuildWebHost(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //            .UseStartup<Startup>()
    //            .Build();
}

