using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.WinUIMethods
{
    public static partial class Customise
    {
        public static void CustomiseDataGridView(DataGridView dataGridView)
        {
            dataGridView.EnableHeadersVisualStyles = false; // Disable default header styles
            // Set the default cell style
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            // Set the header style
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x15, 0x73, 0xE5);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(250, 250, 250);
            // Enable sorting
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = false; // Disable row resizing
            dataGridView.AllowUserToAddRows = false; // Disable adding new rows
            dataGridView.AllowUserToDeleteRows = false; // Disable deleting rows
            // Enable row selection
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Fill Grid
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Set alternating row styles
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0xC5, 0xEE, 0xF3);
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
    }
}
