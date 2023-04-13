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

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _service.GetAllProjectsAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("add-project")]
        public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
        {
            await _service.CreateProjectAsync(projectDto);

            return Ok();
        }

        [HttpDelete]
        [Route("delete-projects")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _service.DeleteProjectAsync(id);

            return Ok();
        }

        [HttpGet]
        [Route("project")]
        public async Task<IActionResult> GetProject(int id)
        {
            var result = await _service.GetProjectByIdAsync(id);

            return Ok(result);
        }

        [HttpPut]
        [Route("update-project")]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await _service.UpdateProjectAsync(projectDto);

            return Ok();
        }

    }
}
