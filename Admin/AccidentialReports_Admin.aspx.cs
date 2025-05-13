using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class AccidentialReports_Admin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {                   
                    BindGrid();
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        public void BindGrid()
        {
            DataTable ds = new DataTable();
            ds = CEI.GetAccidentialReports_forAdmin();
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
                Session["Accident_IDAdmin"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label AccidentId = (Label)row.FindControl("AccidentId");
                Session["Accident_IDAdmin"] = AccidentId.Text;
                Response.Redirect("/Admin/Investigation_of_Electrical_Accidents_officer_Admin.aspx", false);

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {               
                    GridView1.PageIndex = e.NewPageIndex;
                    BindGrid();
                         
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

                string textsearch = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(textsearch))
                {
                    DataTable searchResult = new DataTable();
                    searchResult = CEI.SearchAccidentialReports(textsearch, null, null);
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
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindGrid();
        }
    }
}