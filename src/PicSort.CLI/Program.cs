using System.IO;
using McMaster.Extensions.CommandLineUtils;
using PicSort.Core.Storage;
using PicSort.Core.Classifiers.Date;

namespace PicSort.CLI
{
    class Program
    {

        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "Recursive search", ShortName = "r")]
        public bool Recursive { get; }

        [Option(Description = "The directory to search", ShortName = "d")]
        public string WorkingDirectory { get; set; }

        [Option(Description = "Use multiple classifiers", ShortName = "u")]
        public bool UseMultipleClassifiers { get; set; }

        [Option(Description = "year/month/day/hour", ShortName = "i")]
        public DateInterval Interval { get; set; }

        private void OnExecute()
        {
            var dateClassifier = new DateClassifier();
            if (WorkingDirectory == null)
                WorkingDirectory = Directory.GetCurrentDirectory();
            var manager = new StorageManager(dateClassifier, new StorageUtilities());
            var dateClassifierArgs = new DateClassifierArgs
            {
                Interval = Interval,
                DirectoryPath = WorkingDirectory,
                RecursiveMode = Recursive ? RecursiveMode.RootFolder : RecursiveMode.None,
                UseMultipleClassifiers = UseMultipleClassifiers
            };
            manager.OrganizeDirectory(dateClassifierArgs);
        }
    }
}
