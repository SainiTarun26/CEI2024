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
    public partial class XenInspectioHistrory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null || Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["AdminId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InProcessRequest(LoginID);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            ds.Dispose();
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
                    string id = lblID.Text;
                    Session["InProcessInspectionId"] = id;
                    if (e.CommandName == "Select")
                    {
                        Response.Redirect("/Admin/ActionInprocessInspection.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }
    }
}