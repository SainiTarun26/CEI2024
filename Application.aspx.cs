using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class Application : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        String REID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                }
                else
                {

                }
            }
            catch
            {
            }

        }
        protected void GetUserQualification()
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
                // hdnId.Value = REID;
                //string REID = "Aman20010920";
                DataSet ds = new DataSet();
                ds = CEI.QualificationData(REID);

                txtApplication.Text = ds.Tables[0].Rows[0]["ApplicationFor"].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                txtGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                txtNationality.Text = "Indian";
                txtAdhaar.Text = ds.Tables[0].Rows[0]["Aadhar"].ToString();
                string Dob = ds.Tables[0].Rows[0]["Age"].ToString();
                txtDOB.Text = DateTime.Parse(Dob).ToString("yyyy-MM-dd");
                txtCalculatedAge.Text = ds.Tables[0].Rows[0]["CalculatedAge"].ToString();
                txtPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                txtCommunicationAddress.Text = ds.Tables[0].Rows[0]["CommunicationAddress"].ToString();
                txtContact.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityName10th"].ToString();
                string PassingYear = ds.Tables[0].Rows[0]["PassingYear10th"].ToString();
                txtPassingyear.Text = DateTime.Parse(PassingYear).ToString("yyyy-MM-dd");
                txtmarks.Text = ds.Tables[0].Rows[0]["Marks10th"].ToString();
                txtprcntg.Text = ds.Tables[0].Rows[0]["Percentage10th"].ToString();

                txt12thorITI.Text = ds.Tables[0].Rows[0]["Name12ITIDiploma"].ToString();
                txtUniversity1.Text = ds.Tables[0].Rows[0]["UniversityName12thorITI"].ToString();
                string PassingYear1 = ds.Tables[0].Rows[0]["PassingYear12thorITI"].ToString();
                txtPassingyear1.Text = DateTime.Parse(PassingYear1).ToString("yyyy-MM-dd");
                txtmarks12thOrITI.Text = ds.Tables[0].Rows[0]["Marks12th"].ToString();
                txtprcntg1.Text = ds.Tables[0].Rows[0]["Percentage12thorITI"].ToString();

                txtDiploma.Text = ds.Tables[0].Rows[0]["NameofDiplomaDegree"].ToString();
                txtUniversity2.Text = ds.Tables[0].Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                string PassingYear2 = ds.Tables[0].Rows[0]["PassingYearDiplomaorDegree"].ToString();
                txtPassingyear2.Text = DateTime.Parse(PassingYear2).ToString("yyyy-MM-dd");
                //txtmarksDiploma.Text = ds.Tables[0].Rows[0]["DiplomaMarks"].ToString();
                txtprcntg2.Text = ds.Tables[0].Rows[0]["PercentageDiplomaorDegree"].ToString();

                txtDegree.Text = ds.Tables[0].Rows[0]["NameofDegree"].ToString();
                if (txtDegree.Text.Trim() != null && txtDegree.Text.Trim() != "")
                {
                    txtUniversity3.Text = ds.Tables[0].Rows[0]["UniversityNamePG"].ToString();
                    string PassingYear3 = ds.Tables[0].Rows[0]["PassingYearPG"].ToString();
                    txtPassingyear3.Text = DateTime.Parse(PassingYear3).ToString("yyyy-MM-dd");
                    txtmarksObtained3.Text = ds.Tables[0].Rows[0]["MarksGraduation"].ToString();
                    txtprcntg3.Text = ds.Tables[0].Rows[0]["PercentagePG"].ToString();
                }
                txtMasters.Text = ds.Tables[0].Rows[0]["NameofMasters"].ToString();
                if (txtMasters.Text.Trim() != null && txtMasters.Text.Trim() != "")
                {
                    txtUniversity4.Text = ds.Tables[0].Rows[0]["MastersUniversityName"].ToString();
                    string PassingYear4 = ds.Tables[0].Rows[0]["MastersPassingYear"].ToString();
                    txtPassingyear4.Text = DateTime.Parse(PassingYear4).ToString("yyyy-MM-dd");
                    txtmarksObtained4.Text = ds.Tables[0].Rows[0]["MastersMarks"].ToString();
                    txtprcntg4.Text = ds.Tables[0].Rows[0]["MastersPercentage"].ToString();
                }
                string iscertificateCompetency = ds.Tables[0].Rows[0]["IsCertificateofCompetency"].ToString().Trim();
                RadioButtonList2.Items.FindByText(iscertificateCompetency).Selected = true;
                if (iscertificateCompetency != "No")
                {
                    competency.Visible = true;
                    txtCategory.Text = ds.Tables[0].Rows[0]["CertificateofCompetency1"].ToString();
                    txtPermitNo.Text = ds.Tables[0].Rows[0]["PermitNo1"].ToString();
                    txtIssuingAuthority.Text = ds.Tables[0].Rows[0]["IssuingAuthority1"].ToString();
                    string issuingDate = ds.Tables[0].Rows[0]["IssueDate1"].ToString();
                    txtIssuingDate.Text = DateTime.Parse(issuingDate).ToString("yyyy-MM-dd");
                    string ExpiryDate = ds.Tables[0].Rows[0]["ExpiryDate1"].ToString();
                    txtExpiryDate.Text = DateTime.Parse(ExpiryDate).ToString("yyyy-MM-dd");
                }
                else
                {
                    competency.Visible = false;
                }

                string PermanentEmploye = ds.Tables[0].Rows[0]["EmployedPermanent"].ToString().Trim();
                RadioButtonList3.Items.FindByText(PermanentEmploye).Selected = true;
                if (PermanentEmploye != "No")
                {
                    PermanentEmployee.Visible = true;
                    txtPermanentEmployerName.Text = ds.Tables[0].Rows[0]["EmployerName"].ToString();
                    txtPermanentDescription.Text = ds.Tables[0].Rows[0]["PostDescription"].ToString();
                    string PermanentFrom = ds.Tables[0].Rows[0]["FromDate"].ToString();
                    txtPermanentFrom.Text = DateTime.Parse(PermanentFrom).ToString("yyyy-MM-dd");
                    string PermanentTo = ds.Tables[0].Rows[0]["ToDate"].ToString();
                    txtPermanentTo.Text = DateTime.Parse(PermanentTo).ToString("yyyy-MM-dd");
                }
                else
                {
                    PermanentEmployee.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}