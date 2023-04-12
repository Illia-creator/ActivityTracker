using ActivityTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Infrastructure.Persistence
{
    public class ActivityTrackerDbContext : DbContext
    {
        public ActivityTrackerDbContext(DbContextOptions<ActivityTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
