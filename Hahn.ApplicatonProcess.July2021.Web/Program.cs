using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicatonProcess.July2021.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration().WriteTo.RollingFile(configSettings["Logging:LogPath"]).CreateLogger();

            return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(config => { config.AddConfiguration(configSettings); }).ConfigureLogging(logging => { logging.AddSerilog(); })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).UseSerilog();

        }
    }
}
