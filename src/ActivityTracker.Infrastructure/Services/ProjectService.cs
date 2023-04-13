using ActivityTracker.Application.Dto.ProjectDto;
using ActivityTracker.Application.ServicesContracts;
using ActivityTracker.Domain.Entities;
using ActivityTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ActivityTracker.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ActivityTrackerDbContext _context;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(ActivityTrackerDbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async ValueTask CreateProjectAsync(CreateProjectDto projectDto)
        {
            try
            {
                if (projectDto == null) throw new ArgumentNullException("Project Dto Is Null");
                Project project = await _context.Projects.FirstOrDefaultAsync(x => x.Name == projectDto.Name);
                if (project == null)
                {
                    Project newProject = new Project();

                    newProject.Name = projectDto.Name;
                    newProject.IsDeleted = false;
                    newProject.DateStart = projectDto.DateStart;
                    newProject.DateEnd = projectDto.DateEnd;

                    _context.Projects.Add(newProject);
                    await _context.SaveChangesAsync();
                }
                else throw new Exception("Project is already exist");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        public async ValueTask DeleteProjectAsync(int id)
        {
            try
            {
                Project project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

                if (project != null && project.IsDeleted != true)
                {
                    project.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
                else throw new Exception("Project does not exist or deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        public async ValueTask<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                var projects = await _context.Projects.ToListAsync();

                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }

        public async ValueTask<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

                if (project == null) throw new Exception("Any project was found");

                return project;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }

        public async ValueTask UpdateProjectAsync(UpdateProjectDto projectDto)
        {
            try
            {
                Project projectToUpdate = await _context.Projects.FirstOrDefaultAsync(x => x.Id == projectDto.Id);

                if (projectToUpdate == null) throw new Exception("Project does not exist");
                else
                {
                    projectToUpdate.Id = projectDto.Id;
                    projectToUpdate.Name = projectDto.Name;
                    projectToUpdate.IsDeleted = projectDto.IsDeleted;
                    projectToUpdate.DateStart = projectDto.DateStart;
                    projectToUpdate.DateEnd = projectDto.DateEnd;

                    _context.Projects.Update(projectToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }
    }
}

