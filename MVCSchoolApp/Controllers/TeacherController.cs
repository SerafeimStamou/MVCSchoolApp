using MVCSchoolApp.DataAccess;
using MVCSchoolApp.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCSchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        DbConnection dbConn = new DbConnection();

        public async Task<ActionResult> GetTeachers()
        {
            try
            {
                var teachers = await dbConn.Read<Teacher>();
                return View(teachers);
            }
            catch(Exception ex)
            {
                return RedirectToAction("GetSqlError", "Error", new { message = ex.Message });
            }
        }

        public async Task<ActionResult> LoadForm(int? id)
        {
            try
            {
                var teacherById = await dbConn.SearchById<Teacher>(id);

                if (teacherById is null)
                    return View(new Teacher { });
                else
                    return View(teacherById);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SearchSqlError", "Error", new { message = ex.Message });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(Teacher formData)
        {
            try
            {
                if (formData.ID == 0)
                    await dbConn.Create(formData);
                else
                    await dbConn.Update(formData, formData.ID);

                return RedirectToAction("GetTeachers");
            }
            catch (Exception ex)
            {
                return RedirectToAction("InsertSqlError", "Error", new { message = ex.Message });
            }
        }

        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await dbConn.Delete<Teacher>(id);
                return RedirectToAction("GetTeachers");
            }
            catch (Exception ex)
            {
                return RedirectToAction("RemoveSqlError", "Error", new { message = ex.Message });
            }
        }
    }
}