using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEI_PRoject.Admin
{
    public partial class AddSupervisorDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        public string UserId;
        public string Qualification;
        string REID = string.Empty;
        string ipaddress;
        string NewUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            try
            {
                if (!IsPostBack)
                {
                    if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                    {
                        if (Request.Cookies["AdminID"] != null)
                        {
                            UserId = Request.Cookies["AdminID"].Value;
                        }
                        else
                        {
                            UserId = Session["AdminID"].ToString();
                        }
                        rowContractorDetails.Visible = false;
                        ddlLoadBindState();
                        ddlLoadBindVoltage();
                        ddlQualificationBind();

                        if (Convert.ToString(Session["ID"]) == null || Convert.ToString(Session["ID"]) == "")
                        {
                            rowContractorDetails.Visible = false;
                        }
                        else
                        {
                            string REID = Session["ID"].ToString();
                            hdnId.Value = REID;
                            btnSubmit.Text = "Update";
                            BtnReset.Visible = false;
                            GetDetails();
                            Session["ID"] = "";
                        }
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        private void ddlQualificationBind()
        {
            try
            {
                DataSet dsQualification = new DataSet();
                dsQualification = CEI.GetQualification();
                ddlQualification.DataSource = dsQualification;
                ddlQualification.DataTextField = "Qualificaton";
                ddlQualification.DataValueField = "QualificationValue";
                ddlQualification.DataBind();
                ddlQualification.Items.Insert(0, new ListItem("Select", "0"));
                dsQualification.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        #region Dropdown Bind for State
        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlState.DataSource = dsState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        #endregion
        #region Dropdown Bind for District
        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        #endregion
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
        private void GetContractorDetails()
        {

            DataSet dsContractor = new DataSet();
            dsContractor = CEI.GetContractorData();
            ddlContractorDetails.DataSource = dsContractor;
            ddlContractorDetails.DataTextField = "ContractorData";
            ddlContractorDetails.DataValueField = "ContractorID";
            ddlContractorDetails.DataBind();
            ddlContractorDetails.Items.Insert(0, new ListItem("Select", "0"));
            dsContractor.Clear();

        }
        protected string ConvertDate(string date)
        {
            string D1;
            string[] str = date.Split('/');
            D1 = str[2] + "-" + str[1] + "-" + str[0];
            return D1;
        }
        public void GetDetails()
        {
            REID = hdnId.Value;
            DataSet ds = new DataSet();
            ds = CEI.GetSupervisorData(REID);
            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            FatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
            Address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            string dp_Id4 = ds.Tables[0].Rows[0]["State"].ToString();
            string dp_Id5 = ds.Tables[0].Rows[0]["District"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
            ContactNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
            Email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            string dp_Id9 = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
            string dp_Id10 = ds.Tables[0].Rows[0]["DateofExpiry"].ToString();
            string dp_Id11 = ds.Tables[0].Rows[0]["DateofRenewal"].ToString();
            ddlVoltageLevel.SelectedValue = ds.Tables[0].Rows[0]["votagelevel"].ToString();
            string dp_Id13 = ds.Tables[0].Rows[0]["voltageWithEffect"].ToString();
            CertificateOld.Text = ds.Tables[0].Rows[0]["CertificateOld"].ToString();
            CertificateNew.Text = ds.Tables[0].Rows[0]["CertificateNew"].ToString();
            if (CertificateNew.Text.Length > 0)
                Page.Session["PreviousUserID"] = CertificateNew.Text + "|New";
            else
                Page.Session["PreviousUserID"] = CertificateOld.Text + "|Old";
            string dp_Id16 = ds.Tables[0].Rows[0]["Qualification"].ToString();
            string dp_Id17 = ds.Tables[0].Rows[0]["AnyContractor"].ToString();
            string dp_Id18 = ds.Tables[0].Rows[0]["ContractorID"].ToString();
            string dp_Id19 = ds.Tables[0].Rows[0]["Age"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id4));
            ddlLoadBindDistrict(dp_Id4);
            ddlDistrict.SelectedValue = dp_Id5;
            DateofIntialissue.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
            DateofRenewal.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
            DateofExpiry.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
            voltageWithEffect.Text = DateTime.Parse(dp_Id13).ToString("yyyy-MM-dd");
            txtAge.Text = DateTime.Parse(dp_Id19).ToString("yyyy-MM-dd");
            if (Regex.IsMatch(dp_Id16, @"^\d+$"))
            {
                ddlQualification.SelectedValue = dp_Id16;
            }
            else
            {
                ddlQualification.SelectedValue = "8";
                txtQualification.Visible = true;
                txtQualifications.Text = dp_Id16;
            }
            if (dp_Id17 == "Yes")
            {
                ddlAttachedContractor.SelectedValue = "Yes";
                rowContractorDetails.Visible = true;
                GetContractorDetails();
                ddlContractorDetails.SelectedIndex = ddlContractorDetails.Items.IndexOf(ddlContractorDetails.Items.FindByValue(dp_Id18));
            }
            else
            {
                ddlAttachedContractor.SelectedValue = "No";
                rowContractorDetails.Visible = false;
            }

        }

        #region GetIP
        protected void GetIP()
        {

            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                REID = hdnId.Value;

                if (txtQualification.Visible == true)
                {

                    Qualification = txtQualifications.Text;
                }
                else
                {
                    Qualification = ddlQualification.SelectedValue;
                }

                if (CertificateNew.Text.Trim() != "" && CertificateNew.Text.Trim() != null)
                {
                    UserId = CertificateNew.Text.Trim();
                }
                else
                {
                    UserId = CertificateOld.Text.Trim();
                }
                if (btnSubmit.Text.Trim() == "Submit")
                {
                    DataSet ds1 = new DataSet();
                    ds1 = CEI.checkCertificateexist(CertificateOld.Text.Trim(), CertificateNew.Text.Trim());
                    if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        string alertScript = "alert('The  Certificate number is already in use. Please provide a different Certificate number.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                }
                else if (btnSubmit.Text.Trim() == "Update")
                {
                    if (Convert.ToString(Session["PreviousUserID"]) != "" && Convert.ToString(Session["PreviousUserID"]) != null)
                    {
                        string MySession = Session["PreviousUserID"].ToString();
                        string[] str = MySession.Split('|');
                        UserId = str[0];
                        if (str[1] == "New")
                        {
                            if (UserId == CertificateNew.Text)
                            {
                                NewUserID = "";
                            }
                            else
                            {
                                NewUserID = CertificateNew.Text;
                            }
                        }
                        else
                        {
                            if (CertificateNew.Text.Length > 0)
                            {
                                NewUserID = CertificateNew.Text;
                            }
                            else
                            {
                                if (UserId == CertificateOld.Text)
                                {
                                    NewUserID = "";
                                }
                                else
                                {
                                    NewUserID = CertificateOld.Text;
                                }
                            }
                        }
                    }

                    DataSet ds1 = new DataSet();
                    ds1 = CEI.checkCertificateexistupdated(CertificateOld.Text.Trim(), CertificateNew.Text.Trim(), REID);
                    if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        string alertScript = "alert('The  Certificate number is already in use. Please provide a different Certificate number.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                }

                GetIP();

                if (Session["AdminID"] != null)
                {
                    string Createdby = Convert.ToString(Session["AdminID"]);
                    CEI.InserSupervisorData(REID, txtName.Text, txtAge.Text, FatherName.Text, Address.Text, ddlDistrict.SelectedItem.ToString(),
                     ddlState.SelectedItem.ToString(), txtPincode.Text, ContactNo.Text, Qualification, Email.Text, CertificateOld.Text.Trim(), CertificateNew.Text.Trim(),
                     DateofIntialissue.Text, DateofExpiry.Text, string.IsNullOrEmpty(DateofRenewal.Text) ? null : DateofRenewal.Text, ddlVoltageLevel.Text, voltageWithEffect.Text,
                     ddlAttachedContractor.SelectedValue, ddlContractorDetails.SelectedValue, Createdby, UserId, NewUserID, ipaddress);
                    if (btnSubmit.Text == "Update")
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Updated Successfully !!!')", true);
                        Session["ID"] = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectData();", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Inserted Successfully !!!')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }

                }
                else
                {
                    Response.Redirect("/Login.aspx", false);
                }
                Reset();
            }
            catch (Exception Ex)
            {
                if (Ex.Message.StartsWith("Error converting data type nvarchar to date"))
                {
                    string alertScript = "alert('Error: Incorrect Date\\n\\nThe Date is Incorrect please select a valid date.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }
            }

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlLoadBindDistrict(ddlState.SelectedItem.ToString());

        }
        protected void ddlAttachedContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAttachedContractor.SelectedValue == "Yes")
            {
                rowContractorDetails.Visible = true;
                GetContractorDetails();
            }
            else
            {
                rowContractorDetails.Visible = false;
            }
        }
        protected void Reset()
        {
            txtName.Text = "";
            FatherName.Text = "";
            Address.Text = "";
            txtAge.Text = "";
            ddlDistrict.SelectedIndex = 0;
            ddlState.SelectedIndex = -1;
            ContactNo.Text = "";
            ddlQualification.SelectedIndex = 0;
            Email.Text = "";
            CertificateOld.Text = "";
            CertificateNew.Text = "";
            DateofIntialissue.Text = "";
            DateofExpiry.Text = "";
            DateofRenewal.Text = "";
            ddlVoltageLevel.SelectedIndex = 0;
            voltageWithEffect.Text = "";
            ddlAttachedContractor.SelectedIndex = 0;
            txtPincode.Text = "";
            rowContractorDetails.Visible = false;
            txtQualification.Visible = false;
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();

        }


        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedItem.ToString() == "Other")
            {
                txtQualification.Visible = true;

            }
            else
            {
                txtQualification.Visible = false;
            }
        }

        protected void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAge.Text != "")
            {
                DateTime selectedDOB;
                if (DateTime.TryParse(txtAge.Text, out selectedDOB))
                {

                    DateTime currentDate = DateTime.Now;
                    int ageDiff = currentDate.Year - selectedDOB.Year;

                    if (DateTime.TryParseExact(txtAge.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dobDate))
                    {

                        if (dobDate > currentDate)
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert('Invalid Date !!!')", true);
                            txtAge.Text = "";
                        }

                        else if (ageDiff < 18)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You must be at least 18 years old.');", true);

                            txtAge.Text = "";

                        }
                        else
                        {

                        }
                    }
                }
            }
            else
            {


            }

        }
    }
}
