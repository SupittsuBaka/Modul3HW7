using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modul3HW7.Configs;
using Modul3HW7.Services.Abstracts;
using Modul3HW7.Enums;

namespace Modul3HW7
{
    public class Starter
    {
        private readonly ILogger _logger;
        private readonly IBackupService _backupService;

        public Starter(ILogger logger, IBackupService backupService, IConfigService configService)
        {
            _logger = logger;
            _backupService = backupService;
            _logger.BackupHandler += () => _backupService.BackUp(_logger.File);
        }

        public async Task Run()
        {
            var taskList = new List<Task>
            {
                Task.Run(async () =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        var rand = new Random();
                        var logStatus = (LogStatus)rand.Next(0, 4);
                        var lognumber = i + 1;
                        await _logger.WriteLogAsync($"Log №{lognumber}(1)", logStatus);
                    }
                }),

                Task.Run(async () =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        var rand = new Random();
                        var logStatus = (LogStatus)rand.Next(0, 4);
                        var lognumber = i + 1;
                        await _logger.WriteLogAsync($"Log №{lognumber}(2)", logStatus);
                    }
                })
            };

            await Task.WhenAll(taskList);
        }
    }
}
