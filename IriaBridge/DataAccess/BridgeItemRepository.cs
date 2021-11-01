using IriaBridge.Domain;
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
            //var items =  new ObservableCollection<BridgeItem>();
            //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            //return items;
            return ListBridgeItems();
        }

        private ICollection<BridgeItem> ListBridgeItems()
        {
            string root = @"D:\Enrike\Programming\Repos\IrialBridge";
            var items = new ObservableCollection<BridgeItem>();
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            foreach (string subdirectory in subdirectoryEntries)
                items.Add(ProcessDirectory(subdirectory));
            //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            return items;
        }

        private BridgeItem ProcessDirectory(string directory)
        {
            string readText = File.ReadAllText(directory + @"\data\info.txt");

            var bItem = JsonConvert.DeserializeObject<BridgeItem>(readText);
            bItem.PreviewImage = directory + @"\data\preview.jpg";
            bItem.DataInfoPath = directory + @"\data\info.txt";
            bItem.Directory = directory;
            return bItem;
        }

        public override BridgeItem UpdateEntity(BridgeItem entity)
        {
            var bItem = JsonConvert.SerializeObject(entity);
            File.WriteAllText(entity.DataInfoPath, bItem);
            return entity;
        }
    }
}
