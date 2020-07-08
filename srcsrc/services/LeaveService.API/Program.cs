using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Helper.Utils;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LeaveService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO: insert in system variables and fetch
            //LeaveHandlerSettings.ConnectionString = HelperUtility.GetEnvironmentVariable("LeaveDB_ConnectionString");
            //Hard coded for demo
            LeaveHandlerSettings.ConnectionString = @"Server=localhost\SQLEXPRESS;Database=leave_db;Trusted_Connection=True;";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
