using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.Models
{
    public class WorkEntry
    {
        public Guid WorkEntryId { get; set; } = Guid.NewGuid();

        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string Description { get; set; }
        public decimal Hours { get; set; }
        public DateTime PerformedOn { get; set; } = DateTime.UtcNow;
    }

}
