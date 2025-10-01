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
    public partial class Contractor_Licence_Renewal_Print : System.Web.UI.Page
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
                    // Session["NewApplicationRegistrationNo"] = "12";
                    if (Convert.ToString(Session["NewApplicationRegistrationNo"]) != null || Convert.ToString(Session["NewApplicationRegistrationNo"]) != string.Empty)
                    {
                        GetRenewalData(Session["NewApplicationRegistrationNo"].ToString().Trim());
                        GetGridBindData(Session["NewApplicationRegistrationNo"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

        protected void GetGridBindData(string RenewalId)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetRenewalDocuments(RenewalId);
            if (dt.Rows.Count > 0)
            {
                Grd_Document.DataSource = dt;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string fileName = "";
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                // fileName = "https://localhost:44393" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);


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
                txtAdhaar.Text = dt.Rows[0]["PanCardNo"].ToString();
                txt55Years.Text = dt.Rows[0]["Dateturn55"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtEmailId.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtCompeencyCertificate.Text = dt.Rows[0]["LicenceNew"].ToString();
                txtOldlicense.Text = dt.Rows[0]["LicenceOld"].ToString();
                txtRenewalDte.Text = dt.Rows[0]["RenewalTime"].ToString();
                txtGRNNo.Text = dt.Rows[0]["GRNNo"].ToString();
                txtChallanDate.Text = dt.Rows[0]["ChallanDate"].ToString();
                txtAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                userID = dt.Rows[0]["CreatedBy"].ToString();
                txtBelatedDate.Text = dt.Rows[0]["DelayedOrNot"].ToString();
                //txtMentiondays.Text = dt.Rows[0]["DaysDelay"].ToString();
                txtExpiryDate.Text = dt.Rows[0]["ExpiryDate"].ToString();
                txtlicensechangeaddress.Text = dt.Rows[0]["NeedToChangeOnLicence"].ToString();
                txteqipmenttested.Text = dt.Rows[0]["EquipmentsTested"].ToString();
                txtstaffchanged.Text = dt.Rows[0]["staffchanged"].ToString();
                userID = dt.Rows[0]["CreatedBy"].ToString();
                StaffData(userID);
                //already created that is why usedin it 
            }
        }
        private void StaffData(string userid)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetStaffDate(userid);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                NoStaffLable.Visible = false;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                NoStaffLable.Visible = true;

            }
            dt.Dispose();
        }
    }
}