using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class RenewalPerodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        Session["SiteOwnerId"] = "JVCBN5647K";
                        getWorkIntimationData();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void getWorkIntimationData()
        {
            string Id = Session["SiteOwnerId"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.ExistingInspectionData(Id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //Periodic.Visible = true;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                PeriodicData.Visible = true;
            }
            else
            {
                Periodic.Visible = true;
                BindAdress();
                GridView1.DataSource = null;
                GridView1.DataBind();
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            ds.Dispose();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName == "Select")
                {

                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["id"] = lblID.Text;
                    Renewal.Visible = true;
                    BindGridview2();
                    PeriodicData.Visible = false;
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }
        private void BindGridview2()
        {
            string id = Session["id"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerExistingInstallations(id);
            if (ds.Tables.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();

            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");

                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    Session["TestReportId"] = lblTestReportId;
                    string IntimationId = Session["id"].ToString();
                    string Count = lblNoOfInstallations.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData(lblCategory.Text.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Text.Trim() == "Line")
                        {

                            Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                            Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Substation Transformer")
                        {
                            Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Generating Set")
                        {
                            Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            PeriodicData.Visible = true;
            Renewal.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string siteOwnerId = Session["SiteOwnerId"].ToString();
            string id = Session["id"].ToString();
            //string TestReportId = Session["TestReportId"].ToString();
            //string Category = Session["Category"].ToString();
            //string VoltageLevel = Session["Voltage"].ToString();
            //string Applicant = Session["Applicant"].ToString();
            //string Division = Session["Division"].ToString();
            //string District = Session["District"].ToString();
            //string NoofInstallation = Session["NoOfInstallation"].ToString();
            //string Permises = Session["Permises"].ToString();
            //string InspectionType = Session["InspectionType"].ToString();
            foreach (GridViewRow row in GridView2.Rows)
            {

                RadioButtonList rblInspection = (RadioButtonList)row.FindControl("RadioButtonListInspection");
                DropDownList ddlInspectionType = (DropDownList)row.FindControl("ddlInspectionType");

                TextBox txtInspectionDate = row.FindControl("txtInspectionDate") as TextBox;


                Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                string TestReportId = lblTestReportId.Text;
                Label lblCategory = (Label)row.FindControl("lblCategory");
                string Category = lblCategory.Text;
                Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                string VoltageLevel = lblVoltageLevel.Text;
                Label lblApplicant = (Label)row.FindControl("lblApplicant");
                string Applicant = lblApplicant.Text;
                Label lblDivision = (Label)row.FindControl("lblDivision");
                string Division = lblDivision.Text;
                Label lblDistrict = (Label)row.FindControl("lblDistrict");
                string District = lblDistrict.Text;
                Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                String NoofInstallation = lblNoOfInstallations.Text;
                Label lblPermises = (Label)row.FindControl("lblPermises");
                string Permises = lblPermises.Text;
                Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                string InspectionType = lblInspectionType.Text;
                string formattedInspectionDate = null;
                DateTime inspectionDate;
                if (DateTime.TryParse(txtInspectionDate.Text, out inspectionDate))
                {
                    formattedInspectionDate = inspectionDate.ToString("yyyy-MM-dd");
                }
                CEI.InsertExistingInspectionData(TestReportId, id, NoofInstallation, Applicant, Category, VoltageLevel,
                       District, Division, Permises, siteOwnerId, formattedInspectionDate, ddlInspectionType.SelectedValue, InspectionType, rblInspection.SelectedValue);

                PeriodicData.Visible = true;
                Renewal.Visible = false;
                Periodic.Visible = true;
                BindAdress();


            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Inspection Created Successfully.');", true);
        }

        protected void RadioButtonListInspection_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            GridViewRow row = (GridViewRow)rbl.NamingContainer;

            TextBox txtInspectionDate = (TextBox)row.FindControl("txtInspectionDate");
            DropDownList ddlInspectionType = (DropDownList)row.FindControl("ddlInspectionType");

            if (rbl.SelectedValue == "No")
            {
                ddlInspectionType.Visible = true;
                txtInspectionDate.Visible = false;

            }
            else
            {
                ddlInspectionType.Visible = false;
                txtInspectionDate.Visible = true;
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
                ddlAdress.DataValueField = "siteownerAdress";
                ddlAdress.DataBind();
                ddlAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grid.Visible = true;
            GridBind();
        }
        public void GridBind()
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
                GridView3.DataSource = ds;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();

            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    Label LblIntimationId = e.Row.FindControl("LblIntimationId") as Label;
                    Label LblInstallationType = e.Row.FindControl("LblInstallationType") as Label;

                    Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    Label lblVoltage = (Label)e.Row.FindControl("LblVoltage");
                    Label LblInspectionDate = (Label)e.Row.FindControl("LblInspectionDate");
                    DateTime inspectionDate = DateTime.Parse(LblInspectionDate.Text);
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
                                    e.Row.Visible = false;
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
                                    e.Row.Visible = false;
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
                                    e.Row.Visible = false;
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
                                e.Row.Visible = false;
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
                                e.Row.Visible = false;
                            }

                        }

                        int dueDateColumnIndex = 8;
                        e.Row.Cells[dueDateColumnIndex].Text = Year.ToShortDateString();
                        SetRemainingDaysColumn(e.Row, remainingDays);
                    }


                    int numberofdaysColumnIndex = 9;
                    TableCell numberofdaysCell = e.Row.Cells[numberofdaysColumnIndex];

                    int numberofdays;
                    if (int.TryParse(numberofdaysCell.Text, out numberofdays))
                    {
                        if (numberofdays == 0 || (numberofdays > 0 && numberofdays <= 15))
                        {
                            e.Row.Cells[9].CssClass = "GreenBackground";
                        }
                        else if (numberofdays < 0)
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
        private void SetRemainingDaysColumn(GridViewRow row, int remainingDays)
        {

            row.Cells[9].Text = remainingDays.ToString();
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SiteOwnerId"] != null)
                {
                    string id = Session["SiteOwnerId"].ToString();
                    bool atLeastOneChecked = false;

                    foreach (GridViewRow row in GridView3.Rows)
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
                                 inspectionDueDate, DelayedDays, Voltage, Capacity, Address, CompleteAddress, AddressDistrict, OwnerName, District, Division, id, "1");

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

        protected void ddlNoOfDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numberOfDays = int.Parse(ddlNoOfDays.SelectedValue);
        }

        protected void ddlInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = ddlInstallationType.SelectedValue;

        }

        //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        Label lblTestReportId = e.Row.FindControl("lblTestReportId") as Label;
        //        Session["TestReportId"] = lblTestReportId;
        //        Label lblCategory = e.Row.FindControl("lblCategory") as Label;
        //        Session["Category"] = lblCategory;
        //        Label lblVoltageLevel = e.Row.FindControl("lblVoltageLevel") as Label;
        //        Session["Voltage"] = lblVoltageLevel;
        //        Label lblApplicant = e.Row.FindControl("lblApplicant") as Label;
        //        Session["Applicant"] = lblApplicant;
        //        Label lblDivision = e.Row.FindControl("lblDivision") as Label;
        //        Session["Division"] = lblDivision;
        //        Label lblDistrict = e.Row.FindControl("lblDistrict") as Label;
        //        Session["District"] = lblDistrict;
        //        Label lblNoOfInstallations = e.Row.FindControl("lblNoOfInstallations") as Label;
        //        Session["NoOfInstallation"] = lblNoOfInstallations;
        //        Label lblPermises = e.Row.FindControl("lblPermises") as Label;
        //        Session["Permises"] = lblPermises;
        //        Label lblInspectionType = e.Row.FindControl("lblInspectionType") as Label;
        //        Session["InspectionType"] = lblInspectionType;
        //    }
        //}
    }
}