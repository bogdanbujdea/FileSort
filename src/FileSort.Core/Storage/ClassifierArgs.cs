using FileSort.Core.Classifiers.Date;

namespace FileSort.Core.Storage
{
    public abstract class ClassifierArgs
    {
        public RecursiveMode RecursiveMode { get; set; }

        public string DirectoryPath { get; set; }
    }
}