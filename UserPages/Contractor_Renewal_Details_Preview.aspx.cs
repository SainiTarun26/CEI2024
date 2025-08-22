using CEI_PRoject;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Contractor_Renewal_Details_Preview : System.Web.UI.Page
    {
        //Page Created by Navneet 20-aug-2025
        CEI CEI = new CEI();
        string userID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["NewApplicationRegistrationNo"]) != null || Convert.ToString(Session["NewApplicationRegistrationNo"]) != string.Empty)
                    {
                        GetRenewalData(Session["NewApplicationRegistrationNo"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }
        protected void GetRenewalData(string RenewalId)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetRenwaUserRegistrationData(RenewalId);
            if (dt.Rows.Count > 0 && dt != null)
            {
                txtname.Text = dt.Rows[0]["ApplicantName"].ToString();
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtAge.Text = dt.Rows[0]["Age"].ToString();
                txtpanNo.Text = dt.Rows[0]["AadharNo"].ToString();
                txt55Years.Text = dt.Rows[0]["Dateturn55"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtEmailId.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtCompeencyCertificate.Text = dt.Rows[0]["LicenceNew"].ToString();
                txtRenewalDte.Text = dt.Rows[0]["RenewalTime"].ToString();
                txtGRNNo.Text = dt.Rows[0]["GRNNo"].ToString();
                txtChallanDate.Text = dt.Rows[0]["ChallanDate"].ToString();
                txtAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                userID = dt.Rows[0]["CreatedBy"].ToString();
                txtBelatedDate.Text = dt.Rows[0]["DelayedOrNot"].ToString();
                txtMentiondays.Text = dt.Rows[0]["DaysDelay"].ToString();
                txtEmployerChange.Text = dt.Rows[0]["changeofemployer"].ToString();
            }

            //already created that is why usedin it 
            DataTable dta = new DataTable();
            dta = CEI.GetSuperviserDetailsforRenewal(userID);
            if (dta.Rows[0]["AnyContractor"].ToString() == "No")
            {
                Employer.Visible = false;
            }
            else
            {
                Employer.Visible = true;
                txtNameofEmployer.Text = dta.Rows[0]["ContractorName"].ToString();
                txtLicenseNo.Text = dta.Rows[0]["Licence"].ToString();
                txtEmployerAddress.Text = dta.Rows[0]["ContractorAddress"].ToString();

            }
        }
    }
}