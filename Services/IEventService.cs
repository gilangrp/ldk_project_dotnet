using LDKProject.Models;

namespace LDKProject.Services
{
    public interface IEventService
    {
        Task<IList<Event>> GetAllEvent();
        Task<Event> SaveEvent(Event Event);
    }
}
