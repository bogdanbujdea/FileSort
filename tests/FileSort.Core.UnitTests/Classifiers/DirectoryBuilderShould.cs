using FluentAssertions;

using FileSort.Core.Classifiers;
using FileSort.Core.DirectoryTools;
using FileSort.Core.Classifiers.Date;

using System;

using Xunit;

namespace FileSort.Core.UnitTests.Classifiers
{
    public class DirectoryBuilderShould
    {
        private readonly MediaFileInfo _mediaFileInfo;

        public DirectoryBuilderShould()
        {
            _mediaFileInfo = new MediaFileInfo
            {
                CurrentPath = @"x:\test.jpg",
                ModifiedDate = new DateTime(1, 1, 1),
                FileName = "test.jpg"
            };
        }

        [Fact]
        public void build_new_path_with_year_name()
        {
            _mediaFileInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPathByDate(_mediaFileInfo, DateInterval.Year);
            newPath.Should().Be(@"x:\1\test.jpg");
        }

        [Fact]
        public void build_new_path_with_month_name()
        {
            _mediaFileInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPathByDate(_mediaFileInfo, DateInterval.Month);
            newPath.Should().Be(@"x:\January\test.jpg");
        }

        [Fact]
        public void build_new_path_with_day_name()
        {
            _mediaFileInfo.ModifiedDate = new DateTime(1, 1, 1);
            var newPath = DirectoryBuilder.BuildNewPathByDate(_mediaFileInfo, DateInterval.Day);
            newPath.Should().Be(@"x:\1-Monday\test.jpg");
        }

        [Fact]
        public void build_new_path_with_hour_name()
        {
            _mediaFileInfo.ModifiedDate = new DateTime(1, 1, 1, 15, 0, 0);
            var newPath = DirectoryBuilder.BuildNewPathByDate(_mediaFileInfo, DateInterval.Hour);
            newPath.Should().Be(@"x:\3 PM\test.jpg");
        }
    }
}
