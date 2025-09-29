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
    public partial class ContractorLicenceRenewal : System.Web.UI.Page
    {
        //page created By neeraj 19-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Session["Application_Id"] = "App-109";
                if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                {
                    hdnApplicationId.Value = Session["Application_Id"].ToString();
                    GetData(hdnApplicationId.Value);
                    GridData(hdnApplicationId.Value);
                    //getContractorSignature();
                    GetPatnersDetails();
                    GetSupervisiorWiremanDetails();
                }

            }
        }
        public void GetData(string ApplicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetCertificateDataCon_Sup_Wir(ApplicationId);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["QRCode"] = GenerateQrCode("Certificate_No = " + dt.Rows[0]["Certificate_No"].ToString());
                    lblRegistationId.Text = dt.Rows[0]["RegistationId"].ToString();
                    lblCertificateNo.Text = dt.Rows[0]["LicenceNo"].ToString();
                    lblName.Text = dt.Rows[0]["Name"].ToString();
                    lblApprovedDate.Text = dt.Rows[0]["ApprovedDate"].ToString();
                    Image.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                    myImage.ImageUrl = dt.Rows[0]["ContractorSignatureDocPath"].ToString();
                    imgPhoto.ImageUrl = dt.Rows[0]["ApplicantImageDocPath"].ToString();
                    lblAuthorizedUpto.Text = dt.Rows[0]["Votagelevel"].ToString();
                    imgQRCode.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["QRCode"]);
                    //lblOldLicenceNo.Text = dt.Rows[0]["OldLicenceNo"].ToString();
                    lblWEF.Text = dt.Rows[0]["WitheffectDate"].ToString();
                    lblValidUpto.Text = dt.Rows[0]["ExpiryDate"].ToString();
                    lblInitialIssueDate.Text = dt.Rows[0]["InitialIssueDate"].ToString();
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        //public void getContractorSignature()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = CEI.getContractorSignature(lblRegistationId.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            myImage.ImageUrl = dt.Rows[0]["DocumentPath"].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
        //        return;
        //    }

        //}
        public void GetPatnersDetails()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetPatnersDetails(lblRegistationId.Text);
            if (dt.Rows.Count > 0)
                lblPatner1.Text = dt.Rows[0]["Name"].ToString();

            if (dt.Rows.Count > 1)
                lblPatner2.Text = dt.Rows[1]["Name"].ToString();

            if (dt.Rows.Count > 2)
                lblPatner3.Text = dt.Rows[2]["Name"].ToString();

            if (dt.Rows.Count > 3)
                lblPatner4.Text = dt.Rows[3]["Name"].ToString();

            if (dt.Rows.Count > 4)
                lblPatner5.Text = dt.Rows[4]["Name"].ToString();
        }
        public void GetSupervisiorWiremanDetails()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetSupWiremanDetails(lblRegistationId.Text);
            if (dt.Rows.Count > 0)
            {
                lblSup1.Text = dt.Rows[0]["Name"].ToString();
            }
            if (dt.Rows.Count > 1)
            {
                lblSup2.Text = dt.Rows[1]["Name"].ToString();
            }
            if (dt.Rows.Count > 2)
            {
                lblSup3.Text = dt.Rows[2]["Name"].ToString();
            }
            if (dt.Rows.Count > 3)
            {
                lblSup4.Text = dt.Rows[3]["Name"].ToString();
            }
            if (dt.Rows.Count > 4)
            {
                lblSup5.Text = dt.Rows[4]["Name"].ToString();
            }
        }
        public void GridData(string ApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.getDataLicence(ApplicationId);
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