using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class ViewCart : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        //Session["SiteOwnerId"] = "JVCBN5647K";
                        ViewCartForIndustry();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        private void ViewCartForIndustry()
        {
            string id = Session["SiteOwnerId"].ToString();
            DataSet ds = new DataSet(); ;
            ds = CEI.ViewCartDataIndustry(id);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
               
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
           
            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
                string script = "alert(\"No any item in cart\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            ds.Dispose();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Periodic_Industry/RenewalPerodicIndustry.aspx", false);
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblAddressText = (Label)row.FindControl("lblAddressText");
                Label lblCartId = (Label)row.FindControl("lblCartId");
                Session["Address"] = lblAddressText.Text;
                Session["Cart"] = lblCartId.Text;
                Response.Redirect("/Periodic_Industry/ViewCart_Industry.aspx", false);
            }
            else
            {

            }
        }
    }
}