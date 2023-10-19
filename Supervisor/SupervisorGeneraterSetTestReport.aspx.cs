using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
   
    public partial class SupervisorGeneraterSetTestReport : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridviewBind();
            }
        }

        protected void GridviewBind()
        {
            string LoginId = string.Empty;
            LoginId = Session["AdminID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.GetGeneraterSetData(LoginId);
            if(ds.Tables.Count>0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "serverScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                string id = lblID.Text;
                Session["LineID"] = id;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
                }
            }
        }
    }
}