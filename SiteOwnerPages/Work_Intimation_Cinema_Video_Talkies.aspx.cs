using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Work_Intimation_Cinema_Video_Talkies : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string SiteOwnerId = string.Empty;
        int y = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {

                        BindDistrict();
                        GetDetails();
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
            catch
            {

            }
        }
        public void GetDetails()
        {
            SiteOwnerId = Session["SiteOwnerId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetDetailsByPanNumberIdLift(SiteOwnerId);
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string district = ds.Tables[0].Rows[0]["District"].ToString();
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(district));
                txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            }
            else
            {

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    SiteOwnerId = Session["SiteOwnerId"].ToString();
                    //will return single value only if wants to return more than You have to change executescalar to executenonquery
                    string IntimationI = CEI.InsetCinemaData(SiteOwnerId, ddlInspectionType.SelectedItem?.ToString(), ddlDistrict.SelectedItem?.ToString(), txtAddress.Text, txtPin.Text, txtinstallationType1.Text, txtinstallationNo1.Text);
                    if (IntimationI != null)
                    {
                        string installationType = txtinstallationType1.Text;
                        string installationNoText = txtinstallationNo1.Text;

                        if (int.TryParse(installationNoText, out int installationNo) && installationNo > 0)
                        {
                            for (int j = 0; j < installationNo; j++)
                            {
                                CEI.AddInstallations(IntimationI, installationType, installationNo, SiteOwnerId, "New", transaction);
                            }
                        }
                    }
                    transaction.Commit();

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved Successfully');", true);
                }
                catch
                {
                    transaction?.Rollback();
                }
            }
        }
        protected void Reset()
        {
            GetDetails();
            txtinstallationType1.Text = "";
            txtinstallationNo1.Text = "";
        }
    }
}