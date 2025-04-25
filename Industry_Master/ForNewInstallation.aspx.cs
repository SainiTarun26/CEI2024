using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class ForNewInstallation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Added On 3 apl 2025  List of session keys to remove for this page
                    List<string> sessionKeysToRemove = new List<string>
                    {
                        "id","Duplicacy1","TotalAmount1"
                    };
                    ClearSessions(sessionKeysToRemove);

                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != "" && Convert.ToString(Session["district_Temp"]) != null && Convert.ToString(Session["district_Temp"]) != "")
                    {
                        //Session["SiteOwnerId_Sld_Indus"] = "ABCDG1234G";
                        //Session["district_Temp"] = "Hisar";
                        string District = Session["district_Temp"].ToString();
                        string PanNumber = Session["SiteOwnerId_Sld_Indus"].ToString();
                        hfOwner.Value = Convert.ToString(Session["SiteOwnerId_Sld_Indus"]);
                        //bool panExists = false;

                        //DataSet ds1 = CEI.checkInspection(PanNumber);
                        //if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    panExists = true;
                        //    string statusType = ds1.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        //    string ReasonType = ds1.Tables[0].Rows[0]["ReasonType"].ToString();
                        //    //if (statusType == "Return")
                        //    //{
                        //    //    getWorkIntimationData();
                        //    //}
                        //    if(statusType == "Approved" || statusType == "Rejected")
                        //    {
                        //        getWorkIntimationData();
                        //    }
                        //    else
                        //    {
                        //        Response.Redirect("/Industry_Master/NewInstallationStatus.aspx", false);
                        //    }



                        //}
                        //else
                        //{
                        //    getWorkIntimationData();
                        //}

                        // getWorkIntimationData();

                        //Commented on 21 feb 2025 to apply new check 

                        if (Session["SiteOwnerId_Sld_Indus"] != null || Session["district_Temp"] != null)
                        {
                            if (CheckInspectionStatus())
                            {
                                Response.Redirect("NewInstallationStatus.aspx", false);
                                return;
                            }
                            getWorkIntimationData();
                        }

                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
                        //Commented On 3 Apl 2025 By Aslam
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                        return;
                        //Response.Redirect("SLD_Status.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                // Response.Redirect("/login.aspx",false);
                //Commented On 3 Apl 2025 By Aslam
                Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                return;
            }

        }
        private void getWorkIntimationData(string searchText = null)
        {
            //Added on 3 apl 2025  Method to Check If Any of Neccessary Session is Empty then redirect to Corresponding page
            if (CheckAndRedirect("SiteOwnerId_Sld_Indus", "Industry_Sessions_Clear.aspx"))
            {
                return;
            }
            string Id = Session["SiteOwnerId_Sld_Indus"].ToString();
            string District = Session["district_Temp"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.TestReportData_Industry(Id, District, searchText);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Note.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            ds.Dispose();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["id"] = lblID.Text;
                    Session["Duplicacy1"] = "0";
                    Session["TotalAmount1"] = "0";
                    Response.Redirect("/Industry_Master/GenerateNewInspection.aspx", false);
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                //    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                //}

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 6;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }

                }
            }
            catch { }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        private bool CheckInspectionStatus()
        {
            string panNumberlocal = null;
            string Districtlocal = null;

            if (Session["SiteOwnerId_Sld_Indus"] != null)
            {
                panNumberlocal = Session["SiteOwnerId_Sld_Indus"].ToString();
            }
            if (Session["district_Temp"] != null)
            {
                Districtlocal = Session["district_Temp"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckInspection", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PANNumber", panNumberlocal);
                    cmd.Parameters.AddWithValue("@District", Districtlocal);

                    conn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result == 1;
                }
            }
        }


        //Added on 3 apl 2025
        // Method to clear List Of session variables On Page Load Inside IsNotPost
        private void ClearSessions(List<string> sessionKeysToRemove)
        {
            foreach (string sessionKey in sessionKeysToRemove)
            {
                if (Session[sessionKey] != null && Convert.ToString(Session[sessionKey]) != string.Empty)
                {
                    Session.Remove(sessionKey);
                }
            }
        }

        //Added on 3 apl 2025
        // Method to Check If Any of Neccessary Session is Empty then redirect to Corresponding page
        private string CheckIndustrySessionsAndRedirect(List<string> sessionKeysToCheck, string redirectPage)
        {
            // List of mandatory session keys to check first
            List<string> mandatorySessionKeys = new List<string>
            {
                "SiteOwnerId_Sld_Indus","district_Temp","Serviceid_New_Temp","projectid_New_Temp"
            };
            List<string> allSessionKeysToCheck = mandatorySessionKeys.Concat(sessionKeysToCheck).ToList();

            foreach (string sessionKey in allSessionKeysToCheck)
            {
                string sessionValue = Convert.ToString(Session[sessionKey]);

                if (Session[sessionKey] == null || string.IsNullOrEmpty(Convert.ToString(Session[sessionKey])))
                {
                    if (mandatorySessionKeys.Contains(sessionKey))
                    {
                        return "/Industry_Sessions_Clear.aspx";
                    }
                    else
                    {
                        return redirectPage;
                    }
                }

                if (sessionKey == "SiteOwnerId_Sld_Indus" && sessionValue != hfOwner.Value)
                {
                    return "/Industry_Sessions_Clear.aspx"; // Redirect to logout if session value doesn't match hidden field value
                }
            }
            return null;
        }

        //Added on 3 apl 2025
        private bool CheckAndRedirect(string sessionKeysCsv, string redirectPage)
        {
            List<string> sessionKeys = sessionKeysCsv.Split(',').Select(s => s.Trim()).ToList();
            string resultPage = CheckIndustrySessionsAndRedirect(sessionKeys, redirectPage);
            if (!string.IsNullOrEmpty(resultPage))
            {
                Response.Redirect(resultPage, false);
                return true;
            }
            return false;
        }
    }
}