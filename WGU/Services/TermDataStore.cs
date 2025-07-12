using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGU.Models;

namespace WGU.Services
{
    public class TermDataStore : ITermDataStore<Term>
    {

        public void InitializeDataStore()
        {
            try
            {
                using var db = DBIO.ConnectToSQL();
                // Debug only
                //_ = db.DropTable<Term>();
                //_ = db.DropTable<Course>();
                //_ = db.DropTable<Assessment>();

                // Create the tables if they don't already exist
                var createdTermTable = db.CreateTable<Term>();
                var createdCourseTable = db.CreateTable<Course>();
                var createdAssessmentTable = db.CreateTable<Assessment>();

                // Populate the tables with data for the task if they are empty
                if (createdTermTable == CreateTableResult.Created)
                {
                    Term term1 = new()
                    {
                        Name = "Term 1",
                        StartDate = new DateTime(2022, 1, 1),
                        EndDate = new DateTime(2022, 6, 30)
                    };
                    _ = db.Insert(term1);
                }

                if (createdCourseTable == CreateTableResult.Created)
                {
                    Course course1 = new()
                    {
                        Name = "C971",
                        // Since we are adding new data to an empty table, the term we created above will have the ID of 1.
                        // This field will normally be the value of the selected term in the application
                        TermId = 1,
                        StartDate = new DateTime(2022, 1, 1),
                        EndDate = new DateTime(2022, 2, 28),
                        Status = CourseStatus.InProgress.ToString(),
                        InstructorName = "Brian Hall",
                        InstructorEmail = "bhal212@wgu.edu",
                        InstructorPhone = "540.555.1212"
                    };
                    _ = db.Insert(course1);
                }

                if (createdAssessmentTable == CreateTableResult.Created)
                {
                    Assessment perf = new()
                    {
                        // Again, since this is sample data, the course ID for the two assessments will be 1.
                        CourseId = 1,
                        Performance = true,
                        Name = "C971 PA",
                        DueDate = new DateTime(2022, 2, 15)
                    };
                    Assessment obj = new()
                    {
                        CourseId = 1,
                        Performance = false,
                        Name = "C971 OA",
                        DueDate = new DateTime(2022, 2, 27)
                    };
                    _ = db.Insert(perf);
                    _ = db.Insert(obj);
                }

                // Verify the data exists
                //var terms = db.Query<Term>("select * from terms");
                //foreach (var term in terms)
                //{
                //    Debug.WriteLine($"{term.Id} - {term.Name}");
                //}

                //var courses = db.Query<Course>("select * from courses");
                //foreach (var course in courses)
                //{
                //    Debug.WriteLine($"{course.Id} - {course.Name} - {course.InstructorName}");
                //}

                //var assessments = db.Query<Assessment>("select * from assessments");
                //foreach (var obj in assessments)
                //{
                //    Debug.WriteLine($"{obj.Id} - {obj.Name} - {obj.CourseId}");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public Task<bool> AddItemAsync(Term item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Term> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Term>> GetItemsAsync(bool forceRefresh = false)
        {
            using var db = DBIO.ConnectToSQL();
            return await Task.FromResult(db.Query<Term>("select * from terms").AsEnumerable());
        }

        public Task<bool> UpdateItemAsync(Term item)
        {
            throw new NotImplementedException();
        }
    }
}
