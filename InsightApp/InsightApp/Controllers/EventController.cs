using InsightApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Controllers
{
    public class EventController : Controller
    {
        private SVGSDbContext _SVGSDbContext;
        public EventController( SVGSDbContext sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        [HttpGet("/events")]
        public IActionResult GetAllEvents()
        {
            var allEvents = _SVGSDbContext.GameEvents
                .Include(e => e.EvType)
                .Include(e => e.Address)
                .OrderBy(e => e.EventName).ToList();
            return View("Items", allEvents);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
