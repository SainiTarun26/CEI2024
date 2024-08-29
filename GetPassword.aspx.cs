using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class GetPassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string searchby = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Categary = ddluserCategary.SelectedItem.ToString();
            searchby = txtsearch.Text.ToString();
            DataTable dt = new DataTable();
            dt = CEI.GetDataByCategary(searchby, Categary);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }            
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddluserCategary.SelectedIndex = 0;
            txtsearch.Text = "";
            txtLiencesExpiryDate.Text = "";
            txtContact.Text = "";
            txtEmailId.Text = "";
            txtOTPVerify.Text = "";
            txtsearch.ReadOnly = false;
            ddluserCategary.Enabled = true;
            GridView1.DataSource = null;
            GridView1.DataBind();

        }

        protected void ddluserCategary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddluserCategary.SelectedValue =="1")
            {
                gstno.Visible = true;
                pantanno.Visible = false;
            }
            else if (ddluserCategary.SelectedValue == "2")
            {
                gstno.Visible = false;
                pantanno.Visible = false;
            }
            else if (ddluserCategary.SelectedValue == "3")
            {
                gstno.Visible = false;
                pantanno.Visible = true;
            }
            else if (ddluserCategary.SelectedValue == "4")
            {
                gstno.Visible = false;
                pantanno.Visible = false;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txtsearch.ReadOnly = true;
                ddluserCategary.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('You have to check the declaration first !!!')", true);
            }
        }
    }
}