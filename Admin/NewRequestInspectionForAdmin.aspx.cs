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
    public partial class NewRequestInspectionForAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                        BindDropDownForDivision();
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
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
                LoginId = Convert.ToString(Session["AdminId"]);
                string id = ddldivision.SelectedValue.ToString();
                string InstallationType = RadioButtonList1.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.NeWRequestInspectionForAdmin(LoginId, id , InstallationType);
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                Session["Approval"] = lblApproval.Text.Trim();
                string id = lblID.Text;
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                    {
                        Response.Redirect("/Admin/LiftInspectionDetails.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Admin/InspectionDetails.aspx", false);
                    }
                }
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
    }
}