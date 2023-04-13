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
        private readonly ILogger<ProjectController> _logger;

        public TrackerController(ITrackerService service, ILogger<ProjectController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("date-tracker")]
        public async Task<IActionResult> GetActivitiesByPersonAndDate([FromQuery]TrackerPersonAndDateDto trackerDto) 
        {
            var result = _service.GetActivitiesByPersonAndDate(trackerDto);

            _logger.LogInformation("Activities by person Id and Date got successfully");

            return Ok(result);
        }

        [HttpGet]
        [Route("day-tracker")]
        public async Task<IActionResult> GetActivitiesByPersonAndWeekNumber([FromQuery]TrackerPersonAndWeekNumber trackerDto)
        {
            var result = _service.GetActivitiesByPersonAndWeekNumberAsync(trackerDto);

            _logger.LogInformation("Activities by person Id and Number of week");

            return Ok(result);
        }
    }
}
