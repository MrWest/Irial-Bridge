
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    public class BridgeSettings: Entity
    {
        string _targetedVersion;
        public BridgeSettings()
        {
            LocalRepository = @"D:\Enrike\Programming\Repos\IrialBridge";
            ExportDirectory = @"D:\Enrike\Programming\Repos\BridgeEnvironment\Exported\";
            LumionVersions = LumionVersionsInstalled();
            TargetedVersion = LumionVersions.Length > 0 ? LumionVersions.First() : "Lumion 10.0";
        }
        public string LocalRepository { get; set; }
        public string ExportDirectory { get; set; }
        public string[] LumionVersions { get; set; }
        public string TargetedVersion { get; set; }

        static List<string> GetLumionsOnKey(RegistryKey key)
        {
           return key.GetSubKeyNames().Where(keyName =>
           {
               RegistryKey subkey = key.OpenSubKey(keyName);
               string displayName = subkey.GetValue("DisplayName") as string;
               return displayName != null &&  displayName.ToLower().Contains("lumion");
           }).Select(keyName => {
               RegistryKey subkey = key.OpenSubKey(keyName);
               string displayName = subkey.GetValue("DisplayName") as string;
               string displayVersion = subkey.GetValue("DisplayVersion") as string;
               return displayName + "  " + displayVersion;
           }).ToList();
        }
       static string[] LumionVersionsInstalled()
        {
            List<string> allLumionkeys = GetLumionsOnKey(Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"));
            allLumionkeys.AddRange(GetLumionsOnKey(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")));
            allLumionkeys.AddRange(GetLumionsOnKey(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall")));

            return allLumionkeys.Distinct().ToArray();
        }
    }
}
