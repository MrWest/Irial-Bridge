using IriaBridge.DataAccess;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Business
{
    public  class BridgeItemApplication: ApplicationBase<BridgeItem, BridgeItemRepository>
    {
        public void Export(BridgeItem item)
        {
            string zipPath = @"D:\Enrike\Programming\Repos\BridgeEnvironment\Exported\";
            string fileName = zipPath +item.Name + ".ibr";

           ZipFile.CreateFromDirectory(item.Directory, fileName, CompressionLevel.Fastest, true);
           File.Encrypt(fileName);

        }
    }
}
