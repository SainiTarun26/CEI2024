using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class ViewPerodicRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                       
                        //if (Session["SiteOwnerId"].ToString() != "JVCBN5647K")
                        //{
                        //    //Session["SiteOwnerId"] = "JVCBN5647K";
                        //}

                      
                        if (Session["CartID"] != null)
                        {
                            string CartID = Session["CartID"].ToString();
                            BindGrid(); 
                        }
                     
                    }
                }
            }
            catch
            {
            }

        }
        public void BindGrid()
        {

            string CartID = Session["CartID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.ViewInspection(CartID);
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblInspectionId = (Label)row.FindControl("lblInspectionId");
            Session["InspectionIdNew"] = lblInspectionId.Text;
            if (e.CommandName == "Print")
            {
                Response.Redirect("/Periodic_Industry/Print_PeriodicIndustry.aspx");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Periodic_Industry/RenewalPerodicIndustry.aspx", false);
        }
    }
}