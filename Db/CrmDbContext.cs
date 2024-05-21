using CRM.Db.Configurations;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Db
{
    public class CrmDbContext(DbContextOptions<CrmDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WorkDayEntity> WorkDays { get; set; }
        public DbSet<UserDayEntity> UserDays { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkDayConfiguration());
            modelBuilder.ApplyConfiguration(new UserDayConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
