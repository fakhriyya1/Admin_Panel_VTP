using AutoMapper;
using VTPAdmin.Models;
using VTPAdmin.ViewModels.Events;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.AutoMapper.Events
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventVM, Event>();
            CreateMap<UpdateEventVM, Event>();
            CreateMap<EventVM, UpdateEventVM>();
            CreateMap<EventVM, Event>().ReverseMap();
        }
    }
}
