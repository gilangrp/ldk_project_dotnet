using LDKProject.Data;
using LDKProject.Exceptions;
using LDKProject.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace LDKProject.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly IConfiguration configuration;
        private readonly AppDBContext _appDbContext;
        private readonly IConnectionMultiplexer _redis;

        public EventRepository(IConfiguration configuration, AppDBContext appDbContext, IConnectionMultiplexer redis)
        {
            this.configuration = configuration;
            _appDbContext = appDbContext;
            _redis = redis;
        }

        //public async Task<IList<Event>> GetAllEvent()
        //{
        //    var items = await _appDbContext.Event.ToListAsync();
        //    if (items == null || items.Count == 0)
        //    {
        //        throw new NotFoundException("Event tidak ditemukan");
        //    }

        //    return items;
        //}

        public async Task<IList<Event>> GetAllEvent()
        {
            var db = _redis.GetDatabase();
            string cacheKey = "all_events";
            string cachedEvents = await db.StringGetAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedEvents))
            {
                return JsonConvert.DeserializeObject<IList<Event>>(cachedEvents);
            }

            var items = await _appDbContext.Event.ToListAsync();
            if (items == null || items.Count == 0)
            {
                throw new NotFoundException("Event tidak ditemukan");
            }

            await db.StringSetAsync(cacheKey, JsonConvert.SerializeObject(items), TimeSpan.FromMinutes(10));
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
