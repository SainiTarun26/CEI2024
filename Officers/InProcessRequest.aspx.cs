﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class InProcessRequest : System.Web.UI.Page
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
            catch (Exception)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InProcessRequest(LoginID);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            ds.Dispose();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                if (e.CommandName == "Select")
                {


                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblInstallationfor = (Label)row.FindControl("lblInstallationfor");
                    Label LblInspectionCount = (Label)row.FindControl("LblInspectionCount");
                    string id = lblID.Text;
                    Session["InProcessInspectionId"] = id;
                    if (lblInstallationfor.Text.Trim() == "Lift" || lblInstallationfor.Text.Trim() == "Escalator" || lblInstallationfor.Text.Trim() == "MultiLift" || lblInstallationfor.Text.Trim() == "MultiEscalator" || lblInstallationfor.Text.Trim() == "Lift/Escalator")
                    {
                        if (int.TryParse(LblInspectionCount.Text, out int count) && count > 1)
                        {

                            Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                            return;

                        }
                        else
                        {
                            Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                            return;
                        }
                    }
                    //if (int.TryParse(LblInspectionCount.Text, out int count) && count > 1)
                    //{

                    //    Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                    //    return;

                    //}

                    //else   if (lblInstallationfor.Text.Trim() == "Lift" || lblInstallationfor.Text.Trim() == "Escalator" || lblInstallationfor.Text.Trim() == "MultiLift" || lblInstallationfor.Text.Trim() == "MultiEscalator" || lblInstallationfor.Text.Trim() == "Lift/Escalator")
                    //{
                    //    Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                    //    return;
                    //} else if condition added by neeraj on 20-may-2025
                    else if (lblInstallationfor.Text.Trim() == "Cinema_Videos Talkies")
                    {
                        Response.Redirect("/Officers/ActionForCinemaVideo_Talkies.aspx", false);
                        return;
                    }
                    //
                    else
                    {
                        Response.Redirect("/Officers/InProcessInspection.aspx", false);
                    }




                }
                //Kalpna siteownerpop up 18-July-2025
                else if (e.CommandName == "ShowDetails")
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
                //
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File not found!');", true);
            }
        }
        #endregion


    }
}