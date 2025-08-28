using CEI_PRoject;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.DealingHand
{
    public partial class DealingHand : System.Web.UI.MasterPage
    {
        //page created by Neeraj
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (Convert.ToString(Session["DealingHandId"]) != null && Convert.ToString(Session["DealingHandId"]) != string.Empty)
                {
                    lblName.Text = Session["DealingHandId"].ToString();
                }
                
                else
                {

                    Session["DealingHandId"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/OfficerLogout.aspx");

        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string StaffId = Session["DealingHandId"].ToString();
            Response.Redirect("/ChangePassword.aspx");

        }
    }
}