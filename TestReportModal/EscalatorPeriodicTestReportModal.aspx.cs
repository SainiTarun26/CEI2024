using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.TestReportModal
{
    public partial class EscalatorPeriodicTestReportModal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string siteOwnerId = Convert.ToString(Session["SiteOwnerId"]);
                    string registrationNo = Convert.ToString(Session["RegistrationNo"]);
                    string TestReportID = Convert.ToString(Session["TestReportID"]);
                    if (Request.UrlReferrer != null)
                    {
                        Session["PreviousPage"] = Request.UrlReferrer.ToString();
                    }
                    if (!string.IsNullOrEmpty(siteOwnerId) && !string.IsNullOrEmpty(registrationNo) && !string.IsNullOrEmpty(TestReportID))
                    {
                        GetData();
                        GetDetails();
                    }
                    else if ((Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty) && !string.IsNullOrEmpty(Convert.ToString(Session["RegistrationNo"])) && !string.IsNullOrEmpty(Convert.ToString(Session["TestReportID"])))
                    {
                        GetData();
                        GetDetails_AtOfficerEnd();
                    }
                    else
                    {
                        Response.Redirect("/login.aspx", false);
                    }
                }
            }
            catch (Exception Ex)
            { }
        }

        private void GetDetails()
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                string Id = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSiteOwnerDataInPeriodicOfLift(Id);
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
            else
            {
                Response.Redirect("/login.aspx", false);
            }
        }

        private void GetData()
        {
            try
            {
                if (Convert.ToString(Session["RegistrationNo"]) != null && Convert.ToString(Session["RegistrationNo"]) != "")
                {
                    string RegistrationNo = Session["RegistrationNo"].ToString();
                    string TRId = Session["TestReportID"].ToString();
                    DataSet ds = CEI.GetDetailsOfLiftRenewalReport(RegistrationNo, TRId);
                    
                    txtPrevChallanDate.Text = ds.Tables[0].Rows[0]["PreviousChallanDate"].ToString();
                    txtLastApprovalDate.Text = ds.Tables[0].Rows[0]["LastApprovalDate"].ToString();
                    txtDateofErection.Text = ds.Tables[0].Rows[0]["ErectionDate"].ToString();
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                    txtControlType.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                    txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    txtDistrictOfTr.Text = ds.Tables[0].Rows[0]["ApplicantDistrict"].ToString();
                    txtEscalatorType.Text = ds.Tables[0].Rows[0]["TypeOfLift"].ToString();
                    Session["File"] = ds.Tables[0].Rows[0]["PreviousChallanUpload"].ToString();

                    txtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                    txtMemoDate.Text = ds.Tables[0].Rows[0]["MemoDate"].ToString();

                    GridDocument();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridDocument()
        {
            string RegistrationNo = Session["RegistrationNo"].ToString();
            string TReportID = Convert.ToString(Session["TestReportID"]);
            DataTable ds = CEI.GetDocumentOfLiftRenewalToShow(TReportID);
            //DataTable ds = CEI.GetDocumentOfLiftRenewalToShow(RegistrationNo);
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
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["File"] != null && Session["File"].ToString() != "")
                {
                    string fileName = Session["File"].ToString();

                    string filePath = fileName.Replace("~", "");
                    filePath = "https://uat.ceiharyana.com" + filePath;

                    string script = $@"<script>window.open('{filePath}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", $"alert('Error: {ex.Message}');", true);
            }
        }

        private void GetDetails_AtOfficerEnd()
        {
            if (Convert.ToString(Session["RegistrationNo"]) != null && Convert.ToString(Session["RegistrationNo"]) != "")
            {
                string Id = Session["RegistrationNo"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSiteOwnerDataInPeriodicOfLift_AtOfficerEnd(Id);
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
                Response.Redirect("/login.aspx", false);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                string previousPageUrl = Session["PreviousPage"] as string;
                if (!string.IsNullOrEmpty(previousPageUrl))
                {
                    Response.Redirect(previousPageUrl, false);
                    // Response.Redirect("/SiteOwnerPages/LiftPeriodic.aspx", false);
                    Session["PreviousPage"] = null;
                }
            }
            catch { }
        }
    }
}