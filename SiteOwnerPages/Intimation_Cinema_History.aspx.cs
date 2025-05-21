using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class Intimation_Cinema_History : System.Web.UI.Page
    {
        //Page created by navneet 19-May-2025
        CEI CEI = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Site Owner / WorkIntimation History / WorkIntimation Details";
                    }
                    if (Session["SiteOwnerId"] != null)
                    {
                        GetDetails();                   
               

                    }
                    else
                    {
                        Response.Redirect("/SiteOwnerLogout.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }

        }
        protected void GetDetails()
        {
            try
            {
                REID = Session["IntimationId"].ToString();
                Session["IntimationId"] = "";
                    DataSet ds = new DataSet();
                    ds = CEI.GetCinemaIntimationHistoryById(REID);
                    

                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    //string dp_Id1 = ds.Tables[0].Rows[0]["PremisesType"].ToString();

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
                    //string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    //txtOtherPremises.Text = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                    string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                    //txtApplicant.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString().Trim();
                    string ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString().Trim();
                    string dp_Id8 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                    string dp_Id9 = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                   
                    TxtInspectionType.Text = ds.Tables[0].Rows[0]["InspectionType"].ToString();
                   
                 
                        Installation.Visible = true;
                        installationType1.Visible = true;
                        txtinstallationType1.Text = dp_Id8;
                        txtinstallationNo1.Text = dp_Id9;
                    
                   

                
            }
            catch (Exception ex) { }
        }
      




        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Intimation_Cinema_HistoryGridView.aspx");
        }
    }
}