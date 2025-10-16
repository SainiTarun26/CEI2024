using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Officers
{
    public partial class Lift_EscelatorApprovaldata : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
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
                //Added On 8 oct 2025 to Show Industry cirtificate pages.
                if (Convert.ToString(Session["InProcessInspectionId"]) != null && Convert.ToString(Session["InProcessInspectionId"]) != string.Empty)
                {
                    Session["InProcessInspectionId_IndustryLift"] = null;
                    Session["InProcessInspectionId_PeriodicIndustryLift"] = null;
                    LoginID = Session["InProcessInspectionId"].ToString(); 
                }
                else if (Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != null && Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != string.Empty)
                {
                    Session["InProcessInspectionId"] = null;
                    Session["InProcessInspectionId_PeriodicIndustryLift"] = null;
                    LoginID = Session["InProcessInspectionId_IndustryLift"].ToString();
                }
                else if (Convert.ToString(Session["InProcessInspectionId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["InProcessInspectionId_PeriodicIndustryLift"]) != string.Empty)
                {
                    Session["InProcessInspectionId"] = null;
                    Session["InProcessInspectionId_IndustryLift"] = null;
                    LoginID = Session["InProcessInspectionId_PeriodicIndustryLift"].ToString();
                }
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
                    Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                    string id = lblID.Text;

                    //Commented On 8 oct 2025 by aslam.
                    // string  LoginID = Session["InProcessInspectionId"].ToString();
                    //Session["LiftTestReportID"] = id;
                    //if (lblInstallationType.Text == "Lift")
                    //{
                    //    //
                    //    if (lblInspectionType.Text == "Periodic")
                    //    {
                    //        Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("/Print_Forms/LiftApprovalCertificate.aspx", false);
                    //    }
                    //}
                    //else
                    //{
                    //    Response.Redirect("/Print_Forms/EscalatorApprovalCertificate.aspx", false);
                    //}

                    //Added On 8 oct 2025 to Show Industry cirtificate pages by aslam.
                    if (Convert.ToString(Session["InProcessInspectionId"]) != null && Convert.ToString(Session["InProcessInspectionId"]) != string.Empty)
                    {
                        string LoginID = Session["InProcessInspectionId"].ToString();
                        Session["LiftTestReportID"] = id;
                        Session["LiftTestReportID_IndustryLift"] = null;
                        Session["LiftTestReportID_PeriodicIndustryLift"] = null;
                        if (lblInstallationType.Text == "Lift")
                        {
                            if (lblInspectionType.Text == "Periodic")
                            {
                                Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Print_Forms/LiftApprovalCertificate.aspx", false);
                            }
                        }
                        else
                        {
                            if (lblInspectionType.Text == "Periodic")
                            {
                                Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Print_Forms/EscalatorApprovalCertificate.aspx", false);
                            }
                        }
                    }
                    else if (Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != null && Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != string.Empty)
                    {
                        string LoginID = Session["InProcessInspectionId_IndustryLift"].ToString();
                        Session["LiftTestReportID_IndustryLift"] = id;
                        Session["LiftTestReportID"] = null;
                        Session["LiftTestReportID_PeriodicIndustryLift"] = null;
                        if (lblInstallationType.Text == "Lift")
                        {
                            Response.Redirect("/Industry_Master/Print_Forms/LiftApprovalCertificate_IndustryLift.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("/Industry_Master/Print_Forms/EscalatorApprovalCertificate_IndustryLift.aspx", false);
                        }

                    }
                    else if (Convert.ToString(Session["InProcessInspectionId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["InProcessInspectionId_PeriodicIndustryLift"]) != string.Empty)
                    {
                        string LoginID = Session["InProcessInspectionId_PeriodicIndustryLift"].ToString();
                        Session["LiftTestReportID_IndustryLift"] = null;
                        Session["LiftTestReportID"] = null;
                        Session["LiftTestReportID_PeriodicIndustryLift"] = id;

                        if (lblInstallationType.Text == "Lift")
                        {
                            if (lblInspectionType.Text == "Periodic")
                            {
                                Response.Redirect("/Industry_Master/Print_Forms/Print_Renewal_Of_Lift_PeriodicIndustryLift.aspx", false);
                            }
                        }
                        else
                        {
                            if (lblInspectionType.Text == "Periodic")
                            {
                                Response.Redirect("/Industry_Master/Print_Forms/Print_Renewal_Of_Lift_PeriodicIndustryLift.aspx", false);
                            }
                        }

                    }
                }
            }
            catch { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/AcceptedOrReject.aspx", false);
        }
    }
}