using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class CreateTestReports : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    List<string> sessionKeysToRemove = new List<string>
                 {
                  "id","Duplicacy","TotalAmount"
                 };
                    ClearSessions(sessionKeysToRemove);
                    // if (Convert.ToString(Session["SiteOwnerId"]) != null || Request.Cookies["SiteOwnerId"] != null)
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        string PanNumber = Session["SiteOwnerId"].ToString();
                        hfOwner.Value = Convert.ToString(Session["SiteOwnerId"]);


                        getWorkIntimationData();
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("/SiteOwnerLogout.aspx", false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }

        private void ClearSessions(List<string> sessionKeysToRemove)
        {
            foreach (string sessionKey in sessionKeysToRemove)
            {
                if (Session[sessionKey] != null && Convert.ToString(Session[sessionKey]) != string.Empty)
                {
                    Session.Remove(sessionKey);
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 6;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }
        private void getWorkIntimationData()
        {
            if (CheckAndRedirect("SiteOwnerId", "SiteOwnerLogout.aspx"))
            {
                return;
            }
            string Id = Session["SiteOwnerId"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.TestReportData(Id);
            if (ds.Tables.Count > 0)
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

        private bool CheckAndRedirect(string sessionKeysCsv, string redirectPage)
        {
            List<string> sessionKeys = sessionKeysCsv.Split(',').Select(s => s.Trim()).ToList();
            string resultPage = CheckSessionsAndRedirect(sessionKeys, redirectPage);
            if (!string.IsNullOrEmpty(resultPage))
            {
                Response.Redirect(resultPage, false);
                return true;
            }
            return false;
        }

        private string CheckSessionsAndRedirect(List<string> sessionKeysToCheck, string redirectPage)
        {
            // List of mandatory session keys to check first
            List<string> mandatorySessionKeys = new List<string>
            {
                "SiteOwnerId"
            };
            List<string> allSessionKeysToCheck = mandatorySessionKeys.Concat(sessionKeysToCheck).ToList();

            foreach (string sessionKey in allSessionKeysToCheck)
            {
                string sessionValue = Convert.ToString(Session[sessionKey]);

                if (Session[sessionKey] == null || string.IsNullOrEmpty(Convert.ToString(Session[sessionKey])))
                {
                    if (mandatorySessionKeys.Contains(sessionKey))
                    {
                        return "/SiteOwnerLogout.aspx";
                    }
                    else
                    {
                        return redirectPage;
                    }
                }

                if (sessionKey == "SiteOwnerId" && sessionValue != hfOwner.Value)
                {
                    return "/SiteOwnerLogout.aspx"; // Redirect to logout if session value doesn't match hidden field value
                }
            }
            return null;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["id"] = lblID.Text;
                    Session["Duplicacy"] = "0";
                    Session["TotalAmount"] = "0";
                    Response.Redirect("/SiteOwnerPages/GenerateInspection.aspx", false);
                }
                else
                {
                    Session["id"] = "";
                    Session["Duplicacy"] = "0";
                    Session["TotalAmount"] = "0";
                    Response.Redirect("/SiteOwnerPages/CreateTestReports.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }
    }
}