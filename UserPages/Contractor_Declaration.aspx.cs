using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Contractor_Declaration : System.Web.UI.Page
    {
        // Created by neha on 27-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        //if (Convert.ToString(Session["TempUniqueId"]) != null && Convert.ToString(Session["TempUniqueId"]) != "")
                        //{
                        string UserID = Session["ContractorID"].ToString();
                        HdnUserId.Value = UserID;
                        string ID = Convert.ToString(Session["TempUniqueId"]);
                        //}
                        //else
                        //{
                        //    Response.Redirect("/LogOut.aspx", false);
                        //}
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
            {

                if (chkDeclaration.Checked == true)
                {
                    string UserID = Session["ContractorID"]?.ToString();
                    //string tempUniqueId = Session["TempUniqueId"]?.ToString();

                    if (!string.IsNullOrEmpty(UserID))
                    {
                        CEI.ToSaveDocdataofContNewregistration(UserID, "Contractor");
                        CEI.InsertNewLicenceApplicationFromCEIByRegistrationNo("New", UserID);

                    }

                    Session["TempUniqueId"] = "";
                    Session["TempUniqueId"] = null;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "if (confirm('New User Registration Process completed successfully.')) { window.location.href = '/AdminLogout.aspx'; }", true);
                    Response.Redirect("/UserPages/New_Application_Status.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
    }
}