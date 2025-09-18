using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.GuestAdmin
{
    public partial class InProcessRequestForGuestAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    

                    if (Convert.ToString(Session["GuestAdmin"]) != null && Convert.ToString(Session["GuestAdmin"]) != string.Empty)
                    {
                        GridBind();
                        BindDropDownForDivision();
                    }
                    else
                    {
                        Session["GuestAdmin"] = "";
                        Response.Redirect("/GuestAdminLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/GuestAdminLogout.aspx");
            }
        }

        public void GridBind()
        {
            try
            {
                LoginId = Convert.ToString(Session["GuestAdmin"]);
                string id = ddldivision.SelectedValue.ToString();
                string InstallationType = RadioButtonList1.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.InProcessRequestInspectionForGuestAdmin(LoginId, id, InstallationType);
                if (ds.Tables.Count > 0)
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

                //throw;
            }

        }
        private void BindDropDownForDivision()
        {
            try
            {
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.DdlForDivision();
                ddldivision.DataSource = dsDivision;
                ddldivision.DataTextField = "HeadOffice";
                ddldivision.DataValueField = "HeadOffice";
                ddldivision.DataBind();
                ddldivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
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

        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddldivision.SelectedValue.ToString();
            GridBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = RadioButtonList1.SelectedValue.ToString();
            GridBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                //if (e.CommandName == "Select")
                //{
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                string id = lblID.Text;
                Session["InspectionId"] = id;

                if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                {
                    Response.Redirect("/GuestAdmin/CinemaInspectionDetailsGuestAdmin.aspx", false);
                }
                else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                {
                    Response.Redirect("/GuestAdmin/LiftInspectionDetailsGuestAdmin.aspx", false);
                }
                else
                {
                    Response.Redirect("/GuestAdmin/InspectionDetailsGuestAdmin.aspx", false);
                }

            }
        }
    }
}