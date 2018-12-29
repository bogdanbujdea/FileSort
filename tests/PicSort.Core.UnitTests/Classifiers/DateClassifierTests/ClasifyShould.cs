using FluentAssertions;

using PicSort.Core.Classifiers;
using PicSort.Core.Classifiers.Date;

using System;

using System.Collections.Generic;

using Xunit;

namespace PicSort.Core.UnitTests.Classifiers.DateClassifierTests
{
    public class ClasifyShould
    {
        DateClassifier _dateClassifier;

        public ClasifyShould()
        {
            _dateClassifier = new DateClassifier();
        }

        [Fact]
        public void receive_a_list_of_images()
        {
            Action action = () => _dateClassifier.Classify(new List<MediaFileInfo>(), new DateClassifierArgs());
            action.Should().NotThrow();
        }

        [Fact]
        public void throw_when_list_is_null()
        {
            Action action = () => _dateClassifier.Classify(null, new DateClassifierArgs());
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void throw_when_args_are_not_set()
        {
            Action action = () => _dateClassifier.Classify(new List<MediaFileInfo>(), null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void set_new_path_for_each_image()
        {
            var dateClassifier = _dateClassifier;
            var images = new List<MediaFileInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1))
            };

            dateClassifier.Classify(images, new DateClassifierArgs(DateInterval.Month));

            images[0].NewPath.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void create_directory_for_each_interval_when_it_is_required()
        {
            var dateClassifier = _dateClassifier;
            var images = new List<MediaFileInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1)),
            };

            dateClassifier.Classify(images, new DateClassifierArgs(DateInterval.Hour, true));
            images[0].NewPath.Should().Be(@"d:\1\January\1-Monday\12 AM\test.jpg");
        }

        [Fact]
        public void create_directory_only_until_specified_interval_when_required()
        {
            var dateClassifier = _dateClassifier;
            var images = new List<MediaFileInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1)),
            };

            dateClassifier.Classify(images, new DateClassifierArgs(DateInterval.Month, true));
            images[0].NewPath.Should().Be(@"d:\1\January\test.jpg");
        }

        private MediaFileInfo BuildImageInfo(string fileName, DateTime modifiedDate)
        {
            return new MediaFileInfo
            {
                CurrentPath = $@"d:\{fileName}",
                FileName = fileName,
                ModifiedDate = modifiedDate
            };
        }
    }
}
