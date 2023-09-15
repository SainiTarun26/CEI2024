using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;

namespace CEIHaryana.Contractor
{
    public partial class Work_Intimation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorID = string.Empty; 
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ContractorID"] != null )
                {
                    ddlLoadBindPremises();
                    worktypevisiblity();
                    ddlLoadBindVoltage();

                    BindListBoxInstallationType();
                    hiddenfield.Visible = false;
                    hiddenfield1.Visible = false;
                    OtherPremises.Visible = false;

                    if (Convert.ToString(Session["id"]) == null || Convert.ToString(Session["id"]) == "")
                    {

                        GetGridData();
                        GridView1.Columns[0].Visible = true;
                    }
                    else
                    {

                        GetDetails();
                        GetassigneddatatoContractor();
                        ddlWorkDetail.Visible = false;
                        
                        WorkDetail.Visible = true;
                        Session["id"] = "";
                        btnReset.Visible = false;
                        btnSubmit.Visible = false;
                        btnBack.Visible = true;
                    }
                    
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
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                   // ddlPremises.SelectedIndex = ddlPremises.Items.IndexOf(ddlPremises.Items.FindByValue(dp_Id1));
                    ddlPremises.SelectedValue =  dp_Id1;
                    string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                   // ddlVoltageLevel.SelectedValue = dp_Id3;
                    ddlVoltageLevel.SelectedIndex = ddlVoltageLevel.Items.IndexOf(ddlVoltageLevel.Items.FindByText(dp_Id3));
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                    string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                   
                    ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                    if (dp_Id7 == "Yes")
                    {

                        hiddenfield.Visible = true;
                        hiddenfield1.Visible = true;
                        customFile.Visible = false;
                        customFileLocation.Visible = true;
                        txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                    }
                    WorkDetail.Text = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                    customFileLocation.Text = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();

                    

                    


                }
            }
            catch { }
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
        private void BindListBoxInstallationType()
        {
            DataSet dsWorkDetail = new DataSet();
            dsWorkDetail = CEI.GetddlInstallationType();
            ddlWorkDetail.DataSource = dsWorkDetail;
            ddlWorkDetail.DataTextField = "InstallationType";
            ddlWorkDetail.DataValueField = "Id";
            ddlWorkDetail.DataBind();
            ddlWorkDetail.Items.Insert(0, new ListItem("Select", "0"));
            dsWorkDetail.Clear();
        }
        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageLevel();
            ddlVoltageLevel.DataSource = dsVoltage;
            ddlVoltageLevel.DataTextField = "Voltagelevel";
            ddlVoltageLevel.DataValueField = "VoltageID";
            ddlVoltageLevel.DataBind();
            ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }
        protected void Reset()
        {
            ddlworktype.SelectedValue = "0";
            txtName.Text = "";
            txtagency.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPin.Text = "";
            ddlPremises.SelectedValue = "0";
            ddlVoltageLevel.SelectedValue = "0";
            //txtOtherWorkDetail.Text = "";
            txtStartDate.Text = "";
            txtCompletitionDate.Text = "";
            ddlAnyWork.SelectedValue = "0";
            txtCompletionDateAPWO.Text = "";
            foreach (ListItem item in ddlWorkDetail.Items)
            {
                item.Selected = false;
            }
            //OtherWorkDetail.Visible = false;
            OtherPremises.Visible = false;
            hiddenfield.Visible = false;
            hiddenfield1.Visible = false;
            txtEmail.Text = "";
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ContractorID"] != null)
                {

                    //ContractorID = Session["ContractorID"].ToString();
                    //string WorkDetails = "";
                    //foreach (ListItem item in ddlWorkDetail.Items)
                    //{
                    //    if (item.Selected)
                    //    {
                    //        WorkDetails += item.Text + ",";
                    //    }

                    //}
                    //string WorkData = WorkDetails.TrimEnd(',');

                    string filePathInfo = "";
                    if (ddlAnyWork.SelectedValue == "Yes")
                    {
                        string FileName = string.Empty;
                        if (customFile.PostedFile.FileName.Length > 0)
                        {
                           FileName = Path.GetFileName(customFile.PostedFile.FileName);
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/"));
                            }

                            string ext = customFile.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + ContractorID + "/Copy of Work Order/";
                            string fileName = "Copy of Work Order" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string filePathInfo2 = "";
                            filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/" + fileName);
                            customFile.PostedFile.SaveAs(filePathInfo2);
                            filePathInfo = path + fileName;
                       }
                    }
                    hdnId.Value = ContractorID;
                    CEI.IntimationDataInsertion(ContractorID, ddlworktype.SelectedItem.ToString(), txtName.Text, txtagency.Text, txtPhone.Text, txtAddress.Text
                      , txtPin.Text, ddlPremises.SelectedItem.ToString(), txtOtherPremises.Text, ddlVoltageLevel.SelectedItem.ToString(),txtinstallationType1.Text, 
                      txtinstallationNo1.Text, txtinstallationType2.Text, txtinstallationNo2.Text, txtinstallationType3.Text, txtinstallationNo3.Text, 
                      txtinstallationType4.Text, txtinstallationNo4.Text, txtinstallationType5.Text, txtinstallationNo5.Text, txtinstallationType6.Text,
                      txtinstallationNo6.Text, txtinstallationType7.Text, txtinstallationNo7.Text, txtinstallationType8.Text, txtinstallationNo8.Text,
                      txtEmail.Text, txtStartDate.Text, txtCompletitionDate.Text, ddlAnyWork.SelectedItem.ToString(), filePathInfo, txtCompletionDateAPWO.Text, ContractorID);
                   
                    string projectId = CEI.projectId();
                    if (projectId != "" && projectId != null)
                    {
                        ContractorID = Session["ContractorID"].ToString();
                        string AssignBy = ContractorID;

                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
                            {
                                Label lblREID = (Label)row.FindControl("lblREID");
                                string Reid = lblREID.Text;
                                CEI.SetDataInStaffAssined(Reid, projectId, AssignBy);

                            }
                        }
                    }
                    DataSaved.Visible = true;
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Added Successfully !!!')", true);
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
                Reset();
            }
            catch (Exception)
            {
                string errorMessage = "An error occurred: " + "Please fill all the details Carefully Your Details are wrong";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }
            
        }
        public void GetGridData()
        {
            string LoginID = string.Empty;
            LoginID = Session["ContractorID"].ToString();
            hdnId.Value = LoginID;

            DataSet ds = new DataSet();
                
            ds = CEI.WorkIntimationGridData(LoginID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
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
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch
            {
            }
        }
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

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id"] = "";
            Response.Redirect("PreviousProjects.aspx");
        }

        protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
          string Value = ddlWorkDetail.SelectedItem.ToString();
            if (ddlWorkDetail.SelectedValue != "0")
            {
                Installation.Visible= true;
                installationType1.Visible= true;
                if (string.IsNullOrEmpty(txtinstallationType1.Text))
                {
                    txtinstallationType1.Text = Value;
                }

              else  if (txtinstallationType1.Text!=string.Empty && string.IsNullOrEmpty(txtinstallationType2.Text))
                {
                    installationType2.Visible = true;
                    txtinstallationType2.Text = Value;
                } 
                else  if (string.IsNullOrEmpty(txtinstallationType3.Text))
                {
                    installationType3.Visible = true;
                    txtinstallationType3.Text = Value;
                } 
                else  if (string.IsNullOrEmpty(txtinstallationType4.Text))
                {
                    installationType4.Visible = true;
                    txtinstallationType4.Text = Value;
                } 
                else  if (string.IsNullOrEmpty(txtinstallationType5.Text))
                {
                    installationType5.Visible = true;
                    txtinstallationType5.Text = Value;
                }
                else  if (string.IsNullOrEmpty(txtinstallationType6.Text))
                {
                 
                   installationType6.Visible = true;
                    txtinstallationType6.Text = Value;
                } 
                else  if (string.IsNullOrEmpty(txtinstallationType7.Text))
                {
                    installationType7.Visible = true;
                    txtinstallationType7.Text = Value;
                }
                else  if (string.IsNullOrEmpty(txtinstallationType8.Text))
                {
                    installationType8.Visible = true;
                    txtinstallationType8.Text = Value;
                }
                if (ddlWorkDetail.SelectedValue != "0")
                {
                    ddlWorkDetail.SelectedValue = "0";
                }
            }
        }
    }
}