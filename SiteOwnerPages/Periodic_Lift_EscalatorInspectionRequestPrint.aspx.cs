﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Periodic_Lift_EscalatorInspectionRequestPrint : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        // private static int Inspection;
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
            catch (Exception ex)
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void BindAttachmentGrid()
        {
            string GetAttachedDocuments = ID.ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetAttachmentsDatainInspectionForm(GetAttachedDocuments);
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                statements.Visible = false;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                statements.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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

                ds = CEI.PeriodicLiftDetailstoPrintFormInspectionDetails(int.Parse(ID));

                txtInstallationType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                txtReqNumber.Text = ID.ToString();
                txtTestReportNo.Text = ds.Tables[0].Rows[0]["TestReportNo"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();

                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtUTRN.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txtTransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();
                txtPaymentMode.Text = ds.Tables[0].Rows[0]["PaymentMode"].ToString();
                txtPaymentAmount.Text = ds.Tables[0].Rows[0]["PaymentAmount"].ToString();

                decimal paymentAmount;
                if (decimal.TryParse(txtPaymentAmount.Text, out paymentAmount) && paymentAmount == 0)
                {
                    PaymentAmount.Visible = false;
                    PaymentMode.Visible = false;
                    TransactionDate.Visible = false;
                    TransactionID.Visible = false;
                }
                else
                {
                    PaymentAmount.Visible = true;
                    PaymentMode.Visible = true;
                    TransactionDate.Visible = true;
                    TransactionID.Visible = true;
                }

                txtSubmissionDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["InspectionId"] != null && Session["InspectionId"].ToString() != "")
            {
                Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
            }
            else if (Session["PrintInspectionID"] != null && Session["PrintInspectionID"].ToString() != "")
            {
                Response.Redirect("/SiteOwnerPages/LiftPeriodic.aspx", false);
            }


            Session["PrintInspectionID"] = "";
            Session["InspectionId"] = "";
        }
    }
}