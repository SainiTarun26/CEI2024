using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class EscalatorDetails_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Email = string.Empty;
        string OTPs = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateSetting();
                    ddlEarthing();
                    txtapplication.Text = Session["Application_IndustryLift"].ToString().Trim();
                    txtInstallation.Text = Session["Typs_IndustryLift"].ToString().Trim();
                    //txtid.Text = Session["Intimations"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations_IndustryLift"].ToString().Trim() + " Out of " + Session["TotalInstallation_IndustryLift"].ToString().Trim();
                    BtnBack.Visible = true;
                    GetContractorDetails();
                    GetDocumentforlift();
                }
                GetDocumentforlift();
                BtnBack.Visible = true;
            }
            catch
            {

            }

        }
        public void DateSetting()
        {
            DateTime today = DateTime.Today;

            // Calculate the minimum date (20 years before today)
            DateTime minDate = today.AddYears(-20);

            // Set the min and max attributes for the date input
            txtErectionDate.Attributes["min"] = minDate.ToString("yyyy-MM-dd");
            txtErectionDate.Attributes["max"] = today.ToString("yyyy-MM-dd");
        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();

                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GetDocumentforlift()
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentforlift_IndustryLift("Escalator");
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }


        private void GetContractorDetails()
        {

            DataSet dsContractor = new DataSet();
            dsContractor = CEI.GetContractorDataForLiftEscalator();
            ddlContName.DataSource = dsContractor;
            ddlContName.DataTextField = "ContractorData";
            ddlContName.DataValueField = "LicenseValue";
            ddlContName.DataBind();
            ddlContName.Items.Insert(0, new ListItem("Select", "0"));
            dsContractor.Clear();

        }
        private void GetSupervisorDetails(string value)
        {

            DataSet dsSupervisor = new DataSet();
            dsSupervisor = CEI.GetSupervisorDataatSiteOwner(value);
            ddlLicenseNo.DataSource = dsSupervisor;
            ddlLicenseNo.DataTextField = "SupervisorData";
            ddlLicenseNo.DataValueField = "LicenseValue";
            ddlLicenseNo.DataBind();
            ddlLicenseNo.Items.Insert(0, new ListItem("Select", "0"));
            dsSupervisor.Clear();

        }
        private void ddlEarthing()
        {
            try
            {
                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthing();
                if (dsEarthing.Tables[0].Rows.Count > 10)
                {
                    // Take only the first 10 rows
                    DataTable dtTop10 = dsEarthing.Tables[0].AsEnumerable().Take(10).CopyToDataTable();
                    ddlNoOfEarthing.DataSource = dtTop10;
                }
                else
                {
                    ddlNoOfEarthing.DataSource = dsEarthing;
                }
                ddlNoOfEarthing.DataTextField = "Numbers";
                ddlNoOfEarthing.DataValueField = "Id";
                ddlNoOfEarthing.DataBind();
                ddlNoOfEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;

            // Store the Earthingtype controls in an array for easier manipulation
            Control[] earthingTypes = { Earthingtype1, Earthingtype2, Earthingtype3, Earthingtype4,
                                Earthingtype5, Earthingtype6, Earthingtype7, Earthingtype8,
                                Earthingtype9, Earthingtype10 };

            // First, hide all controls
            foreach (var earthingType in earthingTypes)
            {
                earthingType.Visible = false;
            }

            // Get the selected number of earthing types
            int numberOfEarthing = int.Parse(ddlNoOfEarthing.SelectedValue.Trim());

            // Show only the selected number of earthing types
            for (int i = 0; i < numberOfEarthing; i++)
            {
                earthingTypes[i].Visible = true;
            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateSetting();
            if (RadioButtonList2.SelectedValue == "1")
            {
                Name.Visible = true;
                Address.Visible = true;
                Contact.Visible = true;
            }
            else
            {
                Name.Visible = false;
                Address.Visible = false;
                Contact.Visible = false;

            }
        }
        public void UploadCheckListDocInCollection(string intimationids, string InstallTypeCount)
        {
            foreach (GridViewRow row in Grd_Document.Rows)
            {
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                Label DocSaveName = (Label)row.FindControl("LblDocumentName");
                Label DocumentID = (Label)row.FindControl("LblDocumentID");
                //string DocName = row.Cells[1].Text.Replace("\r\n", "");
                string CreatedBy = Session["SiteOwnerId_IndustryLift"].ToString();
                string InstallTypes = "Escalator";

                if (fileUpload.HasFile)
                {
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")


                    {

                        if (fileUpload.PostedFile.ContentLength <= 1048576)
                        {
                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/"));
                            }

                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/";
                            //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            //string fileName = DocSaveName + "." + ext;
                            string fileName = DocSaveName.Text.Trim() + ".pdf";

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/" + fileName);

                            fileUpload.PostedFile.SaveAs(filePathInfo2);
                            CEI.InsertNewLiftAttachments_IndustryLift(InstallTypes, DocumentID.Text, DocSaveName.Text.Trim(), fileName, path + fileName, CreatedBy);

                        }
                        else
                        {
                            throw new Exception("Please Upload Pdf Files Less Than 1 Mb Only");
                        }
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files Only");
                    }
                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Check.Checked == true)
            {
                try
                {
                    if (Page.IsValid)
                    {
                        btnSubmit.Attributes.Add("onclick", "this.disabled = true;");
                        string IntimationId = Session["id_IndustryLift"].ToString();
                        string CreatedBy = Session["SiteOwnerId_IndustryLift"].ToString();
                        string count = Session["NoOfInstallations_IndustryLift"].ToString();
                        string installationNo = Session["IHID_IndustryLift"].ToString();

                        if (txtNeutralPhase.Text == "")
                        {
                            txtNeutralPhase.Text = "0";
                            txtEarthPhase.Text = "0";
                        }
                        else
                        {

                        }
                        // Helper function to safely parse decimal fields
                        decimal ParseOrDefault(string input, decimal defaultValue = 0)
                        {
                            return decimal.TryParse(input, out decimal result) ? result : defaultValue;
                        }
                        int ParseintOrDefault(string input, int defaultValue = 0)
                        {
                            return int.TryParse(input, out int result) ? result : defaultValue;
                        }
                        bool allFilesArePDF = true;
                        foreach (GridViewRow row in Grd_Document.Rows)
                        {
                            FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();

                            if (fileExtension != ".pdf" || fileUpload == null)
                            {
                                allFilesArePDF = false;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please upload all the PDF files Correctly');", true);

                            }

                        }
                        if (allFilesArePDF == true)
                        {
                            if (Session["Expired_IndustryLift"].ToString() == "False")
                            {
                                if (Session["ReturnedValue_IndustryLift"].ToString() != "1")
                                {
                                    CEI.InsertNewEscalatorData_New_IndustryLift(
                                    count, IntimationId, RadioButtonList2.SelectedItem.Text, TxtAgentName.Text, txtAgentAddress.Text,
                                    txtAgentPhone.Text, DateTime.Parse(txtErectionDate.Text), txtMake.Text, txtSerialNo.Text, ddlEscalatorType.SelectedItem.ToString(), txtEscalatorSpeedContract.Text,
                                    ParseOrDefault(txtEscalatorLoad.Text), txtMaxPersonCapacity.Text, ParseOrDefault(txtWeight.Text), ParseOrDefault(txtCounterWeight.Text),
                                    ParseOrDefault(txtPitDepth.Text), ParseOrDefault(txtTravelDistance.Text), ParseOrDefault(txtFloorsServed.Text),
                                    ParseOrDefault(txtTotalHeadRoom.Text), txtTypeofControll.Text, txtMakeMainBreaker.Text, txtTypeMainBreaker.Text,
                                    ddlPoleMainBreaker.SelectedItem.ToString(), txtratingMainBreaker.Text,
                                    txtCapacityMainBreaker.Text, txtMakeRCCBMainBreaker.Text, ddlPolesRCCBMainBreaker.SelectedItem.ToString(),
                                    txtRatingRCCBMainBreaker.Text, txtfaultratingRCCBMainBreaker.Text, txtMakeLoadBreaker.Text, txtTypeLoadBreaker.Text,
                                    ddlPolesLoadBreaker.SelectedItem.ToString(), txtRatingLoadBreaker.Text, txtCapacityLoadBreaker.Text, txtMakeRCCBLoadBreaker.Text,
                                    ddlpolesRCCBLoadBreaker.SelectedItem.ToString(), txtRatingRCCBLoadBreaker.Text, txtFaultCurrentRCCBLoadBreaker.Text,
                                    txtwholeInstallation.Text, txtNeutralPhase.Text, txtEarthPhase.Text, ParseintOrDefault(txtRedYellow.Text),
                                    ParseintOrDefault(txtRedBlue.Text), ParseintOrDefault(txtYellowBlue.Text),
                                    ParseintOrDefault(txtRedEarth.Text), ParseintOrDefault(txtYellowEarth.Text),
                                     ParseintOrDefault(txtBlueEarth.Text), ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), ParseOrDefault(txtearthingValue1.Text),
                                    ddlEarthingtype2.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue2.Text), ddlEarthingtype3.SelectedItem.ToString(),
                                    ParseOrDefault(txtEarthingValue3.Text), ddlEarthingtype4.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue4.Text),
                                    ddlEarthingtype5.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue5.Text), ddlEarthingtype6.SelectedItem.ToString(),
                                    ParseOrDefault(txtEarthingValue6.Text), ddlEarthingtype7.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue7.Text),
                                    ddlEarthingtype8.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue8.Text), ddlEarthingtype9.SelectedItem.ToString(),
                                    ParseOrDefault(txtEarthingValue9.Text), ddlEarthingtype10.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue10.Text),
                                    CreatedBy, ddlContName.SelectedItem.ToString(), txtContName.Text, DateTime.Parse(txtContExp.Text), ddlLicenseNo.SelectedItem.ToString(),
                                    txtSupLicenseNo.Text, DateTime.Parse(txtSupExpiryDate.Text)
                                );
                                    //CEI.UpdateLiftTestReportHistory_IndustryLift("Escalator", IntimationId, count, CreatedBy);
                                    //CEI.UpdateInstallations_IndustryLift(installationNo, IntimationId);
                                    UploadCheckListDocInCollection(IntimationId, count);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                                }
                                else
                                {
                                    string TestReportId = Session["EscalatorTestReportID_IndustryLift"].ToString();

                                    CEI.InsertReturnEscalatorData_New_IndustryLift(TestReportId,
                                count, IntimationId, RadioButtonList2.SelectedItem.Text, TxtAgentName.Text, txtAgentAddress.Text,
                                txtAgentPhone.Text, DateTime.Parse(txtErectionDate.Text), txtMake.Text, txtSerialNo.Text, ddlEscalatorType.SelectedItem.ToString(), txtEscalatorSpeedContract.Text,
                                ParseOrDefault(txtEscalatorLoad.Text), txtMaxPersonCapacity.Text, ParseOrDefault(txtWeight.Text), ParseOrDefault(txtCounterWeight.Text),
                                ParseOrDefault(txtPitDepth.Text), ParseOrDefault(txtTravelDistance.Text), ParseOrDefault(txtFloorsServed.Text),
                                ParseOrDefault(txtTotalHeadRoom.Text), txtTypeofControll.Text, txtMakeMainBreaker.Text, txtTypeMainBreaker.Text,
                                ddlPoleMainBreaker.SelectedItem.ToString(), txtratingMainBreaker.Text,
                                txtCapacityMainBreaker.Text, txtMakeRCCBMainBreaker.Text, ddlPolesRCCBMainBreaker.SelectedItem.ToString(),
                                txtRatingRCCBMainBreaker.Text, txtfaultratingRCCBMainBreaker.Text, txtMakeLoadBreaker.Text, txtTypeLoadBreaker.Text,
                                ddlPolesLoadBreaker.SelectedItem.ToString(), txtRatingLoadBreaker.Text, txtCapacityLoadBreaker.Text, txtMakeRCCBLoadBreaker.Text,
                                ddlpolesRCCBLoadBreaker.SelectedItem.ToString(), txtRatingRCCBLoadBreaker.Text, txtFaultCurrentRCCBLoadBreaker.Text,
                                txtwholeInstallation.Text, txtNeutralPhase.Text, txtEarthPhase.Text, ParseintOrDefault(txtRedYellow.Text),
                                ParseintOrDefault(txtRedBlue.Text), ParseintOrDefault(txtYellowBlue.Text),
                                ParseintOrDefault(txtRedEarth.Text), ParseintOrDefault(txtYellowEarth.Text),
                                 ParseintOrDefault(txtBlueEarth.Text), ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), ParseOrDefault(txtearthingValue1.Text),
                                ddlEarthingtype2.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue2.Text), ddlEarthingtype3.SelectedItem.ToString(),
                                ParseOrDefault(txtEarthingValue3.Text), ddlEarthingtype4.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue4.Text),
                                ddlEarthingtype5.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue5.Text), ddlEarthingtype6.SelectedItem.ToString(),
                                ParseOrDefault(txtEarthingValue6.Text), ddlEarthingtype7.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue7.Text),
                                ddlEarthingtype8.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue8.Text), ddlEarthingtype9.SelectedItem.ToString(),
                                ParseOrDefault(txtEarthingValue9.Text), ddlEarthingtype10.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue10.Text),
                                CreatedBy, ddlContName.SelectedItem.ToString(), txtContName.Text, DateTime.Parse(txtContExp.Text), ddlLicenseNo.SelectedItem.ToString(),
                                txtSupLicenseNo.Text, DateTime.Parse(txtSupExpiryDate.Text));
                                    CEI.UpdateReturnLiftInspection_IndustryLift(TestReportId);
                                    UploadCheckListDocInCollection(IntimationId, count);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithReturnRedirectdata();", true); //Response.Redirect("/Supervisor/TestReportHistory.aspx", false);


                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Sorry Your License Is Expired Please Contact Admin For saving This Information');", true);

                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        string message = "Please fill form Correctly";
                        throw new Exception(message);
                    }

                }
                catch (Exception ex)
                {



                    string script = ex.Message + "alert(\"Please Fill Form Correctly\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please Check declaration first');", true);

            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiftInstallationDetails_IndustryLift.aspx", false);
        }
        protected void ddlContName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            dta = CEI.GetEmailContractor(ddlContName.SelectedValue.ToString());
            Email = dta.Rows[0]["Email"].ToString();
            Session["ContractorEmail_IndustryLift"] = Email.Trim();


            DataSet dt = new DataSet();
            dt = CEI.GetSupervisorandContractor("Contractor", ddlContName.SelectedValue.ToString());
            if (dt.Tables.Count > 0)
            {
                //txtContName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                txtContExp.Text = dt.Tables[0].Rows[0]["ExpiryDate"].ToString();
                txtContName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                if (DateTime.TryParse(txtContExp.Text, out DateTime expiryDate)) // Parse the expiry date
                {
                    Session["Expired_IndustryLift"] = "true";
                    txtContExp.Text = expiryDate.ToString("yyyy-MM-dd"); // Set formatted date to TextBox

                    if (expiryDate <= DateTime.Now) // Compare with the current date
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Your License Is Expired Please Contact Admin');", true);
                    }
                    else
                    {
                        Session["Expired_IndustryLift"] = "False";
                    }

                }


            }
            else
            {

            }
            GetSupervisorDetails(ddlContName.SelectedValue);

        }
        protected void ddlLicenseNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt = CEI.GetSupervisorandContractor("Supervisor", ddlLicenseNo.SelectedValue.ToString());
            if (dt.Tables[0].Rows.Count > 0)
            {
                //txtSupName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                txtSupExpiryDate.Text = dt.Tables[0].Rows[0]["DateofExpiry"].ToString();
                txtSupLicenseNo.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                if (DateTime.TryParse(txtSupExpiryDate.Text, out DateTime expiryDate)) // Parse the expiry date
                {
                    Session["Expired_IndustryLift"] = "true";
                    txtSupExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd"); // Set formatted date to TextBox

                    if (expiryDate <= DateTime.Now) // Compare with the current date
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Your License Is Expired Please Contact Admin');", true);
                    }
                    else
                    {
                        Session["Expired_IndustryLift"] = "False";
                    }

                }

            }
            else
            {

            }
        }
        protected void ddlPoleMainBreaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPoleMainBreaker.SelectedValue == "1")
            {
                InDPO.Visible = false;
                Heading.Visible = false;
                TPN1.Visible = true;
                TPN2.Visible = true;
            }
            else
            {
                InDPO.Visible = true;
                TPN1.Visible = false;
                TPN2.Visible = false;
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            OTP.Visible = true;
            btnVerify.Text = "Verify";
            btnResend.Visible = true;
            if (Session["OTP_IndustryLift"].ToString() == txtOTP.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusGridView", "focusOnGridView();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusOTP", "document.getElementById('" + txtOTP.ClientID + "').focus();", true);

            }
            if (Session["OTP_IndustryLift"].ToString() == "0")
            {

                Email = Session["ContractorEmail_IndustryLift"].ToString();
                OTPs = CEI.ValidateOTPthroughEmail(Email);
                Session["OTP_IndustryLift"] = OTPs.Trim();
                // ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Enter the OTP you received to Your Contractor's Email');", true);
            }
            //else if (Session["ContractorEmail_IndustryLift"].ToString() == "OTPSEND")
            //{
            //    OTP.Visible = true;
            //    btnVerify.Text = "Verify";
            //    btnResend.Visible = true;
            //    Session["ContractorEmail_IndustryLift"] = "";
            //}
            else
            {
                if (Session["OTP_IndustryLift"].ToString() == txtOTP.Text.Trim())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Otp Verified Successfully');", true);
                    OTP.Visible = false;
                    btnVerify.Visible = false;
                    btnSubmit.Visible = true;
                    Attachments.Visible = true;
                    CheckDeclaration.Visible = true;
                    btnResend.Visible = false;
                    ddlContName.Enabled = false;
                    ddlLicenseNo.Enabled = false;
                }
                else if (txtOTP.Text != "" && txtOTP.Text != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Incorrect Otp Please Try Again');", true);

                }
                else
                {
                    
                }
            }
        }

        protected void btnResend_Click(object sender, EventArgs e)
        {
            if (Session["OTP_IndustryLift"].ToString() == txtOTP.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusGridView", "focusOnGridView();", true);
                // ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Enter the OTP you received to Your Contractor's Email');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusOTP", "document.getElementById('" + txtOTP.ClientID + "').focus();", true);

            }
            if (Session["ContractorEmail_IndustryLift"].ToString() != "")
            {

                OTP.Visible = true;
                btnVerify.Text = "Verify";
                Email = Session["ContractorEmail_IndustryLift"].ToString();
                OTPs = CEI.ValidateOTPthroughEmail(Email);
                Session["OTP_IndustryLift"] = OTPs.Trim();
                // Session["ContractorEmail"] = "";

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert(' Otp Sent Successfully');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please click on Verify Button For Verification');", true);



            }

        }
    }
}