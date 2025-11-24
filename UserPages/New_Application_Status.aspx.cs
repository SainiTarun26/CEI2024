using CEI_PRoject;
using CEIHaryana.Contractor;
using iText.Layout.Element;
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
    public partial class New_Application_Status : System.Web.UI.Page
    {

        // Created by neha on 27-June-2025
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
                        BindGridData(UserID);
                    }
                    else if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        string UserID = Session["SupervisorID"].ToString();
                        BindGridData(UserID);
                    }
                    else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        string UserID = Session["WiremanId"].ToString();
                        BindGridData(UserID);
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

        private void BindGridData(string UserID)
        {
            //DataTable dt = CEI.GetUserGridData(UserID);
            DataTable dt = CEI.GetUserApplicationGridDataByUserId(UserID);
            if (dt.Rows.Count > 0)
            {
                string filePath = dt.Rows[0]["LetterPath"].ToString();
                HdnPanFilePath.Value = filePath;
                if (string.IsNullOrEmpty(filePath))
                {
                    GridView1.Columns[11].Visible = false;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;

            if (ctrl != null)
            {
                GridViewRow row = ctrl.NamingContainer as GridViewRow;

                if (row != null)
                {
                    Label lblID = row.FindControl("lblID") as Label;
                    Label lblCategory = row.FindControl("lblCategory") as Label;


                    if (lblID == null || lblCategory == null)
                        return;

                    string idValue = lblID.Text.Trim();
                    string category = lblCategory.Text.Trim();

                    if (e.CommandName == "ViewUser")
                    {
                        if (category == "Supervisor" || category == "Wireman")
                        {
                            Session["NewApplicationRegistrationNo"] = idValue;
                            Response.Redirect("~/Print_Forms/Print_New_Registration_Information.aspx");
                        }
                        else if (category == "Contractor")
                        {
                            Session["NewApplication_Contractor_RegNo"] = idValue;
                            Response.Redirect("~/Print_Forms/Print_New_Registration_Information_Contractor.aspx");
                        }

                    }
                    else if (e.CommandName == "ViewDetails")
                    {
                        if (category == "Supervisor" || category == "Wireman")
                        {
                            Session["NewApplicationRegistrationNo"] = idValue;
                            Response.Redirect("~/UserPages/New_Registration_Information.aspx");
                        }
                        else if (category == "Contractor")
                        {
                            Session["NewApplication_Contractor_RegNo"] = idValue;
                            Response.Redirect("~/UserPages/New_Registration_Information_Contractor.aspx");
                        }
                    }
                    else if (e.CommandName == "ViewVerificationLetter")
                    {

                        string fileUrl = "https://uat.ceiharyana.com" + HdnPanFilePath.Value;
                        string script = $@"<script>window.open('{fileUrl}', '_blank');</script>";
                        //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenFileInNewTab", script, false);


                    }
                    else if (e.CommandName == "Reapply")
                    {

                        if (category == "Supervisor" )
                        {
                            Session["InsertedCategory"] = "Supervisor";
                            Session["UserIdForEdit"] = idValue;
                            Session["SupervisorID"] = idValue;
                            Response.Redirect("~/UserPages/Update_Supervisor_Qualification.aspx");
                        }
                        else if (category == "Wireman")
                        {
                            Session["InsertedCategory"] = "Wireman";
                            Session["UserIdForEdit"] = idValue;
                            Session["WiremanId"] = idValue;
                            Response.Redirect("~/UserPages/Update_Wireman_Qualification.aspx");
                        }
                        else if (category == "Contractor")
                        {
                            Session["ContractorID"] = idValue;
                            Response.Redirect("~/UserPages/Update_Contractor_Application_Form.aspx");
                        }
                    }
                }
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/AdminLogout.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string status = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus")?.ToString();
                string status = DataBinder.Eval(e.Row.DataItem, "Status")?.ToString();

                Label lblID = e.Row.FindControl("lblID") as Label;
                Label active = e.Row.FindControl("lblActiveStatus") as Label;
                // Find LinkButton
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkReapply");

                if (lblID != null)
                {
                    HdnID.Value = lblID.Text.Trim();
                }

                if (active.Text == "0" || status == "Submit" || status == "Resubmit")
                {
                    lnk.Enabled = false;       // disable
                    lnk.ForeColor = System.Drawing.Color.Gray;   // visual hint (optional)
                    lnk.Visible = false;
                }

                if (status == "Return"|| status == "Rejected")
                {
                    GridView1.Columns[12].Visible = true;
                    GridView1.Columns[13].Visible = true;
                    lnk.Visible = true;
                }
                else
                {
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (HdnID.Value != null && HdnID.Value != null)
            {
                Session["NewUser_RegNoID"] = HdnID.Value;
                Response.Redirect("~/UserPages/ReSubmitDocumentofNewUser.aspx");
            }
        }
    }
}
