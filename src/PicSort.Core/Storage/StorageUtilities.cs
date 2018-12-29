using PicSort.Core.Classifiers;
using PicSort.Core.Classifiers.Date;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PicSort.Core.Storage
{
    public class StorageUtilities : IStorageUtilities
    {
        public void MoveFiles(List<MediaFileInfo> files)
        {
            foreach (var imageInfo in files)
            {
                Directory.CreateDirectory(new FileInfo(imageInfo.NewPath).Directory?.FullName);
                File.Move(imageInfo.CurrentPath, imageInfo.NewPath);
            }
        }

        public List<MediaFileInfo> RetrieveMediaFiles(ClassifierArgs args)
        {
            IEnumerable<string> files;
            if (args.RecursiveMode == RecursiveMode.RootFolder)
            {
                MoveFilesToRoot(args);
                files = Directory.GetFiles(args.DirectoryPath, searchPattern: "*.*", searchOption: SearchOption.AllDirectories);
            }
            else
            {
                files = Directory.EnumerateFiles(args.DirectoryPath);
            }
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
            return images;
        }

        public void MoveFilesToRoot(ClassifierArgs args)
        {
            var files = Directory.GetFiles(args.DirectoryPath, searchPattern: "*.*", searchOption: SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    var newPath = Path.Combine(args.DirectoryPath, new FileInfo(file).Name);
                    File.Move(file, newPath);
                }
                catch (IOException)
                {
                    HandleNameCollision(args, file);
                }
            }

            Console.WriteLine($"Moved {files.Count()} to root directory");
        }

        private void HandleNameCollision(ClassifierArgs args, string file)
        {
            var fileInfo = new FileInfo(file);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var suffix = 1;
            while (true)
            {
                var newPath = $"{fileNameWithoutExtension}-{suffix}{fileInfo.Extension}";
                Console.WriteLine($"Name conflict for {fileInfo.Name}");
                if (File.Exists(Path.Combine(args.DirectoryPath,
                    newPath)))
                {
                    suffix++;
                }
                else
                {
                    File.Move(file, newPath);
                    break;
                }
            }
        }
    }
}