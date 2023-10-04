using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.Contractor
{

    public partial class TestReportHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridData();
            }
        }

        protected void GridData() {
            string LoginID = string.Empty;
            LoginID = Session["ContractorID"].ToString();
            DataTable ds = new DataTable();
        ds = CEI.LineTestReportData(LoginID);
            if (ds.Rows.Count > 0)
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