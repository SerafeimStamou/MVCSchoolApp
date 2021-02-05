

namespace MVCSchoolApp.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}