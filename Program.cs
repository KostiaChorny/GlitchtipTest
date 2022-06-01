using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sentry;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sentry.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SentryTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.SetBasePath(Directory.GetCurrentDirectory());
                    c.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConfiguration(context.Configuration);
                    builder.AddConsole();
                    builder.AddSentry();
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<MySettings>(context.Configuration.GetSection(nameof(MySettings)));
                    services.AddHostedService<Service>();
                });

            await builder.RunConsoleAsync();
        }

        public static void Method1()
        {
            Method2();
        }
        public static void Method2()
        {
            Method3();
        }
        public static void Method3()
        {
            Method4();
        }
        public static void Method4()
        {
            Method5();
        }
        public static void Method5()
        {
            try
            {
                throw new InvalidOperationException("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                //var a = 0;
                //Console.WriteLine(1 / a);
            }
            catch (Exception ex)
            {
                throw new CustomException("Test Exception", ex);
            }
            
        }

        public class CustomException : Exception
        {
            public CustomException(string message, Exception innerException)
            {

            }
        }
    }
}
