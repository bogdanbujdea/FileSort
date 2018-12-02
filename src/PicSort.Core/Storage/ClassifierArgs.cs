using PicSort.Core.Classifiers.Date;

namespace PicSort.Core.Storage
{
    public abstract class ClassifierArgs
    {
        public RecursiveMode RecursiveMode { get; set; }

        public string DirectoryPath { get; set; }
    }
}