using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class Print__New_Registration_Information : System.Web.UI.Page
    {

        //Page created By Navneet 27-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["NewApplicationRegistrationNo"]) != null && Convert.ToString(Session["NewApplicationRegistrationNo"]) != "")
                    {
                        if (Request.UrlReferrer != null)
                        {
                            Session["BackPreviousPage"] = Request.UrlReferrer.ToString();
                        }

                        GetDetailsOfUser(Convert.ToString(Session["NewApplicationRegistrationNo"]));
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetDetailsOfUser(string RegNo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetNewLicenceApplicationData(RegNo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string UserId = dt.Rows[0]["CreatedBy"].ToString();
                     ApplyingFor.Text = dt.Rows[0]["ApplicationFor"].ToString();
                     Name.Text = dt.Rows[0]["Name"].ToString();
                     FatherName.Text = dt.Rows[0]["FatherName"].ToString();
                     gender.Text = dt.Rows[0]["Gender"].ToString();
                     Nationailty.Text = dt.Rows[0]["Nationality"].ToString();
                     Aadhar.Text = dt.Rows[0]["Aadhar"].ToString();
                     dob.Text = dt.Rows[0]["DOB"].ToString();
                     Age.Text = dt.Rows[0]["CalculatedAge"].ToString();
                     phone.Text = dt.Rows[0]["PhoneNo"].ToString();
                     Email.Text = dt.Rows[0]["Email"].ToString();
                     CommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                    // permanentAddress.Text = dt.Rows[0][""].ToString();

                    GridBindDocument(UserId);



                     University.Text = dt.Rows[0]["UniversityName10th"].ToString();
                     Passingyear.Text = dt.Rows[0]["PassingYear10th"].ToString();
                     marksObtained.Text = dt.Rows[0]["MarksObtained10th"].ToString();
                     marksmax.Text = dt.Rows[0]["MarksMax10th"].ToString();
                     prcntg.Text = dt.Rows[0]["Percentage10th"].ToString();

                     Exam1.Text = dt.Rows[0]["Name12ITIDiploma"].ToString();
                    if (!string.IsNullOrEmpty( Exam1.Text))
                    {
                        Tr_Qualification2.Visible = true;
                         University1.Text = dt.Rows[0]["UniversityName12thorITI"].ToString();
                         Passingyear1.Text = dt.Rows[0]["PassingYear12thorITI"].ToString();
                         marksObtained1.Text = dt.Rows[0]["MarksObtained12thorITI"].ToString();
                         marksmax1.Text = dt.Rows[0]["MarksMax12thorITI"].ToString();
                         prcntg1.Text = dt.Rows[0]["Percentage12thorITI"].ToString();
                    }
                     Exam2.Text = dt.Rows[0]["NameofDiplomaDegree"].ToString();
                    if (!string.IsNullOrEmpty( Exam2.Text))
                    {
                        Tr_Qualification3.Visible = true;
                         University2.Text = dt.Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                         Passingyear2.Text = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();
                         marksObtained2.Text = dt.Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                         marksmax2.Text = dt.Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                         prcntg2.Text = dt.Rows[0]["PercentageDiplomaorDegree"].ToString();
                    }
                     Exam3.Text = dt.Rows[0]["NameofDegree"].ToString();
                    if (!string.IsNullOrEmpty( Exam3.Text))
                    {
                        DdlDegree.Visible = true;
                         University3.Text = dt.Rows[0]["UniversityNamePG"].ToString();
                         Passingyear3.Text = dt.Rows[0]["PassingYearPG"].ToString();
                         marksObtained3.Text = dt.Rows[0]["MarksObtainedPG"].ToString();
                         marksmax3.Text = dt.Rows[0]["MarksMaxPG"].ToString();
                         prcntg3.Text = dt.Rows[0]["PercentagePG"].ToString();
                    }
                     Exam4.Text = dt.Rows[0]["NameofMasters"].ToString();
                    if (!string.IsNullOrEmpty( Exam4.Text))
                    {
                        DdlMasters.Visible = true;
                         University4.Text = dt.Rows[0]["MastersUniversityName"].ToString();
                         Passingyear4.Text = dt.Rows[0]["MastersPassingYear"].ToString();
                         marksObtained4.Text = dt.Rows[0]["MasterMarksObtained"].ToString();
                         marksmax4.Text = dt.Rows[0]["MastersMarksMax"].ToString();
                         prcntg4.Text = dt.Rows[0]["MastersPercentage"].ToString();
                    }
                    string IsCertificateofCompetency = dt.Rows[0]["IsCertificateofCompetency"].ToString();
                    if (IsCertificateofCompetency == "Yes")
                    {
                         PermitNo.Text = dt.Rows[0]["PermitNo1"].ToString();
                         Category.Text = dt.Rows[0]["CertificateofCompetency1"].ToString();
                         IssuingAuthority.Text = dt.Rows[0]["IssuingAuthority1"].ToString();
                         IssuingDate.Text = dt.Rows[0]["IssueDate1"].ToString();
                         ExpiryDate.Text = dt.Rows[0]["ExpiryDate1"].ToString();
                    }

                    string EmployedPermanent = dt.Rows[0]["EmployedPermanent"].ToString();
                    if (EmployedPermanent == "Yes")
                    {
                        PermanentEmployee.Visible = true;
                        RadioButtonList3.SelectedValue = "0";//dt.Rows[0]["EmployedPermanent"].ToString();
                         PermanentEmployerName.Text = dt.Rows[0]["EmployerName"].ToString();
                         PermanentDescription.Text = dt.Rows[0]["PostDescription"].ToString();
                         PermanentFrom.Text = dt.Rows[0]["FromDate"].ToString();
                         PermanentTo.Text = dt.Rows[0]["ToDate"].ToString();
                        // ExpiryDate.Text = dt.Rows[0][""].ToString();
                    }
                    else
                    {
                        RadioButtonList3.SelectedValue = "1";
                    }


                     Experience.Text = dt.Rows[0]["ExperiencedIn"].ToString();
                     Trainingunder.Text = dt.Rows[0]["TrainingUnder"].ToString();
                     ExperienceEmployer.Text = dt.Rows[0]["ExperienceEmployerName"].ToString();
                     PostDescription.Text = dt.Rows[0]["ExperiencePostDescription"].ToString();
                     ExperienceFrom.Text = dt.Rows[0]["ExperienceFromDate"].ToString();
                     ExperienceTo.Text = dt.Rows[0]["ExperienceToDate"].ToString();
                     txtExperience1.Text = dt.Rows[0]["ExperiencedIn1"].ToString();
                     TotalExperience.Text = dt.Rows[0]["TotalExperience"].ToString();
                    if (!string.IsNullOrEmpty( txtExperience1.Text))
                    {
                        Experience1.Visible = true;
                         Trainingunder1.Text = dt.Rows[0]["TrainingUnder1"].ToString();
                         ExperienceEmployer1.Text = dt.Rows[0]["ExperienceEmployerName1"].ToString();
                         PostDescription1.Text = dt.Rows[0]["ExperiencePostDescription1"].ToString();
                         ExperienceFrom1.Text = dt.Rows[0]["ExperienceFromDate1"].ToString();
                         ExperienceTo1.Text = dt.Rows[0]["ExperienceToDate1"].ToString();
                    }
                     txtExperience2.Text = dt.Rows[0]["ExperiencedIn2"].ToString();
                    if (!string.IsNullOrEmpty( txtExperience2.Text))
                    {
                        Experience2.Visible = true;
                         Trainingunder2.Text = dt.Rows[0]["TrainingUnder2"].ToString();
                         ExperienceEmployer2.Text = dt.Rows[0]["ExperienceEmployerName2"].ToString();
                         PostDescription2.Text = dt.Rows[0]["ExperiencePostDescription2"].ToString();
                         ExperienceFrom2.Text = dt.Rows[0]["ExperienceFromDate2"].ToString();
                         ExperienceTo2.Text = dt.Rows[0]["ExperienceToDate2"].ToString();
                    }
                     txtExperience3.Text = dt.Rows[0]["ExperiencedIn3"].ToString();
                    if (!string.IsNullOrEmpty( txtExperience3.Text))
                    {
                        Experience3.Visible = true;
                         Trainingunder3.Text = dt.Rows[0]["TrainingUnder3"].ToString();
                         ExperienceEmployer3.Text = dt.Rows[0]["ExperienceEmployerName3"].ToString();
                         PostDescription3.Text = dt.Rows[0]["ExperiencePostDescription3"].ToString();
                         ExperienceFrom3.Text = dt.Rows[0]["ExperienceFromDate3"].ToString();
                         ExperienceTo3.Text = dt.Rows[0]["ExperienceToDate3"].ToString();
                    }
                     txtExperience4.Text = dt.Rows[0]["ExperiencedIn4"].ToString();
                    if (!string.IsNullOrEmpty( txtExperience4.Text))
                    {
                        Experience4.Visible = true;
                         Trainingunder4.Text = dt.Rows[0]["TrainingUnder4"].ToString();
                         ExperienceEmployer4.Text = dt.Rows[0]["ExperienceEmployerName4"].ToString();
                         PostDescription4.Text = dt.Rows[0]["ExperiencePostDescription4"].ToString();
                         ExperienceFrom4.Text = dt.Rows[0]["ExperienceFromDate4"].ToString();
                         ExperienceTo4.Text = dt.Rows[0]["ExperienceToDate4"].ToString();
                    }



                    string RetiredEngineer = dt.Rows[0]["RetiredEngineer"].ToString();
                    if (RetiredEngineer == "Yes")
                    {
                        RetiredEmployee.Visible = true;
                       // RadioButtonList1.SelectedValue = "0";
                         EmployerName2.Text = dt.Rows[0]["RetiredEmployerName"].ToString();
                         Description2.Text = dt.Rows[0]["RetiredPostDescription"].ToString();
                         From2.Text = dt.Rows[0]["RetiredFromDate"].ToString();
                         To2.Text = dt.Rows[0]["RetiredToDate"].ToString();
                    }
                    else
                    {
                        //RadioButtonList1.SelectedValue = "1";
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void GridBindDocument(string Userid)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.ViewDocumentsNewApplications(Userid);
                if (ds.Tables.Count > 0 && ds != null)
                {
                    string photoUrl = "";
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string a = row["DocumentName"].ToString();
                        if (row["DocumentName"].ToString() == "Candidate Image")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            imgPhoto.ImageUrl = photoUrl;
                        }
                        if (row["DocumentName"].ToString() == "Candidate Signature")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            mySignature.ImageUrl = photoUrl;
                        }
                    }
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    string fileNames = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileNames);

                    //string fileNames = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileNames}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataRowView = (DataRowView)e.Row.DataItem;
                string DocmentName = dataRowView["DocumentName"].ToString().ToLower();
                if (DocmentName == "candidate image" || DocmentName == "candidate signature")
                {
                    e.Row.Visible = false;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string previousPageUrl = Session["BackPreviousPage"] as string;
            if (!string.IsNullOrEmpty(previousPageUrl))
            {
                Response.Redirect(previousPageUrl, false);
                Session["BackPreviousPage"] = null;
            }
        }
    }
}