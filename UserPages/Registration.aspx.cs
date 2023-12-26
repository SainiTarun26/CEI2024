using CEI_PRoject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Registration : System.Web.UI.Page
    {
        string REID = string.Empty;
        CEI CEI = new CEI();
        string ipaddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlLoadBindState();
                    ddlLoadBindState1();
                    if (Convert.ToString(Session["RegistrationID"]) == null || Convert.ToString(Session["RegistrationID"]) == "")
                    {

                    }
                    else
                    {
                        REID = Session["RegistrationID"].ToString();
                        hdnId.Value = REID;
                        btnNext.Text = "Update";
                        GetUserRegistartionData();
                    }

                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
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
        protected void GetUserRegistartionData()
        {
            REID = Session["RegistrationID"].ToString();
            hdnId.Value = REID;

            SqlCommand cmd = new SqlCommand("sp_GetUserRegistrationData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", REID);
            cmd.Connection = con;
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
                string dp_Id = ds.Tables[0].Rows[0]["Category"].ToString();

                //selectedFileName1.Text = ds.Tables[0].Rows[0]["UploadPhoto"].ToString();
                //uploadedImage1.ImageUrl = ds.Tables[0].Rows[0]["UploadPhoto"].ToString();
                //uploadedImage.ImageUrl = ds.Tables[0].Rows[0]["UploadSignature"].ToString();
                //selectedFileName.Text = ds.Tables[0].Rows[0]["UploadSignature"].ToString();


                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtFatherNmae.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                txtAadhaar.Text = ds.Tables[0].Rows[0]["AdhaarNo"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["Gender"].ToString();
                string dp_Id2 = ds.Tables[0].Rows[0]["DOB"].ToString();
                txtCommunicationAddress.Text = ds.Tables[0].Rows[0]["CommunicationAddress"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["CommunicationState"].ToString();
                string dp_Id4 = ds.Tables[0].Rows[0]["DistrictCommunication"].ToString();
                txtPinCode.Text = ds.Tables[0].Rows[0]["CommunicationPin"].ToString();
                string dp_Id6 = ds.Tables[0].Rows[0]["PermanentState"].ToString();
                txtPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                string dp_Id7 = ds.Tables[0].Rows[0]["PermanentDistrict"].ToString();
                txtPin.Text = ds.Tables[0].Rows[0]["PermanentPin"].ToString();
                txtphone.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                ddlLoadBindState();
                ddlLoadBindState1();
                ddlLoadBindDistrict(dp_Id3);
                ddlLoadBindDistrict1(dp_Id6);
                ddlDistrict.SelectedValue = dp_Id4;
                ddlDistrict1.SelectedValue = dp_Id7;
                ddlState1.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id3));
                ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id6));
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtDOB.Text = DateTime.Parse(dp_Id2).ToString("yyyy-MM-dd");
                ddlcategory.SelectedIndex = ddlcategory.Items.IndexOf(ddlcategory.Items.FindByText(dp_Id));
                ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(dp_Id1));
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                string Category = string.Empty;
                string name = txtName.Text;
                string dob = txtDOB.Text;

                string firstNamePart = name.Length >= 4 ? name.Substring(0, 4) : name;

                string numericDOB = new string(dob.Where(char.IsDigit).ToArray());

                string userId = $"{firstNamePart}{numericDOB}";

                if (ddlcategory.SelectedValue == "1")
                {
                    Category = "Wireman";
                }
                else if (ddlcategory.SelectedValue == "2")
                {
                    Category = "Supervisor";
                }
                else
                {
                    Category = "Contractor";
                }
                GetIP();
                CEI.InserNewUserData(ddlcategory.SelectedItem.ToString(), txtName.Text, txtDOB.Text, txtyears.Text, txtFatherNmae.Text,
       txtPermanentAddress.Text, ddlDistrict.SelectedItem.ToString(), ddlState.SelectedItem.ToString(), txtPinCode.Text, txtphone.Text,
       txtEmail.Text, Category, userId, userId, txtCommunicationAddress.Text, ddlState1.SelectedItem.ToString(), ddlDistrict1.SelectedItem.ToString(),
       txtPin.Text, txtConfirmPswrd.Text, ipaddress);


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("cs.nehaa6@gmail.com");
                mailMessage.To.Add(txtEmail.Text); mailMessage.Subject = "Your Credentials"; string body = $"Dear Customer, Your Account is created. Your user id is First 4 characters of your Name + your date of birth. ";
                mailMessage.Body = body;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("cs.nehaa6@gmail.com", "onzlivlqffxixxgg");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);




            }
            catch (Exception)
            {

            }
        }

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
        private void ddlLoadBindState1()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlState1.DataSource = dsState;
                ddlState1.DataTextField = "StateName";
                ddlState1.DataValueField = "StateID";
                ddlState1.DataBind();
                ddlState1.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        private void ddlLoadBindDistrict1(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict1.DataSource = dsDistrict;
                ddlDistrict1.DataTextField = "District";
                ddlDistrict1.DataValueField = "District";
                ddlDistrict1.DataBind();
                ddlDistrict1.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            if (txtDOB.Text != "")
            {
                DateTime selectedDOB;
                if (DateTime.TryParse(txtDOB.Text, out selectedDOB))
                {

                    DateTime currentDate = DateTime.Now;


                    int ageDiff = currentDate.Year - selectedDOB.Year;

                    if (ageDiff < 18)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You must be at least 18 years old.');", true);

                        txtDOB.Text = "";




                        CalculatedDatey.Visible = false;
                    }
                    else if (ageDiff > 65)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligble to fill this form.');", true);

                        txtDOB.Text = "";

                        CalculatedDatey.Visible = false;
                    }
                    else
                    {
                        if (DateTime.TryParseExact(txtDOB.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dobDate))
                        {

                            if (dobDate > currentDate)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Date !!!')", true);
                                txtDOB.Text = "";

                                CalculatedDatey.Visible = false;
                            }

                            else
                            {


                                int ageYear = currentDate.Year - dobDate.Year;
                                int ageMonth = currentDate.Month - dobDate.Month;
                                int ageDay = currentDate.Day - dobDate.Day;

                                // Adjust the age if the current day is before the birth day
                                if (ageDay < 0)
                                {
                                    ageMonth--;
                                    ageDay += DateTime.DaysInMonth(currentDate.Year, currentDate.Month - 1);

                                }

                                // Adjust the age if the current month is before the birth month
                                if (ageMonth < 0)
                                {
                                    ageYear--;
                                    ageMonth += 12;
                                }
                                if (currentDate.Year == dobDate.Year)
                                {
                                    ageYear = 0;
                                }


                                txtyears.Text = ageYear.ToString() + "Years-" + ageMonth.ToString() + "Months-" + ageDay.ToString() + "Days";

                                txtyears.Text = ageYear.ToString() + "Years-" + ageMonth.ToString() + "Months-" + ageDay.ToString() + "Days";

                            }

                            //CalculatedDate.Visible = true;
                            //CalculatedDateM.Visible = true;
                            CalculatedDatey.Visible = true;
                        }
                    }
                }
            }
            else
            {
                //CalculatedDate.Visible = false;
                //CalculatedDateM.Visible = false;
                CalculatedDatey.Visible = false;
            }

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
            }

            ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
        }

        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict1(ddlState1.SelectedItem.ToString());

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txtPermanentAddress.Text = txtCommunicationAddress.Text;
                ddlState.SelectedValue = ddlState1.SelectedValue;
                ddlDistrict.ClearSelection();
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Add(new ListItem(ddlDistrict1.SelectedItem.Text, "1"));

                txtPin.Text = txtPinCode.Text;
                txtPermanentAddress.Attributes.Add("readonly", "false");
                ddlState.Attributes.Add("disabled", "disabled");
                txtPin.Attributes.Add("readonly", "false");
                ddlDistrict.Attributes.Add("disabled", "disabled");
            }
            else
            {
                txtPermanentAddress.Text = "";
                ddlState.SelectedValue = "0";
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Add(new ListItem("Select", "0"));
                txtPin.Text = "";
                txtPermanentAddress.Attributes.Remove("readonly");
                ddlState.Attributes.Remove("disabled");
                txtPin.Attributes.Remove("readonly");
                ddlDistrict.Attributes.Remove("disabled");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue =="3")
            {
                contractor.Visible = true;
                WireSup.Visible = false;
            }
            else
            {
                contractor.Visible = false;
                WireSup.Visible = true;
            }
        }
    }
}