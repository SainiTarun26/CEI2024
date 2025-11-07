using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Wiremen
{
    public partial class RenewalHistoryWireman : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string userID = "";
        string Category = "";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Renwal"]) != "" && Convert.ToString(Session["Renwal"]) != null)
            {
                this.Page.MasterPageFile = "~/Wiremen/Wireman_Renewal.Master";

            }
            else
            {
                this.Page.MasterPageFile = "~/Wiremen/Wiremen.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {                   
                   if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")                   
                    {
                        Category = "WiremanId";
                        userID = Session["WiremanId"].ToString();
                        HdnUserId.Value = userID;
                        HdnUserType.Value = "WiremanId";
                        GetRenewalDetails(userID);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void GetRenewalDetails(string userID)
        {
            try
            {
                DataTable ds = new DataTable();

                ds = CEI.GetRenewalData(userID);
                if (ds.Rows.Count > 0)
                {
                    string filePath = ds.Rows[0]["LetterPath"].ToString();
                    HdnPanFilePath.Value = filePath;
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
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                string RegNo = e.CommandArgument.ToString();

                Session["NewApplicationRegistrationNo"] = RegNo;
                Response.Write("<script>window.open('/UserPages/Certificate_Renewal_Details_Preview.aspx','_blank');</script>");
            }
            else if (e.CommandName == "Reapply")
            {
                Session["Reapply"] = "Yes"; 
                Response.Redirect("~/Wiremen/Renewal_Certificate_Wiremen.aspx");
            }
            else if (e.CommandName == "ViewVerificationLetter")
            {

                string fileUrl = "https://uat.ceiharyana.com" + HdnPanFilePath.Value;
                string script = $@"<script>window.open('{fileUrl}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus")?.ToString();
                string VerificationLetter = DataBinder.Eval(e.Row.DataItem, "LetterPath")?.ToString();
                if (VerificationLetter != "" && VerificationLetter != null)
                {
                    GridView1.Columns[8].Visible = true;

                }

                if (status == "Return" || status == "Rejected")
                {
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[9].Visible = true;
                }
                else
                {
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[9].Visible = false;
                }
            }
        }


        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                // Disable all Reapply buttons first
                foreach (GridViewRow row in GridView1.Rows)
                {
                    LinkButton btn = row.FindControl("lnkReapply") as LinkButton;
                    if (btn != null)
                    {
                        btn.Visible = false;

                    }
                }


                GridViewRow lastRow = GridView1.Rows[GridView1.Rows.Count - 1];
                LinkButton lastBtn = lastRow.FindControl("lnkReapply") as LinkButton;
                if (lastBtn != null)
                {
                    lastBtn.Visible = true;

                }
            }
        }
    }
}