using CommonServiceLocator;
using IriaBridge.Domain;
using IriaBridge.SystemSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class BridgeItemRepository : Repository<BridgeItem>
    {

        protected override async Task<ICollection<BridgeItem>> GetRepository()
        {
            return ListBridgeItems();
        }

        private ICollection<BridgeItem> ListBridgeItems()
        {

            var settings = ServiceLocator.Current.GetInstance(typeof(BridgeSettingsPresenter)) as BridgeSettingsPresenter;
            string root = settings.LocalRepository;
            var items = new ObservableCollection<BridgeItem>();
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            foreach (string subdirectory in subdirectoryEntries)
                items.Add(ProcessDirectory(subdirectory));

            return items;
        }

        private BridgeItem ProcessDirectory(string directory)
        {
            if(Directory.Exists(directory + @"\data"))
            return LoadFromExisting(directory);

            return LoadFromUnExisting(directory);
        }

        private static BridgeItem LoadFromExisting(string directory)
        {
            string readText = File.ReadAllText(directory + @"\data\info.txt");

            var bItem = JsonConvert.DeserializeObject<BridgeItem>(readText);
            bItem.PreviewImage = directory + @"\data\preview.jpg";
            bItem.DataInfoPath = directory + @"\data\info.txt";
            bItem.DataDirectory = directory + @"\data";
            bItem.Directory = directory;
            bItem.Type = GetType(directory);
            return bItem;
        }
        private static BridgeItem LoadFromUnExisting(string directory)
        {
            var dInfo = new DirectoryInfo(directory);
            return new BridgeItem() { Name= dInfo.Name,
                DataDirectory = directory + @"\data",
                DataInfoPath = directory + @"\data\info.txt",
                Type = GetType(directory) };
        }

        private static string GetType(string directory)
        {
            var dInfo = new DirectoryInfo(directory);
            var fileNames = dInfo.GetFiles().Select((f,next) => f.Name);
            
            return fileNames.Count(name => name.EndsWith(".lib") || name.EndsWith(".lib.inn") || name.EndsWith(".lib.mtt")
            || name.EndsWith(".lib.txx")) == 4 ? "Model" : "Unknown";

        }

        public override BridgeItem UpdateEntity(BridgeItem item)
        {
            var dInfo = new DirectoryInfo(item.DataDirectory);
            if (!dInfo.Exists) dInfo.Create();
            
            var bItem = JsonConvert.SerializeObject(item);
            File.WriteAllText(item.DataInfoPath, bItem);

            return item;
        }
    }
}
