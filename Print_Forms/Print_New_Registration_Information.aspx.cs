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
                    string ApplicationType = ApplyingFor.Text;
                    if (ApplicationType== "Supervisor")
                    {
                        lblDeclarationType.Text = "Certificate of Competency";
                    }
                    else if(ApplicationType == "Wireman Permit")
                    {
                        lblDeclarationType.Text = "Certificate of Permit";
                    }
                  
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    FatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    gender.Text = dt.Rows[0]["Gender"].ToString();
                    Nationailty.Text = dt.Rows[0]["Nationality"].ToString();
                    Aadhar.Text = dt.Rows[0]["Aadhar"].ToString();
                    dob.Text = dt.Rows[0]["DOB"].ToString();
                    Age.Text = dt.Rows[0]["CalculatedAge"].ToString();
                    phone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    CommunicationAddress.Text = dt.Rows[0]["Communication"].ToString();
                    PermanentAddress.Text = dt.Rows[0]["permanant"].ToString();
                    GridBindDocument(UserId);



                    University.Text = dt.Rows[0]["UniversityName10th"].ToString();
                    Passingyear.Text = dt.Rows[0]["PassingYear10th"].ToString();
                    marksObtained.Text = dt.Rows[0]["MarksObtained10th"].ToString();
                    marksmax.Text = dt.Rows[0]["MarksMax10th"].ToString();
                    prcntg.Text = dt.Rows[0]["Percentage10th"].ToString();

                    Exam1.Text = dt.Rows[0]["Name12ITIDiploma"].ToString();
                    if (!string.IsNullOrEmpty(Exam1.Text))
                    {
                        Tr_Qualification2.Visible = true;
                        University1.Text = dt.Rows[0]["UniversityName12thorITI"].ToString();
                        Passingyear1.Text = dt.Rows[0]["PassingYear12thorITI"].ToString();
                        marksObtained1.Text = dt.Rows[0]["MarksObtained12thorITI"].ToString();
                        marksmax1.Text = dt.Rows[0]["MarksMax12thorITI"].ToString();
                        prcntg1.Text = dt.Rows[0]["Percentage12thorITI"].ToString();
                    }
                    Exam2.Text = dt.Rows[0]["NameofDiplomaDegree"].ToString();
                    if (!string.IsNullOrEmpty(Exam2.Text))
                    {
                        Tr_Qualification3.Visible = true;
                        University2.Text = dt.Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                        Passingyear2.Text = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();
                        marksObtained2.Text = dt.Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                        marksmax2.Text = dt.Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                        prcntg2.Text = dt.Rows[0]["PercentageDiplomaorDegree"].ToString();
                    }
                    Exam3.Text = dt.Rows[0]["NameofDegree"].ToString();
                    if (!string.IsNullOrEmpty(Exam3.Text))
                    {
                        DdlDegree.Visible = true;
                        University3.Text = dt.Rows[0]["UniversityNamePG"].ToString();
                        Passingyear3.Text = dt.Rows[0]["PassingYearPG"].ToString();
                        marksObtained3.Text = dt.Rows[0]["MarksObtainedPG"].ToString();
                        marksmax3.Text = dt.Rows[0]["MarksMaxPG"].ToString();
                        prcntg3.Text = dt.Rows[0]["PercentagePG"].ToString();
                    }
                    Exam4.Text = dt.Rows[0]["NameofMasters"].ToString();
                    if (!string.IsNullOrEmpty(Exam4.Text))
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
                        RadioButtonList2.SelectedValue = "0";
                        competency.Visible = true;
                        PermitNo.Text = dt.Rows[0]["PermitNo1"].ToString();
                        Category.Text = dt.Rows[0]["CertificateofCompetency1"].ToString();
                        IssuingAuthority.Text = dt.Rows[0]["IssuingAuthority1"].ToString();

                        if (DateTime.TryParse(dt.Rows[0]["IssueDate1"].ToString(), out DateTime IssueDate))
                        {
                            IssuingDate.Text = IssueDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ExpiryDate1"].ToString(), out DateTime ExpiryDate1))
                        {
                            ExpiryDate.Text = ExpiryDate1.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        RadioButtonList2.SelectedValue = "1";
                        competency.Visible = false;
                    }

                        string EmployedPermanent = dt.Rows[0]["EmployedPermanent"].ToString();
                    if (EmployedPermanent == "Yes")
                    {
                        PermanentEmployee.Visible = true;
                        RadioButtonList3.SelectedValue = "0";//dt.Rows[0]["EmployedPermanent"].ToString();
                        PermanentEmployerName.Text = dt.Rows[0]["EmployerName"].ToString();
                        PermanentDescription.Text = dt.Rows[0]["PostDescription"].ToString();
                        // ExpiryDate.Text = dt.Rows[0][""].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["FromDate"].ToString(), out DateTime FromDate))
                        {
                            PermanentFrom.Text = FromDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["ToDate"].ToString(), out DateTime ToDate))
                        {
                            PermanentTo.Text = ToDate.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        RadioButtonList3.SelectedValue = "1";
                    }


                    ////if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticePostDescription"].ToString()) ||
                    ////    !string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticenameofEmployer"].ToString()))
                    ////{
                    ////    //txtApprenticeship.Text = dt.Rows[0]["ApprenticeExperience"].ToString().Trim();
                    ////    txtAppretinceExperience.Text = dt.Rows[0]["ApprenticeTrainingUnder"].ToString().Trim();
                    ////    txtApprenticeshipEmployer.Text = dt.Rows[0]["ApprenticenameofEmployer"].ToString();
                    ////    txtApprenticesPost.Text = dt.Rows[0]["ApprenticePostDescription"].ToString();

                    ////    if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceFromDate"].ToString(), out DateTime apprenticeFrom))
                    ////    {
                    ////        Apprenticesdatefrom.Text = apprenticeFrom.ToString("yyyy-MM-dd");
                    ////    }

                    ////    if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceToDate"].ToString(), out DateTime apprenticeTo))
                    ////    {
                    ////        Apprenticesdateto.Text = apprenticeTo.ToString("yyyy-MM-dd");
                    ////    }

                    ////    TrApprenticeship.Visible = true;
                    ////}
                    ////else
                    ////{
                    ////    TrApprenticeship.Visible = false;
                    ////}


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ExperiencedIn"].ToString()) ||
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["ExperienceEmployerName"].ToString()))
                    {

                        ddlExperience.Text = dt.Rows[0]["ExperiencedIn"].ToString().Trim();
                        ddlTrainingUnder.Text = dt.Rows[0]["TrainingUnder"].ToString();
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
                        ddlExperience1.Text = dt.Rows[0]["ExperiencedIn1"].ToString();
                        ddlTrainingUnder1.Text = dt.Rows[0]["TrainingUnder1"].ToString();
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

                        ddlExperience2.Text = dt.Rows[0]["ExperiencedIn2"].ToString();
                        ddlTrainingUnder2.Text = dt.Rows[0]["TrainingUnder2"].ToString();

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
                        ddlExperience3.Text = dt.Rows[0]["ExperiencedIn3"].ToString();
                        ddlTrainingUnder3.Text = dt.Rows[0]["TrainingUnder3"].ToString();

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
                        ddlExperience4.Text = dt.Rows[0]["ExperiencedIn4"].ToString();
                        ddlTrainingUnder4.Text = dt.Rows[0]["TrainingUnder4"].ToString();

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

                        ddlExperience5.Text = dt.Rows[0]["ExperiencedIn5"].ToString();
                        ddlTrainingUnder5.Text = dt.Rows[0]["TrainingUnder5"].ToString();

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
                        ddlExperience6.Text = dt.Rows[0]["ExperiencedIn6"].ToString();
                        ddlTrainingUnder6.Text = dt.Rows[0]["TrainingUnder6"].ToString();

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
                        ddlExperience7.Text = dt.Rows[0]["ExperiencedIn7"].ToString();
                        ddlTrainingUnder7.Text = dt.Rows[0]["TrainingUnder7"].ToString();

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

                        ddlExperience8.Text = dt.Rows[0]["ExperiencedIn8"].ToString();
                        ddlTrainingUnder8.Text = dt.Rows[0]["TrainingUnder8"].ToString();

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
                        ddlExperience9.Text = dt.Rows[0]["ExperiencedIn9"].ToString();
                        ddlTrainingUnder9.Text = dt.Rows[0]["TrainingUnder9"].ToString();

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

                    TotalExperience.Text = dt.Rows[0]["TotalExperience"].ToString();




                    string RetiredEngineer = dt.Rows[0]["RetiredEngineer"].ToString();
                    if (RetiredEngineer == "Yes")
                    {
                        RetiredEmployee.Visible = true;
                        RadioButtonList1.SelectedValue = "0";
                        EmployerName2.Text = dt.Rows[0]["RetiredEmployerName"].ToString();
                        Description2.Text = dt.Rows[0]["RetiredPostDescription"].ToString();
                        From2.Text = dt.Rows[0]["RetiredFromDate"].ToString();
                        To2.Text = dt.Rows[0]["RetiredToDate"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["RetiredFromDate"].ToString(), out DateTime RetiredFromDate))
                        {
                            From2.Text = RetiredFromDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(dt.Rows[0]["RetiredToDate"].ToString(), out DateTime RetiredToDate))
                        {
                            To2.Text = RetiredToDate.ToString("yyyy-MM-dd");
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
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
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