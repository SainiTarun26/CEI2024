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
                Session["Renwal"] = "No";
                Response.Redirect("~/Wiremen/Renewal_Certificate_Wiremen.aspx");
            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus")?.ToString();


                if (status == "Returned" || status == "Rejected")
                {
                    GridView1.Columns[7].Visible = true;
                }
                else
                {
                    GridView1.Columns[7].Visible = false;
                }
            }
        }
    }
}