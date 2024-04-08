using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_forms
{
    public partial class PrintLineTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        GetDetails();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        protected void GetDetails()
        {
            string LoginId = Session["PendingIntimations"].ToString();
            //string   IntimationIds = Session["PendingIntimations"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetSiteOwnerDetails(LoginId);
            txtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();
            txtIntimationId.Text = ds.Tables[0].Rows[0]["WorkIntimationID"].ToString();
            txtPermisestype.Text = ds.Tables[0].Rows[0]["PremisesTypes"].ToString();
            txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
            txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtUTRN.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
            //txtTransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
            DateTime transactionDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["TransctionDate"]);
            string formattedDate = transactionDate.ToString("yyyy-MM-dd");
            txtTransactionDate.Text = formattedDate;
            txtPaymentMode.Text = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
            txtChallan.Text = ds.Tables[0].Rows[0]["ChallanAttachment"].ToString();

        }
    }
}