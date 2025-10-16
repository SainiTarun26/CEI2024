using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System.Windows.Media.TextFormatting;
using CEI_PRoject;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using iText.StyledXmlParser.Node;

namespace CEIHaryana.Industry_Master.TestReportModal
{
    public partial class LiftPeriodicTestReportModal_PeriodicIndustryLift : System.Web.UI.Page
    {
        //page created by aslam 16-oct-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string siteOwnerId = Convert.ToString(Session["SiteOwnerId_PeriodicIndustryLift"]);
                    string registrationNo = Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"]);
                    string TestReportID = Convert.ToString(Session["TestReportID_PeriodicIndustryLift"]);
                    if (Request.UrlReferrer != null)
                    {
                        Session["PreviousPage_PeriodicIndustryLift"] = Request.UrlReferrer.ToString();
                    }

                    if (!string.IsNullOrEmpty(siteOwnerId) && !string.IsNullOrEmpty(registrationNo) && !string.IsNullOrEmpty(TestReportID))
                    {
                        GetData();
                        GetDetails();
                    }
                    else if ((Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                        && !string.IsNullOrEmpty(Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"])) && !string.IsNullOrEmpty(Convert.ToString(Session["TestReportID_PeriodicIndustryLift"])))
                    {
                        GetData();
                        GetDetails_AtOfficerEnd();
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
            }
            catch (Exception Ex)
            { }
        }

        private void GetDetails()
        {
            if (Convert.ToString(Session["SiteOwnerId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["SiteOwnerId_PeriodicIndustryLift"]) != "")
            {
                string Id = Session["SiteOwnerId_PeriodicIndustryLift"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSiteOwnerDataInPeriodicOfLift_PeriodicIndustryLift(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtInstallationFor.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void GetData()
        {
            try
            {
                if (Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"]) != null && Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"]) != "")
                {
                    string RegistrationNo = Session["RegistrationNo_PeriodicIndustryLift"].ToString();
                    string TRId = Session["TestReportID_PeriodicIndustryLift"].ToString();
                    DataSet ds = CEI.GetDetailsOfLiftRenewalReport_PeriodicIndustryLift(RegistrationNo, TRId);

                    txtLastPaymentDate.Text = ds.Tables[0].Rows[0]["LastDateOfPayment"].ToString();
                    txtMemoDate.Text = ds.Tables[0].Rows[0]["MemoDate"].ToString();
                    txtDateofErection.Text = ds.Tables[0].Rows[0]["ErectionDate"].ToString();
                    txtLastExpiryDate.Text = ds.Tables[0].Rows[0]["LastExpiryDate"].ToString();
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                    txtControlType.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                    txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    txtDistrictOfTr.Text = ds.Tables[0].Rows[0]["ApplicantDistrict"].ToString();
                    txtLiftType.Text = ds.Tables[0].Rows[0]["TypeOfLift"].ToString();

                    GridDocument();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridDocument()
        {
            string RegistrationNo = Session["RegistrationNo_PeriodicIndustryLift"].ToString();

            string TReportID = Convert.ToString(Session["TestReportID_PeriodicIndustryLift"]);
            DataTable ds = CEI.GetDocumentOfLiftRenewalToShow_PeriodicIndustryLift(TReportID);
            if (ds != null && ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert('No Record Found for document');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                string fileName = "";
                try
                {
                    if (e.CommandName == "Select")
                    {
                        //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                { }
            }
        }
        private void GetDetails_AtOfficerEnd()
        {
            if (Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"]) != null && Convert.ToString(Session["RegistrationNo_PeriodicIndustryLift"]) != "")
            {
                string Id = Session["RegistrationNo_PeriodicIndustryLift"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd_PeriodicIndustryLift(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtInstallationFor.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    //txtagency.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                }
            }
            //else if ((Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty) && !string.IsNullOrEmpty(Convert.ToString(Session["RegistrationNo"])))
            //{

            //}
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                string previousPageUrl = Session["PreviousPage_PeriodicIndustryLift"] as string;
                if (!string.IsNullOrEmpty(previousPageUrl))
                {
                    Response.Redirect(previousPageUrl, false);
                    //Response.Redirect("/SiteOwnerPages/LiftPeriodic.aspx", false);
                    Session["PreviousPage_PeriodicIndustryLift"] = null;
                }
            }
            catch { }
        }
    }
}