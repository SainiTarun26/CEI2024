using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

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
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        ddlPoweUtilityBind();
                        GridBind();
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
                //string Id = ddlZone.SelectedValue.ToString();
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

                string Circleid = ddlCircle.SelectedValue.ToString();

                DataSet dsDivision = new DataSet();
                dsDivision = CEI.GetDivisionName(UtilityId, WingId, ZoneId, Circleid);
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
            string UtilityId = ddlUtility.SelectedValue.ToString();

            DdlWingBind();
            GridBind();


        }

        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            string WingId = ddlWing.SelectedValue.ToString();
            if (ddlWing.SelectedValue == "0")
            {
                ddlWing.SelectedValue = "0";
            }
            DdlZoneBind();
            GridBind();


        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ZoneId = ddlZone.SelectedValue.ToString();
            if (ddlZone.SelectedValue == "0")
            {
                ddlZone.SelectedValue = "0";
            }
            DdlCircleBind();
            GridBind();

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Only try and exception in catch added by navneet 30-May-2025
            try
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Sub-Division name Submitted Successfully !!!');", true);
                    GridBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('This EmailId Already Exists. Please use another one !!!');", true);

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
            string CircleId = ddlCircle.SelectedValue.ToString();
            if (ddlCircle.SelectedValue == "0")
            {
                ddlCircle.SelectedValue = "0";
            }
            DdlDivisionBind();
            GridBind();
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DivisionId = ddlDivision.SelectedValue.ToString();
            if (ddlDivision.SelectedValue == "0")
            {
                ddlDivision.SelectedValue = "0";
            }
            Session["DivisionId"] = ddlDivision.SelectedValue.ToString();
            GridBind();
        }

        private void GridBind()
        {
            try
            {
                string UtilityId = ddlUtility.SelectedValue.ToString();
                string WingId = ddlWing.SelectedValue.ToString();
                string ZoneId = ddlZone.SelectedValue.ToString();
                string CircleId = ddlCircle.SelectedValue.ToString();
                string DivisionId = ddlDivision.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSubDivisionMaster(UtilityId, WingId, ZoneId, CircleId, DivisionId, txtSearch.Text);
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
        #region kalpana change password 30-July-2025
        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string UserId = txtUserId.Text.Trim();
            string password = txtPassword.Text.Trim();
            string Email = hdnEmailId.Value;
            try
            {
                if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Email))
                {
                    int Ad = CEI.ResetPasswordByAdmin(UserId, password);
                    if (Ad > 0)
                    {
                        hdnEmailId.Value = null;
                        string script = @"
                    alert('Password Reset successfully.');
                    $('#updatePasswordModal').modal('hide');
                    $('body').removeClass('modal-open');
                    $('.modal-backdrop').remove();
                ";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ResetSuccessScript", script, true);
                    }
                    else
                    {
                        string script = "alert('Password Not Reset.')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ResetFailScript", script, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MissingFieldsScript", "alert('UserId or Email is Not Found')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ExceptionScript", $"alert('{ex.Message.Replace("'", "\\'")}')", true);
            }
        }

        #endregion
        #region Neha search 7-Aug-2025
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reset")
            {
                Control ctrl = e.CommandSource as Control;
                if (ctrl != null)
                {
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label RowID = (Label)row.FindControl("lblRowID");
                    int rowIdInt = Convert.ToInt32(RowID.Text);
                   
                    DataTable dt = new DataTable();
                    dt = CEI.GetSubDivisionMasterDataAfterFilter(rowIdInt);
                    txtUserId.Text = dt.Rows[0]["UserId"].ToString();
                }

            }
        }
        #endregion
    }


}
