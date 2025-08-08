using Learn_EFCore.Activity;
using Learn_EFCore.Data;
using Learn_EFCore.Utility;
using Learn_EFCore.WinUIMethods;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
namespace Learn_EFCore
{
    public partial class StartUp : Form
    {
        private readonly AppDbContext _context;
        private DataTable _dataTable;
        private BindingSource _bindingSource;
        public StartUp(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            Load += StartUp_Load;
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            LoadJobsGrid(GetBaseJobQuery());
            Customise.CustomiseDataGridView(jobsDataGridView);
        }

        private void AllToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetAllJobs(_context, j => new
            {
                j.CreatedAt,
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void OverDueToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetOverdueJobs(_context, j => new
            {
                j.CreatedAt,
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void UnassignedToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetUnassignedJobs(_context, j => new
            {
                j.CreatedAt,
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void TopEmployeeToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetTopEmployeesByHours(_context,
                g => new
                {
                    EmployeeName = g.Key,
                    TotalHours = g.Sum(w => w.HoursWorked)
                },
                count: 10 // optional, defaults to 10
            ).ToList();

            LoadJobsGrid(list);
        }

        private void RecentToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetRecentJobs(_context, j => new
            {
                j.CreatedAt,
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void AverageToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetOverdueJobs(_context, j => new
            {
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();
        }

        private void LoadJobsGrid<T>(IQueryable<T> query)
        {
            var list = query.ToList(); // EF executes here
            jobsDataGridView.DataSource = null; // Clear previous data source
            jobsDataGridView.DataSource = list;
        }

        private void LoadJobsTableGrid<T>(List<T> list)
        {
            //var list = query.ToList(); // EF executes here

            _bindingSource = new BindingSource
            {
                DataSource = list.ToDataTable()
            };
            jobsDataGridView.DataSource = _bindingSource;
        }

        private void LoadJobsGrid<T>(List<T> list)
        {
            //var list = query.ToList(); // EF executes here

            _bindingSource = new BindingSource
            {
                DataSource = list
            };
            jobsDataGridView.DataSource = _bindingSource;
        }

        private IQueryable<object> GetBaseJobQuery()
        {
            return _context.Jobs
                .Include(j => j.AssignedTo)
                .Select(j => new
                {
                    j.CreatedAt,
                    j.Title,
                    j.Description,
                    j.Status,
                    j.DueDate,
                    AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
                });
        }
    }
}
