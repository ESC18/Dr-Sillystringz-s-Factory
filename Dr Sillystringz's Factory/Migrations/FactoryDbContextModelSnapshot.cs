using Dr_Sillystringz_s_Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dr_Sillystringz_s_Factory.Migrations
{
    [DbContext(typeof(FactoryDbContext))]
    partial class FactoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.Engineer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.EngineerMachine", b =>
                {
                    b.Property<int>("EngineerId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.HasKey("EngineerId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("EngineerMachines");
                });

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.EngineerMachine", b =>
                {
                    b.HasOne("Dr_Sillystringzs_Factory.Models.Engineer", "Engineer")
                        .WithMany("EngineerMachines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dr_Sillystringzs_Factory.Models.Machine", "Machine")
                        .WithMany("EngineerMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.Engineer", b =>
                {
                    b.Navigation("EngineerMachines");
                });

            modelBuilder.Entity("Dr_Sillystringzs_Factory.Models.Machine", b =>
                {
                    b.Navigation("EngineerMachines");
                });
#pragma warning restore 612, 618
        }
    }
}
