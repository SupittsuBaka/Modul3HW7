using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modul3HW7.Services.Abstracts;

namespace Modul3HW7.Services
{
    public class FileService : IFileService
    {
        public async Task WriteToFileAsync(StreamWriter streamWriter, string text)
        {
            await streamWriter.WriteLineAsync(text);
            await streamWriter.FlushAsync();
        }
    }
}
