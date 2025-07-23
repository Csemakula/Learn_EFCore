using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = true;

        public ICollection<Job> AssignedJobs { get; set; } = new List<Job>();
        public ICollection<WorkEntry> WorkEntries { get; set; } = new List<WorkEntry>();
    }

}
