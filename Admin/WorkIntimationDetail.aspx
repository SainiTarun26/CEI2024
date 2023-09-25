using CEI_PRoject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class WorkIntimationDetail : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorID = string.Empty;
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                {
                    //BindListBoxInstallationType();
                    hiddenfield.Visible = false;
                    hiddenfield1.Visible = false;
                    OtherWorkDetail.Visible = false;
                    OtherPremises.Visible = false;
                    if (Convert.ToString(Session["id"]) == null || Convert.ToString(Session["id"]) == "")
                    {



                    }
                    else
                    {
                        GetDetails();
                        GetassigneddatatoContractor();

                    }
                    ddlLoadBindPremises();
                    worktypevisiblity();
                    // ddlLoadBindVoltage();




                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
        }
        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                DataSet ds = new DataSet();
                ds= CEI.GetWorkIntimationDataForAdmin(REID);
                    string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                    ddlPremises.SelectedValue = dp_Id1;
                    string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                    ddVoltageLevel.Text = dp_Id3;
                    //txtOtherWorkDetail.Text = ds.Tables[0].Rows[0]["OtherWorkDetail"].ToString();
                    string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                    string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                    txtcustomFile.Text = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
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
                    ddWorkDetail.Text = dp_Id8;
                
            }
            catch { }
        }
        protected void GetassigneddatatoContractor()
        {
            try
            {
                string ID = string.Empty;
                ID = Session["id"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetStaffAssignedToContractor(ID);
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record of attached Supervisor/Wireman Found \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch
            {
            }
        }
        protected void worktypevisiblity()
        {

            if (ddlworktype.SelectedValue == "1")
            {
                individual.Visible = true;
                agency.Visible = false;

            }
            else if (ddlworktype.SelectedValue == "2")
            {
                individual.Visible = false;
                agency.Visible = true;

            }
            else
            {
                individual.Visible = true;
                agency.Visible = false;
            }

        }

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktypevisiblity();
        }
        private void ddlLoadBindPremises()
        {
            try
            {

                DataSet dsPremises = new DataSet();
                dsPremises = CEI.GetddlPremises();
                ddlPremises.DataSource = dsPremises;
                ddlPremises.DataTextField = "Premises";
                ddlPremises.DataValueField = "ID";
                ddlPremises.DataBind();
                ddlPremises.Items.Insert(0, new ListItem("Select", "0"));
                dsPremises.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        //private void BindListBoxInstallationType()
        //{
        //    try
        //    {
        //        DataSet dsWorkDetail = new DataSet();
        //        dsWorkDetail = CEI.GetddlInstallationType();
        //        ddlWorkDetail.DataSource = dsWorkDetail;
        //        ddlWorkDetail.DataTextField = "InstallationType";
        //        ddlWorkDetail.DataValueField = "Id";
        //        ddlWorkDetail.DataBind();
        //        ddlWorkDetail.Items.Insert(0, new ListItem("Select", "0"));
        //        dsWorkDetail.Clear();
        //    }
        //    catch
        //    {

        //    }
        //}
        //private void ddlLoadBindVoltage()
        //{
        //    try
        //    {
        //        DataSet dsVoltage = new DataSet();
        //        dsVoltage = CEI.GetddlVoltageLevel();
        //        ddlVoltageLevel.DataSource = dsVoltage;
        //        ddlVoltageLevel.DataTextField = "Voltagelevel";
        //        ddlVoltageLevel.DataValueField = "VoltageID";
        //        ddlVoltageLevel.DataBind();
        //        ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
        //        dsVoltage.Clear();
        //    }
        //    catch
        //    {

        //    }

        //}





        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
            }
        }

        protected void ddlAnyWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnyWork.SelectedValue == "Yes")
            {

                hiddenfield.Visible = true;
                hiddenfield1.Visible = true;
            }
            else
            {
                hiddenfield.Visible = false;
                hiddenfield1.Visible = false;
            }
        }

        //protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlWorkDetail.SelectedValue == "1")
        //    {
        //        OtherWorkDetail.Visible = true;
        //        //ddlWorkDetail.Attributes.Add("disabled", "disabled");
        //    }
        //    else
        //    {

        //        OtherWorkDetail.Visible = false;
        //    }
        //}

        protected void ddlPremises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPremises.SelectedValue == "10")
            {
                OtherPremises.Visible = true;

            }
            else
            {

                OtherPremises.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id"] = "";
            Response.Redirect("Projects.aspx");
        }
    }
}