using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class Upgratation_WorkIntimation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorID = string.Empty;
        string REID = string.Empty;
        string NewUserID = string.Empty;

        List<string> SelectedSupervisor = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["ContractorID"] != null || Request.Cookies["ContractorID"] != null)
                    {
                        ScriptManager scriptManager = ScriptManager.GetCurrent(this);

                        ddlLoadBindPremises();
                        worktypevisiblity();
                        ddlLoadBindVoltage();
                        BindDistrict();
                        BindListBoxInstallationType();
                        hiddenfield.Visible = false;
                        hiddenfield1.Visible = false;
                        OtherPremises.Visible = false;
                        //FileUpdate.Visible=false;   
                        //btnOpenWindow.Visible = false;

                        if (Convert.ToString(Session["id"]) == null || Convert.ToString(Session["id"]) == "")
                        {
                            Session["UpdationId"] = null;
                            //GetGridData();
                            GridView1.Columns[0].Visible = true;
                            customFile.Visible = true;
                        }
                        else
                        {
                            GetDetails();
                            GetGridData();
                            GetassigneddatatoContractor();
                            Session["PrintIntimationId"] = null;
                            //btnOpenWindow.Visible = true;
                            CheckedPriviousSupervisor();
                            Session["UpdationId"] = Session["id"];
                            Session["PrintIntimationId"] = Session["id"];
                            Session["id"] = "";
                        }
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataForAdmin(REID);

                string dp_Id24 = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                ddlApplicantType.SelectedIndex = ddlApplicantType.Items.IndexOf(ddlApplicantType.Items.FindByText(dp_Id24));
                //if (ddlApplicantType.Text.Trim() == "1")
                //{}
                //if (ddlApplicantType.SelectedIndex == 2)
                //{
                //    DivPoweUtility.Visible = true;
                //    DivPoweUtilityWing.Visible = true;
                //}
                string dp_Id14 = ds.Tables[0].Rows[0]["PowerUtility"].ToString();
                ddlPoweUtility.SelectedIndex = ddlPoweUtility.Items.IndexOf(ddlPoweUtility.Items.FindByText(dp_Id14));
                string dp_Id15 = ds.Tables[0].Rows[0]["PowerUtilityWing"].ToString();
                ddlPowerUtilityWing.SelectedIndex = ddlPowerUtilityWing.Items.IndexOf(ddlPowerUtilityWing.Items.FindByText(dp_Id15));

                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
                if (ddlworktype.Text.Trim() == "2")
                {
                    agency.Visible = true;
                    individual.Visible = false;
                }

                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                string District = ds.Tables[0].Rows[0]["District"].ToString();
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(District));
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                ddlPremises.SelectedIndex = ddlPremises.Items.IndexOf(ddlPremises.Items.FindByText(dp_Id1));
                //ddlPremises.SelectedValue = dp_Id1;
                string PanTanNumber = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                if (dp_Id24 == "Private/Personal Installation")
                {
                    DivPancard_TanNo.Visible = true;
                    txtPAN.Text = PanTanNumber;
                }
                else if (dp_Id24 == "Other Department/Organization")
                {
                    DivOtherDepartment.Visible = true;
                    txtTanNumber.Text = PanTanNumber;
                }
                else if (dp_Id24 == "Power Utility")
                {
                }

                Page.Session["OldUserID"] = PanTanNumber;

                //txtPAN.Text= ds.Tables[0].Rows[0]["PanNumber"].ToString();
                //if (txtPAN.Text.Trim() != null && txtPAN.Text.Trim() != "")
                //{
                //    DivPancard_TanNo.Visible = true;
                //}
                //txtTanNumber.Text = ds.Tables[0].Rows[0]["TanNumber"].ToString();
                //if (txtTanNumber.Text.Trim() != null && txtTanNumber.Text.Trim() != "")
                //{
                //    DivOtherDepartment.Visible = true;
                //}

                string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                // ddlVoltageLevel.SelectedValue = dp_Id3;
                ddlVoltageLevel.SelectedIndex = ddlVoltageLevel.Items.IndexOf(ddlVoltageLevel.Items.FindByText(dp_Id3));
                //          string dp_Id24 = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                // ddlVoltageLevel.SelectedValue = dp_Id3;
                //       ddlApplicantType.SelectedIndex = ddlApplicantType.Items.IndexOf(ddlApplicantType.Items.FindByText(dp_Id24));
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                Session["File"] = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();

                txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("yyyy-MM-dd");
                string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                string dp_Id10 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                string dp_Id12 = ds.Tables[0].Rows[0]["TypeOfInstallation3"].ToString();
                string dp_Id13 = ds.Tables[0].Rows[0]["NumberOfInstallation3"].ToString();
                //string dp_Id14 = ds.Tables[0].Rows[0]["TypeOfInstallation4"].ToString();
                //string dp_Id15 = ds.Tables[0].Rows[0]["NumberOfInstallation4"].ToString();
                //string dp_Id16 = ds.Tables[0].Rows[0]["TypeOfInstallation5"].ToString();
                //string dp_Id17 = ds.Tables[0].Rows[0]["NumberOfInstallation5"].ToString();
                //string dp_Id18 = ds.Tables[0].Rows[0]["TypeOfInstallation6"].ToString();
                //string dp_Id19 = ds.Tables[0].Rows[0]["NumberOfInstallation6"].ToString();
                //string dp_Id20 = ds.Tables[0].Rows[0]["TypeOfInstallation7"].ToString();
                //string dp_Id21 = ds.Tables[0].Rows[0]["NumberOfInstallation7"].ToString();
                //string dp_Id22 = ds.Tables[0].Rows[0]["TypeOfInstallation8"].ToString();
                //string dp_Id23 = ds.Tables[0].Rows[0]["NumberOfInstallation8"].ToString();
                string TestReportGenerated = ds.Tables[0].Rows[0]["TestReportGenerated"].ToString();
                if (dp_Id2 != "")
                {
                    OtherPremises.Visible = true;
                }
                if (dp_Id8 != "")
                {
                    Installation.Visible = true;
                    installationType1.Visible = true;
                    txtinstallationType1.Text = dp_Id8;
                    txtinstallationNo1.Text = dp_Id9;
                }
                else
                {
                    installationType1.Visible = false;
                }
                if (dp_Id10 != "" && dp_Id11 != "")
                {
                    Installation.Visible = true;
                    installationType2.Visible = true;
                    txtinstallationType2.Text = dp_Id10;
                    txtinstallationNo2.Text = dp_Id11;
                }
                else
                {

                    installationType2.Visible = false;
                }
                if (dp_Id12 != "")
                {
                    Installation.Visible = true;
                    installationType3.Visible = true;
                    txtinstallationType3.Text = dp_Id12;
                    txtinstallationNo3.Text = dp_Id13;
                }
                else
                {
                    installationType3.Visible = false;
                }
                //if (dp_Id14 != "")
                //{
                //    Installation.Visible = true;
                //    installationType4.Visible = true;
                //    txtinstallationType4.Text = dp_Id14;
                //    txtinstallationNo4.Text = dp_Id15;
                //}
                //if (dp_Id16 != "")
                //{
                //    Installation.Visible = true;
                //    installationType5.Visible = true;
                //    txtinstallationType5.Text = dp_Id16;
                //    txtinstallationNo5.Text = dp_Id17;
                //}
                //if (dp_Id18 != "")
                //{
                //    Installation.Visible = true;
                //    installationType6.Visible = true;
                //    txtinstallationType6.Text = dp_Id18;
                //    txtinstallationNo6.Text = dp_Id19;
                //}
                //if (dp_Id20 != "")
                //{
                //    Installation.Visible = true;
                //    installationType7.Visible = true;
                //    txtinstallationType7.Text = dp_Id20;
                //    txtinstallationNo7.Text = dp_Id21;
                //}
                //if (dp_Id22 != "")
                //{
                //    Installation.Visible = true;
                //    installationType8.Visible = true;
                //    txtinstallationType8.Text = dp_Id22;
                //    txtinstallationNo8.Text = dp_Id23;
                //}

                ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                if (dp_Id7 == "Yes")
                {

                    hiddenfield.Visible = true;
                    hiddenfield1.Visible = true;
                    customFile.Visible = false;
                    FileUpdate.Visible = true;
                    customFileLocation.Visible = false;
                    txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                }
                if (dp_Id7 == "No")
                {
                    ddlAnyWork.Enabled = false;
                }
                if (ddlVoltageLevel.SelectedValue == "650V")
                {
                    installationType2.Visible = false;
                }
                else
                {
                    installationType2.Visible = true;
                }
                //WorkDetail.Text = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                customFileLocation.Text = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                //if (TestReportGenerated.Trim() == "Yes")
                //{
                //    txtPAN.Attributes.Add("readonly", "readonly");
                //    txtTanNumber.Attributes.Add("readonly", "readonly");
                //    ddlworktype.Attributes.Add("disabled", "disabled");
                //    txtName.Attributes.Add("readonly", "readonly");
                //    txtagency.Attributes.Add("readonly", "readonly");
                //    txtPhone.Attributes.Add("readonly", "readonly");
                //    txtAddress.Attributes.Add("readonly", "readonly");
                //    ddlDistrict.Attributes.Add("disabled", "disabled");
                //    txtPin.Attributes.Add("readonly", "readonly");
                //    txtOtherPremises.Attributes.Add("readonly", "readonly");
                //    txtEmail.Attributes.Add("readonly", "readonly");
                //    ddlPremises.Attributes.Add("disabled", "disabled");
                //    ddlVoltageLevel.Attributes.Add("disabled", "disabled");
                //    ddlApplicantType.Attributes.Add("disabled", "disabled");
                //    txtinstallationNo1.Attributes.Add("disabled", "disabled");
                //    txtinstallationNo2.Attributes.Add("disabled", "disabled");
                //    txtinstallationNo3.Attributes.Add("disabled", "disabled");
                //    txtStartDate.Attributes.Add("readonly", "readonly");
                //    txtCompletitionDate.Attributes.Add("readonly", "readonly");
                //    ddlAnyWork.Attributes.Add("disabled", "disabled");
                //    txtCompletionDateAPWO.Attributes.Add("disabled", "disabled");

                //    //btnReset.Visible = false;
                //    //btnSubmit.Visible = false;
                //    btnBack.Visible = true;
                //    lnkFile.Visible = true;
                //}
                //else
                //{
                //    // btnReset.Visible = false;
                //    //btnSubmit.Visible = false;
                //    //btnSubmit.Text = "Update";
                //    btnBack.Visible = true;
                //    //InCaseUploadFile.Visible= true;
                //    lnkFile.Visible = true;
                //    //BtnUpdate1.Visible = true;
                //    //btnUpdate2.Visible = true;
                //    //btnUpdate3.Visible = true;
                //    //FileUpdate.Visible = true;
                //}
            }
            catch { }
        }
        protected void txtPAN_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string PANNumber = txtPAN.Text.Trim();

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}");
                if (!regex.IsMatch(PANNumber))
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid PAN card format. Please enter a valid PAN number.');", true);

                    return;
                }

                DataSet ds = new DataSet();
                ds = CEI.GetDetailsByPanNumberId(PANNumber);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string ContractNameAgeny = ds.Tables[0].Rows[0]["username"].ToString();
                    string contractorType = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(contractorType));
                    ddlworktype.Enabled = false;
                    if (contractorType == "Firm/Organization/Company/Department")
                    {
                        txtagency.Text = ContractNameAgeny; // ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                        txtagency.ReadOnly = true;
                    }
                    else if (contractorType == "Individual Person")
                    {
                        txtName.Text = ContractNameAgeny; //ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                        txtName.ReadOnly = true;
                    }

                }
                else
                {
                    ddlworktype.SelectedValue = "0";
                    ddlworktype.Enabled = true;
                    txtagency.Text = "";
                    txtName.Text = "";
                    txtagency.ReadOnly = false;
                    txtName.ReadOnly = false;
                }

            }
            catch (Exception ex)
            {
                // Log the exception or provide a more detailed error message
                Page.ClientScript.RegisterStartupScript(GetType(), "error", $"alert('An error occurred: {ex.Message}');", true);
            }
        
        }
        protected void worktypevisiblity()
        {
            try
            {
                if (ddlworktype.SelectedValue == "1")
                {
                    individual.Visible = true;
                    agency.Visible = false;
                    txtagency.Text = "";
                }
                else if (ddlworktype.SelectedValue == "2")
                {
                    individual.Visible = false;
                    agency.Visible = true;
                    txtName.Text = "";
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }
            }
            catch { }

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
        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            {

            }
        }
        protected void lnkFile_Click(object sender, EventArgs e)
        {

            string fileName = Session["File"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);

            }
        }
        private void ddlLoadBindVoltage()
        {
            try
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
            catch
            {
            }

        }
        protected void Reset()
        {
            try
            {
                ddlworktype.SelectedValue = "0";
                txtName.Text = "";
                txtagency.Text = "";
                ddlDistrict.SelectedValue = "0";
                ddlApplicantType.SelectedValue = "0";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtPin.Text = "";
                ddlPremises.SelectedValue = "0";
                ddlVoltageLevel.SelectedValue = "0";
                //txtOtherWorkDetail.Text = "";
                txtStartDate.Text = "";
                txtPAN.Text = "";
                Installation.Visible = false;
                txtinstallationType1.Text = "";
                txtinstallationNo1.Text = "";
                txtinstallationType2.Text = "";
                txtinstallationNo2.Text = "";
                txtinstallationType3.Text = "";
                txtinstallationNo3.Text = "";

                ddlAnyWork.SelectedValue = "0";
                txtCompletionDateAPWO.Text = "";
                foreach (ListItem item in ddlWorkDetail.Items)
                {
                    item.Selected = false;
                }
                OtherPremises.Visible = false;
                hiddenfield.Visible = false;
                hiddenfield1.Visible = false;
                txtEmail.Text = "";
            }
            catch (Exception ex) { }
        }

        public void GetGridData()
        {
            try
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
                else
                {
                    Helpline.Visible = true;
                }
            }
            catch { }
        }
        #region comment code
        //protected void HighlightGridViewRows(DataTable dataTable)
        //{
        //    // Assuming the column name is "Name"
        //    string columnName = "Name";

        //    // Find the index of the "Name" column in the DataTable
        //    int nameColumnIndex = -1;
        //    for (int i = 0; i < dataTable.Columns.Count; i++)
        //    {
        //        if (dataTable.Columns[i].ColumnName == columnName)
        //        {
        //            nameColumnIndex = i;
        //            break;
        //        }
        //    }


        //    // If the column was found, highlight rows based on the "Name" column value
        //    if (nameColumnIndex != -1 && nameColumnIndex < GridView1.Columns.Count)
        //    {
        //        foreach (GridViewRow row in GridView1.Rows)
        //        {
        //            // Check if the cell exists at the specified column index
        //            if (row.Cells.Count > nameColumnIndex)
        //            {
        //                // Get the value from the "Name" column in the DataTable
        //                string columnValue = row.Cells[nameColumnIndex].Text;

        //                // Highlight rows where the value in the "Name" column matches a value in the DataTable
        //                if (dataTable.AsEnumerable().Any(dataRow => dataRow.Field<string>(columnName) == columnValue))
        //                {
        //                    row.BackColor = System.Drawing.Color.Yellow;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // Handle case where the "Name" column was not found in the DataTable
        //        // This could indicate a data mismatch between the GridView and the DataTable
        //    }
        //}
        #endregion
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                }
            }
            catch { }
        }
        protected void ddlAnyWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlAnyWork.SelectedValue == "Yes")
                {
                    FileUpdate.Visible = true;
                    hiddenfield.Visible = true;
                    hiddenfield1.Visible = true;
                    customFile.Visible = false;
                    
                }
                else
                {
                    hiddenfield.Visible = false;
                    hiddenfield1.Visible = false;
                    hiddenfield2.Visible = false;
                    FileUpdate.Visible = false;
                }
            }
            catch { }
        }
        //protected void GetassigneddatatoContractor()
        //{
        //    try
        //    {
        //        if (!IsPostBack) // Check if it's the initial page load
        //        {
        //            string ID = string.Empty;
        //            ID = Session["id"].ToString();
        //            DataTable ds = new DataTable();
        //            ds = CEI.GetStaffAssignedToContractor(ID);
        //            if (ds.Rows.Count > 0)
        //            {
        //                GridView1.DataSource = ds;
        //                GridView1.DataBind();
        //                foreach (GridViewRow row in GridView1.Rows)
        //                {
        //                    row.BackColor = System.Drawing.Color.SkyBlue;
        //                }
        //                GetGridData();

        //            }
        //            else
        //            {
        //                GridView1.DataSource = null;
        //                GridView1.DataBind();
        //                string script = "alert(\"No Record Found\");";
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //            }
        //            ds.Dispose();
        //        }
        //    }
        //    catch
        //    {
        //        // Handle exceptions
        //    }
        //}
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
                    foreach (DataRow row in ds.Rows)
                    {
                        string SupervisorREID = row["REID"].ToString();
                        SelectedSupervisor.Add(SupervisorREID);
                    }
                }
                else
                {
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void ddlPremises_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPremises.SelectedValue == "11")
                {
                    OtherPremises.Visible = true;
                }
                else
                {
                    OtherPremises.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        //protected void Unnamed2_Click(object sender, EventArgs e)
        //{
        //    Reset();
        //}
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Session["id"] = "";
                Response.Redirect("PreviousProjects.aspx");
            }
            catch { }
        }
        protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivOtherDepartment.Visible = false;
            DivPancard_TanNo.Visible = false;
            DivPoweUtility.Visible = false;
            DivPoweUtilityWing.Visible = false;
            string Value = ddlWorkDetail.SelectedItem.ToString();
            if (ddlWorkDetail.SelectedValue != "0")
            {
                Installation.Visible = true;
                installationType1.Visible = true;
                if (string.IsNullOrEmpty(txtinstallationType1.Text))
                {
                    txtinstallationType1.Text = Value;
                }
                else if (txtinstallationType1.Text != string.Empty && string.IsNullOrEmpty(txtinstallationType2.Text))
                {
                    installationType2.Visible = true;
                    txtinstallationType2.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType3.Text))
                {
                    installationType3.Visible = true;
                    txtinstallationType3.Text = Value;
                }

                if (ddlWorkDetail.SelectedValue != "0")
                {
                    try
                    {
                        string selectedValue = ddlWorkDetail.SelectedValue;
                        ListItem itemToRemove = ddlWorkDetail.Items.FindByValue(selectedValue);
                        if (itemToRemove != null)
                        {
                            ddlWorkDetail.Items.Remove(itemToRemove);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    ddlWorkDetail.SelectedValue = "0";
                }


            }
            if (ddlApplicantType.SelectedValue == "AT001")
            {
                DivPancard_TanNo.Visible = true;
            }
            else if (ddlApplicantType.SelectedValue == "AT002")
            {
                DivPoweUtility.Visible = true;
                DivPoweUtilityWing.Visible = true;
            }
            else if (ddlApplicantType.SelectedValue == "AT003")
            {
                DivOtherDepartment.Visible = true;
            }
        }
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                string valueToAddBack = txtinstallationType1.Text;

                if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
                {
                    ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                    ddlWorkDetail.Items.Add(newItem);

                }
                installationType1.Visible = false;
                txtinstallationType1.Text = string.Empty;
                txtinstallationNo1.Text = string.Empty;
            }
            catch { }
        }
        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType2.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType2.Visible = false;
            txtinstallationType2.Text = string.Empty;
            txtinstallationNo2.Text = string.Empty;
        }
        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType3.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);
            }
            installationType3.Visible = false;
            txtinstallationType3.Text = string.Empty;
            txtinstallationNo3.Text = string.Empty;
        }
       
        protected void ddlVoltageLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                installationType2.Visible = true;
                if (ddlVoltageLevel.SelectedValue == "650V")
                {
                    installationType2.Visible = false;
                }
                else
                {
                    installationType2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        protected void ddlFileUpdated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlFileUpdated.SelectedValue == "Yes")
                {

                    hiddenfield2.Visible = true;
                    InCaseUploadFile.Visible = true;

                }
                else
                {
                    hiddenfield2.Visible = false;

                }
            }
            catch { }

        }
        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {
                ContractorID = Session["ContractorID"].ToString();
                //String CreatedBy = ContractorID;
                string UpdationId = string.Empty;
                string OldUserID = string.Empty;
                string Pan_TanNumber = "";
                if (DivPancard_TanNo.Visible == true && !string.IsNullOrEmpty(txtPAN.Text.Trim()))
                {
                    Pan_TanNumber = txtPAN.Text.Trim();
                }
                else if (DivOtherDepartment.Visible == true && !string.IsNullOrEmpty(txtTanNumber.Text.Trim()))
                {
                    Pan_TanNumber = txtTanNumber.Text.Trim();
                }
                if (Session["UpdationId"] != null)
                {
                    if (Convert.ToString(Page.Session["OldUserID"]) != null && Convert.ToString(Page.Session["OldUserID"]) !="")
                    {
                        OldUserID = Convert.ToString(Page.Session["OldUserID"]);
                        if(OldUserID == Pan_TanNumber)
                        {
                            NewUserID = "";
                        }
                        else
                        {
                            NewUserID = Pan_TanNumber;
                        }
                       
                    }

                    

                    UpdationId = Session["UpdationId"].ToString();
                    hdnId.Value = ContractorID;
                    CEI.IntimationDataInsertionForSiteOwner(UpdationId, ContractorID, ddlworktype.SelectedItem.ToString(),
                    ddlApplicantType.SelectedValue, ddlApplicantType.SelectedItem.ToString(),
                    ddlPoweUtility.SelectedValue == "0" ? null : ddlPoweUtility.SelectedItem.ToString(),
                    ddlPowerUtilityWing.SelectedValue == "0" ? null : ddlPowerUtilityWing.SelectedItem.ToString(),// txtTanNumber.Text.Trim(),
                    txtName.Text.Trim(), txtagency.Text.Trim(), txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(), ddlDistrict.SelectedItem.ToString(), txtPin.Text.Trim(),
                    OldUserID,NewUserID, txtEmail.Text.Trim(), ContractorID);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectUpdation();", true);
                }
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            try
            {
                ContractorID = Session["ContractorID"].ToString();
                string UpdationId = string.Empty;
                if (Session["UpdationId"] != null)
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            UpdationId = Session["UpdationId"].ToString();
                            hdnId.Value = ContractorID;
                            CEI.InsertionForApplicationDetails(UpdationId, ContractorID, ddlPremises.SelectedItem.ToString(), txtOtherPremises.Text.Trim(),
                                    ddlVoltageLevel.SelectedItem.ToString(), txtinstallationType1.Text.Trim(), txtinstallationNo1.Text.Trim(), txtinstallationType2.Text.Trim(),
                                    txtinstallationNo2.Text.Trim(), txtinstallationType3.Text.Trim(), txtinstallationNo3.Text.Trim(), ContractorID, transaction);
                            string LoginID = string.Empty;
                            LoginID = Session["UpdationId"].ToString();
                            TextBox[] typeTextBoxes = new TextBox[] { txtinstallationType1, txtinstallationType2, txtinstallationType3 };
                            TextBox[] noTextBoxes = new TextBox[] { txtinstallationNo1, txtinstallationNo2, txtinstallationNo3 };

                            for (int i = 0; i < typeTextBoxes.Length; i++)
                            {

                                string installationType = typeTextBoxes[i].Text;
                                string installationNoText = noTextBoxes[i].Text;

                                int installationNo;
                                if (int.TryParse(installationNoText, out installationNo) && installationNo > 0)
                                {
                                    CEI.AddInstallations2(LoginID, installationType, installationNo, ContractorID,transaction);
                                }
                            }
                            transaction.Commit();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectUpdation();", true);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            string errorMessage = ex.Message;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnUpdate3_Click(object sender, EventArgs e)
        {
            try
            {
                ContractorID = Session["ContractorID"].ToString();
                string UpdationId = string.Empty;
                if (Session["UpdationId"] != null)
                {
                    UpdationId = Session["UpdationId"].ToString();
                    string filePathInfo1 = "";
                    if (ddlFileUpdated.SelectedValue == "Yes")
                    {
                        if (InCaseUploadFile.HasFile)
                        {
                            try
                            {
                                string fileName = Path.GetFileName(InCaseUploadFile.FileName);
                                if (!string.IsNullOrEmpty(fileName))
                                {

                                    string ext = Path.GetExtension(fileName);
                                    string directoryPath = Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/");

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }


                                    string uniqueFileName = "CopyOfWorkOrder_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;


                                    string filePath = Path.Combine(directoryPath, uniqueFileName);


                                    InCaseUploadFile.SaveAs(filePath);


                                    filePathInfo1 = "/Attachment/" + ContractorID + "/Copy of Work Order/" + uniqueFileName;
                                }
                            }
                            catch (Exception ex)
                            {

                                string errorMessage = "An error occurred: " + ex.Message;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                                return;
                            }
                        }

                    }
                    hdnId.Value = ContractorID;
                    CEI.InsertionForWorkScheduleInWoIntimation(UpdationId, ContractorID, txtStartDate.Text.Trim(),
                        txtCompletitionDate.Text.Trim(), ddlAnyWork.SelectedItem.ToString(), filePathInfo1, txtCompletionDateAPWO.Text.Trim(),
                     ContractorID);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectUpdation();", true);

                }



            }
            catch (Exception ex)
            {
            }

        }
        private void CheckedPriviousSupervisor()
        {
            if (SelectedSupervisor != null)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox checkSelect = (CheckBox)row.FindControl("CheckBox1");
                    Label lblREID = (Label)row.FindControl("lblREID");
                    if (lblREID != null)
                    {
                        string REID = lblREID.Text;
                        if (SelectedSupervisor.Contains(REID))
                        {
                            checkSelect.Checked = true;
                        }
                    }
                }
            }
        }
        protected void btnUpdate4_Click(object sender, EventArgs e)
        {
            String IntimationID = Session["UpdationId"]?.ToString(); // Ensure safe access
            ContractorID = Session["ContractorID"]?.ToString(); // Ensure safe access

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string AssignBy = ContractorID;
                    bool atLeastOneChecked = false;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk.Checked)
                        {
                            atLeastOneChecked = true;
                            break;
                        }
                    }

                    if (atLeastOneChecked)
                    {

                        int x = CEI.RemovePrivousSupervisiorToContractor(IntimationID, transaction);
                        if (x >= 0)
                        {
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                                if (chk.Checked)
                                {
                                    Label lblREID = (Label)row.FindControl("lblREID");
                                    string Reid = lblREID.Text;
                                    CEI.AssignSupervisiorToContractor(IntimationID, Reid, AssignBy, transaction);
                                }
                            }
                            transaction.Commit();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectUpdation();", true);
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('Please select at least one supervisor.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //string errorMessage = ex.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "UpdationErrorMessage();", true);
                }
            }
        }

        protected void txtTanNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string TANNumber = txtTanNumber.Text.Trim();
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}");
                if (!regex.IsMatch(TANNumber))
                {
                    txtTanNumber.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid TAN Number format. Please enter a valid TAN number.');", true);
                    return;
                }
                DataSet ds = new DataSet();
                ds = CEI.GetDetailsByPanNumberId(TANNumber);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string ContractNameAgeny = ds.Tables[0].Rows[0]["username"].ToString();
                    string contractorType = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(contractorType));
                    ddlworktype.Enabled = false;
                    if (contractorType == "Firm/Organization/Company/Department")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                        txtagency.Text = ContractNameAgeny; // ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                        txtagency.ReadOnly = true;
                    }
                    else if (contractorType == "Individual Person")
                    {
                        individual.Visible = true;
                        agency.Visible = false;
                        txtName.Text = ContractNameAgeny; //ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                        txtName.ReadOnly = true;
                    }
                    
                }
                else
                {
                    ddlworktype.SelectedValue = "0";
                    ddlworktype.Enabled = true;
                    txtagency.ReadOnly = false;
                    txtName.ReadOnly = false;
                    txtagency.Text = "";
                    txtName.Text = "";                  
                }

            }
            catch (Exception ex)
            {
                // Log the exception or provide a more detailed error message
                Page.ClientScript.RegisterStartupScript(GetType(), "error", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}