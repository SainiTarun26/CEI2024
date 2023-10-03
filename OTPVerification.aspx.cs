using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class OTPVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void VerifyOTP(object sender, EventArgs e)
        {
            Verify.Visible = false;
            VerifyOPTdiv.Visible = true;
        }
    }
}