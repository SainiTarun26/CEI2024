using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CEI_PRoject;
using iText.Forms.Form.Element;

namespace CEIHaryana.Supervisor
{
    public partial class Renewal_Certificate_Competency : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string userID = "";
        string Category = "";
        //page created by kalpana 18-Aug-2025
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["SupervisorID"] = "EPH-5030";
            ////EPH-4929
            //Session["SupervisorID"] = "EPH-4929";
            //Category = "Supervisor";
            //userID = Session["SupervisorID"].ToString();
            ////Session["SupervisorID"] = "CPH-3188";
            //GetSupervisorDetails();

            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        Category = "Supervisor";
                        userID = Session["SupervisorID"].ToString();
                        GetSupervisorDetails(userID);
                    }
                    else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        Category = "Wireman";
                        userID = Session["WiremanId"].ToString();
                        GetSupervisorDetails(userID);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        public void GetSupervisorDetails(string userID)
        {
            //string UserID = Session["SupervisorID"].ToString();
            DataTable dt = new DataTable();
            dt = CEI.GetSuperviserDetailsforRenewal(userID);
            txtname.Text = dt.Rows[0]["Name"].ToString();
            txtage.Text = dt.Rows[0]["Age"].ToString();
            string age = txtage.Text.ToString();
            int ageValue;
            if (int.TryParse(age, out ageValue))
            {
                if (ageValue >= 55)
                {
                    Ifage55.Visible = true;
                    MedicalCertificate.Visible = true;
                }
                else
                {
                    Ifage55.Visible = false;
                    MedicalCertificate.Visible = false;
                }
            }
            else
            {
                Ifage55.Visible = false;
            }

            txtage55.Text = dt.Rows[0]["DateTurned55"].ToString();
            txtaddress.Text = dt.Rows[0]["Address"].ToString();
            txtcertificateno.Text = dt.Rows[0]["Certificate"].ToString();
            txtexpirydate.Text = dt.Rows[0]["DateofExpiry"].ToString();
            int belated = Convert.ToInt32(dt.Rows[0]["BelatedRenewal"]);
            if (belated == 1)
            {
                rblbelated.SelectedValue = "1";
                days.Visible = true;
            }
            else
            {
                rblbelated.SelectedValue = "0";
                days.Visible = false;
            }
            txtdays.Text = dt.Rows[0]["NoOfDays"].ToString();
            if (dt.Rows[0]["AnyContractor"].ToString() == "No")
            {
                NameContractor.Visible = false;
                LicensenContractor.Visible = false;
                AddressContractor.Visible = false;
            }
            else
            {

                NameContractor.Visible = true;
                LicensenContractor.Visible = true;
                AddressContractor.Visible = true;
                txtNameofEmployer.Text = dt.Rows[0]["ContractorName"].ToString();
                txtNameofEmployer.ReadOnly = true;
                txtLicenseno.Text = dt.Rows[0]["Licence"].ToString();
                txtLicenseno.ReadOnly = true;
                txtaddressofEmployer.Text = dt.Rows[0]["ContractorAddress"].ToString();
                txtaddressofEmployer.ReadOnly = true;
            }
            //if (dt.Rows[0]["ContractorName"] != null)
            //{
            //}
        }



        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDeclaration.Checked == true && chkdeclaration2.Checked == true)
                {
                    string CreatedBy = userID;
                    string FileName = string.Empty;
                    string CertificateofCompetency = string.Empty;
                    string PresentworkingStatusfp = string.Empty;
                    string Undertakingfp = string.Empty;
                    string MedicalFitnessfp = string.Empty;
                    string Challanfp = string.Empty;
                    int maxFileSize = 1 * 1024 * 1024; // 1MB in bytes



                    if (Certificate.PostedFile.ContentLength > 0)
                    {
                        if (Certificate.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Certificate must be a PDF file with a maximum size of 1MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(Certificate.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateofCompetency/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateofCompetency/"));
                        }

                        string ext = Path.GetExtension(Certificate.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('  Certificate must be a PDF file.')", true);
                            return;
                        }
                        //string ext = Age.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateofCompetency/";
                        string fileName = "CertificateofCompetency " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateofCompetency/" + fileName);
                        Certificate.PostedFile.SaveAs(filePathInfo2);
                        CertificateofCompetency = path + fileName;

                    }

                    if (Challan.PostedFile.FileName.Length > 0)
                    {
                        if (Challan.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Challan must be a PDF file with a maximum size of 1MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(Challan.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Challan/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Challan/"));
                        }
                        string ext = Path.GetExtension(Challan.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Challan must be a PDF file.')", true);
                            return;
                        }
                        //string ext = Annexure.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + "/Renewal/" + CreatedBy + "/Challan/";
                        string fileName = "Challan  " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Challan/" + fileName);
                        Challan.PostedFile.SaveAs(filePathInfo2);
                        Challanfp = path + fileName;
                    }

                    if (MedicalCertificate.Visible == true)
                    {
                        if (MedicalFitness.PostedFile.ContentLength > 0)
                        {
                            if (MedicalFitness.PostedFile.ContentLength > maxFileSize)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Certificate must be a PDF file with a maximum size of 1MB.')", true);
                                return;
                            }
                            FileName = Path.GetFileName(MedicalFitness.PostedFile.FileName);
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateMedicalFitness/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateMedicalFitness/"));
                            }

                            string ext = Path.GetExtension(MedicalFitness.PostedFile.FileName).ToLower();
                            if (ext != ".pdf")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('  Certificate must be a PDF file.')", true);
                                return;
                            }
                            //string ext = Age.PostedFile.FileName.Split('.')[1];
                            string path = "/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateMedicalFitness/";
                            string fileName = "CertificateMedicalFitness " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/CertificateMedicalFitness/" + fileName);
                            MedicalFitness.PostedFile.SaveAs(filePathInfo2);
                            MedicalFitnessfp = path + fileName;

                        }
                    }
                    if (Undertaking.PostedFile.ContentLength > 0)
                    {
                        if (Undertaking.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Certificate must be a PDF file with a maximum size of 1MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(Undertaking.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Undertaking/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Undertaking/"));
                        }

                        string ext = Path.GetExtension(Undertaking.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('  Undertaking must be a PDF file.')", true);
                            return;
                        }
                        //string ext = Age.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + "/Renewal/" + CreatedBy + "/Undertaking/";
                        string fileName = "Undertaking " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/Undertaking/" + fileName);
                        Undertaking.PostedFile.SaveAs(filePathInfo2);
                        Undertakingfp = path + fileName;

                    }

                    if (PresentworkingStatus.PostedFile.ContentLength > 0)
                    {
                        if (PresentworkingStatus.PostedFile.ContentLength > maxFileSize)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert(' Present working Status must be a PDF file with a maximum size of 1MB.')", true);
                            return;
                        }
                        FileName = Path.GetFileName(PresentworkingStatus.PostedFile.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/PresentworkingStatus/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/PresentworkingStatus/"));
                        }

                        string ext = Path.GetExtension(PresentworkingStatus.PostedFile.FileName).ToLower();
                        if (ext != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('  Present working Status must be a PDF file.')", true);
                            return;
                        }
                        //string ext = Age.PostedFile.FileName.Split('.')[1];
                        string path = "/Attachment/" + "/Renewal/" + CreatedBy + "/PresentworkingStatus/";
                        string fileName = "PresentworkingStatus " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                        string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + "/Renewal/" + CreatedBy + "/PresentworkingStatus/" + fileName);
                        PresentworkingStatus.PostedFile.SaveAs(filePathInfo2);
                        PresentworkingStatusfp = path + fileName;

                    }


                    CEI.InsertRenewalData(Category, ddlRenewalTime.SelectedItem.ToString(), txtamount.ToString(), CertificateofCompetency, Challanfp, txtgrnno.Text, txtdate.Text, MedicalFitnessfp, PresentworkingStatusfp, Undertakingfp, RadioButtonList1.SelectedItem.ToString(), userID);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Documents Added Successfully !!!')", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                }
            }
            catch (Exception ex)
            {
            }
        }



        protected void ddlRenewalTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRenewalTime.SelectedValue == "1")
            {
                txtamount.Text = "200";
            }
            else if (ddlRenewalTime.SelectedValue == "5")
            {
                txtamount.Text = "950";
            }
        }
    }
}
