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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
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
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/"));
                        }
                        string ext = AnnualInsurancePolicy.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/AnnualInsurancePolicy/";
                        string filePathInfo2 = "";
                        string filename = "AnnualInsurancePolicy" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualInsurancePolicy/" + filename);
                        AnnualInsurancePolicy.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl = path + filename;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please only Upload pdf formate of AnnualInsurancePolicy')", true);
                        //showAlert = true;
                        return;
                    }
                }

                if (CopyChallanTreasury.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(CopyChallanTreasury.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {

                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/"));
                        }
                        string ext = CopyChallanTreasury.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/CopyChallanTreasury/";
                        string filename = "CopyChallanTreasury" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/CopyChallanTreasury/" + filename);
                        CopyChallanTreasury.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl1 = path + filename;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload only pdf formate of ChallanTreasury')", true);
                        //showAlert = true;
                        return;
                    }
                }

                if (AnnualMaintenanceContract.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(AnnualMaintenanceContract.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {

                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/"));
                        }
                        string ext = AnnualMaintenanceContract.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/AnnualMaintenanceContract/";
                        string filename = "AnnualMaintenanceContract" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/AnnualMaintenanceContract/" + filename);
                        AnnualMaintenanceContract.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl2 = path + filename;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload only pdf formate of AnnualMaintenanceContract')", true);
                        // showAlert = true;
                        return;
                    }
                }

                if (SafetyCertificate.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(SafetyCertificate.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/"));
                        }

                        string ext = SafetyCertificate.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/SafetyCertificate/";
                        string filename = "SafetyCertificate" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/SafetyCertificate/" + filename);
                        SafetyCertificate.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl3 = path + filePathInfo2;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload only pdf formate of SafetyCertificate')", true);
                        //showAlert = true;
                        return;
                    }

                }

                if (FormA.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(FormA.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/"));
                        }
                        string ext = FormA.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/FormA/";
                        string filename = "FormA" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormA/" + filename);
                        FormA.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl4 = path + filePathInfo2;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload only pdf formate of FormA')", true);
                        //showAlert = true;
                        return;
                    }
                }

                if (FormB.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(FormB.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/"));
                        }
                        string ext = FormA.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/FormB/";
                        string filename = "FormB" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormB/" + filename);
                        FormB.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl5 = path + filePathInfo2;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Showlert", "alert('Please upload only pdf formate of FormB')", true);
                        //showAlert = true;
                        return;
                    }
                }

                if (FormC.PostedFile.FileName.Length > 0)
                {
                    FileName = Path.GetFileName(FormC.PostedFile.FileName);
                    if (Path.GetExtension(FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {


                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/"));
                        }
                        string ext = FormA.PostedFile.FileName.Split('.')[1];
                        string path = "";
                        path = "/Attachment/" + REID + "/FormC/";
                        string filename = "FormA" + DateTime.Now.ToString("yyyyMMddHHmmssFF") + "." + ext;
                        string filePathInfo2 = "";
                        filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + REID + "/FormC/" + filename);
                        FormC.PostedFile.SaveAs(filePathInfo2);
                        flpPhotourl6 = path + filePathInfo2;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload only pdf formate of FormC')", true);
                        //showAlert = true;
                        return;
                    }
                }

                CEI.LiftEsculatorDocument(REID, flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert('Documents are Uploaded successfull')", true);

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}