using MVCSchoolApp.Models;
using System.Data.Entity;



namespace MVCSchoolApp.DataAccess
{
    public class MVCSchoolAppContext:DbContext
    {
        public MVCSchoolAppContext() : base("MVCSchoolAppDB") { }

        public DbSet<Student> Students { get; set; }
    }
}