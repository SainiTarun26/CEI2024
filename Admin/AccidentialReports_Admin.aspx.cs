using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class AccidentialReports_Admin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {                   
                    BindGrid();
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        public void BindGrid()
        {
            DataTable ds = new DataTable();
            ds = CEI.GetAccidentialReports_forAdmin();
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

            }
            ds.Dispose();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                Session["Accident_IDAdmin"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label AccidentId = (Label)row.FindControl("AccidentId");
                Session["Accident_IDAdmin"] = AccidentId.Text;
                Response.Redirect("/Admin/Investigation_of_Electrical_Accidents_officer_Admin.aspx", false);

            }
        }
    }
}