using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW7.Enums;

namespace Modul3HW7.Services.Abstracts
{
    public interface ILogger
    {
        event Action BackupHandler;
        public FileInfo File { get; }
        public Task WriteLogAsync(string message, LogStatus status);
    }
}
