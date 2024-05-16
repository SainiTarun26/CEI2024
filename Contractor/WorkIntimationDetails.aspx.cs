using CEI_PRoject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;

namespace CEIHaryana.Contractor
{
    public partial class WorkIntimationDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorID = string.Empty;
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ContractorID"] != null || Request.Cookies["ContractorID"] != null)
                    {
                      
                        hiddenfield.Visible = false;
                        hiddenfield1.Visible = false;
                      
                        OtherPremises.Visible = false;
                        if (Convert.ToString(Session["id"]) == null || Convert.ToString(Session["id"]) == "")
                        {

                        }
                        else
                        {
                            GetDetails();
                            GetassigneddatatoContractor();
                            //btnOpenWindow.Visible = true;
                           // Session["id"] = null; // added by gurmeet to resolve redirection problem 24 Aprail
                        }
                       


                        worktypevisiblity();
                      



                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }

        }
        protected void GetDetails()
        {
            try
            {
                REID = Session["id"].ToString();
                SqlCommand cmd = new SqlCommand("sp_WorkIntimationData");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", REID);
                cmd.Connection = con;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    ddlworktype.SelectedIndex = ddlworktype.Items.IndexOf(ddlworktype.Items.FindByText(dp_Id));
                    txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                    txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();
                    txtPremises.Text = dp_Id1;
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    //txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pincode"].ToString()))
                    {
                        pin.Visible = false;
                    }
                    else
                    {
                        txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                        pin.Visible = true;
                    }
                    string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                    ddVoltageLevel.Text = dp_Id3;
                    txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    //txtPAN.Text = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                    string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("yyyy-MM-dd");
                    //txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString().Trim();
                    string ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString().Trim();
                    txtApplicant.Text = ApplicantType;
                    if (ApplicantType == "Private/Personal Installation")
                    {
                        string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                        PanNo.Visible = true;
                        txtPAN.Text = PanTanNumber;
                    }
                    else if (ApplicantType == "Other Department/Organization")
                    {
                        string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                        TanNo.Visible = true;
                        txtTanNo.Text = PanTanNumber;
                    }
                    string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("yyyy-MM-dd");
                    string dp_Id6 = ds.Tables[0].Rows[0]["CompletionDateasPerOrder"].ToString();
                    string dp_Id7 = ds.Tables[0].Rows[0]["AnyWorkIssued"].ToString();
                    Session["File"] = ds.Tables[0].Rows[0]["CopyOfWorkOrder"].ToString();
                    ddlAnyWork.SelectedIndex = ddlAnyWork.Items.IndexOf(ddlAnyWork.Items.FindByText(dp_Id7));
                    string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                    string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                    string dp_Id10 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                    string dp_Id11 = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                    string dp_Id12 = ds.Tables[0].Rows[0]["TypeOfInstallation3"].ToString();
                    string dp_Id13 = ds.Tables[0].Rows[0]["NumberOfInstallation3"].ToString();
                    string dp_Id14 = ds.Tables[0].Rows[0]["TypeOfInstallation4"].ToString();
                    string dp_Id15 = ds.Tables[0].Rows[0]["NumberOfInstallation4"].ToString();
                    string dp_Id16 = ds.Tables[0].Rows[0]["TypeOfInstallation5"].ToString();
                    string dp_Id17 = ds.Tables[0].Rows[0]["NumberOfInstallation5"].ToString();
                    string dp_Id18 = ds.Tables[0].Rows[0]["TypeOfInstallation6"].ToString();
                    string dp_Id19 = ds.Tables[0].Rows[0]["NumberOfInstallation6"].ToString();
                    string dp_Id20 = ds.Tables[0].Rows[0]["TypeOfInstallation7"].ToString();
                    string dp_Id21 = ds.Tables[0].Rows[0]["NumberOfInstallation7"].ToString();
                    string dp_Id22 = ds.Tables[0].Rows[0]["TypeOfInstallation8"].ToString();
                    string dp_Id23 = ds.Tables[0].Rows[0]["NumberOfInstallation8"].ToString();

                    if (dp_Id8 != "")
                    {
                        Installation.Visible = true;
                        installationType1.Visible = true;
                        txtinstallationType1.Text = dp_Id8;
                        txtinstallationNo1.Text = dp_Id9;
                    }
                    else
                    {
                        //Installation.Visible = false;
                        installationType1.Visible = false;
                    }
                    if (dp_Id10 != "")
                    {
                        Installation.Visible = true;
                        installationType2.Visible = true;
                        txtinstallationType2.Text = dp_Id10;
                        txtinstallationNo2.Text = dp_Id11;
                    }
                    else
                    {

                        // Installation.Visible = false;
                        installationType2.Visible = false;
                    }
                    if (dp_Id12 != "")
                    {
                        Installation.Visible = true;
                        installationType3.Visible = true;
                        txtinstallationType3.Text = dp_Id12;
                        txtinstallationNo3.Text = dp_Id13;
                    }
                    else
                    {

                        //  Installation.Visible = false;
                        installationType3.Visible = false;
                    }
                    if (dp_Id14 != "")
                    {
                        Installation.Visible = true;
                        installationType4.Visible = true;
                        txtinstallationType4.Text = dp_Id14;
                        txtinstallationNo4.Text = dp_Id15;
                    }
                    if (dp_Id16 != "")
                    {
                        Installation.Visible = true;
                        installationType5.Visible = true;
                        txtinstallationType5.Text = dp_Id16;
                        txtinstallationNo5.Text = dp_Id17;
                    }
                    if (dp_Id18 != "")
                    {
                        Installation.Visible = true;
                        installationType6.Visible = true;
                        txtinstallationType6.Text = dp_Id18;
                        txtinstallationNo6.Text = dp_Id19;
                    }
                    if (dp_Id20 != "")
                    {
                        Installation.Visible = true;
                        installationType7.Visible = true;
                        txtinstallationType7.Text = dp_Id20;
                        txtinstallationNo7.Text = dp_Id21;
                    }
                    if (dp_Id22 != "")
                    {
                        Installation.Visible = true;
                        installationType8.Visible = true;
                        txtinstallationType8.Text = dp_Id22;
                        txtinstallationNo8.Text = dp_Id23;
                    }

                    if (dp_Id7.Trim() == "Yes")
                    {

                        hiddenfield.Visible = true;
                        hiddenfield1.Visible = true;
                        txtCompletionDateAPWO.Text = DateTime.Parse(dp_Id6).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        hiddenfield.Visible = false;
                        hiddenfield1.Visible = false;
                    }

                    if (dp_Id3 == "upto 650 V")
                    {
                        installationType2.Visible = false;
                    }
                    else
                    {
                        installationType2.Visible = true;
                    }
                   
                }
            }
            catch { }
        }
        protected void lnkFile_Click(object sender, EventArgs e)
        {

            string fileName = Session["File"].ToString();
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


        protected void GetassigneddatatoContractor()
        {
            try
            {
                string ID = string.Empty;
                ID = Session["id"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetStaffAssignedToContractor(ID);
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record of attached Supervisor/Wireman Found \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch
            {
            }
        }
        protected void worktypevisiblity()
        {

            if (ddlworktype.SelectedValue == "1")
            {
                individual.Visible = true;
                agency.Visible = false;

            }
            else if (ddlworktype.SelectedValue == "2")
            {
                individual.Visible = false;
                agency.Visible = true;

            }
            else
            {
                individual.Visible = true;
                agency.Visible = false;
            }

        }

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktypevisiblity();
        }
       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
            }
        }

        protected void ddlAnyWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnyWork.SelectedValue == "Yes")
            {

                hiddenfield.Visible = true;
                hiddenfield1.Visible = true;
            }
            else
            {
                hiddenfield.Visible = false;
                hiddenfield1.Visible = false;
            }
        }

      

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id"] = "";
            Session["id"] = null;
            Response.Redirect("PreviousProjects.aspx");
        }
    }
}
