using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReport
{
    public partial class TestReport : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        string Type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["Value"]) == null)
                {
                    ddlSearchingName.Visible = false;
                }
            }

            RedirectPages();
            if (Session["Page"] != null && (int)Session["Page"] == 0)
            {

            }
            else
            {
                Searching.Visible = true;

            }


        }
        public void RedirectPages()
        {
            try
            {
                if (Session["installationType1"].ToString().Trim() == "Line" || Session["installationType2"].ToString().Trim() == "Line"
                    || Session["installationType3"].ToString().Trim() == "Line" || Session["installationType4"].ToString().Trim() == "Line"
                    || Session["installationType5"].ToString().Trim() == "Line" || Session["installationType6"].ToString().Trim() == "Line"
                    || Session["installationType7"].ToString().Trim() == "Line" || Session["installationType8"].ToString().Trim() == "Line")
                {
                    //if (Convert.ToString(Session["SubmittedValue2"]) != null && Convert.ToString(Session["SubmittedValue2"]) != "")
                    //{
                    //    lblLinePage.Visible = false;
                    //}
                    //else
                    //{
                    lblLinePage.Visible = true;
                    // }
                }
                if (Session["installationType1"].ToString().Trim() == "Substation Transformer" || Session["installationType2"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType3"].ToString().Trim() == "Substation Transformer" || Session["installationType4"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType5"].ToString().Trim() == "Substation Transformer" || Session["installationType6"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType7"].ToString().Trim() == "Substation Transformer" || Session["installationType8"].ToString().Trim() == "Substation Transformer")
                {
                    //if (Convert.ToString(Session["SubmittedValue"]) != null && Convert.ToString(Session["SubmittedValue"]) != "")
                    //{
                    //    lblSubStationPage.Visible = false;
                    //}
                    //else
                    //{
                    lblSubStationPage.Visible = true;
                    // }
                }
                if (Session["installationType1"].ToString().Trim() == "Generating Station" || Session["installationType2"].ToString().Trim() == "Generating Station"
                   || Session["installationType3"].ToString().Trim() == "Generating Station" || Session["installationType4"].ToString().Trim() == "Generating Station"
                   || Session["installationType5"].ToString().Trim() == "Generating Station" || Session["installationType6"].ToString().Trim() == "Generating Station"
                   || Session["installationType7"].ToString().Trim() == "Generating Station" || Session["installationType8"].ToString().Trim() == "Generating Station")
                {
                    //if (Convert.ToString(Session["SubmittedValue3"]) != null && Convert.ToString(Session["SubmittedValue3"]) != "")
                    //{
                    //    lblGeneratingSet.Visible = false;
                    //}
                    //else
                    //{
                    lblGeneratingSet.Visible = true;
                    //}



                }
                if (Session["installationType1"].ToString().Trim() == "Single/ Three Phase" || Session["installationType2"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType3"].ToString().Trim() == "Single/ Three Phase" || Session["installationType4"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType5"].ToString().Trim() == "Single/ Three Phase" || Session["installationType6"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType7"].ToString().Trim() == "Single/ Three Phase" || Session["installationType8"].ToString().Trim() == "Single/ Three Phase")
                {
                    lblPhses.Visible = true;

                }


            }
            catch
            {

            }
        }

        protected void ddlSearchingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TestReportId = Session["TestReportId"].ToString();
            CEI.GetTestReportHistoryForUpdate(Type, TestReportId);
            ddlSearchingNo.Visible = true;

            Session["Value"] = ddlSearchingName.SelectedItem.ToString();
            if (Convert.ToString(Session["Value"]) == null || Convert.ToString(Session["Value"]) == "")
            {
                Type = ddlSearchingName.SelectedItem.ToString();
            }
            else
            {
                Type = Session["Value"].ToString();
            }
            try
            {
                DataSet dsSearchingNo = new DataSet();
                dsSearchingNo = CEI.GetTestReportHistoryForUpdate(Type, TestReportId);
                ddlSearchingNo.DataSource = dsSearchingNo;
                ddlSearchingNo.DataTextField = "HistoryID";
                ddlSearchingNo.DataValueField = "ID";
                ddlSearchingNo.DataBind();
                ddlSearchingNo.Items.Insert(0, new ListItem("Select", "0"));
                dsSearchingNo.Clear();
            }
            catch (Exception ex)
            {
                
            }

        }

        protected void ddlSearchingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlSearchingNo.SelectedValue;
            Session["Id"] = id;
            ddlSearchingNo.Visible = true;
            Type = Session["Value"].ToString();
      

            if (Type.Trim() == "Line")
            {
                Response.Redirect("/TestReport/LineTestReport.aspx");
            }
            else if (Type.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReport/SubstationTransformer.aspx");
            }
            else if (Type.Trim() == "Generating Station")
            {
                Response.Redirect("/TestReport/GeneratingSetTestReport.aspx");
            }


        }
    }
}