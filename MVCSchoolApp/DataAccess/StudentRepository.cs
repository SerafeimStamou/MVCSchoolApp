using MVCSchoolApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVCSchoolApp.DataAccess
{
    public class StudentRepository
    {
        public static List<Student> Search(string searchParameter)
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            return context.Students.Where(s => s.FirstName.Contains(searchParameter) ||
                                          s.LastName.Contains(searchParameter) ||
                                          s.Email.Contains(searchParameter) ||
                                          s.Phone.Contains(searchParameter)).ToList();
        }
    }
}