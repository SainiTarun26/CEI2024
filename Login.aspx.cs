using CEI_PRoject;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Web;
using System.Web.UI;

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

                if (Session["Username"] != null)
                {

                    string script = "alert(\"You are already logged in another tab\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    // Response.End();

                    Response.Redirect("LogOut.aspx", false);

                }
                else
                {
                    #region Kalpana Restrict user login
                    bool expired = cei.IsUserExpired(txtUserID.Text, txtPassword.Text);

                    if (expired)
                    {
                        //string script = "alert('Your license has expired.');";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                        DataSet ds = new DataSet();
                        ds = cei.checkApplicationStatus(txtUserID.Text);
                        string Category = ds.Tables[0].Rows[0]["Category"].ToString();
                        Session["Renwal"] = "Yes";
                        if (Category.Trim() == "Contractor")
                        {
                            Session["ContractorID"] = txtUserID.Text;
                            Response.Redirect("/Contractor/Contractor_Licence_Renewal.aspx", false);

                        }
                        if (Category.Trim() == "Supervisor")
                        {
                            Session["SupervisorID"] = txtUserID.Text;
                            Response.Redirect("/Supervisor/Renewal_Certificate_Competency.aspx", false);
                        }
                        else if (Category.Trim() == "Wireman")
                        {
                            Session["WiremanId"] = txtUserID.Text;
                            Response.Redirect("/Wiremen/WiremenDashboard.aspx", false);
                        }
                    }
                    else
                    {
                        #endregion
                        int check = Convert.ToInt32(cei.checkUserLogin(txtUserID.Text, txtPassword.Text));
                        string Status = cei.Status();

                        Session["Username"] = txtUserID.Text;
                        if (check == 1)
                        {
                            if (txtPassword.Text != "123456")
                            {
                                //if (txtUserID.Text.ToLower().Trim() == "cei")
                                //{
                                //    Session["Role"] = "Admin";
                                //    Session["StaffID"] = txtUserID.Text;
                                //    Response.Redirect("OfficerVerification/OTP.aspx", false);
                                //}
                                //else
                                //{
                                Session["AdminID"] = txtUserID.Text;
                                Session["logintype"] = "Admin";
                                Response.Cookies["AdminID"].Value = txtUserID.Text;
                                Response.Cookies["logintype"].Value = "Admin";
                                Response.Redirect("/Admin/AdminMaster.aspx", false);
                                // }
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
                                string UserType = "Contractor";
                                int exist = CEI.ToCheckthesignatureAndImageexist(txtUserID.Text, UserType);

                                if (exist > 0)
                                {
                                    Session["UserID"] = txtUserID.Text;
                                    Session["UserType"] = "Contractor";
                                    Response.Redirect("/Upload_Image_Sign.aspx", false);
                                }
                                else
                                {
                                    //  ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                                    if (Status.Trim() == "1")
                                    {
                                        Session["ContractorID"] = txtUserID.Text;
                                        Session["logintype"] = "Contractor";
                                        Response.Cookies["ContractorID"].Value = txtUserID.Text;
                                        Response.Cookies["logintype"].Value = "Contractor";
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
                            }
                            else
                            {
                                Session["ContractorID"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);
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
                                    Response.Redirect("Admin/AddContractorDetails.aspx", false);
                                }
                                else
                                {
                                    Session["AdminID"] = txtUserID.Text;
                                    Session["logintype"] = "Assistant";
                                    Response.Cookies["AdminID"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "Assistant";
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
                                    Response.Redirect("Admin/AddContractorDetails.aspx", false);
                                }
                                else
                                {
                                    Session["AdminID"] = txtUserID.Text;
                                    Session["logintype"] = "Clerk";
                                    Response.Cookies["AdminID"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "Clerk";

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
                                    Response.Redirect("Admin/AddContractorDetails.aspx", false);
                                }
                                else
                                {
                                    Session["AdminID"] = txtUserID.Text;
                                    Session["logintype"] = "SeniorScale";
                                    Response.Cookies["AdminID"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "SeniorScale";
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
                                string UserType = "Supervisor";
                                int exist = CEI.ToCheckthesignatureAndImageexist(txtUserID.Text, UserType);

                                if (exist > 0)
                                {
                                    Session["UserID"] = txtUserID.Text;
                                    Session["UserType"] = "Supervisor";
                                    Response.Redirect("/Upload_Image_Sign.aspx", false);
                                }
                                else
                                {

                                    if (chkSignedin.Checked == true)
                                    {
                                        Session["SupervisorID"] = txtUserID.Text;
                                        Session["logintype"] = "Supervisor";
                                        Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                                        Response.Cookies["logintype"].Value = "Supervisor";
                                        Response.Redirect("/Supervisor/IntimationData.aspx", false);
                                    }
                                    else
                                    {
                                        Session["SupervisorID"] = txtUserID.Text;
                                        Session["logintype"] = "Supervisor";
                                        Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                                        Response.Cookies["logintype"].Value = "Supervisor";
                                        Response.Redirect("/Supervisor/IntimationData.aspx", false);
                                    }
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
                                //dt aaded by navneet for siteowner login
                                DataTable dt = new DataTable();
                                dt = cei.LoginsiteownerPanverification(txtUserID.Text.Trim());
                                string path = dt.Rows[0]["panpath"].ToString();
                                //
                                if (path != null && path != "")
                                {
                                    if (chkSignedin.Checked == true)
                                    {
                                        Session["SiteOwnerId"] = txtUserID.Text;
                                        Session["logintype"] = "SiteOwner";
                                        Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                                        Response.Cookies["logintype"].Value = "SiteOwner";
                                        Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
                                    }
                                    else
                                    {
                                        Session["SiteOwnerId"] = txtUserID.Text;
                                        Session["logintype"] = "SiteOwner";
                                        Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                                        Response.Cookies["logintype"].Value = "SiteOwner";
                                        Response.Redirect("/SiteOwnerPages/InspectionHistory.aspx", false);
                                    }
                                }
                                else
                                {
                                    Session["SiteOwnerId"] = txtUserID.Text;
                                    Response.Redirect("/SiteOwner_Verification/Pan_Card_Verification.aspx", false);
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
                                //Session["Role"] = "Staff";
                                //Session["StaffID"] = txtUserID.Text;
                                //Response.Redirect("OfficerVerification/OTP.aspx", false);

                                Session["StaffID"] = txtUserID.Text;
                                Session["logintype"] = "Staff";
                                Response.Cookies["StaffID"].Value = txtUserID.Text;
                                Response.Cookies["logintype"].Value = "Staff";

                                Response.Redirect("/Officers/OfficerDashboard.aspx", false);
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

                                }
                                else
                                {
                                    Session["NewUserId"] = txtUserID.Text;
                                    //Session["logintype"] = "NewUser";
                                    Session["logintype"] = "Registered User";
                                    Response.Cookies["NewUserId"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "NewUser";
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
                                        int result = Convert.ToInt32(cei.DetailOfContractorExist(txtUserID.Text));
                                        if (result == 1)
                                        {
                                            Response.Redirect("/UserPages/Update_Contractor_Application_Form.aspx", false);
                                        }
                                        else if (result == 0)
                                        {
                                            Response.Redirect("/UserPages/ContractorApplicationForm.aspx", false);
                                        }
                                    }
                                    else if (ApplicationStatus.Trim() == "Mid")
                                    {
                                        Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("/UserPages/New_Application_Status.aspx", false);
                                    }
                                }

                                else if (Category.Trim() == "Supervisor")
                                {
                                    Session["SupervisorID"] = txtUserID.Text;
                                    Session["InsertedCategory"] = "Supervisor";
                                    if (ApplicationStatus.Trim() == "New")
                                    {
                                        int result = Convert.ToInt32(cei.DetailOfSupervisorAndWiremanExist(txtUserID.Text));
                                        if (result == 1)
                                        {
                                            Response.Redirect("/UserPages/Update_Supervisor_Qualification.aspx", false);
                                        }
                                        else if (result == 0)
                                        {
                                            Response.Redirect("/UserPages/SupervisorQualification.aspx", false);
                                        }



                                    }
                                    else if (ApplicationStatus.Trim() == "Mid")
                                    {
                                        Response.Redirect("/UserPages/Documents.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("/UserPages/New_Application_Status.aspx", false);
                                    }
                                }
                                else if (Category.Trim() == "Wireman")
                                {
                                    Session["WiremanId"] = txtUserID.Text;
                                    Session["InsertedCategory"] = "Wireman";
                                    if (ApplicationStatus.Trim() == "New")
                                    {
                                        int result = Convert.ToInt32(cei.DetailOfSupervisorAndWiremanExist(txtUserID.Text));
                                        if (result == 1)
                                        {
                                            Response.Redirect("/UserPages/Update_Wireman_Qualification.aspx", false);
                                        }
                                        else if (result == 0)
                                        {
                                            Response.Redirect("/UserPages/Qualification.aspx", false);
                                        }

                                    }
                                    else if (ApplicationStatus.Trim() == "Mid")
                                    {
                                        Response.Redirect("/UserPages/Documents.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("/UserPages/New_Application_Status.aspx", false);
                                    }
                                }
                            }
                            else
                            {
                                Session["NewUserId"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);

                            }
                        }
                        else if (check == 10)
                        {
                            if (txtPassword.Text != "123456")
                            {
                                string UserType = "Wireman";
                                int exist = CEI.ToCheckthesignatureAndImageexist(txtUserID.Text, UserType);
                                if (exist > 0)
                                {
                                    Session["UserID"] = txtUserID.Text;
                                    Session["UserType"] = "Wireman";
                                    Response.Redirect("/Upload_Image_Sign.aspx", false);
                                }
                                else
                                {
                                    if (chkSignedin.Checked == true)
                                    {
                                        Session["logintype"] = "Wireman";
                                        Session["WiremanId"] = txtUserID.Text;
                                        Response.Redirect("/Wiremen/Renewal_Certificate_Wiremen.aspx", false);
                                    }
                                    else
                                    {
                                        Session["logintype"] = "Wireman";
                                        Session["WiremanId"] = txtUserID.Text;
                                        Response.Redirect("/Wiremen/Renewal_Certificate_Wiremen.aspx", false);
                                    }
                                }
                            }
                            else
                            {
                                Session["WiremanId"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);
                            }
                        }
                        else if (check == 11)
                        {
                            if (txtPassword.Text != "123456")
                            {
                                if (chkSignedin.Checked == true)
                                {
                                    Session["DealingHandId"] = txtUserID.Text;
                                    Session["logintype"] = "DealingHand";
                                    Response.Cookies["DealingHandId"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "DealingHand";
                                    Response.Redirect("DealingHand/ViewData.aspx", false);
                                }
                                else
                                {
                                    Session["DealingHandId"] = txtUserID.Text;
                                    Session["logintype"] = "DealingHand";
                                    Response.Cookies["DealingHandId"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "DealingHand";
                                    Response.Redirect("DealingHand/ViewData.aspx", false);
                                }
                            }
                            else
                            {
                                Session["DealingHandId"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);
                            }
                        }
                        else if (check == 12)
                        {
                            if (txtPassword.Text != "123456")
                            {
                                if (chkSignedin.Checked == true)
                                {
                                    Session["SuperidentId"] = txtUserID.Text;
                                    Session["logintype"] = "Superintendent";
                                    Response.Cookies["SuperidentId"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "Superintendent";
                                    Response.Redirect("Superintendent/UserDetails.aspx", false);
                                }
                                else
                                {
                                    Session["SuperidentId"] = txtUserID.Text;
                                    Session["logintype"] = "Superintendent";
                                    Response.Cookies["SuperidentId"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "Superintendent";
                                    Response.Redirect("Superintendent/UserDetails.aspx", false);
                                }
                            }
                            else
                            {
                                Session["SuperidentId"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);
                            }
                        }
                        else if (check == 13)
                        {
                            if (txtPassword.Text != "123456")
                            {
                                if (chkSignedin.Checked == true)
                                {
                                    Session["GuestAdmin"] = txtUserID.Text;
                                    Session["logintype"] = "GuestAdmin";
                                    Response.Cookies["GuestAdmin"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "GuestAdmin";
                                    Response.Redirect("GuestAdmin/GuestAdmin.aspx", false);
                                }
                                else
                                {
                                    Session["GuestAdmin"] = txtUserID.Text;
                                    Session["logintype"] = "GuestAdmin";
                                    Response.Cookies["GuestAdmin"].Value = txtUserID.Text;
                                    Response.Cookies["logintype"].Value = "GuestAdmin";
                                    Response.Redirect("GuestAdmin/GuestAdmin.aspx", false);
                                }
                            }
                            else
                            {
                                Session["GuestUser"] = txtUserID.Text;
                                Response.Redirect("/ChangePassword.aspx", false);

                            }
                        }
                        else
                        {
                            Session["Username"] = null;
                            txtUserID.Text = "";
                            txtPassword.Text = "";
                            WrongCredentials.Visible = true;

                            Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
                            // string script = "alert(\"Your UserName or Password is Invalid.\");";
                            // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Session["Username"] = "";
                Response.Write("<script> window.close(); localStorage.removeItem('activeSession'); sessionStorage.clear(); window.close();</script>");
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }
    }
}