using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Error Page
        public IActionResult Error()
        {
            return View();
        }
    }
}
