using CEI_PRoject;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CEIHaryana.Print_Forms
{
    public partial class Certificate_Of_Competency_Upgradation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                        else
                        {
                            Session["ApplicationId"] = "";
                            Response.Redirect("/Admin/UpgradationRequestHistory.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
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

        private void GetLicenceDetails(string applicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetSupervisorDetailsForUpgApprovedRequest(applicationId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.Rows[0]["QRCode"] = GenerateQrCode("Certificate_No = " + dt.Rows[0]["Certificate_No"].ToString());
                    lblCertificateNo.Text = dt.Rows[0]["LicenceNo"].ToString();
                    lblWEF.Text = dt.Rows[0]["VoltageEffectedOn"].ToString();
                    lblValidUpto.Text = dt.Rows[0]["DateofExpiry"].ToString();
                    lblAuthorizedUpto.Text = dt.Rows[0]["Votagelevel"].ToString();
                    lblName.Text = dt.Rows[0]["Name"].ToString();
                    lblFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    lblAddress.Text = dt.Rows[0]["FullAddress"].ToString();
                    lblApprovedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    lblDob.Text = dt.Rows[0]["DOB"].ToString();
                    imgQRCode.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["QRCode"]);

                            string CandidateImg = dt.Rows[0]["Image"].ToString(); 
                            imgPhoto.ImageUrl = CandidateImg;
                     
                      
                    
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