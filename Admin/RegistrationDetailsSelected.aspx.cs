using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CEIHaryana.Admin
{
    public partial class RegistrationDetailsAll : System.Web.UI.Page
    {
        string REID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["RegistrationID"]) == null || Convert.ToString(Session["RegistrationID"]) == "")
                {

                }
                else
                {
                    REID = Session["RegistrationID"].ToString();
                    hdnId.Value = REID;
                    GetUserRegistartionData();
                }
            }
            catch
            {
                Response.Redirect("/AdminLogout.aspx");
            }
        }

        protected void GetUserRegistartionData()
        {
            REID = Session["RegistrationID"].ToString();
            hdnId.Value = REID;

            SqlCommand cmd = new SqlCommand("sp_GetUserDetails");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", REID);
            cmd.Connection = con;
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
                string dp_Id = ds.Tables[0].Rows[0]["Category"].ToString();

                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtFatherNmae.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                txtAadhaar.Text = ds.Tables[0].Rows[0]["AdhaarNo"].ToString();
                txtGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                string dp_Id2 = ds.Tables[0].Rows[0]["DOB"].ToString();
                txtCommunicationAddress.Text = ds.Tables[0].Rows[0]["CommunicationAddress"].ToString();
                txtPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtyears.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                txtphone.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                txtDOB.Text = DateTime.Parse(dp_Id2).ToString("yyyy-MM-dd");
                txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityName10th"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["PassingYear10th"].ToString();
                txtPassingyear.Text = DateTime.Parse(dp_Id3).ToString("yyyy-MM-dd");
                txtmarksObtained.Text = ds.Tables[0].Rows[0]["MarksObtained10th"].ToString();
                txtmarksmax.Text = ds.Tables[0].Rows[0]["MarksMax10th"].ToString();
                txtprcntg.Text = ds.Tables[0].Rows[0]["Percentage10th"].ToString();
                string dp_Id20 = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
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
                string dp_Id21 = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
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

                ddlQualification.SelectedIndex = ddlQualification.Items.IndexOf(ddlQualification.Items.FindByText(dp_Id20));
                ddlQualification1.SelectedIndex = ddlQualification1.Items.IndexOf(ddlQualification1.Items.FindByText(dp_Id1));
                ddlQualification2.SelectedIndex = ddlQualification2.Items.IndexOf(ddlQualification2.Items.FindByText(dp_Id21));
            }
        }
    }
}