using LDKProject.Models;

namespace LDKProject.Repositories
{
    public interface IEventRepository
    {
        Task<IList<Event>> GetAllEvent();
        Task<Event> SaveEvent(Event Event);
    }
}
