namespace web.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int EventID { get; set; }
        public int StudentID { get; set; }

        public Event? Event { get; set; }
        public Student? Student { get; set; }
    }
}