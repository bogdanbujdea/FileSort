using PicSort.Core.Storage;

using System.Collections.Generic;

namespace PicSort.Core.Classifiers
{
    public interface IClassifier<T> where T: ClassifierArgs
    {
        void Classify(List<MediaFileInfo> images, T args);
    }
}