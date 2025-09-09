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
    public partial class AcceptedOrRejectedRequestForGuestAdmin : System.Web.UI.Page
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
                        Response.Redirect("/LogOut.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }

        }

   
        private void GridBind()
        {
            try
            {
                LoginId = Convert.ToString(Session["GuestAdmin"]);
                string id = ddldivision.SelectedValue.ToString();
                string InstallationType = RadioButtonList1.SelectedValue.ToString();
                DataTable dt = new DataTable();
                //ds = CEI.AcceptedOrRejectedRequestInspectionForAdmin(LoginId, id);
                dt = CEI.AcceptRejectReturnedInspectionForGuestAdmin(LoginId, id, InstallationType);
                if(dt.Rows.Count>0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();
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



    }
}