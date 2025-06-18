using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class ToVerifyRegistration : System.Web.UI.Page
    {
        //Page Created by neha 18-June-2025
        CEI CEI = new CEI();

        protected void Page_Load(object sender, EventArgs e)
        {
            string encryptedId = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(encryptedId))
            {
                try
                {
                    string email = Request.QueryString["email"]; 
                    if (!string.IsNullOrEmpty(email))
                    {
                        string decryptedRandomNumber = DecryptRandomNumber(encryptedId);

                        DataTable dt = CEI.GetNewAccountCredentials(decryptedRandomNumber);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string UserId = dt.Rows[0]["UserId"].ToString();
                            string Password = dt.Rows[0]["Password"].ToString();

                            CEI.NewAccountCredentialsthroughEmail(email, UserId, Password);                           
                        }
                        else
                        {
                        }
                        

                        //CEI.NewAccountCredentialsthroughEmail(email);
                    }
                }
                catch (FormatException ex)
                {
                    Response.Write("Invalid ID format.");
                }
            }
        }

        private string DecryptRandomNumber(string encryptedId)
        {
            int padding = 4 - (encryptedId.Length % 4);
            if (padding != 4)
            {
                encryptedId = encryptedId.PadRight(encryptedId.Length + padding, '=');
            }

            byte[] bytes = Convert.FromBase64String(encryptedId);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}