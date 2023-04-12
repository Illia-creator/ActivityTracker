using ActivityTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityTracker.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.TimeOfWork)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.ActivityType)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.ActivityTypeId);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
