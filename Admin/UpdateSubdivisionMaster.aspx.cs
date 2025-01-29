using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace CEIHaryana.Admin
{
    public partial class UpdateSubdivisionMaster : System.Web.UI.Page
    {
        CEI CEI = new CEI();
      //  string UserId;
        string UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminID"] != null && Convert.ToString(Session["AdminID"]) != "")
                {
                    ddlPoweUtilityBind();
                    Getdata();
                }

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

        public void Getdata()
        {
          string ID = Session["SubDivisionID"].ToString() ;
            DataSet ds = new DataSet();
            ds = CEI.GetDataForUpdateSubdivision(ID);
            txtSubDivision.Text = ds.Tables[0].Rows[0]["SubDivision"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                Session["EmailId"] = txtEmail.Text;
            }
            string dp_Id = ds.Tables[0].Rows[0]["UtilityId"].ToString();
            ddlUtility.SelectedIndex = ddlUtility.Items.IndexOf(ddlUtility.Items.FindByValue(dp_Id));
           
            string dp_Id1 = ds.Tables[0].Rows[0]["WingId"].ToString();
            DdlWingBind();
            ddlWing.SelectedIndex = ddlWing.Items.IndexOf(ddlWing.Items.FindByValue(dp_Id1));
            string dp_Id2 = ds.Tables[0].Rows[0]["ZoneId"].ToString();
            DdlZoneBind();
            ddlZone.SelectedIndex = ddlZone.Items.IndexOf(ddlZone.Items.FindByValue(dp_Id2));
            string dp_Id3 = ds.Tables[0].Rows[0]["CircleId"].ToString();
            DdlCircleBind();
            ddlCircle.SelectedIndex = ddlCircle.Items.IndexOf(ddlCircle.Items.FindByValue(dp_Id3));
            string dp_Id4 = ds.Tables[0].Rows[0]["DivisionId"].ToString();
            DdlDivisionBind();
            ddlDivision.SelectedIndex = ddlDivision.Items.IndexOf(ddlDivision.Items.FindByValue(dp_Id4));
            txtUserId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
            Session["UserName"] = ds.Tables[0].Rows[0]["SubDivision"].ToString(); 
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
        private void DdlDivisionBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                string CircleId = ddlCircle.SelectedValue.ToString();

                DataSet dsDivision = new DataSet();
                dsDivision = CEI.GetDivisionName(UtilityId, WingId, ZoneId, CircleId);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserName = Session["UserName"].ToString();
            if (Session["EmailId"] == null && Convert.ToString(Session["EmailId"]) == "")
            {
                string email = txtEmail.Text.Trim();
                DataSet ds1 = CEI.checkEmail(email);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {

                    string script = $"alert('User with Email ID  {email}  already exists.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                    return;

                }

            }
            
            UserName = txtSubDivision.Text.Trim();
            if (txtSubDivision.Text != UserName)
            {
                DataSet ds2 = CEI.checkSubDivisionName(UserName);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {

                    string script = $"alert('User with Same Name  {UserName}  already exists.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

                }
            }
            CEI.UpdateSubdivision(txtUserId.Text, txtSubDivision.Text.Trim() , txtEmail.Text.Trim(), txtPhone.Text.Trim(), ddlUtility.SelectedValue.Trim(),ddlWing.SelectedValue.Trim(),
                ddlZone.SelectedValue.Trim(), ddlCircle.SelectedValue.Trim(),ddlDivision.SelectedValue.Trim());
            Reset();
            Session["SubDivisionID"] = "";
            Session["UserName"] = "";
            Session["EmailId"] = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Sub-Division details updated Successfully !!!');  window.location='SubDivisionMaster.aspx'", true);
            


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

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDivisionBind();
        }
    }
}