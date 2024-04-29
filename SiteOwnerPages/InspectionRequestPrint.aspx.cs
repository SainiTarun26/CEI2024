using CEI_PRoject;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{

    public partial class InspectionRequestPrint : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int Inspection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        GetDetailstoPrint();
                        BindAttachmentGrid();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void BindAttachmentGrid()
        {
            string GetAttachedDocuments = ID.ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetAttachmentsDatainInspectionForm(GetAttachedDocuments);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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

        private void GetDetailstoPrint()
        {
            if (Session["InspectionId"] != null && !string.IsNullOrEmpty(Session["InspectionId"].ToString()))
            {
                ID = Session["InspectionId"].ToString();
               
            }
            else if (Session["PrintInspectionID"] != null && !string.IsNullOrEmpty(Session["PrintInspectionID"].ToString()))
            {
                ID = Session["PrintInspectionID"].ToString();
            }

            if (!string.IsNullOrEmpty(ID))
            {
                DataSet ds = new DataSet();
                ds = CEI.DetailstoPrintFormInspectionDetails(int.Parse(ID));
                txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                txtReqNumber.Text = ID.ToString();
                txtTestReportNo.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();
                txtIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                txtPermisestype.Text = ds.Tables[0].Rows[0]["PremisesTypes"].ToString();
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtUTRN.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txtTransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
                txtPaymentMode.Text = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                txtPaymentAmount.Text = ds.Tables[0].Rows[0]["PaymentAmount"].ToString();
             }
            Session["PrintInspectionID"] = "";
            Session["InspectionId"] = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);           
        }
    }
}