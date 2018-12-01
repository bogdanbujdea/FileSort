using PicSort.Core.Storage;
using PicSort.Core.Classifiers.Date;

namespace PicSort.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateClassifier = new DateClassifier();
            var manager = new StorageManager(dateClassifier);
            var dateClassifierArgs = new DateClassifierArgs
            {
                Interval = DateInterval.Day,
                DirectoryPath = @"D:\png",
                Recursive = true,
                UseAllIntervals = true
            };
            manager.MoveFiles(dateClassifierArgs);
        }
    }
}
