using CEI_PRoject;
using CEIHaryana.Supervisor;
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
            try
            {
                if (!IsPostBack)
                {
                    //Contractor.Visible = false;
                    if (Convert.ToString(Session["Value"]) == null)
                    {
                        ddlSearchingName.Visible = false;
                        Contractor.Visible = false;
                    }
                    if (Request.Cookies["SupervisorID"] != null)
                    {

                        lblName.Text = Request.Cookies["SupervisorID"].Value;
                        lblName2.Text = Request.Cookies["SupervisorID"].Value;
                        DivStatus.Visible = false;
                        btnSubmit.Visible = false;
                        Contractor.Visible = false;
                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["SupervisorID"]);
                        lblName2.Text = Convert.ToString(Session["SupervisorID"]);
                    }

                    RedirectPages();
                    if (Session["Visible"] != null && (int)Session["Visible"] == 0)
                    {

                    }
                    else
                    {
                        Searching.Visible = true;

                    }
                    if (Convert.ToString(Session["ValueId"]) == null || Convert.ToString(Session["ValueId"]) == "")
                    {

                    }
                    else
                    {
                        SearchingNo.Visible = true;
                    }
                    if (Convert.ToString(Session["ContractorID"]) == null || Convert.ToString(Session["ContractorID"]) == "")
                    {
                        Contractor.Visible = false;
                    }
                    else
                    {
                        if (Convert.ToString(Session["Approval"]) == "Reject" || Convert.ToString(Session["Approval"]) == "Accept")
                        {
                            Contractor.Visible = true;
                            DivStatus.Visible = true;
                            BtnBack1.Visible = true;
                            btnVerify.Visible = false;

                            string response = Session["Approval"].ToString();
                            ddlforResponse.SelectedIndex = ddlforResponse.Items.IndexOf(ddlforResponse.Items.FindByText(response));
                            if (ddlforResponse.SelectedItem.Text == "Reject")
                            {
                                if (Convert.ToString(Session["ReasionForRejection"]) != null)
                                {
                                    Rejection.Visible = true;
                                    txtRejection.Text = Session["ReasionForRejection"].ToString();
                                    txtRejection.Enabled = false;
                                }
                            }


                            ddlforResponse.Attributes.Add("disabled", "disabled");
                            lbltext.Visible = false;
                        }
                        else
                        {
                            Contractor.Visible = true;
                            DivStatus.Visible = true;
                            btnSubmit.Visible = false;
                        }

                    }
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }


        }
        public void RedirectPages()
        {
            try
            {
                if (Session["Value"] != null)
                {
                    Type = Session["Value"].ToString();
                }
                if (Convert.ToString(Session["installationType1"]).Trim() == "Line" || Convert.ToString(Session["installationType2"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType3"]).Trim() == "Line" || Convert.ToString(Session["installationType4"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType5"]).Trim() == "Line" || Convert.ToString(Session["installationType6"]).Trim() == "Line"
                    || Convert.ToString(Session["installationType7"]).Trim() == "Line" || Convert.ToString(Session["installationType8"]).Trim() == "Line")
                {
                    if (Session["SubmittedValue2"] == null || Type.Trim() == "Line")
                    {
                        lblLinePage.Visible = true;
                    }
                    else
                    {
                        lblLinePage.Visible = false;
                    }
                }

                if (Type.Trim() == "Substation Transformer")
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
                    if (Session["SubmittedValue"] == null || Type.Trim() == "Substation Transformer")
                    {
                        lblSubStationPage.Visible = true;
                    }
                    else
                    {
                        lblSubStationPage.Visible = false;
                    }
                }
                if (Convert.ToString(Session["installationType1"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType2"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType3"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType4"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType5"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType6"]).Trim() == "Generating Station"
                   || Convert.ToString(Session["installationType7"]).Trim() == "Generating Station" || Convert.ToString(Session["installationType8"]).Trim() == "Generating Station")
                {
                    if (Session["SubmittedValue3"] == null || Type.Trim() == "Generating Station")
                    {
                        lblGeneratingSet.Visible = true;
                    }
                    else
                    {
                        lblGeneratingSet.Visible = false;
                    }


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
            try
            {
                string TestReportId = Session["TestReportId"].ToString();
                CEI.GetTestReportHistoryForUpdate(Type, TestReportId);
                SearchingNo.Visible = true;
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
                    if (dsSearchingNo.Tables.Count > 0 && dsSearchingNo.Tables[0].Rows.Count > 0)
                    {
                        // Data is available, bind it to the DropDownList
                        ddlSearchingNo.DataSource = dsSearchingNo;
                        ddlSearchingNo.DataTextField = "HistoryID";
                        ddlSearchingNo.DataValueField = "ID";
                        ddlSearchingNo.DataBind();
                        ddlSearchingNo.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else
                    {
                        // No data found, display a message
                        ddlSearchingNo.Items.Clear();
                        ddlSearchingNo.Items.Insert(0, new ListItem("No record found", "0"));
                    }

                    dsSearchingNo.Clear();
                }
                catch (Exception ex)
                {
                    //abc
                }
            }
            catch { }

        }

        protected void ddlSearchingNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = ddlSearchingNo.SelectedValue;
            Session["ValueId"] = id;
            Type = Session["Value"].ToString();

            //if(Convert.ToString(Session["Approval"])=="Accept")
            //{
            //    Contractor.Visible = true;
            //    DivStatus.Visible = true;
            //    ddlforResponse.Visible = true;

            //    string Response = Session["Approval"].ToString();
            //    ddlforResponse.SelectedIndex = ddlforResponse.Items.IndexOf(ddlforResponse.Items.FindByText(Response));
            //}


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
            Response.Redirect("/SiteOwnerLogout.aspx");
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlforResponse.SelectedValue == "2")
            {
                Rejection.Visible = true;
            }
            else
            {

                Rejection.Visible = false;
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string id = Session["TestReportId"].ToString();
            CEI.UpdateTestReportData(id, ddlforResponse.SelectedItem.ToString(), txtRejection.Text);
            Response.Redirect("/Contractor/TestReportForContractor.aspx");
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnVerify.Text == "SendOTP")
                {
                    OTP.Visible = true;
                    string mobilenumber = Session["Contact"].ToString();
                    Session["OTP"] = CEI.ValidateOTP(mobilenumber);
                    btnVerify.Text = "Verify";
                }
                else
                {
                    if (Session["OTP"].ToString() == txtOtp.Text)
                    {
                        btnSubmit.Visible = true;
                        Verify.Visible = false; // Assuming Verify is the correct ID
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error Occured Please try again later')", true);

            }
        }

        protected void BtnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Contractor/TestReportForContractor.aspx");
        }
    }
}