using CEI_PRoject;
using CEIHaryana.Contractor;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Get_UserCurrent_Licence : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        string UserID = Session["ContractorID"].ToString();
                        HdnID.Value = UserID;
                        GridBind(UserID);
                    }
                    else if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        string UserID = Session["SupervisorID"].ToString();
                        HdnID.Value = UserID;
                        GridBind(UserID);
                    }
                    else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        string UserID = Session["WiremanId"].ToString();
                        HdnID.Value = UserID;
                        GridBind(UserID);
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        public void GridBind(string Userid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Latest_Licence_UserWise(Userid);

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
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/AdminLogout.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (HdnID.Value != null && HdnID.Value != null)
            {
                Session["NewUser_RegNoID"] = HdnID.Value;
                Response.Redirect("~/UserPages/ReSubmitDocumentofNewUser.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select" || e.CommandName == "Print")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Label lblgetCategory = (Label)row.FindControl("lblgetCategory");
                Label lblLicenceType = (Label)row.FindControl("lblLicenceType");

                string applicationId = lblApplicationId?.Text;
                string category = lblgetCategory?.Text;

                Session["Application_Id"] = applicationId;

                if (e.CommandName == "Select")
                {
                    Response.Redirect("Licence_Approval_DetailsView_Cei.aspx", false);
                    return;
                }

                if (e.CommandName == "Print")
                {

                    if (!string.IsNullOrEmpty(lblLicenceType.Text) && lblLicenceType.Text == "New")
                    {
                        switch (category)
                        {
                            case "Contractor":
                                Response.Redirect("/Print_Forms/Contractor_Licence_New_Certificate.aspx", false);
                                break;
                            case "Supervisor":
                                Response.Redirect("/Print_Forms/Certificate_of_Competency.aspx", false);
                                break;
                            case "Wireman":
                                Response.Redirect("/Print_Forms/Certificate_of_wireman_Permit.aspx", false);
                                break;
                        }
                    }
                    else if (!string.IsNullOrEmpty(lblLicenceType.Text) && lblLicenceType.Text == "Renewal")
                    {
                        switch (category)
                        {
                            case "Contractor":
                                Response.Redirect("/Print_Forms/ContractorLicenceRenewal.aspx", false);
                                break;
                            case "Supervisor":

                                Response.Redirect("/Print_Forms/CertificateOfCompetencyRenewal.aspx", false);
                                break;
                            case "Wireman":
                                Response.Redirect("/Print_Forms/CertificateOfWiremanPermitRenewal.aspx", false);
                                break;
                        }
                    }
                    else if (!string.IsNullOrEmpty(lblLicenceType.Text) && lblLicenceType.Text == "Upgrade")
                    {
                        switch (category)
                        {
                            case "Contractor":
                                Response.Redirect("/Print_Forms/Contractor_Licence_Upgradation_Certificate.aspx", false);
                                break;
                            case "Supervisor":

                                Response.Redirect("/Print_Forms/Certificate_Of_Competency_Upgradation.aspx", false);
                                break;
                           
                        }
                    }

                }
            }
        }
    }
}