using System;
using System.IO;
using System.Threading.Tasks;
using PCLStorage;

namespace slimWallet.Data
{
    public class FileRepository
    {
        private IFolder _folder;

        public async Task<string> SaveAsync(Stream stream)
        {
            var folder = await InitFolderAsync();
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var file = await folder.CreateFileAsync(fileName,
                CreationCollisionOption.ReplaceExisting);
            using (var writer = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                await stream.CopyToAsync(writer);
            }
            return fileName;
        }

        public async Task DeleteAsync(string fileName)
        {
            var folder = await InitFolderAsync();
            ExistenceCheckResult result = await folder.CheckExistsAsync(fileName);
            if(result == ExistenceCheckResult.FileExists){
                var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                await file.DeleteAsync();
            }
        }

        public async Task<Stream> ReadAsync(string fileName)
        {
            var folder = await InitFolderAsync();
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            return await file.OpenAsync(PCLStorage.FileAccess.Read);
        }

        private async Task<IFolder> InitFolderAsync() => _folder ??
                (_folder = await FileSystem.Current.LocalStorage.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists));
    }
}
