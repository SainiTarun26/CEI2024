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
        string LoginId = string.Empty;
        string IntimationId = string.Empty;
        string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewBind();
                    if(txtPayment.Text == "0")
                    {
                        btnFinalSubmit.Visible = true;
                        btnSubmit.Visible = false;
                        ChallanUpload.Visible = false;

                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void GridViewBind()
        {
            
            LoginId = Session["SiteOwnerId"].ToString();
            IntimationId = Session["PendingIntimations"].ToString();
            DataSet ds = new DataSet();
            ds = cei.GetPaymentInformation(LoginId, IntimationId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                string script = "alert(\"Please Fill the Form first for knowing Payment History\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
            }
            ds.Dispose();
          string TotalPayment = cei.GetTotalPaymentInformation(LoginId, IntimationId);
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

        protected void ChallanUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/ChallanReport.aspx");
        }

        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {
            id = Session["PendingPaymentId"].ToString();
            string transactionId = string.Empty;
            string transactiondate = string.Empty;
           // CEI.updateInspectionPending(id, transactionId, transactiondate, transactiondate);

        }
    }
}