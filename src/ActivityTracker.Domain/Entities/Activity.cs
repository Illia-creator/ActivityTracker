using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracker.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float TimeOfWork { get; set; } 
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int ActivityTypeId { get; set; }
        public int RoleId { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public ActivityType ActivityType { get; set; }
        public Role Role { get; set; }
    }
}
