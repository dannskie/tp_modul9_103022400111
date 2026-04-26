using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_MODUL9_103022400111
{
    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }
    internal class CovidConfig
    {
        public Config config;
        private const string filePath = "covid_config.json";
        public CovidConfig()
        {
            ReadConfigFile();
        }

        private void ReadConfigFile()
        {
            
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(jsonString);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
            }
            WriteNewConfigFile() ;
        }
    }
}
