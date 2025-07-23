using Learn_EFCore.Data;
using Learn_EFCore.Models;
using Microsoft.EntityFrameworkCore;
namespace Learn_EFCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            using var context = new AppDbContext(options);

            // Seed test data here
            SeedData(context);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartUp(context));
        }

        static void SeedData(AppDbContext context)
        {
            var alice = new Employee { Name = "Alice", Email = "alice@example.com", Active = true };
            var bob = new Employee { Name = "Bob", Email = "bob@example.com", Active = false };

            var job1 = new Job { Title = "Fix Server", Description = "Server down", AssignedTo = alice, Status = JobStatus.InProgress, DueDate = DateTime.UtcNow.AddDays(3) };
            var job2 = new Job { Title = "Update Docs", AssignedTo = bob, Status = JobStatus.Pending };

            context.Employees.AddRange(alice, bob);
            context.Jobs.AddRange(job1, job2);

            context.SaveChanges();

            // Simulate Bob becoming inactive and nullify his assignments
            bob.Active = false;

            var jobsAssignedToBob = context.Jobs.Where(j => j.AssignedToId == bob.EmployeeId);
            foreach (var job in jobsAssignedToBob)
                job.AssignedToId = null;

            context.SaveChanges();
        }


    }
}