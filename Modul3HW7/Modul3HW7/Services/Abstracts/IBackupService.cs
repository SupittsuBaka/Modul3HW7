using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW7.Services.Abstracts
{
    public interface IBackupService
    {
        void BackUp(FileInfo fileInfo);
    }
}
