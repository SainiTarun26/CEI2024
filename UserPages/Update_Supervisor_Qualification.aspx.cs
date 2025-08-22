using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.UserPages
{

    //Page created by kalpana 4-July -2025
    public partial class Update_Supervisor_Qualification : System.Web.UI.Page
    {
        string userid = "";
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Convert.ToString(Session["UserIdForEdit"]) != null && Convert.ToString(Session["UserIdForEdit"]) != "")
                {
                    hdnId.Value = Session["UserIdForEdit"].ToString();

                    ApplicantDetail(hdnId.Value);
                    GetYearDropdown(YearDropdown);
                    GetYearDropdown(DropDownList2);
                    GetYearDropdown(DropDownList3);
                    GetYearDropdown(DropDownList4);

                    GetEducationData(hdnId.Value);
                    getcertificateofcompetencyDetails(hdnId.Value);
                    PermanentEmployed(hdnId.Value);
                    getExperienceDetail(hdnId.Value);
                    RetiredEngineer(hdnId.Value);

                    btnDeleteExp.Visible = true;
                    BtnDelete.Visible = true;

                }
                else if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {

                    hdnId.Value = Session["SupervisorID"].ToString();
                    ApplicantDetail(hdnId.Value);
                    GetYearDropdown(YearDropdown);
                    GetYearDropdown(DropDownList2);
                    GetYearDropdown(DropDownList3);
                    GetYearDropdown(DropDownList4);

                    GetEducationData(hdnId.Value);
                    getcertificateofcompetencyDetails(hdnId.Value);
                    PermanentEmployed(hdnId.Value);
                    getExperienceDetail(hdnId.Value);
                    RetiredEngineer(hdnId.Value);

                    btnDeleteExp.Visible = true;
                    BtnDelete.Visible = true;
                }
                else
                {
                    Response.Redirect("/LogOut.aspx");
                }
            }
        }

        private void ApplicantDetail(string Id)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetApplicantBasicInformation(Id);
                txtApplicantName.Text = ds.Rows[0]["Name"].ToString();
                txtFatherName.Text = ds.Rows[0]["FatherName"].ToString();
                txtBirthDate.Text = ds.Rows[0]["DOB"].ToString();
                txtAppliedFor.Text = ds.Rows[0]["ApplicationFor"].ToString();
                HdnDOBYear.Value = ds.Rows[0]["BirthYear"].ToString();
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }
        private void GetYearDropdown(DropDownList ddl)
        {
            int currentYear = DateTime.Now.Year;
            ddl.Items.Clear();

            ddl.Items.Add(new ListItem("Select", "0"));

            int dobYear;
            if (int.TryParse(HdnDOBYear.Value, out dobYear))
            {
                for (int i = dobYear; i <= currentYear; i++)
                {
                    ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }


        private void GetEducationData(string userid)
        {
            try
            {
                DataTable dt = CEI.GetUserQualification(userid);

                txtUniversity.Text = dt.Rows[0]["UniversityName10th"].ToString();
                YearDropdown.SelectedValue = dt.Rows[0]["PassingYear10th"]?.ToString();
                txtmarksObtained.Text = dt.Rows[0]["MarksObtained10th"].ToString();
                txtmarksmax.Text = dt.Rows[0]["MarksMax10th"].ToString();
                txtprcntg.Text = dt.Rows[0]["Percentage10th"].ToString();

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofDiplomaDegree"].ToString()))
                {
                    var item = ddlQualification1.Items.FindByText(dt.Rows[0]["NameofDiplomaDegree"].ToString());
                    if (item != null)
                    { ddlQualification1.SelectedValue = item.Value; }
                    txtUniversity2.Text = dt.Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();
                    txtmarksObtained2.Text = dt.Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                    txtmarksmax2.Text = dt.Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                    txtprcntg2.Text = dt.Rows[0]["PercentageDiplomaorDegree"].ToString();
                    diploma.Visible = true;
                }
                else
                {
                    diploma.Visible = true;
                }

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofDegree"].ToString()))
                {
                    var item = ddlQualification2.Items.FindByText(dt.Rows[0]["NameofDegree"].ToString());
                    if (item != null) ddlQualification2.SelectedValue = item.Value;
                    txtUniversity3.Text = dt.Rows[0]["UniversityNamePG"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["PassingYearPG"].ToString();
                    txtmarksObtained3.Text = dt.Rows[0]["MarksObtainedPG"].ToString();
                    txtmarksmax3.Text = dt.Rows[0]["MarksMaxPG"].ToString();
                    txtprcntg3.Text = dt.Rows[0]["PercentagePG"].ToString();
                    DdlDegree.Visible = true;
                }
                else
                {
                    DdlDegree.Visible = true;
                }

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NameofMasters"].ToString()))
                {
                    var item = ddlQualification3.Items.FindByText(dt.Rows[0]["NameofMasters"].ToString());
                    if (item != null) ddlQualification3.SelectedValue = item.Value;
                    txtUniversity4.Text = dt.Rows[0]["MastersUniversityName"].ToString();
                    DropDownList4.SelectedValue = dt.Rows[0]["MastersPassingYear"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    userid = hdnId.Value;
                    string UniversityName10th = txtUniversity.Text;
                    int PassingYear10th = Convert.ToInt32(YearDropdown.SelectedValue.ToString());
                    string MarksObtained10th = txtmarksObtained.Text;
                    string MarksMax10th = txtmarksmax.Text;
                    string Percentage10th = txtprcntg.Text;

                    string NameofDiplomaDegree = ddlQualification1.SelectedItem.ToString();
                    string UniversityNameDiplomaorDegree = txtUniversity2.Text;
                    int PassingYearDiplomaorDegree = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                    string MarksObtainedDiplomaorDegree = txtmarksObtained2.Text;
                    string MarksMaxDiplomaorDegree = txtmarksmax2.Text;
                    string PercentageDiplomaorDegree = txtprcntg2.Text;

                    string NameofDegree = ddlQualification2.SelectedItem.ToString();
                    string UniversityNamePG = txtUniversity3.Text;
                    int PassingYearPG = Convert.ToInt32(DropDownList3.SelectedValue.ToString());
                    string MarksObtainedPG = txtmarksObtained3.Text;
                    string MarksMaxPG = txtmarksmax3.Text;
                    string PercentagePG = txtprcntg3.Text;

                    string NameofMasters = ddlQualification3.SelectedItem.ToString();
                    string MastersUniversityName = txtUniversity4.Text;
                    int MastersPassingYear = Convert.ToInt32(DropDownList4.SelectedValue.ToString());
                    string MasterMarksObtained = txtmarksObtained4.Text;
                    string MastersMarksMax = txtmarksmax4.Text;
                    string MatersPercentage = txtprcntg4.Text;


                    CEI.UpdateEducationDetailsByIdforsupervisor(userid, UniversityName10th, PassingYear10th, MarksObtained10th, MarksMax10th, Percentage10th,
                        NameofDiplomaDegree, UniversityNameDiplomaorDegree, PassingYearDiplomaorDegree, MarksObtainedDiplomaorDegree, MarksMaxDiplomaorDegree, PercentageDiplomaorDegree,
                        NameofDegree, UniversityNamePG, PassingYearPG, MarksObtainedPG, MarksMaxPG, PercentagePG,
                        NameofMasters, MastersUniversityName, MastersPassingYear, MasterMarksObtained, MastersMarksMax, MatersPercentage);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void getcertificateofcompetencyDetails(string userid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(userid);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string isCertificate = dt.Rows[0]["IsCertificateofCompetency"].ToString().Trim();

                    if (isCertificate == "Yes")
                    {
                        competency.Visible = true;
                        //RadioButtonList2.Enabled = false;
                        RadioButtonList2.SelectedValue = "0";
                        txtCategory.Text = dt.Rows[0]["CertificateofCompetency1"].ToString();
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
                        RadioButtonList2.SelectedValue = "1";
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    userid = hdnId.Value;

                    string IsCertificateofCompetency = RadioButtonList2.SelectedItem.ToString();
                    string CertificateofCompetency1 = txtCategory.Text;
                    string PermitNo1 = txtPermitNo.Text;
                    string IssuingAuthority1 = txtIssuingAuthority.Text;
                    string IssueDate1 = txtIssuingDate.Text;
                    string ExpiryDate1 = txtExpiryDate.Text;

                    CEI.UpdateGetcertificateofcompetencyDetails(userid, IsCertificateofCompetency, CertificateofCompetency1, PermitNo1, IssuingAuthority1, IssueDate1, ExpiryDate1);
                    getcertificateofcompetencyDetails(userid);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void PermanentEmployed(string userid)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetUserQualification(userid);

            if (dt != null && dt.Rows.Count > 0)
            {
                string isEmployedPermanent = dt.Rows[0]["EmployedPermanent"].ToString().Trim();

                if (isEmployedPermanent == "Yes")
                {
                    PermanentEmployee.Visible = true;
                    //RadioButtonList3.Enabled = false;
                    RadioButtonList3.SelectedValue = "0";
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
                    RadioButtonList3.SelectedValue = "1";

                }

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    userid = hdnId.Value;

                    string isEmployedPermanent = RadioButtonList3.SelectedItem.ToString();
                    string EmployerName = txtPermanentEmployerName.Text;
                    string PostDescription = txtPermanentDescription.Text;
                    string FromDate = txtPermanentFrom.Text;
                    string ToDate = txtPermanentTo.Text;
                    ;

                    CEI.UpdateEmployedPermanentDetails(userid, isEmployedPermanent, EmployerName, PostDescription, FromDate, ToDate);
                    PermanentEmployed(userid);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void getExperienceDetail(string userid)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(userid);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName"].ToString()))
                    {
                        //var experienceItem = ddlExperience.Items.FindByText(dt.Rows[0]["ExperiencedIn"].ToString());
                        //if (experienceItem != null) ddlExperience.SelectedValue = experienceItem.Value;

                        var experienceText = dt.Rows[0]["ExperiencedIn"].ToString().Trim();
                        var item = ddlExperience.Items.FindByText(experienceText);
                        if (item != null)
                            ddlExperience.SelectedValue = item.Value;


                        var trainingItem = ddlTrainingUnder.Items.FindByText(dt.Rows[0]["TrainingUnder"].ToString());
                        if (trainingItem != null) ddlTrainingUnder.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience1.Items.FindByText(dt.Rows[0]["ExperiencedIn1"].ToString());
                        if (experienceItem != null) ddlExperience1.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder1.Items.FindByText(dt.Rows[0]["TrainingUnder1"].ToString());
                        if (trainingItem != null) ddlTrainingUnder1.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience2.Items.FindByText(dt.Rows[0]["ExperiencedIn2"].ToString());
                        if (experienceItem != null) ddlExperience2.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder2.Items.FindByText(dt.Rows[0]["TrainingUnder2"].ToString());
                        if (trainingItem != null) ddlTrainingUnder2.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience3.Items.FindByText(dt.Rows[0]["ExperiencedIn3"].ToString());
                        if (experienceItem != null) ddlExperience3.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder3.Items.FindByText(dt.Rows[0]["TrainingUnder3"].ToString());
                        if (trainingItem != null) ddlTrainingUnder3.SelectedValue = trainingItem.Value;
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
                        var experienceItem = ddlExperience4.Items.FindByText(dt.Rows[0]["ExperiencedIn4"].ToString());
                        if (experienceItem != null) ddlExperience4.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder4.Items.FindByText(dt.Rows[0]["TrainingUnder4"].ToString());
                        if (trainingItem != null) ddlTrainingUnder4.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience5.Items.FindByText(dt.Rows[0]["ExperiencedIn5"].ToString());
                        if (experienceItem != null) ddlExperience5.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder5.Items.FindByText(dt.Rows[0]["TrainingUnder5"].ToString());
                        if (trainingItem != null) ddlTrainingUnder5.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience6.Items.FindByText(dt.Rows[0]["ExperiencedIn6"].ToString());
                        if (experienceItem != null) ddlExperience6.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder6.Items.FindByText(dt.Rows[0]["TrainingUnder6"].ToString());
                        if (trainingItem != null) ddlTrainingUnder6.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience7.Items.FindByText(dt.Rows[0]["ExperiencedIn7"].ToString());
                        if (experienceItem != null) ddlExperience7.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder7.Items.FindByText(dt.Rows[0]["TrainingUnder7"].ToString());
                        if (trainingItem != null) ddlTrainingUnder7.SelectedValue = trainingItem.Value;

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
                        var experienceItem = ddlExperience8.Items.FindByText(dt.Rows[0]["ExperiencedIn8"].ToString());
                        if (experienceItem != null) ddlExperience8.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder8.Items.FindByText(dt.Rows[0]["TrainingUnder8"].ToString());
                        if (trainingItem != null) ddlTrainingUnder8.SelectedValue = trainingItem.Value;

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

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn8"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName8"].ToString()))
                    {
                        var experienceItem = ddlExperience9.Items.FindByText(dt.Rows[0]["ExperiencedIn9"].ToString());
                        if (experienceItem != null) ddlExperience9.SelectedValue = experienceItem.Value;

                        var trainingItem = ddlTrainingUnder9.Items.FindByText(dt.Rows[0]["TrainingUnder9"].ToString());
                        if (trainingItem != null) ddlTrainingUnder9.SelectedValue = trainingItem.Value;

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
                    else { Experience8.Visible = false; }

                    txtTotalExperience.Text = dt.Rows[0]["TotalExperience"].ToString();

                    HdnExistedTotalexperience.Value = dt.Rows[0]["TotalExperience"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    userid = hdnId.Value;

                    string experience = ddlExperience.SelectedItem.ToString();
                    string trainingUnder = ddlTrainingUnder.SelectedItem.ToString();
                    string employer = txtExperienceEmployer.Text;
                    string postDescription = txtPostDescription.Text;
                    string expFrom = txtExperienceFrom.Text;
                    string expTo = txtExperienceTo.Text;
                    string experience1 = ddlExperience1.SelectedItem.ToString();
                    string trainingUnder1 = ddlTrainingUnder1.SelectedItem.ToString();
                    string employer1 = txtExperienceEmployer1.Text;
                    string postDescription1 = txtPostDescription1.Text;
                    string expFrom1 = txtExperienceFrom1.Text;
                    string expTo1 = txtExperienceTo1.Text;
                    string experience2 = ddlExperience2.SelectedItem.ToString();
                    string trainingUnder2 = ddlTrainingUnder2.SelectedItem.ToString();
                    string employer2 = txtExperienceEmployer2.Text;
                    string postDescription2 = txtPostDescription2.Text;
                    string expFrom2 = txtExperienceFrom2.Text;
                    string expTo2 = txtExperienceTo2.Text;
                    string experience3 = ddlExperience3.SelectedItem.ToString();
                    string trainingUnder3 = ddlTrainingUnder3.SelectedItem.ToString();
                    string employer3 = txtExperienceEmployer3.Text;
                    string postDescription3 = txtPostDescription3.Text;
                    string expFrom3 = txtExperienceFrom3.Text;
                    string expTo3 = txtExperienceTo3.Text;
                    string experience4 = ddlExperience4.SelectedItem.ToString();
                    string trainingUnder4 = ddlTrainingUnder4.SelectedItem.ToString();
                    string employer4 = txtExperienceEmployer4.Text;
                    string postDescription4 = txtPostDescription4.Text;
                    string expFrom4 = txtExperienceFrom4.Text;
                    string expTo4 = txtExperienceTo4.Text;
                    string experience5 = ddlExperience5.SelectedItem.ToString();
                    string trainingUnder5 = ddlTrainingUnder5.SelectedItem.ToString();
                    string employer5 = txtExperienceEmployer5.Text;
                    string postDescription5 = txtPostDescription5.Text;
                    string expFrom5 = txtExperienceFrom5.Text;
                    string expTo5 = txtExperienceTo5.Text;
                    string experience6 = ddlExperience6.SelectedItem.ToString();
                    string trainingUnder6 = ddlTrainingUnder6.SelectedItem.ToString();
                    string employer6 = txtExperienceEmployer6.Text;
                    string postDescription6 = txtPostDescription6.Text;
                    string expFrom6 = txtExperienceFrom6.Text;
                    string expTo6 = txtExperienceTo6.Text;
                    string experience7 = ddlExperience7.SelectedItem.ToString();
                    string trainingUnder7 = ddlTrainingUnder7.SelectedItem.ToString();
                    string employer7 = txtExperienceEmployer7.Text;
                    string postDescription7 = txtPostDescription7.Text;
                    string expFrom7 = txtExperienceFrom7.Text;
                    string expTo7 = txtExperienceTo7.Text;
                    string experience8 = ddlExperience8.SelectedItem.ToString();
                    string trainingUnder8 = ddlTrainingUnder8.SelectedItem.ToString();
                    string employer8 = txtExperienceEmployer8.Text;
                    string postDescription8 = txtPostDescription8.Text;
                    string expFrom8 = txtExperienceFrom8.Text;
                    string expTo8 = txtExperienceTo8.Text;
                    string experience9 = ddlExperience9.SelectedItem.ToString();
                    string trainingUnder9 = ddlTrainingUnder9.SelectedItem.ToString();
                    string employer9 = txtExperienceEmployer9.Text;
                    string postDescription9 = txtPostDescription9.Text;
                    string expFrom9 = txtExperienceFrom9.Text;
                    string expTo9 = txtExperienceTo9.Text;
                    string totalExperience = txtTotalExperience.Text;
                    CEI.updateExperienceforsupervisor(userid, experience, trainingUnder, employer, postDescription, expFrom, expTo,
                                experience1, trainingUnder1, employer1, postDescription1, expFrom1, expTo1,
                                experience2, trainingUnder2, employer2, postDescription2, expFrom2, expTo2,
                                experience3, trainingUnder3, employer3, postDescription3, expFrom3, expTo3,
                                experience4, trainingUnder4, employer4, postDescription4, expFrom4, expTo4,
                                experience5, trainingUnder5, employer5, postDescription5, expFrom5, expTo5,
                                experience6, trainingUnder6, employer6, postDescription6, expFrom6, expTo6,
                                experience7, trainingUnder7, employer7, postDescription7, expFrom7, expTo7,
                                experience8, trainingUnder8, employer8, postDescription8, expFrom8, expTo8,
                                experience9, trainingUnder9, employer9, postDescription9, expFrom9, expTo9,
                                totalExperience);
                    getExperienceDetail(userid);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }
        }
        protected void RetiredEngineer(string userid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUserQualification(userid);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string isRetired = dt.Rows[0]["RetiredEngineer"].ToString().Trim();

                    if (isRetired == "Yes")
                    {
                        RetiredEmployee.Visible = true;
                        //RadioButtonList1.Enabled = false;
                        RadioButtonList1.SelectedValue = "0";
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
                        RadioButtonList1.SelectedValue = "1";
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    userid = hdnId.Value;

                    string RetireEngineer = RadioButtonList1.SelectedItem.ToString();
                    string RetiredEmployerName = txtEmployerName2.Text;
                    string RetiredPostDescription = txtDescription2.Text;
                    string RetiredFromDate = txtFrom2.Text;
                    string RetiredToDate = txtTo2.Text;


                    CEI.UpdateRetiredDetails(userid, RetireEngineer, RetiredEmployerName, RetiredPostDescription, RetiredFromDate, RetiredToDate);
                    RetiredEngineer(userid);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //string totalExpText = txtTotalExperience.Text.Trim().ToLower();
                string totalExpText = HdnExistedTotalexperience.Value.Trim().ToLower();
                int totalExperiences = 0;

                if (!(totalExpText.Contains("years") && totalExpText.Contains("months") && totalExpText.Contains("days")))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertInvalid",
                        "alert('Please enter experience in format: X years, Y months, Z days');", true);
                    return;
                }

                string[] parts = totalExpText.Split(new[] { "years", "months", "days", ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 1 && int.TryParse(parts[0], out int years))
                {
                    totalExperiences = years;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertInvalidYears",
                        "alert('Unable to extract number of years from Total Experience.');", true);
                    return;
                }

                // Qualification checks
                bool hasDiploma = ddlQualification1.SelectedIndex > 0;
                bool hasDegree = ddlQualification2.SelectedIndex > 0;

                // Only Diploma
                if (hasDiploma && !hasDegree)
                {
                    if (totalExperiences < 5)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma",
                            "alert('As per your qualification, Total Experience should be at least 5 years.');", true);
                        return;
                    }
                }

                // Only Degree
                if (hasDegree && !hasDiploma)
                {
                    if (totalExperiences < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDegree",
                            "alert('As per your qualification, Total Experience should be at least 1 year.');", true);
                        return;
                    }
                }

                // Both Degree and Diploma
                if (hasDegree && hasDiploma)
                {
                    if (totalExperiences < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpBoth",
                            "alert('As per your qualifications, Total Experience should be at least 1 year.');", true);
                        return;
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "CallValidateForm", "validateForm();", true);

                CEI.UpdateStatusAfterEdit(hdnId.Value);
                string validationResult = Page.ClientScript.GetWebResourceUrl(this.GetType(), "window.validationResult");


                Response.Redirect("/UserPages/Documents.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void BtnAddMoreQualification_Click(object sender, EventArgs e)
        {
            if (DdlDegree.Visible == true)
            {
                DdlMasters.Visible = true;
                BtnDelete.Visible = true;
            }
            else
            {
                DdlDegree.Visible = true;
                BtnDelete.Visible = true;
            }
        }
        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            try
            {
                if (DdlMasters.Visible == true)
                {
                    ddlQualification3.SelectedValue = "0";
                    txtUniversity4.Text = "";
                    DropDownList4.SelectedValue = "0";
                    txtmarksObtained4.Text = "";
                    txtmarksmax4.Text = "";
                    txtprcntg4.Text = "";
                    DdlMasters.Visible = false;
                }
                else
                {
                    ddlQualification2.SelectedValue = "0";
                    txtUniversity3.Text = "";
                    DropDownList3.SelectedValue = "0";
                    txtmarksObtained3.Text = "";
                    txtmarksmax3.Text = "";
                    txtprcntg3.Text = "";
                    DdlDegree.Visible = false;
                    BtnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            if (Experience9.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
                Experience6.Visible = true;
                Experience7.Visible = true;
                Experience8.Visible = true;
                Experience9.Visible = true;
            }
            if (Experience8.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
                Experience6.Visible = true;
                Experience7.Visible = true;
                Experience8.Visible = true;
                Experience9.Visible = true;

                btnAddMore.Visible = false;
            }
            if (Experience7.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
                Experience6.Visible = true;
                Experience7.Visible = true;
                Experience8.Visible = true;
            }
            if (Experience6.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
                Experience6.Visible = true;
                Experience7.Visible = true;
            }
            if (Experience5.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
                Experience6.Visible = true;
            }
            if (Experience4.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
                Experience5.Visible = true;
            }
            if (Experience3.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
                Experience4.Visible = true;
            }
            else if (Experience2.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
                Experience3.Visible = true;
            }
            else if (Experience1.Visible == true)
            {
                Experience1.Visible = true;
                Experience2.Visible = true;
            }
            else if (Experience.Visible == false)
            {
                Experience.Visible = true;
            }
            else if (Experience1.Visible == false)
            {
                Experience1.Visible = true;
                Experience2.Visible = false;
                btnDeleteExp.Visible = true;
            }
            else
            {
                Experience1.Visible = false;
                Experience2.Visible = false;
                btnDeleteExp.Visible = false;
            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "0")
            {
                competency.Visible = true;
            }
            else
            {
                competency.Visible = false;
                txtCategory.Text = "";
                txtPermitNo.Text = "";
                txtIssuingAuthority.Text = "";
                txtIssuingDate.Text = "";
                txtExpiryDate.Text = "";
            }
        }
        protected void txtmarksmax_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarksObtained.Text) || string.IsNullOrWhiteSpace(txtmarksmax.Text))
            {
                txtmarksmax.Text = "";
                txtprcntg.Text = "";
                return;
            }
            try
            {
                double obtainedMarks = Convert.ToDouble(txtmarksObtained.Text);
                double maxMarks = Convert.ToDouble(txtmarksmax.Text);

                if (obtainedMarks <= maxMarks)
                {
                    double percentage = (obtainedMarks / maxMarks) * 100;
                    txtprcntg.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Obtained Marks cannot be greater than Maximum Marks.')", true);
                    txtmarksmax.Text = "";
                    txtprcntg.Text = "";
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please enter valid numeric values.')", true);
                txtmarksmax.Text = "";
                txtprcntg.Text = "";
            }
        }
        protected void txtmarksmax2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarksObtained2.Text) || string.IsNullOrWhiteSpace(txtmarksmax2.Text))
            {
                txtmarksmax2.Text = "";
                txtprcntg2.Text = "";
                return;
            }
            try
            {
                double obtainedMarks = Convert.ToDouble(txtmarksObtained2.Text);
                double maxMarks = Convert.ToDouble(txtmarksmax2.Text);

                if (obtainedMarks <= maxMarks)
                {
                    double percentage = (obtainedMarks / maxMarks) * 100;
                    txtprcntg2.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Obtained Marks cannot be greater than Maximum Marks.')", true);
                    txtmarksmax2.Text = "";
                    txtprcntg2.Text = "";
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please enter valid numeric values.')", true);
                txtmarksmax2.Text = "";
                txtprcntg2.Text = "";
            }
        }
        protected void txtmarksmax3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarksObtained3.Text) || string.IsNullOrWhiteSpace(txtmarksmax3.Text))
            {
                txtmarksmax3.Text = "";
                txtprcntg3.Text = "";
                return;
            }
            try
            {
                double obtainedMarks = Convert.ToDouble(txtmarksObtained3.Text);
                double maxMarks = Convert.ToDouble(txtmarksmax3.Text);

                if (obtainedMarks <= maxMarks)
                {
                    double percentage = (obtainedMarks / maxMarks) * 100;
                    txtprcntg3.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Obtained Marks cannot be greater than Maximum Marks.')", true);
                    txtmarksmax3.Text = "";
                    txtprcntg3.Text = "";
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please enter valid numeric values.')", true);
                txtmarksmax3.Text = "";
                txtprcntg3.Text = "";
            }
        }
        protected void txtmarksmax4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarksObtained4.Text) || string.IsNullOrWhiteSpace(txtmarksmax4.Text))
            {
                txtmarksmax4.Text = "";
                txtprcntg4.Text = "";
                return;
            }
            try
            {
                double obtainedMarks = Convert.ToDouble(txtmarksObtained4.Text);
                double maxMarks = Convert.ToDouble(txtmarksmax4.Text);

                if (obtainedMarks <= maxMarks)
                {
                    double percentage = (obtainedMarks / maxMarks) * 100;
                    txtprcntg4.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Obtained Marks cannot be greater than Maximum Marks.')", true);
                    txtmarksmax4.Text = "";
                    txtprcntg4.Text = "";
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please enter valid numeric values.')", true);
                txtmarksmax4.Text = "";
                txtprcntg4.Text = "";
            }
        }
        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList3.SelectedValue == "0")
            {
                PermanentEmployee.Visible = true;
            }
            else
            {
                PermanentEmployee.Visible = false;
                txtPermanentEmployerName.Text = "";
                txtPermanentDescription.Text = "";
                txtPermanentFrom.Text = "";
                txtPermanentTo.Text = "";
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1")
            {
                RetiredEmployee.Visible = false;
                txtEmployerName2.Text = "";
                txtDescription2.Text = "";
                txtFrom2.Text = "";
                txtTo2.Text = "";
            }
            else
            {
                RetiredEmployee.Visible = true;
            }
        }
        protected void txtTo1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ToCalculateExperience();
            }
            catch (Exception ex)
            {
                txtTotalExperience.Text = "Error calculating experience.";
            }
        }
        private void ToCalculateExperience()
        {
            hdnTotalExperience.Value = "";
            txtTotalExperience.Text = "";

            TextBox[] fromArray = new TextBox[] {txtExperienceFrom, txtExperienceFrom1, txtExperienceFrom2, txtExperienceFrom3,
                    txtExperienceFrom4, txtExperienceFrom5, txtExperienceFrom6, txtExperienceFrom7, txtExperienceFrom8, txtExperienceFrom9
        };
            TextBox[] toArray = new TextBox[] { txtExperienceTo, txtExperienceTo1, txtExperienceTo2, txtExperienceTo3,
                    txtExperienceTo4, txtExperienceTo5, txtExperienceTo6, txtExperienceTo7, txtExperienceTo8, txtExperienceTo9
        };
            int totalYears = 0, totalMonths = 0, totalDays = 0;
            for (int i = 0; i < fromArray.Length; i++)
            {
                if (fromArray[i].Visible && toArray[i].Visible &&
                    !string.IsNullOrWhiteSpace(fromArray[i].Text) &&
                    !string.IsNullOrWhiteSpace(toArray[i].Text))
                {
                    if (DateTime.TryParse(fromArray[i].Text, out DateTime fromDate) &&
                        DateTime.TryParse(toArray[i].Text, out DateTime toDate))
                    {
                        if (toDate < fromDate)
                            continue; // Skip invalid range

                        int years = toDate.Year - fromDate.Year;
                        int months = toDate.Month - fromDate.Month;
                        int days = toDate.Day - fromDate.Day;

                        if (days < 0)
                        {
                            months--;
                            days += DateTime.DaysInMonth(toDate.AddMonths(-1).Year, toDate.AddMonths(-1).Month);
                        }
                        if (months < 0)
                        {
                            years--;
                            months += 12;
                        }
                        totalYears += years;
                        totalMonths += months;
                        totalDays += days;
                    }
                }
            }

            // Normalize extra days to months
            if (totalDays >= 30)
            {
                totalMonths += totalDays / 30;
                totalDays = totalDays % 30;
            }

            // Normalize extra months to years
            if (totalMonths >= 12)
            {
                totalYears += totalMonths / 12;
                totalMonths = totalMonths % 12;
            }
            hdnTotalExperience.Value = totalYears.ToString();
            txtTotalExperience.Text = $"{totalYears} years, {totalMonths} months, {totalDays} days";
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/Login.aspx");
        }

        protected void ddlQualification2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification2.SelectedValue == "0")
            {
                txtUniversity3.Text = "";
                DropDownList3.SelectedValue = "0";
                txtmarksObtained3.Text = "";
                txtmarksmax3.Text = "";
                txtprcntg3.Text = "";
            }
        }

        protected void ddlQualification1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification1.SelectedValue == "0")
            {
                txtUniversity2.Text = "";
                DropDownList2.SelectedValue = "0";
                txtmarksObtained2.Text = "";
                txtmarksmax2.Text = "";
                txtprcntg2.Text = "";
            }
        }

        protected void btnDeleteExp_Click(object sender, EventArgs e)
        {
            if (Experience9.Visible == true)
            {

                Experience9.Visible = false;
                btnAddMore.Visible = true;
                ToCalculateExperience();
                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";


            }
            else if (Experience8.Visible == true)
            {
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience7.Visible == true)
            {
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();


                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience6.Visible == true)
            {
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience5.Visible == true)
            {
                Experience5.Visible = false;
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();
                ddlExperience5.SelectedValue = "0";
                ddlTrainingUnder5.SelectedValue = "0";
                txtExperienceEmployer5.Text = "";
                txtPostDescription5.Text = "";
                txtExperienceFrom5.Text = "";
                txtExperienceTo5.Text = "";

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience4.Visible == true)
            {
                Experience4.Visible = false;
                Experience5.Visible = false;
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();
                ddlExperience4.SelectedValue = "0";
                ddlTrainingUnder4.SelectedValue = "0";
                txtExperienceEmployer4.Text = "";
                txtPostDescription4.Text = "";
                txtExperienceFrom4.Text = "";
                txtExperienceTo4.Text = "";

                ddlExperience5.SelectedValue = "0";
                ddlTrainingUnder5.SelectedValue = "0";
                txtExperienceEmployer5.Text = "";
                txtPostDescription5.Text = "";
                txtExperienceFrom5.Text = "";
                txtExperienceTo5.Text = "";

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience3.Visible == true)
            {
                Experience3.Visible = false;
                Experience4.Visible = false;
                Experience5.Visible = false;
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();
                ddlExperience3.SelectedValue = "0";
                ddlTrainingUnder3.SelectedValue = "0";
                txtExperienceEmployer3.Text = "";
                txtPostDescription3.Text = "";
                txtExperienceFrom3.Text = "";
                txtExperienceTo3.Text = "";

                ddlExperience4.SelectedValue = "0";
                ddlTrainingUnder4.SelectedValue = "0";
                txtExperienceEmployer4.Text = "";
                txtPostDescription4.Text = "";
                txtExperienceFrom4.Text = "";
                txtExperienceTo4.Text = "";

                ddlExperience5.SelectedValue = "0";
                ddlTrainingUnder5.SelectedValue = "0";
                txtExperienceEmployer5.Text = "";
                txtPostDescription5.Text = "";
                txtExperienceFrom5.Text = "";
                txtExperienceTo5.Text = "";

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience2.Visible == true)
            {
                Experience2.Visible = false;
                Experience3.Visible = false;
                Experience4.Visible = false;
                Experience5.Visible = false;
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();

                ddlExperience2.SelectedValue = "0";
                ddlTrainingUnder2.SelectedValue = "0";
                txtExperienceEmployer2.Text = "";
                txtPostDescription2.Text = "";
                txtExperienceFrom2.Text = "";
                txtExperienceTo2.Text = "";

                ddlExperience3.SelectedValue = "0";
                ddlTrainingUnder3.SelectedValue = "0";
                txtExperienceEmployer3.Text = "";
                txtPostDescription3.Text = "";
                txtExperienceFrom3.Text = "";
                txtExperienceTo3.Text = "";

                ddlExperience4.SelectedValue = "0";
                ddlTrainingUnder4.SelectedValue = "0";
                txtExperienceEmployer4.Text = "";
                txtPostDescription4.Text = "";
                txtExperienceFrom4.Text = "";
                txtExperienceTo4.Text = "";

                ddlExperience5.SelectedValue = "0";
                ddlTrainingUnder5.SelectedValue = "0";
                txtExperienceEmployer5.Text = "";
                txtPostDescription5.Text = "";
                txtExperienceFrom5.Text = "";
                txtExperienceTo5.Text = "";

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";
            }
            else if (Experience1.Visible == true)
            {
                Experience1.Visible = false;
                Experience2.Visible = false;
                Experience3.Visible = false;
                Experience4.Visible = false;
                Experience5.Visible = false;
                Experience6.Visible = false;
                Experience7.Visible = false;
                Experience8.Visible = false;
                Experience9.Visible = false;
                ToCalculateExperience();
                ddlExperience1.SelectedValue = "0";
                ddlTrainingUnder1.SelectedValue = "0";
                txtExperienceEmployer1.Text = "";
                txtPostDescription1.Text = "";
                txtExperienceFrom1.Text = "";
                txtExperienceTo1.Text = "";

                ddlExperience2.SelectedValue = "0";
                ddlTrainingUnder2.SelectedValue = "0";
                txtExperienceEmployer2.Text = "";
                txtPostDescription2.Text = "";
                txtExperienceFrom2.Text = "";
                txtExperienceTo2.Text = "";

                ddlExperience3.SelectedValue = "0";
                ddlTrainingUnder3.SelectedValue = "0";
                txtExperienceEmployer3.Text = "";
                txtPostDescription3.Text = "";
                txtExperienceFrom3.Text = "";
                txtExperienceTo3.Text = "";

                ddlExperience4.SelectedValue = "0";
                ddlTrainingUnder4.SelectedValue = "0";
                txtExperienceEmployer4.Text = "";
                txtPostDescription4.Text = "";
                txtExperienceFrom4.Text = "";
                txtExperienceTo4.Text = "";

                ddlExperience5.SelectedValue = "0";
                ddlTrainingUnder5.SelectedValue = "0";
                txtExperienceEmployer5.Text = "";
                txtPostDescription5.Text = "";
                txtExperienceFrom5.Text = "";
                txtExperienceTo5.Text = "";

                ddlExperience6.SelectedValue = "0";
                ddlTrainingUnder6.SelectedValue = "0";
                txtExperienceEmployer6.Text = "";
                txtPostDescription6.Text = "";
                txtExperienceFrom6.Text = "";
                txtExperienceTo6.Text = "";

                ddlExperience7.SelectedValue = "0";
                ddlTrainingUnder7.SelectedValue = "0";
                txtExperienceEmployer7.Text = "";
                txtPostDescription7.Text = "";
                txtExperienceFrom7.Text = "";
                txtExperienceTo7.Text = "";

                ddlExperience8.SelectedValue = "0";
                ddlTrainingUnder8.SelectedValue = "0";
                txtExperienceEmployer8.Text = "";
                txtPostDescription8.Text = "";
                txtExperienceFrom8.Text = "";
                txtExperienceTo8.Text = "";


                ddlExperience9.SelectedValue = "0";
                ddlTrainingUnder9.SelectedValue = "0";
                txtExperienceEmployer9.Text = "";
                txtPostDescription9.Text = "";
                txtExperienceFrom9.Text = "";
                txtExperienceTo9.Text = "";

                btnDeleteExp.Visible = false;
            }
            else
            {
                btnDeleteExp.Visible = false;
            }
        }
    }
}