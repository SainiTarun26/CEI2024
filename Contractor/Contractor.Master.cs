using System;
using System.Web;

namespace CEIHaryana.Contractor
{
    public partial class Contractor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                if (Convert.ToString(Session["ContractorID"]) != null || Convert.ToString(Session["ContractorID"]) != string.Empty)
                {

                    lblName.Text = Convert.ToString(Session["ContractorID"]);
                }
                else if (Session["ContractorID"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/Login.aspx");
                }
                else
                {

                    Session["ContractorID"] = "";
                    Response.Redirect("/Login.aspx");
                }
            }
            catch
            {
                Session["ContractorID"] = "";
                Response.Redirect("/Login.aspx");
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Login.aspx");
        }
    }
}