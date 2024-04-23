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
            catch
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void BindAttachmentGrid()
        {
            string InspectionId = string.Empty;
            InspectionId = Session["InspectionId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.GetAttachmentsDatainInspectionForm(InspectionId);
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

        private void GetDetailstoPrint()
        {
            ID = Session["PrintInspectionID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.DetailstoPrintFormInspectionDetails(int.Parse(ID));
            txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
            txtReqNumber.Text = Session["PrintInspectionID"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
            txtIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
            txtPermisestype.Text = ds.Tables[0].Rows[0]["PremisesTypes"].ToString();
            txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
            txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtUTRN.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
            txtTransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
            txtPaymentMode.Text = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
            Inspection = (int)ds.Tables[0].Rows[0]["Id"];
            Session["InspectionId"] = Inspection;
        }
    }
}