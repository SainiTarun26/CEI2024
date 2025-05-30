﻿using CEI_PRoject;
using CEIHaryana.Officers;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Industry_Master
{
    public partial class InspectionRenewalCart_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        //string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1, dblSubTotalCapacity = 0, dblGrandTotalCapacity = 0, highestOfficerDesignation = 0;
        double dblSubHighestVoltage = 0, dblHighestVoltage = 0;
        string InstallationTypeId = string.Empty, strPreviousRowID = string.Empty;
        private static int TotalAmount = 0, CheckCase = 0;
        private static string PrevInspectionId = string.Empty, PrevInstallationType = string.Empty, PrevTestReportId = string.Empty,
                              PrevIntimationId = string.Empty, PrevVoltageLevel = string.Empty,
                              PrevApplicantType = string.Empty, AssignToOfficer = string.Empty;

      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                    {
                        hfOwner.Value = Convert.ToString(Session["SiteOwnerId_Industry"]);
                        if (CheckInspectionStatus())
                        {
                            Response.Redirect("InspectionHistory_Industry.aspx", false);
                            return;
                        }

                        Page.Session["FinalAmount_Industry"] = "0";
                        BindAdress();
                    }
                    else
                    {
                        Session["SiteOwnerId_Industry"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["SiteOwnerId_Industry"] = "";
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }
        private void BindAdress()
        {
            try
            {
                if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                {
                    if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                    {
                        string CreatedBy = Session["SiteOwnerId_Industry"].ToString();
                        DataSet FilterAddress = new DataSet();
                        FilterAddress = CEI.GetAddressToFilterCart_Industries(CreatedBy);
                        ddlAddress.DataSource = FilterAddress;
                        ddlAddress.DataTextField = "AddressText";
                        ddlAddress.DataValueField = "AddressText";
                        ddlAddress.DataBind();
                        ddlAddress.Items.Insert(0, new ListItem("Select", "0"));
                        FilterAddress.Clear();
                    }
                    else
                    {
                        Session["SiteOwnerId_Industry"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
                else
                {
                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["SiteOwnerId_Industry"] = "";
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }
        protected void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtAddressFilter.Visible = true;
                txtAddressFilter.Text = ddlAddress.SelectedItem.ToString();

                DivGrid.Visible = true;
                BindGrid();
                BtnSubmit.Visible = true;
                BtnDelete.Visible = true;
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }
        private void BindGrid()
        {
            if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
            {
                if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                {
                    string CreatedBy = Session["SiteOwnerId_Industry"].ToString();
                    string[] str = txtAddressFilter.Text.Split('|');
                    string address = str[0].Trim();
                    string CartID = str[1].Trim();
                    Session["SelectedCartID_Industry"] = CartID;
                    DataSet ds = new DataSet();
                    ds = CEI.ShowDataToCart_Industries(address, CartID, CreatedBy);
                    if (ds.Tables.Count > 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                }
            }
            else
            {
                Session["SiteOwnerId_Industry"] = "";
                Response.Redirect("/Industry_Sessions_Clear.aspx", false);
            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label LblCount = e.Row.FindControl("LblCount") as Label;
                    Label LblInstallationName = e.Row.FindControl("LblInstallationName") as Label;
                    Label LblIntimationId = e.Row.FindControl("LblIntimationId") as Label;
                    Label LblInspectionId = e.Row.FindControl("LblInspectionId") as Label;
                    string InspectionId = LblInspectionId.Text;

                    PrevInspectionId = InspectionId;
                    Label Lbldesignation = e.Row.FindControl("Lbldesignation") as Label;
                    //string Assignedoff = Lbldesignation.Text;
                    //if (Assignedoff != null && Assignedoff != "")
                    //{
                    //    getassignedofficer(Assignedoff);
                    //}

                    if (LblCount.Text != null && LblInstallationName.Text != null && LblIntimationId != null)
                    {
                        if (LblInstallationName.Text == "Line")
                        {
                            InstallationTypeId = "1";
                        }
                        else if (LblInstallationName.Text == "Substation Transformer")
                        {
                            InstallationTypeId = "2";
                        }
                        else if (LblInstallationName.Text == "Generating Set")
                        {
                            InstallationTypeId = "3";
                        }
                        string InspectionType = "Periodic";
                        DataTable ds = new DataTable();
                        ds = CEI.Payment_Industries(LblIntimationId.Text, LblCount.Text, InstallationTypeId, InspectionType);
                        if (ds.Rows.Count > 0 && ds != null)
                        {
                            int Amount = Convert.ToInt32(ds.Rows[0]["Amount"].ToString());
                            TotalAmount = Convert.ToInt32(Session["FinalAmount_Industry"]);
                            TotalAmount = TotalAmount + Amount;
                            Session["FinalAmount_Industry"] = TotalAmount;
                        }
                    }

                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "InstallationName").ToString();

                    // Check and parse Capacity
                    object capacityObj = DataBinder.Eval(e.Row.DataItem, "CapacityNumeric");
                    int dblCapacity = 0;
                    if (capacityObj != null && int.TryParse(capacityObj.ToString(), out dblCapacity))
                    {
                        dblSubTotalCapacity += dblCapacity;
                        dblGrandTotalCapacity += dblCapacity;
                    }

                    // Check and parse Voltage
                    object voltageObj = DataBinder.Eval(e.Row.DataItem, "Voltage");
                    double dblVoltage = 0;
                    if (voltageObj != null && double.TryParse(voltageObj.ToString(), out dblVoltage))
                    {
                        // Update the highest voltage for the subtotal 
                        dblSubHighestVoltage = Math.Max(dblSubHighestVoltage, dblVoltage);
                        dblHighestVoltage = Math.Max(dblHighestVoltage, dblVoltage);
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalCapacity = (Label)e.Row.FindControl("lblTotalCapacity");
                    Label lblMaxVoltage = (Label)e.Row.FindControl("lblMaxVoltage");

                    lblTotalCapacity.Text = "Total Capacity: " + dblGrandTotalCapacity.ToString("N0") + "KVA";
                    lblMaxVoltage.Text = "Max Voltage: " + dblHighestVoltage.ToString("N0");

                    Session["TotalCapacity_Industry"] = dblGrandTotalCapacity;
                    Session["HighestVoltage_Industry"] = dblHighestVoltage;
                }
            }
            catch (Exception ex) { }
        }
        //private void getassignedofficer(string Assignedoff)
        //{
        //    try
        //    {
        //        if (Assignedoff.StartsWith("JE"))
        //        {
        //            CheckCase = 1;
        //            if (CheckCase > highestOfficerDesignation)
        //            {
        //                highestOfficerDesignation = CheckCase;
        //                AssignToOfficer = Assignedoff;
        //            }
        //        }
        //        else if (Assignedoff.StartsWith("AE"))
        //        {
        //            CheckCase = 2;
        //            if (CheckCase > highestOfficerDesignation)
        //            {
        //                highestOfficerDesignation = CheckCase;
        //                AssignToOfficer = Assignedoff;
        //            }
        //        }
        //        else if (Assignedoff.StartsWith("XEN"))
        //        {
        //            CheckCase = 3;
        //            if (CheckCase > highestOfficerDesignation)
        //            {
        //                highestOfficerDesignation = CheckCase;
        //                AssignToOfficer = Assignedoff;
        //            }
        //        }
        //        else if (Assignedoff.StartsWith("CEI"))
        //        {
        //            CheckCase = 4;
        //            if (CheckCase > highestOfficerDesignation)
        //            {
        //                highestOfficerDesignation = CheckCase;
        //                AssignToOfficer = Assignedoff;
        //            }
        //        }

        //    }
        //    catch { }
        //}
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                bool IsSubTotalRowNeedToAdd = false;
                if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "InstallationName") != null))
                    if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "InstallationName").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "InstallationName") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    intSubTotalIndex = 0;
                }
                if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "InstallationName") != null))
                {
                    GridView grdViewOrders = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Installation Name: " + DataBinder.Eval(e.Row.DataItem, "InstallationName").ToString();
                    cell.Font.Bold = true;
                    cell.ColumnSpan = 6;
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                if (IsSubTotalRowNeedToAdd)
                {
                    AddSubTotalRow((GridView)sender, e.Row.RowIndex + intSubTotalIndex);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "InstallationName") != null)
                    {
                        GridView grdViewOrders = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Installation Name: " + DataBinder.Eval(e.Row.DataItem, "InstallationName").ToString();
                        cell.Font.Bold = true;
                        cell.ColumnSpan = 6;
                        row.Cells.Add(cell);
                        grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    //dblSubTotalCapacity = 0;
                    //dblSubHighestVoltage = 0;
                }
            }
            catch (Exception ex) { }
        }
        private void AddSubTotalRow(GridView gridView, int rowIndex)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

            // Create a cell for the subtotal label
            TableCell cell = new TableCell();
            cell.Text = "Sub Total";
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.ColumnSpan = 2;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Create a cell for the subtotal capacity
            cell = new TableCell();
            cell.Text = string.Format("{0:0}", dblSubTotalCapacity);
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Create a cell for the highest voltage in the group
            cell = new TableCell();
            cell.Text = string.Format("{0:0}", dblSubHighestVoltage);
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.CssClass = "SubTotalRowStyle";
            row.Cells.Add(cell);

            // Add the subtotal row to the grid
            gridView.Controls[0].Controls.AddAt(rowIndex, row);

            dblSubTotalCapacity = 0;
            dblSubHighestVoltage = 0;
        }
        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "DeleteRow")
        //        {
        //            int inspectionId = Convert.ToInt32(e.CommandArgument);
        //            DataSet ds = new DataSet();
        //            ds = CEI.ToRemoveDataCart_Industries(inspectionId);

        //            BindGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
        //    }
        //}
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SiteOwnerId_Industry"] != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                {
                    if (hfOwner.Value == Convert.ToString(Session["SiteOwnerId_Industry"]))
                    {
                        string id = Session["SiteOwnerId_Industry"].ToString();
                        string GrandTotalCapacity = Session["TotalCapacity_Industry"].ToString();
                        string HighestVoltage = Session["HighestVoltage_Industry"].ToString();

                        int totalAmount = Convert.ToInt32(Session["FinalAmount_Industry"]);
                        string AssignTo = AssignToOfficer;
                        string Division = string.Empty;
                        string District = string.Empty;
                        string StaffAssignedCount = string.Empty;
                        string StaffAssigned = string.Empty;
                        string Assigned = string.Empty;
                        int ServiceType = 0;

                        string[] str = txtAddressFilter.Text.Split('|');
                        string address = str[0].Trim();
                        string CartID = str[1].Trim();

                        DataSet ds = new DataSet();
                        ds = CEI.ToGetDatafromCart_Industries(address, CartID);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Division = row["Division"].ToString();
                                District = row["District"].ToString();
                            }
                        }
                        ds = CEI.GetStaffAssigned_Industries(CartID);

                        if (ds.Tables.Count > 0 && ds != null)
                        {
                            StaffAssignedCount = ds.Tables[0].Rows[0]["AssignedCount"].ToString();
                        }

                        if (StaffAssignedCount == "1")
                        {
                            StaffAssigned = "JE";
                            ServiceType = 2;
                        }
                        else if (StaffAssignedCount == "2")
                        {
                            StaffAssigned = "AE";
                            ServiceType = 3;
                        }

                        else if (StaffAssignedCount == "3")
                        {
                            StaffAssigned = "XEN";
                            ServiceType = 4;
                        }
                        else if (StaffAssignedCount == "4")
                        {
                            StaffAssigned = "CEI";
                            ServiceType = 5;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('your details or component are wrong')", true);
                            return;
                        }


                        DataSet dsp = new DataSet();
                        dsp = CEI.ToGetStaffIdforPeriodic_Industries(Division, StaffAssigned, District);
                        if (dsp.Tables.Count > 0 && dsp.Tables[0].Rows.Count > 0)
                        {
                            Assigned = dsp.Tables[0].Rows[0]["StaffUserId"].ToString();
                        }


                        //int affectedRows = GetAffectedRowsCount(CartID);

                        //if (affectedRows == 1)
                        //{
                        //    string InspectionId = PrevInspectionId;
                        //    DataSet SInsp = new DataSet();
                        //    SInsp = CEI.GetDataForSingleInspection_Industries(InspectionId);

                        //    string InstallationType = SInsp.Tables[0].Rows[0]["InstallationT"].ToString();
                        //    string TestRportId = SInsp.Tables[0].Rows[0]["TestRportId"].ToString();
                        //    string IntimationId = SInsp.Tables[0].Rows[0]["IntimationId"].ToString();
                        //    string VoltageLevel = SInsp.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        //    string ApplicantType = SInsp.Tables[0].Rows[0]["ApplicantType"].ToString();
                        //    PrevInstallationType = InstallationType;
                        //    PrevTestReportId = TestRportId;
                        //    PrevIntimationId = IntimationId;
                        //    PrevVoltageLevel = VoltageLevel;
                        //    PrevApplicantType = ApplicantType;
                        //}
                        //else
                        //{
                        //    string InspectionId = PrevInspectionId;
                        //    DataSet SInsp = new DataSet();
                        //    SInsp = CEI.GetDataForSingleInspection_Industries(InspectionId);
                        //    string IntimationId = SInsp.Tables[0].Rows[0]["IntimationId"].ToString();
                        //    string ApplicantType = SInsp.Tables[0].Rows[0]["ApplicantType"].ToString();
                        //    PrevInstallationType = "Multiple";
                        //    PrevTestReportId = "Multiple";
                        //    PrevIntimationId = IntimationId;
                        //    PrevVoltageLevel = HighestVoltage;
                        //    PrevApplicantType = ApplicantType;
                        //}

                        CEI.InsertInspectinData_Industries(CartID, GrandTotalCapacity, HighestVoltage,  Assigned, totalAmount, id, ServiceType);

                        Session["CartID_Industry"] = CartID;
                        Session["IDCart_Industry"] = string.Empty;
                        Session["TotalCapacity_Industry"] = string.Empty;
                        Session["HighestVoltage_Industry"] = string.Empty;
                        Session["FinalAmount_Industry"] = string.Empty;

                        Response.Redirect("/Industry_Master/ProcessInspectionRenewalCart_Industries.aspx", false);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Cart Submitted Successfully !!!'); window.location='/Industry_Master/ProcessInspectionRenewalCart_Industries.aspx';", true);
                    }
                    else
                    {
                        Session["SiteOwnerId_Industry"] = "";
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    }
                }
                else
                {
                    Session["SiteOwnerId_Industry"] = "";
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["SiteOwnerId_Industry"] = "";
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }

        //private int GetAffectedRowsCount(string cartId)
        //{
        //    int count = 0;
        //    count = CEI.GetAffectedRowsCountByCartId_Industries(cartId);

        //    return count;
        //}

        private bool CheckInspectionStatus()
        {
            string panNumber = null;
            string Districtlocalpr = null;
            //added on 24 feb 2025 to filter district records against a panno

            if (Session["SiteOwnerId_Industry"] != null)
            {
                panNumber = Session["SiteOwnerId_Industry"].ToString();
            }
            if (Session["district_Temp"] != null)
            {
                Districtlocalpr = Session["district_Temp"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckAlreadyApplied_PeriodicInspection_Industries", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PANNumber", panNumber);
                    cmd.Parameters.AddWithValue("@District", Districtlocalpr);
                    //added on 24 feb 2025 to filter district records against a panno

                    conn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result == 1;
                }
            }
        }
        
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string[] str = txtAddressFilter.Text.Split('|');
            if (str.Length > 1)
            {
                string SelectedCartID_Industry = str[1].Trim();

                if (!string.IsNullOrEmpty(SelectedCartID_Industry))
                {
                    try
                    {
                        CEI.ToDeleteCart(SelectedCartID_Industry);
                        Response.Redirect("/Industry_Master/PeriodicRenewal_Industry.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('An error occurred while deleting the cart.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No Cart ID selected.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('An error occurred while deleting the cart.');</script>");
            }
        }

    }
}