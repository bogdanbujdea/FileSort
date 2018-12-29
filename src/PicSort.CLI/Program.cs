using System;
using McMaster.Extensions.CommandLineUtils;

using PicSort.Core.Storage;
using PicSort.Core.Classifiers.Date;

using System.IO;

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

        [Option(Description = "Move all files to root", ShortName = "m")]
        public bool MoveToRoot{ get; set; }

        private void OnExecute()
        {
            var dateClassifier = new DateClassifier();
            if (WorkingDirectory == null)
                WorkingDirectory = Directory.GetCurrentDirectory();
            var storageUtilities = new StorageUtilities();
            var manager = new StorageManager(dateClassifier, storageUtilities);

            var dateClassifierArgs = new DateClassifierArgs
            {
                Interval = Interval,
                DirectoryPath = WorkingDirectory,
                RecursiveMode = Recursive ? RecursiveMode.RootFolder : RecursiveMode.None,
                UseMultipleClassifiers = UseMultipleClassifiers
            };
            if (MoveToRoot)
            {
                Console.WriteLine("Moving files to root");
                storageUtilities.MoveFilesToRoot(dateClassifierArgs);
                return;
            }
            manager.OrganizeDirectory(dateClassifierArgs);
        }
    }
}
