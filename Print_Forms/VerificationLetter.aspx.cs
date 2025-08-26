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

            if (!IsPostBack)
            {

                if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                {
                    hdnApplicationId.Value = Session["Application_Id"].ToString();
                    GetLetterData(hdnApplicationId.Value);
                }

            }
        }
        public void GetLetterData(string id)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetdataforXenletter(id);
            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();

            lblAppNo.Text = ds.Tables[0].Rows[0]["ApplicationNo"].ToString();
            lblCategary.Text = ds.Tables[0].Rows[0]["Categary"].ToString();
            lblCategary1.Text = ds.Tables[0].Rows[0]["Categary"].ToString();
            lblShortcomings.Text = ds.Tables[0].Rows[0]["Shortcoming"].ToString();
            if (string.IsNullOrEmpty(lblShortcomings.Text))
            {
                //lblShortcomings.Text = "Nil";
                Shortcomings.Visible = false;
            }
            lblScheduleDate.Text = ds.Tables[0].Rows[0]["PhysicalVerificationDate"].ToString();
            lblScheduleTime.Text = ds.Tables[0].Rows[0]["PhysicalVerificationTime"].ToString();
            lblScheduleVenue.Text = ds.Tables[0].Rows[0]["PhysicalVerificationPlace"].ToString();


            // lblapplicationDate.Text = ds.Tables[0].Rows[0]["applicationdate"].ToString();
            // lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            // lbluseraddress1.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
        }
    }
}