using CEI_PRoject;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class InspectionRequestPrint_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int Inspection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_IndustryLift"] != null && Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != string.Empty)
                    {
                        string ID = Session["InspectionId_IndustryLift"] as string ?? Session["PrintInspectionID_IndustryLift"] as string;

                        if (!string.IsNullOrEmpty(ID))
                        {
                            GetDetailstoPrint(ID);
                        }
                        else
                        {
                            Session["InspectionId_IndustryLift"] = "";
                            Session["PrintInspectionID_IndustryLift"] = "";
                            Response.Redirect("Industry_Master/SiteOwnerPages/InspectionHistory_New_IndustryLift.aspx", false);
                            return;
                        }
                    }
                    else
                    {
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["InspectionId_IndustryLift"] = "";
                Session["PrintInspectionID_IndustryLift"] = "";
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }

        private void BindAttachmentGrid(string InspID)
        {
            //string GetAttachedDocuments = ID.ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetAttachmentsDatainInspectionForm_IndustryLift(InspID);
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
                //if (Session["InspectionId_IndustryLift"] != null && !string.IsNullOrEmpty(Session["InspectionId_IndustryLift"].ToString()))
                //{
                //    ID = Session["InspectionId_IndustryLift"].ToString();
                //}
                //else if (Session["PrintInspectionID_IndustryLift"] != null && !string.IsNullOrEmpty(Session["PrintInspectionID_IndustryLift"].ToString()))
                //{
                //    ID = Session["PrintInspectionID_IndustryLift"].ToString();
                //}

                //if (!string.IsNullOrEmpty(ID))
                //{
                DataSet ds = new DataSet();
                ds = CEI.DetailstoPrintFormInspectionDetails_IndustryLift(int.Parse(InspectionID));
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
                Session["InspectionId_IndustryLift"] = "";
                Session["PrintInspectionID_IndustryLift"] = "";
                string script = "alert('An error occurred');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["PrintInspectionID_IndustryLift"] = "";
            Session["InspectionId_IndustryLift"] = "";
            Response.Redirect("/Industry_Master/SiteOwnerPages/InspectionHistory_New_IndustryLift.aspx", false);
        }
    }
}