using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class NewApplications_Licence : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminID"]) != null && Convert.ToString(Session["AdminID"]) != "")
                    {                       
                        CommitteeGridViewBind();
                        Page.Session["double_Clickbutton"] = "1";
                    }
                    else
                    {
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void GridViewBind(string Categary, string RegistrationNo, string Name)
        {
            DataTable dt = new DataTable();
            dt = cei.GetNewLicenceApplicationForCEI(Categary, RegistrationNo, Name);
            if (dt.Rows.Count > 0 && dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlcategory.SelectedValue != "0")
                {
                    string Categary = ddlcategory.SelectedItem.Text;
                    GridViewBind(Categary, null, null);
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["AdminID"]) != null && Convert.ToString(Session["AdminID"]) != "")
                {
                    string Categary = ddlcategory.SelectedItem.Text;
                    string Searchby = ddlSearchBy.SelectedItem.Text;
                    if (Searchby == "Name")
                    {
                        GridViewBind(Categary, null, txtName.Text.Trim());
                    }
                    else if (Searchby == "RegistrationNo.")
                    {
                        GridViewBind(Categary, txtName.Text.Trim(), null);
                    }
                    else
                    {
                        GridViewBind(Categary, null, null);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            ddlSearchBy.SelectedIndex = 0;
            ddlcategory.SelectedIndex = 0;
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSearchBy.SelectedValue != "0")
            {
                Name_Registration.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["AdminID"]) != null && Convert.ToString(Session["AdminID"]) != "")
                {
                    string CreatedBy = Convert.ToString(Session["AdminID"]);
                    bool isAnySelected = false;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                        if (cb != null && cb.Checked)
                        {
                            isAnySelected = true;
                            break;
                        }
                    }
                    if (isAnySelected)
                    {
                        string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connectionstring);

                        if (Convert.ToString(Session["double_Clickbutton"]) == "1")
                        {
                            try
                            {
                                conn.Open();
                                //transaction = conn.BeginTransaction();
                                string CommitteeID = txtCommittee.Text;
                                if (CommitteeID == "" || CommitteeID == null)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('No committe active pls activate the commite');", true);
                                    return;
                                }
                                //if (GridViewCommittee.Rows.Count >0)
                                //{
                                //    GridViewRow row = GridViewCommittee.Rows[0];
                                //    Label lblCommitteeID = (Label)row.FindControl("lblCommitteeID");
                                //    CommitteeID = lblCommitteeID.Text;
                                //}
                                foreach (GridViewRow row in GridView1.Rows)
                                {
                                    string ApplicationID, Category, RegistrationNo = "";
                                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                                    if (chk != null && chk.Checked)
                                    {
                                        SqlTransaction transaction = null;
                                        try
                                        {
                                            transaction = conn.BeginTransaction();
                                            //Label lblApplicationID = (Label)row.FindControl("lblApplicationID");
                                            //ApplicationID = lblApplicationID.Text;
                                            Label lblCategory = (Label)row.FindControl("lblCategory");
                                            Category = lblCategory.Text;
                                            Label lblRegistrationNo = (Label)row.FindControl("lblRegistrationNo");
                                            RegistrationNo = lblRegistrationNo.Text;

                                            cei.InsertNewLicenceApplicationFromCEI(RegistrationNo, CommitteeID, Category, CreatedBy, transaction);
                                            transaction.Commit();
                                            Session["double_Clickbutton"] = "";
                                            Session["double_Clickbutton"] = null;

                                        }
                                        catch (Exception ex)
                                        {
                                            transaction.Rollback();
                                            ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('Error: {ex.Message}');", true);
                                        }
                                    }
                                }

                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Application Forword Successfully!');  window.location.href='/Admin/NewApplications_Licence.aspx';", true);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                       "alert('Please select AtLeast one checkbox or Select Applications');", true);
                        return;
                    }
                }
                else
                {
                    Response.Redirect("LogOut.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('Error: {ex.Message}');", true);
            }
        }

        private void CommitteeGridViewBind()
        {
            DataTable dt = new DataTable();
            dt = cei.GetCommitteeDetails();
            if (dt.Rows.Count > 0 && dt != null)
            {
                txtCommittee.Text = dt.Rows[0]["CommitteeID"].ToString();
                //GridViewCommittee.DataSource =  dt;
                //GridViewCommittee.DataBind();
            }
            else
            {
                //GridViewCommittee.DataSource = null;
                //GridViewCommittee.DataBind();
            }
        }

        protected void lnkShowCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Committee_Details.aspx", false);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label Categary = (Label)row.FindControl("lblCategory");
                //LinkButton lnkRegNo= row.FindControl("LinkRegistrationNo") as LinkButton;
                //string RegNo = lnkRegNo.Text;
                string RegNo = e.CommandArgument.ToString();
                Session["NewApplicationRegistrationNo"] = "";
                Session["NewApplication_Contractor_RegNo"] = "";
                if (Categary.Text == "Wireman" || Categary.Text == "Supervisor")
                {
                    Session["NewApplicationRegistrationNo"] = RegNo;
                    Response.Redirect("/UserPages/New_Registration_Information.aspx", false);
                }
                else if (Categary.Text == "Contractor")
                {
                    Session["NewApplication_Contractor_RegNo"] = RegNo;
                    Response.Redirect("/UserPages/New_Registration_Information_Contractor.aspx", false);

                }


            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Session["double_Clickbutton"] = "1";
        }
    }
}