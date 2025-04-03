using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace CEIHaryana.Admin
{
    public partial class UtilityMaster : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            string UtilityName = txtUtilityName.Text.Trim();

            DataSet ds1 = CEI.checkUtilityName(UtilityName);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                string script = $"alert('Power Utility Name  {UtilityName}  already exists.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);

            }
            else
            {
                CEI.InsertInUtilityMaster(txtUtilityName.Text.Trim());
                Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Utility Name Submitted Successfully !!!');  window.location='AdminMaster.aspx';", true);
            }
        }
        protected void Reset()
        {
            try
            {

                txtUtilityName.Text = "";
            
            }
            catch (Exception ex)
            {
            }
        }

        private void GridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetUtilityMaster();
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
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}