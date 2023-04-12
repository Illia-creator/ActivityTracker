using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
