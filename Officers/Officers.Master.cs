using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class Officers : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (!IsPostBack)
                {
                  //  string hideEntireModal = "$('#searchModal').modal('hide'); alert('No Record Found');";
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        lblName.Text = Convert.ToString(Session["StaffID"]);
                        PersonDetails.Text = lblName.Text.Trim();
                        Getdesignation();
                        #region neeraj disconnection 29-May-2025
                        DataTable ds = new DataTable();
                        ds = CEI.GetOfficerDisconnection(lblName.Text);
                        if (ds.Rows.Count > 0)
                        {
                            DisconnectionNotice.Visible = true;
                            DisconnectionNoticeRequest.Visible = true;
                        }
                        #endregion
                        #region navneet 25-June-2025
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])) &&
        Convert.ToString(Session["StaffID"]).IndexOf("xen", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            NewApplications.Visible = true;
                        }
                        #endregion

                        #region aslam 2 july 2025 uat 
                        string staffId = Convert.ToString(Session["StaffID"]);

                        List<string> allowedStaffIds = new List<string>
                    {
                        "XEN_CDG",
                        "AE_CDG",
                        "AE_CDG_2"
                    };

                        if (!string.IsNullOrEmpty(staffId) &&
                            allowedStaffIds.Contains(staffId, StringComparer.OrdinalIgnoreCase))
                        {
                            Transfer_Sld.Visible = true;
                        }
                        else
                        {
                            Transfer_Sld.Visible = false;
                        }

                        #endregion
                    }
                    else if (Session["StaffID"] == null)
                    {
                        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        HttpContext.Current.Response.Cache.SetNoStore();
                        Response.Redirect("/OfficerLogout.aspx");
                    }
                    else
                    {

                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx");
                    }
                }
            }
            catch
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");
            }
        }
        private void Getdesignation()
        {
            try
            {
                string StaffID  = Convert.ToString(Session["StaffID"]);
                DataTable ds = new DataTable();
                ds = CEI.getStaffdesignation(StaffID);
                if (ds.Rows.Count > 0)
                {
                    designation.Text = ds.Rows[0]["Designation"].ToString();
                }

            }
            catch { }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/OfficerLogout.aspx");
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string StaffId = Session["StaffID"].ToString();
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
                string LoginId = Convert.ToString(Session["StaffID"]);
                string searchText = txtSearch.Text;
                DataSet ds = new DataSet();

                ds = CEI.InspectionModalforofficer(LoginId, searchText);
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

        //protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        //{
        //    Control ctrl = e.CommandSource as Control;
        //    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //    if (e.CommandName == "Select")
        //    {
        //        //if (e.CommandName == "Select")
        //        //{
        //        Label lblID = (Label)row.FindControl("lblID");
        //        Label lblApproval = (Label)row.FindControl("lblApproval");
        //        Session["Approval"] = lblApproval.Text.Trim();
        //        Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
        //        string id = lblID.Text;
        //        Session["InspectionId"] = id;

        //        if (lblInstallationFor.Text == "Cinema_Videos Talkies")
        //        {
        //            Response.Redirect("/Admin/CinemaInspectionDetails.aspx", false);
        //        }
        //        else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
        //        {
        //            Response.Redirect("/Admin/LiftInspectionDetails.aspx", false);
        //        }
        //        else
        //        {
        //            Response.Redirect("/Admin/InspectionDetails.aspx", false);
        //        }
        //    }
        //}
    }
}