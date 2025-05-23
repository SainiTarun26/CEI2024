using CEI_PRoject;
using CEIHaryana.Officers;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;

namespace CEIHaryana.Admin
{
    public partial class CESE_Registration : System.Web.UI.Page
    {
        //Page created by neeraj on may2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e) 
        {
            try
            {
                if (!IsPostBack)
                {
                    hnOwnerId.Value = null;
                    hnRegistrationId.Value = null;
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        hnOwnerId.Value = Session["AdminId"].ToString();
                        ddlLoadBindDistrict();
                        GridBind();
                        ddlLoadBindVoltage();
                        ForSubmit.Visible = true;
                        CeseCert.Visible = true;
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void ddlLoadBindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict("Haryana");
                ddldistrict.DataSource = dsDistrict;
                ddldistrict.DataTextField = "District";
                ddldistrict.DataValueField = "District";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageLevel();
            ddlVoltage.DataSource = dsVoltage;
            ddlVoltage.DataTextField = "Voltagelevel";
            ddlVoltage.DataValueField = "VoltageID";
            ddlVoltage.DataBind();
            ddlVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
            {
                if (Convert.ToString(hnOwnerId.Value) == Convert.ToString(Session["AdminId"]))
                {
                    if (Page.IsValid)

                    {
                        if (Convert.ToString(ddldistrict.SelectedValue) != "0")
                        {
                            if (Convert.ToString(ddlVoltage.SelectedValue) != "0")
                            {
                                string AdminId = hnOwnerId.Value;
                                string[] allowedExtensions = { ".pdf" };
                                int maxFileSize = 1 * 1024 * 1024;

                                DataTable dt = CEI.checkPanNumber_CESE(txtPanNo.Text);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    string alertScript = "alert('The  Pan number is already in use. Please provide a different Pan number.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                }
                                if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize)
                                {
                                    string ext = Path.GetExtension(customFile.FileName).ToLower();
                                    if (!allowedExtensions.Contains(ext))
                                    {                                         
                                        string alertScript = "alert('Only PDF files are allowed.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }

                                    string directoryPath = Server.MapPath("~/Attachment/CESE-Certificate/" + txtPanNo.Text);
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    string fileName = "CESE-Certificate" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                    string fullPath = Path.Combine(directoryPath, fileName);
                                    string filePathInfo = "/Attachment/CESE-Certificate/" + txtPanNo.Text + "/" + fileName;

                                    customFile.SaveAs(fullPath);

                                    int x = CEI.InsertDataForCESE(txtName.Text, txtPanNo.Text, txtAddress.Text, txtEmail.Text,
                                        txtContactNo.Text, ddldistrict.SelectedValue.ToString(), ddlVoltage.SelectedItem.ToString(), filePathInfo, AdminId);

                                    if (x > 0)
                                    {
                                        string script = $"alert('Registration Succesffuly!!.'); window.location='AdminMaster.aspx';";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
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
                                    string alertScript = "alert('Please upload PDF file under 1MB.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                }
                            }
                            else
                            {
                                ddlVoltage.Focus();
                                string alertScript = "alert('Please Select Voltage Level to Proceed.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }
                        }
                        else
                        {
                            ddldistrict.Focus();
                            string alertScript = "alert('Please Select District to Proceed.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }
                    else
                    {                        
                        string alertScript = "alert('Please fill all mandatory fields.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;

                    }
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            else
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }

        
        public void GridBind()
        {
            try
            {          
                DataTable dt = new DataTable();
                dt = CEI.GetCESEData();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
            {
                if (Convert.ToString(hnOwnerId.Value) == Convert.ToString(Session["AdminId"]))
                {

                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblRegistrationId = (Label)row.FindControl("lblRegistrationId");
                    hnRegistrationId.Value = lblRegistrationId.Text;
                    if (e.CommandName == "Print")
                    {
                        CEI.DeleteCESERecord(hnRegistrationId.Value);
                        string script = $"alert('Registration deleted successfully!!.'); window.location='AdminMaster.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

                    }
                    else if (e.CommandName == "Select")
                    {
                        Reset();
                        ForSubmit.Visible = false;
                        ForUpdate.Visible = true;
                        CeseCert.Visible = false;
                        hiddenfield.Visible = true;
                        txtPanNo.ReadOnly = true;
                        DataTable dt = new DataTable();

                        dt = CEI.GETCESERecord(hnRegistrationId.Value);
                        if (dt.Rows.Count > 0)
                        {
                            txtName.Text = dt.Rows[0]["Name"].ToString();
                            txtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                            txtAddress.Text = dt.Rows[0]["Address"].ToString();
                            txtEmail.Text = dt.Rows[0]["Email"].ToString();
                            txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();                        
                            string Voltage = dt.Rows[0]["MaxVoltage"].ToString();
                            ddlVoltage.SelectedIndex = ddlVoltage.Items.IndexOf(ddlVoltage.Items.FindByText(Voltage));
                            string District = dt.Rows[0]["District"].ToString();
                            ddldistrict.SelectedIndex = ddldistrict.Items.IndexOf(ddldistrict.Items.FindByText(District));
                            hnFile.Value = dt.Rows[0]["CSSE_Certificate"].ToString();
                        }
                    }
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            else
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }


        protected void Reset()
        {
            try
            {              
                txtName.Text = "";
                txtPanNo.Text = "";
                txtAddress.Text = "";
                txtPanNo.ReadOnly = false;
                txtEmail.Text = "";
                txtContactNo.Text = "";
                ddldistrict.SelectedValue = "0";
                ddlVoltage.SelectedValue = "0";
                customFile.Attributes.Clear();
                CeseCert.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = hnFile.Value.ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          
                if (Convert.ToString(hnOwnerId.Value) == Convert.ToString(Session["AdminId"]))
                {
                    if (hnRegistrationId.Value != null && hnRegistrationId.Value != string.Empty)
                    {
                    if (Convert.ToString(ddldistrict.SelectedValue) != "0" && ddldistrict.SelectedValue != null && ddldistrict.SelectedValue !=string.Empty)
                    {
                        if (Convert.ToString(ddlVoltage.SelectedValue) != "0" && ddlVoltage.SelectedValue != null && ddlVoltage.SelectedValue != string.Empty)
                        {
                            if (txtName.Text != null && txtName.Text != string.Empty)
                            {
                                if (txtAddress.Text != null && txtAddress.Text != string.Empty)
                                {
                                    if (txtContactNo != null && txtContactNo.Text != string.Empty)
                                    {
                                        if (!Regex.IsMatch(txtName.Text.Trim(), @"^[A-Za-z]+$"))
                                        {
                                            txtName.Focus();
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter a valid name.');", true);
                                            return;
                                        }
                                         if (!Regex.IsMatch(txtAddress.Text.Trim(), @"^[A-Za-z0-9\W_]+$"))
                                        {
                                            txtAddress.Focus();
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter address.');", true);
                                            return;
                                        }
                                        if (!Regex.IsMatch(txtContactNo.Text, @"^[6-9]\d{9}$"))
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter a valid Contact No.');", true);
                                            return;
                                        }
                                        if (txtEmail.Text != null && txtEmail.Text != string.Empty)
                                        {
                                            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter a valid email.');", true);
                                                return;
                                            }

                                       
                                            string AdminId = hnOwnerId.Value;
                                            string[] allowedExtensions = { ".pdf" };
                                            int maxFileSize = 1 * 1024 * 1024;
                                            string filePathInfo = "";
                                            if (customFile.HasFile)
                                            {
                                                if (customFile.PostedFile.ContentLength <= maxFileSize)
                                                {
                                                    string ext = Path.GetExtension(customFile.FileName).ToLower();
                                                    if (!allowedExtensions.Contains(ext))
                                                    {
                                                        throw new Exception("Only PDF files are allowed.");
                                                    }

                                                    string directoryPath = Server.MapPath("~/Attachment/CESE-Certificate/" + txtPanNo.Text);
                                                    if (!Directory.Exists(directoryPath))
                                                    {
                                                        Directory.CreateDirectory(directoryPath);
                                                    }
                                                    string fileName = "CESE-Certificate" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                                    string fullPath = Path.Combine(directoryPath, fileName);
                                                    filePathInfo = "/Attachment/CESE-Certificate/" + txtPanNo.Text + "/" + fileName;
                                                    customFile.SaveAs(fullPath);
                                                }
                                                else
                                                {

                                                    string alertScript = "alert('Please upload PDF file under 1MB.');";
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                                    return;
                                                }

                                            }
                                            else
                                            {
                                                filePathInfo = hnFile.Value;
                                            }
                                            int x = CEI.UpdateDataForCESE(hnRegistrationId.Value, txtName.Text, txtPanNo.Text, txtAddress.Text, txtEmail.Text,
                                                    txtContactNo.Text, ddldistrict.SelectedValue.ToString(), ddlVoltage.SelectedItem.ToString(), filePathInfo, AdminId);

                                            if (x > 0)
                                            {
                                                string script = $"alert('Registration updated Succesffuly!!.'); window.location='AdminMaster.aspx';";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
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
                                            txtEmail.Focus();
                                            string alertScript = "alert('Please provide Email Id to Proceed.');";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        txtContactNo.Focus();
                                        string alertScript = "alert('Please provide ContactNo to Proceed.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }
                                }
                                else
                                {
                                    txtAddress.Focus();
                                    string alertScript = "alert('Please Enter address to Proceed.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                }
                            }
                            else
                            {
                                txtName.Focus();
                                string alertScript = "alert('Please Enter Name to Proceed.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }
                        }
                        else
                        {
                            ddlVoltage.Focus();
                            string alertScript = "alert('Please Select Voltage Level to Proceed.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;


                        }
                    }
                    else
                    {
                        ddldistrict.Focus();
                        string alertScript = "alert('Please Select District to Proceed.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                        
                    }
                    }
                    else
                    {
                    string alertScript = "alert('An Error occured.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                   
                   
                }
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ForSubmit.Visible = true;
            ForUpdate.Visible = false;
            hiddenfield.Visible = false;
            Reset();
        }

        protected void btnUploadNew_Click(object sender, EventArgs e)
        {
            hiddenfield.Visible = false;
            CeseCert.Visible = true;
        }

        protected void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            string PANNumber = txtPanNo.Text.Trim();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}$|^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$");
            if (!regex.IsMatch(PANNumber))
            {
                txtPanNo.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid PAN/TAN card format. Please enter a valid PAN/TAN number.');", true);
                txtPanNo.Text = "";
                return;
            }
        }
    }
}