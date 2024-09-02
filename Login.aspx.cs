using CEI_PRoject;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Web;
using System.Web.Helpers;

namespace CEIHaryana
{
    public partial class Login : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string ApplicationStatus = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // int check = Convert.ToInt32(cei.checkLogin(txtUserID.Text, txtPassword.Text));
                int check = Convert.ToInt32(cei.checkUserLogin(txtUserID.Text, txtPassword.Text));
                string Status = cei.Status();
                //if (txtPassword.Text == "123456")
                //{
                //    Session["UserId"] = txtUserID.Text;
                //    Response.Redirect("/ChangePassword.aspx");
                //}
                if (check == 1)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Admin";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Admin";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);

                            Response.Redirect("Admin/AdminMaster.aspx", false);




                        }
                        else
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Admin";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Admin";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("Admin/AdminMaster.aspx", false);

                        }
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);
                    }
                }
                else if (check == 2)
                {
                    if (txtPassword.Text != "123456")
                    {

                        //  ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                        if (Status.Trim() == "1")
                        {
                            Session["ContractorID"] = txtUserID.Text;
                            Session["logintype"] = "Contractor";
                            Response.Cookies["ContractorID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Contractor";
                            Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("/OTPVerification.aspx", false);
                        }
                        else
                        {
                            if (chkSignedin.Checked == true)
                            {
                                Session["ContractorID"] = txtUserID.Text;
                                Session["logintype"] = "Contractor";
                                Response.Cookies["ContractorID"].Value = txtUserID.Text;
                                Response.Cookies["logintype"].Value = "Contractor";
                                Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                                Response.Redirect("Contractor/Work_Intimation.aspx", false);

                            }
                            else
                            {
                                Session["ContractorID"] = txtUserID.Text;
                                Session["logintype"] = "Contractor";
                                Response.Cookies["ContractorID"].Value = txtUserID.Text;
                                Response.Cookies["logintype"].Value = "Contractor";
                                Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(1);
                                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                                Response.Redirect("Contractor/Work_Intimation.aspx", false);
                              
                            }
                        }
                    }
                    else
                    {
                        Session["ContractorID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx");
                    }
                }



                else if (check == 3)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Assistant";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Assistant";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                        else
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Assistant";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Assistant";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);

                    }
                }
                else if (check == 4)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Clerk";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Clerk";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                        else
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "Clerk";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Clerk";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                           
                            // Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);

                    }

                }
                else if (check == 5)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "SeniorScale";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "SeniorScale";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                        else
                        {
                            Session["AdminID"] = txtUserID.Text;
                            Session["logintype"] = "SeniorScale";
                            Response.Cookies["AdminID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "SeniorScale";
                            Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("Admin/AddContractorDetails.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);

                    }
                }
                else if (check == 6)
                {
                    if (txtPassword.Text != "123456")
                    {

                        if (chkSignedin.Checked == true)
                        {
                            Session["SupervisorID"] = txtUserID.Text;
                            Session["logintype"] = "Supervisor";
                            Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Supervisor";
                            Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("/Supervisor/IntimationData.aspx", false);
                        }
                        else
                        {
                            Session["SupervisorID"] = txtUserID.Text;
                            Session["logintype"] = "Supervisor";
                            Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Supervisor";
                            Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("/Supervisor/IntimationData.aspx", false);
                        }
                    }
                    else
                    {
                        Session["SupervisorID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);
                    }
                }
                else if (check == 7)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["SiteOwnerId"] = txtUserID.Text;
                            Session["logintype"] = "SiteOwner";
                            Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "SiteOwner";
                            Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("/SiteOwnerPages/SiteOwnerDashboard.aspx", false);
                        }
                        else
                        {
                            Session["SiteOwnerId"] = txtUserID.Text;
                            Session["logintype"] = "SiteOwner";
                            Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "SiteOwner";
                            Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("/SiteOwnerPages/SiteOwnerDashboard.aspx", false);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);
                    }
                }
                else if (check == 8)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["StaffID"] = txtUserID.Text;
                            Session["logintype"] = "Staff";
                            Response.Cookies["StaffID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Staff";
                            Response.Cookies["StaffID"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                            Response.Redirect("Officers/OfficerDashboard.aspx", false);
                        }
                        else
                        {
                            Session["StaffID"] = txtUserID.Text;
                            Session["logintype"] = "Staff";
                            Response.Cookies["StaffID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Staff";
                            Response.Cookies["StaffID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            Response.Redirect("Officers/OfficerDashboard.aspx", false);
                        }
                    }
                    else
                    {
                        Session["StaffID"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);
                    }
                }
                else if (check == 9)
                {
                    if (txtPassword.Text != "123456")
                    {
                        if (chkSignedin.Checked == true)
                        {
                            Session["NewUserId"] = txtUserID.Text;
                            //Session["logintype"] = "NewUser";
                            Session["logintype"] = "Registered User";
                            Response.Cookies["NewUserId"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "NewUser";
                            Response.Cookies["NewUserId"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Session["NewUserId"] = txtUserID.Text;
                            //Session["logintype"] = "NewUser";
                            Session["logintype"] = "Registered User";
                            Response.Cookies["NewUserId"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "NewUser";
                            Response.Cookies["NewUserId"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                        }
                        DataSet ds = new DataSet();
                        ds = cei.checkApplicationStatus(txtUserID.Text);
                        string Category = ds.Tables[0].Rows[0]["Category"].ToString();
                        ApplicationStatus = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        if (Category.Trim() == "Contractor")
                        {
                            Session["ContractorID"] = txtUserID.Text;
                            if (ApplicationStatus.Trim() == "New")
                            {
                                Response.Redirect("/UserPages/ContractorApplicationForm.aspx", false);
                            }
                            else if (ApplicationStatus.Trim() == "Mid")
                            {
                                Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Contractor/Work_Intimation.aspx", false);
                            }
                        }
                        else if (Category.Trim() == "Lift")
                        {
                            Session["LiftId"] = txtUserID.Text;
                            if (ApplicationStatus.Trim() == "New")
                            {
                                Response.Redirect("/UserPages/ApplicationForLiftEscalators.aspx", false);
                            }
                            else if (ApplicationStatus.Trim() == "Mid")
                            {
                                Response.Redirect("/UserPages/DocumentsForLift.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Login.aspx", false);
                            }
                        }
                        else
                        {
                            if (Category.Trim() == "Supervisor")
                            {
                                Session["SupervisorID"] = txtUserID.Text;
                                Session["InsertedCategory"] = "Supervisor";
                            }
                            else
                            {
                                Session["WiremanId"] = txtUserID.Text;
                                Session["InsertedCategory"] = "Wireman";
                            }
                            if (ApplicationStatus.Trim() == "New")
                            {
                                Response.Redirect("/UserPages/Qualification.aspx", false);
                            }
                            else if (ApplicationStatus.Trim() == "Mid")
                            {
                                Response.Redirect("/UserPages/Documents.aspx", false);
                            }

                        }
                    }
                    else
                    {
                        Session["NewUserId"] = txtUserID.Text;
                        Response.Redirect("/ChangePassword.aspx", false);

                    }
                }
                else
                {
                    txtUserID.Text = "";
                    txtPassword.Text = "";
                    WrongCredentials.Visible = true;
                    // string script = "alert(\"Your UserName or Password is Invalid.\");";
                    // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnForgetPassword_Click(object sender, EventArgs e)
        {
            //string storedOtp = Session["ResetOTP"] as string;
            //string storedemailid = Session["ResetOTPEmail"] as string;
            //if (string.IsNullOrEmpty(storedOtp))
            //{
            //    string email = "makaslam786@gmail.com";
            //    Session["ResetOTP"] = cei.ForgetResetPasswordOtpEmail(email);
            //    Session["ResetOTPEmail"] = email;
            //}

            Response.Redirect("/ForgotPassword.aspx", false);
        }
    }
}