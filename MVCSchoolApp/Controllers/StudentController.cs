using MVCSchoolApp.DataAccess;
using MVCSchoolApp.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using static MVCSchoolApp.DataAccess.StudentRepository;

namespace MVCSchoolApp.Controllers
{
    public class StudentController : Controller
    {
        DbConnection dbConn = new DbConnection();

        public async Task<ActionResult> GetStudents()
        {
            try
            {
              var students = await dbConn.Read<Student>();
              return View(students);
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetSqlError", "Error",new { message =ex.Message});
            }  
        }

        public async Task<ActionResult> LoadForm(int? id)
        {
            try
            {
                var studentById = await dbConn.SearchById<Student>(id);

                if (studentById is null)
                    return View(new Student { });
                else
                    return View(studentById);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SearchSqlError", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(Student formData)
        {
            try
            {
                if (formData.ID == 0)
                    await dbConn.Create(formData);
                else
                    await dbConn.Update(formData, formData.ID);

                return RedirectToAction("GetStudents");
            }
            catch (Exception ex)
            {
                return RedirectToAction("InsertSqlError", "Error",new { message = ex.Message});
            }            
        }

        public async Task<ActionResult> Remove(int id)
        {
             try
             {
                await dbConn.Delete<Student>(id);
                return RedirectToAction("GetStudents");
             }
             catch(Exception ex)
             {
                return RedirectToAction("RemoveSqlError", "Error", new { message = ex.Message });
             }       
        }

        public ActionResult GetResults(string searchParameter)
        {
            var results = Search(searchParameter);
            return View("GetStudents", results);
        }
    }
}