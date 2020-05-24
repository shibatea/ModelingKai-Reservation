using System.IO;
using Cli.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Infrastructure;

namespace Cli
{
    internal static class Startup
    {
        private static string Env =>
#if DEBUG
            "Development";
#else
            "Production";
#endif

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    // ���O�@�\��DI�ݒ�
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    // �ݒ�t�@�C���ǂݍ���
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json");
                    builder.AddJsonFile($"appsettings.{Env}.json");
                    builder.AddEnvironmentVariables();
                })
                .ConfigureServices((context, collection) =>
                {
                    // SampleSettings��DI�ݒ�
                    // collection.Configure<SampleSettings>(context.Configuration.GetSection(nameof(SampleSettings)));

                    // Repository��DI�ݒ�
                    collection.AddSingleton<I�\���]Repository, �\���]Repository>();

                    // Controller��DI�ݒ�
                    collection.AddTransient<�\��Controller>();
                });
    }
}