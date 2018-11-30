using FluentAssertions;

using PicSort.Core.Classifiers;

using System;
using System.Collections.Generic;

using Xunit;

namespace PicSort.Core.UnitTests.Classifiers
{
    public class DateClassifierClasifyShould
    {
        [Fact]
        public void receive_a_list_of_images()
        {
            Action action = () => new DateClassifier().Classify(new List<ImageInfo>());
            action.Should().NotThrow();
        }

        [Fact]
        public void set_new_path_for_each_image()
        {
            var dateClassifier = new DateClassifier();
            var images = new List<ImageInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1))
            };

            dateClassifier.Classify(images, DateInterval.Month);

            images[0].NewPath.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void create_directory_for_each_interval_when_it_is_required()
        {
            var dateClassifier = new DateClassifier();
            var images = new List<ImageInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1)),
            };

            dateClassifier.Classify(images, DateInterval.Hour, true);
            images[0].NewPath.Should().Be(@"d:\1\January\1-Monday\12 AM\test.jpg");
        }

        [Fact]
        public void create_directory_only_until_specified_interval_when_required()
        {
            var dateClassifier = new DateClassifier();
            var images = new List<ImageInfo>
            {
                BuildImageInfo("test.jpg", new DateTime(1, 1, 1)),
            };

            dateClassifier.Classify(images, DateInterval.Month, true);
            images[0].NewPath.Should().Be(@"d:\1\January\test.jpg");
        }

        private ImageInfo BuildImageInfo(string fileName, DateTime modifiedDate)
        {
            return new ImageInfo
            {
                CurrentPath = $@"d:\{fileName}",
                FileName = fileName,
                ModifiedDate = modifiedDate
            };
        }
    }
}
