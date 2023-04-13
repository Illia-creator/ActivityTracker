using ActivityTracker.Application.Dto.ProjectDto;
using ActivityTracker.Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTracker.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService service, ILogger<ProjectController> logger)
        {
            _service = service;
            _logger = logger;

        }

        [HttpGet]
        [Route("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _service.GetAllProjectsAsync();

            _logger.LogInformation("Got all projects");

            return Ok(result);
        }

        [HttpPost]
        [Route("add-project")]
        public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
        {
            await _service.CreateProjectAsync(projectDto);

            _logger.LogInformation("Project created successfully");

            return Ok();
        }

        [HttpDelete]
        [Route("delete-projects")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _service.DeleteProjectAsync(id);

            _logger.LogInformation("Project deleted successfully");

            return Ok();
        }

        [HttpGet]
        [Route("project")]
        public async Task<IActionResult> GetProject(int id)
        {
            var result = await _service.GetProjectByIdAsync(id);

            _logger.LogInformation("Project got successfully");

            return Ok(result);
        }

        [HttpPut]
        [Route("update-project")]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await _service.UpdateProjectAsync(projectDto);

            _logger.LogInformation("Project updated successfully");

            return Ok();
        }

    }
}
