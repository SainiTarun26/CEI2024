using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewBind();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void GridViewBind()
        {
            string LoginId = string.Empty;
            LoginId = Session["SiteOwnerId"].ToString(); 
            DataSet ds = new DataSet();
            ds = cei.GetPaymentInformation(LoginId);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
            }
            ds.Dispose();
          string TotalPayment = cei.GetTotalPaymentInformation(LoginId);
            txtPayment.Text = TotalPayment;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

     

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch
            {

            }
        }
    }
}