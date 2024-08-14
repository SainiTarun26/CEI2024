using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            
            if (Session["NewUserId"] != null)
            {
                UserId = Session["NewUserId"].ToString();
            }
            else if (Session["ContractorID"] != null)
            {
                UserId = Session["ContractorID"].ToString();

            }
            else if (Session["SiteOwnerId"] != null)
            {
                UserId = Session["SiteOwnerId"].ToString();

            }
            else if (Session["AdminID"] != null)
            {
                UserId = Session["AdminID"].ToString();

            }
            else if (Session["StaffID"] != null)
            {
                UserId = Session["StaffID"].ToString();

            }
            else if (Session["SupervisorID"] != null)
            {
                UserId = Session["SupervisorID"].ToString();

            }
            //String UserId = Session["UserId"].ToString();

            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string verifyPassword = txtVerifyPassword.Text.Trim();
            if (newPassword != verifyPassword)
            {

                string alertScript = "alert('New passwords do not match with verify password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }
            if (currentPassword == newPassword)
            {

                string alertScript = "alert('New passwords do not equal to current password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }

            DataSet ds1 = CEI.checkPassword(UserId);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string storedPassword = ds1.Tables[0].Rows[0]["Password"].ToString();

                if (currentPassword == storedPassword)
                {

                    DataSet ds2 = CEI.changePassword(UserId, newPassword);

                    

                        string successScript = "alert('Password changed successfully.'); window.location='Login.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", successScript, true);
               
                      
                }
                else
                {

                    string alertScript = "alert('Current password is incorrect.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }
            }
            else
            {
              
                string alertScript = "alert('Error retrieving current password.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtVerifyPassword.Text = "";
        }
    }
}