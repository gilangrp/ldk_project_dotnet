using System.Net;
using AutoMapper;
using LDKProject.Constants;
using LDKProject.Exceptions;
using LDKProject.Models.DTO;
using LDKProject.Models;
using LDKProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LDKProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(ILogger<WeatherForecastController> logger, IEventService eventService, IMapper mapper)
        {
            _logger = logger;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllEvents")]
        [Authorize]
        public async Task<IActionResult> GetAllEvent()
        {
            try
            {
                var events = await _eventService.GetAllEvent();
                return Ok(Utils.Utils.NewSuccessResponse(events, null, null));
            }
            catch (NotFoundException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.NotFoundErr, (int)HttpStatusCode.NotFound));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpPost]
        [Route("CreateEvent")]
        [Authorize]

        public async Task<IActionResult> SaveEvent([FromBody] CreateEventRequest request)
        {
            try
            {
                Event payload = _mapper.Map<Event>(request);
                if (payload == null)
                {
                    return BadRequest();
                }
                var result = await _eventService.SaveEvent(payload);
                return Ok(Utils.Utils.NewSuccessResponse(result, null, null));


            }
            catch (ConflictException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.Conflict, (int)HttpStatusCode.Conflict));
            }
            catch (BadRequestException e)
            {
                return BadRequest(Utils.Utils.NewErrorResponse(null, e.Message, Status.BadRequestErr, (int)HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                var isDuplicate = Utils.Errors.IsDuplicateError(ex);
                if (isDuplicate)
                {
                    return Conflict(Utils.Utils.NewErrorResponse(null, null, Status.Conflict, (int)HttpStatusCode.Conflict));
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }
    }
}
