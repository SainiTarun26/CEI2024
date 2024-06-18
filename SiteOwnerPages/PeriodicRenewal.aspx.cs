using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
                    {
                        BindAdress();
                       // grid.Visible = false;
                        //BindInstallationType();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        private void BindAdress()
        {
            try
            {
                string id = Session["SiteOwnerId"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetSiteOwnerAdress(id);
                ddlAdress.DataSource = dsAdress;
                ddlAdress.DataTextField = "siteownerAdress";
                ddlAdress.DataValueField = "Address";
                ddlAdress.DataBind();
                ddlAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch
            {

            }
        }


        //private void BindInstallationType()
        //{
        //    try
        //    {
        //        DataSet dsInstallation = new DataSet();
        //        dsInstallation = CEI.GetInstallationType();
        //        ddlInstallationType.DataSource = dsInstallation;
        //        ddlInstallationType.DataTextField = "InstallationType";
        //        ddlInstallationType.DataValueField = "ID";
        //        ddlInstallationType.DataBind();
        //        ddlInstallationType.Items.Insert(0, new ListItem("Select", "0"));
        //        dsInstallation.Clear();
        //    }
        //    catch
        //    {

        //    }
        //}

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grid.Visible = true;
            GridViewBind();
        }
         
        public void GridViewBind()
        { 
            string id = Session["SiteOwnerId"].ToString();
            string Adress = ddlAdress.SelectedItem.Text;
            int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);
            string InstallationType = ddlInstallationType.SelectedValue;
            //Session["IntimationId"+ ] = ddlAdress.SelectedValue;
            DataSet ds = new DataSet();
            ds = CEI.GetPeriodicDetails(Adress, id, numberOfDays, InstallationType);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

            }
        }


        //protected void BtnProcess_Click(object sender, EventArgs e)
        //{

        //    List<string> selectedInspectionIdsList = new List<string>();

        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
        //        if (chk != null && chk.Checked)
        //        {

        //            int inspectionId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        //            selectedInspectionIdsList.Add(inspectionId.ToString());

        //        }
        //    }

        //    if (selectedInspectionIdsList.Count > 0)
        //    {

        //        string selectedInspectionIdsString = string.Join(",", selectedInspectionIdsList);

        //         Session["SelectedInspectionId"] = selectedInspectionIdsString;

        //        Response.Redirect("InspectionRenewal.aspx", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Declaration');", true);
        //    }
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
            string installationtype = lblInstallationType.Text;
            string testReportId = e.CommandArgument.ToString();



            if (installationtype == "Line")
            {
                Session["LineID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Substation Transformer")
            {
                Session["SubStationID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Generating Set")
            {
                Session["GeneratingSetId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    int numberofdaysColumnIndex = 9;
                    TableCell numberofdaysCell = e.Row.Cells[numberofdaysColumnIndex];

                    int numberofdays;
                    if (int.TryParse(numberofdaysCell.Text, out numberofdays))
                    {
                        if (numberofdays > 30)
                        {
                            e.Row.Cells[9].CssClass = "GreenBackground";
                        }
                        else if (numberofdays < 15)
                        {
                            e.Row.Cells[9].CssClass = "OrangeBackground";
                        }
                        else if (numberofdays < 30 && numberofdays > 15)
                        {
                            e.Row.Cells[9].CssClass = "YellowBackground";
                        }
                    }
                }
            }

            catch (Exception ex)
            { }
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SiteOwnerId"] != null)
                {
                    string id = Session["SiteOwnerId"].ToString();
                    bool atLeastOneChecked = false;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            atLeastOneChecked = true;

                            string IntimationId = row.Cells[2].Text;
                            int InspectionId = Convert.ToInt32(row.Cells[3].Text);
                            Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                            string InstallationType = LblInstallationType.Text;
                            Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                            string TestReportId = LblTestReportId.Text;
                            Label LblinspectionDate = (Label)row.FindControl("LblinspectionDate");
                            string inspectionDate = LblinspectionDate.Text;

                            Label LblinspectionDueDate = (Label)row.FindControl("LblinspectionDueDate");
                            string inspectionDueDate = LblinspectionDueDate.Text;
                            Label LblNumberofdays = (Label)row.FindControl("LblNumberofdays");
                            string DelayedDays = LblNumberofdays.Text;
                            Label LblVoltage = (Label)row.FindControl("LblVoltage");
                            string Voltage = LblVoltage.Text;
                            Label LblCapacity = (Label)row.FindControl("LblCapacity");
                            string Capacity = LblCapacity.Text;

                            Label LblAddress = (Label)row.FindControl("LblAddress");
                            string Address = LblAddress.Text;

                            CEI.InsertInspectionRenewalData(IntimationId, InspectionId, InstallationType, TestReportId, inspectionDate,
                            inspectionDueDate, DelayedDays, Voltage, Capacity, Address, id, "1");

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                    }
                    if (!atLeastOneChecked)
                    {
                        Response.Write("<script>alert('Please select at least one Supervisor.');</script>");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlNoOfDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);

        }

        protected void ddlInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = ddlInstallationType.SelectedValue;
        }
    }
}