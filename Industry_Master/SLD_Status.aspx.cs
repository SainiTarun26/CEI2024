using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class SLD_Status : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty)
                {
                    BindGrid();

                }
                else
                {

                }
            }

        }
        public void BindGrid(string searchText = null)
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_Sld_Indus"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldHistory(LoginID, searchText);
            if (ds.Rows.Count > 0)
            {
                GridView.DataSource = ds;
                GridView.DataBind();
            }
            else
            {
                GridView.DataSource = null;
                GridView.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

      

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = TxtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                BindGrid(searchText);
            }
            else
            {
                BindGrid();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Select1")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

                LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");

                if (status == "Approved" || status == "Rejected")
                {
                    linkButton1.Visible = false;
                    lnkDocumemtPath.Visible = true;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    linkButton1.Visible = true;
                    lnkDocumemtPath.Visible = false;
                }
            }
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            { }
        }
    }
}