using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class DocumentsForContractor : System.Web.UI.Page
    {
        string REID = string.Empty;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Session["ContractorID"] != null)
                    //{

                    //}
                    //else
                    //{
                    //    Response.Redirect("/Login.aspx");
                    //}

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
                if (Session["ContractorID"] != null)
                {
                    REID = Session["ContractorID"].ToString();
                }
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
                string flpPhotourl10 = string.Empty;
                int maxFileSize = 2 * 1024 * 1024; // 2MB in bytes
                if (IncomeTax.PostedFile.FileName.Length > 0)
                {
                    if (IncomeTax.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Income Tax document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }

                    FileName = Path.GetFileName(IncomeTax.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IncomeTax/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IncomeTax/"));
                    }

                    string ext = Path.GetExtension(IncomeTax.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Income Tax document must be a PDF file.')", true);
                        return;
                    }

                    string path = "/Attachment/" + REID + "/IncomeTax/";

                    string fileName = "IncomeTax" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/IncomeTax/" + fileName);
                    IncomeTax.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl = path + fileName;


                }
                if (Pan.PostedFile.FileName.Length > 0)
                {
                    if (Pan.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Pan Card document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Pan.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Pan/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Pan/"));
                    }
                    string ext = Path.GetExtension(Pan.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Pan Card document must be a PDF file.')", true);
                        return;
                    }

                    string path = "/Attachment/" + REID + "/Pan/";
                    string fileName = "Pan" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";

                    //string ext = Pan.PostedFile.FileName.Split('.')[1];                

                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Pan/" + fileName);
                    Pan.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl1 = path + fileName;

                }
                if (Aadhaar.PostedFile.FileName.Length > 0)
                {
                    if (Aadhaar.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Aadhaar card must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Aadhaar.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Aadhaar/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Aadhaar/"));
                    }
                    string ext = Path.GetExtension(Aadhaar.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Aadhaar card must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Aadhaar.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/Aadhaar/";
                    string fileName = "Aadhaar " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/Aadhaar/" + fileName);
                    Aadhaar.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl2 = path + fileName;
                }

                if (Age.PostedFile.FileName.Length > 0)
                {
                    if (Age.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Age Certificate must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Age.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AgeProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AgeProof/"));
                    }

                    string ext = Path.GetExtension(Age.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Age Certificate must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Age.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/AgeProof/";
                    string fileName = "AgeProof " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AgeProof/" + fileName);
                    Age.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl3 = path + fileName;
                }

                if (Calibration.PostedFile.FileName.Length > 0)
                {
                    if (Calibration.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Calibration Certificate must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Calibration.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CalibrationCertificate/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CalibrationCertificate/"));
                    }
                    string ext = Path.GetExtension(Calibration.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Calibration Certificate must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Calibration.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/CalibrationCertificate/";
                    string fileName = "CalibrationCertificate " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CalibrationCertificate/" + fileName);
                    Calibration.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl4 = path + fileName;
                }
                if (Annexure.PostedFile.FileName.Length > 0)
                {
                    if (Annexure.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Annexure 3 & 5 must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Annexure.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnexureProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnexureProof/"));
                    }
                    string ext = Path.GetExtension(Annexure.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Annexure 3 & 5 must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Annexure.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/AnnexureProof/";
                    string fileName = "AnnexureProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnexureProof/" + fileName);
                    Annexure.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl5 = path + fileName;
                }
                if (Status.PostedFile.FileName.Length > 0)
                {
                    if (Status.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('status of the firm/company must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(Status.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/StatusProof/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/StatusProof/"));
                    }
                    string ext = Path.GetExtension(Status.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('status of the firm/company must be a PDF file.')", true);
                        return;
                    }
                    //string ext = Status.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/StatusProof/";
                    string fileName = "StatusProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/StatusProof/" + fileName);
                    Status.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl6 = path + fileName;
                }

                if (WorkOutHry.PostedFile.FileName.Length > 0)
                {
                    if (WorkOutHry.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('works carried out in Haryana must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(WorkOutHry.PostedFile.FileName);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkOutHry/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkOutHry/"));
                    }
                    string ext = Path.GetExtension(WorkOutHry.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('works carried out in Haryana must be a PDF file.')", true);
                        return;
                    }
                    //string ext = WorkOutHry.PostedFile.FileName.Split('.')[1];
                    string path = "/Attachment/" + REID + "/WorkOutHry/";
                    string fileName = "WorkOutHry  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkOutHry/" + fileName);
                    WorkOutHry.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl7 = path + fileName;
                }
                if (WorkPermitted.Visible == true)
                {
                    if (WorkPermitted.PostedFile.FileName.Length > 0)
                    {
                        if (WorkPermitted.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of works permitted must be a PDF file with a maximum size of 2MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(WorkPermitted.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkPermittedCertificate/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkPermittedCertificate/"));
                        }
                        string ext = Path.GetExtension(WorkPermitted.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Details of works permitted must be a PDF file.')", true);
                            return;
                        }
                        //string ext = WorkPermitted.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + REID + "/WorkPermittedCertificate/";
                        string fileName = "WorkPermittedCertificate  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/WorkPermittedCertificate/" + fileName);
                        WorkPermitted.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl8 = path + fileName;
                    }
                }
                if (CopyOfLibrary.Visible == true)
                {
                    if (CopyOfLibrary.PostedFile.FileName.Length > 0)
                    {
                        if (CopyOfLibrary.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Elibrary/library asper ANNEXURE 2 must be a PDF file with a maximum size of 2MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(CopyOfLibrary.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyOfLibraryProof/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyOfLibraryProof/"));
                        }
                        string ext = Path.GetExtension(CopyOfLibrary.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Elibrary/library asper ANNEXURE 2 must be a PDF file.')", true);
                            return;
                        }
                        //string ext = CopyOfLibrary.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + REID + "/CopyOfLibraryProof/";
                        string fileName = "CopyOfLibraryProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyOfLibraryProof/" + fileName);
                        CopyOfLibrary.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl9 = path + fileName;
                    }

                }
                if (GrantedLicense.Visible == true)
                {
                    if (GrantedLicense.PostedFile.FileName.Length > 0)
                    {
                        if (GrantedLicense.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Previously Granted Contractor License must be a PDF file with a maximum size of 2MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(GrantedLicense.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/GrantedLicenseProof/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/GrantedLicenseProof/"));
                        }
                        string ext = Path.GetExtension(GrantedLicense.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Copy of Previously Granted Contractor License must be a PDF file.')", true);
                            return;
                        }
                        //string ext = GrantedLicense.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + REID + "/GrantedLicenseProof/";
                        string fileName = "GrantedLicenseProof  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/GrantedLicenseProof/" + fileName);
                        GrantedLicense.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl10 = path + fileName;
                    }

                }
                CEI.DocumentsForContactor(flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8, flpPhotourl9, flpPhotourl10, REID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Documents Added Successfully !!!')", true);


                Response.Redirect("/Contractor/Work_Intimation.aspx", false);
            }
            catch (Exception ex) { }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }
    }
}