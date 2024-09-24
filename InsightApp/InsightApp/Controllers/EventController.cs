using Microsoft.AspNetCore.Mvc;

namespace InsightApp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
