using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Print_Forms
{
    //Page created by navneet 18-June-2025
    public partial class VerificationLetter : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ApplicationId;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            //{
            //    ApplicationId = Session["Application_Id"].ToString();
            //    GetLetterData(ApplicationId);
            //}
        }
        public void GetLetterData(string id)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetdataforXenletter(id);
           // Application.Text = ds.Tables[0].Rows[0]["ApplicationId"].ToString();
           // lblapplicationDate.Text = ds.Tables[0].Rows[0]["applicationdate"].ToString();
           // lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
           // lbluseraddress1.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
        }
    }
}