namespace PicSort.Core.Storage
{
    public abstract class ClassifierArgs
    {
        public bool Recursive { get; set; }
        
        public string DirectoryPath { get; set; }
    }
}