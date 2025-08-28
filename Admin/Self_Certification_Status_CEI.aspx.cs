using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class Self_Certification_Status_CEI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // So data binds only once
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SC_ID");
            dt.Columns.Add("OwnerName");
            dt.Columns.Add("Volatage");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("ApprovedDate");
            dt.Columns.Add("ApplicationStatus");

            // Uncomment to add static rows
            // dt.Rows.Add("SC101", "John Doe", "220V", "2025-08-01", "2025-08-05", "Approved");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow()); // Add an empty row to keep structure
                GridView1.DataSource = dt;
                GridView1.DataBind();

                // Merge cells for "No data found" message
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No data found";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}
