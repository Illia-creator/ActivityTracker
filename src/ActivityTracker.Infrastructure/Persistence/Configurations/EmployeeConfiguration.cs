using ActivityTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityTracker.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(x => x.Sex)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(x => x.Birthday)
                .IsRequired();
        }
    }
}
