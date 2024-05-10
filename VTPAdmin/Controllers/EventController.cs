using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VTPAdmin.Models;
using VTPAdmin.Repositories.Abstraction;
using VTPAdmin.Repositories.Concrete;
using VTPAdmin.ViewModels.Events;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllNonDeletedEvents();

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CreateEventVM createEventVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createEventVM);
            }

            await _eventRepository.CreateEventAsync(createEventVM);

            return RedirectToAction(nameof(Index), "Event");
        }

        [HttpGet("/Event/Update/{eventId}")]
        public async Task<IActionResult> Update(int eventId)
        {
            var evnt = await _eventRepository.GetNonDeletedEventById(eventId);

            if (evnt == null)
                return NotFound();

            var updateEventVM = _mapper.Map<UpdateEventVM>(evnt);

            return View(updateEventVM);
        }

        [HttpPost("/Event/Update/{eventId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int eventId, UpdateEventVM updateEventVM)
        {
            if (!ModelState.IsValid)
            {
                return View(updateEventVM);
            }

            var evnt = await _eventRepository.UpdateEventAsync(eventId, updateEventVM);

            if (evnt == null)
                return NotFound();

            return RedirectToAction(nameof(Index), "Event");
        }

        [Authorize("admin")]

        [HttpGet("/Event/Delete/{eventId}")]
        public async Task<IActionResult> SafeDelete(int eventId)
        {
            var evnt = await _eventRepository.SafeDeleteAsync(eventId);

            if (evnt == null)
                return NotFound();

            return RedirectToAction(nameof(Index), "Event");
        }
    }
}
