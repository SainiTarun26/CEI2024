using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftPeriodic : System.Web.UI.Page
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
                        BindDistrict();
                        //GridBind();
                    }
                }
            }
            catch
            { }
        }


        private void BindDistrict()
        {
            try
            {
                string SiteOwnerId = Session["SiteOwnerId"].ToString();
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetDistrictForLiftRenewal(SiteOwnerId);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "ApplicantDistrict"; // Change to "ApplicantDistrict"
                ddlDistrict.DataValueField = "ApplicantDistrict";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            { }
        }
        private void GridBind()
        {
            string SiteOwnerId = Session["SiteOwnerId"].ToString();
            string District = Session["District"].ToString();
            DataTable ds = CEI.GetDataForLiftRenewal(District, SiteOwnerId);
            if (ds != null && ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert('No Record Found for document');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/LiftPeriodicRenewal.aspx", false);
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrict.SelectedItem.ToString();
            Session["District"] = ddlDistrict.SelectedItem.ToString();
            GridBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                Response.Redirect("/SiteOwnerPages/ViewLiftPeriodicReport.aspx", false);
            }
        }
    }
}