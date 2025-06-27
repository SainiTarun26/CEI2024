using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class New_Application_Status : System.Web.UI.Page
    {

        // Created by neha on 27-June-2025
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        string UserID = Session["ContractorID"].ToString();
                        BindGridData(UserID);
                    }
                    else if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        string UserID = Session["SupervisorID"].ToString();
                        BindGridData(UserID);
                    }
                    else if(Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        string UserID = Session["WiremanId"].ToString();
                        BindGridData(UserID);
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void BindGridData(string UserID)
        {
            DataTable dt = CEI.GetUserGridData(UserID);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewUser")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                //string id = lblID.Text;
                Session["RegisteredUserId"] = lblID.Text;

                Response.Redirect("~/Print_Forms/Print_Certificate_Competency_Wireman_Permit.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/Login.aspx");
        }
    }
}
