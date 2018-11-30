using System.Collections.Generic;

namespace PicSort.Core.Classifiers
{
    public interface IClassifier
    {
        void Classify(List<ImageInfo> images, DateInterval interval = DateInterval.Day, bool useAllIntervals = false);
    }
}