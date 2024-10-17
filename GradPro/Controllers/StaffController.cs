using Microsoft.AspNetCore.Mvc;

namespace GradPro.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index(Guid? Id)
        {
            return View();
        }
    }
}
