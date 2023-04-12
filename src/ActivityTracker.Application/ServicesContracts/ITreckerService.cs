using ActivityTracker.Application.Dto.TimeTrackingDto;
using ActivityTracker.Domain.Entities;

namespace ActivityTracker.Application.ServicesContracts
{
    public interface ITreckerService
    {
        Task<IQueryable<Activity>> GetActivitiesByPersonAndDateAsync(TrackerPersonAndDateDto trackerDto);
        Task<IQueryable<Activity>> GetActivitiesByPersonAndWeekNumberAsync(TrackerPersonAndWeekNumber trackerDto);
    }
}
