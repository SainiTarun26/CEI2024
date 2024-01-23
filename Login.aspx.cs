using CEI_PRoject;
using System;

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
                int check = Convert.ToInt32(cei.checkLogin(txtUserID.Text, txtPassword.Text));
                string Status = cei.Status();
                if (check == 1)
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
                else if (check == 2)
                {
                    ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                    if (Status.Trim() == "1")
                    {
                        Session["ContractorID"] = txtUserID.Text;
                        Session["logintype"] = "Contractor";
                        Response.Cookies["ContractorID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Contractor";
                        Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                        //Response.Redirect("/OTPVerification.aspx");
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
                            // Response.Redirect("Contractor/Work_Intimation.aspx", false);
                        }
                        else
                        {
                            Session["ContractorID"] = txtUserID.Text;
                            Session["logintype"] = "Contractor";
                            Response.Cookies["ContractorID"].Value = txtUserID.Text;
                            Response.Cookies["logintype"].Value = "Contractor";
                            Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(1);
                            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                            // Response.Redirect("Contractor/Work_Intimation.aspx", false);
                        }
                    }
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
                else if (check == 3)
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
                else if (check == 4)
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
                        Response.Redirect("Admin/AddContractorDetails.aspx", false);
                    }

                }
                else if (check == 5)
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
                else if (check == 6)
                {
                    ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                    Session["InsertedCategory"] = "Supervisor";
                    if (chkSignedin.Checked == true)
                    {
                        Session["SupervisorID"] = txtUserID.Text;
                        Session["logintype"] = "Supervisor";
                        Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Supervisor";
                        Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Session["SupervisorID"] = txtUserID.Text;
                        Session["logintype"] = "Supervisor";
                        Response.Cookies["SupervisorID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Supervisor";
                        Response.Cookies["SupervisorID"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                    }

                    if (ApplicationStatus.Trim() == "New")
                    {
                        Response.Redirect("/UserPages/Qualification.aspx", false);
                    }
                    else if (ApplicationStatus.Trim() == "Mid")
                    {
                        Response.Redirect("/UserPages/Documents.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Supervisor/IntimationData.aspx", false);
                    }
                }
                else if (check == 7)
                {
                    if (chkSignedin.Checked == true)
                    {
                        Session["SiteOwnerId"] = txtUserID.Text;
                        Session["logintype"] = "SiteOwner";
                        Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "SiteOwner";
                        Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                        Response.Redirect("/SiteOwnerPages/CreateTestReports.aspx", false);
                    }
                    else
                    {
                        Session["SiteOwnerId"] = txtUserID.Text;
                        Session["logintype"] = "SiteOwner";
                        Response.Cookies["SiteOwnerId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "SiteOwner";
                        Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("/SiteOwnerPages/CreateTestReports.aspx", false);
                    }
                }
                else if (check == 8)
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
                else if (check == 9)
                {
                    ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                    Session["InsertedCategory"] = "Wireman";
                    if (chkSignedin.Checked == true)
                    {
                        Session["WiremanId"] = txtUserID.Text;
                        Session["logintype"] = "Wireman";
                        Response.Cookies["WiremanId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Wireman";
                        Response.Cookies["WiremanId"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Session["WiremanId"] = txtUserID.Text;
                        Session["logintype"] = "Wireman";
                        Response.Cookies["WiremanId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Wireman";
                        Response.Cookies["WiremanId"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                    }
                    if (ApplicationStatus.Trim() == "New")
                    {
                        Response.Redirect("/UserPages/Qualification.aspx", false);
                    }
                    else if (ApplicationStatus.Trim() == "Mid")
                    {
                        Response.Redirect("/UserPages/Documents.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Wiremen/WiremenDashboard.aspx", false);
                    }
                }
                else if (check == 10)
                {
                    ApplicationStatus = cei.checkApplicationStatus(txtUserID.Text);
                    if (chkSignedin.Checked == true)
                    {
                        Session["LiftId"] = txtUserID.Text;
                        Session["logintype"] = "Lift";
                        Response.Cookies["LiftId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Lift";
                        Response.Cookies["LiftId"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Session["LiftId"] = txtUserID.Text;
                        Session["logintype"] = "LiftId";
                        Response.Cookies["LiftId"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "LiftId";
                        Response.Cookies["LiftId"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                    }
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
            catch (Exception)
            {
                //
            }
        }
    }
}