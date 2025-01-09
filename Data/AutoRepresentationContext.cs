using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectAutoCore.Models;

namespace ProiectAutoCore.Data
{
    public class AutoRepresentationContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }

        public AutoRepresentationContext(DbContextOptions<AutoRepresentationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Cars)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Car)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceHistory>()
                .HasOne(sh => sh.Car)
                .WithMany()
                .HasForeignKey(sh => sh.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceHistory>()
                .HasOne(sh => sh.Service)
                .WithMany()
                .HasForeignKey(sh => sh.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
