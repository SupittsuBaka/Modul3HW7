using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modul3HW7.Configs;
using Modul3HW7.Services.Abstracts;
using Newtonsoft.Json;

namespace Modul3HW7.Services
{
    public class ConfigService : IConfigService
    {
        private const string _configPath = "config.json";
        private Config _config;

        public ConfigService()
        {
            Init();
        }

        public LoggerConfig LoggerConfig => _config.LoggerConfig;
        public BackupConfig BackupConfig => _config.BackupConfig;

        private void Init()
        {
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(_configPath));
        }
    }
}
