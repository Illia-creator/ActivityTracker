namespace ActivityTracker.Application.Dto.ProjectDto
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
