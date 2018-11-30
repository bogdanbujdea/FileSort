using FluentAssertions;

using PicSort.Core.Classifiers;

using System;

using Xunit;

namespace PicSort.Core.UnitTests.Classifiers
{
    public class DirectoryBuilderShould
    {
        private readonly ImageInfo _imageInfo;

        public DirectoryBuilderShould()
        {
            _imageInfo = new ImageInfo
            {
                CurrentPath = @"d:\test.jpg",
                ModifiedDate = new DateTime(1, 1, 1),
                FileName = "test.jpg"
            };
        }

        [Fact]
        public void build_new_path_with_year_name()
        {
            _imageInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPath(_imageInfo, DateInterval.Year);
            newPath.Should().Be(@"d:\1\test.jpg");
        }

        [Fact]
        public void build_new_path_with_month_name()
        {
            _imageInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPath(_imageInfo, DateInterval.Month);
            newPath.Should().Be(@"d:\January\test.jpg");
        }

        [Fact]
        public void build_new_path_with_day_name()
        {
            _imageInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPath(_imageInfo, DateInterval.Day);
            newPath.Should().Be(@"d:\Monday\test.jpg");
        }

        [Fact]
        public void build_new_path_with_hour_name()
        {
            _imageInfo.ModifiedDate = new DateTime(1, 1, 1, 15, 0, 0);
            var newPath = DirectoryBuilder.BuildNewPath(_imageInfo, DateInterval.Hour);
            newPath.Should().Be(@"d:\3 PM\test.jpg");
        }
    }
}
