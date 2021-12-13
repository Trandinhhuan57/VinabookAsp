using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}