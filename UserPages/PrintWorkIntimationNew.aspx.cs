using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class PrintWorkIntimationNew : System.Web.UI.Page
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
                        //hiddenfield.Visible = false;
                        hiddenfield1.Visible = false;
                        OtherPremises.Visible = false;

                        if (Convert.ToString(Session["PrintIntimationId"]) == null || Convert.ToString(Session["PrintIntimationId"]) == "")
                        {
                            Session["UpdationId"] = null;
                            GetGridData();
                            GridView1.Columns[0].Visible = true;
                            //customFile.Visible = true;
                            GetDetails();
                        }
                        else
                        {
                            GetDetails();
                            GetassigneddatatoContractor();
                           
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

        protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            TanNumber.Visible = false;
            DivPancard_PanNo.Visible = false;
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
                //else if (string.IsNullOrEmpty(txtinstallationType4.Text))
                //{
                //    installationType4.Visible = true;
                //    txtinstallationType4.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType5.Text))
                //{
                //    installationType5.Visible = true;
                //    txtinstallationType5.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType6.Text))
                //{

                //    installationType6.Visible = true;
                //    txtinstallationType6.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType7.Text))
                //{
                //    installationType7.Visible = true;
                //    txtinstallationType7.Text = Value;
                //}
                //else if (string.IsNullOrEmpty(txtinstallationType8.Text))
                //{
                //    installationType8.Visible = true;
                //    txtinstallationType8.Text = Value;
                //}
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
                DivPancard_PanNo.Visible = true;
            }
            else if (ddlApplicantType.SelectedValue == "AT002")
            {
                DivPoweUtility.Visible = true;
                DivPoweUtilityWing.Visible = true;
            }
            else if (ddlApplicantType.SelectedValue == "AT003")
            {
                TanNumber.Visible = true;
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            if (Session["File"].ToString() != "" && Session["File"].ToString() != null)
            {
                string fileName = Session["File"].ToString();
                string filePath = "https://uat.ceiharyana.com" + fileName;
          
                string script = $@"<script>window.open('{filePath}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
        }
        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktypevisiblity();
        }
        protected void GetassigneddatatoContractor()
        {
            try
            {
                string ID = string.Empty;
                ID = Session["PrintIntimationId"].ToString();
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
        protected void GetDetails()
        {
            try
            {
                REID = Session["PrintIntimationId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetWorkIntimationDataForPrint(REID);

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
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pincode"].ToString()))
                {
                    pin.Visible = false;
                }
                else
                {
                    pin.Visible = true;
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                }                
                string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                ddlPremises.SelectedIndex = ddlPremises.Items.IndexOf(ddlPremises.Items.FindByText(dp_Id1));
                string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                if (dp_Id24 == "Private/Personal Installation")
                {                    
                    DivPancard_PanNo.Visible = true;
                    txtPAN.Text = PanTanNumber;
                }
                else if (dp_Id24 == "Other Department/Organization")
                {                   
                    TanNumber.Visible = true;
                    txtTanNumber.Text = PanTanNumber;
                }
                string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
             
                ddlVoltageLevel.SelectedIndex = ddlVoltageLevel.Items.IndexOf(ddlVoltageLevel.Items.FindByText(dp_Id3));
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("dd-MM-yyyy");
                //txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                Session["File"] = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                //txtCompletitionDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("dd-MM-yyyy");
                string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                string dp_Id10 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                string dp_Id11 = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                string dp_Id12 = ds.Tables[0].Rows[0]["TypeOfInstallation3"].ToString();
                string dp_Id13 = ds.Tables[0].Rows[0]["NumberOfInstallation3"].ToString();
                txtwIpID.Text = ds.Tables[0].Rows[0]["id"].ToString();

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


                ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                if (dp_Id7 == "Yes")
                {

                   // hiddenfield.Visible = true;
                    hiddenfield1.Visible = true;
                    //customFile.Visible = false;
                    //customFileLocation.Visible = false;
                    txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("dd-MM-yyyy");
                }
                if (ddlVoltageLevel.SelectedValue == "650V")
                {
                    installationType2.Visible = false;
                }
                else
                {
                    installationType2.Visible = true;
                }

                //customFileLocation.Text = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                if (TestReportGenerated.Trim() == "Yes")
                {
                    txtPAN.Attributes.Add("readonly", "readonly");
                    txtwIpID.Attributes.Add("readonly", "readonly");
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
                    txtState.Attributes.Add("disabled", "disabled");


                    //lnkFile.Visible = true;
                }
                else
                {

                 
                   //lnkFile.Visible = true;
                }

                string createdDateString = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                DateTime createdDate;
                if (DateTime.TryParse(createdDateString, out createdDate))
                {
                    txtCreatedDate.Text = createdDate.ToString("dd-MM-yyyy");
                }
                txtCreatedBy.Text = ds.Tables[0].Rows[0]["ContractorCreated"].ToString();

            }
            catch { }
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




    }
}