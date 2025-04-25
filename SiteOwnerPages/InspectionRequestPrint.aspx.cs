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
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
                    {
                        //string siteOwnerId = Session["SiteOwnerId"] as string;
                        string ID = Session["InspectionId"] as string ?? Session["PrintInspectionID"] as string;

                        if (!string.IsNullOrEmpty(ID))
                        {
                            GetDetailstoPrint(ID);
                        }
                        else
                        {
                            Session["InspectionId"] = "";
                            Session["PrintInspectionID"] = "";
                            Response.Redirect("SiteOwnerPages/InspectionHistory.aspx", false);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("SiteOwnerPages/CreateTestReports.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["InspectionId"] = "";
                Session["PrintInspectionID"] = "";
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }

        private void BindAttachmentGrid(string InspID)
        {
            //string GetAttachedDocuments = ID.ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetAttachmentsDatainInspectionForm(InspID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                statement.Visible = false;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                statement.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        private void GetDetailstoPrint(string InspectionID)
        {
            try
            {
                //if (Session["InspectionId"] != null && !string.IsNullOrEmpty(Session["InspectionId"].ToString()))
                //{
                //    ID = Session["InspectionId"].ToString();
                //}
                //else if (Session["PrintInspectionID"] != null && !string.IsNullOrEmpty(Session["PrintInspectionID"].ToString()))
                //{
                //    ID = Session["PrintInspectionID"].ToString();
                //}

                //if (!string.IsNullOrEmpty(ID))
                //{
                DataSet ds = new DataSet();
                ds = CEI.DetailstoPrintFormInspectionDetails(int.Parse(InspectionID));
                txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                txtReqNumber.Text = InspectionID.ToString();
                txtTestReportNo.Text = ds.Tables[0].Rows[0]["TestReportNo"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();
                txtIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                txtPermisestype.Text = ds.Tables[0].Rows[0]["PremisesTypes"].ToString();
                if (string.IsNullOrEmpty(txtPermisestype.Text))
                {
                    Premises.Visible = false;
                }
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtUTRN.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txtTransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
                txtPaymentMode.Text = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                txtPaymentAmount.Text = ds.Tables[0].Rows[0]["PaymentAmount"].ToString();
                txtSubmissionDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                txtRTSDueDate.Text = ds.Tables[0].Rows[0]["RTSDueDate"].ToString();

                BindAttachmentGrid(InspectionID);
            }
            catch (Exception ex)
            {
                Session["InspectionId"] = "";
                Session["PrintInspectionID"] = "";
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["PrintInspectionID"] = "";
            Session["InspectionId"] = "";
            Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
        }
    }
}