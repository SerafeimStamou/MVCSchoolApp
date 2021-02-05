using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCSchoolApp.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "First name must not be greater than 50 characters")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name must not be greater than 50 characters")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}