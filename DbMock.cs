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

        public static List<Course> Classes = new List<Course> {
            new Course{SemesterId = 1, Id = 0, CourseName = "Software Engingeering 1", CourseCode = "CEN 4020", Enrollment = 120, Instructor = "Sonya P"},
            new Course{SemesterId = 2, Id = 1, CourseName = "C# Programming", CourseCode = "CIS 4930", Instructor = "Chris Mills", Enrollment = 43},
            new Course{SemesterId =3, Id = 2, CourseName = "Intro to Programming", CourseCode = "COP 3330", Instructor = "Chris Mills", Enrollment = 250},
            new Course{SemesterId = 2, Id = 3, CourseName = "Op Sys", CourseCode = "COP 4610", Instructor = "An-i Wang", Enrollment = 200}
        };
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