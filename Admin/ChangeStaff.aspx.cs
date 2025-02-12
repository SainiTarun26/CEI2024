using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Count = string.Empty;
            string IntimationId = string.Empty;
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblDivision = (Label)row.FindControl("LblDivision");
                Label LblDistrict = (Label)row.FindControl("LblDistrict");
                Label LblStaff = (Label)row.FindControl("LblStaff");
                Label LblStaffId = (Label)row.FindControl("LblStaffId");

                txtDivision.Text = LblDivision.Text.Trim();
                txtStaff.Text = LblStaff.Text.Trim();
                txtStaffId.Text = LblStaffId.Text.Trim();
            }
        }

        protected void DdlStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDistrictBind();
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            bool atLeastOneChecked = false;

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null && chk.Checked)
                {
                    atLeastOneChecked = true;

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

            if (!atLeastOneChecked)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check at least one Checkbox');", true);
                return;
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
            if (!string.IsNullOrEmpty(Convert.ToString(Session["AdminId"])))
            {

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string NewStaffId = DdlNewStaffId.SelectedItem.Text;
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                    if (chk != null && chk.Checked)
                    {
                        Label LblDivision = (Label)row.FindControl("LblDivision") as Label;
                        string ChangeForDivision = LblDivision.Text;
                        Label LblStaff = (Label)row.FindControl("LblStaff");
                        string Staff = LblStaff.Text;
                        Label LblStaffId = (Label)row.FindControl("LblStaffId");
                        string ChangeForStaffId = LblStaffId.Text;
                        Label LblDistrict = (Label)row.FindControl("LblDistrict");
                        string District = LblDistrict.Text;

                        CEI.ToReplaceStaffId(ChangeForDivision, Staff, ChangeForStaffId, NewStaffId, District, Session["AdminId"].ToString());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithReturnRedirectdata();", true);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Session expired or not valid');", true);
                return;
            }
        }
    }
}