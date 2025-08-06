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

        /*private void StartUp_Load(object sender, EventArgs e)
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

            _bindingSource = new BindingSource
            {
                DataSource = jobList.ToDataTable()
            };
            jobsDataGridView.DataSource = _bindingSource;
            Customise.CustomiseDataGridView(jobsDataGridView);
        }*/

        private void StartUp_Load(object sender, EventArgs e)
        {
            var list = _context.Jobs
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
            LoadJobsGrid(list);
            Customise.CustomiseDataGridView(jobsDataGridView);
        }

        /// <summary>
        /// Base EF Core query for jobs with assigned employee names.
        /// You can modify this query later for filtering, grouping, etc.
        /// </summary>
        private IQueryable<object> GetBaseJobQuery()
        {
            return _context.Jobs
                .Include(j => j.AssignedTo)
                .Select(j => new
                {
                    j.Title,
                    j.Description,
                    j.Status,
                    j.DueDate,
                    AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
                });
        }

        private void allToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetAllJobs(_context, j => new
            {
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void overDueToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetOverdueJobs(_context, j => new
            {
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void unassignedToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetUnassignedJobs(_context, j => new
            {
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void topEmployeeToolStripButton_Click(object sender, EventArgs e)
        {
            /*var list = JobQueries.GetTopEmployeesByHours(_context,
                g => new
                {
                    EmployeeName = g.Key,
                    TotalHours = g.Sum(w => w.HoursWorked)
                },
                count: 10 // optional, defaults to 10
            ).ToList();

            LoadJobsGrid(list);*/
        }

        private void recentToolStripButton_Click(object sender, EventArgs e)
        {
            var list = JobQueries.GetRecentJobs(_context, j => new
            {
                j.Title,
                j.Description,
                j.Status,
                j.DueDate,
                AssignedTo = j.AssignedTo != null ? j.AssignedTo.Name : "(Unassigned)"
            }).ToList();

            LoadJobsGrid(list);
        }

        private void averageToolStripButton_Click(object sender, EventArgs e)
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
            LoadJobsGrid(query.ToList());
        }

        /// <summary>
        /// Runs the query, converts to DataTable, and binds to the grid.
        /// </summary>
        private void LoadJobsGrid<T>(List<T> list)
        {
            //var list = query.ToList(); // EF executes here

            _bindingSource = new BindingSource
            {
                DataSource = list.ToDataTable()
            };
            jobsDataGridView.DataSource = _bindingSource;
        }
    }
}
