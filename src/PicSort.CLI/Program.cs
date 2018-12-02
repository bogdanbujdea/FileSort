using PicSort.Core.Storage;
using PicSort.Core.Classifiers.Date;

namespace PicSort.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateClassifier = new DateClassifier();
            var manager = new StorageManager(dateClassifier, new StorageUtilities());
            var dateClassifierArgs = new DateClassifierArgs
            {
                Interval = DateInterval.Day,
                DirectoryPath = @"D:\png",
                RecursiveMode = RecursiveMode.RootFolder,
                UseAllIntervals = true
            };
            manager.OrganizeDirectory(dateClassifierArgs);
        }
    }
}
