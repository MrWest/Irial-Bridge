using CommonServiceLocator;
using IriaBridge.DataAccess;
using IriaBridge.Domain;
using IriaBridge.SystemSettings;
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

            var settings = ServiceLocator.Current.GetInstance(typeof(BridgeSettingsPresenter)) as BridgeSettingsPresenter;
            string zipPath = settings.ExportDirectory;
            string fileName = zipPath +item.Name + ".ibr";

           ZipFile.CreateFromDirectory(item.Directory, fileName, CompressionLevel.Fastest, true);
           File.Encrypt(fileName);

        }

        public void Import(string file)
        {
            var settings = ServiceLocator.Current.GetInstance(typeof(BridgeSettingsPresenter)) as BridgeSettingsPresenter;
            string root = settings.LocalRepository;
            ZipFile.ExtractToDirectory(file, root);

        }

        public void ChangePreview(string newImagePath, BridgeItem item )
        {
            string previewPath = Path.Combine(item.DataDirectory, "preview.jpg");
            File.Copy(newImagePath, previewPath, true);
        }

        public void Install(BridgeItem item)
        {

            var settings = ServiceLocator.Current.GetInstance(typeof(BridgeSettingsPresenter)) as BridgeSettingsPresenter;
            string targetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), settings.TargetedVersion, "Library", item.Name);
            //3d assets.C:\Users\Atlas\Documents\Lumion 10.0\Library AQUÍ CREAR 6 FOLDERS: Naturaleza / Personas y Animales/ Interior / Exterior / Transporte / Luces(extensiones(.lib /.lib.Inn /.lib.mtt /.lib.txx) pegar archivos
            DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetPath);
            if (!targetDirectoryInfo.Exists)
                targetDirectoryInfo.Create();

            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(item.Directory);
            var files = sourceDirectoryInfo.GetFiles();
            foreach (FileInfo fi in files)
                fi.CopyTo(Path.Combine(targetPath, fi.Name));
            item.InstallDirectory = targetPath;
            Repository.UpdateEntity(item);

        }

        public void Uninstall(BridgeItem item)
        {

            DirectoryInfo installationDirectoryInfo = new DirectoryInfo(item.InstallDirectory);
            installationDirectoryInfo.Delete(true);
            item.InstallDirectory = null;
            Repository.UpdateEntity(item);

        }
    }
}
