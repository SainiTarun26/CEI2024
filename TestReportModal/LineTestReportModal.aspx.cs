using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class LineTestReportModal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (Session["ContractorID"] != null)
                //{
                //    GetDetailswithId();
                //}
            }


        }

        public void GetDetailswithId()
        {
            ID = Session["LineID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.LineDataWithId(ID);

        }
    }
}