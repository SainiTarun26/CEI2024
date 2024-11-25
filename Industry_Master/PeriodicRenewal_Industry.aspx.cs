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

namespace CEIHaryana.Industry_Master
{
    public partial class PeriodicRenewal_Industry : System.Web.UI.Page
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
                    //Session["SiteOwnerId_Industry"] = "BDJPB4957Q";
                    Session["SiteOwnerId_Industry"] = "1123";
                    Session["district_Temp"] = "Ambala";
                    Session["Serviceid_pd_Indus"] = "ec289b0f-e803-4bce-9dc2-d1d5ce93ba5a";
                    Session["projectid_pd_Indus"] = "1";
                    if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                    {
                        //if (CheckInspectionStatus())
                        //{
                        //    Response.Redirect("InspectionHistory_Industry.aspx", false);
                        //    return;
                        //}
                        BindAdress();
                        //getWorkIntimationDataForListOfExisting();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
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

                    BindListBoxInstallationType(); ;
                }
                else if (RadioButtonList1.SelectedValue == "0")
                {
                    divToShowLabel.Visible = true;
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
                string id = Session["SiteOwnerId_Industry"].ToString();
                string District = Session["district_Temp"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetSiteOwnerAdress_Industries(id, District);
                ddlAdress.DataSource = dsAdress;
                ddlAdress.DataTextField = "siteownerAdress";
                ddlAdress.DataValueField = "siteownerAdress";
                ddlAdress.DataBind();
                ddlAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch
            {
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch { }
        }

        public void GridViewBind()
        {
            string id = Session["SiteOwnerId_Industry"].ToString();
            string Adress = ddlAdress.SelectedItem.Text;
            //int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);
            //string InstallationType = ddlInstallationType.SelectedValue;
            //Session["SiteOwnerId_Industry"+ ] = ddlAdress.SelectedValue;
            DataSet ds = new DataSet();
            ds = CEI.GetPeriodicDetails_Industries(Adress, id);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string LoginID = Session["SiteOwnerId_Industry"].ToString();
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
            string installationtype = LblInstallationName.Text;
            //Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
            //string installationtype = lblInstallationType.Text;
            string testReportId = e.CommandArgument.ToString();

            if (installationtype == "Line")
            {
                Session["LineID_Industry"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Substation Transformer")
            {
                Session["SubStationID_Industry"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Generating Set")
            {
                Session["GeneratingSetId_Industry"] = testReportId;
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
                if (Session["SiteOwnerId_Industry"] != null)
                {
                    string id = Session["SiteOwnerId_Industry"].ToString();
                    bool atLeastOneChecked = false;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk.Checked)
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
        //    string Id = Session["SiteOwnerId_Industry"].ToString();

        //    DataSet ds = new DataSet();
        //    ds = CEI.ExistingInspectionData_Industries(Id);

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
        //            Session["id_Industry"] = lblID.Text;
        //            Response.Redirect("/Industry_Master/ExistingInspectionData_Industry.aspx", false);
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
                dsVoltage = CEI.GetVoltageLevelForSiteownerIntimation_Industries();
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
                dsPremises = CEI.GetddlPremises_Industries();
                ddlPremises.DataSource = dsPremises;
                ddlPremises.DataTextField = "Premises";
                ddlPremises.DataValueField = "ID";
                ddlPremises.DataBind();
                ddlPremises.Items.Insert(0, new ListItem("Select", "0"));
                dsPremises.Clear();
                string dp_Id241 = "Industry";
                ListItem selectedItem = ddlPremises.Items.FindByText(dp_Id241);

                if (selectedItem != null)
                {
                    ddlPremises.SelectedIndex = ddlPremises.Items.IndexOf(selectedItem);
                }
                //ddlPremises.Attributes.Add("disabled", "disabled");
                ddlPremises.Enabled = false;
            }
            catch (Exception ex) { }
        }
        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict_Industries();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
                string dp_Id24 = Session["district_Temp"].ToString();
                ListItem selectedItem = ddlDistrict.Items.FindByText(dp_Id24);

                if (selectedItem != null)
                {
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(selectedItem);
                }
                ddlDistrict.Enabled = false;
                //ddlDistrict.Attributes.Add("disabled", "disabled");

            }
            catch (Exception ex) { }
        }
        private void GetDetails()
        {
            Id = Session["SiteOwnerId_Industry"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetPeriodicRenualDataAtSiteOwner_Industries(Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["TestReportGenerated"] = ds.Tables[0].Rows[0]["TestReportGenerated"].ToString();
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
                else if (EInstallationType == "Firm/Organization/Company/Department")
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
                    DivPancard_TanNo.Visible = true;
                    txtPAN.Text = Session["SiteOwnerId_Industry"].ToString();
                    PowerUtility.Visible = true;
                    InstallationFor.Visible = false;
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
            else
            {
                Session["TestReportGenerated"] = "";
                txtCircle.Visible = false;
                DdlCircle.Visible = true;
                txtSubDivision.Visible = false;
                ddlworktype.Visible = true;
                txtElecticalInstallation.Visible = false;
                DdlSubDivision.Visible = true;
                txtDivision.Visible = false;
                DdlDivision.Visible = true;
                txtApplicantType.Visible = false;
                ddlApplicantType.Visible = true;
                txtZone.Visible = false;
                DdlZone.Visible = true;
                txtWing.Visible = false;
                DdlWing.Visible = true;
                txtUtilityName.Visible = false;
                ddlPoweUtility.Visible = true;
                txtPAN.Text = Session["SiteOwnerId_Industry"].ToString();
                txtPhone.ReadOnly = false;
                txtTanNumber.Text = Session["SiteOwnerId_Industry"].ToString();
                txtEmail.ReadOnly = false;
                ddlPremises.Enabled = true;
                txtName.ReadOnly = false;
                txtagency.ReadOnly = false;
            }
        }
        protected void worktypevisiblity()
        {
            try
            {
                if (ddlworktype.SelectedValue == "1")
                {
                    individual.Visible = true;
                    agency.Visible = false;
                    txtagency.Text = "";
                }
                else if (ddlworktype.SelectedValue == "2")
                {
                    individual.Visible = false;
                    agency.Visible = true;
                    txtName.Text = "";
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }
            }
            catch { }

        }
        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktypevisiblity();
        }
        protected void DdlSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DdlSubDivision.SelectedValue.ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetSubDivisionEmail(id);
            txtPhone.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtUserId.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["SubDivision"].ToString();

        }
        protected void DdlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlSubDivisionBind();
        }
        private void DdlSubDivisionBind()
        {
            try
            {
                string id = DdlDivision.SelectedValue.ToString();
                DataSet dsSubDivision = new DataSet();
                dsSubDivision = CEI.GetSubDivisionName(id);
                DdlSubDivision.DataSource = dsSubDivision;
                DdlSubDivision.DataTextField = "SubDivision";
                DdlSubDivision.DataValueField = "Id";
                DdlSubDivision.DataBind();
                DdlSubDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsSubDivision.Clear();
            }
            catch
            {
            }

        }
        private void DdlDivisionBind()
        {
            try
            {
                string id = DdlCircle.SelectedValue.ToString();
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.GetDivisionName(id);
                DdlDivision.DataSource = dsDivision;
                DdlDivision.DataTextField = "DivisionName";
                DdlDivision.DataValueField = "Id";
                DdlDivision.DataBind();
                DdlDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
            }
            catch
            {
            }

        }
        protected void DdlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDivisionBind();
        }
        private void DdlCircleBind()
        {
            try
            {
                string Id = DdlZone.SelectedValue.ToString();
                DataSet dsCircle = new DataSet();
                dsCircle = CEI.GetCirclesName(Id);
                DdlCircle.DataSource = dsCircle;
                DdlCircle.DataTextField = "CircleName";
                DdlCircle.DataValueField = "Id";
                DdlCircle.DataBind();
                DdlCircle.Items.Insert(0, new ListItem("Select", "0"));
                dsCircle.Clear();
            }
            catch
            {
            }

        }
        protected void DdlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCircleBind();

        }
        private void DdlWingBind()
        {
            try
            {
                string Id = ddlPoweUtility.SelectedValue.ToString();
                DataSet dsWing = new DataSet();
                dsWing = CEI.GetWingName(Id);
                DdlWing.DataSource = dsWing;
                DdlWing.DataTextField = "WingName";
                DdlWing.DataValueField = "Id";
                DdlWing.DataBind();
                DdlWing.Items.Insert(0, new ListItem("Select", "0"));
                dsWing.Clear();
            }
            catch
            {
            }

        }
        protected void DdlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlZoneBind();
        }
        private void DdlZoneBind()
        {
            try
            {
                string Id = DdlWing.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                dsZone = CEI.GetZoneName(Id);
                DdlZone.DataSource = dsZone;
                DdlZone.DataTextField = "ZoneName";
                DdlZone.DataValueField = "Id";
                DdlZone.DataBind();
                DdlZone.Items.Insert(0, new ListItem("Select", "0"));
                dsZone.Clear();
            }
            catch
            {
            }

        }
        private void ddlPoweUtilityBind()
        {
            try
            {

                DataSet dsUtility = new DataSet();
                dsUtility = CEI.GetUtilityName();
                ddlPoweUtility.DataSource = dsUtility;
                ddlPoweUtility.DataTextField = "UtilityName";
                ddlPoweUtility.DataValueField = "Id";
                ddlPoweUtility.DataBind();
                ddlPoweUtility.Items.Insert(0, new ListItem("Select", "0"));
                dsUtility.Clear();

            }
            catch
            {
            }

        }
        protected void ddlPoweUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlWingBind();
        }
        private void BindListBoxInstallationType()
        {
            DataSet dsWorkDetail = new DataSet();
            dsWorkDetail = CEI.GetddlInstallationType();
            ddlWorkDetail.DataSource = dsWorkDetail;
            ddlWorkDetail.DataTextField = "InstallationType";
            ddlWorkDetail.DataValueField = "Id";
            ddlWorkDetail.DataBind();
            ddlWorkDetail.Items.Insert(0, new ListItem("Select", "0"));
            dsWorkDetail.Clear();
        }
        protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivOtherDepartment.Visible = false;
            DivPancard_TanNo.Visible = false;
            //ElectricalInstallation.Visible = true;
            //DivPoweUtility.Visible = false;
            //DivPoweUtilityWing.Visible = false;
            string Value = ddlWorkDetail.SelectedItem.ToString();
            if (ddlWorkDetail.SelectedValue != "0")
            {
                Installation.Visible = true;

                if (string.IsNullOrEmpty(txtinstallationType2.Text))
                {
                    installationType2.Visible = true;
                    txtinstallationType2.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType3.Text))
                {
                    installationType3.Visible = true;
                    txtinstallationType3.Text = Value;
                }
                //else if (string.IsNullOrEmpty(txtinstallationType4.Text))
                //{
                //    installationType4.Visible = true;
                //    txtinstallationType4.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType5.Text))
                //{
                //    installationType5.Visible = true;
                //    txtinstallationType5.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType6.Text))
                //{

                //    installationType6.Visible = true;
                //    txtinstallationType6.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType7.Text))
                //{
                //    installationType7.Visible = true;
                //    txtinstallationType7.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType8.Text))
                //{
                //    installationType8.Visible = true;
                //    txtinstallationType8.Text = Value;
                //}
                if (ddlWorkDetail.SelectedValue != "0")
                {
                    try
                    {
                        string selectedValue = ddlWorkDetail.SelectedValue;
                        ListItem itemToRemove = ddlWorkDetail.Items.FindByValue(selectedValue);
                        if (itemToRemove != null)
                        {
                            ddlWorkDetail.Items.Remove(itemToRemove);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    ddlWorkDetail.SelectedValue = "0";
                }


            }
            if (ddlApplicantType.SelectedValue == "AT001")
            {
                //ElectricalInstallation.Visible = true;
                DivPancard_TanNo.Visible = true;
                txtTanNumber.Text = "";
                PowerUtility.Visible = false;
                NameUtility.Visible = false;
                Wing.Visible = false;
            }
            else if (ddlApplicantType.SelectedValue == "AT002")
            {
                NameUtility.Visible = true;
                Wing.Visible = true;
                PowerUtility.Visible = true;
                //ElectricalInstallation.Visible= false;
                ddlPoweUtilityBind();
                //DivPoweUtilityWing.Visible = true;
                txtTanNumber.Text = "";
                txtPAN.Text = "";
            }
            else if (ddlApplicantType.SelectedValue == "AT003")
            {
                //ElectricalInstallation.Visible = true;
                PowerUtility.Visible = false;
                NameUtility.Visible = false;
                Wing.Visible = false;
                DivOtherDepartment.Visible = true;
                txtPAN.Text = "";
            }
            ddlPoweUtility.SelectedValue = "0";
            DdlWing.SelectedValue = "0";
            DdlZone.SelectedValue = "0";
            DdlCircle.SelectedValue = "0";
            DdlDivision.SelectedValue = "0";
            DdlSubDivision.SelectedValue = "0";

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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string Pan_TanNumber = "";
                    string PowerUtilityname = "";
                    string PowerUtilitywing = "";
                    string ZoneName = "";
                    string CircleName = "";
                    string DivisionName = "";
                    string SubdivisionName = "";
                    string applicantType = "";

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
                    if (NameUtility.Visible == true && ddlPoweUtility.Visible == true)
                    {
                        PowerUtilityname = ddlPoweUtility.SelectedItem.ToString();
                        PowerUtilitywing = DdlWing.SelectedItem.ToString();
                    }
                    else
                    {
                        PowerUtilityname = txtUtilityName.Text.Trim();
                        PowerUtilitywing = txtWing.Text.Trim();

                    }
                    if (PowerUtility.Visible == true && DdlZone.Visible == true)
                    {
                        ZoneName = DdlZone.SelectedItem.ToString();
                        CircleName = DdlCircle.SelectedItem.ToString();
                        DivisionName = DdlDivision.SelectedItem.ToString();
                        SubdivisionName = DdlSubDivision.SelectedItem.ToString();
                    }
                    else
                    {
                        CircleName = txtCircle.Text.Trim();
                        ZoneName = txtZone.Text.Trim();
                        DivisionName = txtDivision.Text.Trim();
                        SubdivisionName = txtSubDivision.Text.Trim();

                    }
                    if (ddlApplicantType.Visible == true)
                    {
                        ApplicantCode = ddlApplicantType.SelectedValue;
                        applicantType = ddlApplicantType.SelectedItem.ToString();
                    }
                    else
                    {
                        applicantType = txtApplicantType.Text.Trim();
                    }
                    Id = Session["SiteOwnerId_Industry"].ToString();
                    string TestReportGenerated = "";
                    TestReportGenerated = Session["TestReportGenerated"].ToString();
                    // if (TestReportGenerated != "" || TestReportGenerated!= null) {
                    // Insert data
                    CEI.IntimationDataInsertionBySiteowner_Industries(
                        Id,
                        applicantType,
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
                        PowerUtilityname,
                        PowerUtilitywing,
                        ZoneName,
                        CircleName,
                        DivisionName,
                        SubdivisionName,
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
                                    CEI.AddInstallationsCreatedbySiteOwner_Industries(projectId, installationType, installationNo, Id, TypeOfInspection, transaction);
                                }
                            }
                        }
                    }
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of Installation Submitted Successfully !!!')", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of Installation Submitted Successfully !!!'); window.location='RatingOfInstallations_Industry.aspx';", true);

                    //}
                    //else 
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Fill Previous Test Reports First !!!'); window.location='RatingOfInstallations_Industry.aspx';", true);

                    //}
                    transaction.Commit();
                    Reset();
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
        private void Reset()
        {
            txtAddress.Text = "";
            ddlDistrict.SelectedValue = "0";
            txtPin.Text = "";
            txtOtherPremises.Text = "";
            ddlVoltageLevel.SelectedValue = "0";
            RadioButtonList2.ClearSelection();
            txtSanctionLoad.Text = "";
            txtCapacity.Text = "";
            txtinstallationNo2.Text = "";
            txtinstallationNo3.Text = "";
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
                string valueToAddBack = txtinstallationType2.Text;

                if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
                {
                    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                    ddlWorkDetail.Items.Add(newItem);
                }
                installationType2.Visible = false;
                txtinstallationType2.Text = string.Empty;
                txtinstallationNo2.Text = string.Empty;
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
                string valueToAddBack = txtinstallationType3.Text;
                if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
                {
                    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                    ddlWorkDetail.Items.Add(newItem);
                }
                installationType3.Visible = false;
                txtinstallationType3.Text = string.Empty;
                txtinstallationNo3.Text = string.Empty;
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

        private bool CheckInspectionStatus()
        {
            string panNumber = null;

            if (Session["SiteOwnerId_Industry"] != null)
            {
                panNumber = Session["SiteOwnerId_Industry"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckAlreadyApplied_PeriodicInspection_Industries", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PANNumber", panNumber);

                    conn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result == 1;
                }
            }
        }
    }
    #endregion
}