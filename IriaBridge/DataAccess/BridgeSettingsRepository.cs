using IriaBridge.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class BridgeSettingsRepository:  Repository<BridgeSettings>
    {
        static string root = "IrialBridge";
        static string applicaionPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), root);
        static string settingsFile = applicaionPath + @"\settings.txt";
        BridgeSettings _bridgeSettings;
        public BridgeSettingsRepository()
        {

            if (File.Exists(settingsFile))
            {
                string readText = File.ReadAllText(settingsFile);
                _bridgeSettings = JsonConvert.DeserializeObject<BridgeSettings>(readText);
                // LumionVersions = settings.LumionVersions;
            }
            else
            {
                _bridgeSettings = new BridgeSettings();
            }
        }

        public override BridgeSettings UpdateEntity(BridgeSettings settings)
        {
            if (!Directory.Exists(applicaionPath))
                Directory.CreateDirectory(applicaionPath);

            var textSettings = JsonConvert.SerializeObject(settings);
            File.WriteAllText(settingsFile, textSettings);
            return settings;
        }

        public BridgeSettings BridgeSettings { get { return _bridgeSettings; } }
    }
}
