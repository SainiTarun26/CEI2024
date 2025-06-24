using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class ContractorLicenceRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  Session["Application_Id"] = "App-101";
                if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                {
                    hdnApplicationId.Value = Session["Application_Id"].ToString();
                    GetData(hdnApplicationId.Value);
                    GridData(hdnApplicationId.Value);
                    GetPatnersDetails();
                    GetSupervisiorWiremanDetails();
                }

            }
        }
        public void GetData(string ApplicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetCertificateDataCon_Sup_Wir(ApplicationId);
                if (dt.Rows.Count > 0)
                {
                    lblRegistationId.Text = dt.Rows[0]["RegistationId"].ToString();
                    lblCertificateNo.Text = dt.Rows[0]["CertificateNo"].ToString();
                    lblName.Text = dt.Rows[0]["Name"].ToString();
                    lblApprovedDate.Text = dt.Rows[0]["ApprovedDate"].ToString();
                    Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void GetPatnersDetails()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetPatnersDetails(lblRegistationId.Text);
            if (dt.Rows.Count > 0)
                lblPatner1.Text = dt.Rows[0]["Name"].ToString();

            if (dt.Rows.Count > 1)
                lblPatner2.Text = dt.Rows[1]["Name"].ToString();

            if (dt.Rows.Count > 2)
                lblPatner3.Text = dt.Rows[2]["Name"].ToString();

            if (dt.Rows.Count > 3)
                lblPatner4.Text = dt.Rows[3]["Name"].ToString();

            if (dt.Rows.Count > 4)
                lblPatner5.Text = dt.Rows[4]["Name"].ToString();
        }
        public void GetSupervisiorWiremanDetails()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetSupWiremanDetails(lblRegistationId.Text);
            if (dt.Rows.Count > 0)
            {
                lblSup1.Text = dt.Rows[0]["Name"].ToString();
            }
            if (dt.Rows.Count > 1)
            {
                lblSup2.Text = dt.Rows[1]["Name"].ToString();
            }
            if (dt.Rows.Count > 2)
            {
                lblSup3.Text = dt.Rows[2]["Name"].ToString();
            }
            if (dt.Rows.Count > 3)
            {
                lblSup4.Text = dt.Rows[3]["Name"].ToString();
            }
            if (dt.Rows.Count > 4)
            {
                lblSup5.Text = dt.Rows[4]["Name"].ToString();
            }
        }
        public void GridData(string ApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.getDataLicence(ApplicationId);
                if (ds.Tables.Count > 0)
                {
                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
    }
}