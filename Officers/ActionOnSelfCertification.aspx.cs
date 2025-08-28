using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class ActionOnSelfCertification : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hnStaffId.Value = "";
                    hnSc_Id.Value = "";
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        if (Convert.ToString(Session["SC_Id"]) != null && Convert.ToString(Session["SC_Id"]) != string.Empty)
                        {
                            hnStaffId.Value = Session["StaffID"].ToString();
                            hnSc_Id.Value = Session["SC_Id"].ToString();
                            GetData(hnSc_Id.Value);
                            BindGrid(hnSc_Id.Value);
                        }
                    }
                    else
                    {
                        Session["StaffID"] = "";
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

        private void GetData(string ScId)
        {
            try
            {
                if (Convert.ToString(hnStaffId.Value) == Convert.ToString(Session["StaffID"]) && Convert.ToString(hnSc_Id.Value) == Convert.ToString(Session["SC_Id"]))
                {
                    DataTable dt = CEI.GetSelfCertificateDataReapply(ScId);
                    txtName.Text = dt.Rows[0]["OwnerName"].ToString();
                    txtPanNo.Text = dt.Rows[0]["CreatedBy"].ToString();
                    txtDistrict.Text = dt.Rows[0]["District"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtContact.Text = dt.Rows[0]["ContactNo"].ToString();
                    chkLine.Checked = dt.Rows[0]["Line"].ToString() == "1";
                    chkGenerater.Checked = dt.Rows[0]["Generating"].ToString() == "1";
                    chkSubstation.Checked = dt.Rows[0]["Substation"].ToString() == "1";
                    chkSwitching.Checked = dt.Rows[0]["Switching"].ToString() == "1";
                    chkSolar.Checked = dt.Rows[0]["Solar"].ToString() == "1";
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
                    Session["StaffID"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
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
                DataSet ds = CEI.GetReturnSCDouments(ScId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //if (ds != null && ds.Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();

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
                    ////fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    string fileName = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileName);
                    string filePath = Path.Combine(folderPath);
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
                if (e.CommandName == "Print")
                {
                    ////fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
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

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label LblPrevious = (Label)e.Row.FindControl("LblPrevious");
                    Label LblCurrent = (Label)e.Row.FindControl("LblCurrent");
                    LinkButton lnkPreviousDoc = (LinkButton)e.Row.FindControl("lnkPreviousDoc");
                    LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("lnkDocumemtPath");

                    // Check if Previous Document Path exists
                    if (!string.IsNullOrWhiteSpace(LblPrevious?.Text))
                    {
                        lnkPreviousDoc.Visible = true;
                        lnkPreviousDoc.Text = "View Document";
                        lnkPreviousDoc.CommandArgument = LblPrevious.Text;
                    }
                    else
                    {
                        lnkPreviousDoc.Visible = false;
                    }

                    // Check if Current Document Path exists
                    if (!string.IsNullOrWhiteSpace(LblCurrent?.Text))
                    {
                        lnkDocumemtPath.Visible = true;
                        lnkDocumemtPath.Text = "View Document";
                        lnkDocumemtPath.CommandArgument = LblCurrent.Text;
                    }
                    else
                    {
                        lnkDocumemtPath.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Approved")
            {
                Document.Visible = true;
                Suggestion.Visible = true;
                Remarks.Visible = false;
            }
         
            else
            {
                Document.Visible = false;
                Suggestion.Visible = false;
                Remarks.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hnStaffId.Value) == Convert.ToString(Session["StaffID"]) && Convert.ToString(hnSc_Id.Value) == Convert.ToString(Session["SC_Id"]))
            {
                if (RadioButtonList1.SelectedValue != "" && RadioButtonList1.SelectedValue != null)
                {
                    if (RadioButtonList1.SelectedValue == "Approved")
                    {
                        if (txtSuggestion.Text == "" || txtSuggestion.Text == null)
                        {
                            string alertScript = "alert('Please enter suggestions  to Proceed.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }
                    if (RadioButtonList1.SelectedValue == "Rejected")
                    {
                        if (txtRemarks.Text == "" || txtRemarks.Text == null)
                        {
                            string alertScript = "alert('Please enter remarks to Proceed.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }
                    string[] allowedExtensions = { ".pdf" };
                    int maxFileSize = 1 * 1024 * 1024;
                    string filePathForm1 = "";
                    if (FileSuppDoc.HasFile)
                    {
                        if (FileSuppDoc.PostedFile.ContentLength <= maxFileSize)
                        {
                            string ext = Path.GetExtension(FileSuppDoc.FileName).ToLower();
                            if (!allowedExtensions.Contains(ext))
                            {
                                throw new Exception("Only PDF files are allowed.");
                            }

                            string directoryPath = Server.MapPath("~/Attachment/Self-Certification/" + hnStaffId.Value + "/" + hnSc_Id.Value);
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string fileName = "Self-Certification" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                            string fullPath = Path.Combine(directoryPath, fileName);
                            filePathForm1 = "/Attachment/Self-Certification/" + hnStaffId.Value + "/" + hnSc_Id.Value + "/" + fileName;
                            FileSuppDoc.SaveAs(fullPath);

                        }
                        else
                        {
                            string alertScript = "alert('Please upload 1MB files.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }

                    //insert for final approval
                    int x = CEI.InsertApprovalDataForCS(hnSc_Id.Value, RadioButtonList1.SelectedValue, hnStaffId.Value, txtRemarks.Text, txtSuggestion.Text, filePathForm1);

                    if (x > 0)
                    {
                        if (RadioButtonList1.SelectedValue == "Approved")
                        {
                            string script = $"alert('SELF CERTIFICATION Approve Successfuly !!.'); window.location='/Officers/Self_CertificationStatus.aspx';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                        }
                        
                        else
                        {
                            string script = $"alert('SELF CERTIFICATION Rejected !!.'); window.location='/Officers/Self_CertificationStatus.aspx';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                        }
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the action to Process.');", true);
                }
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
    }
}