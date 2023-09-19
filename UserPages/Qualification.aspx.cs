using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CEIHaryana.UserPages
{
    public partial class Qualification : System.Web.UI.Page
    {
        string InsertedCategory = "";
        string REID = string.Empty;
        bool showAlert = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["InsertedCategory"] != null && !string.IsNullOrEmpty(Session["InsertedCategory"].ToString()))
                {
                    string InsertedCategory = "";
                    InsertedCategory = Session["InsertedCategory"].ToString();
                    if (InsertedCategory == "Wireman")
                    {
                        ddlQualification2.Attributes.Add("disabled", "disabled");
                    }
                    else
                    {
                        ddlQualification2.Attributes.Remove("disabled");
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

        }

        protected void GetUserQualification()
        {
            REID = Session["RegistrationID"].ToString();
            hdnId.Value = REID;

            SqlCommand cmd = new SqlCommand("sp_GetUserQualification");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", REID);
            cmd.Connection = con;
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
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
                txtIssuingDate.Text = DateTime.Parse(dp_Id7).ToString("yyyy-MM-dd");
                txtCategory1.Text = ds.Tables[0].Rows[0]["CertificateofCompetency2"].ToString();
                txtPermitNo1.Text = ds.Tables[0].Rows[0]["PermitNo2"].ToString();
                txtIssuingAuthority1.Text = ds.Tables[0].Rows[0]["IssuingAuthority2"].ToString();
                string dp_Id8 = ds.Tables[0].Rows[0]["IssueDate2"].ToString();
                txtIssuingDate1.Text = DateTime.Parse(dp_Id8).ToString("yyyy-MM-dd");
                txtEmployerName.Text = ds.Tables[0].Rows[0]["EmployerName"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["PostDescription"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["FromDate"].ToString();
                txtFrom.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
                string dp_Id10 = ds.Tables[0].Rows[0]["ToDate"].ToString();
                txtTo.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
                txtEmployerName1.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName"].ToString();
                txtDescription1.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["ExperienceFromDate"].ToString();
                txtFrom1.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
                string dp_Id12 = ds.Tables[0].Rows[0]["ExperienceToDate"].ToString();
                txtTo1.Text = DateTime.Parse(dp_Id12).ToString("yyyy-MM-dd");
                txtEmployer.Text = ds.Tables[0].Rows[0]["ExperienceEmployerName1"].ToString();
                txtDescript.Text = ds.Tables[0].Rows[0]["ExperiencePostDescription1"].ToString();
                string dp_Id15 = ds.Tables[0].Rows[0]["ExperienceFromDate1"].ToString();
                txtFrm1.Text = DateTime.Parse(dp_Id15).ToString("yyyy-MM-dd");
                string dp_Id16 = ds.Tables[0].Rows[0]["ExperienceToDate1"].ToString();
                txtToDate.Text = DateTime.Parse(dp_Id16).ToString("yyyy-MM-dd");
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
            Session["RegistrationID"].ToString();
            Response.Redirect("Registration.aspx");
        }
        protected void CheckExperience()
        {
            try
            {


                DateTime fromDate = DateTime.Parse(txtFrom1.Text);
                DateTime toDate = DateTime.Parse(txtTo1.Text);

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
                if (ddlQualification1.SelectedValue != "0")
                {
                    if (txtUniversity2.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add your Board/University Name');", true);
                        showAlert = true;
                    }
                    else if (txtPassingyear2.Text == "")
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
                    else if (txtPassingyear3.Text == "")
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
            REID = Session["RegistrationID"].ToString();
            hdnId.Value = REID;

            QualificationValidations();
            CheckExperience();
            validations();

            if (!showAlert)
            {

                SqlCommand cmd = new SqlCommand("sp_InsertUserQualification");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", REID);
                cmd.Parameters.AddWithValue("@UniversityName10th", txtUniversity.Text);
                cmd.Parameters.AddWithValue("@PassingYear10th", txtPassingyear.Text);
                cmd.Parameters.AddWithValue("@MarksObtained10th", txtmarksObtained.Text);
                cmd.Parameters.AddWithValue("@MarksMax10th", txtmarksmax.Text);
                cmd.Parameters.AddWithValue("@Percentage10th", txtprcntg.Text);
                cmd.Parameters.AddWithValue("@Name12ITIDiploma", ddlQualification.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UniversityName12thorITI", txtUniversity1.Text);
                cmd.Parameters.AddWithValue("@PassingYear12thorITI", txtPassingyear1.Text);
                cmd.Parameters.AddWithValue("@MarksObtained12thorITI", txtmarksObtained1.Text);
                cmd.Parameters.AddWithValue("@MarksMax12thorITI", txtmarksmax1.Text);
                cmd.Parameters.AddWithValue("@Percentage12thorITI", txtprcntg1.Text);
                cmd.Parameters.AddWithValue("@NameofDiplomaDegree", ddlQualification1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UniversityNameDiplomaorDegree", txtUniversity2.Text);
                cmd.Parameters.AddWithValue("@PassingYearDiplomaorDegree", txtPassingyear2.Text);
                cmd.Parameters.AddWithValue("@MarksObtainedDiplomaorDegree", txtmarksObtained2.Text);
                cmd.Parameters.AddWithValue("@MarksMaxDiplomaorDegree", txtmarksmax2.Text);
                cmd.Parameters.AddWithValue("@PercentageDiplomaorDegree", txtprcntg2.Text);
                cmd.Parameters.AddWithValue("@NameofDegree", ddlQualification2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UniversityNamePG", txtUniversity3.Text);
                cmd.Parameters.AddWithValue("@PassingYearPG", txtPassingyear3.Text);
                cmd.Parameters.AddWithValue("@MarksObtainedPG", txtmarksObtained3.Text);
                cmd.Parameters.AddWithValue("@MarksMaxPG", txtmarksmax3.Text);
                cmd.Parameters.AddWithValue("@PercentagePG", txtprcntg3.Text);
                cmd.Parameters.AddWithValue("@IsCertificateofCompetency", RadioButtonList2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@CertificateofCompetency1", txtCategory.Text);
                cmd.Parameters.AddWithValue("@PermitNo1", txtPermitNo.Text);
                cmd.Parameters.AddWithValue("@IssuingAuthority1", txtIssuingAuthority.Text);
                cmd.Parameters.AddWithValue("@IssueDate1", txtIssuingDate.Text);
                cmd.Parameters.AddWithValue("@CertificateofCompetency2", txtCategory1.Text);
                cmd.Parameters.AddWithValue("@PermitNo2", txtPermitNo1.Text);
                cmd.Parameters.AddWithValue("@IssuingAuthority2", txtIssuingAuthority1.Text);
                cmd.Parameters.AddWithValue("@IssueDate2", txtIssuingDate1.Text);
                cmd.Parameters.AddWithValue("@EmployedPermanent", RadioButtonList3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@EmployerName", txtEmployerName.Text);
                cmd.Parameters.AddWithValue("@PostDescription", txtDescription.Text);
                cmd.Parameters.AddWithValue("@FromDate", txtFrom.Text);
                cmd.Parameters.AddWithValue("@ToDate", txtTo.Text);
                cmd.Parameters.AddWithValue("@ExperienceEmployerName", txtEmployerName1.Text);
                cmd.Parameters.AddWithValue("@ExperiencePostDescription", txtDescription1.Text);
                cmd.Parameters.AddWithValue("@ExperienceFromDate", txtFrom1.Text);
                cmd.Parameters.AddWithValue("@ExperienceToDate", txtTo1.Text);
                cmd.Parameters.AddWithValue("@ExperienceEmployerName1", txtEmployer.Text);
                cmd.Parameters.AddWithValue("@ExperiencePostDescription1", txtDescript.Text);
                cmd.Parameters.AddWithValue("@ExperienceFromDate1", txtFrm1.Text);
                cmd.Parameters.AddWithValue("@ExperienceToDate1", txtToDate.Text);
                cmd.Parameters.AddWithValue("@RetiredEngineer", RadioButtonList1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@RetiredEmployerName", txtEmployerName2.Text);
                cmd.Parameters.AddWithValue("@RetiredPostDescription", txtDescription2.Text);
                cmd.Parameters.AddWithValue("@RetiredFromDate", txtFrom2.Text);
                cmd.Parameters.AddWithValue("@RetiredToDate", txtTo2.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Session["Back"] = txtUniversity.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Added Successfully !!!')", true);
                showAlert = true;
                Response.Redirect("Documents.aspx");
            }
        }



        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            QualificationValidations();
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

            if (RadioButtonList1.SelectedValue == "0")
            {
                RetiredEmployee.Visible = true;
            }
            else
            {
                RetiredEmployee.Visible = false;
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
    }
}