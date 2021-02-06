using MVCSchoolApp.Models;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.DataAccess;
using static MVCSchoolApp.Helpers.Helper;

namespace MVCSchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        Teacher teacher = new Teacher();

        public ActionResult GetTeachers()
        {
            var teachers = Read(teacher);
            return View(teachers);
        }

        public ActionResult LoadForm(int? id)
        {
            var teacherById = context.Teachers.Find(id);

            if (teacherById is null)
                return View(teacher);
            else
                return View(teacherById);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Teacher formData)
        {
            if (formData.ID is 0)
            {
                Create(formData);
            }
            else
            {
                var teacherFromDb = context.Teachers.Find(formData.ID);

                UpdateModel(teacherFromDb, "", LoadTeacherProperties());
            }

            context.SaveChanges();

            return RedirectToAction("GetTeachers");
        }

        public ActionResult Remove(int id)
        {
            Delete<Teacher>(id);
            context.SaveChanges();

            return RedirectToAction("GetTeachers");
        }
    }
}