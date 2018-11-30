using System;

namespace PicSort.Core.Classifiers
{
    public static class DateExtensions
    {
        public static string GetMonthName(this DateTime date)
        {
            return new DateTime(1, date.Month, 1).ToString("M").Split(' ')[0];
        }

        public static string GetDayName(this DateTime date)
        {
            return new DateTime(1, 1, date.Day).ToString("D").Split(' ')[0];
        }

        public static string GetName(this DateTime date, DateInterval interval)
        {
            switch (interval)
            {
                case DateInterval.Month:
                    return new DateTime(1, date.Month, 1).ToString("M").Split(' ')[0];
                case DateInterval.Day:
                    return new DateTime(1, 1, date.Day).ToString("D").Split(',')[0];
                case DateInterval.Year:
                    return date.Year.ToString();
                case DateInterval.Hour:
                    return $"{date:h tt}";
            }
            return string.Empty;
        }
    }
}
