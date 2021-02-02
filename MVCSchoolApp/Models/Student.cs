using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSchoolApp.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="First name must not be greater than 50 characters")]
        [MinLength(2,ErrorMessage ="First name must be at least 2 characters long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name must not be greater than 50 characters")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}