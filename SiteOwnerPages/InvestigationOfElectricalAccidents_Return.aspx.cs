using CEI_PRoject;
using CEIHaryana.Officers;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class InvestigationOfElectricalAccidents_Return : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                    {
                        if (Session["Accident_IdReturn_siteowner"] != null && Session["Accident_IdReturn_siteowner"].ToString() != "")
                        {
                            int Accident_ID = Convert.ToInt32(Session["Accident_IdReturn_siteowner"]);
                            BindDistrict();
                            GetData(Accident_ID);
                            Page.Session["FlagHumanReturn"] = 0;
                            Page.Session["FlagAnimalReturn"] = 0;
                        }
                        else
                        {
                            Response.Redirect("~/SiteOwnerPages/AccidentialHistory_SiteOwner.aspx", false); //for reinitlization session
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                Response.Redirect("/Logout.aspx", false);
            }
        }
        private void GetData(int Accident_ID)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetAccidentReportData(Accident_ID);
                if (ds != null && ds.Rows.Count > 0)
                {
                    txtUtility.Text = ds.Rows[0]["NameOfUtility"].ToString();
                    txtSubdivision.Text = ds.Rows[0]["NameOfSubDivision"].ToString();
                    txtZone.Text = ds.Rows[0]["NameofZone"].ToString();
                    txtCircle.Text = ds.Rows[0]["NameOfCircle"].ToString();
                    txtDivision.Text = ds.Rows[0]["NameOfDivision"].ToString();
                    //DateTime AccidentDate = Convert.ToDateTime(ds.Rows[0]["DateOfAccident"]);
                    string AccidentDate = ds.Rows[0]["DateOfAccident"].ToString();
                    txtAccidentDate.Text = DateTime.Parse(AccidentDate).ToString("yyyy-MM-dd");
                    txtAccidentTime.Text = ds.Rows[0]["TimeOfAccident"].ToString();
                    string dist = ds.Rows[0]["District"].ToString();
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(dist));
                    txtThana.Text = ds.Rows[0]["Thana"].ToString();
                    txtTehsil.Text = ds.Rows[0]["Tehsil"].ToString();
                    txtVillageCityTown.Text = ds.Rows[0]["VillageCityTown"].ToString();
                    txtVoltageLevel.Text = ds.Rows[0]["VoltageLevelOnWhichAccidentOccurred"].ToString();
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
                    Hdn_TempId.Value = TempId;
                    AnimalGridViewBind(TempId);
                    HumanGridViewBind(TempId);
                    GridBindDocument(TempId);
                    string Remarks = ds.Rows[0]["Remarks"].ToString();
                    if (!string.IsNullOrEmpty(Remarks))
                    {
                        //Div_Remark.Visible = true;
                        //txtRemarks.Text = Remarks;
                        //txtRemarks.ReadOnly = true;
                    }
                    string ApplicationStatus = ds.Rows[0]["ApplicationStatus"].ToString();
                    if (ApplicationStatus == "Return") //  ApplicationStatus == "Report Issued" || ApplicationStatus == "Reject")
                    { }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('no data found for this Id')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        #region Binding Grid/Dropdown
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
            catch (Exception ex) { }
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
                ds = CEI.ViewDocumentsAccidentApplicationForReturn(TempId);
                if (ds.Tables.Count > 0 && ds != null)
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
        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblIsDocumentUpload = (Label)e.Row.FindControl("lblIsDocumentUpload");
                    LinkButton LnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
                    if (lblIsDocumentUpload.Text == "Yes")
                    {
                        LnkDocumemtPath.Visible = true;
                    }
                    else
                    {
                        LnkDocumemtPath.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        //protected void HumanGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        Control ctrl = e.CommandSource as Control;
        //        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //        LinkButton lnkbtn =(LinkButton)row.FindControl("LnkEditHuman");
        //        if (e.CommandName == "EditHuman")
        //        {

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        protected void LnkEditHuman_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnhuman = (LinkButton)sender;
                int HumanId = Convert.ToInt32(lnkbtnhuman.CommandArgument);
                Hdn_HumanModelId.Value = HumanId.ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetHumanAccident_singledata(HumanId);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    txtHumanName.Text = ds.Rows[0]["NameOfVictim"].ToString();
                    txtHumanFatherName.Text = ds.Rows[0]["FatherNameOrSpouseName"].ToString();
                    txtAge.Text = ds.Rows[0]["ApproximateAge"].ToString();
                    string Gender = ds.Rows[0]["Gender"].ToString();
                    ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(Gender));
                    string Categoryofperson = ds.Rows[0]["Categoryofperson"].ToString();
                    ddlPersonCategory.SelectedIndex = ddlPersonCategory.Items.IndexOf(ddlPersonCategory.Items.FindByText(Categoryofperson));
                    txtPostalAddress.Text = ds.Rows[0]["FullPostalAddress"].ToString();
                    string Type = ds.Rows[0]["Type"].ToString();
                    ddlFatelNonFatelHuman.SelectedIndex = ddlFatelNonFatelHuman.Items.IndexOf(ddlFatelNonFatelHuman.Items.FindByText(Type));
                    Hdn_TempId.Value = ds.Rows[0]["TempId"].ToString();
                    ddlFatelNonFatelHuman.Enabled = false;
                    Session["FlagHumanReturn"] = 1;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#humanModal').modal('show');", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void LnkEditAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnAnimal = (LinkButton)sender;
                string HumanId = lnkbtnAnimal.CommandArgument;
                Hdn_AnimalModelId.Value = HumanId;
                DataTable ds = new DataTable();
                ds = CEI.GetAnimalAccident_singledata(HumanId);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    txtOwnerName.Text = ds.Rows[0]["NameOfOwner"].ToString();
                    txtDescriptionAnimal.Text = ds.Rows[0]["Description"].ToString();
                    txtNumber.Text = ds.Rows[0]["Number"].ToString();
                    txtAddressofOwner.Text = ds.Rows[0]["AddressOfOwner"].ToString();
                    string Type = ds.Rows[0]["Type"].ToString();
                    ddlFatelTypeAnimal.SelectedIndex = ddlFatelTypeAnimal.Items.IndexOf(ddlFatelTypeAnimal.Items.FindByText(Type));
                    Hdn_TempId.Value = ds.Rows[0]["TempId"].ToString();
                    //txtHumanName.ReadOnly = true;
                    //txtHumanFatherName.ReadOnly = true;
                    //txtNumber.ReadOnly = true;
                    //txtPostalAddress.ReadOnly = true;
                    ddlFatelTypeAnimal.Enabled = false;
                    Session["FlagAnimalReturn"] = 1;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#animalModal').modal('show');", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnAnimalUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (Convert.ToString(Session["FlagAnimalReturn"]) == "1")
                    {
                        if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                        {
                            if (Hdn_AnimalModelId.Value == null || Hdn_AnimalModelId.Value == "")
                            {
                                return;
                            }
                            if (Hdn_AnimalModelId.Value != null && Hdn_AnimalModelId.Value != "" && Hdn_TempId.Value != null && Hdn_TempId.Value != "")
                            {
                                int AnimalId = Convert.ToInt32(Hdn_AnimalModelId.Value);
                                int Number = Convert.ToInt32(txtNumber.Text.Trim());
                                int x = CEI.UpdateAnimalData(txtDescriptionAnimal.Text.Trim(), Number, txtOwnerName.Text.Trim(),
                                    txtAddressofOwner.Text.Trim(), Convert.ToString(Session["SiteOwnerId"]), AnimalId
                                    );
                                if (x > 0)
                                {
                                    //hdnFieldGridView.Value = "2";
                                    //txtDescriptionAnimal.Text = ""; txtOwnerName.Text = "";
                                    //txtAddressofOwner.Text = ""; ddlFatelTypeAnimal.SelectedIndex = 0; txtNumber.Text = "";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideModalScript", "hideModal('animalModal');", true);
                                    AnimalGridViewBind(Hdn_TempId.Value);
                                }
                                else
                                {
                                    //return;
                                }
                            }
                            //}
                            //Session["FlagAnimal"] = 0;
                        }
                        Session["FlagAnimalReturn"] = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void btnHumanUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {

                    if (Convert.ToString(Session["FlagHumanReturn"]) == "1")
                    {
                        if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                        {

                            if (Hdn_HumanModelId.Value != null && Hdn_HumanModelId.Value != "" && Hdn_TempId.Value != null && Hdn_TempId.Value != "")
                            {
                                int HumanId = Convert.ToInt32(Hdn_HumanModelId.Value);
                                int x = CEI.UpdateHumanData(txtHumanName.Text.Trim(), txtHumanFatherName.Text.Trim(), ddlGender.SelectedItem.Text == "Select" ? null : ddlGender.SelectedItem.Text,
                                   txtAge.Text.Trim(), ddlPersonCategory.SelectedItem.Text == "Select" ? null : ddlPersonCategory.SelectedItem.Text,
                                   txtPostalAddress.Text.Trim(), Convert.ToString(Session["SiteOwnerId"]), HumanId//Convert.ToInt32(Session["TempUniqueId"])
                                   );
                                if (x > 0)
                                {
                                    //txtHumanName.Text = ""; txtHumanFatherName.Text = ""; ddlGender.SelectedIndex = 0; ddlPersonCategory.SelectedIndex = 0;
                                    //txtAge.Text = ""; ddlFatelNonFatelHuman.SelectedIndex = 0; txtPostalAddress.Text = "";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideModalScript", "hideModal('humanModal');", true);
                                    HumanGridViewBind(Hdn_TempId.Value);
                                }
                                else
                                {
                                    //return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            Response.Redirect("/Logout.aspx", false);
                        }
                        Session["FlagHumanReturn"] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                // throw;
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

                    string fileNames = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
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
            if ((Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != ""))
            {
                
                string CreatedBy, documentName = string.Empty;
                int DocumentNameId, DocumentId = 0;
                CreatedBy = Convert.ToString(Session["SiteOwnerId"]);
                if (Hdn_TempId.Value == null || Hdn_TempId.Value == "")
                {
                    return;
                }

                if (IsValidAccidentDateTime())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                   "alert('future time is not allowed please select time correctly');", true);
                    return;
                }

                long TempId = Convert.ToInt64(Hdn_TempId.Value);
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    SqlTransaction Transaction = null;
                    try
                    {
                        connection.Open();
                        Transaction = connection.BeginTransaction();

                        foreach (GridViewRow rows in grd_Documemnts.Rows)
                        {
                            
                            FileUpload Fileuploadcontrol = (FileUpload)rows.FindControl("FileUpload1");
                            HiddenField Hdn_DocumentID = (HiddenField)rows.FindControl("HdnDocumentID");
                            HiddenField HdnDocumentName = (HiddenField)rows.FindControl("HdnDocumentName");
                            HiddenField HdnDocumentNameId = (HiddenField)rows.FindControl("HdnDocumentNameID");

                            documentName = HdnDocumentName.Value;
                            if (string.IsNullOrEmpty(Hdn_DocumentID.Value))
                            {
                                Hdn_DocumentID.Value = "10";
                            }
                            DocumentId =Convert.ToInt32(Hdn_DocumentID.Value);
                            DocumentNameId= Convert.ToInt32(HdnDocumentNameId.Value);
                            if (Fileuploadcontrol.HasFile && Fileuploadcontrol != null)
                            {
                                if (Path.GetExtension(Fileuploadcontrol.FileName).ToLower() == ".pdf" && Fileuploadcontrol.PostedFile.ContentLength <= 1048576)
                                {
                                    string fileName = ""; string dbPath = ""; string fullPath = "";
                                    string directoryPath = Server.MapPath($"~/Attachment/{TempId}/{CreatedBy}/");
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }
                                    fileName = $"{documentName}_{DateTime.Now:yyyyMMddHHmmssFFF}.pdf";           // Generate file path and name
                                    dbPath = $"/Attachment/{TempId}/{CreatedBy}/{fileName}";
                                    fullPath = Path.Combine(directoryPath, fileName);
                                    int x = CEI.UpdateDocumentData(DocumentId,TempId, DocumentNameId, documentName, fileName, dbPath, CreatedBy, Transaction);
                                    Fileuploadcontrol.PostedFile.SaveAs(fullPath);
                                }
                                else
                                {
                                    throw new Exception("Please check Pdf and size of Pdf");                                    
                                }

                            }
                        }

                        int Accident_ID = Convert.ToInt32(Session["Accident_IdReturn_siteowner"]);
                        CEI.UpdateAccidentData(Accident_ID, TempId, txtAccidentDate.Text,txtAccidentTime.Text,ddlDistrict.SelectedItem.Text,txtThana.Text.Trim(),txtTehsil.Text.Trim(),
                            txtVillageCityTown.Text.Trim(),CreatedBy,Transaction);
                        
                        Transaction.Commit();
                        ScriptManager.RegisterStartupScript(this, GetType(), "successful",
                                "alert('Successfully Updated'); window.location.href = '/SiteOwnerPages/AccidentialHistory_SiteOwner.aspx'; ", true);
                    }
                    catch (Exception ex)
                    {
                        Transaction?.Rollback();
                        string errorMessage = ex.Message.Replace("'", "\\'");
                        ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    }
                    finally
                    {
                        Transaction?.Dispose();
                        connection.Close();
                    }
                }

            }

        }
        private bool IsValidAccidentDateTime()
        {
            DateTime accidentDate, accidentTime;

            if (DateTime.TryParse(txtAccidentDate.Text, out accidentDate) &&
                TimeSpan.TryParse(txtAccidentTime.Text, out TimeSpan timePart))
            {
                DateTime fullAccidentDateTime = accidentDate.Date.Add(timePart);
                if (accidentDate.Date == DateTime.Today && fullAccidentDateTime > DateTime.Now)
                {
                    return true;
                }
            }

            return false;
        }
    }
}