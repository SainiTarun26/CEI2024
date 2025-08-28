using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using System.IO;
using System.Drawing;

namespace CEIHaryana.Print_Forms
{
    public partial class Contractor_Licence_Upgradation_Certificate : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    if (Convert.ToString(Session["ApplicationId"]) != null && Convert.ToString(Session["ApplicationId"]) != string.Empty)
                    {
                        String ApplicationId = Convert.ToString(Session["ApplicationId"]);
                        GetLicenceDetails(ApplicationId);
                        GetCEISignatureForUpgradation();
                    }
                }
            }
        }


        private void GetCEISignatureForUpgradation()
        {
            try
            {
                DataTable dt = CEI.GetCEISignatureForUpgradation();
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Signature"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])dt.Rows[0]["Signature"];
                    string base64String = Convert.ToBase64String(imageBytes);
                    CEISignatureImage.ImageUrl = "data:image/png;base64," + base64String;
                }
            }
            catch
            { }
        }
        private void GetLicenceDetails(string ApplicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetContractorDetailsForUpgApprovedRequest(ApplicationId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.Rows[0]["QRCode"] = GenerateQrCode("Certificate_No = " + dt.Rows[0]["Certificate_No"].ToString());
                    lblCertificateNo.Text = dt.Rows[0]["LicenceNo"].ToString();
                    lblWEF.Text = dt.Rows[0]["VoltageWithEffect"].ToString();
                    lblAuthorizedUpto.Text = dt.Rows[0]["Votagelevel"].ToString();
                    lblName.Text = dt.Rows[0]["Name"].ToString();
                    lblApprovedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    imgQRCode.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["QRCode"]);
                    String UserID = dt.Rows[0]["RegistationId"].ToString();
                    GetPartnerDetails(UserID);
                    String CertificateNo = lblCertificateNo.Text;
                    GetTeamDetails(CertificateNo);

                    string CandidateImg = dt.Rows[0]["Image"].ToString();
                    imgPhoto.ImageUrl = CandidateImg;
                    string CandidateSignatureImg = dt.Rows[0]["CandidateSignature"].ToString();
                    mySignature.ImageUrl = CandidateSignatureImg;
                }
            }
            catch
            { }
        }

        private void GetTeamDetails(string CertificateNo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUpgContractorTeam(CertificateNo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Team = dt.Rows[0]["Name"].ToString();
                    string[] TeamArray = Team.Split(',');

                    // values
                    if (TeamArray.Length > 0) lblSup1.Text = TeamArray[0];
                    if (TeamArray.Length > 1) lblSup2.Text = TeamArray[1];
                    if (TeamArray.Length > 2) lblSup3.Text = TeamArray[2];
                    if (TeamArray.Length > 3) lblSup4.Text = TeamArray[1];
                    if (TeamArray.Length > 4) lblSup5.Text = TeamArray[2];
                }
            }
            catch
            { }
        }

        private void GetPartnerDetails(string userID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUpgContractorPartnerForLetter(userID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string partners = dt.Rows[0]["Name"].ToString(); 
                    string[] partnerArray = partners.Split(',');

                    // values
                    if (partnerArray.Length > 0) lblPatner1.Text = partnerArray[0];
                    if (partnerArray.Length > 1) lblPatner2.Text = partnerArray[1];
                    if (partnerArray.Length > 2) lblPatner3.Text = partnerArray[2];
                    if (partnerArray.Length > 3) lblPatner4.Text = partnerArray[1];
                    if (partnerArray.Length > 4) lblPatner5.Text = partnerArray[2];
                }
            }
            catch
            { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/UpgradationRequestHistory.aspx", false);
        }

        private byte[] GenerateQrCode(string qrmsg)
        {
            string code = qrmsg;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    return byteImage;
                }
            }
        }
    }
}