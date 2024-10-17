using Microsoft.AspNetCore.Mvc;

namespace GradPro.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Index(Guid? Id)
        {
            return View();
        }
    }
}
