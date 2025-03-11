using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;


namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class LiftSiteDetails_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string SiteOwnerId = string.Empty;
        string ApplicantTypeCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_IndustryLift"] != null || Request.Cookies["SiteOwnerId_IndustryLift"] != null)
                    {
                        //if (CheckInspectionStatus())
                        //{
                        //    Response.Redirect("InspectionHistory_New_IndustryLift.aspx", false);
                        //    return;
                        //}
                        BindListBoxInstallationType();
                        BindDistrict();
                        GetDetails();
                    }
                }
            }
            catch(Exception ex)
            {

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

        public void GetDetails()
        {
            string PANNumber = Session["SiteOwnerId_IndustryLift"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetDetailsByPanNumberIdLift_IndustryLift(PANNumber);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DivOtherDepartment.Visible = false;
                DivPancard_TanNo.Visible = false;
                //string Value = ddlWorkDetail.SelectedItem.ToString();
                //if (ddlWorkDetail.SelectedValue != "0")
                //{
                //    Installation.Visible = true;
                //    installationType1.Visible = true;
                //    if (string.IsNullOrEmpty(txtinstallationType1.Text))
                //    {
                //        txtinstallationType1.Text = Value;
                //    }
                //    else if (txtinstallationType1.Text != string.Empty && string.IsNullOrEmpty(txtinstallationType2.Text))
                //    {
                //        installationType2.Visible = true;
                //        txtinstallationType2.Text = Value;
                //    }

                //    if (ddlWorkDetail.SelectedValue != "0")
                //    {
                //        try
                //        {
                //            string selectedValue = ddlWorkDetail.SelectedValue;
                //            ListItem itemToRemove = ddlWorkDetail.Items.FindByValue(selectedValue);
                //            if (itemToRemove != null)
                //            {
                //                ddlWorkDetail.Items.Remove(itemToRemove);
                //            }
                //        }
                //        catch (Exception)
                //        {
                //        }
                //        ddlWorkDetail.SelectedValue = "0";
                //    }


                //}

                ApplicantTypeCode = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();
                Session["ApplicantTypeCode_IndustryLift"] = ApplicantTypeCode;
                if (ApplicantTypeCode.ToString() == "AT001")
                {
                    //ElectricalInstallation.Visible = true;
                    DivPancard_TanNo.Visible = true;
                    txtPAN.Text = Session["SiteOwnerId_IndustryLift"].ToString();
                    txtTanNumber.Text = "";
                    PowerUtility.Visible = false;
                    NameUtility.Visible = false;
                    Wing.Visible = false;
                }
                else if (ApplicantTypeCode.ToString() == "AT003")
                {
                    //ElectricalInstallation.Visible = true;
                    PowerUtility.Visible = false;
                    NameUtility.Visible = false;
                    Wing.Visible = false;
                    txtTanNumber.Text = Session["SiteOwnerId_IndustryLift"].ToString();
                    DivOtherDepartment.Visible = true;
                    txtPAN.Text = "";
                }

                //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}");
                //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}$|^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$");
                //if (!regex.IsMatch(PANNumber))
                //{
                //    txtPAN.Focus();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid PAN/TAN card format. Please enter a valid PAN/TAN number.');", true);
                //    txtPAN.Text = "";
                //    return;
                //}


                if (Session["UserSessionData"] is Cei_IndustryServices_Redirection_IncomingJson_Model userSession)
                {
                    txtName.Text = userSession.uname;
                    txtagency.Text = userSession.businessentity;
                    txtAddress.Text = userSession.address;
                    txtEmail.Text = userSession.useremail;
                    txtPhone.Text = userSession.mobile;
                }
                txtPAN.Text = Session["SiteOwnerId_IndustryLift"].ToString();
                txtTanNumber.Text = Session["SiteOwnerId_IndustryLift"].ToString();


                //string ContractNameAgeny = ds.Tables[0].Rows[0]["username"].ToString();
                string contractorType = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                // txtPhone.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                // txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtPhone.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtWorkType.ReadOnly = true;
                txtWorkType.Text = contractorType;
                //ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(contractorType));
                //ddlworktype.Enabled = false;
                //if (contractorType == "Firm/Organization/Company/Department")
                //{
                //    agency.Visible = true;
                //    individual.Visible = false;
                //    txtagency.Text = ContractNameAgeny; 
                //    txtagency.ReadOnly = true;
                //}
                //else if (contractorType == "Individual Person")
                //{
                //    txtName.Text = ContractNameAgeny; 
                //    txtName.ReadOnly = true;
                //}
            }
            else
            {
                //ddlworktype.SelectedValue = "0";
                //ddlworktype.Enabled = true;
                txtagency.Text = "";
                txtName.Text = "";
                txtagency.ReadOnly = false;
                txtName.ReadOnly = false;
                //Page.ClientScript.RegisterStartupScript(GetType(), "panNotFound", "alert('PAN card not found in the database.');", true);
            }

        }
        protected void ddlWorkDetail_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        //private void ddlPoweUtilityBind()
        //{
        //    try
        //    {
        //        DataSet dsUtility = new DataSet();
        //        dsUtility = CEI.GetUtilityName();
        //        ddlPoweUtility.DataSource = dsUtility;
        //        ddlPoweUtility.DataTextField = "UtilityName";
        //        ddlPoweUtility.DataValueField = "Id";
        //        ddlPoweUtility.DataBind();
        //        ddlPoweUtility.Items.Insert(0, new ListItem("Select", "0"));
        //        dsUtility.Clear();
        //    }
        //    catch
        //    {
        //    }
        //}

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktypevisiblity();
        }
        protected void worktypevisiblity()
        {
            try
            {
                //if (ddlworktype.SelectedValue == "1")
                //{
                //    individual.Visible = true;
                //    agency.Visible = false;
                //    txtagency.Text = "";
                //}
                //else if (ddlworktype.SelectedValue == "2")
                //{
                //    individual.Visible = false;
                //    agency.Visible = true;
                //    txtName.Text = "";
                //}
                //else
                //{
                //    individual.Visible = true;
                //    agency.Visible = false;
                //}
            }
            catch { }

        }

        protected void ddlPoweUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlWingBind();
        }

        private void DdlWingBind()
        {
            try
            {
                string Id = ddlPoweUtility.SelectedValue.ToString();
                DataSet dsWing = new DataSet();
                dsWing = CEI.GetWingName(Id);
                DdlWing.DataSource = dsWing;
                DdlWing.DataTextField = "WingName";
                DdlWing.DataValueField = "Id";
                DdlWing.DataBind();
                DdlWing.Items.Insert(0, new ListItem("Select", "0"));
                dsWing.Clear();
            }
            catch
            {
            }

        }

        protected void DdlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlZoneBind();
        }

        private void DdlZoneBind()
        {
            try
            {
                string Id = DdlWing.SelectedValue.ToString();
                DataSet dsZone = new DataSet();
                // dsZone = CEI.GetZoneName(Id);
                DdlZone.DataSource = dsZone;
                DdlZone.DataTextField = "ZoneName";
                DdlZone.DataValueField = "Id";
                DdlZone.DataBind();
                DdlZone.Items.Insert(0, new ListItem("Select", "0"));
                dsZone.Clear();
            }
            catch
            {
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            btnSubmit.Attributes.Add("onclick", "this.disabled = true;");            
            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$"; // Regex for email
            ApplicantTypeCode = Session["ApplicantTypeCode_IndustryLift"].ToString();
            if (Regex.IsMatch(email, emailPattern))
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();
                        string Pan_TanNumber = "";
                        //bool panExists = false;


                        Debug.WriteLine("Before checking visibility and setting Pan_TanNumber");
                        if (DivPancard_TanNo.Visible || DivOtherDepartment.Visible)
                        {

                            if (DivPancard_TanNo.Visible && !string.IsNullOrEmpty(txtPAN.Text.Trim()))
                            {
                                Pan_TanNumber = txtPAN.Text.Trim();

                            }
                            else if (DivOtherDepartment.Visible && !string.IsNullOrEmpty(txtTanNumber.Text.Trim()))
                            {
                                Pan_TanNumber = txtTanNumber.Text.Trim();
                            }
                            //else if (PowerUtility.Visible)
                            //{
                            //    if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                            //    {
                            //        string email = txtEmail.Text.Trim();
                            //        if (email.Contains("@"))
                            //        {
                            //            Pan_TanNumber = email.Split('@')[0];
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Pan_TanNumber = txtUserId.Text.Trim();
                            //    }
                            //}                    
                            if (string.IsNullOrEmpty(Pan_TanNumber))
                            {
                                throw new Exception("Pan/Tan Number cannot be empty.");
                            }

                            //DataSet ds1 = CEI.checkPanNumber(Pan_TanNumber);
                            //if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                            //{
                            //    panExists = true;
                            //}
                        }
                        else if (PowerUtility.Visible)
                        {

                            Pan_TanNumber = Session["UserId_IndustryLift"].ToString();
                        }

                        transaction = connection.BeginTransaction();

                        string UpdationId = Session["UpdationId_IndustryLift"] != null ? Session["UpdationId_IndustryLift"].ToString() : null;



                        if (Session["SiteOwnerId_IndustryLift"] == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata1();", true);
                            return;
                        }

                        SiteOwnerId = Session["SiteOwnerId_IndustryLift"].ToString();
                        string filePathInfo = "";


                        hdnId.Value = SiteOwnerId;

                        //Check for null and empty values before calling IntimationDataInsertion

                        //Debug.WriteLine("Before IntimationDataInsertion");
                        //Debug.WriteLine($"ContractorID: {SiteOwnerId}, ApplicantTypeCode: {ApplicantTypeCode.ToString()}, PowerUtility: {ddlPoweUtility.SelectedItem?.ToString()}");

                        CEI.IntimationDataInsertion_New_LiftIndustry(
                         UpdationId,
                         SiteOwnerId,
                         ApplicantTypeCode.ToString(),
                         ddlPoweUtility.SelectedItem?.ToString(),
                         DdlWing.SelectedItem?.ToString(),
                         DdlZone.SelectedItem?.ToString(),
                         DdlCircle.SelectedItem?.ToString(),
                         DdlDivision.SelectedItem?.ToString(),
                         DdlSubDivision.SelectedItem?.ToString(),
                         //ddlworktype.SelectedItem?.ToString(),
                         txtWorkType.Text,
                         txtName.Text,
                         txtagency.Text,
                         txtPhone.Text,
                         txtAddress.Text,
                         divGurugramSelection.Visible == false ? txtDistrict.Text : ddlGurugram.SelectedValue,
                         txtPin.Text,
                         "",
                         "",
                         "",
                         SiteOwnerId,
                         txtinstallationType1.Text,
                         txtinstallationNo1.Text,
                         txtinstallationType2.Text,
                         txtinstallationNo2.Text,
                         "",
                         "",
                         txtEmail.Text,
                         "",
                         "",
                         "",
                        filePathInfo,
                         "",
                         txtApplicantType.Text,
                         SiteOwnerId,
                         "",
                          "New",
                          "",
                         transaction);

                        //Debug.WriteLine("After IntimationDataInsertion");

                        string projectId = CEI.projectId();
                        if (!string.IsNullOrEmpty(projectId))
                        {
                            //foreach (GridViewRow row in GridView1.Rows)
                            //{
                            //    if ((row.FindControl("CheckBox1") as CheckBox)?.Checked == true)
                            //    {
                            //        string Reid = (row.FindControl("lblREID") as Label)?.Text;
                            //        CEI.SetDataInStaffAssined(Reid, projectId, ContractorID, transaction);
                            //    }
                            //}

                            TextBox[] typeTextBoxes = { txtinstallationType1, txtinstallationType2 };
                            TextBox[] noTextBoxes = { txtinstallationNo1, txtinstallationNo2 };

                            for (int i = 0; i < typeTextBoxes.Length; i++)
                            {
                                string installationType = typeTextBoxes[i].Text;
                                string installationNoText = noTextBoxes[i].Text;

                                if (int.TryParse(installationNoText, out int installationNo) && installationNo > 0)
                                {
                                    for (int j = 0; j < installationNo; j++)
                                    {
                                        CEI.AddInstallations_New_IndustryLift(projectId, installationType, installationNo, SiteOwnerId, "New", transaction);
                                    }
                                }
                            }

                            //if (ddlPremises.SelectedItem.Text != "Industry" && PowerUtility.Visible != true)
                            //{
                            //if (!panExists)
                            //{
                            //    CEI.SiteOwnerCredentials(txtEmail.Text, Pan_TanNumber);
                            //}
                            //  }
                        }

                        transaction.Commit();
                        Reset();

                        if (btnSubmit.Text.Trim() == "Submit")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alertWithRedirectdata();", true);
                            btnSubmit.Enabled = false;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alertWithRedirectUpdation();", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        string errorMessage = ex.Message.Replace("'", "\\'");
                        ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    }
                    finally
                    {
                        transaction?.Dispose();
                        connection.Close();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please enter a valid email');", true);

            }
        }
        private void BindDistrict()
        {
            try
            {
                txtDistrict.Text = Session["district_IndustryLift"].ToString();
                // Check if the district is "Gurugram"
                if (Session["district_IndustryLift"].ToString().Equals("Gurugram", StringComparison.OrdinalIgnoreCase))
                {
                    divGurugramSelection.Visible = true;
                }
                else
                {
                    divGurugramSelection.Visible = false;
                }
            }
            catch
            {

            }
        }
        protected void imgDelete1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (installationType2.Visible == true)
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('One Installation Is Mandatory');", true);

                }
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
                if (installationType1.Visible == true)
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('One Installation Is Mandatory');", true);

                }
            }
            catch
            {
                // Handle exceptions appropriately
            }
        }
        protected void Reset()
        {
            try
            {
                if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                {
                    BindListBoxInstallationType();
                    BindDistrict();
                    GetDetails();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private bool CheckInspectionStatus()
        {
            string panNumber = null;

            if (Session["SiteOwnerId_IndustryLift"] != null)
            {
                panNumber = Session["SiteOwnerId_IndustryLift"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckAlreadyApplied_NewInspection_IndustryLift", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PANNumber", panNumber);

                    conn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result == 1;
                }
            }
        }
    }
}