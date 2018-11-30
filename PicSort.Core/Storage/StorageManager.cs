using System.Collections.Generic;
using System.IO;
using System.Linq;
using PicSort.Core.Classifiers;

namespace PicSort.Core.Storage
{
    public class StorageManager
    {
        private readonly IClassifier _classifier;

        public StorageManager(IClassifier classifier)
        {
            _classifier = classifier;
        }

        public void MoveFiles(MoveInfo moveInfo)
        {
            var files = Directory.EnumerateFiles(moveInfo.DirectoryPath);
            var images = files.Select(f =>
            {
                var fileInfo = new FileInfo(f);
                return new ImageInfo
                {
                    CurrentPath = fileInfo.FullName,
                    FileName = fileInfo.Name,
                    ModifiedDate= fileInfo.LastWriteTime,
                };
            }).ToList();
            _classifier.Classify(images, moveInfo.Interval, moveInfo.UseAllIntervals);
            foreach (var imageInfo in images)
            {
                File.Move(imageInfo.CurrentPath, imageInfo.NewPath);
            }
        }
    }

    public class MoveInfo
    {
        public bool UseAllIntervals { get; set; }

        public bool Recursive { get; set; }

        public string DirectoryPath { get; set; }

        public DateInterval Interval { get; set; }
    }
}
