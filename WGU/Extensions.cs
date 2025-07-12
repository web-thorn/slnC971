using System;
using WGU.Models;

namespace WGU
{
    public static class Extensions
    {
        public static string ToString(this CourseStatus status)
        {
            return status switch
            {
                CourseStatus.InProgress => "In Progress",
                _ => status.ToString()
            };
        }
        public static string ToTermDates(this DateTime StartDate, DateTime EndDate)
        {
            return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
        }
    }
}
