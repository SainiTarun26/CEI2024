using CEI_PRoject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CEIHaryana.Supervisor
{
    public partial class SupervisorDashboard : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                    {

                        GetDetails();
                    }
                    else
                    {
                        Response.Redirect("/SiteOwnerLogout.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }
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
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
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
                    txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                    txtVoltagelevel.Text = dp_Id3;
                    string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                    string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtSiteContact.Text = ds.Tables[0].Rows[0]["SiteContact"].ToString();
                    ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                    if (dp_Id7.Trim() == "Yes")
                    {

                        hiddenfield.Visible = true;
                        hiddenfield1.Visible = true;
                        txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        hiddenfield.Visible = false;
                        hiddenfield1.Visible = false;
                    }
                    string dp_Id8 = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                    txtWorkDetail.Text = dp_Id8;
                }
            }
            catch { }
        }

        //private void ddlLoadBindAssignWork()
        //{
        //    try
        //    {
        //        DataSet dsAssignWork = new DataSet();
        //        dsAssignWork = CEI.GetddlAssignedWorkForSupervisor();
        //        ddlAssignWork.DataSource = dsAssignWork;
        //        ddlAssignWork.DataTextField = "Id";
        //        ddlAssignWork.DataValueField = "Id";
        //        ddlAssignWork.DataBind();
        //        ddlAssignWork.Items.Insert(0, new ListItem("Select", "0"));
        //        dsAssignWork.Clear();
        //    }
        //    catch (Exception)
        //    {
        //        //msg.Text = ex.Message;
        //    }
        //}
        protected void ddlAssignedWork_SelectedIndexChanged1(object sender, EventArgs e)
        {
            // Session["Id"] = ddlAssignWork.SelectedItem.ToString();
            GetDetails();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "winclose", "window.close();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('TestReportDetails.aspx');", true);
            //Response.Redirect("TestReportDetails.aspx");
        }
    }
}