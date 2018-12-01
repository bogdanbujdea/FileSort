using PicSort.Core.Storage;

namespace PicSort.Core.Classifiers.Date
{
    public class DateClassifierArgs: ClassifierArgs
    {
        public DateClassifierArgs()
        {
            
        }

        public DateClassifierArgs(DateInterval interval, bool useAllIntervals = false)
        {
            Interval = interval;
            UseAllIntervals = useAllIntervals;
        }

        public bool UseAllIntervals { get; set; }

        public DateInterval Interval { get; set; }
    }
}