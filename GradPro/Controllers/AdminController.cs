using Microsoft.AspNetCore.Mvc;

namespace GradPro.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(Guid? Id)
        {
            return View();
        }
    }
}
