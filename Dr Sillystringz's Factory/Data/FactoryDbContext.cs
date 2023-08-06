using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dr_Sillystringz_s_Factory.Models;

namespace Dr_Sillystringz_s_Factory.Models
{
    public class FactoryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FactoryDbContext(DbContextOptions<FactoryDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }
    }
}
