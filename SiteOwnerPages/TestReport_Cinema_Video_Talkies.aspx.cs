using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class TestReport_Cinema_Video_Talkies : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        if (Convert.ToString(Session["id"]) != null && Convert.ToString(Session["id"]) != "")
                        {
                            HFrowID.Value = Convert.ToString(Session["id"]);
                            DataTable dt = CEI.GetCinemaIntimationComponentdetails(HFrowID.Value);

                            if (dt.Rows.Count > 0)
                            {
                                txtWorkintimation.Text = dt.Rows[0]["IntimationId"].ToString();
                                txtInstallation.Text = dt.Rows[0]["InstallationType"].ToString();
                                txtNameOfCinema.Text = dt.Rows[0]["InstallationType"].ToString();
                                txtNOOfInstallation.Text = dt.Rows[0]["InstallationNo"].ToString();
                                HiddenField1.Value = dt.Rows[0]["Count"].ToString();
                            }
                        }
                        else
                        {
                            Response.Redirect("CinemaInstallationComponentDetails.aspx", false);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
            }
            catch
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("LogOut.aspx", false);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                 CEI.InsertDataOfCinema_New(txtWorkintimation.Text, HiddenField1.Value, txtNameOfCinema.Text,
                txtSerialNo.Text, txtScreenSize.Text, CreatedBy);
                CEI.UpdateInstallations(HFrowID.Value, txtWorkintimation.Text);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithReturnRedirectdata();", true);
            }
            catch (Exception ex)
            {
                DataSaved.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void Reset()
        {
            txtNameOfCinema.Text = "";
            txtSerialNo.Text = "";
            txtScreenSize.Text = "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect("CinemaInstallationComponentDetails.aspx", false);
        }

    }
}