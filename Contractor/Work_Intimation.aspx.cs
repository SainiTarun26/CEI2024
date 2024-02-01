using CEI_PRoject;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana.Contractor
{
    public partial class Work_Intimation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorID = string.Empty;
        string REID = string.Empty;
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

                        if (Convert.ToString(Session["id"]) == null || Convert.ToString(Session["id"]) == "")
                        {

                            GetGridData();
                            GridView1.Columns[0].Visible = true;
                            customFile.Visible = true;
                        }
                        else
                        {

                            GetDetails();
                            GetassigneddatatoContractor();
                            Session["UpdationId"] =  Session["id"] ;
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
                // DivInstallationType.Visible = false;
                REID = Session["id"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataForAdmin(REID);
                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
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
                txtPAN.Text = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                // ddlVoltageLevel.SelectedValue = dp_Id3;
                ddlVoltageLevel.SelectedIndex = ddlVoltageLevel.Items.IndexOf(ddlVoltageLevel.Items.FindByText(dp_Id3));
                string dp_Id24 = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                // ddlVoltageLevel.SelectedValue = dp_Id3;
                ddlApplicantType.SelectedIndex = ddlApplicantType.Items.IndexOf(ddlApplicantType.Items.FindByText(dp_Id24));
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                Session["File"] = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                string dp_Id10 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                string dp_Id12 = ds.Tables[0].Rows[0]["TypeOfInstallation3"].ToString();
                string dp_Id13 = ds.Tables[0].Rows[0]["NumberOfInstallation3"].ToString();
                string dp_Id14 = ds.Tables[0].Rows[0]["TypeOfInstallation4"].ToString();
                string dp_Id15 = ds.Tables[0].Rows[0]["NumberOfInstallation4"].ToString();
                string dp_Id16 = ds.Tables[0].Rows[0]["TypeOfInstallation5"].ToString();
                string dp_Id17 = ds.Tables[0].Rows[0]["NumberOfInstallation5"].ToString();
                string dp_Id18 = ds.Tables[0].Rows[0]["TypeOfInstallation6"].ToString();
                string dp_Id19 = ds.Tables[0].Rows[0]["NumberOfInstallation6"].ToString();
                string dp_Id20 = ds.Tables[0].Rows[0]["TypeOfInstallation7"].ToString();
                string dp_Id21 = ds.Tables[0].Rows[0]["NumberOfInstallation7"].ToString();
                string dp_Id22 = ds.Tables[0].Rows[0]["TypeOfInstallation8"].ToString();
                string dp_Id23 = ds.Tables[0].Rows[0]["NumberOfInstallation8"].ToString();
                string TestReportGenerated = ds.Tables[0].Rows[0]["TestReportGenerated"].ToString();

                if (dp_Id8 != "")
                {
                    Installation.Visible = true;
                    installationType1.Visible = true;
                    txtinstallationType1.Text = dp_Id8;
                    txtinstallationNo1.Text = dp_Id9;
                }
                else
                {
                   // Installation.Visible = false;
                    installationType1.Visible = false;
                }
                if (dp_Id10 != "")
                {
                    Installation.Visible = true;
                    installationType2.Visible = true;
                    txtinstallationType2.Text = dp_Id10;
                    txtinstallationNo2.Text = dp_Id11;
                }
                else
                {

                   // Installation.Visible = false;
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

                  //  Installation.Visible = false;
                    installationType3.Visible = false;
                }
                if (dp_Id14 != "")
                {
                    Installation.Visible = true;
                    installationType4.Visible = true;
                    txtinstallationType4.Text = dp_Id14;
                    txtinstallationNo4.Text = dp_Id15;
                }
                if (dp_Id16 != "")
                {
                    Installation.Visible = true;
                    installationType5.Visible = true;
                    txtinstallationType5.Text = dp_Id16;
                    txtinstallationNo5.Text = dp_Id17;
                }
                if (dp_Id18 != "")
                {
                    Installation.Visible = true;
                    installationType6.Visible = true;
                    txtinstallationType6.Text = dp_Id18;
                    txtinstallationNo6.Text = dp_Id19;
                }
                if (dp_Id20 != "")
                {
                    Installation.Visible = true;
                    installationType7.Visible = true;
                    txtinstallationType7.Text = dp_Id20;
                    txtinstallationNo7.Text = dp_Id21;
                }
                if (dp_Id22 != "")
                {
                    Installation.Visible = true;
                    installationType8.Visible = true;
                    txtinstallationType8.Text = dp_Id22;
                    txtinstallationNo8.Text = dp_Id23;
                }

                ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                if (dp_Id7 == "Yes")
                {

                    hiddenfield.Visible = true;
                    hiddenfield1.Visible = true;
                    customFile.Visible = false;
                    customFileLocation.Visible = false;
                    txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                }
                //  WorkDetail.Text = ds.Tables[0].Rows[0]["WorkDetails"].ToString();
                customFileLocation.Text = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                if (TestReportGenerated.Trim() == "Yes") {
                    txtPAN.Attributes.Add("readonly", "readonly");
                    ddlworktype.Attributes.Add("disabled", "disabled");
                    txtName.Attributes.Add("readonly", "readonly");
                    txtagency.Attributes.Add("readonly", "readonly");
                    txtPhone.Attributes.Add("readonly", "readonly");
                    txtAddress.Attributes.Add("readonly", "readonly");
                    ddlDistrict.Attributes.Add("disabled", "disabled");
                    txtPin.Attributes.Add("readonly", "readonly");
                    txtOtherPremises.Attributes.Add("readonly", "readonly");
                    txtEmail.Attributes.Add("readonly", "readonly");
                    ddlPremises.Attributes.Add("disabled", "disabled");
                    ddlVoltageLevel.Attributes.Add("disabled", "disabled");
                    ddlApplicantType.Attributes.Add("disabled", "disabled");
                    txtinstallationNo1.Attributes.Add("disabled", "disabled");
                    txtinstallationNo2.Attributes.Add("disabled", "disabled");
                    txtinstallationNo3.Attributes.Add("disabled", "disabled");
                    txtStartDate.Attributes.Add("readonly", "readonly");
                    txtCompletitionDate.Attributes.Add("readonly", "readonly");
                    ddlAnyWork.Attributes.Add("disabled", "disabled");
                    txtCompletionDateAPWO.Attributes.Add("disabled", "disabled");

                    btnReset.Visible = false;
                    btnSubmit.Visible = false;
                    btnBack.Visible = true;
                    lnkFile.Visible = true;
                }
                else
                {

                    btnReset.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Text = "Update";
                    btnBack.Visible = true;
                    lnkFile.Visible = true;
                }
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
                    string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    string District = ds.Tables[0].Rows[0]["District"].ToString();
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(District));
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtPAN.Text = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                else
                {
                   // Page.ClientScript.RegisterStartupScript(GetType(), "panNotFound", "alert('PAN card not found in the database.');", true);
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
                txtinstallationType4.Text = "";
                txtinstallationNo4.Text = "";
                txtinstallationType5.Text = "";
                txtinstallationNo5.Text = "";
                txtinstallationType6.Text = "";
                txtinstallationNo6.Text = "";
                txtinstallationType7.Text = ""; txtinstallationNo7.Text = ""; txtinstallationType8.Text = ""; txtinstallationNo8.Text = "";
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
            catch (Exception) { }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string UpdationId = string.Empty;
                if (Session["UpdationId"] != null)
                {
                     UpdationId = Session["UpdationId"].ToString();
                }
                else
                {
                    UpdationId = null;

                }
                bool atLeastOneSupervisorChecked = false;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    
                    Label lblCategory = (Label)row.FindControl("lblCategory"); 
                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    if (lblCategory != null && lblCategory.Text == "Supervisor" && chk != null && chk.Checked)
                    {
                        atLeastOneSupervisorChecked = true;
                        break;
                    }
                }

                if (!atLeastOneSupervisorChecked && btnSubmit.Text !="Update")
                {
                    // No Supervisor checkbox is selected
                    // Add your logic or show a message here
                    Response.Write("<script>alert('Please select at least one Supervisor.');</script>");
                    return;
                }
                else
                {
                    string mobilenumber = txtPhone.Text.Trim();
                    if (Session["ContractorID"] != null)
                    {

                        ContractorID = Session["ContractorID"].ToString();

                        string filePathInfo = "";
                        if (ddlAnyWork.SelectedValue == "Yes")
                        {
                            try
                            {
                                string FilName = string.Empty;
                                //if (customFile.PostedFile.FileName.Length > 0)
                                //{
                                FilName = Path.GetFileName(customFile.PostedFile.FileName);
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/"));
                                }

                                string ext = customFile.PostedFile.FileName.Split('.')[1];
                                string path = "";
                                path = "/Attachment/" + ContractorID + "/Copy of Work Order/";
                                string fileName = "Copy of Work Order" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                                string filePathInfo2 = "";
                                filePathInfo2 = Server.MapPath("~/Attachment/" + ContractorID + "/Copy of Work Order/" + fileName);
                                customFile.PostedFile.SaveAs(filePathInfo2);
                                filePathInfo = path + fileName;
                                // }
                            }
                            catch (Exception ex)
                            {
                                string errorMessage = "An error occurred: " + "Please Add Copy Of work Order";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                            }
                        }

                       
                        hdnId.Value = ContractorID;
                        CEI.IntimationDataInsertion(UpdationId,ContractorID, ddlworktype.SelectedItem.ToString(), txtName.Text, txtagency.Text, txtPhone.Text, 
                            txtAddress.Text,ddlDistrict.SelectedItem.ToString(), txtPin.Text, ddlPremises.SelectedItem.ToString(), txtOtherPremises.Text, 
                            ddlVoltageLevel.SelectedItem.ToString(),txtPAN.Text,txtinstallationType1.Text,txtinstallationNo1.Text, txtinstallationType2.Text,
                            txtinstallationNo2.Text, txtinstallationType3.Text,txtinstallationNo3.Text,txtinstallationType4.Text, txtinstallationNo4.Text,
                            txtinstallationType5.Text, txtinstallationNo5.Text, txtinstallationType6.Text,txtinstallationNo6.Text, txtinstallationType7.Text, 
                            txtinstallationNo7.Text, txtinstallationType8.Text, txtinstallationNo8.Text,txtEmail.Text, txtStartDate.Text,
                            txtCompletitionDate.Text, ddlAnyWork.SelectedItem.ToString(), filePathInfo, txtCompletionDateAPWO.Text,
                          ddlApplicantType.SelectedItem.ToString(), ContractorID);

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
                        TextBox[] typeTextBoxes = new TextBox[] { txtinstallationType1, txtinstallationType2, txtinstallationType3 };
                        TextBox[] noTextBoxes = new TextBox[] { txtinstallationNo1, txtinstallationNo2, txtinstallationNo3 };

                        for (int i = 0; i < typeTextBoxes.Length; i++)
                        {
                            string installationType = typeTextBoxes[i].Text;
                            string installationNoText = noTextBoxes[i].Text;

                            int installationNo;

                            if (int.TryParse(installationNoText, out installationNo) && installationNo > 0)
                            {
                                // Save data according to the number of installations
                                for (int j = 0; j < installationNo; j++)
                                {
                                    CEI.AddInstallations(projectId, installationType, installationNo);
                                }
                            }
                        }
                        CEI.SiteOwnerCredentials(txtEmail.Text, txtPAN.Text);
                        if (btnSubmit.Text.Trim() =="Submit") {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectUpdation();", true);
                        }



                    }

                    else
                    {
                        Response.Redirect("/Login.aspx", false);
                    }
                    Reset();
                }
            }
            catch (Exception)
            {
                string errorMessage = "An error occurred: " + "Please fill all the details Carefully Your Details are wrong";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }

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
            }
            catch { }
        }


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

                    hiddenfield.Visible = true;
                    hiddenfield1.Visible = true;
                }
                else
                {
                    hiddenfield.Visible = false;
                    hiddenfield1.Visible = false;
                }
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
            try
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
            catch { }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Reset();
        }

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
                else if (string.IsNullOrEmpty(txtinstallationType4.Text))
                {
                    installationType4.Visible = true;
                    txtinstallationType4.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType5.Text))
                {
                    installationType5.Visible = true;
                    txtinstallationType5.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType6.Text))
                {

                    installationType6.Visible = true;
                    txtinstallationType6.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType7.Text))
                {
                    installationType7.Visible = true;
                    txtinstallationType7.Text = Value;
                }
                else if (string.IsNullOrEmpty(txtinstallationType8.Text))
                {
                    installationType8.Visible = true;
                    txtinstallationType8.Text = Value;
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

        protected void btnDelete4_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType4.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType4.Visible = false;
            txtinstallationType4.Text = string.Empty;
            txtinstallationNo4.Text = string.Empty;
        }

        protected void btnDelete5_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType5.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType5.Visible = false;
            txtinstallationType5.Text = string.Empty;
            txtinstallationNo5.Text = string.Empty;
        }

        protected void btnDelete6_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType6.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType6.Visible = false;
            txtinstallationType6.Text = string.Empty;
            txtinstallationNo6.Text = string.Empty;
        }

        protected void btnDelete7_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType7.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType7.Visible = false;
            txtinstallationType7.Text = string.Empty;
            txtinstallationNo7.Text = string.Empty;
        }

        protected void btnDelete8_Click(object sender, EventArgs e)
        {
            string valueToAddBack = txtinstallationType8.Text;

            if (ddlWorkDetail.Items.FindByValue(valueToAddBack) == null)
            {
                ListItem newItem = new ListItem(valueToAddBack, valueToAddBack);
                ddlWorkDetail.Items.Add(newItem);

            }
            installationType8.Visible = false;
            txtinstallationType8.Text = string.Empty;
            txtinstallationNo8.Text = string.Empty;
        }

        protected void imgDelete1_Click(object sender, ImageClickEventArgs e)
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
            catch
            {
                // Handle exceptions appropriately
            }
        }

        protected void imgDelete2_Click(object sender, ImageClickEventArgs e)
        {
            try
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
            catch
            {
                // Handle exceptions appropriately
            }
        }
        protected void imgDelete3_Click(object sender, ImageClickEventArgs e)
        {
            try
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
            catch { }
        }


       
    }
}