using PicSort.Core.Storage;
using PicSort.Core.Classifiers;

namespace PicSort.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new StorageManager(new DateClassifier());
            manager.MoveFiles(new MoveInfo
            {
                Interval = DateInterval.Day,
                DirectoryPath = @"D:\png",
                Recursive = true,
                UseAllIntervals = true
            });
        }
    }
}
