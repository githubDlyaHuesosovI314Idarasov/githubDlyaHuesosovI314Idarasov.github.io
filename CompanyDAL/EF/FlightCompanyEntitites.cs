using Microsoft.EntityFrameworkCore;
using Models.Base;
using Models;
using Microsoft.IdentityModel;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Areas.AspNet.Identity.Data;
using CompanyDAL.EF.Configurations;

// using System.Data.Entity;
// using System.Data.Entity.Core.Objects;

namespace CompanyDAL.EF
{
    public partial class FlightCompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public FlightCompanyDbContext()
        {

        }
        public FlightCompanyDbContext(DbContextOptions<FlightCompanyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FlightCompanyDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Plane> Planes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plane>().ToTable("Planes");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");

            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());


        }




    }
}
