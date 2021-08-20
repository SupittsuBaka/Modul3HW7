using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Modul3HW7.Services;
using Modul3HW7.Services.Abstracts;

namespace Modul3HW7
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviseProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IBackupService, BackupService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviseProvider.GetService<Starter>();
            await starter.Run();
        }
    }
}
