using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CEI_PRoject;
using CEIHaryana.UserPages;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ViewLiftPeriodicReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string siteOwnerId = Convert.ToString(Session["SiteOwnerId"]);
                    string registrationNo = Convert.ToString(Session["RegistrationNo"]);

                    if (!string.IsNullOrEmpty(siteOwnerId) && !string.IsNullOrEmpty(registrationNo))
                    {
                        GetData();
                    }
                }
            }
            catch
            { }
        }

        private void GetData()
        {
            try
            {
                if (Convert.ToString(Session["RegistrationNo"]) != null && Convert.ToString(Session["RegistrationNo"]) != "")
                {
                    string RegistrationNo = Session["RegistrationNo"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.GetDetailsOfLiftRenewalReport(RegistrationNo);
                    txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();

                    if (txtInstallationType.Text == "Lift")
                    {
                        divLiftDetails.Visible = true;
                        lblTypeOfLift.InnerText = "Type of Lift";
                    }
                    else if (txtInstallationType.Text == "Escalator")
                    {
                        divLiftDetails.Visible = false;
                        lblTypeOfLift.InnerText = "Type of Escalator";
                    }
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();

                    object previousChallanDateObj = ds.Tables[0].Rows[0]["PreviousChallanDate"];
                    if (previousChallanDateObj != DBNull.Value)
                    {
                        DateTime previousChallanDate = Convert.ToDateTime(previousChallanDateObj);
                        txtPrevChallanDate.Text = previousChallanDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtPrevChallanDate.Text = string.Empty;
                    }
                    //txtPrevChallanDate.Text = ds.Tables[0].Rows[0]["PreviousChallanDate"].ToString();
                    txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                    txtLiftType.Text = ds.Tables[0].Rows[0]["TypeOfLift"].ToString();
                    txtControlType.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                    txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["ApplicantDistrict"].ToString();
                    txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    Session["File"] = ds.Tables[0].Rows[0]["PreviousChallanUpload"].ToString();
                    GridDocument();
                }
            }

            catch { }
        }

        private void GridDocument()
        {
            string RegistrationNo = Session["RegistrationNo"].ToString();

            DataTable ds = CEI.GetDocumentOfLiftRenewalToShow(RegistrationNo);
            if (ds != null && ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert('No Record Found for document');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/LiftPeriodic.aspx", false);
        }

        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                string fileName = "";
                try
                {
                    if (e.CommandName == "Select")
                    {
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["File"] != null && Session["File"].ToString() != "")
                {
                    string fileName = Session["File"].ToString();

                    string filePath = fileName.Replace("~", "");
                    filePath = "https://uat.ceiharyana.com" + filePath;

                    string script = $@"<script>window.open('{filePath}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}