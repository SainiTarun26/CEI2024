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

                    //Added by aslam 15-may-2025
                    if (!IsPostBack && Request.UrlReferrer != null)
                    {
                        ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
                    }
                    //                    
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
                    //labe added by aslam 19-may-2025
                    Label lblblUserType = row.FindControl("lblUserType") as Label;
                    //lblInspectionType added by aslam 24-July-2025
                    Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                    string id = lblID.Text;
                    string InspectionId = Session["InspectionId"].ToString();

                    #region aslam code lift industry_19M-May-2025
                    Session["LiftTestReportID_IndustryLift"] = null;
                    Session["LiftTestReportID"] = null;
                    if (lblblUserType.Text != "Industry")
                    {
                        #endregion
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

                    #region aslam code lift industry_19M-May-2025
                    else if (lblblUserType.Text == "Industry")
                    {
                        Session["LiftTestReportID_IndustryLift"] = id;
                        if (lblInstallationType.Text == "Lift")
                        {
                            Response.Redirect("/Industry_Master/Print_Forms/LiftApprovalCertificate_IndustryLift.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("/Industry_Master/Print_Forms/EscalatorApprovalCertificate_IndustryLift.aspx", false);
                        }
                    }
                    #endregion

                }
            }
            catch { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Added by aslam 15-may-2025
            if (ViewState["PreviousPageUrl"] != null)
            {
                Response.Redirect(ViewState["PreviousPageUrl"].ToString(), false);
            }
            //
        }
    }
}