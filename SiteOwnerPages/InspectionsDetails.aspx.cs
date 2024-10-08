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
    public partial class InspectionsDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        string ApplicationStatus = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null || Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    GridBind();
                }
                else
                {
                    Response.Redirect("/Login.aspx", false);
                }
            }
        }
        public void GridBind()
        {
            if (Request.QueryString["parameter"].ToString() != null && Request.QueryString["parameter"].ToString() != "")
            {
                ApplicationStatus = Request.QueryString["parameter"].ToString();
                if (ApplicationStatus=="Approved")
                {
                    GridView1.Columns[8].Visible = true;
                }               
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.SiteOwnerDashbordCapsule(LoginId, ApplicationStatus);
                if (ds.Tables.Count > 0 && ds != null && ds.Tables[0].Rows.Count>0)
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
        }
        public void GridBindSearch(string searchText)
        {
            if (Request.QueryString["parameter"].ToString() != null && Request.QueryString["parameter"].ToString() != "")
            {
                ApplicationStatus = Request.QueryString["parameter"].ToString();
                if (ApplicationStatus == "Approved")
                {
                    GridView1.Columns[8].Visible = true;
                }
                LoginId = Session["SiteOwnerId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.SiteOwnerDashbordCapsuleSearch(LoginId, ApplicationStatus, searchText);
                if (ds.Tables.Count > 0 && ds != null && ds.Tables[0].Rows.Count > 0)
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
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch (Exception ex)
            {

                //throw;
            }
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select" || e.CommandName == "Print1")
            {
                Session["LineID"] = "";
                Session["SubStationID"] = "";
                Session["GeneratingSetId"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspectionId"] = lblID.Text;                
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/SiteOwnerPages/Inspection.aspx");
                }               
                else if (e.CommandName == "Print1")
                {
                    Response.Redirect("/Print_Forms/PrintCertificate1.aspx");
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                GridBindSearch(searchText);
            }
            else
            {
                GridBind();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            GridBind();
        }

    }
}