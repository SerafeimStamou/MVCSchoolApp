using MVCSchoolApp.Models;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.DataAccess;

namespace MVCSchoolApp.Controllers
{
    public class CourseController : Controller
    {
        Course course = new Course();
        public ActionResult GetCourses()
        {
            var courses = Read(course);
            return View(courses);
        }
    }
}