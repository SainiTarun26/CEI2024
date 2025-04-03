using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace CEIHaryana.Admin
{
    public partial class CircleMaster : System.Web.UI.Page
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
                        Circle.Visible = false;
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
        private void DdlZoneBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWingName.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                dsZone = CEI.GetZoneName(UtilityId, WingId);
                ddlZoneName.DataSource = dsZone;
                ddlZoneName.DataTextField = "ZoneName";
                ddlZoneName.DataValueField = "Id";
                ddlZoneName.DataBind();
                ddlZoneName.Items.Insert(0, new ListItem("Select", "0"));
                dsZone.Clear();
            }
            catch
            {
            }

        }

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUtility.SelectedValue == "0")
            {
                ddlWingName.SelectedValue = "0";
                ddlZoneName.SelectedValue = "0";
                Circle.Visible = false;

            }
            else {
                DdlWingBind();
            }
            
        }

        protected void ddlWingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlWingName.SelectedValue =="0")
            {
                ddlZoneName.SelectedValue = "0";
                Circle.Visible = false;
            }
            else
            {
                DdlZoneBind();
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string CircleName = txtCircleName.Text.Trim();

            DataSet ds1 = CEI.checkCircleName(CircleName);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string script = $"alert('Circle Name  {CircleName}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
                CEI.InsertInCircleMaster(txtCircleName.Text.Trim(), ddlUtility.SelectedValue, ddlWingName.SelectedValue , ddlZoneName.SelectedValue);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Circle Name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }
        protected void Reset()
        {
            try
            {
               
                txtCircleName.Text = "";
                ddlUtility.SelectedValue = "0";
                ddlWingName.SelectedValue = "0";
                ddlZoneName.SelectedValue = "0";
              


            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlZoneName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = ddlZoneName.SelectedValue.ToString();
            if (ddlWingName.SelectedValue == "0" || ddlUtility.SelectedValue == "0" || ddlZoneName.SelectedValue=="0")
            {
                Circle.Visible = false;
            }
            else
            {
                Circle.Visible = true;
                GridBind();
            }
        }
        private void GridBind()
        {
            try
            {
                string Id = ddlZoneName.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetCircleMaster(Id);
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
    }
}