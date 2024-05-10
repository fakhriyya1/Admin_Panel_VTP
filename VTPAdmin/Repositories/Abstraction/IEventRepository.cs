using VTPAdmin.Models;
using VTPAdmin.ViewModels.Events;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Repositories.Abstraction
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventVM>> GetAllNonDeletedEvents();
        Task<EventVM?> GetNonDeletedEventById(int eventId);
        Task CreateEventAsync(CreateEventVM createEventVM);
        Task<UpdateEventVM?> UpdateEventAsync(int eventId, UpdateEventVM updateEventVM);
        Task<Event?> SafeDeleteAsync(int eventId);
    }
}
