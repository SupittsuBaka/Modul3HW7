using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul3HW7.Services.Abstracts
{
    public interface IFileService
    {
        Task WriteToFileAsync(StreamWriter streamWriter, string text);
    }
}
