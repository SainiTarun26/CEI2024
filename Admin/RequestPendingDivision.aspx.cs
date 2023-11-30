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
    public partial class RequestPendingDivision : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                DataTable ds = new DataTable();
                ds = cei.RequestPendingDivision();
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    string script = "alert(\"No Data Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), " script", script, true);
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        //private void GridViewBind()
        //{
        //    DataSet ds = new DataSet();


        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Session["Id"] = string.Empty;
            string Id = string.Empty;
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

            if (e.CommandName == "15Days")
            {
                Label lbl15Days = (Label)row.FindControl("lblCreatedDate15Days");
                Id = lbl15Days.Text;
            }
            else if (e.CommandName == "Select15to30Days")
            {
                Label lbl15to30Days = (Label)row.FindControl("lblCreatedDate15to30Days");
                Id = lbl15to30Days.Text;
            }
            else if (e.CommandName == "Select30to45Days")
            {
                Label lbl30to30Days = (Label)row.FindControl("lblCreatedDate30to45Days");
                Id = lbl30to30Days.Text;
            }
            else
            {
                Label lblMoreThan45Days = (Label)row.FindControl("lblCreatedDateMoreThan45Days");
                Id = lblMoreThan45Days.Text;
            }
            Session["CreatedDate"] = Id;
            Response.Redirect("/Admin/SubstationDataHistory.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}