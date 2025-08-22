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
    public partial class New_Registration_Information : System.Web.UI.Page
    {
        //Page created By Gurmeet 26-June-2025
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
                    txtApplyingFor.Text = dt.Rows[0]["ApplicationFor"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    txtgender.Text = dt.Rows[0]["Gender"].ToString();
                    txtNationailty.Text = dt.Rows[0]["Nationality"].ToString();
                    txtAadhar.Text = dt.Rows[0]["Aadhar"].ToString();
                    txtdob.Text = dt.Rows[0]["DOB"].ToString();
                    txtAge.Text = dt.Rows[0]["CalculatedAge"].ToString();                    
                    txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                    //txtpermanentAddress.Text = dt.Rows[0][""].ToString();

                    GridBindDocument(UserId);



                    txtUniversity.Text = dt.Rows[0]["UniversityName10th"].ToString();
                    txtPassingyear.Text = dt.Rows[0]["PassingYear10th"].ToString();
                    txtmarksObtained.Text = dt.Rows[0]["MarksObtained10th"].ToString();
                    txtmarksmax.Text = dt.Rows[0]["MarksMax10th"].ToString();
                    txtprcntg.Text = dt.Rows[0]["Percentage10th"].ToString();

                    txtExam1.Text = dt.Rows[0]["Name12ITIDiploma"].ToString();
                    if (!string.IsNullOrEmpty(txtExam1.Text))
                    {
                        Tr_Qualification2.Visible = true;
                        txtUniversity1.Text = dt.Rows[0]["UniversityName12thorITI"].ToString();
                        txtPassingyear1.Text = dt.Rows[0]["PassingYear12thorITI"].ToString();
                        txtmarksObtained1.Text = dt.Rows[0]["MarksObtained12thorITI"].ToString();
                        txtmarksmax1.Text = dt.Rows[0]["MarksMax12thorITI"].ToString();
                        txtprcntg1.Text = dt.Rows[0]["Percentage12thorITI"].ToString();
                    }
                    txtExam2.Text = dt.Rows[0]["NameofDiplomaDegree"].ToString();
                    if (!string.IsNullOrEmpty(txtExam2.Text))
                    {
                        Tr_Qualification3.Visible = true;
                        txtUniversity2.Text = dt.Rows[0]["UniversityNameDiplomaorDegree"].ToString();
                        txtPassingyear2.Text = dt.Rows[0]["PassingYearDiplomaorDegree"].ToString();
                        txtmarksObtained2.Text = dt.Rows[0]["MarksObtainedDiplomaorDegree"].ToString();
                        txtmarksmax2.Text = dt.Rows[0]["MarksMaxDiplomaorDegree"].ToString();
                        txtprcntg2.Text = dt.Rows[0]["PercentageDiplomaorDegree"].ToString();
                    }
                    txtExam3.Text = dt.Rows[0]["NameofDegree"].ToString();
                    if (!string.IsNullOrEmpty(txtExam3.Text))
                    {
                        DdlDegree.Visible = true;
                        txtUniversity3.Text = dt.Rows[0]["UniversityNamePG"].ToString();
                        txtPassingyear3.Text = dt.Rows[0]["PassingYearPG"].ToString();
                        txtmarksObtained3.Text = dt.Rows[0]["MarksObtainedPG"].ToString();
                        txtmarksmax3.Text = dt.Rows[0]["MarksMaxPG"].ToString();
                        txtprcntg3.Text = dt.Rows[0]["PercentagePG"].ToString();
                    }
                    txtExam4.Text = dt.Rows[0]["NameofMasters"].ToString();
                    if (!string.IsNullOrEmpty(txtExam4.Text))
                    {
                        DdlMasters.Visible = true;
                        txtUniversity4.Text = dt.Rows[0]["MastersUniversityName"].ToString();
                        txtPassingyear4.Text = dt.Rows[0]["MastersPassingYear"].ToString();
                        txtmarksObtained4.Text = dt.Rows[0]["MasterMarksObtained"].ToString();
                        txtmarksmax4.Text = dt.Rows[0]["MastersMarksMax"].ToString();
                        txtprcntg4.Text = dt.Rows[0]["MastersPercentage"].ToString();
                    }
                    string IsCertificateofCompetency = dt.Rows[0]["IsCertificateofCompetency"].ToString();
                    if (IsCertificateofCompetency == "Yes")
                    {
                        RadioButtonList2.SelectedValue = "0";
                        competency.Visible = true;
                        txtPermitNo.Text = dt.Rows[0]["PermitNo1"].ToString();
                        txtCategory.Text = dt.Rows[0]["CertificateofCompetency1"].ToString();
                        txtIssuingAuthority.Text = dt.Rows[0]["IssuingAuthority1"].ToString();
                        txtIssuingDate.Text = dt.Rows[0]["IssueDate1"].ToString();
                        txtExpiryDate.Text = dt.Rows[0]["ExpiryDate1"].ToString();
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
                        txtPermanentEmployerName.Text = dt.Rows[0]["EmployerName"].ToString();
                        txtPermanentDescription.Text = dt.Rows[0]["PostDescription"].ToString();
                        txtPermanentFrom.Text = dt.Rows[0]["FromDate"].ToString();
                        txtPermanentTo.Text = dt.Rows[0]["ToDate"].ToString();
                        //txtExpiryDate.Text = dt.Rows[0][""].ToString();
                    }
                    else
                    {
                        RadioButtonList3.SelectedValue = "1";
                    }


                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticePostDescription"].ToString()) ||
                      !string.IsNullOrWhiteSpace(dt.Rows[0]["ApprenticenameofEmployer"].ToString()))
                    {
                        //txtApprenticeship.Text = dt.Rows[0]["ApprenticeExperience"].ToString().Trim();
                        txtAppretinceExperience.Text = dt.Rows[0]["ApprenticeTrainingUnder"].ToString().Trim();
                        txtApprenticeshipEmployer.Text = dt.Rows[0]["ApprenticenameofEmployer"].ToString();
                        txtApprenticesPost.Text = dt.Rows[0]["ApprenticePostDescription"].ToString();

                        //if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceFromDate"].ToString(), out DateTime apprenticeFrom))
                        //{
                        //    Apprenticesdatefrom.Text = apprenticeFrom.ToString("yyyy-MM-dd");
                        //}

                        //if (DateTime.TryParse(dt.Rows[0]["ApprenticeExperienceToDate"].ToString(), out DateTime apprenticeTo))
                        //{
                        //    Apprenticesdateto.Text = apprenticeTo.ToString("yyyy-MM-dd");
                        //}

                        Apprenticesdatefrom.Text = dt.Rows[0]["ApprenticeExperienceFromDate"].ToString();
                        Apprenticesdateto.Text = dt.Rows[0]["ApprenticeExperienceToDate"].ToString();
                        TrApprenticeship.Visible = true;
                    }
                    else
                    {
                        TrApprenticeship.Visible = false;
                    }

                    txtExperience.Text = dt.Rows[0]["ExperiencedIn"].ToString();
                    txtTrainingunder.Text = dt.Rows[0]["TrainingUnder"].ToString();
                    txtExperienceEmployer.Text = dt.Rows[0]["ExperienceEmployerName"].ToString();
                    txtPostDescription.Text = dt.Rows[0]["ExperiencePostDescription"].ToString();
                    txtExperienceFrom.Text = dt.Rows[0]["ExperienceFromDate"].ToString();
                    txtExperienceTo.Text = dt.Rows[0]["ExperienceToDate"].ToString();
                    txtExperience1.Text = dt.Rows[0]["ExperiencedIn1"].ToString();
                    txtTotalExperience.Text = dt.Rows[0]["TotalExperience"].ToString();
                    if (!string.IsNullOrEmpty(txtExperience1.Text))
                    {
                        Experience1.Visible = true;
                        txtTrainingunder1.Text = dt.Rows[0]["TrainingUnder1"].ToString();
                        txtExperienceEmployer1.Text = dt.Rows[0]["ExperienceEmployerName1"].ToString();
                        txtPostDescription1.Text = dt.Rows[0]["ExperiencePostDescription1"].ToString();
                        txtExperienceFrom1.Text = dt.Rows[0]["ExperienceFromDate1"].ToString();
                        txtExperienceTo1.Text = dt.Rows[0]["ExperienceToDate1"].ToString();
                    }
                    txtExperience2.Text = dt.Rows[0]["ExperiencedIn2"].ToString();
                    if (!string.IsNullOrEmpty(txtExperience2.Text))
                    {
                        Experience2.Visible = true;
                        txtTrainingunder2.Text = dt.Rows[0]["TrainingUnder2"].ToString();
                        txtExperienceEmployer2.Text = dt.Rows[0]["ExperienceEmployerName2"].ToString();
                        txtPostDescription2.Text = dt.Rows[0]["ExperiencePostDescription2"].ToString();
                        txtExperienceFrom2.Text = dt.Rows[0]["ExperienceFromDate2"].ToString();
                        txtExperienceTo2.Text = dt.Rows[0]["ExperienceToDate2"].ToString();
                    }
                    txtExperience3.Text = dt.Rows[0]["ExperiencedIn3"].ToString();
                    if (!string.IsNullOrEmpty(txtExperience3.Text))
                    {
                        Experience3.Visible = true;
                        txtTrainingunder3.Text = dt.Rows[0]["TrainingUnder3"].ToString();
                        txtExperienceEmployer3.Text = dt.Rows[0]["ExperienceEmployerName3"].ToString();
                        txtPostDescription3.Text = dt.Rows[0]["ExperiencePostDescription3"].ToString();
                        txtExperienceFrom3.Text = dt.Rows[0]["ExperienceFromDate3"].ToString();
                        txtExperienceTo3.Text = dt.Rows[0]["ExperienceToDate3"].ToString();
                    }
                    txtExperience4.Text = dt.Rows[0]["ExperiencedIn4"].ToString();
                    if (!string.IsNullOrEmpty(txtExperience4.Text))
                    {
                        Experience4.Visible = true;
                        txtTrainingunder4.Text = dt.Rows[0]["TrainingUnder4"].ToString();
                        txtExperienceEmployer4.Text = dt.Rows[0]["ExperienceEmployerName4"].ToString();
                        txtPostDescription4.Text = dt.Rows[0]["ExperiencePostDescription4"].ToString();
                        txtExperienceFrom4.Text = dt.Rows[0]["ExperienceFromDate4"].ToString();
                        txtExperienceTo4.Text = dt.Rows[0]["ExperienceToDate4"].ToString();
                    }



                    string RetiredEngineer = dt.Rows[0]["RetiredEngineer"].ToString();
                    if (RetiredEngineer == "Yes")
                    {
                        RetiredEmployee.Visible = true;
                        RadioButtonList1.SelectedValue = "0";
                        txtEmployerName2.Text = dt.Rows[0]["RetiredEmployerName"].ToString();
                        txtDescription2.Text = dt.Rows[0]["RetiredPostDescription"].ToString();
                        txtFrom2.Text = dt.Rows[0]["RetiredFromDate"].ToString();
                        txtTo2.Text = dt.Rows[0]["RetiredToDate"].ToString();
                    }
                    else
                    {
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