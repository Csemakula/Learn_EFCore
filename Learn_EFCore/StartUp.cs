using Learn_EFCore.Data;
using Microsoft.EntityFrameworkCore;
namespace Learn_EFCore
{
    public partial class StartUp : Form
    {
        private readonly AppDbContext _context;
        public StartUp(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            Load += StartUp_Load;
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            var jobList = _context.Jobs
                .Include(j => j.AssignedTo)
                .Select(j => new
                {
                    j.Title,
                    j.Description,
                    j.Status,
                    j.DueDate,
                    AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
                })
                .ToList();

            jobsDataGridView.DataSource = jobList;
        }

    }
}
