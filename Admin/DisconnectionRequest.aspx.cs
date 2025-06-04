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
    public partial class DisconnectionRequest : System.Web.UI.Page
    {
        //Page created by neeraj 29-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {

                        hnOwnerId.Value = Session["AdminId"].ToString();
                        GridBind();

                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }
        public void GridBind()
        {
            try
            {
                DataTable dt = CEI.GetDisconnectionRequest();
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No any request submitted for disconnection yet.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Convert.ToString(hnOwnerId.Value) == Convert.ToString(Session["AdminId"]))
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                if (e.CommandName == "Select")
                {
                   
                        Session["Dis_Id"] = lblID.Text;
                        Response.Redirect("/Admin/DisconnectionSupplyView.aspx", false);
                    
                }
            }
            else
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);

            }
        }
    }
}