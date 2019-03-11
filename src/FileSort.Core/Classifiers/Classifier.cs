using FileSort.Core.Storage;

using System.Collections.Generic;

namespace FileSort.Core.Classifiers
{
    public interface IClassifier<T> where T: ClassifierArgs
    {
        void Classify(List<MediaFileInfo> images, T args);
    }
}