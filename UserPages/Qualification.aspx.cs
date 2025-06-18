using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Qualification : System.Web.UI.Page
    {
        //Page settd by neha 18-June-2025
        string InsertedCategory = "";
        string REID = string.Empty;
        bool showAlert = false;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["InsertedCategory"]) != null && Convert.ToString(Session["InsertedCategory"]) != "")
                    {
                        HdnCategory.Value = Session["InsertedCategory"].ToString();
                        if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                        {
                            Label1.Text = "Application For Grant of Certificate of Competency(Supervisor)";
                            hdnId.Value = Session["SupervisorID"].ToString();
                            GetYearDropdown(YearDropdown);
                            GetYearDropdown(DropDownList1);
                            GetYearDropdown(DropDownList2);
                            GetYearDropdown(DropDownList3);
                            GetYearDropdown(DropDownList4);
                            //InsertedCategory = Session["InsertedCategory"].ToString();

                            Experience.Visible = true;
                            DdlDegree.Visible = true;
                        }
                        else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                        {
                            Label1.Text = "Application For Grant of Certificate of Wireman Permit";
                            hdnId.Value = Session["WiremanId"].ToString();
                            GetYearDropdown(YearDropdown);
                            GetYearDropdown(DropDownList1);
                            GetYearDropdown(DropDownList2);
                            GetYearDropdown(DropDownList3);
                            GetYearDropdown(DropDownList4);
                            // InsertedCategory = Session["InsertedCategory"].ToString();

                            Experience.Visible = true;
                            certificatewireman.Visible = true;
                            DdlDegree.Visible = false;
                            DdlMasters.Visible = false;

                        }
                        //GetYearDropdown(YearDropdown);
                        //GetYearDropdown(DropDownList1);
                        //GetYearDropdown(DropDownList2);
                        //GetYearDropdown(DropDownList3);
                        //GetYearDropdown(DropDownList4);
                        ////if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null || Session["WiremanId"] != null || Request.Cookies["WiremanId"] != null)
                        ////{
                        ////    if (Session["InsertedCategory"] != null && !string.IsNullOrEmpty(Session["InsertedCategory"].ToString()))
                        ////    {
                        //InsertedCategory = Session["InsertedCategory"].ToString();
                        //if (InsertedCategory == "Wireman")
                        //{
                        //    //ddlQualification2.Attributes.Add("disabled", "disabled");
                        //    certificatewireman.Visible = true;
                        //    DdlDegree.Visible = false;
                        //    DdlMasters.Visible = false;
                        //}
                        //else if (InsertedCategory == "Supervisor")
                        //{
                        //    Experience.Visible = true;
                        //    DdlDegree.Visible = true;
                        //    //DdlMasters.Visible = true;
                        //    //ddlQualification2.Attributes.Remove("disabled");
                        //}
                        //if (Session["Back"] != null && !string.IsNullOrEmpty(Session["Back"].ToString()))
                        //{
                        //    //GetUserQualification();
                        //}
                        //else if (Session["Back"] == null)
                        //{
                        //}
                    }
                }
            }
            catch
            {
                //Response.Redirect("/Login.aspx");
            }
        }

        private void GetYearDropdown(DropDownList ddl)
        {
            int currentYear = DateTime.Now.Year;
            ddl.Items.Clear();

            ddl.Items.Add(new ListItem("Select", "0"));

            for (int i = 1975; i <= currentYear + 20; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

        }

        //protected void GetUserQualification()
        //{
        //    if (Session["WiremanId"] != null)
        //    {
        //        REID = Session["WiremanId"].ToString();
        //    }
        //    else
        //    {
        //        REID = Session["SupervisorID"].ToString();
        //    }
        //    //hdnId.Value = REID;
        //    DataSet ds = new DataSet();
        //    ds = CEI.GetQualificationHistory(REID);
        //    if (ds.Tables.Count > 0)
        //    {
        //        txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityName10th"].ToString();
        //        string dp_Id3 = ds.Tables[0].Rows[0]["PassingYear10th"].ToString();
        //        //txtPassingyear.Text = DateTime.Parse(dp_Id3).ToString("yyyy-MM-dd");
        //        YearDropdown.SelectedItem.Text
        //        txtmarksObtained.Text = ds.Tables[0].Rows[0]["MarksObtained10th"].ToString();
        //        txtmarksmax.Text = ds.Tables[0].Rows[0]["MarksMax10th"].ToString();
        //        txtprcntg.Text = ds.Tables[0].Rows[0]["Percentage10th"].ToString();
        //        string dp_Id = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
        //        string dp_Id1 = ds.Tables[0].Rows[0]["NameofDiplomaDegree"].ToString();
        //        txtUniversity1.Text = ds.Tables[0].Rows[0]["UniversityName12thorITI"].ToString();
        //        string dp_Id4 = ds.Tables[0].Rows[0]["PassingYear12thorITI"].ToString();
        //        txtPassingyear1.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
        //        txtmarksObtained1.Text = ds.Tables[0].Rows[0]["MarksObtained12thorITI"].ToString();
        //        txtmarksmax1.Text = ds.Tables[0].Rows[0]["MarksMax12thorITI"].ToString();
        //        txtprcntg1.Text = ds.Tables[0].Rows[0]["Percentage12thorITI"].ToString();
        //        txtUniversity2.Text = ds.Tables[0].Rows[0]["UniversityNameDiplomaorDegree"].ToString();
        //        string dp_Id5 = ds.Tables[0].Rows[0]["PassingYearDiplomaorDegree"].ToString();
        //        txtPassingyear2.Text = DateTime.Parse(dp_Id5).ToString("yyyy-MM-dd");
        //        txtmarksObtained2.Text = ds.Tables[0].Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
        //        txtmarksmax2.Text = ds.Tables[0].Rows[0]["MarksMaxDiplomaorDegree"].ToString();
        //        txtprcntg2.Text = ds.Tables[0].Rows[0]["PercentageDiplomaorDegree"].ToString();
        //        string dp_Id2 = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
        //        txtUniversity3.Text = ds.Tables[0].Rows[0]["UniversityNamePG"].ToString();
        //        string dp_Id6 = ds.Tables[0].Rows[0]["PassingYearPG"].ToString();
        //        txtPassingyear3.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
        //        txtmarksObtained3.Text = ds.Tables[0].Rows[0]["MarksObtainedPG"].ToString();
        //        txtmarksmax3.Text = ds.Tables[0].Rows[0]["MarksMaxPG"].ToString();
        //        txtprcntg3.Text = ds.Tables[0].Rows[0]["PercentagePG"].ToString();
        //        txtCategory.Text = ds.Tables[0].Rows[0]["CertificateofCompetency1"].ToString();
        //        txtPermitNo.Text = ds.Tables[0].Rows[0]["PermitNo1"].ToString();
        //        txtIssuingAuthority.Text = ds.Tables[0].Rows[0]["IssuingAuthority1"].ToString();
        //        string dp_Id7 = ds.Tables[0].Rows[0]["IssueDate1"].ToString();
        //        //string dp_Id8 = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
        //        txtIssuingDate.Text = DateTime.Parse(dp_Id7).ToString("yyyy-MM-dd");
        //        //txtExpiryDate.Text = DateTime.Parse(dp_Id8).ToString("yyyy-MM-dd");
        //        //txtCategory1.Text = ds.Tables[0].Rows[0]["CertificateofCompetency2"].ToString();
        //        //txtPermitNo1.Text = ds.Tables[0].Rows[0]["PermitNo2"].ToString();
        //        //txtIssuingAuthority1.Text = ds.Tables[0].Rows[0]["IssuingAuthority2"].ToString();
        //        //string dp_Id8 = ds.Tables[0].Rows[0]["IssueDate2"].ToString();
        //        //txtIssuingDate1.Text = DateTime.Parse(dp_Id8).ToString("yyyy-MM-dd");
        //        txtPermanentEmployerName.Text = ds.Tables[0].Rows[0]["EmployerName"].ToString();
        //        txtPermanentDescription.Text = ds.Tables[0].Rows[0]["PostDescription"].ToString();
        //        string dp_Id9 = ds.Tables[0].Rows[0]["FromDate"].ToString();
        //        txtPermanentFrom.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
        //        string dp_Id10 = ds.Tables[0].Rows[0]["ToDate"].ToString();
        //        txtPermanentTo.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
        //        txtExperienceEmployer.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName"].ToString();
        //        txtPostDescription.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription"].ToString();
        //        string dp_Id11 = ds.Tables[0].Rows[0]["ExperienceFromDate"].ToString();
        //        txtExperienceFrom.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
        //        string dp_Id12 = ds.Tables[0].Rows[0]["ExperienceToDate"].ToString();
        //        txtExperienceTo.Text = DateTime.Parse(dp_Id12).ToString("yyyy-MM-dd");
        //        //txtEmployer.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName1"].ToString();
        //        //txtDescript.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription1"].ToString();
        //        //string dp_Id15 = ds.Tables[0].Rows[0]["ExperienceFromDate1"].ToString();
        //        //txtFrm1.Text = DateTime.Parse(dp_Id15).ToString("yyyy-MM-dd");
        //        //string dp_Id16 = ds.Tables[0].Rows[0]["ExperienceToDate1"].ToString();
        //        //txtToDate.Text = DateTime.Parse(dp_Id16).ToString("yyyy-MM-dd");
        //        txtEmployerName2.Text = ds.Tables[0].Rows[0]["RetiredEmployerName"].ToString();
        //        txtDescription2.Text = ds.Tables[0].Rows[0]["RetiredPostDescription"].ToString();
        //        string dp_Id13 = ds.Tables[0].Rows[0]["RetiredFromDate"].ToString();
        //        txtFrom2.Text = DateTime.Parse(dp_Id13).ToString("yyyy-MM-dd");
        //        string dp_Id14 = ds.Tables[0].Rows[0]["RetiredToDate"].ToString();
        //        txtTo2.Text = DateTime.Parse(dp_Id14).ToString("yyyy-MM-dd");
        //        // txtDOB.Text = DateTime.Parse(dp_Id2).ToString("yyyy-MM-dd");
        //        ddlQualification.SelectedIndex = ddlQualification.Items.IndexOf(ddlQualification.Items.FindByText(dp_Id));
        //        ddlQualification1.SelectedIndex = ddlQualification1.Items.IndexOf(ddlQualification1.Items.FindByText(dp_Id1));
        //        ddlQualification2.SelectedIndex = ddlQualification2.Items.IndexOf(ddlQualification2.Items.FindByText(dp_Id2));
        //    }
        //}
        ////protected void QualificationValidations()
        ////{
        ////    //InsertedCategory = Session["InsertedCategory"].ToString();
        ////    if (HdnCategory.Value == "Supervisor")
        ////    //if (InsertedCategory == "Supervisor")
        ////    {
        ////        ////if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "2")
        ////        ////{
        ////        ////    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('You are not eligible for filling this form because your qualification does not match our criteria!!!');", true);
        ////        ////    showAlert = true;
        ////        ////}
        ////    }
        ////    if (ddlQualification.SelectedValue == "0" && ddlQualification1.SelectedValue == "0")
        ////    {
        ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('You are not eligible for filling this form because your qualification does not match our criteria!!!');", true);
        ////        showAlert = true;
        ////    }
        ////    if (!showAlert)
        ////    {
        ////        CheckExperience();
        ////    }
        ////}
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
        ////protected void CheckExperience()
        ////{
        ////    try
        ////    {
        ////        if (!DateTime.TryParse(txtExperienceFrom.Text, out DateTime fromDate) ||
        ////            !DateTime.TryParse(txtExperienceTo.Text, out DateTime toDate))
        ////        {
        ////            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid From and To dates.');", true);
        ////            showAlert = true;
        ////            return;
        ////        }

        ////        if (toDate < fromDate)
        ////        {
        ////            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('To date cannot be earlier than From date.');", true);
        ////            showAlert = true;
        ////            return;
        ////        }
        ////        TimeSpan oneYear = TimeSpan.FromDays(365);
        ////        string insertedCategory = Session["InsertedCategory"]?.ToString();
        ////        if (string.IsNullOrEmpty(insertedCategory))
        ////        {
        ////            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Category information is missing.');", true);
        ////            showAlert = true;
        ////            return;
        ////        }

        ////        if (insertedCategory == "Wireman")
        ////        {
        ////            if (ddlQualification.SelectedValue == "3" || ddlQualification.SelectedValue == "4")
        ////            {
        ////                if ((toDate - fromDate) < oneYear)
        ////                {
        ////                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because you need at least 1 year of experience.');", true);
        ////                    showAlert = true;
        ////                }
        ////            }
        ////            else if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "2")
        ////            {
        ////                if ((toDate - fromDate) < (TimeSpan.FromDays(3 * 365)))
        ////                {
        ////                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because you need at least 3 years of experience.');", true);
        ////                    showAlert = true;
        ////                }
        ////            }
        ////        }
        ////        else if (insertedCategory == "Supervisor")
        ////        {
        ////            if (ddlQualification2.SelectedValue != "0")
        ////            {
        ////                if ((toDate - fromDate) < oneYear)
        ////                {
        ////                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because you need at least 1 year of experience.');", true);
        ////                    showAlert = true;
        ////                }
        ////            }
        ////            else if (ddlQualification.SelectedValue == "3" || ddlQualification.SelectedValue == "4")
        ////            {
        ////                if ((toDate - fromDate) < (TimeSpan.FromDays(5 * 365)))
        ////                {
        ////                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because you need at least 5 years of experience.');", true);
        ////                    showAlert = true;
        ////                }
        ////            }
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // Log the exception (optional)
        ////        // For example: System.Diagnostics.Debug.WriteLine(ex.Message);
        ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An unexpected error occurred while checking experience.');", true);
        ////        showAlert = true;
        ////    }
        ////}
        protected void validations()
        {
            try
            {
                if (ddlQualification1.SelectedValue != "0")
                {
                    if (txtUniversity2.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Board/University Name');", true);
                        showAlert = true;
                    }
                    else if (YearDropdown.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Passing Year');", true);
                        showAlert = true;
                    }
                    else if (txtmarksObtained2.Text == "" || txtmarksmax2.Text == "" || txtprcntg2.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Marks');", true);
                        showAlert = true;
                    }
                }
                else if (ddlQualification2.SelectedValue != "0")
                {
                    if (txtUniversity3.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Board/University Name');", true);
                        showAlert = true;
                    }
                    else if (DropDownList3.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Passing Year');", true);
                        showAlert = true;
                    }
                    else if (txtmarksObtained3.Text == "" || txtmarksmax3.Text == "" || txtprcntg3.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Marks');", true);
                        showAlert = true;
                    }
                }
                else
                {
                    showAlert = false;
                }
            }
            catch { }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value != null && hdnId.Value != "")
                {
                    REID = hdnId.Value;
                    double totalExperiences;
                    if (!double.TryParse(hdnTotalExperience.Value.Trim(), out totalExperiences) || totalExperiences < 3)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExperience", "alert('Total Experience should be at least 3 years.');", true);
                        return;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "CallValidateForm", "validateForm();", true);
                    string validationResult = Page.ClientScript.GetWebResourceUrl(this.GetType(), "window.validationResult");
                    bool isValidBoolean;

                    // Check if the string is a valid boolean representation
                    if (!bool.TryParse(validationResult, out isValidBoolean))
                    {
                        string university0 = txtUniversity.Text;
                        int passingYear0 = Convert.ToInt32(YearDropdown.SelectedValue.ToString());
                        string marksObtained0 = txtmarksObtained.Text;
                        string marksMax0 = txtmarksmax.Text;
                        string percentage0 = txtprcntg.Text;
                        string qualification0 = ddlQualification.SelectedItem.ToString();
                        string university1 = txtUniversity1.Text;
                        int passingYear1 = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                        string marksObtained1 = txtmarksObtained1.Text;
                        string marksMax1 = txtmarksmax1.Text;
                        string percentage1 = txtprcntg1.Text;
                        string qualification1 = ddlQualification1.SelectedItem.ToString();
                        string university2 = txtUniversity2.Text;
                        int passingYear2 = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                        string marksObtained2 = txtmarksObtained2.Text;
                        string marksMax2 = txtmarksmax2.Text;
                        string percentage2 = txtprcntg2.Text;
                        string qualification2 = ddlQualification2.SelectedItem.ToString();
                        string university3 = txtUniversity3.Text;
                        int passingYear3 = Convert.ToInt32(DropDownList3.SelectedValue.ToString());
                        string marksObtained3 = txtmarksObtained3.Text;
                        string marksMax3 = txtmarksmax3.Text;
                        string percentage3 = txtprcntg3.Text;
                        string qualification3 = ddlQualification3.SelectedItem.ToString();
                        string university4 = txtUniversity4.Text;
                        int passingYear4 = Convert.ToInt32(DropDownList4.SelectedValue.ToString());
                        string marksObtained4 = txtmarksObtained4.Text;
                        string marksMax4 = txtmarksmax4.Text;
                        string percentage4 = txtprcntg4.Text;
                        string hasPermit = RadioButtonList2.SelectedItem.ToString();
                        string category = txtCategory.Text;
                        string permitNo = txtPermitNo.Text;
                        string issuingAuthority = txtIssuingAuthority.Text;
                        string issuingDate = txtIssuingDate.Text;
                        string expiryDate = txtExpiryDate.Text;
                        string hasPermanentExp = RadioButtonList3.SelectedItem.ToString();
                        string permEmployerName = txtPermanentEmployerName.Text;
                        string permDescription = txtPermanentDescription.Text;
                        string permFrom = txtPermanentFrom.Text;
                        string permTo = txtPermanentTo.Text;
                        string wiremanExperience = ddlExperiencewireman.SelectedItem.ToString();
                        string wiremanTraining = Ddltrainingwiremenexprince.SelectedItem.ToString();
                        string wiremanName = txtnamewireman.Text;
                        string wiremanJobDesc = txtjobdescription.Text;
                        string wiremanExpFrom = dateexperincefrom.Text;
                        string wiremanExpTo = dateexpericeto.Text;
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
                        string hasExperience = RadioButtonList1.SelectedItem.ToString();
                        string RetiredEmployerName = txtEmployerName2.Text;
                        string RetiredPostDescription = txtDescription2.Text;
                        string RetiredFromDate = txtFrom2.Text;
                        string RetiredToDate = txtTo2.Text;

                        CEI.InsertnewUseQualification(REID,
                            university0, passingYear0, marksObtained0, marksMax0, percentage0, qualification0,
                            university1, passingYear1, marksObtained1, marksMax1, percentage1, qualification1,
                            university2, passingYear2, marksObtained2, marksMax2, percentage2, qualification2,
                            university3, passingYear3, marksObtained3, marksMax3, percentage3, qualification3,
                            university4, passingYear4, marksObtained4, marksMax4, percentage4,
                            hasPermit, category, permitNo, issuingAuthority, issuingDate, expiryDate,
                            hasPermanentExp, permEmployerName, permDescription, permFrom, permTo,
                            wiremanExperience, wiremanTraining, wiremanName, wiremanJobDesc, wiremanExpFrom, wiremanExpTo,
                            experience, trainingUnder, employer, postDescription, expFrom, expTo,
                            experience1, trainingUnder1, employer1, postDescription1, expFrom1, expTo1,
                            experience2, trainingUnder2, employer2, postDescription2, expFrom2, expTo2,
                            experience3, trainingUnder3, employer3, postDescription3, expFrom3, expTo3,
                            experience4, trainingUnder4, employer4, postDescription4, expFrom4, expTo4,
                            experience5, trainingUnder5, employer5, postDescription5, expFrom5, expTo5,
                            experience6, trainingUnder6, employer6, postDescription6, expFrom6, expTo6,
                            experience7, trainingUnder7, employer7, postDescription7, expFrom7, expTo7,
                            experience8, trainingUnder8, employer8, postDescription8, expFrom8, expTo8,
                            experience9, trainingUnder9, employer9, postDescription9, expFrom9, expTo9,
                            totalExperience, hasExperience, RetiredEmployerName, RetiredPostDescription, RetiredFromDate, RetiredToDate
                        );

                        ////Session["Back"] = txtUniversity.Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Qualification Added Successfully !!!')", true);
                        showAlert = true;
                        Response.Redirect("/UserPages/Documents.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //QualificationValidations();
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
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioButtonList1.SelectedValue == "1")
            {
                RetiredEmployee.Visible = false;
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
                TextBox[] fromArray = new TextBox[] {dateexperincefrom,txtExperienceFrom, txtExperienceFrom1, txtExperienceFrom2, txtExperienceFrom3, 
                    txtExperienceFrom4, txtExperienceFrom5, txtExperienceFrom6, txtExperienceFrom7, txtExperienceFrom8, txtExperienceFrom9
        };
                TextBox[] toArray = new TextBox[] {dateexpericeto, txtExperienceTo, txtExperienceTo1, txtExperienceTo2, txtExperienceTo3,
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
            catch (Exception ex)
            {
                txtTotalExperience.Text = "Error calculating experience.";
                // Optionally log ex.Message
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
        protected void BtnDelete_Click(object sender, EventArgs e)
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
                    txtmarksmax3.Text = "";
                    txtmarksmax3.Text = "";
                    txtprcntg3.Text = "";
                    DdlDegree.Visible = false;
                    BtnDelete.Visible = false;
                }
            }
            catch
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
            }
            else
            {
                Experience1.Visible = false;
                Experience2.Visible = false;
            }
        }

        //protected void BtnAddMoreQualification_Click(object sender, EventArgs e)
        //{
        //    if (DdlDegree.Visible == true)
        //    {
        //        DdlMasters.Visible = true;
        //    }
        //    else
        //    {
        //        DdlDegree.Visible = true;
        //    }
        //}
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
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            ////Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(-1);
            ////Response.Cookies["WiremanId"].Expires = DateTime.Now.AddDays(-1);
            ////Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/Login.aspx");
        }
        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedValue == "1")
            {
                experiencewireman.Visible = true;
            }
            else
            {
                experiencewireman.Visible = false;
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

        protected void txtmarksmax1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmarksObtained1.Text) || string.IsNullOrWhiteSpace(txtmarksmax1.Text))
            {
                txtmarksmax1.Text = "";
                txtprcntg1.Text = "";
                return;
            }
            try
            {
                double obtainedMarks = Convert.ToDouble(txtmarksObtained1.Text);
                double maxMarks = Convert.ToDouble(txtmarksmax1.Text);

                if (obtainedMarks <= maxMarks)
                {
                    double percentage = (obtainedMarks / maxMarks) * 100;
                    txtprcntg1.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Obtained Marks cannot be greater than Maximum Marks.')", true);
                    txtmarksmax1.Text = "";
                    txtprcntg1.Text = "";
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please enter valid numeric values.')", true);
                txtmarksmax1.Text = "";
                txtprcntg1.Text = "";
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
    }
}