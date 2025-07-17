﻿using CEI_PRoject;
using CEIHaryana.Contractor;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class UploadSignature : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    GetDivisionName();
                    LoadSavedRecords();
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
        }

        public void LoadSavedRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetStaffLoginSignatureData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvImages.DataSource = dt;
                        gvImages.DataBind();
                    }
                }
            }
        }





        //protected void gvImages_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataRowView dr = (DataRowView)e.Row.DataItem;
        //        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Signature"]);
        //        (e.Row.FindControl("ImageUrl") as Image).ImageUrl = imageUrl;
        //    }
        //}

        protected void gvImages_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lblSignatureStatus = (Label)e.Row.FindControl("lblSignatureStatus");
                var imgSignature = (Image)e.Row.FindControl("ImageUrl");
                ImageButton btnDelete = e.Row.FindControl("btnDelete") as ImageButton;

                var signatureData = e.Row.DataItem as DataRowView;
                var signature = signatureData["Signature"];
                var imageType = signatureData["SignatureTypeFormat"] as string;

                if (signature == DBNull.Value)
                {
                    lblSignatureStatus.Visible = true;
                    imgSignature.Visible = false;

                    if (lblSignatureStatus != null && btnDelete != null)
                    {
                        // Show or hide the delete button based on the signature status
                        btnDelete.Visible = lblSignatureStatus.Text != "Not Uploaded";
                    }
                }
                else
                {
                    lblSignatureStatus.Visible = false;
                    imgSignature.Visible = true;
                    string mimeType = "image/jpeg";

                    if (imageType != null)
                    {
                        if (imageType.Equals("png", StringComparison.OrdinalIgnoreCase))
                        {
                            mimeType = "image/png";
                        }
                    }
                    //imgSignature.ImageUrl = "data:image;base64," + Convert.ToBase64String((byte[])signature);
                    //imgSignature.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])signature);
                    imgSignature.ImageUrl = $"data:{mimeType};base64,{Convert.ToBase64String((byte[])signature)}";

                }
            }
        }

        private void GetDivisionName()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.getDivisionName();
                ddlDivisionName.DataSource = ds;
                ddlDivisionName.DataTextField = "HeadOfficeArea";
                ddlDivisionName.DataValueField = "Id";
                ddlDivisionName.DataBind();
                ddlDivisionName.Items.Insert(0, new ListItem("Select", "0"));
                //GetStaffName();

            }
            catch { }
        }
        private void GetStaffName()
        {
            try
            {
                string DivisionName = ddlDivisionName.SelectedItem.ToString();
                DataSet ds = new DataSet();
                ds = CEI.getStaffName(DivisionName);
                ddlstaffname.DataSource = ds;
                ddlstaffname.DataTextField = "StaffUserId";
                ddlstaffname.DataValueField = "StaffUserId";
                ddlstaffname.DataBind();
                ddlstaffname.Items.Insert(0, new ListItem("Select", "0"));


            }
            catch { }
        }



        //protected void BtnSubmit_Click(object sender, EventArgs e)
        //{


        //    string DivisionName = ddlDivisionName.SelectedItem.ToString();
        //    string StaffName = ddlstaffname.SelectedValue;
        //    byte[] signatureBytes = null;
        //    string filePathInfo1 = "";
        //    //int maxFileSize = 1 * 1024 * 1024; ;

        //    //if (Signature.HasFile) // Check if file is uploaded
        //    //{
        //    //    signatureBytes = Signature.FileBytes;
        //    //    string fileName = Path.GetFileName(Signature.FileName);
        //    //    string AdminID = Session["AdminID"].ToString();
        //    //    string ext = Path.GetExtension(fileName);
        //    //    string directoryPath = Server.MapPath("~/Attachment/" + AdminID + "/Signature/");

        //    //    if (!Directory.Exists(directoryPath))
        //    //    {
        //    //        Directory.CreateDirectory(directoryPath);
        //    //    }

        //    //    string uniqueFileName = "Signature" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
        //    //    string filePath = Path.Combine(directoryPath, uniqueFileName);
        //    //    Signature.SaveAs(filePath);

        //    //    filePathInfo1 = "/Attachment/" + AdminID + "/Signature/" + uniqueFileName;
        //    //}

        //        if (Signature.HasFile) // Check if file is uploaded
        //        {
        //            // Allowed file extensions
        //            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        //            // Maximum file size in bytes (1 MB)
        //            int maxFileSize = 1 * 1024 * 1024;

        //            // Get file details
        //            string fileName = Path.GetFileName(Signature.FileName);
        //            string fileExtension = Path.GetExtension(fileName).ToLower();
        //            int fileSize = Signature.PostedFile.ContentLength;

        //              if (allowedExtensions.Contains(fileExtension))
        //              {

        //                if (fileSize <= maxFileSize)
        //                {

        //                    string AdminID = Session["AdminID"].ToString();


        //                    string directoryPath = Server.MapPath("~/Attachment/" + AdminID + "/Signature/");


        //                    if (!Directory.Exists(directoryPath))
        //                    {
        //                        Directory.CreateDirectory(directoryPath);
        //                    }


        //                    string uniqueFileName = "Signature" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + fileExtension;
        //                    string filePath = Path.Combine(directoryPath, uniqueFileName);


        //                    Signature.SaveAs(filePath);


        //                signatureBytes = Signature.FileBytes;



        //                    filePathInfo1 = "/Attachment/" + AdminID + "/Signature/" + uniqueFileName;



        //                }

        //              }
        //            else
        //            {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Upload image that should be less than 1MB')", true);
        //            }
        //        }


        //    CEI.UploadSignature(DivisionName, StaffName, signatureBytes);

        //        ddlDivisionName.SelectedIndex = 0;
        //        ddlstaffname.SelectedIndex = 0;

        //        string script = $"alert('Signature for {StaffName} updated successfully.'); window.location='AdminMaster.aspx';";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);





        //}
        #region Navneet OTP condition 9-July-2025
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            SENDEMAIL();
        }
        protected void SENDEMAIL()
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Otp has been sent to your registered email please add OTP');", true);
            OTPVERIFICATION.Visible = true;
            string Email = CEI.getStaffEmal(ddlstaffname.SelectedItem.ToString());
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            HttpContext.Current.Session["OTP"] = otp;
            string body = $"Dear Customer,\n\n Your OTP for Updation Of Signture is {otp}. OTPs are confidential - Do not share them with anyone. Thank you for choosing our services. If you need any assistance, feel free to contact our support team.\n\n Best regards,\n\n[CEI Haryana]";

            CEI.ResetMessagethroughEmail(Email.Trim(), "Otp For Signature Update", body);
            BtnSubmit.Text = "Verify OTP";
            BtnSubmit.Visible = true;
            BtnSentOtp.Visible = false;
            Resendotp.Visible = true;

        }

        protected void saveImageByteInsession()
        {
            try
            {
                if (Signature.HasFile)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                    int maxFileSize = 1 * 1024 * 1024;
                    int fileSize = Signature.PostedFile.ContentLength;
                    if (fileSize <= maxFileSize)
                    {
                        Session["Selectedphotobyte"] = Signature.FileBytes;
                        txtsignature.Visible = true;
                        Signature.Visible = false;
                        txtsignature.Text = Signature.FileName;
                        SENDEMAIL();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('File size must be 1 MB .');", true);
                        return;
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please upload a file.');", true);
                    return;
                }
            }
            catch
            {

                string script = $"alert('ERROR In sending email,Please try again later');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }
        }
        protected void BtnSendotp_Click(object sender, EventArgs e)
        {
            saveImageByteInsession();
        }
        #endregion

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["OTP"].ToString() == txtOTP.Text.Trim())
            {
                BtnSubmit.Text = "Submit";
                txtOTP.Enabled = false;
                if (BtnSubmit.Text == "Submit"&& Session["Selectedphotobyte"].ToString() != "")
                {

                    string fileExtensionFormat = "";
                    string fileName = txtsignature.Text;
                   // string fileName = Path.GetFileName(Signature.FileName);
                    string fileExtension = Path.GetExtension(fileName).ToLower();
                    fileExtensionFormat = fileExtension.TrimStart('.'); 
                    string DivisionName = ddlDivisionName.SelectedItem.ToString();
                    string StaffName = ddlstaffname.SelectedValue;
                    byte[] signatureBytes = Session["Selectedphotobyte"] as byte[];

                    CEI.UploadSignature(DivisionName, StaffName, signatureBytes, fileExtensionFormat);

                    ddlDivisionName.SelectedIndex = 0;
                    ddlstaffname.SelectedIndex = 0;
                    Session["Selectedphotobyte"]="";
                    LoadSavedRecords();
                    string script = $"alert('Signature for {StaffName} updated successfully.'); window.location='AdminMaster.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

                }
                
                else
                {
                    string script = $"alert('OTP Verified Successfully');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

                }
            }
            else
            {

                string script = $"alert('Incorrect OTP');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }

        }

        protected void ddlDivisionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStaffName();

        }

        protected void gvImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int Idsdel = Convert.ToInt32(e.CommandArgument);
                    DataSet ds = new DataSet();
                    ds = CEI.ToRemoveUploadededSingature(Idsdel);
                    LoadSavedRecords();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Signature Deletion Successfull .');", true);
                }
            }
            catch (Exception ex) { }
        }
    }
}