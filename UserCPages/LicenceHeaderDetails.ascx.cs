using CEI_PRoject;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserCPages
{
    public partial class LicenceHeaderDetails : System.Web.UI.UserControl
    {
        CEI CEI = new CEI();
        public string LicenceCategory
        {
            get => txtLicenceCategory.Text.Trim();
            set => txtLicenceCategory.Text = value;
        }
        public string LicenceType
        {
            get => txtLicenceType.Text.Trim();
            set => txtLicenceType.Text = value;
        }
        public string ApplicationId
        {
            get => txtApplicationId.Text.Trim();
            set => txtApplicationId.Text = value;
        }
        public string ApplicantName
        {
            get => txtApplicantName.Text.Trim();
            set => txtApplicantName.Text = value;
        }
        public string DOB
        {
            get => txtDOB.Text.Trim();
            set => txtDOB.Text = value;
        }
        public string FatherName
        {
            get => txtFatherName.Text.Trim();
            set => txtFatherName.Text = value;
        }
        public string AadhaarNo
        {
            get => txtAdharNo.Text.Trim();
            set => txtAdharNo.Text = value;
        }
        public string District
        {
            get => txtDistrict.Text.Trim();
            set => txtDistrict.Text = value;
        }
        public string ContactNo
        {
            get => txtContactNo.Text.Trim();
            set => txtContactNo.Text = value;
        }
        public string EmailId
        {
            get => txtEmailId.Text.Trim();
            set => txtEmailId.Text = value;
        }
        public string CommitteeId
        {
            get => txtCommiteeId.Text.Trim();
            set => txtCommiteeId.Text = value;
        }
        public string RegistrationId
        {
            get => txtRegistrationId.Text.Trim();
            set => txtRegistrationId.Text = value;
        }
        public string Address
        {
            get => txtAddress.Text.Trim();
            set => txtAddress.Text = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            Session["NewApplicationRegistrationNo"] = "";
            Session["NewApplication_Contractor_RegNo"] = "";
            Session["Application_Id"] = ApplicationId;

            var redirectId = hdnRedirectionRegistrationId.Value.Trim();

            if (string.IsNullOrWhiteSpace(redirectId))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('RegistrationId ID Not Found.');", true);
                return;
            }

            if (LicenceType == "New")
            {
                if (LicenceCategory == "Wireman" || LicenceCategory == "Supervisor")
                {
                    Session["NewApplicationRegistrationNo"] = hdnRedirectionRegistrationId.Value.Trim();
                    Response.Write("<script>window.open('/UserPages/New_Registration_Information.aspx','_blank');</script>");
                }
                else if (LicenceCategory == "Contractor")
                {
                    Session["NewApplication_Contractor_RegNo"] = hdnRedirectionRegistrationId.Value.Trim();
                    Response.Write("<script>window.open('/UserPages/New_Registration_Information_Contractor.aspx','_blank');</script>");
                }
            }
            else if(LicenceType == "Renewal")
            {
                if (LicenceCategory == "Wireman" || LicenceCategory == "Supervisor")
                {
                    Session["NewApplicationRegistrationNo"] = hdnRedirectionRegistrationId.Value.Trim();
                    Response.Write("<script>window.open('/UserPages/Certificate_Renewal_Details_Preview.aspx','_blank');</script>");
                }
                else if (LicenceCategory == "Contractor")
                {
                    Session["NewApplicationRegistrationNo"] = hdnRedirectionRegistrationId.Value.Trim();
                    Response.Write("<script>window.open('/UserPages/Contractor_Renewal_Details_Preview.aspx','_blank');</script>");
                }
            }

        }
        public void BindHeaderDetails(string licApplicationId)
        {
            DataSet ds = CEI.Licence_Cei_Approval_GetHeaderDetails(licApplicationId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                LicenceCategory = row["Categary"].ToString(); 
                LicenceType = row["LicenceType"].ToString(); 
                ApplicationId = row["ApplicationId"].ToString();
                CommitteeId = row["CommitteeId"].ToString();
                ApplicantName = row["Name"].ToString();
                RegistrationId = row["RegistrationId"].ToString();
                DOB = row["DOB"] != DBNull.Value ? Convert.ToDateTime(row["DOB"]).ToString("dd-MM-yyyy") : string.Empty;
                FatherName = row["FatherName"].ToString();
                AadhaarNo = row["PanCardNoOrAdharNo"].ToString();
                EmailId = row["Email"].ToString();
                ContactNo = row["PhoneNo"].ToString();
                District = row["District"].ToString();
                Address = row["Address"].ToString();
                hdnRedirectionRegistrationId.Value = row["RedirectionRegistrationId"]?.ToString();
                
                if (LicenceCategory == "Contractor")
                {
                    lblPanOrAadhaar.InnerText = "PAN No";
                }
                else
                {
                    lblPanOrAadhaar.InnerText = "Aadhaar No";
                }
            }
        }
    }
}
