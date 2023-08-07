using Microsoft.EntityFrameworkCore;

namespace Dr_Sillystringz_s_Factory.Models
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) : base(options) { }

        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<EngineerMachine> EngineerMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineerMachine>().HasKey(em => new { em.EngineerId, em.MachineId });

            modelBuilder.Entity<Engineer>()
                .HasMany(e => e.EngineerMachines)
                .WithOne(em => em.Engineer)
                .HasForeignKey(em => em.EngineerId);

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.EngineerMachines)
                .WithOne(em => em.Machine)
                .HasForeignKey(em => em.MachineId);
        }
    }
}
