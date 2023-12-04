using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class RequestPendingDays : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        private void BindDaysGridView()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }
    }
}