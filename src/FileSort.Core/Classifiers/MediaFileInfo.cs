using System;

namespace FileSort.Core.Classifiers
{
    public class MediaFileInfo
    {
        public string CurrentPath { get; set; }

        public string NewPath { get; set; }

        public string FileName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
