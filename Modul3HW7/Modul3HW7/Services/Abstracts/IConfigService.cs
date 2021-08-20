using Modul3HW7.Configs;

namespace Modul3HW7.Services.Abstracts
{
    public interface IConfigService
    {
        LoggerConfig LoggerConfig { get; }
        BackupConfig BackupConfig { get; }
    }
}
