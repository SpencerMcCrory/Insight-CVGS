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
            //will return only the events that (isDeleted=false)
            var allEvents = _SVGSDbContext.GameEvents
                .Include(e => e.EvType)
                .Include(e => e.Address)
                .Where(e => e.IsDeleted == false)
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

        [HttpGet("/events/{id}")]
        public IActionResult GetEventById(int id)
        {
            var gameEvent = _SVGSDbContext.GameEvents
                .Include(e => e.EvType)
                .Include(e => e.Address)
                .Include(e => e.MemberEventRegists).ThenInclude(m => m.Member)
                .Where(e => e.EventId == id).FirstOrDefault();

            EventDetailViewModel eventDetailViewModel = new EventDetailViewModel()
            {
                ActiveEvent = gameEvent,
                Registrations = gameEvent.MemberEventRegists.Count()
            };

            return View("Details", eventDetailViewModel);
        }

        [HttpGet("/events/{id}/edit-request")]
        public IActionResult GetEditRequestById(int id)
        {
            var gameEvent = _SVGSDbContext.GameEvents
                .Include(e => e.EvType)
                .Include(e => e.Address)
                .Where(e => e.EventId == id).FirstOrDefault();

            EventViewModel eventViewModel = new EventViewModel()
            {
                EventTypes = _SVGSDbContext.EventTypes.OrderBy(t => t.EvTypeId).ToList(),
                ActiveEvent = gameEvent
            };

            return View("EditEvent", eventViewModel);
        }

        [HttpPost("/events/edit-requests")]
        public IActionResult ProcessEditRequest(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var eventType = _SVGSDbContext.EventTypes
                .Where(e => e.EvTypeId == eventViewModel.ActiveEvent.EvTypeId).FirstOrDefault();
                
                //the event is virtual and there is a value for Address id,
                //will remove the address record from Address table then change the addressId to null in the Gameevent table
                
                if (eventType.EvTypeName.ToLower()=="virtual" && eventViewModel.ActiveEvent.AddressId !=null)
                {
                    // Find the address record to delete:
                    //var address = _SVGSDbContext.AddressTables.Find(eventViewModel.ActiveEvent.AddressId);

                    //_SVGSDbContext.AddressTables.Remove(address);
                    //_SVGSDbContext.SaveChanges();

                    eventViewModel.ActiveEvent.AddressId = null;
                }
                
                // it's valid so we want to update the existing movie in the DB:
                _SVGSDbContext.GameEvents.Update(eventViewModel.ActiveEvent);
                _SVGSDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The event \"{eventViewModel.ActiveEvent.EventName}\" was updated.";

                return RedirectToAction("GetAllEvents", "Event");
            }
            else
            {
                eventViewModel.EventTypes = _SVGSDbContext.EventTypes.OrderBy(t => t.EvTypeId).ToList();
                return View("EditEvent", eventViewModel);
            }
        }

        
        [HttpGet("/events/{id}/delete-requests")]
        public IActionResult ProcessDeleteRequest(int id)
        {
            //actually we are not deleting the event record, we only update "isDeleted" to true without saving any changes that happened in the form
            //here we get the original event by id
            var gameEvent = _SVGSDbContext.GameEvents
            .Include(e => e.EvType)
            .Include(e => e.Address)
            .Where(e => e.EventId == id).FirstOrDefault();

            // do soft deletion
            gameEvent.IsDeleted = true;

            // save the changes to DB:
            _SVGSDbContext.GameEvents.Update(gameEvent);
            _SVGSDbContext.SaveChanges();

            return RedirectToAction("GetAllEvents", "Event");
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
