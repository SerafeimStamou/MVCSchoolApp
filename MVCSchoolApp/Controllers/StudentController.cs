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

        public ActionResult LoadForm()
        {
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Student formData)
        {
            if(formData.ID is 0)
            Create(formData);
           
            return RedirectToAction("GetStudents");
        }
    }
}