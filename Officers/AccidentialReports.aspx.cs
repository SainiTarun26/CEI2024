using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.Officers
{
    public partial class AccidentialReports : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                {
                    string LoginId = Convert.ToString(Session["StaffID"]);
                    BindGrid(LoginId);
                }
                else 
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        public void BindGrid(string LoginId)
        {                       
            DataTable ds = new DataTable();
            ds = CEI.GetAccidentialReports_forOfficer(LoginId);
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
                Session["Accident_ID"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label AccidentId = (Label)row.FindControl("AccidentId");
                Session["Accident_ID"] = AccidentId.Text;
                Response.Redirect("/Officers/Investigation_of_Electrical_Accidents_officer.aspx", false);

            }
        }
    }
}