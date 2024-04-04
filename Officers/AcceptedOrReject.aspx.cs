using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class AcceptedOrReject : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }

        }
        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["StaffID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.AcceptOrReject(LoginID);

                GridView1.DataSource = ds;
                GridView1.DataBind();

                ds.Dispose();
            }
            catch (Exception ex)
            {

               // throw;
            }

           
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
                    //Label lblApproval = (Label)row.FindControl("lblApproval");
                    //Session["Approval"] = lblApproval.Text.Trim();
                    if (e.CommandName == "Select")
                    {
                        Response.Redirect("/Officers/InProcessInspection.aspx", false);

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

        }
    }
}