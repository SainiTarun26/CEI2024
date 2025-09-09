
using System;
using System.Web;

namespace CEI_PRoject.ADMIN
{
    public partial class Admin_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["AdminID"]) != null || Convert.ToString(Session["AdminID"]) != string.Empty || Request.Cookies["AdminID"] != null)
                {
                    if (Request.Cookies["AdminID"] != null)
                    {

                        lblName.Text = Request.Cookies["AdminID"].Value;
                        if (string.Equals(lblName.Text, "Admin@123", StringComparison.OrdinalIgnoreCase))
                        {

                            UtilityMasterTab.Visible = true;
                            WingMasterTab.Visible = true;
                            ZoneMasterTab.Visible = true;
                            CircleMasterTab.Visible = true;
                            DivisionMasterTab.Visible = true;
                            SubDivisionMasterTab.Visible = true;
                            SLDRequest.Visible = false;
                            //SLDApproval.Visible = false;
                            //SLDHistory.Visible = false;
                            NewInspectionTab.Visible = false;
                            //ActionInprocesstab.Visible = false;
                            CESE.Visible = true;
                            UpgradationRequest.Visible = true;
                            UpgradationHistory.Visible = true;
                            Printforms.Visible = true;
                            StaffDetails.Visible = true;
                            TerminationOrSuspension.Visible = false;
                        }
                        else
                        {

                            UtilityMasterTab.Visible = false;
                            WingMasterTab.Visible = false;
                            ZoneMasterTab.Visible = false;
                            CircleMasterTab.Visible = false;
                            DivisionMasterTab.Visible = false;
                            SubDivisionMasterTab.Visible = false;
                            SLDRequest.Visible = true;
                            //SLDApproval.Visible = true;
                            //SLDHistory.Visible = true;
                            NewInspectionTab.Visible = true;
                            //ActionInprocesstab.Visible = true;
                            CESE.Visible = false;
                            UpgradationRequest.Visible = true;
                            UpgradationHistory.Visible = true;
                            TerminationOrSuspension.Visible = true;
                        }
                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["AdminID"]);
                    }
                }
                else if (Session["AdminID"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/AdminLogout.aspx");
                }
                else
                {

                    Session["AdminID"] = "";
                    Response.Redirect("/AdminLogout.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["AdminID"] = "";
                Response.Redirect("/AdminLogout.aspx");
            }


        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/AdminLogout.aspx");
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string AdminId = Session["AdminID"].ToString();
            Response.Redirect("/ChangePassword.aspx");
        }
    }
}