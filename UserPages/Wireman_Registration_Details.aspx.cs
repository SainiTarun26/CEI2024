using CEI_PRoject;
using CEIHaryana.Supervisor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Wireman_Registration_Details : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.UrlReferrer != null)
                    {
                        Session["PreviousPage"] = Request.UrlReferrer.ToString();
                    }


                    if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        string WiremanId = Convert.ToString(Session["WiremanId"]);
                        GetUserDetails(WiremanId);

                        hdnId.Value = Session["WiremanId"].ToString();

                        GetEducationData(WiremanId);
                        getcertificateofcompetencyDetails(WiremanId);
                        PermanentEmployed(WiremanId);
                        getExperienceDetail(WiremanId);
                        RetiredEngineer(WiremanId);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('An error Occurred');", true);
                        Response.Redirect("/UserPages/Documents.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void RetiredEngineer(string wiremanId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(wiremanId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string isRetired = dt.Rows[0]["RetiredEngineer"].ToString().Trim();

                    if (isRetired == "Yes")
                    {
                        RetiredEmployee.Visible = true;
                        //RadioButtonList1.Enabled = false;
                        //RadioButtonList1.SelectedValue = "0";
                        txtRadioButtonList1.Text = dt.Rows[0]["RetiredEngineer"].ToString().Trim();

                        txtEmployerName2.Text = dt.Rows[0]["RetiredEmployerName"].ToString();
                        txtDescription2.Text = dt.Rows[0]["RetiredPostDescription"].ToString();

                        if (DateTime.TryParse(dt.Rows[0]["RetiredFromDate"].ToString(), out DateTime issueDate))
                        {
                            txtFrom2.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["RetiredToDate"].ToString(), out DateTime expiryDate))
                        {
                            txtTo2.Text = expiryDate.ToString("yyyy-MM-dd");
                        }

                    }
                    else
                    {
                        RetiredEmployee.Visible = false;
                        txtRadioButtonList1.Text = dt.Rows[0]["RetiredEngineer"].ToString().Trim();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void getExperienceDetail(string wiremanId)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(wiremanId);


                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticePostDescription"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticenameofEmployer"].ToString()))
                    {

                        txtApprenticeship.Text = dt.Rows[0]["ApprenticeExperience"].ToString();
                        txtAppretinceExperience.Text = dt.Rows[0]["ApprenticeTrainingUnder"].ToString();
                        txtApprenticeshipEmployer.Text = dt.Rows[0]["ApprenticenameofEmployer"].ToString();
                        txtApprenticesPost.Text = dt.Rows[0]["ApprenticePostDescription"].ToString();

                        if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceFromDate"].ToString(), out DateTime apprenticeFrom))
                        {
                            Apprenticesdatefrom.Text = apprenticeFrom.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceToDate"].ToString(), out DateTime apprenticeTo))
                        {
                            Apprenticesdateto.Text = apprenticeTo.ToString("yyyy-MM-dd");
                        }

                        TrApprenticeship.Visible = true;
                    }
                    else
                    {
                        TrApprenticeship.Visible = false;
                    }



                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencePostDescription"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName"].ToString()))
                    {

                        var experienceText = dt.Rows[0]["ExperiencedIn"].ToString().Trim();
                        //var item = ddlExperience.Items.FindByText(experienceText);
                        //if (item != null)
                        //    ddlExperience.SelectedValue = item.Value;

                        txtExperience.Text = dt.Rows[0]["ExperiencedIn"].ToString();

                        txtTrainingUnder.Text = dt.Rows[0]["TrainingUnder"].ToString();
                        //var trainingItem = ddlTrainingUnder.Items.FindByText(dt.Rows[0]["TrainingUnder"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder.SelectedValue = trainingItem.Value;

                        txtExperienceEmployer.Text = dt.Rows[0]["ExperienceEmployerName"].ToString();
                        txtPostDescription.Text = dt.Rows[0]["ExperiencePostDescription"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo.Text = expiryDate.ToString("yyyy-MM-dd");
                        }

                        Experience.Visible = true;
                    }
                    else { Experience.Visible = false; }



                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn1"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName1"].ToString()))
                    {
                        //var experienceItem = ddlExperience1.Items.FindByText(dt.Rows[0]["ExperiencedIn1"].ToString());
                        //if (experienceItem != null) ddlExperience1.SelectedValue = experienceItem.Value;



                        //var trainingItem = ddlTrainingUnder1.Items.FindByText(dt.Rows[0]["TrainingUnder1"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder1.SelectedValue = trainingItem.Value;

                        txtExperience1.Text = dt.Rows[0]["ExperiencedIn1"].ToString();

                        txtTrainingUnder1.Text = dt.Rows[0]["TrainingUnder1"].ToString();

                        txtExperienceEmployer1.Text = dt.Rows[0]["ExperienceEmployerName1"].ToString();
                        txtPostDescription1.Text = dt.Rows[0]["ExperiencePostDescription1"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate1"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom1.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate1"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo1.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience1.Visible = true;
                    }
                    else { Experience1.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn2"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName2"].ToString()))
                    {
                        //var experienceItem = ddlExperience2.Items.FindByText(dt.Rows[0]["ExperiencedIn2"].ToString());
                        //if (experienceItem != null) ddlExperience2.SelectedValue = experienceItem.Value;

                        //var trainingItem = ddlTrainingUnder2.Items.FindByText(dt.Rows[0]["TrainingUnder2"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder2.SelectedValue = trainingItem.Value;

                        txtExperience2.Text = dt.Rows[0]["ExperiencedIn2"].ToString();
                        txtTrainingUnder2.Text = dt.Rows[0]["TrainingUnder2"].ToString();

                        txtExperienceEmployer2.Text = dt.Rows[0]["ExperienceEmployerName2"].ToString();
                        txtPostDescription2.Text = dt.Rows[0]["ExperiencePostDescription2"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate2"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom2.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate2"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo2.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience2.Visible = true;
                    }
                    else { Experience2.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn3"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName3"].ToString()))
                    {
                        //var experienceItem = ddlExperience3.Items.FindByText(dt.Rows[0]["ExperiencedIn3"].ToString());
                        //if (experienceItem != null) ddlExperience3.SelectedValue = experienceItem.Value;
                        txtExperience3.Text = dt.Rows[0]["ExperiencedIn3"].ToString();
                        txtTrainingUnder3.Text = dt.Rows[0]["TrainingUnder3"].ToString();

                        //var trainingItem = ddlTrainingUnder3.Items.FindByText(dt.Rows[0]["TrainingUnder3"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder3.SelectedValue = trainingItem.Value;
                        txtExperienceEmployer3.Text = dt.Rows[0]["ExperienceEmployerName3"].ToString();
                        txtPostDescription3.Text = dt.Rows[0]["ExperiencePostDescription3"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate3"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom3.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate3"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo3.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience3.Visible = true;
                    }
                    else { Experience3.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn4"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName4"].ToString()))
                    {
                        //var experienceItem = ddlExperience4.Items.FindByText(dt.Rows[0]["ExperiencedIn4"].ToString());
                        //if (experienceItem != null) ddlExperience4.SelectedValue = experienceItem.Value;
                        txtExperience4.Text = dt.Rows[0]["ExperiencedIn4"].ToString();

                        //var trainingItem = ddlTrainingUnder4.Items.FindByText(dt.Rows[0]["TrainingUnder4"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder4.SelectedValue = trainingItem.Value;
                        txtTrainingUnder4.Text = dt.Rows[0]["TrainingUnder4"].ToString();

                        txtExperienceEmployer4.Text = dt.Rows[0]["ExperienceEmployerName4"].ToString();
                        txtPostDescription4.Text = dt.Rows[0]["ExperiencePostDescription4"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate4"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom4.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate4"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo4.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience4.Visible = true;
                    }
                    else { Experience4.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn5"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName5"].ToString()))
                    {
                        //var experienceItem = ddlExperience5.Items.FindByText(dt.Rows[0]["ExperiencedIn5"].ToString());
                        //if (experienceItem != null) ddlExperience5.SelectedValue = experienceItem.Value;
                        txtExperience5.Text = dt.Rows[0]["ExperiencedIn5"].ToString();

                        //var trainingItem = ddlTrainingUnder5.Items.FindByText(dt.Rows[0]["TrainingUnder5"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder5.SelectedValue = trainingItem.Value;
                        txtTrainingUnder5.Text = dt.Rows[0]["TrainingUnder5"].ToString();

                        txtExperienceEmployer5.Text = dt.Rows[0]["ExperienceEmployerName5"].ToString();
                        txtPostDescription5.Text = dt.Rows[0]["ExperiencePostDescription5"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate5"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom5.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate5"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo5.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience5.Visible = true;
                    }
                    else { Experience5.Visible = false; }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn6"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName6"].ToString()))
                    {
                        //var experienceItem = ddlExperience6.Items.FindByText(dt.Rows[0]["ExperiencedIn6"].ToString());
                        //if (experienceItem != null) ddlExperience6.SelectedValue = experienceItem.Value;

                        txtExperience6.Text = dt.Rows[0]["ExperiencedIn6"].ToString();
                        //var trainingItem = ddlTrainingUnder6.Items.FindByText(dt.Rows[0]["TrainingUnder6"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder6.SelectedValue = trainingItem.Value;
                        txtTrainingUnder6.Text = dt.Rows[0]["TrainingUnder6"].ToString();

                        txtExperienceEmployer6.Text = dt.Rows[0]["ExperienceEmployerName6"].ToString();
                        txtPostDescription6.Text = dt.Rows[0]["ExperiencePostDescription6"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate6"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom6.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate6"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo6.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience6.Visible = true;
                    }
                    else { Experience6.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn7"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName7"].ToString()))
                    {
                        //var experienceItem = ddlExperience7.Items.FindByText(dt.Rows[0]["ExperiencedIn7"].ToString());
                        //if (experienceItem != null) ddlExperience7.SelectedValue = experienceItem.Value;
                        txtExperience7.Text = dt.Rows[0]["ExperiencedIn7"].ToString();

                        //var trainingItem = ddlTrainingUnder7.Items.FindByText(dt.Rows[0]["TrainingUnder7"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder7.SelectedValue = trainingItem.Value;
                        txtTrainingUnder7.Text = dt.Rows[0]["TrainingUnder7"].ToString();

                        txtExperienceEmployer7.Text = dt.Rows[0]["ExperienceEmployerName7"].ToString();
                        txtPostDescription7.Text = dt.Rows[0]["ExperiencePostDescription7"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate7"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom7.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate7"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo7.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience7.Visible = true;
                    }
                    else { Experience7.Visible = false; }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn8"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName8"].ToString()))
                    {
                        //var experienceItem = ddlExperience8.Items.FindByText(dt.Rows[0]["ExperiencedIn8"].ToString());
                        //if (experienceItem != null) ddlExperience8.SelectedValue = experienceItem.Value;
                        txtExperience8.Text = dt.Rows[0]["ExperiencedIn8"].ToString();

                        //var trainingItem = ddlTrainingUnder8.Items.FindByText(dt.Rows[0]["TrainingUnder8"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder8.SelectedValue = trainingItem.Value;

                        txtTrainingUnder8.Text = dt.Rows[0]["TrainingUnder8"].ToString();

                        txtExperienceEmployer8.Text = dt.Rows[0]["ExperienceEmployerName8"].ToString();
                        txtPostDescription8.Text = dt.Rows[0]["ExperiencePostDescription8"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate8"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom8.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate8"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo8.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience8.Visible = true;
                    }
                    else { Experience8.Visible = false; }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn9"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName9"].ToString()))
                    {
                        //var experienceItem = ddlExperience9.Items.FindByText(dt.Rows[0]["ExperiencedIn9"].ToString());
                        //if (experienceItem != null) ddlExperience9.SelectedValue = experienceItem.Value;
                        txtExperience9.Text = dt.Rows[0]["ExperiencedIn9"].ToString();
                        txtTrainingUnder9.Text = dt.Rows[0]["TrainingUnder9"].ToString();

                        //var trainingItem = ddlTrainingUnder9.Items.FindByText(dt.Rows[0]["TrainingUnder9"].ToString());
                        //if (trainingItem != null) ddlTrainingUnder9.SelectedValue = trainingItem.Value;

                        txtExperienceEmployer9.Text = dt.Rows[0]["ExperienceEmployerName9"].ToString();
                        txtPostDescription9.Text = dt.Rows[0]["ExperiencePostDescription9"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ExperienceFromDate9"].ToString(), out DateTime issueDate))
                        {
                            txtExperienceFrom9.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExperienceToDate9"].ToString(), out DateTime expiryDate))
                        {
                            txtExperienceTo9.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        Experience9.Visible = true;
                    }
                    else { Experience9.Visible = false; }


                    txtTotalExperience.Text = dt.Rows[0]["TotalExperience"].ToString();

                    HdnExistedTotalexperience.Value = dt.Rows[0]["TotalExperience"].ToString();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void PermanentEmployed(string wiremanId)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetUserQualification(wiremanId);

            if (dt != null && dt.Rows.Count > 0)
            {
                string isEmployedPermanent = dt.Rows[0]["EmployedPermanent"].ToString().Trim();

                if (isEmployedPermanent == "Yes")
                {
                    PermanentEmployee.Visible = true;
                    //RadioButtonList3.Enabled = false;
                    ////RadioButtonList3.SelectedValue = "0";
                    txtRadioButtonList3.Text = dt.Rows[0]["EmployedPermanent"].ToString();
                    txtPermanentEmployerName.Text = dt.Rows[0]["EmployerName"].ToString();
                    txtPermanentDescription.Text = dt.Rows[0]["PostDescription"].ToString();
                    if (DateTime.TryParse(dt.Rows[0]["FromDate"].ToString(), out DateTime issueDate))
                    {
                        txtPermanentFrom.Text = issueDate.ToString("yyyy-MM-dd");
                    }

                    if (DateTime.TryParse(dt.Rows[0]["ToDate"].ToString(), out DateTime expiryDate))
                    {
                        txtPermanentTo.Text = expiryDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    PermanentEmployee.Visible = false;
                    ////RadioButtonList3.SelectedValue = "1";
                    txtRadioButtonList3.Text = dt.Rows[0]["EmployedPermanent"].ToString();

                }

            }
        }

        private void getcertificateofcompetencyDetails(string wiremanId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(wiremanId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string isCertificate = dt.Rows[0]["IsCertificateofCompetency"].ToString().Trim();

                    if (isCertificate == "Yes")
                    {
                        competency.Visible = true;
                        txtRadioButtonList2.Text = dt.Rows[0]["IsCertificateofCompetency"].ToString();
                        //// RadioButtonList2.SelectedValue = "0";
                        txtCategoryholdercertificate.Text = dt.Rows[0]["CertificateofCompetency1"].ToString();
                        txtPermitNo.Text = dt.Rows[0]["PermitNo1"].ToString();
                        txtIssuingAuthority.Text = dt.Rows[0]["IssuingAuthority1"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["IssueDate1"].ToString(), out DateTime issueDate))
                        {
                            txtIssuingDate.Text = issueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExpiryDate1"].ToString(), out DateTime expiryDate))
                        {
                            txtExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd");
                        }

                    }
                    else
                    {
                        competency.Visible = false;
                        //// RadioButtonList2.SelectedValue = "1";
                        txtRadioButtonList2.Text = dt.Rows[0]["IsCertificateofCompetency"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void GetEducationData(string wiremanId)
        {
            try
            {
                DataTable dt = CEI.GetUserQualification(wiremanId);

                txtUniversity.Text = dt.Rows[0]["UniversityName10th"].ToString();
                //YearDropdown.SelectedValue = dt.Rows[0]["PassingYear10th"]?.ToString();
                txtYearDropdown.Text = dt.Rows[0]["PassingYear10th"].ToString();
                txtmarksObtained.Text = dt.Rows[0]["MarksObtained10th"].ToString();
                txtmarksmax.Text = dt.Rows[0]["MarksMax10th"].ToString();
                txtprcntg.Text = dt.Rows[0]["Percentage10th"].ToString();


                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Name12ITIDiploma"].ToString()) ||
                      !string.IsNullOrWhiteSpace(dt.Rows[0]["MarksObtained12thorITI"].ToString()))
                {
                    //var item = ddlQualification.Items.FindByText(dt.Rows[0]["Name12ITIDiploma"].ToString());
                    //if (item != null) ddlQualification.SelectedValue = item.Value;
                    txtQualification.Text = dt.Rows[0]["Name12ITIDiploma"].ToString();
                    txtUniversity1.Text = dt.Rows[0]["UniversityName12thorITI"].ToString();
                    //DropDownList1.SelectedValue = dt.Rows[0]["PassingYear12thorITI"].ToString();

                    txtDropDownList1.Text = dt.Rows[0]["PassingYear12thorITI"].ToString();
                    txtmarksObtained1.Text = dt.Rows[0]["MarksObtained12thorITI"].ToString();
                    txtmarksmax1.Text = dt.Rows[0]["MarksMax12thorITI"].ToString();
                    txtprcntg1.Text = dt.Rows[0]["Percentage12thorITI"].ToString();
                    certificatewireman.Visible = true;
                }
                else
                {
                    certificatewireman.Visible = false;
                }


                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofDiplomaDegree"].ToString()))
                {
                    //var item = ddlQualification1.Items.FindByText(dt.Rows[0]["NameofDiplomaDegree"].ToString());
                    //if (item != null) ddlQualification1.SelectedValue = item.Value;

                    txtQualification1.Text = dt.Rows[0]["NameofDiplomaDegree"].ToString();
                    txtUniversity2.Text = dt.Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                    //DropDownList2.SelectedValue = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();

                    txtDropDownList2.Text = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();
                    txtmarksObtained2.Text = dt.Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                    txtmarksmax2.Text = dt.Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                    txtprcntg2.Text = dt.Rows[0]["PercentageDiplomaorDegree"].ToString();
                    diploma.Visible = true;
                }
                else
                {
                    diploma.Visible = false;
                }

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofDegree"].ToString()))
                {
                    //var item = ddlQualification2.Items.FindByText(dt.Rows[0]["NameofDegree"].ToString());
                    //if (item != null) ddlQualification2.SelectedValue = item.Value;
                    txtQualification2.Text = dt.Rows[0]["NameofDegree"].ToString();
                    txtUniversity3.Text = dt.Rows[0]["UniversityNamePG"].ToString();
                    txtDropDownList3.Text = dt.Rows[0]["PassingYearPG"].ToString();
                    txtmarksObtained3.Text = dt.Rows[0]["MarksObtainedPG"].ToString();
                    txtmarksmax3.Text = dt.Rows[0]["MarksMaxPG"].ToString();
                    txtprcntg3.Text = dt.Rows[0]["PercentagePG"].ToString();
                    DdlDegree.Visible = true;
                }
                else
                {
                    DdlDegree.Visible = false;
                }

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofMasters"].ToString()))
                {
                    //var item = ddlQualification3.Items.FindByText(dt.Rows[0]["NameofMasters"].ToString());
                    //if (item != null) ddlQualification3.SelectedValue = item.Value;
                    txtQualification3.Text = dt.Rows[0]["NameofMasters"].ToString();

                    txtUniversity4.Text = dt.Rows[0]["MastersUniversityName"].ToString();
                    txtDropDownList4.Text = dt.Rows[0]["MastersPassingYear"].ToString();
                    txtmarksObtained4.Text = dt.Rows[0]["MasterMarksObtained"].ToString();
                    txtmarksmax4.Text = dt.Rows[0]["MastersMarksMax"].ToString();
                    txtprcntg4.Text = dt.Rows[0]["MastersPercentage"].ToString();
                    DdlMasters.Visible = true;
                }
                else
                {
                    DdlMasters.Visible = false;
                }
            }
            catch { }
        }

        private void GetUserDetails(string wiremanId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.Getdetailsofuser(wiremanId);

                txtcategory.Text = dt.Rows[0]["Category"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtuserid.Text = dt.Rows[0]["UserId"].ToString();
                txtFatherNmae.Text = dt.Rows[0]["FatherName"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtyears.Text = dt.Rows[0]["CalculatedAge"].ToString();
                txtgender.Text = dt.Rows[0]["Gender"].ToString();
                txtAadhar.Text = dt.Rows[0]["Aadhar"].ToString();
                txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                txtState1.Text = dt.Rows[0]["CommState"].ToString();
                txtDistrict1.Text = dt.Rows[0]["CommDistrict"].ToString();
                txtPinCode.Text = dt.Rows[0]["CommPin"].ToString();
                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                txtstate.Text = dt.Rows[0]["PermanentState"].ToString();
                txtdistrict.Text = dt.Rows[0]["PermanentDistrict"].ToString();
                txtPin.Text = dt.Rows[0]["PermanentPin"].ToString();
                txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
            }
            catch
            {
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
                    Session["PreviousPage"] = null;

                }
            }
            catch { }
        }
    }
}