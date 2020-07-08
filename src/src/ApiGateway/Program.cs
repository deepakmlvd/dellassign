using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using edesign.ApiGateway;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                CreateWebHostBuilder(args).UseIISIntegration().Build().Run();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            try
            {
                IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args);

                var webHostBuilder = builder.ConfigureServices(s => s.AddSingleton(builder))
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        string environment = hostingContext.HostingEnvironment.EnvironmentName;
                        config.AddJsonFile("appsettings.json", true, true);
                        config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
                        config.AddJsonFile(Path.Combine("configuration", $"configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json"), true, true);

                        Console.WriteLine("Configuration File: " + Path.Combine("configuration", $"configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json"));

                    });
                return webHostBuilder.UseStartup<Startup>();
            }
            finally
            { }

        }
    }
}
