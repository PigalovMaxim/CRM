using CRM.Db.Configurations;
using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Db
{
    public class CrmDbContext(DbContextOptions<CrmDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
