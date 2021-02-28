using System.Web.Mvc;


namespace MVCSchoolApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult GetSqlError(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult InsertSqlError(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult RemoveSqlError(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult SearchSqlError(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}