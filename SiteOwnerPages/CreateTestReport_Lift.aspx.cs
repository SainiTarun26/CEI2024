using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class CreateTestReport_Lift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string siteownerId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        siteownerId = Convert.ToString(Session["SiteOwnerId"]);
                        getWorkIntimationData(siteownerId);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 6;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }

                }
            }
            catch { }
        }
        private void getWorkIntimationData(string siteownerId)
        {
           
            DataSet ds = new DataSet();
            ds = CEI.SiteIntimations_forLift(siteownerId);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            ds.Dispose();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData(siteownerId);
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
                    Label LblTypeOfInstallation = (Label)row.FindControl("LblTypeOfInstallation");
                    Session["IntimationId_LiftEscalator"] = lblID.Text;                   
                    Session["Duplicacy"] = "0";
                    Session["TotalAmount"] = "0";
                    Response.Redirect("/SiteOwnerPages/GenerateInspection_Lift.aspx", false);
                                    
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}