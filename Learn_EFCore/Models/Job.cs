using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.Models
{

    public class Job
    {
        public Guid JobId { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }

        public JobStatus Status { get; set; } = JobStatus.Pending;

        public Guid? AssignedToId { get; set; }
        public Employee? AssignedTo { get; set; }

        public ICollection<WorkEntry> WorkEntries { get; set; } = new List<WorkEntry>();
    }

}
