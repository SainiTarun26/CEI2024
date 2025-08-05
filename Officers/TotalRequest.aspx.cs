using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class TotalRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["StaffID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.TotalRequest(LoginID);
                if (ds.Tables.Count > 0 && ds != null)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Kalpna siteownerpop up 18-July-2025

            try
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                if (e.CommandName == "ShowDetails")
                {
                    Label lbllblApplicantFor = (Label)row.FindControl("lblApplicantFor");

                    if (lbllblApplicantFor.Text == "Power Utility")
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();

                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "openModal();", true);
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#ownerModal').modal('show');", true);
                        binddataforPowerUtility(CreatedBy);
                    }
                    else
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();

                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "openModal();", true);
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#ownerModal').modal('show');", true);
                        binddata(CreatedBy);

                    }

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "aleert", "alert('" + ex.Message + "');", true);
            }
            #endregion
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }
        //Powerutility condition aded by aslam 16-July-2025

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbllblApplicantFor = (Label)e.Row.FindControl("lblApplicantFor");

                if (lbllblApplicantFor != null && lbllblApplicantFor.Text == "Power Utility")
                {
                    e.Row.CssClass = "PowerUtilityRowColor";
                }
            }
        }
        //
        #region Kalpna siteownerpop up 18-July-2025

        protected void binddata(string CreatedBy)
        {

            DataTable dt = CEI.DetailsofSiteOwner(CreatedBy);


            if (dt != null && dt.Rows.Count > 0)
            {
                txttypeofapplicant.Text = dt.Rows[0]["ApplicantType"].ToString();
                txtPANTan.Text = dt.Rows[0]["UserID"].ToString();
                txtElectricalInstallation.Text = dt.Rows[0]["ContractorType"].ToString();
                txtName.Text = dt.Rows[0]["OwnerName"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtPin.Text = dt.Rows[0]["Pincode"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                HdnPanFilePath.Value = dt.Rows[0]["CopyofPanNumber"].ToString();
            }
        }
        protected void binddataforPowerUtility(string CreatedBy)
        {

            DataTable dt = CEI.DetailsforPowerUtility(CreatedBy);


            if (dt != null && dt.Rows.Count > 0)
            {
                txttypeofapplicant.Text = dt.Rows[0]["ApplicantType"].ToString();
                txtPANTan.Text = dt.Rows[0]["PANNumber"].ToString();
                txtElectricalInstallation.Text = dt.Rows[0]["ContractorType"].ToString();
                txtName.Text = dt.Rows[0]["OwnerName"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtPin.Text = dt.Rows[0]["Pincode"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                HdnPanFilePath.Value = dt.Rows[0]["CopyofPanNumber"].ToString();
            }
        }

        protected void LnkDocumemtPath_Click(object sender, EventArgs e)
        {
            string filePath = HdnPanFilePath.Value;
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileUrl = "https://localhost:44393/" + filePath;
                string script = $@"<script>window.open('{fileUrl}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Siteowner has not uploaded the PAN card yet!');", true);
            }
        }
        #endregion


    }
}