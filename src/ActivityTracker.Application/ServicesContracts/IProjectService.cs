using ActivityTracker.Application.Dto.ProjectDto;
using ActivityTracker.Domain.Entities;

namespace ActivityTracker.Application.ServicesContracts
{
    public interface IProjectService
    {
        ValueTask<IEnumerable<Project>> GetAllProjectsAsync();
        ValueTask<Project> GetProjectByIdAsync(int id);
        ValueTask CreateProjectAsync(CreateProjectDto projectDto);
        ValueTask UpdateProjectAsync(UpdateProjectDto projectDto);
        ValueTask DeleteProjectAsync(int id);
    }
}
