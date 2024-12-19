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
    
    public partial class LiftApprovalData : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {
                    GridBind();
                }
            }
            

        }

        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ApprovalData_Lift(LoginID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                // throw;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string id = lblID.Text;
                    string InspectionId = Session["InspectionId"].ToString();
                    Session["LiftTestReportID"] = id;
                    if(lblInstallationType.Text == "Lift")
                    {
                        Response.Redirect("/Print_Forms/LiftApprovalCertificate.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Print_Forms/EscalatorApprovalCertificate.aspx", false);
                    }
                    
                }
            }
            catch { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AcceptedOrRejectedRequest.aspx", false);
        }
    }
}