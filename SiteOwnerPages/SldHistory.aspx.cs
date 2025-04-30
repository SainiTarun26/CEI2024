using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SldHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["SiteOwnerId"] != null)
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
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldHistory(LoginID, searchText);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"Yet no SLD is uploaded.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
            if (e.CommandName == "Print")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();
                string RequestLetter = DataBinder.Eval(e.Row.DataItem, "RequestLetter").ToString();
                LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton Lnkbtn = (LinkButton)e.Row.FindControl("Lnkbtn");

                linkButton1.Visible = true;
                if (status == "Approved")
                {
                    // linkButton1.Visible = false;
                    lnkDocumemtPath.Visible = true;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lnkDocumemtPath.Visible = false;
                }
                if (RequestLetter != null && RequestLetter != "")
                {
                    Lnkbtn.Visible = true;
                }
                else
                {
                    Lnkbtn.Visible = false;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }

      
    }
}