using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class DisConnectionNoticeView : System.Web.UI.Page
    {
        //Page created by neeraj 29-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnOwnerId.Value = "";
                    hdnDisId.Value = "";
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        if (Session["Dis_Id"] != null && Convert.ToString(Session["Dis_Id"]) != string.Empty)
                        {
                            hdnOwnerId.Value = Session["StaffID"].ToString();
                            hdnDisId.Value = Session["Dis_Id"].ToString();
                            GetUtilityData(hdnDisId.Value);
                            GetData(hdnDisId.Value);
                            BindGrid(hdnDisId.Value);
                        }
                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }
        private void GetUtilityData(string DisId)
        {
            try
            {
                if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["StaffID"]) && Convert.ToString(hdnDisId.Value) == Convert.ToString(Session["Dis_Id"]))
                {
                    DataTable dt = CEI.GetUtilityDetails(DisId);
                    txtUtility.Text = dt.Rows[0]["UtilityName"].ToString();
                    txtWing.Text = dt.Rows[0]["WingName"].ToString();
                    txtZone.Text = dt.Rows[0]["ZoneName"].ToString();
                    txtCircle.Text = dt.Rows[0]["CircleName"].ToString();
                    txtDivision.Text = dt.Rows[0]["DivisionName"].ToString();
                    txtSubDivision.Text = dt.Rows[0]["SubDivision"].ToString();
                }
                else
                {
                    Session["StaffID"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GetData(string DisId)
        {
            try
            {
                if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["StaffID"]) && Convert.ToString(hdnDisId.Value) == Convert.ToString(Session["Dis_Id"]))
                {
                    DataTable dt = CEI.GetDSCDetails(DisId);
                    txtName.Text = dt.Rows[0]["Owner_FirmName"].ToString();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    txtAccNo.Text = dt.Rows[0]["AccountNo"].ToString();
                    TxtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtCategory.Text = dt.Rows[0]["Category"].ToString();
                    if (txtCategory.Text != null && txtCategory.Text != string.Empty)
                    {
                        OtherCat.Visible = false;
                    }
                    else
                    {
                        OtherCat.Visible = true;
                        txtOtherCategory.Text = dt.Rows[0]["OtherCategory"].ToString();
                    }
                    txtSanctionLoad.Text = dt.Rows[0]["SanctionLoad"].ToString();
                    hnFile.Value = dt.Rows[0]["ActionReport"].ToString();
                    hnOtherfile.Value = dt.Rows[0]["OtherDocument"].ToString();
                    if (hnOtherfile.Value != null && hnOtherfile.Value != string.Empty)
                    {
                        Document.Visible = true;
                    }
                    txtStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                    if (txtStatus.Text == "Submit")
                    {
                        OwnerAttactment.Visible = false;
                        Suggestion.Visible = false;
                        CeiRemarks.Visible = true;
                        OwnerRemarks.Visible = false;
                        txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();

                    }
                    else if (txtStatus.Text == "Approved")
                    {
                        OwnerAttactment.Visible = true;
                        Suggestion.Visible = true;
                        txtSuggestion.Text = dt.Rows[0]["Suggestions"].ToString();
                        OwnerRemarks.Visible = true;
                        txtOwnerRemarks.Text = dt.Rows[0]["OwnerRemarks"].ToString();
                    }
                    else
                    {
                        OwnerAttactment.Visible = true;
                        OwnerRemarks.Visible = true;
                        Suggestion.Visible = false;
                        CeiRemarks.Visible = false;
                        txtOwnerRemarks.Text = dt.Rows[0]["OwnerRemarks"].ToString();
                    }

                }
                else
                {
                    Session["StaffID"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        public void BindGrid(string Id)
        {
            try
            {
                DataTable dt = CEI.GetDisconnectionDoc_CEI(Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = dt;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ////fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    string fileName = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileName);
                    string filePath = Path.Combine(folderPath);
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["StaffID"]))
            {
                Response.Redirect("/Officers/DisconnectionRequest.aspx", false);
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = hnFile.Value;
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);

            }
        }

        protected void lnkODocument_Click(object sender, EventArgs e)
        {
            string fileName = hnOtherfile.Value;
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);

            }

        }
    }
}