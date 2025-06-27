using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class ReSubmitContractorDocuments : System.Web.UI.Page
    {
        //Created By Neeraj 27-June-2025
        CEI CEI = new CEI();
        string Category;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    Session["ContractorID"] = "Nist19930504";
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        hdnContractorId.Value = Session["ContractorID"].ToString();
                        hdnCategory.Value = "Contractor";
                        bindData(hdnContractorId.Value, hdnCategory.Value);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }


        }
        public void bindData(string Id, string Category)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentForWiremanSupervisior(Id, Category);
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

        }
    }
}