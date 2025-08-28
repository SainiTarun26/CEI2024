using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class Investigation_of_Electrical_Accidents_officer_Admin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                    {
                        if (Session["Accident_IDAdmin"] != null && Session["Accident_IDAdmin"].ToString() != "")
                        {
                            int Accident_ID = Convert.ToInt32(Session["Accident_IDAdmin"]);
                            GetData(Accident_ID);
                        }
                    }
                    else
                    {
                        Response.Redirect("/Logout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Logout.aspx");
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
                    txtUtility.Text = ds.Rows[0]["NameOfUtility"].ToString();
                    txtSubdivision.Text = ds.Rows[0]["NameOfSubDivision"].ToString();
                    txtZone.Text = ds.Rows[0]["NameofZone"].ToString();
                    txtCircle.Text = ds.Rows[0]["NameOfCircle"].ToString();
                    txtDivision.Text = ds.Rows[0]["NameOfDivision"].ToString();
                    txtAccidentDate.Text = ds.Rows[0]["DateOfAccident"].ToString();
                    //txtAccidentTime.Text = ds.Rows[0]["TimeOfAccident"].ToString();
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
                    txtaction.Text= ds.Rows[0]["ApplicationStatus"].ToString();
                   
                    string Remarks = ds.Rows[0]["Remarks"].ToString();
                    if (!string.IsNullOrEmpty(Remarks))
                    {
                        txtRemarks.Text = Remarks;
                        txtRemarks.ReadOnly = true;
                    }                                          
                }
            }
            catch (Exception ex)
            {

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

                    string fileNames = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
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
    }
}