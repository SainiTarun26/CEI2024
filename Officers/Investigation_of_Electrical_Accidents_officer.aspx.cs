﻿using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
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
    public partial class Investigation_of_Electrical_Accidents_officer : System.Web.UI.Page
    {
        //Page created by gurmeet
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                    {
                        if (Session["Accident_ID"] != null && Session["Accident_ID"].ToString() != "")
                        {
                            int Accident_ID = Convert.ToInt32(Session["Accident_ID"]);
                            GetData(Accident_ID);
                        }
                        else
                        {
                            Response.Redirect("/Officers/AccidentialReports.aspx", false); //for reinitlization session
                        }
                    }
                    else
                    {
                        Response.Redirect("/Logout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Logout.aspx", false);
            }
        }

        private void GetData(int Accident_ID)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetAccidentReportData(Accident_ID);
                if (ds != null)
                {
                    txtApplicationID.Text = ds.Rows[0]["Id"].ToString();
                    txtEmailId.Text = ds.Rows[0]["Email"].ToString();
                    txtContact.Text = ds.Rows[0]["Mobile"].ToString();

                    txtUtility.Text = ds.Rows[0]["NameOfUtility"].ToString();
                    txtSubdivision.Text = ds.Rows[0]["NameOfSubDivision"].ToString();
                    txtZone.Text = ds.Rows[0]["NameofZone"].ToString();
                    txtCircle.Text = ds.Rows[0]["NameOfCircle"].ToString();
                    txtDivision.Text = ds.Rows[0]["NameOfDivision"].ToString();
                    txtAccidentDate.Text = ds.Rows[0]["DateOfAccident"].ToString();
                    string TimeofAccident = ds.Rows[0]["TimeOfAccident"].ToString();
                    if (!string.IsNullOrEmpty(TimeofAccident))
                    {
                        txtAccidentTime.Text = ds.Rows[0]["TimeOfAccident"].ToString();
                    }
                    else
                    {
                        DivAccidentTime.Visible = false;
                    }
                    txtDistrict.Text = ds.Rows[0]["District"].ToString();
                    txtThana.Text = ds.Rows[0]["Thana"].ToString();
                    txtTehsil.Text = ds.Rows[0]["Tehsil"].ToString();
                    txtVillageCityTown.Text = ds.Rows[0]["VillageCityTown"].ToString();
                    txtVoltageLevel.Text = ds.Rows[0]["VoltageLevelOnWhichAccidentOccurred"].ToString();
                    //txtElectricalEquipment.Text = ds.Rows[0]["ElectricalEquipmentOfAccident"].ToString();
                    string ElectricalEquipment = ds.Rows[0]["ElectricalEquipmentOfAccident"].ToString();
                    if (ElectricalEquipment == "Other")
                    {
                        txtElectricalEquipment.Text = ds.Rows[0]["InCaseOfOther"].ToString();
                    }
                    else
                    {
                        txtElectricalEquipment.Text = ds.Rows[0]["ElectricalEquipmentOfAccident"].ToString();
                    }
                    //txtSerialNo.Text = ds.Rows[0]["SerialNo/Name"].ToString();                    
                    string permises = ds.Rows[0]["PremisesOfAccident"].ToString();
                    if (permises != "Other")
                    {
                        txtPermises.Text = permises;
                    }
                    else
                    {
                        txtPermises.Text = ds.Rows[0]["InCaseOfOtherPremises"].ToString();
                    }
                    string TempId = ds.Rows[0]["TempId"].ToString();
                    AnimalGridViewBind(TempId);
                    HumanGridViewBind(TempId);
                    GridBindDocument(TempId);
                    string ApplicationStatus = ds.Rows[0]["ApplicationStatus"].ToString();
                    if (ApplicationStatus == "Report Issued" || ApplicationStatus == "Return" || ApplicationStatus == "Reject")
                    {
                        string Remarks = ds.Rows[0]["Remarks"].ToString();
                        if (!string.IsNullOrEmpty(Remarks))
                        {
                            txtRemarks.Text = Remarks;
                            txtRemarks.ReadOnly = true;
                        }
                        if (ApplicationStatus == "Report Issued")
                        {
                            ApplicationStatus = "Approved";
                        }
                        ddlAction.SelectedIndex = ddlAction.Items.IndexOf(ddlAction.Items.FindByText(ApplicationStatus));
                        ddlAction.Attributes.Add("disabled", "true");
                        btnSubmit.Visible = false;
                    }
                    else if (ApplicationStatus == "ReSubmit" || ApplicationStatus == "Submit")
                    {

                        int RequestNo = Convert.ToInt16(ds.Rows[0]["RequestNo"]);
                        if (RequestNo > 1)
                        {
                            ListItem Returnitem = ddlAction.Items.FindByText("Return");
                            ddlAction.Items.Remove(Returnitem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void AnimalGridViewBind(string Id)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDataAnimalAccident(Id);
            if (ds.Rows.Count > 0 && ds != null)
            {
                AnimalGridView.DataSource = ds;
                AnimalGridView.DataBind();
            }
            else
            {
                Animal_Div.Visible = false;
                AnimalGridView.DataSource = null;
                AnimalGridView.DataBind();
            }
        }
        public void HumanGridViewBind(string TempId)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDataHumanAccident(TempId);
            if (ds.Rows.Count > 0 && ds != null)
            {
                HumanGridView.DataSource = ds;
                HumanGridView.DataBind();
            }
            else
            {
                Human_Div.Visible = false;
                HumanGridView.DataSource = null;
                HumanGridView.DataBind();
            }
        }

        protected void GridBindDocument(string TempId)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.ViewDocumentsAccidentApplication(TempId);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    //string fileNames = e.CommandArgument.ToString();
                    //string folderPath = Server.MapPath(fileNames);
                    //string filePath = Path.Combine(folderPath);

                    string fileNames = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileNames}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Accident_ID"].ToString() != null && Session["Accident_ID"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    string AlertMessage = string.Empty;
                    string OfficerId = Session["StaffID"].ToString();
                    int AccidentID = Convert.ToInt32(Session["Accident_ID"]);
                    if (ddlAction.SelectedValue != "0" && ddlAction.SelectedValue != null)
                    {
                        if ((ddlAction.SelectedValue == "2" || ddlAction.SelectedValue == "3") && string.IsNullOrEmpty(txtRemarks.Text))
                        {

                            txtRemarks.Focus();
                            return;
                        }

                        string fileName=string.Empty;
                        string dbPath = string.Empty;
                        string fullPath = string.Empty;
                        string filePathInfo = string.Empty;

                        if (ddlAction.SelectedValue == "1")
                        {                            
                            if (!File_approvedDocument.HasFile || !IsValidPdf(File_approvedDocument))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                                    "alert('Please upload a valid PDF file (Max: 1MB)');", true);
                                File_approvedDocument.Focus();
                                return;
                            }

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + "/Accident/"+ AccidentID + "/ApprovedDocument/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + "/Accident/" + AccidentID + "/ApprovedDocument/"));
                            }                            
                            string path = "/Attachment/" + "/Accident/" + AccidentID + "/ApprovedDocument/";
                            fileName = "ApprovedDocument" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            filePathInfo = Server.MapPath("~/Attachment/" + "/Accident/" + AccidentID + "/ApprovedDocument/" + fileName);
                            dbPath = path + fileName;
                            //string DirectoryPath = Server.MapPath($"~Attachment/ApprovedDocument/");
                            //// Ensure directory exists
                            //if (!Directory.Exists(DirectoryPath))
                            //{
                            //    Directory.CreateDirectory(DirectoryPath);
                            //}
                            //// Generate file path and name
                            //fileName = $"{AccidentID}/ApprovedDocument_{DateTime.Now:yyyyMMddHHmmssFFF}.pdf";
                            //dbPath = $"/Attachment/ApprovedDocument/{AccidentID}/{fileName}";
                            //fullPath = Path.Combine(DirectoryPath, fileName);
                            //fileUpload.PostedFile.SaveAs(fullPath);
                            AlertMessage = "Application approved and report issued to the user.";
                            
                        }
                        else if (ddlAction.SelectedValue == "2")
                        {
                            AlertMessage = "Application returned to the concerned site owner";
                        }
                        else
                        {
                            AlertMessage = "Application has been rejected.";
                        }

                        int x = CEI.AccidentAction(AccidentID, ddlAction.SelectedItem.Text, txtRemarks.Text.Trim(), OfficerId, dbPath);
                        if (x > 0)
                        {
                            if (ddlAction.SelectedValue == "1")
                            {
                                
                                //File_approvedDocument.PostedFile.SaveAs(fullPath);
                                File_approvedDocument.PostedFile.SaveAs(filePathInfo);

                            }
                            ScriptManager.RegisterStartupScript(this, GetType(), "successful",
                            "alert(' " + AlertMessage + "'); window.location.href = '/Officers/AccidentialReports.aspx';",
                            true);
                            //ScriptManager.RegisterStartupScript(this, GetType(), "successful",
                            //   "alert('{AlertMessage}'); window.location.href = '/Officers/AccidentialReports.aspx'; ", true);
                            //// Response.Redirect("/Officers/AccidentialReports.aspx", false);
                        }
                    }
                }
                else
                {
                    Response.Redirect("/Logout.aspx");
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblIsDocumentUpload = (Label)e.Row.FindControl("lblIsDocumentUpload");
                    //LinkButton LnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
                    LinkButton LnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

                    //LnkDocumemtPath.Visible = true;
                    //LnkDocumemtPath.Text = "Click here to view document";
                    if (lblIsDocumentUpload.Text == "Yes")
                    {
                        LnkDocumemtPath.Visible = true;
                    }
                    else
                    {
                        LnkDocumemtPath.Visible = false;
                        //LnkDocumemtPath2.Text = "Click here to view document";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAction.SelectedValue == "1") 
            {
                Document.Visible = true;
            }
            else
            {
                Document.Visible = false;
            }
        }
        private bool IsValidPdf(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile)
            {
                return false;
            }
            if (Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")  // Check file extension
            {
                return false;
            }
            if (fileUpload.PostedFile.ContentLength > 1048576)   // Check file size (1 MB = 1048576 bytes)
            {
                return false;
            }
            return true;
        }
    }
}