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

        //Page created by neha 19-May-2025
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
                            DataTable dt = CEI.GetCinemaIntimationComponentdetails(ID);

                            if (dt.Rows.Count > 0)
                            {
                                txtWorkintimation.Text = dt.Rows[0]["IntimationId"].ToString();
                                txtInstallation.Text = dt.Rows[0]["InstallationType"].ToString();
                                txtNameOfCinema.Text = dt.Rows[0]["InstallationType"].ToString();
                                txtNOOfInstallation.Text = dt.Rows[0]["InstallationNo"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            TxtAgentName.Text = "";
            txtAgentPhone.Text = "";
            txtScreenSize.Text = "";
            txtLastInspdate.Text = "";
        }
    }
}