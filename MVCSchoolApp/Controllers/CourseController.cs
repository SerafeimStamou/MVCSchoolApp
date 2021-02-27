using MVCSchoolApp.DataAccess;
using MVCSchoolApp.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCSchoolApp.Controllers
{
    public class CourseController : Controller
    {
        DbConnection dbConn = new DbConnection();

        public async Task<ActionResult> GetCourses()
        {
            var courses = await dbConn.Read<Course>();
            return View(courses);
        }
    }
}