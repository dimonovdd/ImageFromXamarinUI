using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Sample.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> SaveAsync(Stream stream)
        {
            var dir = FileSystem.CacheDirectory;
            var filepath = Path.Combine(dir, "image.png");

            if (File.Exists(filepath))
                File.Delete(filepath);

            using var fileStream = File.OpenWrite(filepath);
            await stream.CopyToAsync(fileStream);
            fileStream.Close();

            return filepath;
        }
    }
}
