using InsightApp.Entities;
using InsightApp.Models;
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

        [HttpGet("/events/add-request")]
        public IActionResult GetAddEventRequest()
        {
            EventViewModel eventViewModel = new EventViewModel()
            {
                EventTypes = _SVGSDbContext.EventTypes.OrderBy(t => t.EvTypeId).ToList(),
                ActiveEvent = new GameEvent()
            };

            return View("AddEvent", eventViewModel);
        }

        [HttpPost("/events")]
        public IActionResult AddNewEvent(EventViewModel eventViewModel)
        {            
            if (ModelState.IsValid)
            {
                
                // it's valid so we want to add the new event to the DB:
                _SVGSDbContext.GameEvents.Add(eventViewModel.ActiveEvent);
                _SVGSDbContext.SaveChanges();
                TempData["LastActionMessage"] = $"The event \"{eventViewModel.ActiveEvent.EventName}\" is successfully add.";
                return RedirectToAction("GetAllEvents", "Event");
            }
            else
            {
                // it's invalid so we simply return the event object
                // to the Edit view again:
                eventViewModel.EventTypes = _SVGSDbContext.EventTypes.OrderBy(t => t.EvTypeName).ToList();
                return View("AddEvent", eventViewModel);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
