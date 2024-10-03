using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class SubDivisionMaster : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlPoweUtilityBind();



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
                string Id = ddlUtility.SelectedValue.ToString();
                DataSet dsWing = new DataSet();
                dsWing = CEI.GetWingName(Id);
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
                string Id = ddlWing.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                dsZone = CEI.GetZoneName(Id);
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
                string Id = ddlZone.SelectedValue.ToString();
                DataSet dsCircle = new DataSet();
                dsCircle = CEI.GetCirclesName(Id);
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
        private void DdlDivisionBind()
        {
            try
            {
                string id = ddlCircle.SelectedValue.ToString();
              
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.GetDivisionName(id);
                ddlDivision.DataSource = dsDivision;
                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "Id";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
                
            }
            catch
            {
            }

        }

        protected void ddlUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlWingBind();
        }

        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlZoneBind();

        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCircleBind();
        }

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            string email = txtEmail.Text.Trim();
            if (email.Contains("@"))
            {
                UserId = email.Split('@')[0];
            }
          
            DataSet ds1 = CEI.checkEmail(email);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                
                string script = $"alert('User with Email ID  {email}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
               

                CEI.InsertInSubDivisionMaster(txtSubDivision.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(),
                    ddlUtility.SelectedValue, ddlWing.SelectedValue, ddlZone.SelectedValue, ddlCircle.SelectedValue, ddlDivision.SelectedValue, UserId);
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Sub-Division name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }
        protected void Reset()
        {
            try
            {
                ddlUtility.SelectedValue = "0";
                txtSubDivision.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                ddlWing.SelectedValue = "0";
                ddlZone.SelectedValue = "0";
                ddlCircle.SelectedValue = "0";
                ddlDivision.SelectedValue = "0";


            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDivisionBind();
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["DivisionId"] = ddlDivision.SelectedValue.ToString();
        }
    }
}
