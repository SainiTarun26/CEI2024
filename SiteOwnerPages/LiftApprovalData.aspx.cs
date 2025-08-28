using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftApprovalData : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
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
                    string id = lblID.Text;
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    Label lblRegistrationNo = (Label)row.FindControl("lblRegistrationNo");
                    Session["RegistrationNo"] = lblRegistrationNo.Text;
                    string InspectionId = Session["InspectionId"].ToString();
                    Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                    Session["LiftTestReportID"] = id;
                    #region aslam code liftperiodic 26-July-2025
                    if (lblInstallationType.Text == "Lift")
                    {
                        if (lblInspectionType.Text == "Periodic")
                        {
                            Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);
                            return;
                        }
                        else
                        {
                            Response.Redirect("/Print_Forms/LiftApprovalCertificate.aspx", false);
                            return;
                        }
                    }
                    else
                    {
                        if (lblInspectionType.Text == "Periodic")
                        {
                            Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);
                            return;
                        }
                        else
                        {
                            Response.Redirect("/Print_Forms/EscalatorApprovalCertificate.aspx", false);
                            return;
                        }
                    }
                    #endregion

                }
            }
            catch { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx");
        }
    }
}