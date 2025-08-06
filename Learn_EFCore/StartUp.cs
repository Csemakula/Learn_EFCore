using Learn_EFCore.Data;
using Learn_EFCore.Utility;
using Learn_EFCore.WinUIMethods;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace Learn_EFCore
{
    public partial class StartUp : Form
    {
        private readonly AppDbContext _context;
        private DataTable _dataTable;
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

            _dataTable = jobList.ToDataTable();
            jobsDataGridView.DataSource = _dataTable;
            Customise.CustomiseDataGridView(jobsDataGridView);
        }

    }
}
