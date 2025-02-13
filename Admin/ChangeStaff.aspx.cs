using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;

namespace CEIHaryana.Admin
{
    public partial class ChangeStaff : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    BindDivision();
                    BindAreaCoveredGrid();
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
        }

        private void BindAreaCoveredGrid()
        {
            try
            {
                DataSet ds = CEI.ToShowCEIAreaCoveredData();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.Columns[0].Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert('No records found.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            { }
        }

        private void BindDivision()
        {
            try
            {
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.ToGetDivision();
                DdlDivision.DataSource = dsDivision;
                DdlDivision.DataTextField = "HeadOffice";
                DdlDivision.DataValueField = "Area";
                DdlDivision.DataBind();
                DdlDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
            }
            catch (Exception ex)
            { }
        }

        protected void DdlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlStaffBind();
        }

        private void DdlDistrictBind()
        {
            try
            {
                string StaffId = DdlStaff.SelectedItem.ToString();
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.ToGetDistrict(StaffId);
                DdlDistrict.DataSource = dsDistrict;
                DdlDistrict.DataTextField = "AreaCovered";
                DdlDistrict.DataValueField = "AreaCovered";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            { }
        }

        private void DdlStaffBind()
        {
            try
            {
                string Division = DdlDivision.SelectedItem.ToString();
                DataSet dsStaff = new DataSet();
                dsStaff = CEI.ToGetStaff(Division);
                DdlStaff.DataSource = dsStaff;
                DdlStaff.DataTextField = "StaffUserID";
                DdlStaff.DataValueField = "StaffUserID";
                DdlStaff.DataBind();
                DdlStaff.Items.Insert(0, new ListItem("Select", "0"));
                dsStaff.Clear();
            }
            catch (Exception ex)
            { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string DivisionValue = DdlDivision.SelectedItem != null ? DdlDivision.SelectedItem.ToString() : string.Empty;

            string StaffValue = (DdlStaff.SelectedItem != null && !string.IsNullOrEmpty(DdlStaff.SelectedItem.Text)
                      && DdlStaff.SelectedItem.Text.ToLower() != "select") ? DdlStaff.SelectedItem.Text : string.Empty;
            string DistrictValue = (DdlDistrict.SelectedItem != null && !string.IsNullOrEmpty(DdlDistrict.SelectedItem.Text)
                          && DdlDistrict.SelectedItem.Text.ToLower() != "select") ? DdlDistrict.SelectedItem.Text : string.Empty;

            DataSet ds = CEI.ToFilterCEIAreaCoveredData(DivisionValue, StaffValue, DistrictValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridheader.Visible = true;
                dataGrid.Visible = true;
                CardHeader.Visible = false;
                ToChangeStaff.Visible = false;
                BtnSelect.Visible = true;

                GridView1.Columns[0].Visible = true;
                GridView1.Visible = true;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert('No records found.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void DdlStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDistrictBind();
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            bool atLeastOneChecked = false;
            bool allStaffsChecked = true; 
            bool multipleStaffSelected = false;
            string selectedStaffValue = null; 

            // check all checkboxes for the same "Staff"
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                Label lblStaff = (Label)row.FindControl("LblStaff");

                if (chk != null && lblStaff != null)
                {
                    string staffValue = lblStaff.Text.Trim();

                    // If checkbox is checked, check if it's the first checkbox for this staff
                    if (chk.Checked)
                    {
                        atLeastOneChecked = true;

                        // If it's the first selected staff, save its value
                        if (selectedStaffValue == null)
                        {
                            selectedStaffValue = staffValue;
                        }

                        // If a different staff is selected, set multipleStaffSelected to true
                        if (staffValue != selectedStaffValue)
                        {
                            multipleStaffSelected = true;
                            break;
                        }
                    }
                }
            }

            //If multiple staff are selected, show an error
            if (multipleStaffSelected)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select only checkboxes for the same Staff');", true);
                return;
            }

            // Check if all checkboxes for the selected "Staff" are checked
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                Label lblStaff = (Label)row.FindControl("LblStaff");

                if (chk != null && lblStaff != null && lblStaff.Text.Trim() == selectedStaffValue)
                {
                    // If any checkbox for the selected "Staff" is unchecked, set the flag to false
                    if (!chk.Checked)
                    {
                        allStaffsChecked = false;
                        break; 
                    }
                }
            }

            if (!atLeastOneChecked)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check at least one Checkbox');", true);
                return;
            }
            else if (!allStaffsChecked)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check all checkboxes for the selected Staff');", true);
                return;
            }

           
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null && chk.Checked)
                {
                    CardHeader.Visible = true;
                    ToChangeStaff.Visible = true;
                    dataGridheader.Visible = true;
                    dataGrid.Visible = true;
                    BtnSelect.Visible = true;

                    Label LblDivision = (Label)row.FindControl("LblDivision");
                    Label LblStaff = (Label)row.FindControl("LblStaff");
                    Label LblStaffId = (Label)row.FindControl("LblStaffId");

                    if (LblDivision != null && LblStaff != null && LblStaffId != null)
                    {
                        txtDivision.Text = LblDivision.Text.Trim();
                        txtStaff.Text = LblStaff.Text.Trim();
                        txtStaffId.Text = LblStaffId.Text.Trim();

                        string DivisionForStaff = LblDivision.Text.Trim();
                        DDLToBindNewStaff(DivisionForStaff);

                        break;
                    }
                }
            }
        }


        private void DDLToBindNewStaff(string DivisionForStaff)
        {
            try
            {
                DataSet DsUserID = CEI.GetStaffForAssign(DivisionForStaff);
                DdlNewStaffId.DataSource = DsUserID;
                DdlNewStaffId.DataTextField = "InitialStaffUserId";
                DdlNewStaffId.DataValueField = "InitialStaffUserId";
                DdlNewStaffId.DataBind();
                DdlNewStaffId.Items.Insert(0, new ListItem("Select", "0"));
                DsUserID.Clear();
            }
            catch (Exception ex)
            { }
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");

                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                }

            }
            catch (Exception ex) { }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                connection = new SqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                if (!string.IsNullOrEmpty(Convert.ToString(Session["AdminId"])))
                {
                    string id = Session["AdminId"].ToString();
                    string TransferOrderId = CEI.UploadDetailsForChangeStaff(txtStaffId.Text, DdlNewStaffId.SelectedItem.Text
                    , id, id, transaction);
                    string filePathInfo = "";
                    if (customFile.HasFile && customFile.PostedFile != null)
                    {
                        string fileExtension = Path.GetExtension(customFile.PostedFile.FileName).ToLower();
                        if (customFile.PostedFile.ContentLength <= 1048576 && fileExtension == ".pdf")
                        {
                            string fileName = "TransferOrder" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + fileExtension;
                            string directoryPath = Server.MapPath($"~/Attachment/TransferOrder/{TransferOrderId}/");
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePathInfo2 = Path.Combine(directoryPath, fileName);
                            customFile.SaveAs(filePathInfo2);
                            filePathInfo = $"~/Attachment/TransferOrder/{TransferOrderId}/{fileName}";
                            CEI.UploadAttachmentForChangeStaff(filePathInfo, TransferOrderId, transaction);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Please upload a PDF file that is no larger than 1 MB.');", true);
                            return;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Please select a file to upload.');", true);
                        return;
                    }
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string NewStaffId = DdlNewStaffId.SelectedItem.Text;
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            Label LblDivision = (Label)row.FindControl("LblDivision");
                            string ChangeForDivision = LblDivision.Text;
                            Label LblStaff = (Label)row.FindControl("LblStaff");
                            string Staff = LblStaff.Text;
                            Label LblStaffId = (Label)row.FindControl("LblStaffId");
                            string ChangeForStaffId = LblStaffId.Text;
                            Label LblDistrict = (Label)row.FindControl("LblDistrict");
                            string District = LblDistrict.Text;

                            CEI.ToReplaceStaffId(ChangeForDivision, Staff, ChangeForStaffId, NewStaffId, District, id, TransferOrderId, transaction);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithReturnRedirectdata();", true);
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Session expired or not valid');", true);
                    return;
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}