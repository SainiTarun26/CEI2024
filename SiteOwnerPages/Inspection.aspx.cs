using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Inspection : System.Web.UI.Page
    {
        CEI Cei = new CEI();
        string Id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                GetDetailsWithId();
                Visibilty();
            }


        }


        public void Visibilty()
        {
            Uploads.Visible = true;

            if (Session["Approvel"].ToString() == "Pending" || Session["Approvel"].ToString() == "Accept")
            {
                btnBack.Visible = true;
                txtApplicantType.ReadOnly = false;
                txtPremises.ReadOnly = false;
                txtVoltage.ReadOnly = false;
                txtWorkType.ReadOnly = false;
            }
            else
            {
                btnSubmit.Visible = true;
            }
        }

        public void GetDetailsWithId()
        {
            Id = Session["InspectionId"].ToString();

            DataSet ds = new DataSet();
            ds = Cei.InspectionData(Id);

            txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
            txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
            txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
            txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();



        }

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {

        }

        protected void lnkDocument_Click(object sender, EventArgs e)
        {

        }

        protected void lnkLetter_Click(object sender, EventArgs e)
        {

        }

        protected void lnktest_Click(object sender, EventArgs e)
        {

        }

        protected void lnkDiag_Click(object sender, EventArgs e)
        {

        }

        protected void lnkCopy_Click(object sender, EventArgs e)
        {

        }

        protected void lnkInvoiceTransformer_Click(object sender, EventArgs e)
        {

        }

        protected void lnkManufacturing_Click(object sender, EventArgs e)
        {

        }

        protected void lnkSingleDiag_Click(object sender, EventArgs e)
        {

        }

        protected void lnkInvoiceFire_Click(object sender, EventArgs e)
        {

        }

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx");
        }
    }
}