using CEI_PRoject;
using Org.BouncyCastle.Asn1.Cms;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Industry_Master
{
    public partial class ExistingInspectionData_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                    {
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
            string id = Session["id_Industry"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerExistingInstallations_Industries(id);
            if (ds.Tables.Count > 0)
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
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    string IntimationId = Session["id_Industry"].ToString();
                    string Count = lblNoOfInstallations.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData_Industries(lblCategory.Text.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Text.Trim() == "Line")
                        {

                            Session["LineID_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                            Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Substation Transformer")
                        {
                            Session["SubStationID_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Generating Set")
                        {
                            Session["GeneratingSetId_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string siteOwnerId = Session["SiteOwnerId_Industry"].ToString();
            string id = Session["id_Industry"].ToString();

            foreach (GridViewRow row in GridView1.Rows)
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
                CEI.InsertExistingInspectionData_Industries(TestReportId, id, NoofInstallation, Applicant, Category, VoltageLevel,
                       District, Division, Permises, siteOwnerId, formattedInspectionDate, ddlInspectionType.SelectedValue, InspectionType, rblInspection.SelectedValue);




            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
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
    }
}