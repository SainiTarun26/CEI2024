using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.Officers
{
    public partial class AccidentialReports : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                {
                    string LoginId = Convert.ToString(Session["StaffID"]);
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
            ds = CEI.GetAccidentialReports_forOfficer(LoginId);
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

            if (e.CommandName == "Select")
            {               
                Session["Accident_ID"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label AccidentId = (Label)row.FindControl("AccidentId");
                Session["Accident_ID"] = AccidentId.Text;
                Response.Redirect("/Officers/Investigation_of_Electrical_Accidents_officer.aspx", false);

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
               
                if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    BindGrid(Convert.ToString(Session["StaffID"]));
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
                if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                {
                    string textsearch = txtSearch.Text.Trim();
                    if (!string.IsNullOrEmpty(textsearch))
                    {
                        DataTable searchResult = new DataTable();
                        searchResult = CEI.SearchAccidentialReports(textsearch, null, Convert.ToString(Session["StaffID"]));
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
            if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
            {
                txtSearch.Text = "";
                BindGrid(Convert.ToString(Session["StaffID"]));
            }
        }
    }
}