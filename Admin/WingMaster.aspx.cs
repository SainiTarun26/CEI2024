using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class WingMaster : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        ddlPoweUtilityBind();
                        //GridBind();
                        Wing.Visible = false;
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string WingName = txtWingName.Text.Trim();

            DataSet ds1 = CEI.checkWingName(WingName);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string script = $"alert('Wing Name  {WingName}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
                CEI.InsertInWingMaster(txtWingName.Text.Trim(), ddlUtility.SelectedValue);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Wing Name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }
        protected void Reset()
        {
            try
            {

                txtWingName.Text = "";
                ddlUtility.SelectedValue = "0";
            }
            catch (Exception ex)
            {
            }
        }

        private void GridBind()
        {
            try
            {
                string Id = ddlUtility.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWingMaster(Id);
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

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = ddlUtility.SelectedValue.ToString();
            if (ddlUtility.SelectedValue == "0")
            {
                Wing.Visible = false;
            }
            else
            {
                Wing.Visible = true;
                GridBind();
            }
        }
    }


}
