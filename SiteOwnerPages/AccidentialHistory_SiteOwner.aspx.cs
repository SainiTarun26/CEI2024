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
    public partial class AccidentialHistory_SiteOwner : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                {
                    string LoginId = Convert.ToString(Session["SiteOwnerId"]);
                    BindGrid(LoginId);
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        public void BindGrid(string LoginId)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetAccidential_HistoryForSiteowner(LoginId);
            if (ds.Rows.Count > 0)
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (row == null) return;
            Label AccidentId = (Label)row.FindControl("AccidentId");

            if (e.CommandName == "Select")
            {
                Session["Accident_Id_siteowner"] = "";
                Session["Accident_Id_siteowner"] = AccidentId.Text;
                Response.Redirect("/SiteOwnerPages/Investigation_of_Electrical_Accidents_SiteOwner_History.aspx", false);
            }
            else if (e.CommandName == "Return")
            {
                Session["Accident_IdReturn_siteowner"] = "";
                Session["Accident_IdReturn_siteowner"] = AccidentId.Text;
                Response.Redirect("/SiteOwnerPages/InvestigationOfElectricalAccidents_Return.aspx", false);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblApplicationStatus = (Label)e.Row.FindControl("lblApplicationStatus");
                LinkButton btnResubmit = (LinkButton)e.Row.FindControl("LnkBtnReturn");
                if (lblApplicationStatus.Text == "Return")
                {
                    btnResubmit.Visible = true;
                }
                else
                {
                    btnResubmit.Visible = false;
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    BindGrid(Convert.ToString(Session["SiteOwnerId"]));
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
         try
         {
                if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                {
                    string textsearch = txtSearch.Text.Trim();
                    if (!string.IsNullOrEmpty(textsearch))
                    {
                        DataTable searchResult = new DataTable();
                        searchResult = CEI.SearchAccidentialReports(textsearch, Convert.ToString(Session["SiteOwnerId"]),null);
                        if (searchResult.Rows.Count > 0)
                        {
                            GridView1.DataSource = searchResult;
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        txtSearch.Focus();
                    }
                }
                else
                {

                }
         }
         catch (Exception ex)
         {
                throw;
         }

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
            {
                txtSearch.Text = "";
                BindGrid(Convert.ToString(Session["SiteOwnerId"]));
            }
        }
        
    }
}