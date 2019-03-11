using FileSort.Core.Classifiers;

using System.Collections.Generic;

namespace FileSort.Core.Storage
{
    public interface IStorageUtilities
    {
        void MoveFiles(List<MediaFileInfo> files);

        List<MediaFileInfo> RetrieveMediaFiles(ClassifierArgs args);
    }
}
