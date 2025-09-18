using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.GuestAdmin
{
    public partial class CinemaInspectionDetailsGuestAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static string ApprovedorReject;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnAdminId.Value = "";
                    
                    if (Convert.ToString(Session["GuestAdmin"]) != null && Convert.ToString(Session["GuestAdmin"]) != string.Empty && Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != string.Empty)
                    {
                        hdnAdminId.Value = Session["GuestAdmin"].ToString();
                        txtInspectionID.Text = Session["InspectionId"].ToString();

                        GetData(txtInspectionID.Text);
                        GetInspectionData(txtInspectionID.Text);
                        GridBindDocument(txtInspectionID.Text);                    
                        GetTestReportDataNew(txtInspectionID.Text);

                        Page.Session["ClickCount"] = "0";
                      
                        if (!IsPostBack && Request.UrlReferrer != null)
                        {
                            ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
                        }
                    }
                    else
                    {
                        Session["GuestAdmin"] = "";
                        Response.Redirect("/GuestAdmin/GuestAdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }

        private void GetData(string Id)
        {
            try
            {
                if (Convert.ToString(Session["GuestAdmin"]) == hdnAdminId.Value && txtInspectionID.Text != null && txtInspectionID.Text != string.Empty)
                {
                    DataTable dt = CEI.GetSiteOwnerData_Cinema(Id);
                    txtSiteOwnerName.Text = dt.Rows[0]["OwnerName"].ToString();
                    txtPAN.Text = dt.Rows[0]["PANNumber"].ToString();
                    txtCinemaName.Text = dt.Rows[0]["NameOfCinema"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtDistrict.Text = dt.Rows[0]["District"].ToString();
                    txtTransactionId.Text = dt.Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = dt.Rows[0]["TransactionDate"].ToString();
                    txtAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtInspection.Text = dt.Rows[0]["InspectionDate"].ToString();
                    txtRemarksApprove.Text = dt.Rows[0]["Suggestion"].ToString();
                    txtReasonReject.Text = dt.Rows[0]["ReasonForRejection"].ToString();
                    lblInspectionType.Text = dt.Rows[0]["TypeOfInspection"].ToString();
                    lblInstallation.Text = dt.Rows[0]["InstallationType"].ToString();
                    lblUserType.Text = dt.Rows[0]["UserType"].ToString();
                    txtApplicationStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                    {

                        if (txtApplicationStatus.Text == "Approved")
                        {
                            ApproveOrReject.Visible = true;
                            AppRemarks.Visible = true;
                            InsDate.Visible = true;

                        }
                        else if (txtApplicationStatus.Text == "Rejected")
                        {
                            ApproveOrReject.Visible = true;
                            ReReason.Visible = true;
                            InsDate.Visible = false;

                        }
                        else if (txtApplicationStatus.Text == "Return")
                        {
                            ApproveOrReject.Visible = false;
                            AppRemarks.Visible = false;
                            InsDate.Visible = false;

                        }
                    }
                }
                else
                {
                    Session["GuestAdmin"] = "";
                    Response.Redirect("/GuestAdmin/GuestAdminLogout.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        private void GetInspectionData(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionHistoryLogs(InspectionId);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GetTestReportDataNew(string ID)
        {
            try
            {
                DataSet dsVC = CEI.GetDetailsToViewCinemaTestReport(ID);
                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    DivTestReports.Visible = true;
                    New.Visible = true;
                    GridView2.DataSource = dsVC;
                    GridView2.DataBind();
                }
                else
                {
                    DivTestReports.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void GridBindDocument(string ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Lblgrd_Documemnts.Visible = false;
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    Lblgrd_Documemnts.Visible = true;
                    Lblgrd_Documemnts.Text = "Documents Not Uploaded by User.";
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["GuestAdmin"]) != null && Convert.ToString(Session["GuestAdmin"]) != string.Empty)
            {
                //Response.Redirect("/Admin/AcceptedOrRejectedRequest.aspx", false);
                //Commented by aslam 30-July-2025
                if (ViewState["PreviousPageUrl"] != null)
                {
                    Response.Redirect(ViewState["PreviousPageUrl"].ToString(), false);
                }
            }
            else
            {
                Session["GuestAdmin"] = "";
                Response.Redirect("/GuestAdmin/GuestAdminLogout.aspx", false);
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
    }
}