using MVCSchoolApp.Models;
using System.Collections.Generic;
using System.Linq;
using static MVCSchoolApp.DataAccess.DataAccess;

namespace MVCSchoolApp.DataAccess
{
    public class StudentRepository
    {
        public static List<Student> Search(string searchParameter)
        {
            return context.Students.Where(s => s.FirstName.Contains(searchParameter) ||
                                          s.LastName.Contains(searchParameter) ||
                                          s.Email.Contains(searchParameter) ||
                                          s.Phone.Contains(searchParameter)).ToList();
        }

        public static Student SearchById(int? Id)
        {
            return context.Students.Find(Id);
        }
    }
}