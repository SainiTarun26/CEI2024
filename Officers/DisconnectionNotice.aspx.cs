using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Officers
{
    public partial class DisconnectionNotice : System.Web.UI.Page
    {
        //Page created by neeraj 29-May-2025
        CEI CEI = new CEI();
        string Id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        hdnOwnerId.Value = Session["StaffID"].ToString();
                        ddlPoweUtilityBind();
                        GetDivision();
                        Page.Session["ClickCount"] = "0";
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

           private void GetDivision()
           {
            DataTable ds = new DataTable();
            ds = CEI.GetDivisionName(hdnOwnerId.Value);
            string Division = ds.Rows[0]["Division"].ToString();
            hdnDivision.Value = Division;
           }

        private void ddlPoweUtilityBind()
        {
            try
            {
                DataTable dsUtility = new DataTable();
                dsUtility = CEI.GetUtilityName_Disconnection();
                ddlUtility.DataSource = dsUtility;
                ddlUtility.DataTextField = "UtilityName";
                ddlUtility.DataValueField = "Id";
                ddlUtility.DataBind();
                ddlUtility.Items.Insert(0, new ListItem("Select", "0"));
                dsUtility.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void DdlWingBind()
        {
            try
            {
                string Id = ddlUtility.SelectedValue.ToString();
                DataTable dsWing = new DataTable();
                dsWing = CEI.GetWingName_Disconnection(Id);
                ddlWing.DataSource = dsWing;
                ddlWing.DataTextField = "WingName";
                ddlWing.DataValueField = "Id";
                ddlWing.DataBind();
                ddlWing.Items.Insert(0, new ListItem("Select", "0"));
                dsWing.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }

        private void DdlZoneBind()
        {
            try
            {
                 string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                dsZone = CEI.GetZoneName_Disconnection(UtilityId, WingId , hdnDivision.Value);
                ddlZone.DataSource = dsZone;
                ddlZone.DataTextField = "ZoneName";
                ddlZone.DataValueField = "Id";
                ddlZone.DataBind();
                ddlZone.Items.Insert(0, new ListItem("Select", "0"));
                dsZone.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        private void DdlCircleBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                DataSet dsCircle = new DataSet();
                dsCircle = CEI.GetCircleName_Disconnection(UtilityId, WingId, ZoneId, hdnDivision.Value);
                ddlCircle.DataSource = dsCircle;
                ddlCircle.DataTextField = "CircleName";
                ddlCircle.DataValueField = "Id";
                ddlCircle.DataBind();
                ddlCircle.Items.Insert(0, new ListItem("Select", "0"));
                dsCircle.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        private void DdlDivisionBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                string Circleid = ddlCircle.SelectedValue.ToString();
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.GetDivisionName_Disconnection(UtilityId, WingId, ZoneId, Circleid, hdnDivision.Value);
                ddlDivision.DataSource = dsDivision;
                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "Id";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }

        private void DdlSubDivisionBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                string CircleId = ddlCircle.SelectedValue.ToString();

                string DivisionId = ddlDivision.SelectedValue.ToString();
                DataSet dsSubDivision = new DataSet();
                dsSubDivision = CEI.GetSubDivisionName_Disconnection(UtilityId, WingId, ZoneId, CircleId, DivisionId, hdnDivision.Value);
                DdlSubDivision.DataSource = dsSubDivision;
                DdlSubDivision.DataTextField = "SubDivision";
                DdlSubDivision.DataValueField = "Id";
                DdlSubDivision.DataBind();
                DdlSubDivision.Items.Insert(0, new ListItem("Select", "0"));
                if (DdlSubDivision.Items.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please map the SubDivision.');", true);
                    return;
                }
                dsSubDivision.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlWingBind();
        }

        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWing.SelectedValue == "0")
            {
                ddlWing.SelectedValue = "0";
            }
            DdlZoneBind();
        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlZone.SelectedValue == "0")
            {
                ddlZone.SelectedValue = "0";
            }
            DdlCircleBind();
        }

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCircle.SelectedValue == "0")
            {
                ddlCircle.SelectedValue = "0";
            }
            DdlDivisionBind();
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlSubDivisionBind();
        }

        protected void ddlCatogary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCatogary.SelectedValue == "3")
            {
                OtherCategory.Visible = true;
            }
            else
            {
                OtherCategory.Visible = false;
            }
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
        public void CheckValidations()
        {
            if (ddlUtility.SelectedValue != "0" && ddlWing.SelectedValue != "0" && ddlZone.SelectedValue != "0" && ddlCircle.SelectedValue != "0" && ddlDivision.SelectedValue != "0" && DdlSubDivision.SelectedValue != "0")
            {
                if (txtName.Text == null || txtName.Text == string.Empty)
                {
                    string alertScript = "alert('Please enter Name.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (txtPanNo.Text == null || txtPanNo.Text == string.Empty)
                {
                    string alertScript = "alert('Please enter Pan Number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (txtAccountNo.Text == null || txtAccountNo.Text == string.Empty)
                {
                    string alertScript = "alert('Please enter Account Number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (txtPhoneNo.Text == null || txtPhoneNo.Text == string.Empty)
                {
                    string alertScript = "alert('Please enter Contact Number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (ddlCatogary.SelectedValue == "0")
                {
                    string alertScript = "alert('Please select Category of consumer.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;

                }
                if (ddlCatogary.SelectedValue == "3")
                {
                    if (txtOther.Text == null || txtOther.Text == string.Empty)
                    {
                        string alertScript = "alert('Please enter other Category of consumer.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                }
                if (txtSanction.Text == null || txtSanction.Text == string.Empty)
                {
                    string alertScript = "alert('Please enter sanction load.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (!FileUploadForm1.HasFile)
                {
                    string alertScript = "alert('Please upload notice to Utilities for disconnection of supply file.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                if (txtRemarks.Text == null || txtRemarks.Text == string.Empty)
                {
                    string alertScript = "alert('Please provide Remarks.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
            }
            else
            {
                string alertScript = "alert('Please Select Utility to Proceed.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["StaffID"]) == Convert.ToString(hdnOwnerId.Value))
                {
                    int ClickCount = 0;
                    ClickCount = Convert.ToInt32(Session["ClickCount"]);
                    if (ClickCount < 1)
                    {
                        CheckValidations();
                        ClickCount = ClickCount + 1;
                        Session["ClickCount"] = ClickCount;
                        SqlTransaction transaction = null;
                        SqlConnection connection = null;
                        try
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            transaction = connection.BeginTransaction();
                            string StaffId = hdnOwnerId.Value;
                            string[] allowedExtensions = { ".pdf" };
                            int maxFileSize = 1 * 1024 * 1024;
                            // GET ASSIGN TO
                            DataTable dt = CEI.GetAssignTo_DSC(DdlSubDivision.SelectedValue);
                            string AssignTo = dt.Rows[0]["UserId"].ToString();
                            string Email = dt.Rows[0]["Email"].ToString();
                            //insert data for Disconnection of supply

                            Id = CEI.InsertDataForDisconnection(DdlSubDivision.SelectedValue, txtName.Text.Trim(), txtPanNo.Text.Trim(), txtAccountNo.Text.Trim(),
                            txtPhoneNo.Text.Trim(), ddlCatogary.SelectedItem.Text, txtOther.Text.Trim(), txtSanction.Text.Trim(), AssignTo, txtRemarks.Text.Trim(), StaffId, transaction);

                            if (!string.IsNullOrEmpty(Id))
                            {
                                // FOR INSERT DOCUMENTS
                                int x = UploadDocumentd(transaction);
                                if (x > 0)
                                {
                                    CEI.DSCEmailApprove(Email);
                                    transaction.Commit();
                                    string script = $"alert('Request of Disconnection of supply Successfuly Submit!!.'); window.location='DisconnectionRequest.aspx';";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                    return;
                                }
                            }
                            else
                            {
                                string alertScript = "alert('Please try again.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
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
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='DisconnectionRequest.aspx'", true);
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

        public int UploadDocumentd(SqlTransaction transaction)
        {
            int successCount = 0;
            for (int i = 1; i <= 2; i++)
            {
                FileUpload fileUploadControl = null;
                string fileName = "";
                string DocumentId = "";
                switch (i)
                {
                    case 1:
                        fileUploadControl = FileUploadForm1;
                        fileName = "Notice to Utilities for Disconnection of supply";
                        DocumentId = "1";
                        break;
                    case 2:
                        fileUploadControl = FileUploadForm2;
                        fileName = "Other Document";
                        DocumentId = "2";
                        break;

                }

                if (fileUploadControl != null && fileUploadControl.HasFile)
                {
                    string folderPath = Server.MapPath("~/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + Id);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fullPath = Path.Combine(folderPath, fileName + ".pdf");
                    string Fileinfo = "/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + Id + "/" + fileName + ".pdf";

                    fileUploadControl.SaveAs(fullPath);

                    // Save Documents
                    int x = CEI.InsertDocumentDisconnectionOfSupply(Id, DocumentId, fileName, Fileinfo, hdnOwnerId.Value, transaction);
                    if (x > 0)
                    {
                        successCount++;
                    }
                }
            }
            return successCount;
        }

      
        private void GridtoViewAllRecords(string Name)
        {
            DataTable dt = new DataTable();
           dt = CEI.SearchNameDisconnection(Name);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();            
            }
            else
            {              
                txtPanNo.Text = "";
                txtPhoneNo.Text = "";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblOwnerName = (Label)row.FindControl("lblOwnerName");
                Label lblPanNo = (Label)row.FindControl("lblPanNo");
                Label lblContactNo = (Label)row.FindControl("lblContactNo");
                txtName.Text = lblOwnerName.Text;
                txtPanNo.Text = lblPanNo.Text;
                txtPhoneNo.Text = lblContactNo.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", "$('#searchResultModal').modal('hide');", true);
            }
         
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            GridtoViewAllRecords(txtName.Text);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridtoViewAllRecords(txtName.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "openModal();", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void lnkbtnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (!string.IsNullOrEmpty(name))
            {               
                GridtoViewAllRecords(name);              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "openModal();", true);
            }
            else
            {
                string alertScript = "alert('Please enter Name.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }
        }
    }
}