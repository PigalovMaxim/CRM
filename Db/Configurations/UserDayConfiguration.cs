using CRM.Models;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Db.Configurations
{
    public class UserDayConfiguration : IEntityTypeConfiguration<UserDayEntity>
    {
        public void Configure(EntityTypeBuilder<UserDayEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DayType).HasMaxLength(Enum.GetValues(typeof(DaysTypes)).Length - 1).IsRequired();
            builder.HasOne(x => x.User);
        }
    }
}
