using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileSort.Core.Classifiers;

namespace FileSort.Core.Storage
{
    public class StorageManager
    {
        private readonly IClassifier<ClassifierArgs> _classifier;
        private readonly IStorageUtilities _storageUtilities;

        public StorageManager(IClassifier<ClassifierArgs> classifier, IStorageUtilities storageUtilities)
        {
            _classifier = classifier;
            _storageUtilities = storageUtilities;
        }

        public void OrganizeDirectory(ClassifierArgs args)
        {
            var files = _storageUtilities.RetrieveMediaFiles(args);
            _classifier.Classify(files, args);
            _storageUtilities.MoveFiles(files);
        }

        public List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path).ToList();
        }
    }
}
