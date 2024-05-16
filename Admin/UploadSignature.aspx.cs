using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class UploadSignature : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminID"] != null)
                {
                    GetDivisionName();

                }
            }
        }

        private void GetDivisionName()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.getDivisionName();
                ddlDivisionName.DataSource = ds;
                ddlDivisionName.DataTextField = "HeadOfficeArea";
                ddlDivisionName.DataValueField = "Id";
                ddlDivisionName.DataBind();
                ddlDivisionName.Items.Insert(0, new ListItem("Select", "0"));
                //GetStaffName();

            }
            catch { }
        }
        private void GetStaffName()
        {
            try
            {
                string DivisionName = ddlDivisionName.SelectedItem.ToString();
                DataSet ds = new DataSet();
                ds = CEI.getStaffName(DivisionName);
                ddlstaffname.DataSource = ds;
                ddlstaffname.DataTextField = "StaffUserId";
                ddlstaffname.DataValueField = "StaffUserId";
                ddlstaffname.DataBind();
                ddlstaffname.Items.Insert(0, new ListItem("Select", "0"));


            }
            catch { }
        }



        protected void BtnSubmit_Click(object sender, EventArgs e)
        {


            string DivisionName = ddlDivisionName.SelectedItem.ToString();
            string StaffName = ddlstaffname.SelectedValue;
            byte[] signatureBytes = null;
            string filePathInfo1 = "";

            if (Signature.HasFile) // Check if file is uploaded
            {
                signatureBytes = Signature.FileBytes;
                string fileName = Path.GetFileName(Signature.FileName);
                string AdminID = Session["AdminID"].ToString();
                string ext = Path.GetExtension(fileName);
                string directoryPath = Server.MapPath("~/Attachment/" + AdminID + "/Signature/");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string uniqueFileName = "Signature" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                string filePath = Path.Combine(directoryPath, uniqueFileName);
                Signature.SaveAs(filePath);

                filePathInfo1 = "/Attachment/" + AdminID + "/Signature/" + uniqueFileName;
            }


            CEI.UploadSignature(DivisionName, StaffName, signatureBytes);

            ddlDivisionName.SelectedIndex = 0;
            ddlstaffname.SelectedIndex = 0;

            string script = $"alert('Signature for {StaffName} updated successfully.'); window.location='IntimationHistoryForAdmin.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);




        }

        protected void ddlDivisionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStaffName();

        }
    }
}