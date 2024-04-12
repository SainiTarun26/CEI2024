using CEI_PRoject;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CEIHaryana.Supervisor
{
    public partial class Supervisor : System.Web.UI.MasterPage
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetSupervisorName();
                if (Convert.ToString(Session["SupervisorID"]) != null || Convert.ToString(Session["SupervisorID"]) != string.Empty || Request.Cookies["SupervisorID"] != null)
                {
                    if (Request.Cookies["SupervisorID"] != null)
                    {

                        lblName.Text = Request.Cookies["SupervisorID"].Value;
                    }
                    else
                    {
                        lblName.Text = Convert.ToString(Session["SupervisorID"]);
                    }
                }
                else if (Session["SupervisorID"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/Login.aspx");
                }
                else
                {

                    Session["SupervisorID"] = "";
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["SupervisorID"] = "";
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }

        public void GetSupervisorName()
        {
            string SupervisorId = Session["SupervisorID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetsupervisorName(SupervisorId);            
            PersonDetails.Text = ds.Tables[0].Rows[0]["SupervisorProfile"].ToString();
        }
    }
}