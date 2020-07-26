using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSPA.Persistence
{
    public static class DbMock
    {
        public static List<Semester> Semesters = new List<Semester> { 
            new Semester{Id = 1, Name = "Fall2019"},
            new Semester{Id = 2, Name = "Spring2020"},
            new Semester{Id = 3, Name = "Summer2020"}
        };

        public static Course[] Classes = new Course[500];

    }

    public partial class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Course
    {
        public int SemesterId { get; set; }

        public int Id { get; set; }

        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public string Instructor { get; set; }

        public int Enrollment { get; set; }


    }
}