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
    public partial class PeriodicApprovalCertificate : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                {
                    GetData();
                }
                else if (Session["SiteOwnerId"] != null)
                {
                    GetData();
                }



            }

        }
        public void GetData()
        {
            try
            {

                if (Session["InProcessInspectionId"] != null)
                {
                    ID = Session["InProcessInspectionId"].ToString();
                }
                else if (Session["InspectionId"] != null)
                {
                    ID = Session["InspectionId"].ToString();

                }
                DataSet ds = new DataSet();
                ds = CEI.PrintApprovalLetter(ID);
                lblAddress1.Text = ds.Tables[1].Rows[0]["Header1"].ToString();
                lblAdress2.Text = ds.Tables[1].Rows[0]["Header2"].ToString();
                lblAdress3.Text = ds.Tables[1].Rows[0]["Header3"].ToString();
                lblAdress4.Text = ds.Tables[1].Rows[0]["Header4"].ToString();
                TxtName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                TextAdress.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                TextLocation.Text = ds.Tables[0].Rows[0]["CompleteAdress"].ToString();
                txtApplicationNo.Text = ds.Tables[1].Rows[0]["ReferenceNo"].ToString();
                txtCreatedDate.Text = ds.Tables[1].Rows[0]["CreatedDate"].ToString();
                TxtMemo.Text = ds.Tables[2].Rows[1]["MemoNo"].ToString();
                TxtMemoDate.Text = ds.Tables[1].Rows[0]["ApprovedDate"].ToString();
               
                lblVoltage.Text = ds.Tables[2].Rows[0]["InstallationDetails"].ToString();
                Year.Text = ds.Tables[1].Rows[0]["ApprovedYear"].ToString();
              
                lblstamp1.Text = ds.Tables[1].Rows[0]["Stamp1"].ToString();
                lblstamp2.Text = ds.Tables[1].Rows[0]["Stamp2"].ToString();
                lblstamp3.Text = ds.Tables[1].Rows[0]["Stamp3"].ToString();
                GridBind();
            }
            catch { }
        }

        protected void GridBind()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds.Tables.Count > 0)
                {
                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

    }
}