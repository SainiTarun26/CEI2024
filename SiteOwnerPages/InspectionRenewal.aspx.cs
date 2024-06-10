using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class InspectionRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        GridViewBind();


                    }
                    
                    
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        public void GridViewBind()
        {

            string intimationId = Session["IntimationId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InspectionRenewal(intimationId);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string inspectionId = e.Row.Cells[0].Text;
              
            }
        }

        //protected void lnkRedirect_Click(object sender, EventArgs e)
        //{
           
            
        //}
    }
}