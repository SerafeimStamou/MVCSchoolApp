

namespace MVCSchoolApp.Helpers
{
    public static class Helper
    {
        public static string[] LoadStudentProperties()
        {
          return  new string[] { "FirstName", "LastName", "DateOfBirth", "Email", "Phone" };
        }

        public static string[] LoadTeacherProperties()
        { 
          return  new string[] { "FirstName", "LastName", "Email", "Phone" };
        }
    }
}