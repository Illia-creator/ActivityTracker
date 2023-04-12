using ActivityTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityTracker.Infrastructure.Persistence.Configurations
{
    public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
