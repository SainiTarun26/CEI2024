using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Print_Forms
{
    public partial class PrintCertificate1 : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                        {
                            GetData();
                        }
                        else if (Session["SiteOwnerId"] != null)
                        {
                            GetData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/Login.aspx");
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

                    DataSet ds = new DataSet();
                    ds = CEI.PrintSubstrationTransformer(ID);
                    TxtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();
                    TextAdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    string locationValue = ds.Tables[0].Rows[0]["location"].ToString();
                    string Location = "dist - " + locationValue;
                    TextLocation.Text = Location;
                    TxtMemo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                    //TxtDate.Text= ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                    DateTime createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApprovedDate"]);
                    TxtDate.Text = createdDate.ToString("dd/MM/yyyy");
                    lblCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();

                    lblType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    TxtReferenceNo.Text = ds.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    //LblDate.Text= ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    //LblDate.Text = finaldate.ToString("dd/MM/yyyy");
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["InspectionDate"].ToString()))
                    {
                        LblDate.Visible = false;
                    }
                    else
                    {
                        DateTime createdDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectionDate"]);
                        LblDate.Text = createdDate1.ToString("dd/MM/yyyy");
                        LblDate.Visible = true;
                    }
                    txtSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                    LblMonth.Text = ds.Tables[0].Rows[0]["FinalMonth"].ToString();
                    string script = "<script type=\"text/javascript\">printDiv('printableDiv');</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintOnLoad", script, false);

                }
                else if (Session["InspectionId"] != null)
                {
                    ID = Session["InspectionId"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.PrintSubstrationTransformer(ID);
                    TxtName.Text = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();
                    TextAdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    string locationValue = ds.Tables[0].Rows[0]["location"].ToString();
                    string Location = "dist - " + locationValue;
                    TextLocation.Text = Location;
                    TxtMemo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();

                    DateTime createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApprovedDate"]);
                    TxtDate.Text = createdDate.ToString("dd/MM/yyyy");
                    lblCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();

                    lblType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    TxtReferenceNo.Text = ds.Tables[0].Rows[0]["ReferenceNo"].ToString();

                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["InspectionDate"].ToString()))
                    {
                        LblDate.Visible = false;
                    }
                    else
                    {
                        DateTime createdDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectionDate"]);
                        LblDate.Text = createdDate1.ToString("dd/MM/yyyy");
                        LblDate.Visible = true;
                    }
                    //txtSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                    txtSuggestion.Text= ds.Tables[0].Rows[0]["Suggestion"].ToString();
                    LblMonth.Text = ds.Tables[0].Rows[0]["FinalMonth"].ToString();
                    string script = "<script type=\"text/javascript\">printDiv('printableDiv');</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintOnLoad", script, false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/InProcessInspection.aspx", false);
        }
    }
}