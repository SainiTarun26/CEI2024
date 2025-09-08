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
    public partial class Upload_Image_Sign : System.Web.UI.Page
    {
        //Page created by  neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["UserID"]) != null && Convert.ToString(Session["UserID"]) != "")
                    {
                        if (Convert.ToString(Session["UserType"]) != null && Convert.ToString(Session["UserType"]) != "")
                        {
                            string UserID = Session["UserID"].ToString();
                            string UserType = Session["UserType"].ToString();

                            txtUserId.Text = UserID.Trim();
                            txtCategory.Text = UserType.Trim();
                        }
                        else
                        {
                            Response.Redirect("/LogOut.aspx", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Login.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string UId = txtUserId.Text;
                    string baseFolder = Server.MapPath("~/Attachment/Supervisor/" + UId + "/");

                    // Create directory if not exists
                    if (!Directory.Exists(baseFolder))
                    {
                        Directory.CreateDirectory(baseFolder);
                    }

                    string dbPathPhoto = "";
                    string dbPathSignature = "";

                    // ===== PHOTO Upload =====
                    if (fuPhoto.HasFile)
                    {
                        string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
                        string extension = Path.GetExtension(fuPhoto.FileName).ToLower();

                        if (allowedExtensions.Contains(extension))
                        {
                            if (fuPhoto.PostedFile.ContentLength <= 204800) // 200 KB limit
                            {
                                string fileName = "Photo_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                                string savePath = Path.Combine(baseFolder, fileName);
                                fuPhoto.SaveAs(savePath);

                                dbPathPhoto = "/Attachment/Supervisor/" + UId + "/" + fileName;
                            }
                            else
                            {
                                throw new Exception("Photograph must be less than 200 KB.");
                            }
                        }
                        else
                        {
                            throw new Exception("Only image files are allowed for Photograph.");
                        }
                    }

                    // ===== SIGNATURE Upload =====
                    if (fuSignature.HasFile)
                    {
                        string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
                        string extension = Path.GetExtension(fuSignature.FileName).ToLower();

                        if (allowedExtensions.Contains(extension))
                        {
                            if (fuSignature.PostedFile.ContentLength <= 102400) // 100 KB limit
                            {
                                string fileName = "Signature_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                                string savePath = Path.Combine(baseFolder, fileName);
                                fuSignature.SaveAs(savePath);

                                dbPathSignature = "/Attachment/Supervisor/" + UId + "/" + fileName;
                            }
                            else
                            {
                                throw new Exception("Signature must be less than 100 KB.");
                            }
                        }
                        else
                        {
                            throw new Exception("Only image files are allowed for Signature.");
                        }
                    }



                    int result = CEI.UpdateImageAndSignature(txtCategory.Text, dbPathPhoto, dbPathSignature, UId);

                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect",
                            "alert('Information Updated Successfully!'); window.location='Login.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error while saving documents.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);

            }
        }
    }
}