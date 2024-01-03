namespace web.Models
{
    public class Dormitory
    {
        public int DormitoryID { get; set; }
        public string? DormitoryTitle { get; set; }
        public string? JanitorPhoneNumber { get; set; }
        public ICollection<Enrollment>? Students { get; set; }
    }
}