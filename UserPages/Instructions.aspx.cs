using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Instructions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDeclaration.Checked == true)
                {
                    Response.Redirect("/UserPages/Registration.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please check declaration first to proceed.')", true);
                }
            }
            catch (Exception)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
    }
}

