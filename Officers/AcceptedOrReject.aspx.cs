using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class AcceptedOrReject : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }

        }
        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["StaffID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.AcceptOrReject(LoginID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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
                if (e.CommandName == "Select" || e.CommandName == "Print")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                    string id = lblID.Text;
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string InstallationType = lblInstallationType.Text.Trim();
                    Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                    string ApplicationStatus = lblApplicationStatus.Text;
                    Session["InProcessInspectionId"] = id;

                    if (e.CommandName == "Select")
                    {
                       
                        if (InstallationType == "Lift" || InstallationType == "Escalator" || InstallationType == "Lift/Escalator" || InstallationType == "MultiLift" || InstallationType == "MultiEscalator")
                        {
                            if (ApplicationStatus == "Returned")
                            {
                                Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Officers/InProcessInspection.aspx", false);
                        }
                    }
                    else if (e.CommandName == "Print")
                    {
                        if (LblInspectionType.Text == "New")
                        {
                            Session["InProcessInspectionId"] = id;
                            if (InstallationType == "Multiple")
                            {
                                Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                            }

                            else if (InstallationType != "Lift" || InstallationType != "Escalator" || InstallationType != "Lift/Escalator" || InstallationType != "MultiLift" || InstallationType != "MultiEscalator")
                            {
                                Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                            }
                        }
                        if (InstallationType == "Lift" || InstallationType == "Escalator" || InstallationType == "Lift/Escalator" || InstallationType == "MultiLift" || InstallationType == "MultiEscalator")
                        {
                            Session["InProcessInspectionId"] = id;
                            Response.Redirect("/Officers/Lift_EscelatorApprovaldata.aspx", false);
                        }

                        else
                        {
                            Session["InProcessInspectionId"] = id;
                            Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //
            }
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch (Exception ex)
            {
            
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                if (applicationStatus == "Approved")
                {

                    linkButton.Visible = true;
                }
                else
                {

                    linkButton.Visible = false;
                }
            }
        }
    }
}