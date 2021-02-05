using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCSchoolApp.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; }
        public byte HoursPerWeek { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Teacher Teacher { get; set; }
    }
}