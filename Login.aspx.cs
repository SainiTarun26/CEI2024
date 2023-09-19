using CEI_PRoject;
using System;

namespace CEIHaryana
{
    public partial class Login : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int check = Convert.ToInt32(cei.checkLogin(txtUserID.Text, txtPassword.Text));

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
                        Response.Redirect("Admin/AddContractorDetails.aspx", false);
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Session["logintype"] = "Admin";
                        Response.Cookies["AdminID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Admin";
                        Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("Admin/AddContractorDetails.aspx", false);
                    }

                }
                else if (check == 2)
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
                    if (chkSignedin.Checked == true)
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Session["logintype"] = "Supervisor/Wireman";
                        Response.Cookies["AdminID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Supervisor/Wireman";
                        Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                        Response.Redirect("Supervisor/IntimationData.aspx", false);
                    }
                    else
                    {
                        Session["AdminID"] = txtUserID.Text;
                        Session["logintype"] = "Supervisor/Wireman";
                        Response.Cookies["AdminID"].Value = txtUserID.Text;
                        Response.Cookies["logintype"].Value = "Supervisor/Wireman";
                        Response.Cookies["AdminID"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("Supervisor/IntimationData.aspx", false);
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
                //
            }
        }
    }
}