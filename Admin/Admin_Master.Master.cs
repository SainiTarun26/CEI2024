
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEI_PRoject.ADMIN
{
    public partial class Admin_Master : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   // string hideEntireModal = "$('#searchModal').modal('hide'); alert('No Record Found');";
                    //Changed By neeraj 22-May-2025
                    if (Convert.ToString(Session["AdminID"]) != null && Convert.ToString(Session["AdminID"]) != string.Empty && Request.Cookies["AdminID"] != null)
                    {//
                        if (Request.Cookies["AdminID"] != null)
                        {

                            lblName.Text = Request.Cookies["AdminID"].Value;
                            if (string.Equals(lblName.Text, "Admin@123", StringComparison.OrdinalIgnoreCase))
                            {

                                UtilityMasterTab.Visible = true;
                                WingMasterTab.Visible = true;
                                ZoneMasterTab.Visible = true;
                                CircleMasterTab.Visible = true;
                                DivisionMasterTab.Visible = true;
                                SubDivisionMasterTab.Visible = true;
                                SLDRequest.Visible = false;
                                //SLDApproval.Visible = false;
                                //SLDHistory.Visible = false;
                                NewInspectionTab.Visible = false;
                                //ActionInprocesstab.Visible = false;
                                CESE.Visible = true;
                                UpgradationRequest.Visible = true;
                                UpgradationHistory.Visible = true;
                                Printforms.Visible = true;
                                StaffDetails.Visible = true;
                                TerminationOrSuspension.Visible = false;
                            }
                            else
                            {

                                UtilityMasterTab.Visible = false;
                                WingMasterTab.Visible = false;
                                ZoneMasterTab.Visible = false;
                                CircleMasterTab.Visible = false;
                                DivisionMasterTab.Visible = false;
                                SubDivisionMasterTab.Visible = false;
                                SLDRequest.Visible = true;
                                //SLDApproval.Visible = true;
                                //SLDHistory.Visible = true;
                                NewInspectionTab.Visible = true;
                                //ActionInprocesstab.Visible = true;
                                CESE.Visible = false;
                                UpgradationRequest.Visible = true;
                                UpgradationHistory.Visible = true;
                                TerminationOrSuspension.Visible = true;
                            }
                        }
                        else
                        {
                            lblName.Text = Convert.ToString(Session["AdminID"]);
                        }
                    }
                    else if (Session["AdminID"] == null)
                    {
                        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        HttpContext.Current.Response.Cache.SetNoStore();
                        Response.Redirect("/AdminLogout.aspx");
                    }
                    else
                    {

                        Session["AdminID"] = "";
                        Response.Redirect("/AdminLogout.aspx");
                    }
                }
            }
            catch (Exception Ex)
            {
                Session["AdminID"] = "";
                Response.Redirect("/AdminLogout.aspx");
            }


        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/AdminLogout.aspx");
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string AdminId = Session["AdminID"].ToString();
            Response.Redirect("/ChangePassword.aspx");
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            GridBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#searchModal').modal('show');", true);
        }

        public void GridBind()
        {
            try
            {
                string LoginId = Convert.ToString(Session["AdminId"]);
                string searchText = txtSearch.Text;
                DataSet ds = new DataSet();

                ds = CEI.InspectionModal(LoginId, searchText);
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    hdnOpenModal.Value = "true";
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    hdnOpenModal.Value = "false";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('No Record Found');", true);
                }


                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                //if (e.CommandName == "Select")
                //{
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                string id = lblID.Text;
                Session["InspectionId"] = id;

                if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                {
                    Response.Redirect("/Admin/CinemaInspectionDetails.aspx", false);
                }
                else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                {
                    Response.Redirect("/Admin/LiftInspectionDetails.aspx", false);
                }
                else
                {
                    Response.Redirect("/Admin/InspectionDetails.aspx", false);
                }
            }
        }
    }
}