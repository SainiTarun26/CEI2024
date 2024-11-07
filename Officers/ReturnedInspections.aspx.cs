using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
	public partial class ReturnedInspections : System.Web.UI.Page
	{
        CEI CEI = new CEI();
        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        string Type = string.Empty;
        string InstallType = string.Empty;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                  //  GetData();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }

        }

        //public void GetData()
        //{
        //    try
        //    {
        //        ID = Session["InspectionId"].ToString();

        //        DataSet ds = new DataSet();
        //        ds = CEI.InspectionData(ID);
        //        Type = ds.Tables[0].Rows[0]["IType"].ToString();

        //        if (Type == "New")
        //        {
        //            txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
        //            txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
        //            txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
        //            txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
        //            if (txtWorkType.Text == "Line")
        //            {
        //                Capacity.Visible = false;
        //                LineVoltage.Visible = true;
        //                txtLineVoltage.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
        //            }
        //            else
        //            {
        //                LineVoltage.Visible = false;
        //                Capacity.Visible = true;
        //                txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
        //            }
        //            txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
        //            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
        //            txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
        //            txtSiteOwnerContact.Text = ds.Tables[0].Rows[0]["SiteownerContactNumber"].ToString();
        //            txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
        //            txtContractorPhoneNo.Text = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();

        //            txtContractorEmail.Text = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();
        //            txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
        //            txtSupervisorEmail.Text = ds.Tables[0].Rows[0]["SupervisorEmail"].ToString();
        //            txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
        //            txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
        //            txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
        //            // txtInspectionRemark.Text = ds.Tables[0].Rows[0]["InspectionRemarks"].ToString();
        //            txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
        //            //count = Convert.ToInt32(ds.Tables[0].Rows[0]["TestReportCount"].ToString());           //Added     
        //            IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();

        //            GridBindDocument();

        //            DivViewTRinMultipleCaseNew.Visible = true;
        //            GridToViewTRinMultipleCaseNew();

        //            string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

        //            if (Status.Trim() == "InProcess")
        //            {
        //                RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("0"));
        //                RadioButtonList2.Attributes.Add("disabled", "true");
        //                RadioButtonList2.Enabled = false;
        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //            else if (Status.Trim() == "Return")
        //            {
        //                RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("1"));
        //                RadioButtonList2.Attributes.Add("disabled", "true");
        //                RadioButtonList2.Enabled = false;
        //                Rejection.Visible = true;
        //                txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
        //                txtRejected.Attributes.Add("disabled", "true");

        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //            else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
        //            {
        //                RadioButtonList2.Enabled = false;
        //                txtRejected.Attributes.Add("disabled", "true");
        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //        }
        //        else if (Type == "Periodic")
        //        {
        //            txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
        //            txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
        //            txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
        //            txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
        //            txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
        //            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
        //            txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
        //            txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
        //            txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
        //            PermisesType.Visible = false;
        //            LineVoltage.Visible = false;
        //            ContractorName.Visible = false;
        //            ContractorPhoneNo.Visible = false;
        //            ContractorEmail.Visible = false;
        //            SupervisorName.Visible = false;
        //            SupervisorEmail.Visible = false;
        //            SiteOwnerContact.Visible = false;
        //            OwnerAddress.Visible = false;
        //            //if (txtApplicantType.Text != "Multiple")
        //            //{
        //            TRAttached.Visible = true;
        //            TRAttachedGrid.Visible = true;
        //            GridView1.Columns[7].Visible = false;
        //            GridView1.Columns[5].Visible = false;
        //            //}
        //            //else
        //            //{
        //            //    TRAttached.Visible = false;
        //            //    TRAttachedGrid.Visible = false;
        //            //}
        //            //TRAttached.Visible = false;
        //            //TRAttachedGrid.Visible = false;
        //            IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
        //            grd_Documemnts.Columns[1].Visible = true;

        //            GridBindDocument();
        //            DivViewCart.Visible = true;
        //            GridToViewCart();

        //            string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
        //            if (Status.Trim() == "InProcess")
        //            {
        //                RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("0"));
        //                RadioButtonList2.Attributes.Add("disabled", "true");
        //                RadioButtonList2.Enabled = false;
        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //            else if (Status.Trim() == "Return")
        //            {
        //                RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("1"));
        //                RadioButtonList2.Attributes.Add("disabled", "true");
        //                RadioButtonList2.Enabled = false;
        //                Rejection.Visible = true;
        //                txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
        //                txtRejected.Attributes.Add("disabled", "true");

        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //            else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
        //            {
        //                RadioButtonList2.Enabled = false;
        //                txtRejected.Attributes.Add("disabled", "true");
        //                btnBack.Visible = true;
        //                btnSubmit.Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}