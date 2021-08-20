using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modul3HW7.Configs;
using Modul3HW7.Services.Abstracts;

namespace Modul3HW7.Services
{
    public class BackupService : IBackupService
    {
        private readonly BackupConfig _config;
        private DirectoryInfo _directoryInfo;
        private int _backupsCounter;

        public BackupService(
            IConfigService configService)
        {
            _config = configService.BackupConfig;
            _directoryInfo = new DirectoryInfo(_config.Path);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }

            _backupsCounter = 1;
            DeletingFiles();
        }

        public void BackUp(FileInfo fileInfo)
        {
            fileInfo.CopyTo($"{_directoryInfo.FullName}/{DateTime.UtcNow.ToString(_config.NameFormat)}({_backupsCounter}){_config.FileExtension}");
            _backupsCounter++;
        }

        private void DeletingFiles()
        {
            foreach (var item in _directoryInfo.GetFiles())
            {
                item.Delete();
            }
        }
    }
}
