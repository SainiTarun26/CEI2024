using CEI_PRoject;
using CEIHaryana.UserPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Supervisor
{
    public partial class Supervisor_Licence_Upgradation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = (MasterPage)Master;
                var loginTypeLabel = (Label)master.FindControl("LoginType");
                if (loginTypeLabel != null)
                {
                    loginTypeLabel.Text = "Supervisor / Upgradation Application";
                }

                if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    string ID = Convert.ToString(Session["SupervisorID"]);
                    GetSupervisorDetails(ID);
                    ddlLoadBindVoltage();
                    ddlQualificationBind();
                }
            }
        }

        private void ddlQualificationBind()
        {
            DataSet dsQualification = new DataSet();
            dsQualification = CEI.GetQualification();
            ddlQualification.DataSource = dsQualification;
            ddlQualification.DataTextField = "Qualificaton";
            ddlQualification.DataValueField = "QualificationValue";
            ddlQualification.DataBind();
            ddlQualification.Items.Insert(0, new ListItem("Select", "0"));
            dsQualification.Clear();
        }

        private void ddlLoadBindVoltage()
        {
            try
            {
                DataSet dsVoltage = new DataSet();
                dsVoltage = CEI.GetddlVoltageLevel();
                ddlVoltageLevel.DataSource = dsVoltage;
                ddlVoltageLevel.DataTextField = "Voltagelevel";
                ddlVoltageLevel.DataValueField = "VoltageID";
                ddlVoltageLevel.DataBind();
                ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
                dsVoltage.Clear();

            }
            catch (Exception)
            {

            }
        }

        private void GetSupervisorDetails(string ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetSuperviserForUpgradation(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtSupervisorName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtOldCertificateNo.Text = ds.Tables[0].Rows[0]["CertificateOld"].ToString();
                    txtNewCertificateNo.Text = ds.Tables[0].Rows[0]["CertificateNew"].ToString();
                    txtIssueDate.Text = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
                    txtPresentScope.Text = ds.Tables[0].Rows[0]["votagelevel"].ToString(); //Existing voltage level
                    txtAddress.Text = ds.Tables[0].Rows[0]["FullAddress"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void rblbelated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblbelated.SelectedValue == "1")  //Yes
                {
                    InterviewDate.Visible = true;
                }
                else if (rblbelated.SelectedValue == "0")
                {
                    InterviewDate.Visible = false;
                    txtInterviewDate.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedItem.ToString() == "Other")
            {
                txtQualification.Visible = true;
            }
            else
            {
                txtQualification.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userId = Session["SupervisorID"].ToString();
                string baseFolder = Server.MapPath("~/Attachment/LicenceUpgadation/Supervisor/" + userId + "/");

                // Create directory if not exists
                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }

                string dbPathCompetency = "";
                string dbPathExperience = "";

                // ==== Certificate of Competency ====
                if (FileUpload2.HasFile)
                {
                    if (Path.GetExtension(FileUpload2.FileName).ToLower() == ".pdf")
                    {
                        if (FileUpload2.PostedFile.ContentLength <= 1048576) // 1 MB
                        {
                            string fileName = "Competency_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                            string savePath = Path.Combine(baseFolder, fileName);
                            FileUpload2.PostedFile.SaveAs(savePath);

                            dbPathCompetency = "/Attachment/LicenceUpgadation/Supervisor/" + userId + "/" + fileName;
                        }
                        else
                        {
                            throw new Exception("Competency Certificate must be less than 1 MB.");
                        }
                    }
                    else
                    {
                        throw new Exception("Only PDF files are allowed for Competency Certificate.");
                    }
                }

                // ==== Certificate of Experience ====
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".pdf")
                    {
                        if (FileUpload1.PostedFile.ContentLength <= 1048576) // 1 MB
                        {
                            string fileName = "Experience_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                            string savePath = Path.Combine(baseFolder, fileName);
                            FileUpload1.PostedFile.SaveAs(savePath);

                            dbPathExperience = "/Attachment/LicenceUpgadation/Supervisor/" + userId + "/" + fileName;
                        }
                        else
                        {
                            throw new Exception("Experience Certificate must be less than 1 MB.");
                        }
                    }
                    else
                    {
                        throw new Exception("Only PDF files are allowed for Experience Certificate.");
                    }
                }

                string Qualification = "";
                if (txtQualification.Visible == true)
                {
                    Qualification = txtQualification.Text;
                }
                else
                {
                    Qualification = ddlQualification.SelectedItem.Text;

                }

                string SupervisorName = txtSupervisorName.Text.Trim();
                string NewCertificateNo = txtNewCertificateNo.Text.Trim();
                string OldCertificateNo = txtOldCertificateNo.Text.Trim();
                string IssueDate = txtIssueDate.Text.Trim();
                string PresentScope = txtPresentScope.Text.Trim();
                string Academic = txtAcademic.Text.Trim();
                string professional = txtProfessional.Text.Trim();
                string experience = txtExperience.Text.Trim();
                string address = txtAddress.Text.Trim();
                string State = txtState.Text.Trim();
                string District = txtDistrict.Text.Trim();
                string Pin = txtPin.Text.Trim();
                string UpgradationAppliedErlier = rblbelated.SelectedItem.Text;
                string InterviewDate = txtInterviewDate.Text.Trim();
                string Voltage = ddlVoltageLevel.SelectedValue.Trim();
                int result = CEI.UpgradationOfSupervisorData(SupervisorName, NewCertificateNo, OldCertificateNo, IssueDate, PresentScope,
                                                             Qualification, Academic, professional, experience, address,
                                                             State, District, Pin, UpgradationAppliedErlier, txtInterviewDate.Text.Trim(), Voltage, dbPathExperience,
                                                             dbPathCompetency, userId);

                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents saved successfully!');", true);
                    ReSet();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error while saving documents.');", true);
                }
            }
        }

        private void ReSet()
        {
            txtQualification.Text = "";
            txtAcademic.Text = "";
            txtProfessional.Text = "";
            txtExperience.Text = "";
            txtInterviewDate.Text = "";
            ddlQualification.ClearSelection();
            ddlVoltageLevel.ClearSelection();

            rblbelated.ClearSelection();
        }
    }
}