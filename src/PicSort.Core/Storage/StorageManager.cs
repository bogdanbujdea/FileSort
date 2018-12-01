using PicSort.Core.Classifiers;
using System.IO;
using System.Linq;

namespace PicSort.Core.Storage
{
    public class StorageManager
    {
        private readonly IClassifier<ClassifierArgs> _classifier;

        public StorageManager(IClassifier<ClassifierArgs> classifier)
        {
            _classifier = classifier;
        }

        public void MoveFiles(ClassifierArgs args)
        {
            var files = Directory.EnumerateFiles(args.DirectoryPath);
            var images = files.Select(f =>
            {
                var fileInfo = new FileInfo(f);
                return new MediaFileInfo
                {
                    CurrentPath = fileInfo.FullName,
                    FileName = fileInfo.Name,
                    ModifiedDate = fileInfo.LastWriteTime,
                };
            }).ToList();
            _classifier.Classify(images, args);
            foreach (var imageInfo in images)
            {
                Directory.CreateDirectory(new FileInfo(imageInfo.NewPath).Directory?.FullName);
                File.Move(imageInfo.CurrentPath, imageInfo.NewPath);
            }
        }
    }
}
