using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW7.Configs
{
    public class LoggerConfig
    {
        public string Path { get; set; }
        public string NameFormat { get; set; }
        public string FileExtension { get; set; }
        public string LogFormat { get; set; }
        public int RowsToBackup { get; set; }
    }
}
