using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLondon_Click(object sender, EventArgs e)
        {
            London.Visible = true;
            Paris.Visible = false;
            Tokyo.Visible = false;
        }

        protected void btnParis_Click(object sender, EventArgs e)
        {
            London.Visible = false;
            Paris.Visible = true;
            Tokyo.Visible = false;
        }

        protected void btnTokyo_Click(object sender, EventArgs e)
        {
            London.Visible = false;
            Paris.Visible = false;
            Tokyo.Visible = true;
        }
    }
}