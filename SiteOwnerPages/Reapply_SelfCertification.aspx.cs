using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Xml;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Configuration;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Reapply_SelfCertification : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty && Convert.ToString(Session["SC_Id"]) != null && Convert.ToString(Session["SC_Id"]) != string.Empty)
                    {
                        hdnOwnerId.Value = Session["SiteOwnerId"].ToString();
                        hnScId.Value = Session["SC_Id"].ToString();
                        GetData(hnScId.Value);
                        BindGrid(hnScId.Value);
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("/SiteOwnerLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }

        public void BindGrid(string ScId)
        {
            try
            {
                DataTable dt = CEI.GetDocument_Owner(ScId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = dt;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }
        private void GetData(string ScId)
        {
            try
            {
                if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["SiteOwnerId"]) && Convert.ToString(hnScId.Value) == Convert.ToString(Session["SC_Id"]))
                {
                    DataTable dt = CEI.GetSelfCertificateData(ScId);
                    chkLineOption.Checked = dt.Rows[0]["Line"].ToString() == "1";
                    chkGeneratedOption.Checked = dt.Rows[0]["Generating"].ToString() == "1";
                    chkSubstationOption.Checked = dt.Rows[0]["Substation"].ToString() == "1";
                    chkSwitchingOption.Checked = dt.Rows[0]["Switching"].ToString() == "1";
                    chkSolarOption.Checked = dt.Rows[0]["Solar"].ToString() == "1";
                    chkOther.Checked = dt.Rows[0]["Other"].ToString() == "1";
                    if (chkOther.Checked)
                    {
                        OtherInstallation.Visible = true;
                        txtOtherInstallation.Text = dt.Rows[0]["OtherInsatallationType"].ToString();
                    }
                    txtVoltage.Text = dt.Rows[0]["Volatage"].ToString();                  
                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                connection = new SqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                if (Convert.ToString(Session["SiteOwnerId"]) == Convert.ToString(hdnOwnerId.Value))
                {
                    string SiteOwnerId = hdnOwnerId.Value;
                    bool isAnyFormUploaded = false;
                    bool isDemandNotice = false;                
                    foreach (GridViewRow row in grd_Documemnts.Rows)
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");

                        if (fileUpload != null && fileUpload.HasFile && lblDocumentName != null)
                        {
                            string docName = lblDocumentName.Text.Trim();

                            if (docName == "FORM_I" || docName == "FORM_II" || docName == "FORM_III")
                            {
                                isAnyFormUploaded = true;
                                if (fileUpload != null && fileUpload.HasFile)
                                {
                                    ValidatePdfFile(fileUpload);
                                }
                            }
                            else if (docName == "OtherDocument")
                            {
                                if (fileUpload != null && fileUpload.HasFile)
                                {
                                    ValidatePdfFile(fileUpload);
                                }

                            }
                            else if (docName == "DemandNotice_ElectricityBill")
                            {
                                isDemandNotice = true;
                                ValidatePdfFile(fileUpload);
                            }

                        }
                    }

                    if (!isAnyFormUploaded)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "formError", "alert('Please upload any one among Form I / Form II / Form III.');", true);
                        return;
                    }

                    if (!isDemandNotice)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "formError", "alert('Please upload Demand Notice.');", true);
                        return;
                    }

                    string Fileinfo = "";
                    //UPDATE THE STATUS AND COUNT

                 int x = CEI.UpdateSCStatus(hnScId.Value, hdnOwnerId.Value, transaction);
                    if (x > 0)
                    {
                        foreach (GridViewRow row in grd_Documemnts.Rows)
                        {

                            Label lblDocumentId = (Label)row.FindControl("lblDocumentId");
                            Label lblDocumentName = (Label)row.FindControl("lblDocumentName");
                            FileUpload fileUploadDoc = row.FindControl("FileUpload1") as FileUpload;

                            if ((fileUploadDoc != null && fileUploadDoc.HasFile))
                            {

                                string folderPath = Server.MapPath("~/Attachment/Self-Certification/" + hdnOwnerId.Value + "/" + hnScId.Value);
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }
                                string fullPath = Path.Combine(folderPath, lblDocumentName.Text + ".pdf");
                                Fileinfo = "/Attachment/Self-Certification/" + hdnOwnerId.Value + "/" + hnScId.Value + "/" + lblDocumentName.Text + ".pdf";
                                fileUploadDoc.SaveAs(fullPath);

                                CEI.UpdateDocumentForCS(hnScId.Value, lblDocumentId.Text, lblDocumentName.Text, Fileinfo, hdnOwnerId.Value, transaction);

                            }
                        }

                        transaction.Commit();
                        string script = $"alert('SELF CERTIFICATION Successfuly Re-Submit!!.'); window.location='SelfCertificationStatus.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                        return;

                    }
                    else
                    {
                        string alertScript = "alert('Please try again.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        private void ValidatePdfFile(FileUpload fileUpload)
        {

            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            if (fileExtension != ".pdf")
            {
                throw new Exception("Please upload PDF files only.");

            }

            if (fileUpload.PostedFile.ContentLength > 1048576)
            {
                throw new Exception("Please upload PDF files less than 1 MB only.");

            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblDocument = (Label)e.Row.FindControl("lblDocument");
                    LinkButton linkDocument = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

                    if (lblDocument.Text != null && lblDocument.Text != string.Empty)
                    {
                        linkDocument.Visible = true;
                    }
                    else
                    {
                        linkDocument.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    ////fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    string fileName = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileName);
                    string filePath = Path.Combine(folderPath);
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
    }
}