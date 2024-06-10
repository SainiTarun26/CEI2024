using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
                    {
                        BindAdress();
                        BindInstallationType();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
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
                ddlAdress.DataTextField = "Address";
                ddlAdress.DataValueField = "Id";
                ddlAdress.DataBind();
                ddlAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch
            {

            }
        }
       

        private void BindInstallationType()
        {
            try
            {
                DataSet dsInstallation = new DataSet();
                dsInstallation = CEI.GetInstallationType();
                ddlInstallationType.DataSource = dsInstallation;
                ddlInstallationType.DataTextField = "InstallationType";
                ddlInstallationType.DataValueField = "ID";
                ddlInstallationType.DataBind();
                ddlInstallationType.Items.Insert(0, new ListItem("Select", "0"));
                dsInstallation.Clear();
            }
            catch
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }

        public void GridViewBind()
        {
            string id = Session["SiteOwnerId"].ToString();
            string Adress= ddlAdress.SelectedItem.Text;
            Session["IntimationId"] = ddlAdress.SelectedValue;
            DataSet ds = new DataSet();
            ds = CEI.GetPeriodicDetails(Adress , id);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                
            }
        }
               
        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            bool AtLeastOneCheked = false;
            //Response.Redirect("InspectionRenewal.aspx", false);
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null && chk.Checked)
                {
                    AtLeastOneCheked = true;
                    Response.Redirect("InspectionRenewal.aspx", true);
                }
            }
            if (!AtLeastOneCheked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Declaration'); ", true);
            }

        }
    }
}