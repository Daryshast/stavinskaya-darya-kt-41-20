using Microsoft.EntityFrameworkCore;
using stavinskaya_darya_kt_41_20.Data.Configurations;
using stavinskaya_darya_kt_41_20.Models;

namespace stavinskaya_darya_kt_41_20.Data
{
        public class DisciplineDbContext : DbContext
        {

            public DbSet<Direction> Directions { get; set; }
            public DbSet<Discipline> Disciplines { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
                modelBuilder.ApplyConfiguration(new DirectionConfiguration());
            }

            public DisciplineDbContext(DbContextOptions<DisciplineDbContext> options) : base(options)
            {

            }
        }
    }
