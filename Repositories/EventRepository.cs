using LDKProject.Data;
using LDKProject.Exceptions;
using LDKProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LDKProject.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly IConfiguration configuration;
        private readonly AppDBContext _appDbContext;

        public EventRepository(IConfiguration configuration, AppDBContext appDbContext)
        {
            this.configuration = configuration;
            _appDbContext = appDbContext;
        }

        public async Task<IList<Event>> GetAllEvent()
        {
            var items = await _appDbContext.Event.ToListAsync();
            if (items == null || items.Count == 0)
            {
                throw new NotFoundException("Event tidak ditemukan");
            }

            return items;
        }

        public async Task<Event> SaveEvent(Event Event)
        {
            _appDbContext.Event.Add(Event);
            await _appDbContext.SaveChangesAsync();

            return Event;
        }
    }
}
