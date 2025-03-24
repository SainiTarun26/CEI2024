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
    public partial class NewApplications : System.Web.UI.Page
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
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet ds = new DataSet();            
            ds = CEI.NewRequestRecieved(LoginID);
            if (ds.Tables.Count > 0 && ds != null)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                string id = lblID.Text;

                Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                Label lblInstallationfor = (Label)row.FindControl("lblInstallationfor");


                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    if (lblInstallationfor.Text.Trim() == "Lift" || lblInstallationfor.Text.Trim() == "Escalator" || lblInstallationfor.Text.Trim() == "MultiLift" || lblInstallationfor.Text.Trim() == "MultiEscalator" || lblInstallationfor.Text.Trim() == "Lift/Escalator")
                    {
                        if (lblApproval.Text.Trim() == "New" && lblInspectionType.Text.Trim() == "New")
                        {
                            Response.Redirect("/Officers/Inspection_Lift_Escalator.aspx", false);
                            return;
                        }
                        else if (lblApproval.Text.Trim() == "ReSubmit" && lblInspectionType.Text.Trim() == "New")
                        {
                            Response.Redirect("/Officers/Returned_Inspection_Lift_Escalator.aspx", false);
                            return;
                        }
                        else if (lblApproval.Text.Trim() == "New" && lblInspectionType.Text.Trim() == "Periodic")
                        {
                            Response.Redirect("/Officers/PeriodicInspection_Lift_Escalator.aspx", false);
                            return;
                        }
                        else if (lblApproval.Text.Trim() == "ReSubmit" && lblInspectionType.Text.Trim() == "Periodic")
                        {
                            Response.Redirect("/Officers/Returned_PeriodicInspection_Lift_Escalator.aspx", false);
                            return;
                        }

                    }


                    if (lblApproval.Text.Trim() == "New" && lblInspectionType.Text.Trim() == "New")
                    {

                        Response.Redirect("/Officers/Inspection.aspx", false);
                    }
                    else if (lblApproval.Text.Trim() == "ReSubmit" && lblInspectionType.Text.Trim() == "New")
                    {
                        Response.Redirect("/Officers/ReturnedInspections.aspx", false);
                    }
                    else if (lblApproval.Text.Trim() == "New" && lblInspectionType.Text.Trim() == "Periodic")
                    {
                        Response.Redirect("/Officers/PeriodicInspection.aspx", false);
                    }
                    else if (lblApproval.Text.Trim() == "ReSubmit" && lblInspectionType.Text.Trim() == "Periodic")
                    {
                        Response.Redirect("/Officers/PeriodicInspection.aspx", false);
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

       
    }
}