using ActivityTracker.Application.Dto.TimeTrackingDto;
using ActivityTracker.Application.ServicesContracts;
using ActivityTracker.Domain.Entities;
using ActivityTracker.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ActivityTracker.Infrastructure.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ActivityTrackerDbContext _context;
        private readonly ILogger<TrackerService> _logger;
        public TrackerService(ActivityTrackerDbContext context, ILogger<TrackerService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public string GetActivitiesByPersonAndDate(TrackerPersonAndDateDto trackerDto)
        {
            try
            {
                var activities = _context.Activities
                    .Where(x => x.EmployeeId == trackerDto.id)
                    .Where(x => x.Date.Date == trackerDto.Date);

                if (!activities.Any()) throw new Exception("No activities with such parameters");

                string result = "";

                foreach (var activity in activities)
                {
                    result = TrackerResult(activity).ToString();
                }

                _logger.LogInformation("Activities by person Id and Date got successfully");
               
                return result.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }

        public string GetActivitiesByPersonAndWeekNumberAsync(TrackerPersonAndWeekNumber trackerDto)
        {
            try
            {
                var week = ISOWeek.ToDateTime(trackerDto.Year, trackerDto.WeekNumber, DayOfWeek.Monday);

                var activities = _context.Activities
                    .Where(x => x.EmployeeId == trackerDto.Id)
                    .Where(x => x.Date >= week && x.Date < week.AddDays(7));

                if (!activities.Any()) throw new Exception("No activities with such parameters");

                string result = "";

                foreach (var activity in activities)
                {
                    result = TrackerResult(activity).ToString();
                }

                _logger.LogInformation("Activities by person Id and Number of week");

                return result.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }

        public string TrackerResult(Activity activity)
        {
            try
            {
                ActivityType activityType = _context.ActivityTypes.FirstOrDefault(x => x.Id == activity.ActivityTypeId);
                Employee employee = _context.Employees.FirstOrDefault(x => x.Id == activity.EmployeeId);
                Project project = _context.Projects.FirstOrDefault(x => x.Id == activity.ProjectId);
                Role role = _context.Roles.FirstOrDefault(x => x.Id == activity.RoleId);

                string result =
                    $"{activity.Date.Date} {employee.Name} worked as a {role.Name} on {project.Name} for {activity.TimeOfWork} hours";

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }
    }
}
