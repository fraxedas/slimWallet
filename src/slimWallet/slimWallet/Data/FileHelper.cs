using System;
using System.IO;
using Xamarin.Essentials;

namespace slimWallet.Data
{
    public static class FileHelper
    {
        static FileHelper()
        {
            Directory.CreateDirectory(Images);
            Directory.CreateDirectory(Database);
        }

        private static string RootFolder => FileSystem.AppDataDirectory;
        private static string Images => Path.Combine(RootFolder, "Images");
        private static string Database => Path.Combine(RootFolder, "Database");
        public static string DatabasePath => Path.Combine(Database, "slimWallet.db3");

        public static string RandomImageFileName => $"{Guid.NewGuid()}.jpg";

        public static string ToAbsolutePath(this string fileName) => Path.Combine(Images, fileName);
    }
}
