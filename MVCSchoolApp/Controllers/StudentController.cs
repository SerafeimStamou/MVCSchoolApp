using MVCSchoolApp.Models;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.DataAccess;


namespace MVCSchoolApp.Controllers
{
    public class StudentController : Controller
    {
        Student student = new Student();
        public ActionResult GetStudents()
        {
            var students = Read(student);
            return View(students);
        }
    }
}