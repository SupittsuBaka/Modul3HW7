using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Modul3HW7.Enums;
using Modul3HW7.Services.Abstracts;
using Modul3HW7.Configs;

namespace Modul3HW7.Services
{
    public class Logger : ILogger
    {
        private readonly LoggerConfig _config;
        private readonly IFileService _fileService;
        private readonly StreamWriter _streamWriter;
        private readonly SemaphoreSlim _semaphoreSlim;
        private int _logsCounter;

        public Logger(IConfigService configService, IFileService fileService)
        {
            _config = configService.LoggerConfig;
            _fileService = fileService;
            Directory.CreateDirectory(_config.Path);
            File = new FileInfo($"{_config.Path}/{DateTime.UtcNow.ToString(_config.NameFormat)}{_config.FileExtension}");
            _streamWriter = new StreamWriter(File.FullName);
            _semaphoreSlim = new SemaphoreSlim(1);
            _logsCounter = 0;
        }

        public event Action BackupHandler;
        public FileInfo File { get; private set; }

        public async Task WriteLogAsync(string message, LogStatus status)
        {
            await _semaphoreSlim.WaitAsync();
            await _fileService.WriteToFileAsync(_streamWriter, $"{DateTime.UtcNow.ToString(_config.LogFormat)}:{status}:{message}");
            _logsCounter++;
            if (_logsCounter >= _config.RowsToBackup)
            {
                _logsCounter = 0;
                BackupHandler.Invoke();
            }

            _semaphoreSlim.Release();
        }
    }
}