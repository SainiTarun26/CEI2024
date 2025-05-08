using CEI_PRoject;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class NewInstallationStatus : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty)
                    {
                        BindGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
                    }
                        
                }
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                //Response.Redirect("/login.aspx");
            }

        }
        public void BindGrid(string searchText = null)
        {
            string LoginID = string.Empty;
            string Districtlocalpr = null;
            //added on 24 feb 2025 to filter district records against a panno
            LoginID = Session["SiteOwnerId_Sld_Indus"].ToString();
            if (Session["district_Temp"] != null)
            {
                Districtlocalpr = Session["district_Temp"].ToString();
            }

            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerInspectionDataStatus(LoginID, Districtlocalpr);
            //added on 24 feb 2025 to filter district records against a panno
            //ds = CEI.SiteOwnerInspectionDataStatus(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select" || e.CommandName == "Print" || e.CommandName == "Print1")
            {
                Session["LineID"] = "";
                Session["SubStationID"] = "";
                Session["GeneratingSetId"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspId"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                Session["IntimationId"] = lblIntimationId.Text.Trim();
                Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label LblAssignTo = (Label)row.FindControl("LblAssignTo");
                Label lblApproveDateLabel = row.FindControl("lblApproveDate") as Label;
                string ApproveDate = lblApproveDateLabel.Text;
                if (lblType.Text.Trim() == "Line")
                {
                    Session["LineID"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Substation Transformer")
                {
                    Session["SubStationID"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Generating Set")
                {
                    Session["GeneratingSetId"] = lblTestRportId.Text.Trim();
                }
                if (e.CommandName == "Select")
                {
                    if (lblApproval.Text.Trim() == "Returned")
                    {
                        Response.Redirect("/Industry_Master/ReapplyReturnInspectionForNew.aspx");

                    }
                    else
                    {
                        Response.Redirect("/Industry_Master/NewInspectionDetails.aspx");
                    }
                }
                else if (e.CommandName == "Print")
                {
                    Response.Redirect("/Industry_Master/ForNewInspectionRequestPrintForm.aspx");
                }
                else if (e.CommandName == "Print1")
                {
                    if (LblInspectionType.Text == "New")
                    {
                        if (ApproveDate != null && DateTime.TryParse(ApproveDate, out DateTime lblApproveDate))
                        {
                            DateTime comparisonDate = DateTime.Parse("2024-11-16");

                            if (lblApproveDate <= comparisonDate)
                            {
                                Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                            }

                        }
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkPrint");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                string AssignTo = DataBinder.Eval(e.Row.DataItem, "AssignTo").ToString();
                if (applicationStatus == "Approved")
                {
                    if (string.IsNullOrEmpty(AssignTo))
                    {
                        linkButton.Visible = false;
                    }
                    else
                    {
                        linkButton.Visible = true;
                    }

                }
                int reportTypeColumnIndex = 9;
                TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                if (reportTypeCell.Text == "Returned")
                {
                    e.Row.CssClass = "ReturnedRowColor";
                }


                //else
                //{

                //    linkButton.Visible = false;
                //}
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                BindGrid(searchText);
            }
            else
            {
                BindGrid();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}