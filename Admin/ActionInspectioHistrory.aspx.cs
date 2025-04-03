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
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("/AdminLogout.aspx");
            }
        }
        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InProcessRequest(LoginID);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                ds.Dispose();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
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
                    Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                    Label lblInspectionCount = (Label)row.FindControl("lblInspectionCount");                  
                    string id = lblID.Text;                   
                    if (e.CommandName == "Select")
                    {
                        if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                        {
                            if (int.TryParse(lblInspectionCount.Text, out int count) && count > 1)
                            {
                                Session["InProcessInspectionId"] = id;
                                Response.Redirect("/Admin/Action_InProcessLift_Return.aspx", false);
                                return;

                            }
                            else
                            {
                                Session["InProcessInspectionId"] = id;
                                Response.Redirect("/Admin/Action_InProcess_Lift.aspx", false);
                                return;
                            }
                        }
                        else
                        {
                            Session["InProcessInspectionId"] = id;
                            Response.Redirect("/Admin/ActionInprocessInspection.aspx", false);
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch(Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }
        }
    }
}