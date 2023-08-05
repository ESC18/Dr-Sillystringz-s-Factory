using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dr_Sillystringzs_Factory.Models
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) : base(options)
        {
        }

        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<EngineerMachine> EngineerMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<EngineerMachine>()
                .HasKey(em => new { em.EngineerId, em.MachineId });

            modelBuilder.Entity<EngineerMachine>()
                .HasOne(em => em.Engineer)
                .WithMany(e => e.EngineerMachines)
                .HasForeignKey(em => em.EngineerId);

            modelBuilder.Entity<EngineerMachine>()
                .HasOne(em => em.Machine)
                .WithMany(m => m.EngineerMachines)
                .HasForeignKey(em => em.MachineId);
        }
    }
}
