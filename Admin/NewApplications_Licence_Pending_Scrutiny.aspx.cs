using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.IO.Compression;
using CEIHaryana.UserPages;

namespace CEIHaryana.Admin
{
    public partial class NewApplications_Licence_Pending_Scrutiny : System.Web.UI.Page
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
                        if (Convert.ToString(Session["AdminID"]).ToLower().Trim() == "cei")
                        {
                            ForWardToCommittee.Visible = true;
                        }
                        else
                        {
                            ForWardToCommittee.Visible = false;
                        }
                        GridViewBind(null, null, null);

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
            dt = cei.GetPendingScrutinyApplicationsForCei(Categary, RegistrationNo, Name);
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
                                            Label lblCategory = (Label)row.FindControl("lblCategory");
                                            Category = lblCategory.Text;
                                            Label lblApplicationType = (Label)row.FindControl("lblApplicationType");
                                            Label lblApplicationIdval = (Label)row.FindControl("lblApplicationID");
                                            if (lblApplicationType.Text.Trim() == "New")
                                            {
                                                Label lblRegistrationNo = (Label)row.FindControl("lblRegistrationNo");
                                                RegistrationNo = lblRegistrationNo.Text;
                                            }
                                            else
                                            {
                                                Label lblRegistrationNo = (Label)row.FindControl("lblId");
                                                RegistrationNo = lblRegistrationNo.Text;
                                            }

                                            cei.Insert_LicenceForwardApplicationToSup(lblApplicationIdval.Text.Trim(),CreatedBy, transaction);
                                            //cei.InsertNewLicenceApplicationFromCEI(lblApplicationType.Text.Trim(), RegistrationNo, CommitteeID, Category, CreatedBy, transaction);
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

                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Application Forwarded To SuperIntendent!');  window.location.href='/Admin/NewApplications_Licence_Pending_Scrutiny.aspx';", true);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                Label Categary = (Label)row.FindControl("lblCategory");
                Label lblApplicationType = (Label)row.FindControl("lblApplicationType");
                Label lblId = (Label)row.FindControl("lblId");
                string RegNo = e.CommandArgument.ToString();
                Session["NewApplicationRegistrationNo"] = "";
                Session["NewApplication_Contractor_RegNo"] = "";
                if (lblApplicationType.Text.Trim() == "New")
                {
                    if (Categary.Text == "Wireman" || Categary.Text == "Supervisor")
                    {
                        Session["NewApplicationRegistrationNo"] = RegNo;
                        Response.Write("<script>window.open('/UserPages/New_Registration_Information.aspx','_blank');</script>");
                    }
                    else if (Categary.Text == "Contractor")
                    {
                        Session["NewApplication_Contractor_RegNo"] = RegNo;
                        Response.Write("<script>window.open('/UserPages/New_Registration_Information_Contractor.aspx','_blank');</script>");

                    }
                }
                else
                {
                    if (Categary.Text == "Wireman" || Categary.Text == "Supervisor")
                    {
                        Session["NewApplicationRegistrationNo"] = lblId.Text.Trim();

                        Response.Write("<script>window.open('/UserPages/Certificate_Renewal_Details_Preview.aspx','_blank');</script>");
                    }
                    else
                    {
                        Session["NewApplicationRegistrationNo"] = lblId.Text.Trim();

                        Response.Write("<script>window.open('/UserPages/Contractor_Renewal_Details_Preview.aspx','_blank');</script>");

                    }
                }
            }
            else if (e.CommandName == "Download")
            {

                string RegNo = e.CommandArgument.ToString();
                Label lblApplicationType = (Label)row.FindControl("lblApplicationType");
                Label lblId = (Label)row.FindControl("lblId");
                Label Categary = (Label)row.FindControl("lblCategory");
                DataTable dt;
                if (lblApplicationType.Text.Trim() == "New")
                {
                    dt = cei.getNewUserDocumentsForZip(RegNo);
                }
                else
                {
                    dt = cei.GetRenewalDocuments(lblId.Text);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (DataRow rows in dt.Rows)
                        {
                            string fileUrl = "https://uat.ceiharyana.com" + rows["DocumentPath"].ToString();

                            using (var client = new System.Net.WebClient())
                            {
                                try
                                {
                                    byte[] fileBytes = client.DownloadData(fileUrl);
                                    string fileName = Path.GetFileName(fileUrl);

                                    ZipArchiveEntry entry = zip.CreateEntry(fileName, CompressionLevel.Fastest);
                                    using (var entryStream = entry.Open())
                                    {
                                        entryStream.Write(fileBytes, 0, fileBytes.Length);
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }


                        try
                        {
                            using (MemoryStream zipStream = new MemoryStream())
                            {
                                if (lblApplicationType.Text.Trim() == "New")
                                {
                                    if (Categary.Text == "Wireman" || Categary.Text == "Supervisor")
                                    {
                                        Session["NewApplicationRegistrationNo"] = RegNo;
                                        ExportUtility.ExportCleanHtmlToZip(
                                           pagePath: "/Print_Forms/Print_New_Registration_Information.aspx",
                                           queryString: "RegNo=" + RegNo,
                                           zip: zip,
                                           outputFileName: "RegistrationInfo.html"
                                       );
                                        Session["NewApplicationRegistrationNo"] = "";
                                    }
                                    else
                                    {
                                        Session["NewApplication_Contractor_RegNo"] = RegNo;
                                        ExportUtility.ExportCleanHtmlToZip(
                                          pagePath: "/Print_Forms/Print_New_Registration_Information_Contractor.aspx",
                                          queryString: "RegNo=" + RegNo,
                                          zip: zip,
                                          outputFileName: "RegistrationInfo.html"
                                      );
                                        Session["NewApplication_Contractor_RegNo"] = "";
                                    }
                                }
                                else
                                {
                                    if (Categary.Text == "Contractor")
                                    {
                                        Session["NewApplicationRegistrationNo"] = lblId.Text;
                                        ExportUtility.ExportCleanHtmlToZip(
                                              pagePath: "/Print_Forms/Contractor_Licence_Renewal_Print.aspx",
                                              queryString: "RegNo=" + RegNo,
                                              zip: zip,
                                              outputFileName: "RegistrationInfo.html"
                                          );
                                        Session["NewApplicationRegistrationNo"] = "";
                                    }
                                    else
                                    {
                                        Session["NewApplicationRegistrationNo"] = lblId.Text;
                                        ExportUtility.ExportCleanHtmlToZip(
                                              pagePath: "/Print_Forms/Licence_Renewal_Print.aspx",
                                              queryString: "RegNo=" + RegNo,
                                              zip: zip,
                                              outputFileName: "RegistrationInfo.html"
                                          );
                                        Session["NewApplicationRegistrationNo"] = "";
                                    }
                                }
                            }



                        }
                        catch (Exception ex)
                        {
                            // log if page not reachable
                        }

                    }

                    string zipFileName = RegNo + "_Documents.zip";
                    Response.Clear();
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + RegNo + "_Documents" + ".zip");
                    memoryStream.Position = 0; // reset before writing
                    memoryStream.CopyTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();


                }
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Session["double_Clickbutton"] = "1";
        }
    }
}