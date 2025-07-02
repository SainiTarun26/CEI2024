using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicTestReport_Cinema_Video_Talkies : System.Web.UI.Page
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
                        if (Convert.ToString(Session["id"]) != null && Convert.ToString(Session["id"]) != "")
                        {
                            string ID = Convert.ToString(Session["id"]);
                            HFrowID.Value = Convert.ToString(Session["id"]);
                            DataTable dt = CEI.GetCinemaIntimationComponentdetails(ID);

                            if (dt.Rows.Count > 0)
                            {
                                txtWorkintimation.Text = dt.Rows[0]["IntimationId"].ToString();
                                //only text change by navneet
                                txtInstallation.Text = dt.Rows[0]["InstallationTypeOFCinema"].ToString();
                                //
                                txtNameOfCinema.Text = dt.Rows[0]["InstallationType"].ToString();
                                txtNOOfInstallation.Text = dt.Rows[0]["InstallationNo"].ToString();
                                HiddenField1.Value = dt.Rows[0]["Count"].ToString();
                            }
                        }
                        else
                        {
                            Response.Redirect("CinemaInstallationComponentDetails.aspx", false);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
            }
            catch
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("LogOut.aspx", false);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                string IntimationId = txtWorkintimation.Text;
                string count = HiddenField1.Value;
                string installationNo = HFrowID.Value;
                int ReturnResult = CEI.InsertDataOfCinema_Talkies_TestReport_Periodic(IntimationId, count, txtScreenName.Text.ToString(),
                txtSerialNo.Text.ToString(), txtScreenSize.Text.ToString(), txtLastInspdate.Text.ToString(), installationNo, CreatedBy);

                CEI.UpdateInstallations(installationNo, IntimationId);
                Reset();

                if (ReturnResult == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectNextProcess();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectToinstallationPage();", true);
                }
            }
            catch (Exception ex)
            {
                DataSaved.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void Reset()
        {
            txtScreenName.Text = "";
            txtSerialNo.Text = "";
            txtScreenSize.Text = "";
            txtLastInspdate.Text = "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect("CinemaInstallationComponentDetails.aspx", false);
        }
    }
}