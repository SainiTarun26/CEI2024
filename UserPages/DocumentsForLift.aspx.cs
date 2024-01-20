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
    public partial class DocumentsForLift : System.Web.UI.Page
    {
        string REID = string.Empty;
        CEI CEI = new CEI();
        bool showAlert = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["LiftId"] != null)
                {

                }
                else
                {

                }
            }
            catch (Exception)
            {
                Response.Redirect("/Login.aspx");
            }
        }


        public bool IsValidPdforNot()
        {
            string[] fileuploadcontrol = { "AnnualInsurancePolicy", "CopyChallanTreasury", "AnnualMaintenanceContract", "SafetyCertificate", "FormA", "FormB", "FormC" };

            bool allFilesArePDF = true;
            int maxFileSize = 2 * 1024 * 1024;

            foreach (string controlName in fileuploadcontrol)
            {
                var fileUploadControl = Request.Files[controlName];

                if (fileUploadControl != null && fileUploadControl.ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(fileUploadControl.FileName);

                    if (fileExtension.ToLower() != ".pdf" || fileUploadControl.ContentLength > maxFileSize)
                    {
                        allFilesArePDF = false;
                        break;
                    }
                }
            }
            return allFilesArePDF;
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["LiftId"]) != null || Convert.ToString(Session["LiftId"]) != "")
                {

                    if (IsValidPdforNot())
                    {

                        REID = Session["LiftId"].ToString();
                        string FileName = string.Empty;
                        string flpPhotourl = string.Empty;
                        string flpPhotourl1 = string.Empty;
                        string flpPhotourl2 = string.Empty;
                        string flpPhotourl3 = string.Empty;
                        string flpPhotourl4 = string.Empty;
                        string flpPhotourl6 = string.Empty;
                        string flpPhotourl5 = string.Empty;

                        if (AnnualInsurancePolicy.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(AnnualInsurancePolicy.PostedFile.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/"));
                            }
                            string ext = AnnualInsurancePolicy.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/AnnualInsurancePolicy/";
                            string filePathInfo2 = "";
                            string filename = "AnnualInsurancePolicy" + "." + "pdf";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/" + filename);
                            //string existingFilePath = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            AnnualInsurancePolicy.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl = path + filename;

                        }

                        if (CopyChallanTreasury.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(CopyChallanTreasury.PostedFile.FileName);
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/"));
                            }
                            string ext = CopyChallanTreasury.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/CopyChallanTreasury/";
                            string filename = "CopyChallanTreasury" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            CopyChallanTreasury.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl1 = path + filename;
                        }

                        if (AnnualMaintenanceContract.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(AnnualMaintenanceContract.PostedFile.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/"));
                            }
                            string ext = AnnualMaintenanceContract.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/AnnualMaintenanceContract/";
                            string filename = "AnnualMaintenanceContract" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            AnnualMaintenanceContract.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl2 = path + filename;
                        }

                        if (SafetyCertificate.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(SafetyCertificate.PostedFile.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/"));
                            }

                            string ext = SafetyCertificate.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/SafetyCertificate/";
                            string filename = "SafetyCertificate" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            SafetyCertificate.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl3 = path + filename;

                        }

                        if (FormA.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FormA.PostedFile.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/"));
                            }
                            string ext = FormA.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/FormA/";
                            string filename = "FormA" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            FormA.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl4 = path + filename;

                        }

                        if (FormB.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FormB.PostedFile.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/"));
                            }
                            string ext = FormA.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/FormB/";
                            string filename = "FormB" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            FormB.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl5 = path + filename;
                        }

                        if (FormC.PostedFile.FileName.Length > 0)
                        {
                            FileName = Path.GetFileName(FormC.PostedFile.FileName);
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/"));
                            }
                            string ext = FormA.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + REID + "/FormC/";
                            string filename = "FormA" + "." + "pdf";
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/" + filename);
                            if (File.Exists(filePathInfo2))
                            {
                                File.Delete(filePathInfo2); // If the file exists, delete it
                            }
                            FormC.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl6 = path + filename;
                        }









                        int x = CEI.LiftEsculatorDocument(flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, REID);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert('Documents are Uploaded successfull')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert(Please select file in pdf formate and size must be less then 2Mb)", true);
                        Response.Redirect("/Login.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert(Please Login!!!!!!)", true);
                }


            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error Occured, please login again')", true);
                Response.Redirect("/Login.aspx");
                throw;
            }

        }
    }
}