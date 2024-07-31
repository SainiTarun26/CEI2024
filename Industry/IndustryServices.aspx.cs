using CEIHaryana.Model.Industry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Media.TextFormatting;

namespace CEIHaryana.Industry
{
    public partial class IndustryServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["SiteOwnerId"] = null;
                Session["logintype"] = null;


                var inputObject = new Cei_IndustryServices_Redirection_IncomingJson_Model
                {
                    uname = Request.Params["uname"],
                    investorname = Request.Params["investorname"],
                    address = Request.Params["address"],
                    useremail = Request.Params["useremail"],
                    country = Request.Params["country"],
                    state = Request.Params["state"],
                    city = Request.Params["city"],
                    niccode = Request.Params["niccode"],
                    pannumber = Request.Params["pannumber"],
                    //pannumber = "abcde1234t",
                    //pannumber = "ABCDE1234G",
                    gstnumber = Request.Params["gstnumber"],
                    aadhar_number = Request.Params["aadhar_number"],
                    proposedbuilt_up_area = Request.Params["proposedbuilt_up_area"],
                    mobile = Request.Params["mobile"],
                    totalproposedprojectarea = Request.Params["totalproposedprojectarea"],
                    totalpurposedemployment = Request.Params["totalpurposedemployment"],
                    total_project_cost = Request.Params["total_project_cost"],
                    project_site_district = Request.Params["project_site_district"],
                    landzoneuse_type = Request.Params["landzoneuse_type"],
                    businessentity = Request.Params["businessentity"],
                    projecttype = Request.Params["projecttype"],
                    projectid = Request.Params["projectid"],
                    serviceid = Request.Params["serviceid"],
                    projectserviceid = Request.Params["projectserviceid"],
                    cafpin = Request.Params["cafpin"],
                    projectlevel = Request.Params["projectlevel"],
                    requestType = Request.Params["requestType"],
                    cafType = Request.Params["cafType"]
                };
                try
                {
                    if (!string.IsNullOrEmpty(inputObject.pannumber) && !string.IsNullOrWhiteSpace(inputObject.pannumber) &&
                        !string.IsNullOrEmpty(inputObject.serviceid) && !string.IsNullOrWhiteSpace(inputObject.serviceid))
                    {

                        // Store the data in the database
                        OnLoadSaveJson_Log_InDatabase(inputObject);

                        Session["SiteOwnerId_Temp"] = null;
                        Session["Serviceid_Temp"] = null;

                        Session["SiteOwnerId_Temp"] = inputObject.pannumber;
                        Session["Serviceid_Temp"] = inputObject.serviceid;
                        txtPAN.Text = inputObject.pannumber;
                        //txtPAN.Text = "abcde1234t";
                        //txtPAN.Text = "ABCDE1234G";
                    }
                    else
                    {
                       // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Pan Card Or Service Id Not Found.Please Login To Industry Portal Again.')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata1();", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    return;
                }
            }
        }

        private void OnLoadSaveJson_Log_InDatabase(Cei_IndustryServices_Redirection_IncomingJson_Model data)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_IndustryServices_Redirect_IncomingJson_OnLoad_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@uname", data.uname);
                command.Parameters.AddWithValue("@investorname", data.investorname);
                command.Parameters.AddWithValue("@address", data.address);
                command.Parameters.AddWithValue("@useremail", data.useremail);
                command.Parameters.AddWithValue("@country", data.country);
                command.Parameters.AddWithValue("@state", data.state);
                command.Parameters.AddWithValue("@city", data.city);
                command.Parameters.AddWithValue("@niccode", data.niccode);
                command.Parameters.AddWithValue("@pannumber", data.pannumber);
                command.Parameters.AddWithValue("@gstnumber", data.gstnumber);
                command.Parameters.AddWithValue("@aadhar_number", data.aadhar_number);
                command.Parameters.AddWithValue("@proposedbuilt_up_area", data.proposedbuilt_up_area);
                command.Parameters.AddWithValue("@mobile", data.mobile);
                command.Parameters.AddWithValue("@totalproposedprojectarea", data.totalproposedprojectarea);
                command.Parameters.AddWithValue("@totalpurposedemployment", data.totalpurposedemployment);
                command.Parameters.AddWithValue("@total_project_cost", data.total_project_cost);
                command.Parameters.AddWithValue("@project_site_district", data.project_site_district);
                command.Parameters.AddWithValue("@landzoneuse_type", data.landzoneuse_type);
                command.Parameters.AddWithValue("@businessentity", data.businessentity);
                command.Parameters.AddWithValue("@projecttype", data.projecttype);
                command.Parameters.AddWithValue("@projectid", data.projectid);
                command.Parameters.AddWithValue("@serviceid", data.serviceid);
                command.Parameters.AddWithValue("@projectserviceid", data.projectserviceid);

                command.Parameters.AddWithValue("@cafpin", data.cafpin);
                command.Parameters.AddWithValue("@projectlevel", data.projectlevel);

                command.Parameters.AddWithValue("@requestType", data.requestType);
                command.Parameters.AddWithValue("@cafType", data.cafType);

                connection.Open();
                command.ExecuteNonQuery();


            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            string testReportId = txtTestReportId.Text.Trim();
            string panNumber = txtPAN.Text.Trim();
            if (Session["Serviceid_Temp"] != null)
            {
                if (!string.IsNullOrEmpty(testReportId) && !string.IsNullOrEmpty(panNumber) && !string.IsNullOrEmpty(Session["Serviceid_Temp"].ToString()))
                {
                    VerifyTestReport(testReportId, panNumber, Session["Serviceid_Temp"].ToString());
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Your Session Expired.Please Login To Industry Portal Again.')", true);
            }

        }

        private void VerifyTestReport(string testReportId, string panNumber, string serviceid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_IndustryServices_Authenticate_TestReportId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TestReportId", testReportId);
                command.Parameters.AddWithValue("@PanNumber", panNumber);
                // command.Parameters.AddWithValue("@Serviceid", Convert.ToInt32(serviceid));
                command.Parameters.AddWithValue("@Serviceid", 3);
                SqlParameter outputParam = new SqlParameter("@OutputParam", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    string outputValue = (string)outputParam.Value;

                    if (!string.IsNullOrEmpty(outputValue))
                    {
                        string[] outputParts = outputValue.Split('|');
                        string resultCode = outputParts[0];
                        string returnedTestReportId = outputParts[1];
                        string returnedPanno = outputParts[2];
                        string returnedIntimationid = outputParts[3];

                        switch (resultCode)
                        {
                            case "0":
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('TestReportId Not Found')", true);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2();", true);
                                break;
                            case "1":
                                Session["SiteOwnerId_Industry"] = returnedPanno;
                                Session["logintype"] = "SiteOwner_Industry";
                                Session["ReturnedTestReportId_Industry"] = returnedTestReportId;
                                Session["id_Industry"] = returnedIntimationid;

                                Response.Cookies["SiteOwnerId_Industry"].Value = returnedPanno;
                                Response.Cookies["logintype"].Value = "SiteOwner_Industry";
                                Response.Cookies["ReturnedTestReportId_Industry"].Value = returnedTestReportId;
                                Session["InspectionLinkDisable"] = null;
                                Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["ReturnedTestReportId_Industry"].Expires = DateTime.Now.AddDays(15);
                                Response.Redirect("/SiteOwnerPages/GenerateInspection_Industry.aspx", false);
                                break;
                            case "2":
                                Session["SiteOwnerId_Industry"] = returnedPanno;
                                Session["logintype"] = "SiteOwner_Industry";
                                Session["ReturnedTestReportId_Industry"] = returnedTestReportId;
                                Session["id_Industry"] = returnedIntimationid;

                                Session["InspectionLinkDisable"] = 2;

                                Response.Cookies["SiteOwnerId_Industry"].Value = returnedPanno;
                                Response.Cookies["logintype"].Value = "SiteOwner_Industry";
                                Response.Cookies["ReturnedTestReportId_Industry"].Value = returnedTestReportId;

                                Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["ReturnedTestReportId_Industry"].Expires = DateTime.Now.AddDays(15);
                                Response.Redirect("/SiteOwnerPages/InspectionHistory_Industry.aspx", false);
                                break;

                            case "3":
                                //Session["SiteOwnerId_Industry"] = returnedPanno;
                                //Session["logintype"] = "SiteOwner_Industry";
                                //Session["ReturnedTestReportId_Industry"] = returnedTestReportId;
                                //Session["id_Industry"] = returnedIntimationid;

                                //Session["InspectionLinkDisable"] = 3;

                                //Response.Cookies["SiteOwnerId_Industry"].Value = returnedPanno;
                                //Response.Cookies["logintype"].Value = "SiteOwner_Industry";
                                //Response.Cookies["ReturnedTestReportId_Industry"].Value = returnedTestReportId;

                                //Response.Cookies["SiteOwnerId_Industry"].Expires = DateTime.Now.AddDays(15);
                                //Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(15);
                                //Response.Cookies["ReturnedTestReportId_Industry"].Expires = DateTime.Now.AddDays(15);
                                //Response.Redirect("/SiteOwnerPages/InspectionHistory_Industry.aspx", false);
                                //break;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Your TestReport Id Is Not Approved By Contractor.')", true);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}