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
    public partial class InspectionRequestPrint_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int Inspection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                    {
                        GetDetailstoPrint();
                        BindAttachmentGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Industry/IndustryServices.aspx");
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
            if (Session["InspectionId_Industry"] != null && !string.IsNullOrEmpty(Session["InspectionId_Industry"].ToString()))
            {
                ID = Session["InspectionId_Industry"].ToString();

            }
            else if (Session["PrintInspectionID_Industry"] != null && !string.IsNullOrEmpty(Session["PrintInspectionID_Industry"].ToString()))
            {
                ID = Session["PrintInspectionID_Industry"].ToString();
            }

            if (!string.IsNullOrEmpty(ID))
            {
                DataSet ds = new DataSet();
                ds = CEI.DetailstoPrintFormInspectionDetails(int.Parse(ID));
                txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                txtReqNumber.Text = ID.ToString();
                //txtTestReportNo.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                txtTestReportNo.Text = ds.Tables[0].Rows[0]["TestReportNo"].ToString();
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
                txtSubmissionDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
            }
            //Session["PrintInspectionID_Industry"] = "";
            //Session["InspectionId_Industry"] = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["PrintInspectionID_Industry"] = "";
            Session["InspectionId_Industry"] = "";
            Response.Redirect("/SiteOwnerPages/InspectionHistory_Industry.aspx", false);
        }
    }
}