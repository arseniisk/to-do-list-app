using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ToDoApi.Helpers;

namespace ToDoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var appSettings = GetAppSettings();

                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(appSettings.AppUrl);
                });

        private static AppSettings GetAppSettings()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();
            return configuration.GetSection("AppSettings").Get<AppSettings>();
        }
    }
}
