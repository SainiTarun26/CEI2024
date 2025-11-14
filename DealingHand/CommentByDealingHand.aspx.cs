using CEI_PRoject;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.DealingHand
{
    public partial class CommentByDealingHand : System.Web.UI.Page
    {
        //Page Created By Neeraj in june 2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   
                    if (Convert.ToString(Session["DealingHandId"]) != null && Convert.ToString(Session["DealingHandId"]) != string.Empty)
                    {
                        if(Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                           hdnId.Value = Session["DealingHandId"].ToString().Trim();
                           hdnApplicationId.Value = Session["Application_Id"].ToString();
                           getDetails(hdnApplicationId.Value);
                           GetHeaderDetailsWithId(hdnApplicationId.Value);
                           BindApplicationLogDetails(hdnApplicationId.Value);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void  getDetails(string ApplicationId)
        {
            DataTable dt = new DataTable();

            dt = CEI.UserDetailsAfterComment(ApplicationId);
            if (dt.Rows.Count > 0)
            {
                txtStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                if(txtStatus.Text == "Scrutiny")
                {
                    Status.Visible = true;
                }
                string DealingHandComment = dt.Rows[0]["DealingHandComment"].ToString();
                if (DealingHandComment != null && DealingHandComment != string.Empty)
                {

                    Comments.Visible = false;
                    btnSubmit.Visible = false;
                }
                string SuperidentComment = dt.Rows[0]["SuperintendentReviewComment"].ToString();
                if (SuperidentComment != null && SuperidentComment != string.Empty)
                {

                    Comments.Visible = false;
                    btnSubmit.Visible = false;
                }

            }
            }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DealingHand/ViewData.aspx", false);
        }
        private void BindApplicationLogDetails(string licApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplicationId);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    string script = "alert(\"No record found for this application.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["DealingHandId"]) == hdnId.Value && Convert.ToString(Session["Application_Id"]) == hdnApplicationId.Value)
            {

                if(!string.IsNullOrWhiteSpace(txtRemarks.Text))
                {
                    int x = CEI.InsertDealingHandComment(hdnApplicationId.Value, hdnId.Value, txtRemarks.Text );

                    if(x > 1)
                    {
                        string script = $"alert('Remarks has been submit Succesfully!!.'); window.location='ViewData.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                    }
                    else
                    {
                        string alertScript = "alert('Please try again.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;

                    }
                
                }
                else
                {
                    txtRemarks.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter Comment to proceed.');", true);
                    return;
                }
            }
        }
        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            ucLicenceDetails.BindHeaderDetails(licApplicationId);
        }
    }
}