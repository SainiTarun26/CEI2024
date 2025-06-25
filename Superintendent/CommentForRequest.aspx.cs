using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Superintendent
{
    public partial class CommentForRequest : System.Web.UI.Page
    {
        //Page Created By Neeraj on june 2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Convert.ToString(Session["SuperidentId"]) != null && Convert.ToString(Session["SuperidentId"]) != string.Empty)
                    {
                        if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                            hdnId.Value = Session["SuperidentId"].ToString().Trim();
                        hdnApplicationId.Value = Session["Application_Id"].ToString();
                        getDetails(hdnApplicationId.Value);
                        GridBind(hdnApplicationId.Value);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        public void getDetails(string ApplicationId)
        {
            DataTable dt = new DataTable();

            dt = CEI.UserDetailsAfterComment(ApplicationId);
            if (dt.Rows.Count > 0)
            {
                txtApplicantName.Text = dt.Rows[0]["Name"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                txtAdharNo.Text = dt.Rows[0]["Aadhar"].ToString();
                txtAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                txtDistrict.Text = dt.Rows[0]["PermanentDistrict"].ToString();
                txtContactNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtEmailId.Text = dt.Rows[0]["Email"].ToString();
                txtCatogary.Text = dt.Rows[0]["Category"].ToString();
                txtStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                if (txtStatus.Text != "Submit")
                {
                    Status.Visible = true;
                }
                string SuperidentComment = dt.Rows[0]["SuperintendentReviewComment"].ToString();              
               if(SuperidentComment != null && SuperidentComment != string.Empty)
                {
                    SupComment.Visible = false;
                    btnSubmit.Visible = false;
                }
            }
        }

        public void GridBind(string ApplicationId)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GETComments(ApplicationId);
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    Comments.Visible = false;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    //string script = "alert(\"No any User exist.\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SuperidentId"]) == hdnId.Value && Convert.ToString(Session["Application_Id"]) == hdnApplicationId.Value)
            {

                if (!string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    DataTable ds = new DataTable();
                    ds = CEI.GETAssign();
                    if (ds.Rows.Count > 0)
                    {
                        string AssignTo = ds.Rows[0]["StaffID"].ToString();
                    

                    int x = CEI.InsertSuperidentantComment(hdnApplicationId.Value, hdnId.Value, txtComment.Text, AssignTo);

                    if (x > 0)
                    {
                        string script = $"alert('Remarks has been submit Succesfully!!.'); window.location='UserDetails.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                    }
                    else
                    {
                        string alertScript = "alert('Please try again.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;

                    }
                    }
                    else
                    {
                        string alertScript = "alert('Not any Xen  active yet.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }

                }
                else
                {
                    txtComment.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter Comments to proceed.');", true);
                    return;
                }
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Superintendent/UserDetails.aspx", false);
        }
    }
}