using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VTPAdmin.DAL;
using VTPAdmin.Extensions;
using VTPAdmin.Models;
using VTPAdmin.Repositories.Abstraction;
using VTPAdmin.ViewModels.Events;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Repositories.Concrete
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal user;

        public EventRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IEnumerable<EventVM>> GetAllNonDeletedEvents()
        {
            var events = await _dbContext.Events.Where(e => !e.IsDeleted).ToListAsync();
            var map = events.Select(e => _mapper.Map<EventVM>(e)).ToList();

            return map;
        }

        public async Task<EventVM?> GetNonDeletedEventById(int eventId)
        {
            var evnt = await _dbContext.Events.FirstOrDefaultAsync(m => m.Id == eventId && !m.IsDeleted);

            if (evnt == null)
                return null;

            var eventVM = _mapper.Map<EventVM>(evnt);

            return eventVM;
        }

        public async Task CreateEventAsync(CreateEventVM createEventVM)
        {
            var userEmail = user.GetLoggedInUserExtension();

            var map = _mapper.Map<Event>(createEventVM);

            map.CreatedBy = userEmail;

            await _dbContext.Events.AddAsync(map);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UpdateEventVM?> UpdateEventAsync(int eventId, UpdateEventVM updateEventVM)
        {
            var evnt = await _dbContext.Events.FindAsync(eventId);

            if (evnt == null)
                return null;

            var userEmail = user.GetLoggedInUserExtension();

            _mapper.Map(updateEventVM, evnt);

            evnt.ModifiedAt = DateTime.UtcNow;
            evnt.ModifiedBy = userEmail;

            _dbContext.Events.Update(evnt);
            await _dbContext.SaveChangesAsync();

            return updateEventVM;
        }

        public async Task<Event?> SafeDeleteAsync(int eventId)
        {
            var evnt = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventId && !x.IsDeleted);

            if (evnt == null) return null;

            evnt.IsDeleted = true;
            _dbContext.Events.Update(evnt);
            await _dbContext.SaveChangesAsync();

            return evnt;
        }
    }
}
