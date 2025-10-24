using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class Supervisor_Requests : System.Web.UI.Page
    {
        //Page created by 30-June-2025
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != null)
                    {
                        RequestForDeattachment_Attachments(Convert.ToString(Session["ContractorID"]));
                        getAlreadyActionData(Convert.ToString(Session["ContractorID"]));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void RequestForDeattachment_Attachments(string ContractorId)
        {           
            DataSet ds = new DataSet();
            ds = cei.GetSupervisorRequestForDeattachment_Attachments(ContractorId);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                Requests_Card.Visible = true;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                Requests_Card.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }



        private void getAlreadyActionData(string ContractorId)
        {
            DataSet ds = new DataSet();
            ds = cei.GetSupervisorRequestForDeattachment_AttachmentHistroy(ContractorId);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                Histry_Card.Visible = true;
                grdview_Actioned.DataSource = ds;
                grdview_Actioned.DataBind();
            }
            else
            {
                Histry_Card.Visible = false;
                grdview_Actioned.DataSource = null;
                grdview_Actioned.DataBind();              
            }
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
                    Label lblRequestID = (Label)row.FindControl("lblRequestID");                   
                    Session["SupervisorRequestId_Deattachment"] = lblRequestID.Text.Trim();
                    Response.Redirect("/Contractor/Deattatch_Supervisor.aspx", false);
                }
            }
            catch { }
        }
    }
}