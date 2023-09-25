using CEI_PRoject;
using CEIHaryana.TestReport;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindListBoxInstallationType();
                GetDetails();
            }

        }

        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataForAdmin(REID);

                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "Firm/Organization/Company/Department")
                {
                    agency.Visible = true;
                    individual.Visible = false;
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }

                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                TxtPremises.Text = dp_Id1;
                string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                //txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                txtVoltagelevel.Text = dp_Id3;
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                // txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                // txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                //txtSiteContact.Text = ds.Tables[0].Rows[0]["SiteContact"].ToString();
                //string dp_Id8 = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                //txtWorkDetail.Text = dp_Id8;

            }
            catch { }
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
            string Value = ddlWorkDetail.SelectedItem.ToString();
            if (ddlWorkDetail.SelectedValue != "0")
            {
                Installation.Visible = true;
                installationType1.Visible = true;
                if (string.IsNullOrEmpty(txtinstallationType1.Text))
                {
                    txtinstallationType1.Text = Value;
                }

                else if (txtinstallationType1.Text != string.Empty && string.IsNullOrEmpty(txtinstallationType2.Text))
                {
                    installationType2.Visible = true;
                    txtinstallationType2.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType3.Text))
                {
                    installationType3.Visible = true;
                    txtinstallationType3.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType4.Text))
                {
                    installationType4.Visible = true;
                    txtinstallationType4.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType5.Text))
                {
                    installationType5.Visible = true;
                    txtinstallationType5.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType6.Text))
                {

                    installationType6.Visible = true;
                    txtinstallationType6.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType7.Text))
                {
                    installationType7.Visible = true;
                    txtinstallationType7.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType8.Text))
                {
                    installationType8.Visible = true;
                    txtinstallationType8.Text = Value;
                }
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
                    { }
                    ddlWorkDetail.SelectedValue = "0";

                }
            }
        }
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            installationType1.Visible = false;
            txtinstallationType1.Text = string.Empty;
            txtinstallationNo1.Text = string.Empty;
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            installationType2.Visible = false;
            txtinstallationType2.Text = string.Empty;
            txtinstallationNo2.Text = string.Empty;
        }

        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            installationType3.Visible = false;
            txtinstallationType3.Text = string.Empty;
            txtinstallationNo3.Text = string.Empty;
        }

        protected void btnDelete4_Click(object sender, EventArgs e)
        {
            installationType4.Visible = false;
            txtinstallationType4.Text = string.Empty;
            txtinstallationNo4.Text = string.Empty;
        }

        protected void btnDelete5_Click(object sender, EventArgs e)
        {
            installationType5.Visible = false;
            txtinstallationType5.Text = string.Empty;
            txtinstallationNo5.Text = string.Empty;
        }

        protected void btnDelete6_Click(object sender, EventArgs e)
        {
            installationType4.Visible = false;
            txtinstallationType4.Text = string.Empty;
            txtinstallationNo4.Text = string.Empty;
        }

        protected void btnDelete7_Click(object sender, EventArgs e)
        {
            installationType7.Visible = false;
            txtinstallationType7.Text = string.Empty;
            txtinstallationNo7.Text = string.Empty;
        }

        protected void btnDelete8_Click(object sender, EventArgs e)
        {
            installationType8.Visible = false;
            txtinstallationType8.Text = string.Empty;
            txtinstallationNo8.Text = string.Empty;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                CEI.InsertTestReportData(txtInstallation.Text, txtName.Text, txtagency.Text, txtAddress.Text, TxtPremises.Text,
                    txtVoltagelevel.Text, txtPhone.Text, txtStartDate.Text, txtCompletitionDate.Text, txtinstallationType1.Text,
                    txtinstallationNo1.Text, txtinstallationType2.Text, txtinstallationNo2.Text, txtinstallationType3.Text,
                    txtinstallationNo3.Text, txtinstallationType4.Text, txtinstallationNo4.Text, txtinstallationType5.Text,
                    txtinstallationNo5.Text, txtinstallationType6.Text, txtinstallationNo6.Text, txtinstallationType7.Text,
                    txtinstallationNo7.Text, txtinstallationType8.Text, txtinstallationNo8.Text);

                string TestReportId = CEI.TestReportId();
                Session["TestReportId"] = CEI.TestReportId();
                Session["installationType1"] = txtinstallationType1.Text;
                Session["installationNo1"] = txtinstallationNo1.Text;

                Session["installationType2"] = txtinstallationType2.Text;
                Session["installationNo2"] = txtinstallationNo2.Text;

                Session["installationType3"] = txtinstallationType3.Text;
                Session["installationNo3"] = txtinstallationNo3.Text;

                Session["installationType4"] = txtinstallationType4.Text;
                Session["installationNo4"] = txtinstallationNo4.Text;

                Session["installationType5"] = txtinstallationType5.Text;
                Session["installationNo5"] = txtinstallationNo5.Text;

                Session["installationType6"] = txtinstallationType6.Text;
                Session["installationNo6"] = txtinstallationNo6.Text;

                Session["installationType7"] = txtinstallationType7.Text;
                Session["installationNo7"] = txtinstallationNo7.Text;

                Session["installationType8"] = txtinstallationType8.Text;
                Session["installationNo8"] = txtinstallationNo8.Text;
                Response.Redirect("LineTestReport.aspx");
            }
            catch
            {

            }
        }
    }
}