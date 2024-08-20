using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class ViewPerodicRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
                    {
                       
                        //if (Session["SiteOwnerId"].ToString() != "JVCBN5647K")
                        //{
                        //    //Session["SiteOwnerId"] = "JVCBN5647K";
                        //}

                      
                        if (Session["CartID"] != null)
                        {
                            string CartID = Session["CartID"].ToString();
                            BindGrid(); 
                        }
                     
                    }
                }
            }
            catch
            {
            }

        }
        public void BindGrid()
        {

            string CartID = Session["CartID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.ViewInspection(CartID);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
    }
}