using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Investigation_of_Electrical_Accidents_SiteOwner_History : System.Web.UI.Page
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
                        if (Session["Accident_Id_siteowner"] != null && Session["Accident_Id_siteowner"].ToString() != "")
                        {
                            int Accident_ID = Convert.ToInt32(Session["Accident_Id_siteowner"]);
                            GetData(Accident_ID);
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
                    txtAccidentDate.Text = ds.Rows[0]["DateOfAccident"].ToString();
                    txtAccidentTime.Text = ds.Rows[0]["TimeOfAccident"].ToString();
                    txtDistrict.Text = ds.Rows[0]["District"].ToString();
                    txtThana.Text = ds.Rows[0]["Thana"].ToString();
                    txtTehsil.Text = ds.Rows[0]["Tehsil"].ToString();
                    txtVillageCityTown.Text = ds.Rows[0]["VillageCityTown"].ToString();
                    txtVoltageLevel.Text = ds.Rows[0]["VoltageLevelOnWhichAccidentOccurred"].ToString();
                    txtElectricalEquipment.Text = ds.Rows[0]["ElectricalEquipmentOfAccident"].ToString();
                    txtSerialNo.Text = ds.Rows[0]["SerialNo/Name"].ToString();
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
                    string Remarks = ds.Rows[0]["Remarks"].ToString();
                    if (!string.IsNullOrEmpty(Remarks))
                    {
                        Div_Remark.Visible = true;
                        txtRemarks.Text = Remarks;
                        txtRemarks.ReadOnly = true;
                    }
                    string ApplicationStatus = ds.Rows[0]["ApplicationStatus"].ToString();
                    if ( ApplicationStatus == "Return") //  ApplicationStatus == "Report Issued" || ApplicationStatus == "Reject")
                    {  }
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

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    string fileNames = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileNames);                   

                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileNames}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

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
    }
}