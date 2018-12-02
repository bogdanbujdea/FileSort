using PicSort.Core.Classifiers;

using System.Collections.Generic;

namespace PicSort.Core.Storage
{
    public interface IStorageUtilities
    {
        void MoveFiles(List<MediaFileInfo> files);

        List<MediaFileInfo> RetrieveMediaFiles(ClassifierArgs args);
    }
}
