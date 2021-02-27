using MVCSchoolApp.DataAccess;
using MVCSchoolApp.Helpers;
using MVCSchoolApp.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.StudentRepository;
using static MVCSchoolApp.Helpers.Helper;

namespace MVCSchoolApp.Controllers
{
    public class StudentController : Controller
    {
        DbConnection dbConn = new DbConnection();

        public async Task<ActionResult> GetStudents()
        {
            var students = await dbConn.Read<Student>();

            return View(students);
        }

        public async Task<ActionResult> LoadForm(int? id)
        {
            var studentById = await dbConn.SearchById<Student>(id);

            if (studentById is null)
                return View(new Student { });
            else
                return View(studentById);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(Student formData)
        {
            if (formData.ID is 0)
            {
              await dbConn.Create(formData);
            }
            
            return RedirectToAction("GetStudents");
        }

        public async Task<ActionResult> Remove(int id)
        {
            await dbConn.Delete<Student>(id);
       
            return RedirectToAction("GetStudents");
        }

        public ActionResult GetResults(string searchParameter)
        {
            var results = Search(searchParameter);
            return View("GetStudents", results);
        }
    }
}