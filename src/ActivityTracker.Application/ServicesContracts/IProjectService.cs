using ActivityTracker.Application.Dto.ProjectDto;
using ActivityTracker.Domain.Entities;

namespace ActivityTracker.Application.ServicesContracts
{
    public interface IProjectService
    {
        Task<IQueryable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(CreateProjectDto projectDto);
        Task UpdateProjectAsync(UpdateProjectDto projectDto);
        Task DeleteProjectAsync(int id);
    }
}
