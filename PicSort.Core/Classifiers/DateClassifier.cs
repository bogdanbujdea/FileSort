using System.Collections.Generic;

namespace PicSort.Core.Classifiers
{
    public class DateClassifier : IClassifier
    {
        public void Classify(List<ImageInfo> images, DateInterval interval = DateInterval.Day, bool useAllIntervals = false)
        {
            if (useAllIntervals)
            {
                foreach (var image in images)
                {
                    var initialPath = image.CurrentPath;
                    for (var i = (int)DateInterval.Year; i > 0; i--)
                    {
                        image.NewPath = DirectoryBuilder.BuildNewPath(image, (DateInterval)i);
                        image.CurrentPath = image.NewPath;
                    }

                    image.CurrentPath = initialPath;
                }
            }
            else
            {
                AppendDateNameToPath(images, interval);
            }
        }

        private void AppendDateNameToPath(List<ImageInfo> images, DateInterval interval)
        {
            foreach (var imageInfo in images)
            {
                imageInfo.NewPath = DirectoryBuilder.BuildNewPath(imageInfo, interval);
            }
        }
    }
}
