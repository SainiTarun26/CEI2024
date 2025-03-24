using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportIntimationHistory : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                    {
                        getWorkIntimationData();
                    }
                    else
                    {

                    }
                }
            }
            catch {  Response.Redirect("/SupervisorLogout.aspx"); }
        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SupervisorID"].ToString();
            ds = cei.WorkIntimationHistoryforSupervisor(Id);
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
        protected void ShowPopup_Click(object sender, EventArgs e)
        {
            try
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "showModal();", true);
            }
            catch { }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["id"] = lblID.Text;
                //ClientScript.RegisterStaxrtupScript(this.GetType(), "Pop", "showModal();", true);
                //    GetDetails();
                Response.Redirect("/Supervisor/TestReportHistory.aspx");


            }
            else
            {
                getWorkIntimationData();

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
                DataSet ds = new DataSet();
                ds = cei.GetWorkIntimationDataForAdmin(REID);
                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "Firm/Company")
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
                // txtSiteContact.Text = ds.Tables[0].Rows[0]["SiteContact"].ToString();
                //string dp_Id8 = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                //txtWorkDetail.Text = dp_Id8;

            }
            catch { }
        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    string searhterm = txtSearch.Text.Trim();
        //    string LoginId = string.Empty;
        //    LoginId = Session["SupervisorID"].ToString();

        //    DataSet ds = new DataSet();
        //    ds = cei.SearchingOnIntimation(searhterm, LoginId);
        //    if (ds.Tables.Count > 0)
        //    {
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();
        //    }
        //    else
        //    {
        //        string script = "alert(\"No Record Match\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "Server Script", script, true);
        //    }
        //}
    }
}