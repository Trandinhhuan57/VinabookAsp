using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SaleOffController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}