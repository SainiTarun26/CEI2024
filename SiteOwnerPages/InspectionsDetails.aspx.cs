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
               
            }
        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.NewRequestRecieved(LoginID);
            if (ds.Tables.Count > 0 && ds != null)
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
}