using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
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
                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty && Convert.ToString(Session["district_Temp"]) != null && Convert.ToString(Session["district_Temp"]) != string.Empty)
                    {
                        //Session["SiteOwnerId_Sld_Indus"] = "ABCDG1234G";
                        //Session["district_Temp"] = "Hisar";
                        string District = Session["district_Temp"].ToString();
                        string PanNumber = Session["SiteOwnerId_Sld_Indus"].ToString();
                        bool panExists = false;

                        DataSet ds1 = CEI.checkInspection(PanNumber);
                        if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                        {
                            panExists = true;
                            string statusType = ds1.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                            string ReasonType = ds1.Tables[0].Rows[0]["ReasonType"].ToString();
                            if (statusType == "Return")
                            {
                                getWorkIntimationData();
                            }
                            if(statusType == "Approved" || statusType == "Rejected")
                            {
                                getWorkIntimationData();
                            }
                            else
                            {
                                Response.Redirect("/Industry_Master/NewInstallationStatus.aspx", false);
                            }



                        }
                        else
                        {
                            getWorkIntimationData();
                        }

                        // getWorkIntimationData();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("/login.aspx",false);
            }

        }
        private void getWorkIntimationData(string searchText = null)
        {
            string Id = Session["SiteOwnerId_Sld_Indus"].ToString();
            string District = Session["district_Temp"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.TestReportData_Industry(Id, District, searchText);
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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
    }
}