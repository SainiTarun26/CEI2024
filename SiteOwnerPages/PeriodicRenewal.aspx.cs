using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static string Id, ApplicantType, ApplicantCode, Password, EInstallationType;
        string SiteOwnerID = string.Empty;
        string TypeOfInspection = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        BindAdress();
                    }
                    else
                    {
                        Response.Redirect("/login.aspx", false);
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx", false);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                installationType3.Visible = true;
                installationType2.Visible = true;
                if (RadioButtonList1.SelectedValue == "1")
                {
                    
                    divToShowLabel.Visible = false;
                    DivDetails.Visible = true;
                    btnSubmitInstallation.Visible = true;
                    btnBack.Visible = true;
                    btnReset.Visible = true;
                    //DivExistingInspectionRequest.Visible = false;
                    DivPeriodicRenewal.Visible = false;
                    GetDetails();
                    BindDistrict();
                    ddlLoadBindPremises();
                    ddlLoadBindVoltage();
                }
                else if (RadioButtonList1.SelectedValue == "0")
                {
                    divToShowLabel.Visible = true;
                    DivDetails.Visible = false;
                    btnSubmitInstallation.Visible = false;
                    btnBack.Visible = false;
                    btnReset.Visible = false;
                    Reset();
                }
                else
                {
                    DivDetails.Visible = false;
                    btnSubmitInstallation.Visible = false;
                    //DivExistingInspectionRequest.Visible = true;
                    //DivPeriodicRenewal.Visible = true;
                }
            }
            catch (Exception ex) { }
        }

        #region PeriodicRenewal
        private void BindAdress()
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    string id = Session["SiteOwnerId"].ToString();
                    DataSet dsAdress = new DataSet();
                    dsAdress = CEI.GetSiteOwnerAdress(id);
                    ddlAdress.DataSource = dsAdress;
                    ddlAdress.DataTextField = "siteownerAdress";
                    ddlAdress.DataValueField = "siteownerAdress";
                    ddlAdress.DataBind();
                    ddlAdress.Items.Insert(0, new ListItem("Select", "0"));
                    dsAdress.Clear();
                }
                else
                {
                    Response.Redirect("/login.aspx", false);
                }
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
            catch { }
        }
        //////protected void btnSearch_Click(object sender, EventArgs e)
        //////{
        //////    grid.Visible = true;
        //////    GridViewBind();
        //////    //BtnCart.Visible = true;
        //////}
        public void GridViewBind()
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                string id = Session["SiteOwnerId"].ToString();
                string Adress = ddlAdress.SelectedItem.Text;
                //int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);
                //string InstallationType = ddlInstallationType.SelectedValue;
                //Session["IntimationId"+ ] = ddlAdress.SelectedValue;
                DataSet ds = new DataSet();
                ds = CEI.GetPeriodicDetails(Adress, id);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    BtnCart.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    BtnCart.Visible = false;
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            else
            {
                Response.Redirect("/login.aspx", false);
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
            Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
            string installationtype = LblInstallationName.Text;
            //Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
            //string installationtype = lblInstallationType.Text;
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
                //bool showCheckbox = false;
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblInspectionId = e.Row.FindControl("lblInspectionId") as Label;
                    Label LblIntimationId = e.Row.FindControl("LblIntimationId") as Label;
                    Label LblInstallationType = e.Row.FindControl("LblInstallationType") as Label;
                    Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    Label lblVoltage = (Label)e.Row.FindControl("LblVoltage");
                    Label LblInspectionDate = (Label)e.Row.FindControl("LblInspectionDate");
                    if (LblInspectionDate != null && !string.IsNullOrEmpty(LblInspectionDate.Text))
                    {
                        DateTime inspectionDate;
                        if (DateTime.TryParse(LblInspectionDate.Text, out inspectionDate))
                        {
                            int remainingDays = 0;
                            string installationtype = LblInstallationName.Text;
                            int voltage;
                            DateTime Year = DateTime.MinValue;
                            if (int.TryParse(lblVoltage.Text, out voltage))
                            {
                                if (installationtype == "Line")
                                {
                                    if (voltage >= 0 && voltage <= 250)
                                    {
                                        Year = inspectionDate.AddYears(5);
                                        DateTime alertDate = Year.AddDays(-30);
                                        DateTime currentDate = DateTime.Now;
                                        remainingDays = (Year - alertDate).Days;
                                        if (currentDate >= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate <= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                                        {
                                            e.Row.Visible = true;
                                        }
                                        else
                                        {
                                            e.Row.Visible = true;
                                        }
                                    }
                                    if (voltage >= 250 && voltage <= 650)
                                    {
                                        Year = inspectionDate.AddYears(3);
                                        DateTime alertDate = Year.AddDays(-30);
                                        DateTime currentDate = DateTime.Now;
                                        remainingDays = (Year - alertDate).Days;
                                        if (currentDate >= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate <= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                                        {
                                            e.Row.Visible = true;
                                        }
                                        else
                                        {
                                            e.Row.Visible = true;
                                        }
                                    }
                                    if (voltage > 650)
                                    {
                                        Year = inspectionDate.AddYears(1);
                                        DateTime alertDate = Year.AddDays(-30);
                                        DateTime currentDate = DateTime.Now;
                                        remainingDays = (Year - alertDate).Days;
                                        if (currentDate >= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate <= Year)
                                        {
                                            remainingDays = (Year - currentDate).Days;
                                        }
                                        if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                                        {
                                            e.Row.Visible = true;
                                        }
                                        else
                                        {
                                            e.Row.Visible = true;
                                        }
                                    }
                                }

                                if (installationtype == "Generating Set")
                                {
                                    Year = inspectionDate.AddYears(3);
                                    DateTime alertDate = Year.AddDays(-30);
                                    DateTime currentDate = DateTime.Now;
                                    remainingDays = (Year - alertDate).Days;
                                    if (currentDate >= Year)
                                    {
                                        remainingDays = (Year - currentDate).Days;
                                    }
                                    if (currentDate <= Year)
                                    {
                                        remainingDays = (Year - currentDate).Days;
                                    }
                                    if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                                    {
                                        e.Row.Visible = true;
                                    }
                                    else
                                    {
                                        e.Row.Visible = true;
                                    }
                                }
                                if (installationtype == "Substation Transformer")
                                {
                                    Year = inspectionDate.AddYears(1);
                                    DateTime alertDate = Year.AddDays(-30);
                                    DateTime currentDate = DateTime.Now;
                                    remainingDays = (Year - alertDate).Days;
                                    if (currentDate >= Year)
                                    {
                                        remainingDays = (Year - currentDate).Days;

                                    }
                                    if (currentDate <= Year)
                                    {
                                        remainingDays = (Year - currentDate).Days;
                                    }
                                    if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                                    {
                                        e.Row.Visible = true;
                                    }
                                    else
                                    {
                                        e.Row.Visible = true;
                                    }
                                }
                                int dueDateColumnIndex = 10;
                                e.Row.Cells[dueDateColumnIndex].Text = Year.ToShortDateString();
                                SetRemainingDaysColumn(e.Row, remainingDays);
                            }


                            int numberofdaysColumnIndex = 11;
                            TableCell numberofdaysCell = e.Row.Cells[numberofdaysColumnIndex];

                            int numberofdays;
                            if (int.TryParse(numberofdaysCell.Text, out numberofdays))
                            {
                                if (numberofdays < 0)
                                {
                                    e.Row.Cells[numberofdaysColumnIndex].CssClass = "OrangeBackground";
                                    e.Row.Cells[numberofdaysColumnIndex].Text = "Yes";
                                    //showCheckbox = true;
                                }
                                else
                                {
                                    e.Row.Cells[11].Text = "No";
                                    //showCheckbox = false;
                                }
                                //if (numberofdays == 0 || (numberofdays > 0 && numberofdays <= 15))
                                //{
                                //    e.Row.Cells[11].CssClass = "GreenBackground";
                                //}
                                //else if (numberofdays < 0)
                                //{
                                //    e.Row.Cells[11].CssClass = "OrangeBackground";
                                //}
                                //else if (numberofdays < 30 && numberofdays > 15)
                                //{
                                //    e.Row.Cells[11].CssClass = "YellowBackground";
                                //}
                            }
                            //int checkboxColumnIndex = 0;
                            //TableCell checkboxCell = e.Row.Cells[checkboxColumnIndex];
                            //checkboxCell.Controls.Clear();
                            //if (showCheckbox)
                            //{
                            //    checkboxCell.Controls.Add(new CheckBox());
                            //}
                        }

                    }

                    //DateTime inspectionDate = DateTime.Parse(LblInspectionDate.Text);
                    //int remainingDays = 0;
                    //string installationtype = LblInstallationName.Text;
                    //int voltage;
                    //DateTime Year = DateTime.MinValue;

                    //if (int.TryParse(lblVoltage.Text, out voltage))
                    //{
                    //    if (installationtype == "Line")
                    //    {
                    //        if (voltage >= 0 && voltage <= 250)
                    //        {
                    //            Year = inspectionDate.AddYears(5);
                    //            DateTime alertDate = Year.AddDays(-30);
                    //            DateTime currentDate = DateTime.Now;
                    //            remainingDays = (Year - alertDate).Days;
                    //            if (currentDate >= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate <= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                    //            {
                    //                e.Row.Visible = true;
                    //            }
                    //            else
                    //            {
                    //                e.Row.Visible = false;
                    //            }
                    //        }
                    //        if (voltage >= 250 && voltage <= 650)
                    //        {
                    //            Year = inspectionDate.AddYears(3);
                    //            DateTime alertDate = Year.AddDays(-30);
                    //            DateTime currentDate = DateTime.Now;
                    //            remainingDays = (Year - alertDate).Days;
                    //            if (currentDate >= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate <= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                    //            {
                    //                e.Row.Visible = true;
                    //            }
                    //            else
                    //            {
                    //                e.Row.Visible = false;
                    //            }
                    //        }
                    //        if (voltage > 650)
                    //        {
                    //            Year = inspectionDate.AddYears(1);
                    //            DateTime alertDate = Year.AddDays(-30);
                    //            DateTime currentDate = DateTime.Now;
                    //            remainingDays = (Year - alertDate).Days;
                    //            if (currentDate >= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate <= Year)
                    //            {
                    //                remainingDays = (Year - currentDate).Days;
                    //            }
                    //            if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                    //            {
                    //                e.Row.Visible = true;
                    //            }
                    //            else
                    //            {
                    //                e.Row.Visible = false;
                    //            }
                    //        }
                    //    }

                    //    if (installationtype == "Generating Set")
                    //    {
                    //        Year = inspectionDate.AddYears(3);
                    //        DateTime alertDate = Year.AddDays(-30);
                    //        DateTime currentDate = DateTime.Now;
                    //        remainingDays = (Year - alertDate).Days;
                    //        if (currentDate >= Year)
                    //        {
                    //            remainingDays = (Year - currentDate).Days;
                    //        }
                    //        if (currentDate <= Year)
                    //        {
                    //            remainingDays = (Year - currentDate).Days;
                    //        }
                    //        if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                    //        {
                    //            e.Row.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            e.Row.Visible = false;
                    //        }
                    //    }
                    //    if (installationtype == "Substation Transformer")
                    //    {
                    //        Year = inspectionDate.AddYears(1);
                    //        DateTime alertDate = Year.AddDays(-30);
                    //        DateTime currentDate = DateTime.Now;
                    //        remainingDays = (Year - alertDate).Days;
                    //        if (currentDate >= Year)
                    //        {
                    //            remainingDays = (Year - currentDate).Days;

                    //        }
                    //        if (currentDate <= Year)
                    //        {
                    //            remainingDays = (Year - currentDate).Days;
                    //        }
                    //        if (currentDate >= alertDate || currentDate >= Year || currentDate == alertDate)
                    //        {
                    //            e.Row.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            e.Row.Visible = false;
                    //        }
                    //    }
                    //    int dueDateColumnIndex = 10;
                    //    e.Row.Cells[dueDateColumnIndex].Text = Year.ToShortDateString();
                    //    SetRemainingDaysColumn(e.Row, remainingDays);
                    //}


                    //int numberofdaysColumnIndex = 11;
                    //TableCell numberofdaysCell = e.Row.Cells[numberofdaysColumnIndex];

                    //int numberofdays;
                    //if (int.TryParse(numberofdaysCell.Text, out numberofdays))
                    //{
                    //    if (numberofdays == 0 || (numberofdays > 0 && numberofdays <= 15))
                    //    {
                    //        e.Row.Cells[11].CssClass = "GreenBackground";
                    //    }
                    //    else if (numberofdays < 0)
                    //    {
                    //        e.Row.Cells[11].CssClass = "OrangeBackground";
                    //    }
                    //    else if (numberofdays < 30 && numberofdays > 15)
                    //    {
                    //        e.Row.Cells[11].CssClass = "YellowBackground";
                    //    }
                    //}
                    else
                    {
                        e.Row.Cells[11].CssClass = "OrangeBackground";
                        e.Row.Cells[11].Text = "Yes";

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void SetRemainingDaysColumn(GridViewRow row, int remainingDays)
        {
            row.Cells[11].Text = remainingDays.ToString();

        }
        protected void BtnCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    string id = Session["SiteOwnerId"].ToString();
                    bool atLeastOneChecked = false;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            atLeastOneChecked = true;
                            Label LblIntimationId = (Label)row.FindControl("LblIntimationId") as Label;
                            string IntimationId = LblIntimationId.Text;
                            Label lblInspectionId = (Label)row.FindControl("lblInspectionId") as Label;
                            string InspectionId = lblInspectionId.Text;
                            //int InspectionId = Convert.ToInt32(row.Cells[3].Text);
                            Label LblInstallationType = (Label)row.FindControl("LblInstallationType");
                            string InstallationType = LblInstallationType.Text;
                            Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                            string TestReportId = LblTestReportId.Text;
                            Label LblinspectionDate = (Label)row.FindControl("LblinspectionDate");
                            string inspectionDate = LblinspectionDate.Text;
                            Label LblinspectionDueDate = (Label)row.FindControl("LblinspectionDueDate");
                            string inspectionDueDate = LblinspectionDueDate.Text;
                            //Label LblNumberofdays = (Label)row.FindControl("LblNumberofdays");
                            //string DelayedDays = LblNumberofdays.Text;
                            Label LblVoltage = (Label)row.FindControl("LblVoltage");
                            string Voltage = LblVoltage.Text;
                            Label LblCapacity = (Label)row.FindControl("LblCapacity");
                            string Capacity = LblCapacity.Text;
                            Label LblAddress = (Label)row.FindControl("LblAddress");
                            string Address = LblAddress.Text;
                            Label LblCompleteAdress = (Label)row.FindControl("LblCompleteAdress");
                            string CompleteAddress = LblCompleteAdress.Text;
                            Label LblADRESSDistrict = (Label)row.FindControl("LblADRESSDistrict");
                            string AddressDistrict = LblADRESSDistrict.Text;
                            Label LblOwnerName = (Label)row.FindControl("LblOwnerName");
                            string OwnerName = LblOwnerName.Text;
                            Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                            string InstallationName = LblInstallationName.Text;
                            Label LblDivision = (Label)row.FindControl("LblDivision");
                            string Division = LblDivision.Text;
                            Label LblDistrict = (Label)row.FindControl("LblDistrict");
                            string District = LblDistrict.Text;
                            Label lblCount = (Label)row.FindControl("LblCount") as Label;
                            string Count = lblCount.Text;


                            CEI.InsertInspectionRenewalData(IntimationId, InspectionId, InstallationType, InstallationName, TestReportId, Count, inspectionDate,
                                 inspectionDueDate, /*DelayedDays*/ Voltage, Capacity, Address, CompleteAddress, AddressDistrict, OwnerName, District, Division, id, "1");

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                    }
                    if (!atLeastOneChecked)
                    {
                        Response.Write("<script>alert('Please select at least one Inspection');</script>");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        //protected void ddlNoOfDays_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);
        //}
        //protected void ddlInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string InstallationType = ddlInstallationType.SelectedValue;
        //}
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("DetailsOfInstallations.aspx", false);
        //}
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PeriodicRenewal.aspx", false);
        }
        protected void ddlAdress_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.Visible = true;
            GridViewBind();
        }
        #endregion

        #region List Of Existing Installation
        //private void getWorkIntimationDataForListOfExisting()
        //{
        //    string Id = Session["SiteOwnerId"].ToString();

        //    DataSet ds = new DataSet();
        //    ds = CEI.ExistingInspectionData(Id);

        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        GridView2.DataSource = ds;
        //        GridView2.DataBind();
        //    }
        //    else
        //    {
        //        DivExistingInspectionRequest.Visible = false;
        //        GridView2.DataSource = null;
        //        GridView2.DataBind();
        //        //string script = "alert(\"No Record Found\");";
        //        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    }
        //    ds.Dispose();
        //}
        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Select")
        //        {
        //            Control ctrl = e.CommandSource as Control;
        //            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //            Label lblID = (Label)row.FindControl("lblID");
        //            Session["id"] = lblID.Text;
        //            Response.Redirect("/SiteOwnerPages/ExistingInspectionData.aspx", false);
        //        }
        //        else
        //        {
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    getWorkIntimationDataForListOfExisting();
        //}

        #endregion

        #region Details Of Installation
        private void ddlLoadBindVoltage()
        {
            try
            {
                DataSet dsVoltage = new DataSet();
                //dsVoltage = CEI.GetddlVoltageLevel();
                dsVoltage = CEI.GetVoltageLevelForSiteownerIntimation();
                ddlVoltageLevel.DataSource = dsVoltage;
                ddlVoltageLevel.DataTextField = "Voltagelevel";
                ddlVoltageLevel.DataValueField = "VoltageID";
                ddlVoltageLevel.DataBind();
                ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
                dsVoltage.Clear();
            }
            catch (Exception ex) { }
        }
        private void ddlLoadBindPremises()
        {
            try
            {
                DataSet dsPremises = new DataSet();
                dsPremises = CEI.GetddlPremises();
                ddlPremises.DataSource = dsPremises;
                ddlPremises.DataTextField = "Premises";
                ddlPremises.DataValueField = "ID";
                ddlPremises.DataBind();
                ddlPremises.Items.Insert(0, new ListItem("Select", "0"));
                if (ApplicantType == "Private/Personal Installation" || ApplicantType == "Power Utility" || ApplicantType == "Other Department/Organization")
                {
                    ListItem industryItem = ddlPremises.Items.FindByText("Industry");
                    if (industryItem != null)
                    {
                        ddlPremises.Items.Remove(industryItem);
                    }
                }
                dsPremises.Clear();
            }
            catch (Exception ex) { }
        }
        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex) { }
        }
        private void GetDetails()
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                Id = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataAtSiteOwner(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    ApplicantType = txtApplicantType.Text;
                    ApplicantCode = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();

                    txtPAN.Text = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                    txtElecticalInstallation.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    EInstallationType = txtElecticalInstallation.Text;

                    if (EInstallationType == "Individual Person")
                    {
                        individual.Visible = true;
                    }
                    else if (EInstallationType == "Firm/Company")
                    {
                        agency.Visible = true;
                    }

                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();

                    if (ApplicantType == "Private/Personal Installation")
                    {
                        PowerUtility.Visible = false;
                        UserId.Visible = false;
                        string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                        DivPancard_TanNo.Visible = true;
                        txtPAN.Text = PanTanNumber;
                    }
                    else if (ApplicantType == "Other Department/Organization")
                    {
                        string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                        DivOtherDepartment.Visible = true;
                        txtTanNumber.Text = PanTanNumber;
                        PowerUtility.Visible = false;
                        UserId.Visible = false;
                    }
                    else if (ApplicantType == "Power Utility")
                    {
                        string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                        txtUserId.Text = PanTanNumber;
                        UserId.Visible = true;
                        NameUtility.Visible = true;
                        Wing.Visible = true;
                        PowerUtility.Visible = true;
                    }
                    txtUtilityName.Text = ds.Tables[0].Rows[0]["PowerUtility"].ToString();
                    txtWing.Text = ds.Tables[0].Rows[0]["PowerUtilityWing"].ToString();
                    txtZone.Text = ds.Tables[0].Rows[0]["ZoneName"].ToString();
                    txtCircle.Text = ds.Tables[0].Rows[0]["CircleName"].ToString();
                    txtDivision.Text = ds.Tables[0].Rows[0]["DivisionName"].ToString();
                    txtSubDivision.Text = ds.Tables[0].Rows[0]["SubDivisionName"].ToString();
                    Password = ds.Tables[0].Rows[0]["SiteOwnerPassword"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                }
            }
            else
            {
                Response.Redirect("/login.aspx", false);
            }
        }
        protected void ddlPremises_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPremises.SelectedValue == "11")
                {
                    OtherPremises.Visible = true;
                }
                else
                {
                    OtherPremises.Visible = false;
                }
            }
            catch (Exception ex) { }
        }
        protected void btnSubmitInstallation_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                Id = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataAtSiteOwner(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ApplicantType = txtApplicantType.Text;
                    ApplicantCode = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();
                    Password = ds.Tables[0].Rows[0]["SiteOwnerPassword"].ToString();
                }
                else
                {
                    ApplicantType = "";
                    ApplicantCode = "";
                    Password = "";
                }
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        string Pan_TanNumber = "";
                        if (DivPancard_TanNo.Visible && !string.IsNullOrEmpty(txtPAN.Text.Trim()))
                        {
                            Pan_TanNumber = txtPAN.Text.Trim();
                        }
                        else if (DivOtherDepartment.Visible && !string.IsNullOrEmpty(txtTanNumber.Text.Trim()))
                        {
                            Pan_TanNumber = txtTanNumber.Text.Trim();
                        }
                        else if (PowerUtility.Visible)
                        {
                            if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                            {
                                string email = txtEmail.Text.Trim();
                                if (email.Contains("@"))
                                {
                                    Pan_TanNumber = email.Split('@')[0];
                                }
                            }
                            else
                            {
                                Pan_TanNumber = txtUserId.Text.Trim();
                            }
                        }
                        if (string.IsNullOrEmpty(Pan_TanNumber))
                        {
                            throw new Exception("Pan/Tan Number cannot be empty.");
                        }

                        // Insert data
                        CEI.IntimationDataInsertionBySiteowner(
                            Id,
                            txtApplicantType.Text.Trim(),
                            /*ddlApplicantType.SelectedItem.ToString(),*/////------------------------------------
                            ApplicantCode,
                            //ddlApplicantType.SelectedValue.ToString(),
                            txtElecticalInstallation.Text.Trim(),
                            //ddlPoweUtility.SelectedItem.ToString(),
                            //DdlWing.SelectedItem.ToString(),
                            //DdlZone.SelectedItem.ToString(),
                            //DdlCircle.SelectedItem.ToString(),
                            //DdlDivision.SelectedItem.ToString(), 
                            //DdlSubDivision.SelectedItem.ToString(),
                            txtUtilityName.Text.Trim(),
                            txtWing.Text.Trim(),
                            txtZone.Text.Trim(),
                            txtCircle.Text.Trim(),
                            txtDivision.Text.Trim(),
                            txtSubDivision.Text.Trim(),
                            txtName.Text.Trim(),
                            txtagency.Text.Trim(),
                            txtPhone.Text.Trim(),
                            txtAddress.Text.Trim(),
                            ddlDistrict.SelectedItem.ToString(),
                            txtPin.Text.Trim(),
                            ddlPremises.SelectedItem.ToString(),
                            txtOtherPremises.Text.Trim(),
                            ddlVoltageLevel.SelectedValue.ToString(),
                            Pan_TanNumber,
                            txtinstallationType2.Text.Trim(),
                            txtinstallationNo2.Text.Trim(),
                            txtinstallationType3.Text.Trim(),
                            txtinstallationNo3.Text.Trim(),
                            txtEmail.Text.Trim(),
                            Id,
                            RadioButtonList2.SelectedValue.ToString(),
                            "Existing",
                            txtCapacity.Text.Trim(),
                            txtSanctionLoad.Text.Trim(),
                            Password,
                            transaction
                        );

                        TypeOfInspection = "Existing";
                        string projectId = CEI.projectId();

                        if (!string.IsNullOrEmpty(projectId))
                        {
                            TextBox[] typeTextBoxes = { txtinstallationType2, txtinstallationType3 };
                            TextBox[] noTextBoxes = { txtinstallationNo2, txtinstallationNo3 };

                            for (int i = 0; i < typeTextBoxes.Length; i++)
                            {
                                string installationType = typeTextBoxes[i].Text;
                                string installationNoText = noTextBoxes[i].Text;

                                if (int.TryParse(installationNoText, out int installationNo) && installationNo > 0)
                                {
                                    for (int j = 0; j < installationNo; j++)
                                    {
                                        CEI.AddInstallationsCreatedbySiteOwner(projectId, installationType, installationNo, Id, TypeOfInspection, transaction);
                                    }
                                }
                            }
                        }
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of Installation Submitted Successfully !!!')", true);
                        transaction.Commit();
                        Reset();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of Installation Submitted Successfully !!!'); window.location='RatingOfInstallations.aspx';", true);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/login.aspx", false);
            }
        }
        private void Reset()
        {
            txtAddress.Text = "";
            ddlDistrict.SelectedValue = "0";
            txtPin.Text = "";
            txtOtherPremises.Text = "";
            ddlVoltageLevel.SelectedValue = "0";
            ddlPremises.SelectedValue = "0";
            RadioButtonList2.ClearSelection();
            txtSanctionLoad.Text = "";
            txtCapacity.Text = "";
            divSanctionLoad.Visible = false;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList2.SelectedValue == "1")
                {
                    divSanctionLoad.Visible = true;
                }
                else
                {
                    divSanctionLoad.Visible = false;
                }
            }
            catch (Exception ex) { }
        }
        protected void imgDelete2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (installationType3.Visible == true)
                {
                    string valueToAddBack = txtinstallationType2.Text;

                    if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
                    {
                        ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                        ddlWorkDetail.Items.Add(newItem);
                    }
                    installationType2.Visible = false;
                    //txtinstallationType2.Text = string.Empty;
                    txtinstallationNo2.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('One Installation Is Mandatory');", true);

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
            }
        }
        protected void imgDelete3_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                if (installationType2.Visible == true)
                {
                    string valueToAddBack = txtinstallationType3.Text;
                    if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
                    {
                        ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                        ddlWorkDetail.Items.Add(newItem);
                    }
                    installationType3.Visible = false;
                   // txtinstallationType3.Text = string.Empty;
                    txtinstallationNo3.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('One Installation Is Mandatory');", true);

                }
            }
            catch (Exception ex) { }
        }
        protected void ddlVoltageLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                installationType2.Visible = true;
                if (ddlVoltageLevel.SelectedValue == "upto 650 V")
                {
                    installationType2.Visible = false;
                }
                else
                {
                    installationType2.Visible = true;
                }
            }
            catch (Exception ex) { }
        }
    }


    #endregion
}