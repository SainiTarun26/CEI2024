using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Superintendent
{
    public partial class Superintendent : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (Convert.ToString(Session["SuperidentId"]) != null && Convert.ToString(Session["SuperidentId"]) != string.Empty)
                {
                    string Id = Session["SuperidentId"].ToString();
                    lblName.Text = Id;
                }
                else
                {

                    Session["SuperidentId"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string StaffId = Session["SuperidentId"].ToString();
            Response.Redirect("/ChangePassword.aspx");

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/OfficerLogout.aspx");
        }
    }
}