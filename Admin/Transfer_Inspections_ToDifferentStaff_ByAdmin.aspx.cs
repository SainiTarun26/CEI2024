using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.UserPages;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{

    public partial class Transfer_Inspections_ToDifferentStaff_ByAdmin : System.Web.UI.Page
    {
        private string selectedDistrict = "";
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    ViewState["SelectedDistrict"] = null;
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        BindDivisions();

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
                Response.Redirect("/Login.aspx", false);
            }
        }
        public void BindDivisions()
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDivisionList();
            ddlDivisions.DataSource = ds;
            ddlDivisions.DataTextField = "HeadOffice";
            ddlDivisions.DataValueField = "Area";
            ddlDivisions.DataBind();
            ddlDivisions.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }

        public void BindStaff(string division)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetStaffByDivisionList(division);
            ddlToAssign.DataSource = ds;
            ddlToAssign.DataTextField = "Staff";
            ddlToAssign.DataValueField = "StaffUserID";
            ddlToAssign.DataBind();
            ddlToAssign.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }

        public void BindDistricts(string division)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDistrictsByDivisionList(division);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "AreaCovered";
            DropDownList1.DataValueField = "AreaCovered";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }

        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDivision = ddlDivisions.SelectedValue;
            if (selectedDivision == "0")
            {
                ddlToAssign.ClearSelection();
                ddlToAssign.Items.Clear();
                ddlToAssign.Items.Add(new ListItem("Select", "0"));
                ddlToAssign.Items.FindByValue("0").Selected = true;

                ddlNewAssignee.ClearSelection();
                ddlNewAssignee.Items.Clear();
                ddlNewAssignee.Items.Add(new ListItem("Select", "0"));
                ddlNewAssignee.Items.FindByValue("0").Selected = true;

                DropDownList1.ClearSelection();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("Select", "0"));
                DropDownList1.Items.FindByValue("0").Selected = true;

                GridView1.DataSource = null;
                GridView1.DataBind();

                btnSubmit.Visible = false;

                ViewState["SelectedDistrict"] = null;
                ViewState["IsFirstSelection"] = null;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                BindStaff(selectedDivision);
                //BindStaff_ToTransfer(selectedDivision);
            }

        }

        public void GetGridData()
        {
            try
            {
                //string LoginID = string.Empty;
                //LoginID = Session["ContractorID"].ToString();

                string division = ddlDivisions.SelectedItem.Value;
                string staff = ddlToAssign.SelectedItem.Value;
                string district = DropDownList1.SelectedItem.Value;

                district = (district == "0" || string.IsNullOrEmpty(district)) ? null : district;
                DataSet ds = new DataSet();
                ds = CEI.InspectionGridDataList_Admin(division, staff, district);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    btnSubmit.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    btnSubmit.Visible = false;
                }

            }
            catch { }
        }

        public void GetGridData2_WithNoMessage()
        {
            try
            {
                //string LoginID = string.Empty;
                //LoginID = Session["ContractorID"].ToString();

                string division = ddlDivisions.SelectedItem.Value;
                string staff = ddlToAssign.SelectedItem.Value;
                string district = DropDownList1.SelectedItem.Value;

                district = (district == "0" || string.IsNullOrEmpty(district)) ? null : district;
                DataSet ds = new DataSet();
                ds = CEI.InspectionGridDataList_Admin(division, staff, district);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    btnSubmit.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    btnSubmit.Visible = false;
                }

            }
            catch { }
        }

        protected void ddlToAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedItem.Value.ToString() != "0" && ddlToAssign.SelectedItem.Value.ToString() != "0"
                && ddlDivisions.SelectedItem.Value == "CDG" && ddlToAssign.SelectedItem.Value == "AE")
            {
                BindDistricts(ddlDivisions.SelectedItem.Value);
                Div1.Visible = true;
                DropDownList1.Visible = true;
            }
            else
            {
                DropDownList1.ClearSelection();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("Select", "0"));
                DropDownList1.Items.FindByValue("0").Selected = true;

                ddlNewAssignee.ClearSelection();
                ddlNewAssignee.Items.Clear();
                ddlNewAssignee.Items.Add(new ListItem("Select", "0"));
                ddlNewAssignee.Items.FindByValue("0").Selected = true;

                Div1.Visible = false;
                DropDownList1.Visible = false;

                btnSubmit.Visible = false;
            }
            GridView1.DataSource = null;
            GridView1.DataBind();

            ViewState["SelectedDistrict"] = null;
            ViewState["IsFirstSelection"] = null;



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                    //chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");

                }

            }
            catch (Exception ex) { }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetGridData();
            GridView1.DataSource = null;
            GridView1.DataBind();

            ddlNewAssignee.ClearSelection();
            ddlNewAssignee.Items.Clear();
            ddlNewAssignee.Items.Add(new ListItem("Select", "0"));
            ddlNewAssignee.Items.FindByValue("0").Selected = true;

            btnSubmit.Visible = false;
            ViewState["SelectedDistrict"] = null;
            ViewState["IsFirstSelection"] = null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool atLeastOneSupervisorChecked = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = row.FindControl("CheckBox1") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    atLeastOneSupervisorChecked = true;
                    break;
                }
            }

            if (!atLeastOneSupervisorChecked)
            {
                Response.Write("<script>alert('Please Select One InspectionId At A Time.');</script>");
                return;
            }

            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if ((row.FindControl("CheckBox1") as CheckBox)?.Checked == true)
                    {
                        string lbllblInspectionId = (row.FindControl("lblInspectionId") as Label)?.Text;
                        CEI.sp_Transfer_Inspections_ToDifferentStaff_ByAdmin_Method(Convert.ToInt32(lbllblInspectionId), ddlNewAssignee.SelectedItem.Value, Session["AdminId"].ToString());
                    }
                }
                GetGridData2_WithNoMessage();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alertWithRedirectUpdation();", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void BindStaff_ToTransfer(string district, string staffcurrentid)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetNewStaffByDistrictList(district, staffcurrentid);
            ddlNewAssignee.DataSource = ds;
            ddlNewAssignee.DataTextField = "StaffUserID";
            ddlNewAssignee.DataValueField = "StaffUserID";
            ddlNewAssignee.DataBind();
            ddlNewAssignee.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();


        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GetGridData();
                ViewState["SelectedDistrict"] = null;
                ViewState["IsFirstSelection"] = null;
            }
            catch { }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetGridData();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool stillSelectedSameDistrict = false;
                CheckBox clickedChk = (CheckBox)sender;
                bool isChecked = clickedChk.Checked;

                GridViewRow clickedRow = ((CheckBox)sender).NamingContainer as GridViewRow;
                Label lblDistrict = (Label)clickedRow.FindControl("lblDistrict");
                Label lbllblAssignTo = (Label)clickedRow.FindControl("lblAssignTo");
                string currentDistrict = lblDistrict.Text;

                string selectedDistrict = (string)ViewState["SelectedDistrict"];

                if (isChecked)
                {
                    if (string.IsNullOrEmpty(selectedDistrict))
                    {
                        ViewState["SelectedDistrict"] = currentDistrict;

                        ViewState["IsFirstSelection"] = true;
                        BindStaff_ToTransfer(lblDistrict.Text, lbllblAssignTo.Text);
                    }
                    else if (selectedDistrict != currentDistrict)
                    {
                        clickedChk.Checked = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select checkboxes from the same district.');", true);
                        return;
                    }
                }
                else
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk.Checked)
                        {
                            Label lblRowDistrict = (Label)row.FindControl("lblDistrict");
                            if (lblRowDistrict.Text == selectedDistrict)
                            {
                                stillSelectedSameDistrict = true;
                                break;
                            }
                        }
                    }

                    // If no checkboxes are left for the selected district, reset the selected district
                    if (!stillSelectedSameDistrict)
                    {
                        ViewState["SelectedDistrict"] = null;
                        ViewState["IsFirstSelection"] = null;

                        ddlNewAssignee.ClearSelection();
                        ddlNewAssignee.Items.Clear();
                        ddlNewAssignee.Items.Add(new ListItem("Select", "0"));
                        ddlNewAssignee.Items.FindByValue("0").Selected = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




    }
}