using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omar.Utilities.Dates
{
    public static class DatesRangeHelper
    {
        /// <summary>
        /// Returns a list of dates from the given range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> DatesFromRange(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }

        /// <summary>
        /// Returns a single date from the given range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DateTime DateFromRange(this DateTime startDate, DateTime endDate)
        {
            var random = new Random();

            var dates = Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d)).ToList();
            return dates[random.Next(dates.Count())];
        }
    }
}
