using CEI_PRoject;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;

namespace CEIHaryana.UserPages
{
    public partial class Documents : System.Web.UI.Page
    {
        string DOB = string.Empty;
        string REID = string.Empty;
        string userid = string.Empty;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null || Session["WiremanId"] != null || Request.Cookies["WiremanId"] != null)
                    {
                        //if (Session["CandidateAge"] != null)
                        //{
                        //    int candidateAge = (int)Session["CandidateAge"];
                        //    string radioButtonSelection = Session["RadioButtonSelection"].ToString();
                        //    if (candidateAge > 55)
                        //    {
                        //        Medicalfitness.Visible = true;
                        //    }
                        //    else if (radioButtonSelection == "Yes")
                        //    {
                        //        Retired.Visible = true;
                        //    }
                        //}
                        //Medicalfitness.Visible = false;
                        //Retired.Visible = false;

                        if (Session["WiremanId"] != null)
                        {
                            userid = Session["WiremanId"].ToString();
                        }
                        else
                        {
                            userid = Session["SupervisorID"].ToString();
                        }

                        DataSet result = CEI.ToCalculateAge(userid);

                        if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                        {
                            string DOB = result.Tables[0].Rows[0]["DOB"].ToString();

                            if (!string.IsNullOrEmpty(DOB) && DateTime.TryParse(DOB, out DateTime birthDate))
                            {
                                // Calculate the age
                                TimeSpan ageTimeSpan = DateTime.Now - birthDate;
                                int years = ageTimeSpan.Days / 365;

                                if (years > 55)
                                {
                                    Medicalfitness.Visible = true;
                                    Retired.Visible = true;
                                }
                                else
                                {
                                    Medicalfitness.Visible = false;
                                    Retired.Visible = false;
                                }
                            }
                            else
                            {
                                Response.Redirect("/Login.aspx");
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
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
                //hdnId.Value = REID;
                string FileName = string.Empty;
                string flpPhotourl = string.Empty;
                string flpPhotourl1 = string.Empty;
                string flpPhotourl2 = string.Empty;
                string flpPhotourl3 = string.Empty;
                string flpPhotourl4 = string.Empty;
                string flpPhotourl6 = string.Empty;
                string flpPhotourl5 = string.Empty;
                string flpPhotourl7 = string.Empty;
                string flpPhotourl8 = string.Empty;
                string flpPhotourl9 = string.Empty;
                int maxFileSize = 2 * 1024 * 1024;
                if (Photo.PostedFile.FileName.Length > 0)
                {
                    if (Photo.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Photo document must be a PDF file with a maximum size of 2MB.')", true);
                    return;
                }
                FileName = Path.GetFileName(Photo.PostedFile.FileName);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/"));
                }
                string ext = Path.GetExtension(Photo.PostedFile.FileName).ToLower();
                if (ext != ".pdf")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Photo document must be a PDF file.')", true);
                    return;
                }

                string path = "/Attachment/" + REID + "/Photo/";

                string fileName = "Photo" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/" + fileName);
                Photo.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl = path + fileName;
                }
                if (Signatur.PostedFile.FileName.Length > 0)
                {
                    if (Signatur.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Signatur document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Signatur.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/"));
                    }

                    string ext = Path.GetExtension(Signatur.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Signatur document must be a PDF file.')", true);
                        return;
                    }
                    string path = "/Attachment/" + REID + "/Signatur/";
                    string fileName = "Signatur" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";                  
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/" + fileName);
                    Signatur.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl9 = path + fileName;

                }
                if (fileInput.PostedFile.FileName.Length > 0)
                {
                    if (fileInput.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Matriculation Certifiacte document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(fileInput.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/"));
                    }

                    string ext = Path.GetExtension(fileInput.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Matriculation Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    //string ext = fileInput.PostedFile.FileName.Split('.')[1];
                    
                    string path = "/Attachment/" + REID + "/MatriculationCertifiacte/";
                    string fileName = "MatriculationCertifiacte " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/" + fileName);
                    fileInput.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl = path + fileName;
                }

                if (Residence.PostedFile.FileName.Length > 0)
                {
                    if (Residence.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Residence document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Residence.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/"));
                    }
                    string ext = Path.GetExtension(Residence.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Residence document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Residence.PostedFile.FileName.Split('.')[1];

                    string path = "/Attachment/" + REID + "/ResidenceProof/";
                    string fileName = "ResidenceProof " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/" + fileName);
                    Residence.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl1 = path + fileName;
                }

                if (Identit.PostedFile.FileName.Length > 0)
                {
                    if (Identit.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('IdentityProof document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Identit.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/"));
                    }

                    string ext = Path.GetExtension(Identit.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('IdentityProof document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Identit.PostedFile.FileName.Split('.')[1];

                    string path = "/Attachment/" + REID + "/IdentityProof/";
                    string fileName = "IdentityProof " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/" + fileName);
                    Identit.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl2 = path + fileName;
                }
                if (DegreeDiploma.PostedFile.FileName.Length > 0)
                {
                    if (DegreeDiploma.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Degree Proof document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(DegreeDiploma.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/"));
                    }

                    string ext = Path.GetExtension(DegreeDiploma.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Degree Proof document Certifiacte must be a PDF file.')", true);
                        return;
                    }

                    //string ext = DegreeDiploma.PostedFile.FileName.Split('.')[1];
                    
                    string path = "/Attachment/" + REID + "/DegreeProof/";
                    string fileName = "DegreeProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/" + fileName);
                    DegreeDiploma.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl3 = path + fileName;
                }
                if (Experience.PostedFile.FileName.Length > 0)
                {
                    if (Experience.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Experience Proof document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Experience.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/"));
                    }

                    string ext = Path.GetExtension(Experience.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Experience Proof document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Experience.PostedFile.FileName.Split('.')[1];

                    string path = "/Attachment/" + REID + "/ExperienceProof/";
                    string fileName = "ExperienceProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                   
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/" + fileName);
                    Experience.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl4 = path + fileName;
                }

                if (Signature.PostedFile.FileName.Length > 0)
                {
                    if (Signature.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Signature Proof document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Signature.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/"));
                    }

                    string ext = Path.GetExtension(Signature.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Signature Proof document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Signature.PostedFile.FileName.Split('.')[1];

                    string path = "/Attachment/" + REID + "/SignatureProof/";
                    string fileName = "SignatureProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/" + fileName);
                    Signature.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl5 = path + fileName;
                }
                if (Medicalfitness.Visible == true)
                {
                    if (MedicalCertificate.PostedFile.FileName.Length > 0)
                    {
                        if (MedicalCertificate.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Medical Certificate Proof document must be a PDF file with a maximum size of 2MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(MedicalCertificate.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/"));
                        }

                        string ext = Path.GetExtension(MedicalCertificate.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('MedicalCertificate Proof document Certifiacte must be a PDF file.')", true);
                            return;
                        }
                        // string ext = MedicalCertificate.PostedFile.FileName.Split('.')[1];

                        string path = "/Attachment/" + REID + "/MedicalCertificate/";
                        string fileName = "MedicalCertificate  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                       
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/" + fileName);
                        MedicalCertificate.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl6 = path + fileName;
                    }
                }
                if (Retired.Visible == true)
                {
                    if (fileRetired.PostedFile.FileName.Length > 0)
                    {
                        if (fileRetired.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('RetirementProof Certificate Proof document must be a PDF file with a maximum size of 2MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(fileRetired.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/"));
                        }


                        string ext = Path.GetExtension(fileRetired.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('RetirementProof Proof document Certifiacte must be a PDF file.')", true);
                            return;
                        }
                        //string ext = fileRetired.PostedFile.FileName.Split('.')[1];

                        string path = "/Attachment/" + REID + "/RetirementProof/";
                        string fileName = "RetirementProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                        
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/" + fileName);
                        fileRetired.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl7 = path + fileName;
                    }

                }
                int ivalue = CEI.UserDocuments(REID, flpPhotourl8, flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl9, flpPhotourl6, flpPhotourl7);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Documents Added Successfully !!!')", true);
                if (Session["WiremanId"] == null)
                {
                    Response.Redirect("/Supervisor/IntimationData.aspx", false);
                }
                else
                {
                    Response.Redirect("/Wiremen/WiremenDashboard.aspx", false);
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Back"] = "back";
                Response.Redirect("Qualification.aspx", false);
            }
            catch (Exception)
            {

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
    }
}