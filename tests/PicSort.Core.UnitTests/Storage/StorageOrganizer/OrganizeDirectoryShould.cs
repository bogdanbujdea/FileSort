using Moq;
using PicSort.Core.Classifiers;
using PicSort.Core.Classifiers.Date;
using PicSort.Core.Storage;
using System.Collections.Generic;
using Xunit;

namespace PicSort.Core.UnitTests.Storage.StorageOrganizer
{
    public class OrganizeDirectoryShould
    {
        private readonly Mock<IStorageUtilities> _storageUtilities;
        private readonly Mock<IClassifier<ClassifierArgs>> _classifier;
        private readonly StorageManager _storageManager;

        public OrganizeDirectoryShould()
        {
            _storageUtilities = new Mock<IStorageUtilities>();
            _classifier = new Mock<IClassifier<ClassifierArgs>>();
            _storageManager = new StorageManager(_classifier.Object, _storageUtilities.Object);

            _storageUtilities.Setup(s => s.RetrieveMediaFiles(It.IsAny<DateClassifierArgs>())).Returns(new List<MediaFileInfo>());
            _storageUtilities.Setup(s => s.MoveFiles(It.IsAny<List<MediaFileInfo>>()));
            _classifier.Setup(c => c.Classify(It.IsAny<List<MediaFileInfo>>(), It.IsAny<ClassifierArgs>()));
        }

        [Fact]
        public void retrieve_a_list_of_files_from_directory()
        {
            _storageManager.OrganizeDirectory(new DateClassifierArgs());

            _storageUtilities.Verify(s => s.RetrieveMediaFiles(It.IsAny<DateClassifierArgs>()), Times.Once);
        }

        [Fact]
        public void classify_the_found_files()
        {
            _storageManager.OrganizeDirectory(new DateClassifierArgs());

            _classifier.Verify(c => c.Classify(It.IsAny<List<MediaFileInfo>>(), It.IsAny<ClassifierArgs>()), Times.Once);
        }

        [Fact]
        public void move_the_files()
        {
            _storageManager.OrganizeDirectory(new DateClassifierArgs());
            _storageUtilities.Verify(s => s.MoveFiles(It.IsAny<List<MediaFileInfo>>()), Times.Once);
        }
    }
}
