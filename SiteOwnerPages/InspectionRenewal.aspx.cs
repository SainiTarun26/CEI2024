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
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
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
            string selectedInspectionIdsString = Session["SelectedInspectionId"] as string;

            if (!string.IsNullOrEmpty(selectedInspectionIdsString))
            {
                
                string[] selectedInspectionIdsArray = new string[] { selectedInspectionIdsString };
                DataSet ds = CEI.InspectionRenewal(selectedInspectionIdsArray);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
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
            
        }




        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
            string installationtype = lblInstallationType.Text;
            string testReportId = e.CommandArgument.ToString();
            


            if (installationtype == "Line")
            {
                Session["LineID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Substation Transformer")
            {
                Session["SubStationID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (installationtype == "Generating Set")
            {
                Session["GeneratingSetId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               TableCell daysCell = e.Row.Cells[7];

                string daysText = daysCell.Text;
                int days;
                if (int.TryParse(daysText, out days))
                {
                    
                    if (days > 15)
                    {
                        daysCell.ForeColor = System.Drawing.Color.OrangeRed;
                    }
                    else if(days < 15)
                    {
                        daysCell.ForeColor = System.Drawing.Color.YellowGreen;
                    }
                    else
                    {
                        daysCell.ForeColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }

        }
    }
}