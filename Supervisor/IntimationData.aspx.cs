using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Supervisor
{
    public partial class IntimationData : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                    {
                        getWorkIntimationData();
                    }
                }
            }
            catch { }
        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            ds = cei.WorkIntimationDataforAdmin();
            if (ds.Rows.Count > 0)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Session["id"] = id;
            if (e.CommandName == "Select")

            {
                string url = "SupervisorDashboard.aspx";

                // Define the JavaScript code to open the popup
                string script = $@"<script type='text/javascript'>
                        var popup = window.open('{url}', 'PopupWindow', 'width=800,height=600,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no');
                        if (popup) {{
                            popup.focus();
                        }}
                        </script>";

                // Register the JavaScript code to be executed on the client side
                ClientScript.RegisterStartupScript(this.GetType(), "OpenPopup", script);

                //Session["id"] = ID;
                // Response.Redirect("/Supervisor/SupervisorDashboard.aspx");

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }
        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                SqlCommand cmd = new SqlCommand("sp_WorkIntimationData");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", REID);
                cmd.Connection = con;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    txtInstallation.Text = dp_Id;
                    if (dp_Id == "Firm/Organization/Company/Department")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                    }
                    else
                    {
                        individual.Visible = true;
                        agency.Visible = false;
                    }

                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                    TxtPremises.Text = dp_Id1;
                    string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    //txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                    txtVoltagelevel.Text = dp_Id3;
                    string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                    string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                    // txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    // txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtSiteContact.Text = ds.Tables[0].Rows[0]["SiteContact"].ToString();
                    //ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                    //if (dp_Id7.Trim() == "Yes")
                    //{

                    //    hiddenfield.Visible = true;
                    //    hiddenfield1.Visible = true;
                    //    txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                    //}
                    //else
                    //{
                    //    hiddenfield.Visible = false;
                    //    hiddenfield1.Visible = false;
                    // }
                    string dp_Id8 = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                    txtWorkDetail.Text = dp_Id8;
                }
            }
            catch { }
        }
    }
}