using FluentAssertions;

using PicSort.Core.Classifiers.Date;

using System;
using System.Collections.Generic;

using Xunit;

namespace PicSort.Core.UnitTests.Classifiers
{
    public class DateExtensionsShould
    {
        [Fact]
        public void return_month_name_when_interval_is_set_to_month()
        {
            var months = new List<string>
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };
            for (var index = 0; index < months.Count; index++)
            {
                var month = months[index];
                var date = new DateTime(1, index + 1, 1);
                date.GetName(DateInterval.Month).Should().Be(month);
            }
        }

        [Fact]
        public void return_day_name_when_interval_is_set_to_day()
        {
            var days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            for (int i = 0; i < days.Count; i++)
            {
                new DateTime(1, 1, i + 1).GetName(DateInterval.Day).Should().Be($"{i + 1}-{days[i]}");
            }
        }

        [Fact]
        public void return_year_when_interval_is_set_to_day()
        {
            new DateTime(2018, 1, 1).GetName(DateInterval.Year).Should().Be("2018");
        }

        [Fact]
        public void return_hour_when_interval_is_set_to_hour()
        {
            new DateTime(2018, 10, 10, 13, 6, 9).GetName(DateInterval.Hour).Should().Be("1 PM");
            new DateTime(2018, 10, 10, 11, 6, 9).GetName(DateInterval.Hour).Should().Be("11 AM");
        }
    }
}
