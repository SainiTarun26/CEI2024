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
            Control ctrl = e.CommandSource as Control;

            if (ctrl != null)
            {
                GridViewRow row = ctrl.NamingContainer as GridViewRow;

                if (row != null)
                {
                    Label lblID = row.FindControl("lblID") as Label;
                    Label lblCategory = row.FindControl("lblCategory") as Label;

                    if (lblID == null || lblCategory == null)
                        return;

                    string idValue = lblID.Text.Trim();
                    string category = lblCategory.Text.Trim();

                    if (e.CommandName == "ViewUser")
                    {
                        if (category == "Supervisor" || category == "Wireman")
                        {
                            Session["NewApplicationRegistrationNo"] = idValue;
                            Response.Redirect("~/Print_Forms/Print_New_Registration_Information");
                        }
                        else if (category == "Contractor")
                        {
                            Session["NewApplication_Contractor_RegNo"] = idValue;
                            Response.Redirect("~/Print_Forms/Print_New_Registration_Information_Contractor.aspx");
                        }
                        
                    }
                    else if (e.CommandName == "ViewDetails")
                    {
                        if (category == "Supervisor" || category == "Wireman")
                        {
                            Session["NewApplicationRegistrationNo"] = idValue;
                            Response.Redirect("~/UserPages/New_Registration_Information.aspx");
                        }
                        else if (category == "Contractor")
                        {
                            Session["NewApplication_Contractor_RegNo"] = idValue;
                            Response.Redirect("~/UserPages/New_Registration_Information_Contractor.aspx");
                        }
                    }
                }
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
