using System.IO;
using System.Threading.Tasks;

namespace slimWallet.Data
{
    public class FileRepository
    {
        public async Task<string> SaveAsync(Stream stream)
        {
            var fileName = FileHelper.RandomImageFileName;
            using (stream)
            {
                using (var file = File.Create(fileName.ToAbsolutePath()))
                {
                    await stream.CopyToAsync(file);
                }
            }
            return fileName;
        }

        public void Delete(string fileName)
        {
            var path = fileName.ToAbsolutePath();
            if (File.Exists(path))
                File.Delete(path);
        }

        public Stream Read(string fileName)
        {
            var path = fileName.ToAbsolutePath();
            return File.Exists(path) ? File.OpenRead(path) : null;
        }
    }
}