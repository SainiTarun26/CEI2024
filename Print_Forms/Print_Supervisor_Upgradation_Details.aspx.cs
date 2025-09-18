using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class Print_Supervisor_Upgradation_Details : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    Session["BackPreviousPage"] = Request.UrlReferrer.ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Session["AdminId"])))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        int RowID = Convert.ToInt32(Session["id"]);
                        GetDataItem(RowID);

                    }
                    else
                    {
                        Response.Redirect("/Admin/Contractor_Supervisor_Upgradation_Details.aspx");
                    }
                }
                else if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        int RowID = Convert.ToInt32(Session["id"]);
                        GetDataItem(RowID);

                    }
                    else
                    {
                        Response.Redirect("/Supervisor/SupervisorUpgradationHistory.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }
        private void GetDataItem(int rowID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUpgradationOSupervisorRecordsDataAtAdmin(rowID);
                if (dt != null && dt.Rows.Count > 0)
                {

                    HFUserID.Value = dt.Rows[0]["CreatedBy"].ToString();
                    HFApplicationId.Value = dt.Rows[0]["ApplicationId"].ToString();
                    txtQualification.Text = dt.Rows[0]["Qualification"].ToString();

                    string qualificationStr = dt.Rows[0]["Qualification"].ToString();
                    int qualificationInt;
                    if (int.TryParse(qualificationStr, out qualificationInt))
                    {
                        if (qualificationInt >= 1 && qualificationInt <= 7)
                        {
                            getQualification(qualificationInt);
                        }
                        else
                        {
                            txtQualification.Text = dt.Rows[0]["Qualification"].ToString(); ;
                        }

                    }

                    txtSupervisorName.Text = dt.Rows[0]["Name"].ToString();
                    txtDob.Text = dt.Rows[0]["DOB"].ToString();
                    txtCurrentAge.Text = dt.Rows[0]["CalculatedAge"].ToString();
                    string ageText = dt.Rows[0]["CalculatedAge"].ToString();
                    if (!string.IsNullOrEmpty(ageText))
                    {
                        // Try to extract the number before "years"
                        int ageInYears = 0;
                        string[] parts = ageText.Split(new string[] { "years" }, StringSplitOptions.None);

                        if (parts.Length > 0)
                        {
                            // Remove non-numeric characters and try to parse
                            string yearPart = parts[0].Trim();
                            if (int.TryParse(yearPart, out ageInYears))
                            {
                                if (ageInYears >= 55)
                                {
                                    MedicalCertificate.Visible = true;
                                }
                                else
                                {
                                    MedicalCertificate.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        MedicalCertificate.Visible = false; // default fallback
                    }
                    txtNewCertificateNo.Text = dt.Rows[0]["NewCertificateNo"].ToString();
                    txtOldCertificateNo.Text = dt.Rows[0]["OldCertificateNo"].ToString();
                    txtIssueDate.Text = dt.Rows[0]["DateOfIssue"].ToString();
                    txtExperience.Text = dt.Rows[0]["Experience"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtDistrict.Text = dt.Rows[0]["District"].ToString();


                    txtPin.Text = dt.Rows[0]["Pincode"].ToString();
                    txtrblbelated.Text = dt.Rows[0]["UpgradationAppliedErlier"].ToString().Trim();
                    if (txtrblbelated.Text == "Yes")
                    {

                        InterviewDate.Visible = true;
                        txtInterviewDate.Text = dt.Rows[0]["InterviewDate"].ToString();
                    }
                    else
                    {
                        InterviewDate.Visible = false;

                    }

                    txtCurrentVoltage.Text = dt.Rows[0]["CurrentLicenceVoltageLevel"].ToString();
                    txtScopeVoltage.Text = dt.Rows[0]["ScopeVoltageLevel"].ToString();
                }
                else { }
            }
            catch (Exception ex)
            {
            }
        }

        private void getQualification(int qualificationInt)
        {
            DataTable dQ = new DataTable();
            dQ = CEI.GetSupervisorqualification(qualificationInt);
            if (dQ != null && dQ.Rows.Count > 0)
            {
                txtQualification.Text = dQ.Rows[0]["Qualificaton"].ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string previousPageUrl = Session["BackPreviousPage"] as string;
            if (!string.IsNullOrEmpty(previousPageUrl))
            {
                Response.Redirect(previousPageUrl, false);
                Session["BackPreviousPage"] = null;
            }
        }
    }
}