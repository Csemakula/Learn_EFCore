using Learn_EFCore.Data;
using Learn_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.Testing
{
    public static class DbSeeder
    {
        private static readonly string[] FirstNames = {
            "Alice", "Kevin", "Martin", "Diana", "Mohammed", "Fiona", "George", "Hannah", "Ian", "Jane", "Felix", "Moraa", "Grace" };
        private static readonly string[] LastNames = {
            "Kamau", "Otieno", "Mutiso", "Kerich", "Ngare", "Juma", "Osiemo", "Shah", "Mohammed", "Okuku" };
        private static readonly string[] JobTitles = {
            "Fix Server", "Update Docs", "Deploy App", "Refactor Code", "Test Features", "Write Specs", "Train Team", "Review Logs" };
        private static readonly string[] JobDescriptions = {
            "Urgent task", "Client request", "Scheduled maintenance", "Internal improvement", "Follow-up work", "Compliance-related"};
        private static readonly string[] WorkDescriptions = {
        "Initial analysis",
        "Gathered requirements",
        "Prepared resources",
        "Worked on core task",
        "Reviewed progress",
        "Performed quality checks",
        "Completed testing",
        "Finalized documentation",
        "Delivered final report"
        };

        public static void SeedTestData(AppDbContext context)
        {
            if (context.Employees.Any() || context.Jobs.Any() || context.WorkEntries.Any())
                return; // Already seeded

            var random = new Random();

            // Seed Employees
            var employees = new List<Employee>();
            for (int i = 0; i < 120; i++)
            {
                var first = FirstNames[random.Next(FirstNames.Length)];
                var last = LastNames[random.Next(LastNames.Length)];
                var fullName = $"{first} {last}";
                var email = $"{first.ToLower()}.{last.ToLower()}{i}@example.com";

                employees.Add(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = fullName,
                    Email = email,
                    Active = random.NextDouble() > 0.1 // 90% active
                });
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            // Seed Jobs
            var jobs = new List<Job>();
            for (int i = 0; i < 1000; i++)
            {
                var assignedEmployee = employees[random.Next(employees.Count)];
                var hasDueDate = random.NextDouble() > 0.2;
                var createdAt = DateTime.UtcNow.AddDays(-random.Next(60));
                var dueDate = hasDueDate
                    ? createdAt.AddDays(random.Next(1, 30))
                    : (DateTime?)null;

                jobs.Add(new Job
                {
                    JobId = Guid.NewGuid(),
                    Title = JobTitles[random.Next(JobTitles.Length)],
                    Description = JobDescriptions[random.Next(JobDescriptions.Length)],
                    CreatedAt = createdAt,
                    DueDate = dueDate,
                    Status = (JobStatus)random.Next(0, 3),
                    AssignedToId = assignedEmployee.Active ? assignedEmployee.EmployeeId : null
                });
            }

            context.Jobs.AddRange(jobs);
            context.SaveChanges();

            // Seed WorkEntries
            var workEntries = new List<WorkEntry>();
            foreach (var job in jobs)
            {
                int workCount = random.Next(0, 11); // 0 to 10 entries
                for (int i = 0; i < workCount; i++)
                {
                    var worker = employees[random.Next(employees.Count)];
                    var workDate = job.CreatedAt.AddDays(random.Next(0, 90));

                    workEntries.Add(new WorkEntry
                    {
                        WorkEntryId = Guid.NewGuid(),
                        JobId = job.JobId,
                        EmployeeId = worker.EmployeeId,
                        PerformedOn = workDate,
                        Description = WorkDescriptions[random.Next(WorkDescriptions.Length)],
                        HoursWorked = (decimal)Math.Round(random.NextDouble() * 8, 2) // up to 8 hours
                    });
                }
            }
            context.WorkEntries.AddRange(workEntries);
            context.SaveChanges();
        }
    }
}
