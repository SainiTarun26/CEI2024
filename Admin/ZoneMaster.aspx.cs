using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace CEIHaryana.Admin
{
   
    public partial class ZoneMaster : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlPoweUtilityBind();
                    Zone.Visible = false;


                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }

        }
        private void ddlPoweUtilityBind()
        {
            try
            {
                DataSet dsUtility = new DataSet();
                dsUtility = CEI.GetUtilityName();
                ddlUtility.DataSource = dsUtility;
                ddlUtility.DataTextField = "UtilityName";
                ddlUtility.DataValueField = "Id";
                ddlUtility.DataBind();
                ddlUtility.Items.Insert(0, new ListItem("Select", "0"));
                dsUtility.Clear();
            }
            catch
            {
            }
        }
        private void DdlWingBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                DataSet dsWing = new DataSet();
                dsWing = CEI.GetWingName(UtilityId);
                ddlWingName.DataSource = dsWing;
                ddlWingName.DataTextField = "WingName";
                ddlWingName.DataValueField = "Id";
                ddlWingName.DataBind();
                ddlWingName.Items.Insert(0, new ListItem("Select", "0"));
                dsWing.Clear();
            }
            catch
            {
            }

        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string ZoneName = txtZoneName.Text.Trim();

            DataSet ds1 = CEI.checkZoneName(ZoneName);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string script = $"alert('Zone Name  {ZoneName}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
                CEI.InsertInZoneMaster(txtZoneName.Text.Trim(),ddlUtility.SelectedValue,ddlWingName.SelectedValue);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Zone Name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }
        protected void Reset()
        {
            try
            {
                ddlUtility.SelectedValue = "0";

                txtZoneName.Text = "";

                ddlWingName.SelectedValue = "0";
              


            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlUtility.SelectedValue == "0")
            {
                ddlWingName.SelectedValue = "0";
                Zone.Visible = false;
            }
            else
            {
                DdlWingBind();
            }
            
        }
        private void GridBind()
        {
            try
            {
                string Id = ddlWingName.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetZoneMaster(Id);
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
            catch (Exception ex)
            {
                //throw;
            }
        }

        protected void ddlWingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = ddlWingName.SelectedValue.ToString();
            //GridBind();
            if (ddlWingName.SelectedValue == "0" || ddlUtility.SelectedValue == "0")
            {
                Zone.Visible = false;
            }
            else
            {
                Zone.Visible = true;
                GridBind();
            }
        }
    }
}
