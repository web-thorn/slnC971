using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace WGU.Models
{
    public enum CourseStatus
    {
        Completed,
        Dropped,
        InProgress,
        Upcoming
    }

    [Table("terms")]
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Ignore]
        public string TermDate => $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
    }

    [Table("courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int TermId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public string Notes { get; set; }
    }

    [Table("assessments")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int CourseId { get; set; }
        public bool Performance { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
    }

}