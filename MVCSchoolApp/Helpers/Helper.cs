

namespace MVCSchoolApp.Helpers
{
    public static class Helper
    {
        public static string[] LoadStudentProperties()
        {
            string[] studentProperties;

            return studentProperties = new string[] { "FirstName", "LastName", "DateOfBirth", "Email", "Phone" };
        }
    }
}