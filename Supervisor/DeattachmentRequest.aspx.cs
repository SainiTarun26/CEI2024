using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Supervisor
{
    public partial class DeattachmentRequest : System.Web.UI.Page
    {
        //Page created y Neeraj on 23-June-2025
        CEI CEI = new CEI();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Renwal"]) != "" && Convert.ToString(Session["Renwal"]) != null)
            {
                this.Page.MasterPageFile = "~/Supervisor/Supervisor_Renewal.Master";

                Session["double_Clickbutton"] = "1";
            }
            else
            {
                this.Page.MasterPageFile = "~/Supervisor/Supervisor.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != string.Empty)
                    {
                        hdnId.Value = Session["SupervisorID"].ToString();
                        GridBind(hdnId.Value);


                    }
                    else
                    {
                        Session["SupervisorID"] = "";
                        Response.Redirect("/SupervisorLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        public void GridBind(string SupervisiorId)
        {
            try
            {
              
                DataTable ds = new DataTable();
                ds = CEI.GetSupervisiorRequest(SupervisiorId);
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No any Request For Attachment-DeAttachment.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Label lblRequestFor = (Label)row.FindControl("lblRequestFor");

            if (e.CommandName == "Select")
            {
                if (lblRequestFor.Text == "DeAttached")
                {
                    Session["Id"] = lblID.Text;
                    Response.Redirect("/Supervisor/DeAttachedRequestView.aspx", false);
                }
                else if(lblRequestFor.Text == "Attached")
                {
                    Session["Id"] = lblID.Text;
                    Response.Redirect("/Supervisor/AttachedRequestViewDetails.aspx", false);
                }
            }
          
        }
    }
}