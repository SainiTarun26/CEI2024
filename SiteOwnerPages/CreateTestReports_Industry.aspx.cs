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
    public partial class CreateTestReports_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                    {
                        getWorkIntimationData();
                    }
                }
            }
            catch
            {
                Response.Redirect("/Industry/IndustryServices.aspx");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{

                //    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                //    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                //}

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
            catch { }
        }
        private void getWorkIntimationData()
        {
            string Id = Session["SiteOwnerId_Industry"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.TestReportData_Industry(Id);
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
                    Session["id_Industry"] = lblID.Text;
                    Response.Redirect("/SiteOwnerPages/GenerateInspection_Industry.aspx", false);
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }
    }
}