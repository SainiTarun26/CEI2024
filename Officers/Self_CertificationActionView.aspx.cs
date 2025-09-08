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
    public partial class Self_CertificationActionView : System.Web.UI.Page
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
                        Response.Redirect("/OfficerLogout.aspx");
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
                    DataTable dt = CEI.GetSelfCertificateData(ScId);
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
                    txtStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                    hnFile.Value = dt.Rows[0]["Support_Document"].ToString();
                    if (txtStatus.Text == "Approved")
                    { 
                        if(hnFile.Value != null && hnFile.Value != string.Empty)
                        {
                            Document.Visible = true;                           
                        }
                        Suggestion.Visible = true;
                        Remarks.Visible = false;
                        txtSuggestion.Text = dt.Rows[0]["Suggestions"].ToString();

                    }                  
                    else
                    {
                        Suggestion.Visible = false;
                        Document.Visible = false;
                        Remarks.Visible = true;
                        txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    }
                   
                
                }
                else
                {
                    Session["StaffID"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
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
                DataTable dt = CEI.GetDocument_Officer(ScId);
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

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string fileName = "";
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = hnFile.Value;
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hnStaffId.Value) == Convert.ToString(Session["StaffID"]))
            {
                Response.Redirect("/Officers/Self_CertificationStatus.aspx", false);
            }
        }
    }
}