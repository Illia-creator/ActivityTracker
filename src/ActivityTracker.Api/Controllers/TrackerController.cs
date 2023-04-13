using ActivityTracker.Application.Dto.TimeTrackingDto;
using ActivityTracker.Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTracker.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrackerController : ControllerBase
    {
        private readonly ITrackerService _service;

        public TrackerController(ITrackerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("date-tracker")]
        public async Task<IActionResult> GetActivitiesByPersonAndDate([FromQuery]TrackerPersonAndDateDto trackerDto) 
        {
            var result = _service.GetActivitiesByPersonAndDate(trackerDto);           

            return Ok(result);
        }

        [HttpGet]
        [Route("day-tracker")]
        public async Task<IActionResult> GetActivitiesByPersonAndWeekNumber([FromQuery]TrackerPersonAndWeekNumber trackerDto)
        {
            var result = _service.GetActivitiesByPersonAndWeekNumberAsync(trackerDto);

            return Ok(result);
        }
    }
}
