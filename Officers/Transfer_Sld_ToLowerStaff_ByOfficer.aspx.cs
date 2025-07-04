using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.Officers;
using CEIHaryana.SiteOwnerPages;
using CEIHaryana.UserPages;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Officers
{
    public partial class Transfer_Sld_ToLowerStaff_ByOfficer : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        BindStaff(Session["StaffID"].ToString());
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
                Response.Redirect("/OfficerLogout.aspx", false);
            }
        }


        public void BindStaff(string loginid)
        {
            DataSet ds = new DataSet();
            ds = CEI.Get_Sld_SelectedStaffFromLogin(loginid);
            ddlToAssign.DataSource = ds;
            ddlToAssign.DataTextField = "StaffUserID";
            ddlToAssign.DataValueField = "StaffUserID";
            ddlToAssign.DataBind();
            ddlToAssign.SelectedValue = "StaffUserID";
            ds.Clear();
        }

        public void GetGridData()
        {
            try
            {
                string selectedStaffID = ddlToAssign.SelectedValue;
                DataSet ds = new DataSet();
                ds = CEI.SldTransfer_ToLowerStaff_GridDataList_Officer(selectedStaffID, txtSearch.Text.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    BindStaff_ToTransfer();
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
                string selectedStaffID = ddlToAssign.SelectedValue;
                DataSet ds = new DataSet();
                ds = CEI.SldTransfer_ToLowerStaff_GridDataList_Officer(selectedStaffID, txtSearch.Text.ToString());
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
                    btnSubmit.Visible = false;
                }

            }
            catch { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                string RequestLetter = DataBinder.Eval(e.Row.DataItem, "RequestLetter").ToString();
                LinkButton Lnkbtn = (LinkButton)e.Row.FindControl("Lnkbtn");
                linkButton1.Visible = true;

                if (RequestLetter != null && RequestLetter != "")
                {
                    Lnkbtn.Visible = true;
                }
                else
                {
                    Lnkbtn.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
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
                    Response.Write("<script>alert('Please Select Atleast One SldId At A Time.');</script>");
                    return;
                }

                try
                {
                    foreach (GridViewRow CurrentRow in GridView1.Rows)
                    {
                        CheckBox chkSelect = CurrentRow.FindControl("CheckBox1") as CheckBox;

                        if (chkSelect != null && chkSelect.Checked)
                        {
                            Label lbllblInspectionIds = CurrentRow.FindControl("lblSLD_ID") as Label;

                            if (lbllblInspectionIds != null)
                            {
                                CEI.sp_Transfer_Sld_ToDifferent_Lower_Staff_ByOfficer_Method(Convert.ToInt32(lbllblInspectionIds.Text), ddlNewAssignee.SelectedItem.Value, Session["StaffID"].ToString());
                            }
                        }
                    }

                    GetGridData2_WithNoMessage();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alertWithRedirectUpdation();", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "'); window.location.href = '/Officers/Transfer_Sld_ToLowerStaff_ByOfficer.aspx';", true);
                    return;
                }
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx", false);
            }

        }
        public void BindStaff_ToTransfer()
        {
            string selectedStaffID = ddlToAssign.SelectedValue;
            DataSet ds = new DataSet();
            ds = CEI.Get_Sld_LowerStaffByHeadQuarterList(selectedStaffID);
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
            }
            catch { }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
            {
                ddlNewAssignee.ClearSelection();
                ddlNewAssignee.Items.Clear();
                ddlNewAssignee.Items.Add(new ListItem("Select", "0"));
                ddlNewAssignee.Items.FindByValue("0").Selected = true;
                GetGridData();
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx", false);
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelectAll = (CheckBox)sender;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null)
                {
                    chk.Checked = chkSelectAll.Checked;
                }
            }
        }

        protected void ddlToAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStaff_ToTransfer();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select1")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Print")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void GetPopUpDetails(string sldId)
        {
            try
            {
                DataSet ds = CEI.SldTransfer_GetSiteOwnerDetails_OnPopup(Convert.ToInt32(sldId));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    txtApplicant.Text = row["ApplicantType"].ToString();
                    txtContractorType.Text = row["ContractorType"].ToString();
                    txtPanNoOrTanNo.Text = row["UserId"].ToString();

                    if (!string.IsNullOrEmpty(row["NameOfOwner"].ToString()))
                    {
                        txtNameOfOwner.Text = row["NameOfOwner"].ToString();
                        OwnerNameDiv.Visible = true;
                        AgencyNameDiv.Visible = false;
                    }
                    else
                    {
                        txtNameOfAgency.Text = row["NameOfAgency"].ToString();
                        AgencyNameDiv.Visible = true;
                        OwnerNameDiv.Visible = false;
                    }


                    txtAddress.Text = row["Address"].ToString();
                    txtContactNo.Text = row["ContactNo"].ToString();
                    txtEmail.Text = row["Email"].ToString();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string enteredText = txtSearch.Text;
            if (enteredText.Length >= 4)
            {
                GetGridData();
            }
        }

        protected void lnkOwnerName_Command(object sender, CommandEventArgs e)
        {
            string sldId = e.CommandArgument.ToString();
            // Fetch owner details
            GetPopUpDetails(sldId);
            // Show the modal using Bootstrap (after data is filled)
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowOwnerModal", "$('#ownerModal').modal('show');", true);
        }

    }
}