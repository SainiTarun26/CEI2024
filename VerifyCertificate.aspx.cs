using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana
{
    public partial class VerifyCertificate : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCAPTCHA();
                txtSecurityCode.Text = "";
                txtRegistrationNo.Text = "";
                //RadioBtnType.SelectedIndex = -1;

            }
        }

        private void FillCAPTCHA()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                Session["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch
            {
                throw;
            }
        }
   
        //protected void RadioBtnType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RadioBtnType.SelectedValue == "0") // Lift/Esclator 
        //    {
        //        CertificateDetails.Visible = false;
        //        CertificateDetailsForLift.Visible = false;
        //        FillCAPTCHA();
        //        txtSecurityCode.Text = "";
        //        txtMemoNo.Text = "";
        //        txtRegistrationNo.Text = "";
        //        trMemoNo.Visible = false;
        //        trRegistrationNo.Visible = true;
        //        trEnterSecurityCode.Visible = true;
        //        trCode.Visible = true;
        //        DivButtons.Visible = true;
        //    }
        //    else if (RadioBtnType.SelectedValue == "1") // Generator/Line/Transformer 
        //    {
        //        CertificateDetails.Visible = false;
        //        CertificateDetailsForLift.Visible = false;
        //        FillCAPTCHA();
        //        txtSecurityCode.Text = "";
        //        txtMemoNo.Text = "";
        //        txtRegistrationNo.Text = "";              
        //        trMemoNo.Visible = true;
        //        trRegistrationNo.Visible = false;
        //        trEnterSecurityCode.Visible = true;
        //        trCode.Visible = true;
        //        DivButtons.Visible = true;
        //    }
        //}

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Print")
        //        {
        //            Control ctrl = e.CommandSource as Control;
        //            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //            Label lblID = (Label)row.FindControl("lblID");
        //            string id = lblID.Text;
        //            Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
        //            string InstallationType = lblInstallationType.Text.Trim();
        //            Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
        //            Session["ViewCertificate"] = id;
        //            if (LblInspectionType.Text == "New")
        //            {
        //                Session["InProcessInspectionId"] = id;
        //                if (InstallationType == "Multiple")
        //                {
        //                    Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
        //                }
        //                else if (InstallationType != "Lift" && InstallationType != "Escalator" && InstallationType != "Lift/Escalator" && InstallationType != "MultiLift" && InstallationType != "MultiEscalator")
        //                {
        //                    Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
        //                }
                        
        //            }
        //            else if (LblInspectionType.Text == "Periodic")
        //            {
        //                Session["InProcessInspectionId"] = id;
        //                if (InstallationType != "Lift" && InstallationType != "Escalator" && InstallationType != "Lift/Escalator" && InstallationType != "MultiLift" && InstallationType != "MultiEscalator")
        //                {
        //                    Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
        //                }
                      
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                    string id = lblID.Text;
                    Label lblInspectionId = (Label)row.FindControl("lblInspectionId");
                    string Inspectionid = lblInspectionId.Text;

                    
                    Session["LiftTestReportID"] = id;
                    Session["InProcessInspectionId"] = Inspectionid;
                    if (lblInspectionType.Text.Trim()== "New") {
                        if (lblInstallationType.Text == "Lift")
                        {
                            Response.Redirect("/Print_Forms/LiftApprovalCertificate.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("/Print_Forms/EscalatorApprovalCertificate.aspx", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("/Print_Forms/Print_Renewal_Of_Lift.aspx", false);

                    }
                }
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Session["captcha"].ToString() != txtSecurityCode.Text)
            {
                FillCAPTCHA();
                txtSecurityCode.Focus();
                string script = "alert(\"Invalid Security Code.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                //CertificateDetails.Visible = true;
                //if (!string.IsNullOrWhiteSpace(txtMemoNo.Text)) // Generator/Line/Transformer 
                //{
                //    CertificateDetails.Visible = true;
                //    CertificateDetailsForLift.Visible = false;
                //    DataSet ds = CEI.GetVerifyCertificateDetails(txtMemoNo.Text);
                //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //    {
                //        GridView1.DataSource = ds;
                //        GridView1.DataBind();
                //        lblNoDataMessage.Visible = false;
                //        GridView1.Visible = true;
                //    }
                //    else
                //    {
                //        GridView1.DataSource = null;
                //        GridView1.DataBind();
                //        GridView1.Visible = false;
                //        lblNoDataMessage.Text = "No any certificate Available with this number";
                //        lblNoDataMessage.Visible = true;
                //    }
                //    ds.Dispose();
                //}
                //else 
                if (!string.IsNullOrWhiteSpace(txtRegistrationNo.Text)) 
                {
                    //CertificateDetails.Visible = false;
                    CertificateDetailsForLift.Visible = true;
                    DataSet ds = CEI.GetVerifyCertificateDetailsforLift(txtRegistrationNo.Text);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();

                        GridView2.Visible = true;
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                        GridView2.Visible = false;

                        Label1.Text = "No any certificate Available with this number";
                        Label1.Visible = true;
                    }
                    ds.Dispose();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogout.aspx", false);
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCAPTCHA();
        }
    }
}