namespace FileSort.Core.Classifiers.Date
{
    public enum RecursiveMode
    {
        /// <summary>
        /// Classify files from current folder
        /// </summary>
        None,
        /// <summary>
        /// Go through each folder and classify files
        /// </summary>
        InsideExistingFolder,
        /// <summary>
        /// Move files to root folder and then classify them
        /// </summary>
        RootFolder
    }
}