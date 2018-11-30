using System.IO;

namespace PicSort.Core.Classifiers
{
    public class DirectoryBuilder
    {
        public static string BuildNewPath(ImageInfo imageInfo, DateInterval interval)
        {
            var newDirectoryName = imageInfo.ModifiedDate.GetName(interval);
            var fileInfo = new FileInfo(imageInfo.CurrentPath);
            var oldDirectoryPath = fileInfo.Directory?.FullName;
            return Path.Combine(oldDirectoryPath, newDirectoryName, fileInfo.Name);
        }
    }
}
