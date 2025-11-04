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

namespace CEIHaryana.Previewpages
{
    public partial class Certificate_of_wireman_PermitPreview : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["Application_Id"] = "App-103";
                if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                {
                    hdnApplicationId.Value = Session["Application_Id"].ToString();
                    GetData(hdnApplicationId.Value);
                    GridData(hdnApplicationId.Value);
                }
                else
                {
                    Response.Redirect("/LogOut.aspx", false);
                }

            }
        }
        public void GetData(string ApplicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetCertificateDataCon_Sup_WirForPreview(ApplicationId);
                if (dt.Rows.Count > 0)
                {
                   // dt.Rows[0]["QRCode"] = GenerateQrCode("Certificate_No = " + dt.Rows[0]["Certificate_No"].ToString());
                   // lblCertificateNo.Text = dt.Rows[0]["LicenceNo"].ToString();
                    lblDob.Text = dt.Rows[0]["DOB"].ToString();
                    lblname.Text = dt.Rows[0]["Name"].ToString();
                    lblFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                  //  lblApprovedDate.Text = dt.Rows[0]["ApprovedDate"].ToString();
                    Image.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                    imgPhoto.ImageUrl = dt.Rows[0]["ApplicantImageDocPath"].ToString();
                   // imgQRCode.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["QRCode"]);
                    //lblWEF.Text = dt.Rows[0]["WitheffectDate"].ToString();
                    lblValidUpto.Text = dt.Rows[0]["ExpiryDate"].ToString();


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void GridData(string ApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.getDataLicence_ForPreview(ApplicationId);
                if (ds.Tables.Count > 0)
                {
                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private byte[] GenerateQrCode(string qrmsg)
        {
            string code = qrmsg;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 70;
            imgBarCode.Width = 70;
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