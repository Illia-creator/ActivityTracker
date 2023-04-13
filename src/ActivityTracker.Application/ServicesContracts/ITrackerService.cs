using ActivityTracker.Application.Dto.TimeTrackingDto;
using ActivityTracker.Domain.Entities;

namespace ActivityTracker.Application.ServicesContracts
{
    public interface ITrackerService
    {
        string GetActivitiesByPersonAndDate(TrackerPersonAndDateDto trackerDto);
        string GetActivitiesByPersonAndWeekNumberAsync(TrackerPersonAndWeekNumber trackerDto);
    }
}
