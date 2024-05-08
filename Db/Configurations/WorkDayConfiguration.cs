using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRM.Models.Entities;

namespace CRM.Db.Configurations
{
    public class WorkDayConfiguration : IEntityTypeConfiguration<WorkDayEntity>
    {
        public void Configure(EntityTypeBuilder<WorkDayEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Day).IsRequired();
            builder.Property(x => x.Count).HasMaxLength(12).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.User);
        }
    }
}
