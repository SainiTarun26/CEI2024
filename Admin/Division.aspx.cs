using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace CEIHaryana.Admin
{
    public partial class Division : System.Web.UI.Page
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
                ddlWing.DataSource = dsWing;
                ddlWing.DataTextField = "WingName";
                ddlWing.DataValueField = "Id";
                ddlWing.DataBind();
                ddlWing.Items.Insert(0, new ListItem("Select", "0"));
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
                string WingId = ddlWing.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                dsZone = CEI.GetZoneName(UtilityId, WingId);
                ddlZone.DataSource = dsZone;
                ddlZone.DataTextField = "ZoneName";
                ddlZone.DataValueField = "Id";
                ddlZone.DataBind();
                ddlZone.Items.Insert(0, new ListItem("Select", "0"));
                dsZone.Clear();
            }
            catch
            {
            }

        }
        private void DdlCircleBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                DataSet dsCircle = new DataSet();
                dsCircle = CEI.GetCirclesName(UtilityId, WingId, ZoneId);
                ddlCircle.DataSource = dsCircle;
                ddlCircle.DataTextField = "CircleName";
                ddlCircle.DataValueField = "Id";
                ddlCircle.DataBind();
                ddlCircle.Items.Insert(0, new ListItem("Select", "0"));
                dsCircle.Clear();
            }
            catch
            {
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string DivisionName = txtDivisionName.Text.Trim();
            DataSet ds1 = CEI.checkDivisionName(DivisionName);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string script = $"alert('Division Name  {DivisionName}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
                CEI.InsertInDivisionMaster(txtDivisionName.Text.Trim(), ddlUtility.SelectedValue, ddlWing.SelectedValue,
                    ddlZone.SelectedValue, ddlCircle.SelectedValue);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Division Name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUtility.SelectedValue == "0")
            {
                ddlWing.SelectedValue = "0";
                ddlZone.SelectedValue = "0";
                ddlCircle.SelectedValue = "0";
                Circle.Visible = false;
            }
            else
            {
                DdlWingBind();
            }

        }

        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWing.SelectedValue == "0")
            {
           
                ddlZone.SelectedValue = "0";
                ddlCircle.SelectedValue = "0";
                Circle.Visible = false;
            }
            else
            {
                DdlZoneBind();
            }

        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlZone.SelectedValue == "0")
            {
              ddlCircle.SelectedValue = "0";
                Circle.Visible = false;

            }
            else
            {
                DdlCircleBind();
            }
         

        }
        protected void Reset()
        {
            try
            {
                ddlUtility.SelectedValue = "0";
                txtDivisionName.Text = "";
                 ddlWing.SelectedValue = "0";
                ddlZone.SelectedValue = "0";
                ddlCircle.SelectedValue = "0";


            }
            catch (Exception ex)
            {
            }
        }


        private void GridBind()
        {
            try
            {
                string Id = ddlCircle.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetDivisionMaster(Id);
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

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = ddlCircle.SelectedValue.ToString();
            if (ddlWing.SelectedValue == "0" || ddlUtility.SelectedValue == "0" || ddlZone.SelectedValue == "0" || ddlCircle.SelectedValue =="0")
            {
                Circle.Visible = false;
            }
            else
            {
                Circle.Visible = true;
                GridBind();
            }
        }
    }
}