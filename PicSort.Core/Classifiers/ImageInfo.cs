using System;

namespace PicSort.Core.Classifiers
{
    public class ImageInfo
    {
        public string CurrentPath { get; set; }

        public string NewPath { get; set; }

        public string FileName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
