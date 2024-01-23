using CEI_PRoject;
using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace CEIHaryana.UserPages
{
    public partial class Documents : System.Web.UI.Page
    {
        string REID = string.Empty;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null || Session["WiremanId"] != null || Request.Cookies["WiremanId"] != null)
                    {
                        if (Session["CandidateAge"] != null)
                        {
                            int candidateAge = (int)Session["CandidateAge"];
                            string radioButtonSelection = Session["RadioButtonSelection"].ToString();
                            if (candidateAge > 55)
                            {
                                Medicalfitness.Visible = true;
                            }
                            else if (radioButtonSelection == "Yes")
                            {
                                Retired.Visible = true;

                            }


                        }

                        Medicalfitness.Visible = false;
                        Retired.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
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
                if (Photo.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Photo.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/"));
                    }

                    string ext = Photo.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/Photo/";
                    string fileName = "Photo" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Photo/" + fileName);
                    Photo.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl8 = path + fileName;
                }
                if (Signatur.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Signatur.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/"));
                    }

                    string ext = Signatur.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/Signature/";
                    string fileName = "Signature" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Signature/" + fileName);
                    Signatur.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl9 = path + fileName;

                }
                if (fileInput.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(fileInput.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/"));
                    }

                    string ext = fileInput.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/MatriculationCertifiacte/";
                    string fileName = "MatriculationCertifiacte " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MatriculationCertifiacte/" + fileName);
                    fileInput.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl = path + fileName;
                }

                if (Residence.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Residence.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/"));
                    }

                    string ext = Residence.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/ResidenceProof/";
                    string fileName = "ResidenceProof " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ResidenceProof/" + fileName);
                    Residence.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl1 = path + fileName;
                }

                if (Identit.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Identit.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/"));
                    }

                    string ext = Identit.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/IdentityProof/";
                    string fileName = "IdentityProof " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IdentityProof/" + fileName);
                    Identit.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl2 = path + fileName;
                }
                if (DegreeDiploma.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(DegreeDiploma.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/"));
                    }

                    string ext = DegreeDiploma.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/DegreeProof/";
                    string fileName = "DegreeProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/DegreeProof/" + fileName);
                    DegreeDiploma.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl3 = path + fileName;
                }
                if (Experience.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Experience.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/"));
                    }

                    string ext = Experience.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/ExperienceProof/";
                    string fileName = "ExperienceProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/ExperienceProof/" + fileName);
                    Experience.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl4 = path + fileName;
                }

                if (Signature.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(Signature.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/"));
                    }

                    string ext = Signature.PostedFile.FileName.Split('.')[1];
                    string path = "";
                    path = "/Attachment/" + REID + "/SignatureProof/";
                    string fileName = "SignatureProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    string filePathInfo2 = "";
                    filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SignatureProof/" + fileName);
                    Signature.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl5 = path + fileName;
                }
                if (Medicalfitness.Visible == true)
                {
                    if (MedicalCertificate.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(MedicalCertificate.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/"));
                        }

                        string ext = MedicalCertificate.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/MedicalCertificate/";
                        string fileName = "MedicalCertificate  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/MedicalCertificate/" + fileName);
                        MedicalCertificate.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl6 = path + fileName;
                    }
                }
                if (Retired.Visible == true)
                {
                    if (fileRetired.PostedFile.FileName.Length > 0)
                    {
                        FileName = Path.GetFileName(fileRetired.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/"));
                        }

                        string ext = fileRetired.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/RetirementProof/";
                        string fileName = "RetirementProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/RetirementProof/" + fileName);
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