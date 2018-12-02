using PicSort.Core.Storage;
using PicSort.Core.DirectoryTools;

using System;
using System.Collections.Generic;

namespace PicSort.Core.Classifiers.Date
{
    public class DateClassifier: IClassifier<ClassifierArgs>
    {
        public void Classify(List<MediaFileInfo> images, ClassifierArgs args)
        {
            var dateArgs = args as DateClassifierArgs;
            if (images == null)
            {
                throw new ArgumentNullException(nameof(images));
            }
            if (dateArgs == null)
            {
                throw new ArgumentNullException(nameof(dateArgs));
            }
            foreach (var image in images)
            {
                if (!dateArgs.UseAllIntervals)
                {
                    image.NewPath = DirectoryBuilder.BuildNewPathByDate(image, dateArgs.Interval);
                }
                else
                {
                    ApplyMultipleIntervals(dateArgs.Interval, image);
                }
            }
        }

        private void ApplyMultipleIntervals(DateInterval interval, MediaFileInfo mediaFile)
        {
            var initialPath = mediaFile.CurrentPath;
            for (var i = (int) DateInterval.Year; i >= (int) interval; i--)
            {
                mediaFile.NewPath = DirectoryBuilder.BuildNewPathByDate(mediaFile, (DateInterval) i);
                mediaFile.CurrentPath = mediaFile.NewPath;
            }

            mediaFile.CurrentPath = initialPath;
        }
    }
}
