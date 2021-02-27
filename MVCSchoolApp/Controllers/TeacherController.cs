using MVCSchoolApp.DataAccess;
using MVCSchoolApp.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using static MVCSchoolApp.Helpers.Helper;

namespace MVCSchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        DbConnection dbConn = new DbConnection();

        public async Task<ActionResult> GetTeachers()
        {
            var teachers = await dbConn.Read<Teacher>();
            return View(teachers);
        }

        public async Task<ActionResult> LoadForm(int? id)
        {
            var teacherById = await dbConn.SearchById<Teacher>(id);

            if (teacherById is null)
                return View(new Teacher{ });
            else
                return View(teacherById);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(Teacher formData)
        {
            if (formData.ID is 0)
            {
                await dbConn.Create(formData);
            }
  
            return RedirectToAction("GetTeachers");
        }

        public async Task<ActionResult> Remove(int id)
        {
            await dbConn.Delete<Teacher>(id);
            
            return RedirectToAction("GetTeachers");
        }
    }
}