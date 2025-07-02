using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class Cinema_Video_Talkies_TestReport_Modal : System.Web.UI.Page
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
                        if (Convert.ToString(Session["TestReportId"]) != null && Convert.ToString(Session["TestReportId"]) != "")
                        {
                            String TestReportId = Convert.ToString(Session["TestReportId"]);
                            GetData(TestReportId);
                        }
                        else
                        {
                            Response.Redirect("CinemaIntimationDetails.aspx", false);
                        }
                    }
                    else
                    {
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

        private void GetData(string testReportId)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDataCinemaVideoTalkiesTestReport(testReportId);

            lbltestReportId.Text = ds.Tables[0].Rows[0]["TestReportId"].ToString();
            lblWorkIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
            txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
            txtInstallationFor.Text = ds.Tables[0].Rows[0]["InstallationFor"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
            txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtWorkIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
            txtInstallationtype.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
            txtCinemaName.Text = ds.Tables[0].Rows[0]["NameOfScreen"].ToString();
            txtScreenName.Text = ds.Tables[0].Rows[0]["NameOfScreen"].ToString();
            txtInstallationNo.Text = ds.Tables[0].Rows[0]["count"].ToString();
            txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            txtScreenSize.Text = ds.Tables[0].Rows[0]["SizeOfScreen"].ToString();
            txtTRCreatedBy.Text = ds.Tables[0].Rows[0]["TestReportCreatedBy"].ToString();
            txtTRCreatedDate.Text = ds.Tables[0].Rows[0]["TestReportCreatedDate"].ToString();
        }
    }
}