using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Contractor
{
    public partial class ConractorUpgradationHistory : System.Web.UI.Page
    {
        //page created by Neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Contractor / Upgradation Licence Application History";
                    }
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        string Id = Session["ContractorID"].ToString();
                        GridToBindData(Id);
                    }
                    else
                    {
                        Session["ContractorID"] = "";
                        Response.Redirect("/ContractorLogout.aspx");
                    }
                }
            }
            catch
            {
                Session["ContractorID"] = "";
                Response.Redirect("/ContractorLogout.aspx");
            }
        }

        private void GridToBindData(string id)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetDataOfUpgradationRequestForContractor(id);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"There is no application Applied for Licence Upgradation.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                if (e.CommandName == "Print")
                {
                    
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["id"] = lblID.Text;
                    Response.Redirect("/Print_Forms/Print_Contractor_Upgradation_Details.aspx", false);
                   
                }
                else if (e.CommandName == "Select")
                {
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["id"] = lblID.Text;
                    Response.Redirect("/UserPages/Contractor_Upgradation.aspx", false);
                    
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "aleert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}