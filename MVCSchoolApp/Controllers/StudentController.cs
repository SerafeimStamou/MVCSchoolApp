using MVCSchoolApp.Models;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.DataAccess;
using static MVCSchoolApp.DataAccess.StudentRepository;
using static MVCSchoolApp.Helpers.Helper;


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

        public ActionResult LoadForm(int? id)
        {
            var studentById = SearchById(id);

            if (studentById is null)
                return View(student);
            else
                return View(studentById);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Student formData)
        {
            if (formData.ID is 0)
            {
                Create(formData);
            }
            else
            {
                var studentFromDb = SearchById(formData.ID);

                UpdateModel(studentFromDb, "",LoadStudentProperties());
            }

            context.SaveChanges();

            return RedirectToAction("GetStudents");
        }

        public ActionResult Remove(int id)
        {
            Delete<Student>(id);
            context.SaveChanges();

            return RedirectToAction("GetStudents");
        }

        public ActionResult GetResults(string searchParameter)
        {
            var results = Search(searchParameter);
            return View("GetStudents", results);
        }
    }
}