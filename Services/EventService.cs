using AutoMapper;
using LDKProject.Models;
using LDKProject.Repositories;

namespace LDKProject.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper mapper;
        private readonly ILogger<WeatherForecast> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventService(IMapper mapper, ILogger<WeatherForecast> logger, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            _logger = logger;
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<Event>> GetAllEvent()
        {
            return await _eventRepository.GetAllEvent();
        }

        public async Task<Event> SaveEvent(Event Event)
        {
            var payload = new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = Event.Title,
                Description = Event.Description,
                Location = Event.Location,
                EventDate = Event.EventDate,
                Speaker = Event.Speaker,
                CreatedAt = DateTime.Now,
            };
            return await _eventRepository.SaveEvent(payload);
        }
    }
}
