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
	public partial class Qualification : System.Web.UI.Page
	{
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
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null || Session["WiremanId"] != null || Request.Cookies["WiremanId"] != null)
                    {
                        if (Session["InsertedCategory"] != null && !string.IsNullOrEmpty(Session["InsertedCategory"].ToString()))
                        {
                            InsertedCategory = Session["InsertedCategory"].ToString();
                            if (InsertedCategory == "Wireman")
                            {
                                //ddlQualification2.Attributes.Add("disabled", "disabled");
                                DdlDegree.Visible = false;
                                DdlMasters.Visible = false;

                            }
                            else if (InsertedCategory == "Supervisor")
                            {
                                DdlDegree.Visible = true;
                                //DdlMasters.Visible = true;
                                //ddlQualification2.Attributes.Remove("disabled");
                            }

                        }
                        if (Session["Back"] != null && !string.IsNullOrEmpty(Session["Back"].ToString()))
                        {
                            GetUserQualification();
                        }
                        else if (Session["Back"] == null)
                        {


                        }
                    }
                    else
                    {
                       
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }

        }
        protected void GetUserQualification()
        {
            if (Session["WiremanId"] != null)
            {
                REID = Session["WiremanId"].ToString();
            }
            else
            {
                REID = Session["SupervisorID"].ToString();
            }
            //hdnId.Value = REID;

            DataSet ds = new DataSet();
            ds = CEI.GetQualificationHistory(REID);
            if (ds.Tables.Count > 0)
            {
                txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityName10th"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["PassingYear10th"].ToString();
                txtPassingyear.Text = DateTime.Parse(dp_Id3).ToString("yyyy-MM-dd");
                txtmarksObtained.Text = ds.Tables[0].Rows[0]["MarksObtained10th"].ToString();
                txtmarksmax.Text = ds.Tables[0].Rows[0]["MarksMax10th"].ToString();
                txtprcntg.Text = ds.Tables[0].Rows[0]["Percentage10th"].ToString();
                string dp_Id = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["NameofDiplomaDegree"].ToString();
                txtUniversity1.Text = ds.Tables[0].Rows[0]["UniversityName12thorITI"].ToString();
                string dp_Id4 = ds.Tables[0].Rows[0]["PassingYear12thorITI"].ToString();
                txtPassingyear1.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                txtmarksObtained1.Text = ds.Tables[0].Rows[0]["MarksObtained12thorITI"].ToString();
                txtmarksmax1.Text = ds.Tables[0].Rows[0]["MarksMax12thorITI"].ToString();
                txtprcntg1.Text = ds.Tables[0].Rows[0]["Percentage12thorITI"].ToString();
                txtUniversity2.Text = ds.Tables[0].Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                string dp_Id5 = ds.Tables[0].Rows[0]["PassingYearDiplomaorDegree"].ToString();
                txtPassingyear2.Text = DateTime.Parse(dp_Id5).ToString("yyyy-MM-dd");
                txtmarksObtained2.Text = ds.Tables[0].Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                txtmarksmax2.Text = ds.Tables[0].Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                txtprcntg2.Text = ds.Tables[0].Rows[0]["PercentageDiplomaorDegree"].ToString();
                string dp_Id2 = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
                txtUniversity3.Text = ds.Tables[0].Rows[0]["UniversityNamePG"].ToString();
                string dp_Id6 = ds.Tables[0].Rows[0]["PassingYearPG"].ToString();
                txtPassingyear3.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                txtmarksObtained3.Text = ds.Tables[0].Rows[0]["MarksObtainedPG"].ToString();
                txtmarksmax3.Text = ds.Tables[0].Rows[0]["MarksMaxPG"].ToString();
                txtprcntg3.Text = ds.Tables[0].Rows[0]["PercentagePG"].ToString();
                txtCategory.Text = ds.Tables[0].Rows[0]["CertificateofCompetency1"].ToString();
                txtPermitNo.Text = ds.Tables[0].Rows[0]["PermitNo1"].ToString();
                txtIssuingAuthority.Text = ds.Tables[0].Rows[0]["IssuingAuthority1"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["IssueDate1"].ToString();
                //string dp_Id8 = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
                txtIssuingDate.Text = DateTime.Parse(dp_Id7).ToString("yyyy-MM-dd");
                //txtExpiryDate.Text = DateTime.Parse(dp_Id8).ToString("yyyy-MM-dd");
                //txtCategory1.Text = ds.Tables[0].Rows[0]["CertificateofCompetency2"].ToString();
                //txtPermitNo1.Text = ds.Tables[0].Rows[0]["PermitNo2"].ToString();
                //txtIssuingAuthority1.Text = ds.Tables[0].Rows[0]["IssuingAuthority2"].ToString();
                //string dp_Id8 = ds.Tables[0].Rows[0]["IssueDate2"].ToString();
                //txtIssuingDate1.Text = DateTime.Parse(dp_Id8).ToString("yyyy-MM-dd");
                txtPermanentEmployerName.Text = ds.Tables[0].Rows[0]["EmployerName"].ToString();
                txtPermanentDescription.Text = ds.Tables[0].Rows[0]["PostDescription"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["FromDate"].ToString();
                txtPermanentFrom.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
                string dp_Id10 = ds.Tables[0].Rows[0]["ToDate"].ToString();
                txtPermanentTo.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
                txtExperienceEmployer.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName"].ToString();
                txtPostDescription.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["ExperienceFromDate"].ToString();
                txtExperienceFrom.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
                string dp_Id12 = ds.Tables[0].Rows[0]["ExperienceToDate"].ToString();
                txtExperienceTo.Text = DateTime.Parse(dp_Id12).ToString("yyyy-MM-dd");
                //txtEmployer.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName1"].ToString();
                //txtDescript.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription1"].ToString();
                //string dp_Id15 = ds.Tables[0].Rows[0]["ExperienceFromDate1"].ToString();
                //txtFrm1.Text = DateTime.Parse(dp_Id15).ToString("yyyy-MM-dd");
                //string dp_Id16 = ds.Tables[0].Rows[0]["ExperienceToDate1"].ToString();
                //txtToDate.Text = DateTime.Parse(dp_Id16).ToString("yyyy-MM-dd");
                txtEmployerName2.Text = ds.Tables[0].Rows[0]["RetiredEmployerName"].ToString();
                txtDescription2.Text = ds.Tables[0].Rows[0]["RetiredPostDescription"].ToString();
                string dp_Id13 = ds.Tables[0].Rows[0]["RetiredFromDate"].ToString();
                txtFrom2.Text = DateTime.Parse(dp_Id13).ToString("yyyy-MM-dd");
                string dp_Id14 = ds.Tables[0].Rows[0]["RetiredToDate"].ToString();
                txtTo2.Text = DateTime.Parse(dp_Id14).ToString("yyyy-MM-dd");
                // txtDOB.Text = DateTime.Parse(dp_Id2).ToString("yyyy-MM-dd");

                ddlQualification.SelectedIndex = ddlQualification.Items.IndexOf(ddlQualification.Items.FindByText(dp_Id));
                ddlQualification1.SelectedIndex = ddlQualification1.Items.IndexOf(ddlQualification1.Items.FindByText(dp_Id1));
                ddlQualification2.SelectedIndex = ddlQualification2.Items.IndexOf(ddlQualification2.Items.FindByText(dp_Id2));
            }
        }
        protected void QualificationValidations()
        {


            InsertedCategory = Session["InsertedCategory"].ToString();


            if (InsertedCategory == "Supervisor")
            {
                if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "2")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('You are not eligible for filling this form because your qualification does not match our criteria!!!');", true);
                    showAlert = true;
                }

            }
            if (ddlQualification.SelectedValue == "0" && ddlQualification1.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('You are not eligible for filling this form because your qualification does not match our criteria!!!');", true);
                showAlert = true;
            }
            if (!showAlert)
            {
                CheckExperience();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["RegistrationID"].ToString();
            Response.Redirect("/Login.aspx");
        }
        protected void CheckExperience()
        {
            try
            {


                DateTime fromDate = DateTime.Parse(txtExperienceFrom.Text);
                DateTime toDate = DateTime.Parse(txtExperienceTo.Text);

                TimeSpan oneYear = TimeSpan.FromDays(365);
                string InsertedCategory = "";
                InsertedCategory = Session["InsertedCategory"].ToString();
                if (InsertedCategory == "Wireman")
                {
                    if (ddlQualification.SelectedValue == "3" || ddlQualification.SelectedValue == "4")
                    {
                        if ((toDate - fromDate) < oneYear)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because You need at least 1 years of experience ');", true);
                            showAlert = true;
                        }
                    }
                    else if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "2")
                    {
                        if ((toDate - fromDate) < (TimeSpan.FromDays(3 * 365)))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because You need at least 3 year of experience');", true);
                            showAlert = true;
                        }
                    }
                }
                else if (InsertedCategory == "Supervisor")
                {
                    if (ddlQualification2.SelectedValue != "0")
                    {
                        if ((toDate - fromDate) < oneYear)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because You need at least 1 years of experience');", true);
                            showAlert = true;
                        }
                    }
                    else if (ddlQualification.SelectedValue == "3" || ddlQualification.SelectedValue == "4")
                    {
                        if ((toDate - fromDate) < (TimeSpan.FromDays(5 * 365)))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for filling this form because You need at least 5 year of experience ');", true);
                            showAlert = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        protected void validations()
        {
            try
            {

                //if (ddlQualification1.SelectedValue != "0")
                //{
                //    if (txtUniversity2.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Board/University Name');", true);
                //        showAlert = true;
                //    }
                //    else if (txtPassingyear2.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Passing Year');", true);
                //        showAlert = true;
                //    }
                //    else if (txtmarksObtained2.Text == "" || txtmarksmax2.Text == "" || txtprcntg2.Text == "")
                //    {
                //        ScriptManager.RegisterStar tupScript(this, this.GetType(), "alert", "alert('Please add your Marks');", true);
                //        showAlert = true;
                //    }
                //}
                //else if (ddlQualification2.SelectedValue != "0")
                //{
                //    if (txtUniversity3.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Board/University Name');", true);
                //        showAlert = true;
                //    }
                //    else if (txtPassingyear3.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Passing Year');", true);
                //        showAlert = true;
                //    }
                //    else if (txtmarksObtained3.Text == "" || txtmarksmax3.Text == "" || txtprcntg3.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Marks');", true);
                //        showAlert = true;
                //    }
                //}
                //else
                //{
                //    showAlert = false;
                //}
            }
            catch { }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["WiremanId"] != null)
                {
                    REID = Session["WiremanId"].ToString();
                }
                else
                {
                    REID = Session["SupervisorID"].ToString();
                }
                hdnId.Value = REID;
                QualificationValidations();
                CheckExperience();
                //validations();


                ClientScript.RegisterStartupScript(this.GetType(), "CallValidateForm", "validateForm();", true);

                string validationResult = Page.ClientScript.GetWebResourceUrl(this.GetType(), "window.validationResult");

                bool isValidBoolean;
                // bool result;

                // Check if the string is a valid boolean representation
                if (!bool.TryParse(validationResult, out isValidBoolean))
                {

                    CEI.InsertnewUseQualification(REID, txtUniversity.Text, txtPassingyear.Text, txtmarksObtained.Text, txtmarksmax.Text, txtprcntg.Text,
                      ddlQualification.SelectedItem.ToString(), txtUniversity1.Text, txtPassingyear1.Text, txtmarksObtained1.Text, txtmarksmax1.Text, txtprcntg1.Text,
                      ddlQualification1.SelectedItem.ToString(), txtUniversity2.Text, txtPassingyear2.Text, txtmarksObtained2.Text, txtmarksmax2.Text, txtprcntg2.Text,
                      ddlQualification2.SelectedItem.ToString(), txtUniversity3.Text, txtPassingyear3.Text, txtmarksObtained3.Text, txtmarksmax3.Text, txtprcntg3.Text,
                      ddlQualification3.SelectedItem.ToString(), txtUniversity4.Text, txtPassingyear4.Text, txtmarksObtained4.Text, txtmarksmax4.Text, txtprcntg4.Text,
                      RadioButtonList2.SelectedItem.ToString(), txtCategory.Text, txtPermitNo.Text, txtIssuingAuthority.Text, txtIssuingDate.Text, txtExpiryDate.Text,
                      RadioButtonList3.SelectedItem.ToString(), txtPermanentEmployerName.Text, txtPermanentDescription.Text, txtPermanentFrom.Text, txtPermanentTo.Text,
                     // ddlExperience.SelectedItem.ToString(),ddlTrainingUnder.SelectedItem.ToString(),txtEmployerName1.Text, txtDescription1.Text, txtFrom1.Text, txtTo1.Text, 
                     ddlExperiene.SelectedItem.ToString(), ddlTraningUnder.SelectedItem.ToString(), txtExperienceEmployer.Text, txtPostDescription.Text, txtExperienceFrom.Text, txtExperienceTo.Text,
                     ddlExperience1.SelectedItem.ToString(), ddlTrainingUnder1.SelectedItem.ToString(), txtExperienceEmployer1.Text, txtPostDescription1.Text, txtExperienceFrom1.Text, txtExperienceTo1.Text,
                     ddlExperience2.SelectedItem.ToString(), ddlTrainingUnder2.SelectedItem.ToString(), txtExperienceEmployer2.Text, txtPostDescription2.Text, txtExperienceFrom2.Text, txtExperienceTo2.Text,
                     ddlExperience3.SelectedItem.ToString(), ddlTrainingUnder3.SelectedItem.ToString(), txtExperienceEmployer3.Text, txtPostDescription3.Text, txtExperienceFrom3.Text, txtExperienceTo3.Text,
                     ddlExperience4.SelectedItem.ToString(), ddlTrainingUnder4.SelectedItem.ToString(), txtExperienceEmployer4.Text, txtPostDescription3.Text, txtExperienceFrom4.Text, txtExperienceTo4.Text,
                     txtTotalExperience.Text, RadioButtonList1.SelectedItem.ToString()
                     );

                    Session["Back"] = txtUniversity.Text;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Qualification Added Successfully !!!')", true);
                    showAlert = true;
                    Response.Redirect("/UserPages/Documents.aspx", false);
                }
            }
            catch
            {

            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // QualificationValidations();
            if (RadioButtonList2.SelectedValue == "0")
            {
                competency.Visible = true;
            }
            else
            {
                competency.Visible = false;
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (RadioButtonList1.SelectedValue == "0")
            //{
            //    RetiredEmployee.Visible = true;
            //}
            //else
            //{
            //    RetiredEmployee.Visible = false;
            //}
        }
        protected void txtTo1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Check the condition to determine if txtExperienceFrom and txtExperienceTo are visible
                bool isExperienceVisible = true;

                TextBox[] fromArray = isExperienceVisible ? new TextBox[] { txtExperienceFrom, txtExperienceFrom1, txtExperienceFrom2, txtExperienceFrom3, txtExperienceFrom4 } : new TextBox[] { txtExperienceFrom };
                TextBox[] toArray = isExperienceVisible ? new TextBox[] { txtExperienceTo, txtExperienceTo1, txtExperienceTo2, txtExperienceTo3, txtExperienceTo4 } : new TextBox[] { txtExperienceTo };

                int totalYears = 0, totalMonths = 0, totalDays = 0;

                for (int i = 0; i < fromArray.Length; i++)
                {
                    // Check if the TextBox controls are visible
                    if (fromArray[i].Visible && toArray[i].Visible)
                    {
                        DateTime fromDate, toDate;

                        try
                        {
                            // Parse the 'From' and 'To' values
                            if (DateTime.TryParse(fromArray[i].Text, out fromDate) && DateTime.TryParse(toArray[i].Text, out toDate))
                            {
                                TimeSpan difference = toDate - fromDate;

                                totalYears += (int)(difference.TotalDays / 365.25); // 365.25 takes into account leap years
                                totalMonths += (int)((difference.TotalDays % 365.25) / 30.44); // 30.44 is the average number of days in a month
                                totalDays += (int)(difference.TotalDays % 30.44);
                            }
                        }
                        catch (Exception)
                        {
                            // Handle the exception if needed
                        }
                    }
                }

                txtTotalExperience.Text = $"{totalYears} years, {totalMonths} months, {totalDays} days";
            }
            catch
            {
                // Handle the exception if needed
            }
        }
        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList3.SelectedValue == "1")
            {
                PermanentEmployee.Visible = false;

            }
            else
            {
                PermanentEmployee.Visible = true;
            }

        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DdlMasters.Visible == true)
                {
                    DdlMasters.Visible = false;
                }
                else
                {
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
            Session.Abandon();
            Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["WiremanId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }
        protected void txtmarksmax_TextChanged(object sender, EventArgs e)
        {
            if (txtmarksObtained.Text == "" || txtmarksObtained.Text == null)
            {

            }
            else
            {
                double ObtainedMarks = Convert.ToDouble(txtmarksObtained.Text);
                double MaxiMarks = Convert.ToDouble(txtmarksmax.Text);
                if (ObtainedMarks <= MaxiMarks)
                {
                    double percentage = (ObtainedMarks / MaxiMarks) * 100;
                    txtprcntg.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please first Enter Obtained Marks')", true);
                    return;
                }

            }
        }

        protected void txtmarksmax1_TextChanged(object sender, EventArgs e)
        {
            if (txtmarksObtained1.Text == "" || txtmarksObtained1.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please first Enter Obtained Marks')", true);
                return;
            }
            else
            {
                double ObtainedMarks = Convert.ToDouble(txtmarksObtained1.Text);
                double MaxiMarks = Convert.ToDouble(txtmarksmax1.Text);
                if (ObtainedMarks <= MaxiMarks)
                {
                    double percentage = (ObtainedMarks / MaxiMarks) * 100;
                    txtprcntg1.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please  Enter correct MaximumMarks')", true);
                    return;
                }
            }
        }

        protected void txtmarksmax2_TextChanged(object sender, EventArgs e)
        {
            if (txtmarksObtained2.Text == "" || txtmarksObtained2.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please first Enter Obtained Marks')", true);
                return;
            }
            else
            {
                double ObtainedMarks = Convert.ToDouble(txtmarksObtained2.Text);
                double MaxiMarks = Convert.ToDouble(txtmarksmax2.Text);
                if (ObtainedMarks <= MaxiMarks)
                {
                    double percentage = (ObtainedMarks / MaxiMarks) * 100;
                    txtprcntg2.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please  Enter correct MaximumMarks')", true);
                    return;
                }
            }
        }

        protected void txtmarksmax3_TextChanged(object sender, EventArgs e)
        {
            if (txtmarksObtained3.Text == "" || txtmarksObtained3.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please first Enter Obtained Marks')", true);
                return;
            }
            else
            {
                double ObtainedMarks = Convert.ToDouble(txtmarksObtained3.Text);
                double MaxiMarks = Convert.ToDouble(txtmarksmax3.Text);
                if (ObtainedMarks <= MaxiMarks)
                {
                    double percentage = (ObtainedMarks / MaxiMarks) * 100;
                    txtprcntg3.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please  Enter correct MaximumMarks')", true);
                    return;
                }
            }
        }

        protected void txtmarksmax4_TextChanged(object sender, EventArgs e)
        {
            if (txtmarksObtained4.Text == "" || txtmarksObtained4.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please first Enter Obtained Marks')", true);
                return;
            }
            else
            {
                double ObtainedMarks = Convert.ToDouble(txtmarksObtained4.Text);
                double MaxiMarks = Convert.ToDouble(txtmarksmax4.Text);
                if (ObtainedMarks <= MaxiMarks)
                {
                    double percentage = (ObtainedMarks / MaxiMarks) * 100;
                    txtprcntg4.Text = percentage.ToString("F1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Showalert", "alert('Please  Enter correct MaximumMarks')", true);
                    return;
                }
            }
        }
    }
}