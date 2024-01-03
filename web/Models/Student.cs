using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Points { get; set; }
        public int DormitoryID { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}