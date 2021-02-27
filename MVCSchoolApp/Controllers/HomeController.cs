using System.Web.Mvc;


namespace MVCSchoolApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}