using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Db.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(128).IsRequired();
            builder.Property(x => x.WastedHours).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Hours).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256).IsRequired();

            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Executor);
        }
    }
}
