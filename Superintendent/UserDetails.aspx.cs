using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Superintendent
{
    public partial class UserDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SuperidentId"]) != null && Convert.ToString(Session["SuperidentId"]) != string.Empty)
                    {
                        BindApplicationStatus();
                        string Id = Session["SuperidentId"].ToString();
                        DataTable ds = new DataTable();
                        ds = CEI.GETActiveSuperident(Id);
                        if (ds.Rows.Count > 0)
                        {
                            BindDistrict();
                            GridBind();
                        }
                        else
                        {

                            string script = "alert(\"No any request submit for Licence yet.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }
        }
        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An Error Occured');", true);
            }
        }
        public void GridBind()
        {
            try
            {
                string District = ddlDistrict.SelectedItem.ToString();
                string Category = ddlcategory.SelectedItem.ToString();
                string Status = ddlApplicationStatus.SelectedValue;
                if (Status == "0" || string.IsNullOrEmpty(Status))
                {
                    Status = null; 
                }
                //string Status = ddlApplicationStatus.SelectedItem.ToString();
                DataTable ds = new DataTable();
                ds = CEI.BindDataForSuperident(Category, District, Status, txtName.Text.Trim());
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No any User exist.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            Label lblRegistrationId = (Label)row.FindControl("lblRegistrationId");
            Label lblCategory = (Label)row.FindControl("lblCategory");
            if (e.CommandName == "Select")
            {
                Session["Application_Id"] = lblID.Text;
                //Session["Superidentent"] = "SUP_CDG";

                Response.Redirect("/Superintendent/CommentForRequest.aspx", false);


            }
            else if (e.CommandName == "Download")
            {

                string RegNo = e.CommandArgument.ToString();
                string RegistrationId=string.Empty;
                Label lblApplicationType = (Label)row.FindControl("lblApplicationType");
                Label Categary = (Label)row.FindControl("lblCategory");
                DataSet ds = CEI.Licence_Cei_Approval_GetHeaderDetails(RegNo);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                     RegistrationId = ds.Tables[0].Rows[0]["RedirectionRegistrationId"].ToString();
                }
                    DataTable dt;
                if (lblApplicationType.Text.Trim() == "New")
                {
                    dt = CEI.getNewUserDocumentsForZip(RegistrationId);
                }
                else
                {
                    dt = CEI.GetRenewalDocuments(RegistrationId);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (DataRow rows in dt.Rows)
                        {
                            string fileUrl = "https://ceiharyana.com" + rows["DocumentPath"].ToString();

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
                                    // Log error if file missing
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
                                        Session["NewApplicationRegistrationNo"] = RegistrationId;
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
                                        Session["NewApplication_Contractor_RegNo"] = RegistrationId;
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
                                        Session["NewApplicationRegistrationNo"] = RegistrationId;
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
                                        Session["NewApplicationRegistrationNo"] = RegistrationId;
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
            //Commented By Aslam on 16 sep 2025 because its not required here. . 
            //else if (e.CommandName == "Print")
            //{
            //    Label lblLicenceType = (Label)row.FindControl("lblLicenceType");
            //    string LicenceType = lblLicenceType != null ? lblLicenceType.Text : string.Empty;

            //    if (LicenceType == "New")
            //    {
            //        if (lblCategory.Text == "Contractor")
            //        {

            //            Session["NewApplication_Contractor_RegNo"] = lblRegistrationId.Text;
            //            Response.Redirect("/UserPages/New_Registration_Information_Contractor.aspx", false);
            //        }
            //        else
            //        {
            //            Session["NewApplicationRegistrationNo"] = lblRegistrationId.Text;
            //            Response.Redirect("/UserPages/New_Registration_Information.aspx", false);
            //        }
            //    }
            //    else
            //    {
            //        string Id = CEI.GetIDfForRenewalPrint(lblID.Text);
            //        if (lblCategory.Text == "Contractor")
            //        {
            //            Session["NewApplicationRegistrationNo"] = Id;
            //            Response.Redirect("/UserPages/Contractor_Renewal_Details_Preview.aspx", false);
            //        }
            //        else
            //        {
            //            Session["NewApplicationRegistrationNo"] = Id;
            //            Response.Redirect("/UserPages/Certificate_Renewal_Details_Preview.aspx", false);
            //        }

            //    }
            //}

        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchBy.SelectedValue == "1")
            {
                district.Visible = true;
                ddlApplicationStatus.SelectedValue = "0";
                txtName.Text = "";
                Name.Visible = false;
                AppStatus.Visible = false;
            }
            else if (ddlSearchBy.SelectedValue == "2")
            {
                ddlApplicationStatus.SelectedValue = "0";
                txtName.Text = "";
                Name.Visible = false;
                district.Visible = false;
                AppStatus.Visible = true;
            }
            else if (ddlSearchBy.SelectedValue == "3")
            {
                ddlDistrict.SelectedValue = "0";
                ddlApplicationStatus.SelectedValue = "0";
                district.Visible = false;
                AppStatus.Visible = false;
                Name.Visible = true;
            }
            else
            {
                ddlDistrict.SelectedValue = "0";
                ddlApplicationStatus.SelectedValue = "0";
                ddlSearchBy.SelectedValue = "0";
                txtName.Text = "";
                district.Visible = false;
                AppStatus.Visible = false;
                Name.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue != "0")
            {
                if (ddlSearchBy.SelectedValue != "0")
                {
                    if (ddlSearchBy.SelectedValue == "1")
                    {


                        if (ddlDistrict.SelectedItem.ToString() == "Select")
                        {
                            ddlDistrict.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select District by to proceed.');", true);
                            return;
                        }
                    }
                    else if (ddlSearchBy.SelectedValue == "2")
                    {
                        ddlDistrict.SelectedValue = "0";
                        if (ddlApplicationStatus.SelectedItem.ToString() == "Select")
                        {
                            ddlApplicationStatus.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Status by to proceed.');", true);
                            return;
                        }

                    }
                    else if (ddlSearchBy.SelectedValue == "3")
                    {

                        if (string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            txtName.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Enter the name  to proceed.');", true);
                            return;

                        }
                    }

                    GridBind();
                }
                else
                {
                    ddlSearchBy.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Search by to proceed.');", true);
                    return;
                }
            }
            else
            {
                ddlcategory.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Category to proceed.');", true);
                return;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlcategory.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlApplicationStatus.SelectedValue = "0";
            ddlSearchBy.SelectedValue = "0";
            txtName.Text = "";
            district.Visible = false;
            AppStatus.Visible = false;
            Name.Visible = false;
            GridBind();
        }

        private void BindApplicationStatus()
        {
            DataTable dt = CEI.GetApplicationStatus();

            ddlApplicationStatus.DataSource = dt;
            ddlApplicationStatus.DataTextField = "ApplicationStatus";
            ddlApplicationStatus.DataValueField = "ApplicationStatus";
            ddlApplicationStatus.DataBind();

            // Add a default option at the top
            ddlApplicationStatus.Items.Insert(0, new ListItem("Select", "0"));

            ddlApplicationStatus.SelectedValue = "0";
        }

    }
}