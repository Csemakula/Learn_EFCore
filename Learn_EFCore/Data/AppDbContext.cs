using Learn_EFCore.Models; // Adjust namespace if different
using Microsoft.EntityFrameworkCore;

namespace Learn_EFCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<WorkEntry> WorkEntries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Configure relationships if not relying on EF conventions

            modelBuilder.Entity<Job>()
                .HasOne(j => j.AssignedTo)
                .WithMany(e => e.AssignedJobs)
                .HasForeignKey(j => j.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<WorkEntry>()
                .HasOne(w => w.Job)
                .WithMany(j => j.WorkEntries)
                .HasForeignKey(w => w.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkEntry>()
                .HasOne(w => w.Employee)
                .WithMany(e => e.WorkEntries)
                .HasForeignKey(w => w.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
