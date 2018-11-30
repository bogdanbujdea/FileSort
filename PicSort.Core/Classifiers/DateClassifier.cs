using System.Collections.Generic;

namespace PicSort.Core.Classifiers
{
    public class DateClassifier : IClassifier
    {
        public void Classify(List<ImageInfo> images, DateInterval interval = DateInterval.Day, bool useAllIntervals = false)
        {
            foreach (var image in images)
            {
                if (!useAllIntervals)
                {
                    image.NewPath = DirectoryBuilder.BuildNewPath(image, interval);
                }
                else
                {
                    ApplyMultipleIntervals(interval, image);
                }
            }
        }

        private void ApplyMultipleIntervals(DateInterval interval, ImageInfo image)
        {
            var initialPath = image.CurrentPath;
            for (var i = (int) DateInterval.Year; i >= (int) interval; i--)
            {
                image.NewPath = DirectoryBuilder.BuildNewPath(image, (DateInterval) i);
                image.CurrentPath = image.NewPath;
            }

            image.CurrentPath = initialPath;
        }
    }
}
