using CEI_PRoject;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;

namespace CEIHaryana.SiteOwnerPages
{
    //Created By neeraj 22-May-2025
    public partial class InspectionDetailsCinema : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private bool hasLinkInAnyRow = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        if (Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != "")
                        {
                            hdnOwnerId.Value = Session["SiteOwnerId"].ToString();
                            txtApplicationNo.Text = Session["InspectionId"].ToString();
                            GetData(txtApplicationNo.Text);
                            GetInspectionData(txtApplicationNo.Text);
                            GridBindDocument(txtApplicationNo.Text);
                            // for  Test Report data
                            GetTestReportDataNew(txtApplicationNo.Text);
                        }
                    }
                    else
                    {
                        Response.Redirect("/login.aspx", false);
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
                if (Convert.ToString(Session["SiteOwnerId"]) == hdnOwnerId.Value && txtApplicationNo.Text != null && txtApplicationNo.Text != string.Empty)
                {
                    DataTable dt = CEI.GetSiteOwnerData_CinemaOfficer(Id);
                    lblInspectionType.Text = dt.Rows[0]["TypeOfInspection"].ToString();                                 
                    txtWorkType.Text = dt.Rows[0]["InstallationType"].ToString();       
                    txtAmount.Text = dt.Rows[0]["TotalAmount"].ToString();                    
                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx");
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

                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
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
                    TestReport.Visible = true;
                    New.Visible = true;
                    GridView3.DataSource = dsVC;
                    GridView3.DataBind();
                }
                else
                {
                    TestReport.Visible = false;
                    GridView3.DataSource = null;
                    GridView3.DataBind();
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
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
            {
                Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
            }
            else
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx");
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
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //lblerror.Text = fileName;
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
                else
                {

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