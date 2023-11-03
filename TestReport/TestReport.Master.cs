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
                if (Convert.ToString(Session["installationType1"]).Trim() == "Line" || Convert.ToString(Session["installationType2"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType3"]).Trim() == "Line" || Convert.ToString(Session["installationType4"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType5"]).Trim() == "Line" || Convert.ToString(Session["installationType6"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType7"]).Trim() == "Line" || Convert.ToString(Session["installationType8"]).Trim() == "Line")
                {
                    //if (Convert.ToString(SessionConvert.ToString(Session["SubmittedValue2"]) != null && Convert.ToString(SessionConvert.ToString(Session["SubmittedValue2"]) != "")
                    //{
                    //    lblLinePage.Visible = false;
                    //}
                    //else
                    //{
                    lblLinePage.Visible = true;
                    // }
                }
                if (Convert.ToString(Session["Approval"]).Trim() == "Reject")
                {
                    lblLinePage.Visible = true;
                }
                else
                {
                    lblLinePage.Visible = false;
                }
                if (Convert.ToString(Session["Approval2"]).Trim() == "Reject")
                {
                    lblSubStationPage.Visible = true;
                }
                else
                {
                }
                if (Convert.ToString(Session["installationType1"]).Trim() == "Substation Transformer" || Convert.ToString(Session["installationType2"]).Trim() == "Substation Transformer"
                   || Convert.ToString(Session["installationType3"]).Trim() == "Substation Transformer" || Convert.ToString(Session["installationType4"]).Trim() == "Substation Transformer"
                   || Convert.ToString(Session["installationType5"]).Trim() == "Substation Transformer" || Convert.ToString(Session["installationType6"]).Trim() == "Substation Transformer"
                   || Convert.ToString(Session["installationType7"]).Trim() == "Substation Transformer" || Convert.ToString(Session["installationType8"]).Trim() == "Substation Transformer")
                {
                    //if (Convert.ToString(SessionConvert.ToString(Session["SubmittedValue"]) != null && Convert.ToString(SessionConvert.ToString(Session["SubmittedValue"]) != "")
                    //{
                    //    lblSubStationPage.Visible = false;
                    //}
                    //else
                    //{
                    lblSubStationPage.Visible = true;
                    // }
                }
                if (Convert.ToString(Session["installationType1"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType2"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType3"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType4"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType5"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType6"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType7"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType8"]).Trim() == "Generating Station")
                {
                    //if (Convert.ToString(SessionConvert.ToString(Session["SubmittedValue3"]) != null && Convert.ToString(SessionConvert.ToString(Session["SubmittedValue3"]) != "")
                    //{
                    //    lblGeneratingSet.Visible = false;
                    //}
                    //else
                    //{
                    lblGeneratingSet.Visible = true;
                    //}


                }
                if (Convert.ToString(Session["installationType1"]).Trim() == "Single/ Three Phase" || Convert.ToString(Session["installationType2"]).Trim() == "Single/ Three Phase"
                   || Convert.ToString(Session["installationType3"]).Trim() == "Single/ Three Phase" || Convert.ToString(Session["installationType4"]).Trim() == "Single/ Three Phase"
                   || Convert.ToString(Session["installationType5"]).Trim() == "Single/ Three Phase" || Convert.ToString(Session["installationType6"]).Trim() == "Single/ Three Phase"
                   || Convert.ToString(Session["installationType7"]).Trim() == "Single/ Three Phase" || Convert.ToString(Session["installationType8"]).Trim() == "Single/ Three Phase")
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
                //abc
            }

        }

        protected void ddlSearchingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlSearchingNo.SelectedValue;
            Session["ValueId"] = id;
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
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }
    }
}