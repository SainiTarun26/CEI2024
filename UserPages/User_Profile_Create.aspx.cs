using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.UserPages
{
    public partial class User_Profile_Create : System.Web.UI.Page
    {
        //Page Created by neha 18-June-2025
        CEI CEI = new CEI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.UrlReferrer != null)
                {
                    Session["PreviousPage"] = Request.UrlReferrer.ToString();
                }

                string username = Session["Username"]?.ToString();

                if (!string.IsNullOrEmpty(username))
                {
                    GetUserDetails(username);
                }
            }
        }

        private void GetUserDetails(string username)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.Getdetailsofuser(username);


                txtcategory.Text = dt.Rows[0]["Category"].ToString();

                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtuserid.Text = dt.Rows[0]["UserId"].ToString();
                txtFatherNmae.Text = dt.Rows[0]["FatherName"].ToString();
                //txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                DateTime dob = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                txtDOB.Text = dob.ToString("dd-MM-yyyy");

                txtyears.Text = dt.Rows[0]["CalculatedAge"].ToString();
                txtgender.Text = dt.Rows[0]["Gender"].ToString();


                txtAadhaar.Text = dt.Rows[0]["Aadhar"].ToString();

                if (string.IsNullOrEmpty(txtAadhaar.Text))
                {
                    txtAadhaar.Text=dt.Rows[0]["PanCardNo"].ToString();
                    Aadhaar.Visible=false;
                    Pancard.Visible=true;
                }
                else
                {
                    Aadhaar.Visible=true;
                }

                txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();

                txtState1.Text = dt.Rows[0]["CommState"].ToString();


                txtDistrict1.Text = dt.Rows[0]["CommDistrict"].ToString();


                txtPinCode.Text = dt.Rows[0]["CommPin"].ToString();

                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();

                txtstate.Text = dt.Rows[0]["PermanentState"].ToString();



                txtdistrict.Text = dt.Rows[0]["PermanentDistrict"].ToString();


                txtPin.Text = dt.Rows[0]["PermanentPin"].ToString();

                txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();

                txtEmail.Text = dt.Rows[0]["Email"].ToString();


            }
            catch
            {
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                string previousPageUrl = Session["PreviousPage"] as string;
                if (!string.IsNullOrEmpty(previousPageUrl))
                {

                    Response.Redirect(previousPageUrl, false);
                    Session["PreviousPage"] = null;

                }
            }
            catch { }
        }
    }
}