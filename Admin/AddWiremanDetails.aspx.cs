using Org.BouncyCastle.Ocsp;
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
    public partial class AddWiremanDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        public string UserId;
        public string Qualification;
        string REID = string.Empty;
        string ipaddress;
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
                        ddlLoadBindState();
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

               // Response.Redirect("/Login.aspx");
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
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        #endregion
        public void GetDetails()
        {
            REID = hdnId.Value;
            DataSet ds = new DataSet();
            ds = CEI.GetSupervisorData(REID);

            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            string dp_Id4 = ds.Tables[0].Rows[0]["State"].ToString();
            string dp_Id5 = ds.Tables[0].Rows[0]["District"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
            txtContect.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            string dp_Id9 = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
            string dp_Id10 = ds.Tables[0].Rows[0]["DateofExpiry"].ToString();
            string dp_Id11 = ds.Tables[0].Rows[0]["DateofRenewal"].ToString();
            string dp_Id13 = ds.Tables[0].Rows[0]["voltageWithEffect"].ToString();
            txtCertifacateOld.Text = ds.Tables[0].Rows[0]["CertificateOld"].ToString();
            txtCertificateNew.Text = ds.Tables[0].Rows[0]["CertificateNew"].ToString();
            string dp_Id16 = ds.Tables[0].Rows[0]["Qualification"].ToString();

            string dp_Id17 = ds.Tables[0].Rows[0]["AnyContractor"].ToString();
            string dp_Id18 = ds.Tables[0].Rows[0]["ContractorID"].ToString();
            string dp_Id19 = ds.Tables[0].Rows[0]["Age"].ToString();

            ddlAttachedContractor.SelectedValue = dp_Id17;

            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id4));

            ddlLoadBindDistrict(dp_Id4);
            ddlDistrict.SelectedValue = dp_Id5;
            txtAge.Text = DateTime.Parse(dp_Id19).ToString("yyyy-MM-dd");
            txtDateInitialIssue.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
            txtDateExpiry.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
            txtDateRenewal.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");

            if (Regex.IsMatch(dp_Id16, @"^\d+$"))
            {
                ddlQualification.SelectedIndex = ddlQualification.Items.IndexOf(ddlQualification.Items.FindByValue(dp_Id16));
            }
            else
            {
                ddlQualification.SelectedValue = "8";
                txtQualification.Visible = true;
                txtQualifications.Text = dp_Id16;
            }
            if (dp_Id17 == "No")
            {
                rowContractorDetails.Visible = false;
                ddlAttachedContractor.SelectedValue = "No";
            }
            else if (dp_Id17 == "Yes")
            {
                ddlAttachedContractor.SelectedValue = "Yes";
                rowContractorDetails.Visible = true;
                GetContractorDetails();
                ddlContractorDetails.SelectedIndex = ddlContractorDetails.Items.IndexOf(ddlContractorDetails.Items.FindByValue(dp_Id18));
            }


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
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
        }
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
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        protected string ConvertDate(string date)
        {
            string D1;
            string[] str = date.Split('/');
            D1 = str[2] + "-" + str[1] + "-" + str[0];
            return D1;
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
                if (txtCertificateNew.Text != "" && txtCertificateNew.Text != "NA")
                {
                    UserId = txtCertificateNew.Text;
                }
                else
                {
                    UserId = txtCertifacateOld.Text;
                }
                if (btnSubmit.Text.Trim() == "Submit")
                {
                    DataSet ds1 = new DataSet();
                    ds1 = CEI.checkCertificateexist(txtCertifacateOld.Text, txtCertificateNew.Text);
                    if ( ds1.Tables.Count > 0)
                    {
                        string alertScript = "alert('The  Certificate number is already in use. Please provide a different Certificate number.');";
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                        else if(ds1.Tables.Count >1 && ds1.Tables[1].Rows.Count>0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }                      
                    }
                }
                else if (btnSubmit.Text.Trim() == "Update")
                {
                    DataSet ds1 = new DataSet();
                    ds1 = CEI.checkCertificateexistupdated(txtCertifacateOld.Text, txtCertificateNew.Text, REID);
                    if (ds1.Tables.Count>0)
                    {                        
                        string alertScript = "alert('The  Certificate number is already in use. Please provide a different Certificate number.');";
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                        else if (ds1.Tables.Count > 1 && ds1.Tables[1].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }
                }


                GetIP();
                
                string Createdby = Convert.ToString(Session["AdminID"]);
                CEI.InserWireManData(REID, txtName.Text.ToUpper(), txtAge.Text.Trim(), txtFatherName.Text.ToUpper(), txtAddress.Text, ddlDistrict.SelectedItem.ToString(),
                ddlState.SelectedItem.ToString(), txtPincode.Text.Trim(), txtContect.Text.Trim(), Qualification, txtEmail.Text.Trim(), txtCertifacateOld.Text.Trim(), txtCertificateNew.Text.Trim(),
                txtDateInitialIssue.Text, txtDateExpiry.Text, txtDateRenewal.Text, ddlAttachedContractor.SelectedValue, ddlContractorDetails.SelectedValue,
                Createdby, UserId, ipaddress);


                if (btnSubmit.Text == "Update")
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Updated Successfully !!!')", true);
                    Session["ID"] = "";
                    DataUpdated.Visible = true;
                }
                else
                {
                    DataSaved.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Inserted Successfully !!!')", true);

                }
                Reset();

            }
            catch (Exception Ex)
            {
            }

        }
        protected void Reset()
        {
            txtName.Text = "";
            txtFatherName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            ddlDistrict.SelectedIndex = -1;
            ddlState.SelectedIndex = -1;
            txtPincode.Text = "";
            txtContect.Text = "";
            ddlQualification.SelectedIndex = -1;
            txtEmail.Text = "";
            txtCertifacateOld.Text = "";
            txtCertificateNew.Text = "";
            txtDateInitialIssue.Text = "";
            txtDateExpiry.Text = "";
            txtDateRenewal.Text = "";
            ddlAttachedContractor.SelectedIndex = -1;
            ddlContractorDetails.SelectedIndex = -1;
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