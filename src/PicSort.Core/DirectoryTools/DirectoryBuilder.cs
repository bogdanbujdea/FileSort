using PicSort.Core.Classifiers;
using PicSort.Core.Classifiers.Date;

using System.IO;

namespace PicSort.Core.DirectoryTools
{
    public static class DirectoryBuilder
    {
        public static string BuildNewPathByDate(MediaFileInfo mediaFileInfo, DateInterval interval)
        {
            var newDirectoryName = mediaFileInfo.ModifiedDate.GetName(interval);
            var fileInfo = new FileInfo(mediaFileInfo.CurrentPath);
            var oldDirectoryPath = fileInfo.Directory?.FullName;
            return Path.Combine(oldDirectoryPath, newDirectoryName, fileInfo.Name);
        }
    }
}
