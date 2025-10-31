using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class SupervisorQualification : System.Web.UI.Page
    {
        // Created by neha on 27-June-2025
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
                            hdnId.Value = Session["SupervisorID"].ToString();

                            ApplicantDetail(hdnId.Value);

                            GetYearDropdown(YearDropdown);
                            GetYearDropdown(DropDownList2);
                            GetYearDropdown(DropDownList3);
                            GetYearDropdown(DropDownList4);


                            Experience.Visible = true;
                            DdlDegree.Visible = true;
                            RadioButtonList3.SelectedValue = "1";
                            PermanentEmployee.Visible = false;
                        }
                        else
                        {
                            Response.Redirect("/LogOut.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("/AdminLogout.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
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
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value == Convert.ToString(Session["SupervisorID"]))
                {
                    if (hdnId.Value != null && hdnId.Value != "")
                    {
                        REID = hdnId.Value;
                        double totalExperiences;
                        if (!double.TryParse(hdnTotalExperience.Value.Trim(), out totalExperiences))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertInvalid", "alert('Total Experience value is invalid.');", true);
                            return;
                        }

                        bool hasDiploma = ddlQualification1.SelectedIndex > 0;
                        bool hasDegree = ddlQualification2.SelectedIndex > 0;

                        //Only Diploma
                        if (hasDiploma && !hasDegree)
                        {
                            if (totalExperiences < 5)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('As per your qualification, Total Experience should be at least 5 years.');", true);
                                return;
                            }
                        }

                        //Only Degree
                        if (hasDegree && !hasDiploma)
                        {
                            if (totalExperiences < 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDegree", "alert('As per your qualification, Total Experience should be at least 1 year.');", true);
                                return;
                            }
                        }

                        // Both Degree and Diploma
                        if (hasDegree && hasDiploma)
                        {
                            if (totalExperiences < 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpBoth", "alert('As per your qualifications, Total Experience should be at least 1 year.');", true);
                                return;
                            }
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

                            CEI.InsertSupervisorQualification(REID,
                                university0, passingYear0, marksObtained0, marksMax0, percentage0, qualification1,
                                university2, passingYear2, marksObtained2, marksMax2, percentage2, qualification2,
                                university3, passingYear3, marksObtained3, marksMax3, percentage3, qualification3,
                                university4, passingYear4, marksObtained4, marksMax4, percentage4,
                                hasPermit, category, permitNo, issuingAuthority, issuingDate, expiryDate,
                                hasPermanentExp, permEmployerName, permDescription, permFrom, permTo,
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

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Qualification Added Successfully !!!')", true);
                            showAlert = true;
                            Response.Redirect("/UserPages/Documents.aspx", false);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx",false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx");
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
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioButtonList1.SelectedValue == "1") //NO
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
                    BtnAddMoreQualification.Visible = true;
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
                Response.Redirect("/LogOut.aspx");
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
        protected void BtnAddMoreQualification_Click(object sender, EventArgs e)
        {
            if (DdlDegree.Visible == true)
            {
                DdlMasters.Visible = true;
                BtnDelete.Visible = true;
                BtnAddMoreQualification.Visible = false;
            }
            else
            {
                DdlDegree.Visible = true;
                BtnDelete.Visible = true;
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/AdminLogout.aspx");
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