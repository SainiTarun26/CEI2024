using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CEIHaryana.Contractor;
using System.Text.RegularExpressions;

namespace CEI_PRoject.Admin
{
    public partial class AddSupervisorDetails : System.Web.UI.Page
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
            
            catch (Exception)
            {
                //
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
            SqlCommand cmd = new SqlCommand("sp_GetSuperwiserDetails");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", REID);
            cmd.Connection = con;
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
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
                string dp_Id16 = ds.Tables[0].Rows[0]["Qualification"].ToString();
                string dp_Id17 = ds.Tables[0].Rows[0]["AnyContractor"].ToString();
                string dp_Id18 = ds.Tables[0].Rows[0]["ContractorID"].ToString();
                string dp_Id19 = ds.Tables[0].Rows[0]["Age"].ToString();
                ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id4)); 
                ddlLoadBindDistrict(dp_Id4);
                ddlDistrict.SelectedValue = dp_Id5;
                DateofIntialissue.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
                DateofRenewal.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
                DateofExpiry.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
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
                if (txtQualification.Visible == true)
                {

                    Qualification = txtQualifications.Text;
                }
                else
                {
                    Qualification = ddlQualification.SelectedValue;

                }
                GetIP();
                REID = hdnId.Value; ;
                string Createdby = Convert.ToString(Session["AdminID"]);
                SqlCommand cmd = new SqlCommand("sp_SetWiremanandSuperwiserDetails");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@REID", REID);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@FatherName", FatherName.Text);
                cmd.Parameters.AddWithValue("@Address", Address.Text);
                cmd.Parameters.AddWithValue("@District", ddlDistrict.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@PinCode", txtPincode.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", ContactNo.Text);
                cmd.Parameters.AddWithValue("@Qualification", Qualification);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@CertificateOld", CertificateOld.Text);
                cmd.Parameters.AddWithValue("@CertificateNew", CertificateNew.Text);
                cmd.Parameters.AddWithValue("@DateofIntialissue", DateofIntialissue.Text);
                cmd.Parameters.AddWithValue("@DateofExpiry", DateofExpiry.Text);
                cmd.Parameters.AddWithValue("@DateofRenewal", DateofRenewal.Text);
                cmd.Parameters.AddWithValue("@votagelevel", ddlVoltageLevel.Text);
                cmd.Parameters.AddWithValue("@voltageWithEffect", voltageWithEffect.Text);
                cmd.Parameters.AddWithValue("@AnyContractor", ddlAttachedContractor.SelectedValue);
                cmd.Parameters.AddWithValue("@AttachedContractorld", ddlContractorDetails.SelectedValue);
                cmd.Parameters.AddWithValue("@Category", "Supervisor");
                cmd.Parameters.AddWithValue("@Createdby", Createdby);
                cmd.Parameters.AddWithValue("@UserId", CertificateOld.Text);

                cmd.Parameters.AddWithValue("@IPAddress", ipaddress);
                cmd.ExecuteNonQuery();
                con.Close();
                if (btnSubmit.Text == "Update")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Updated Successfully !!!')", true);
                    Session["ID"] = "";
                    DataUpdated.Visible = true;
                }
                else
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Inserted Successfully !!!')", true);
                    DataSaved.Visible = true;

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
    }
}