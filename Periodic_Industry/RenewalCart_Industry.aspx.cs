using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class RenewalCart_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1;
        int dblSubTotalCapacity = 0;
        double dblSubHighestVoltage = 0;
        int dblGrandTotalCapacity = 0;
        double dblHighestVoltage = 0;
        string InstallationTypeId = string.Empty;
        private static int TotalAmount = 0;
        private static int CheckCase = 0;
        int highestOfficerDesignation = 0;
        //private static string PrevInspectionId = string.Empty;
        //private static string PrevInstallationType = string.Empty;
        //private static string PrevTestReportId = string.Empty;
        //private static string PrevIntimationId = string.Empty;
        //private static string PrevVoltageLevel = string.Empty;
        //private static string PrevApplicantType = string.Empty;
        private static string PrevInspectionId = string.Empty, PrevInstallationType = string.Empty, PrevTestReportId = string.Empty,
                              PrevIntimationId = string.Empty, PrevVoltageLevel = string.Empty, PrevApplicantType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        //Session["SiteOwnerId"] = "JVCBN5647K";
                        BindAdress();
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

        }
        private void BindAdress()
        {
            try
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                DataSet FilterAddress = new DataSet();
                FilterAddress = CEI.GetAddressToFilterCartForIndustry(CreatedBy);
                ddlAddress.DataSource = FilterAddress;
                ddlAddress.DataTextField = "AddressText";
                ddlAddress.DataValueField = "AddressText";
                ddlAddress.DataBind();
                ddlAddress.Items.Insert(0, new ListItem("Select", "0"));
                FilterAddress.Clear();
            }
            catch (Exception ex)
            {
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
                    string Assignedoff = Lbldesignation.Text;
                    if (Assignedoff != null && Assignedoff != "")
                    {
                        getassignedofficer(Assignedoff);
                    }

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
                        ds = CEI.Payment(LblIntimationId.Text, LblCount.Text, InstallationTypeId, InspectionType);
                        if (ds.Rows.Count > 0 && ds != null)
                        {
                            int Amount = Convert.ToInt32(ds.Rows[0]["Amount"].ToString());
                            TotalAmount += Amount;
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

                    Session["TotalCapacity1"] = dblGrandTotalCapacity;
                    Session["HighestVoltage1"] = dblHighestVoltage;
                }
            }
            catch (Exception ex) { }
        }

        protected void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txtAddressFilter.Visible = true;
                txtAddressFilter.Text = ddlAddress.SelectedItem.ToString();

                DivGrid.Visible = true;
                BindGrid();
            }
            catch (Exception ex)
            {
            }
        }

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

        private static string AssignToOfficer = string.Empty;

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int inspectionId = Convert.ToInt32(e.CommandArgument);
                    DataSet ds = new DataSet();
                    ds = CEI.ToRemoveDataCart(inspectionId);

                    BindGrid();
                }
            }
            catch (Exception ex) { }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SiteOwnerId"] != null)
                {
                    string id = Session["SiteOwnerId"].ToString();
                    string GrandTotalCapacity = Session["TotalCapacity1"].ToString();
                    string HighestVoltage = Session["HighestVoltage1"].ToString();
                    //string address = txtAddressFilter.Text;

                    int totalAmount = TotalAmount;
                    string AssignTo = AssignToOfficer;
                    //string CartId = string.Empty;
                    string Division = string.Empty;
                    string District = string.Empty;
                    string StaffAssigned = string.Empty;

                    //string InspectionId = PrevInspectionId;
                    string[] str = txtAddressFilter.Text.Split('-');
                    string address = str[0].Trim();
                    string CartID = str[1].Trim();

                    DataSet ds = new DataSet();
                    ds = CEI.ToGetDatafromCart(address, CartID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //CartId = row["CartId"].ToString();
                            Division = row["Division"].ToString();
                            District = row["District"].ToString();
                        }
                    }
                    if (AssignTo != "Admin@123")
                    {
                        DataSet dsp = new DataSet();
                        //dsp = CEI.ToGetStaffIdforPeriodic(Division, AssignTo);  comment by gurmeet 15oct, becz change this method inspectionrenewalCart.aspx.cs fetching details from Tbl_ceiAreaCovered
                        dsp = CEI.ToGetStaffIdforPeriodic(Division, AssignTo, District);
                        if (dsp.Tables.Count > 0 && dsp.Tables[0].Rows.Count > 0)
                        {
                            StaffAssigned = dsp.Tables[0].Rows[0]["StaffUserId"].ToString();
                        }
                        else
                        {
                            StaffAssigned = "CEI";
                        }
                    }
                    else
                    {
                        StaffAssigned = "Admin@123";
                    }


                    int affectedRows = GetAffectedRowsCount(CartID);

                    if (affectedRows == 1)
                    {
                        string InspectionId = PrevInspectionId;
                        DataSet SInsp = new DataSet();
                        SInsp = CEI.GetDataForSingleInspection(InspectionId);

                        string InstallationType = SInsp.Tables[0].Rows[0]["InstallationT"].ToString();
                        string TestRportId = SInsp.Tables[0].Rows[0]["TestRportId"].ToString();
                        string IntimationId = SInsp.Tables[0].Rows[0]["IntimationId"].ToString();
                        string VoltageLevel = SInsp.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        string ApplicantType = SInsp.Tables[0].Rows[0]["ApplicantType"].ToString();
                        PrevInstallationType = InstallationType;
                        PrevTestReportId = TestRportId;
                        PrevIntimationId = IntimationId;
                        PrevVoltageLevel = VoltageLevel;
                        PrevApplicantType = ApplicantType;
                    }
                    else
                    {
                        PrevInstallationType = "Multiple";
                        PrevTestReportId = "Multiple";
                        PrevIntimationId = "MultipleIntimations";
                        PrevVoltageLevel = "Multiple";
                        PrevApplicantType = "Multiple";
                    }



                    CEI.InsertInspectinData(CartID, GrandTotalCapacity, HighestVoltage, PrevInstallationType, PrevTestReportId,
              PrevIntimationId, PrevVoltageLevel, PrevApplicantType, District, Division, StaffAssigned, "Offline", totalAmount, 1, id);

                    Session["CartID"] = CartID;
                    Session["TotalCapacity1"] = string.Empty;
                    Session["HighestVoltage1"] = string.Empty;

                    Response.Redirect("/Periodic_Industry/InProcessRenewal_Industry.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

       
        private void BindGrid()
        {
            string[] str = txtAddressFilter.Text.Split('-');
            string address = str[0].Trim();
            string CartID = str[1].Trim();
            DataSet ds = new DataSet();
            ds = CEI.ShowDataToCart(address, CartID);
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
        private void getassignedofficer(string Assignedoff)
        {
            try
            {
                if (Assignedoff.StartsWith("JE"))
                {
                    CheckCase = 1;
                    if (CheckCase > highestOfficerDesignation)
                    {
                        highestOfficerDesignation = CheckCase;
                        AssignToOfficer = Assignedoff;
                    }
                }
                else if (Assignedoff.StartsWith("AE"))
                {
                    CheckCase = 2;
                    if (CheckCase > highestOfficerDesignation)
                    {
                        highestOfficerDesignation = CheckCase;
                        AssignToOfficer = Assignedoff;
                    }
                }
                else if (Assignedoff.StartsWith("XEN"))
                {
                    CheckCase = 3;
                    if (CheckCase > highestOfficerDesignation)
                    {
                        highestOfficerDesignation = CheckCase;
                        AssignToOfficer = Assignedoff;
                    }
                }
                else if (Assignedoff.StartsWith("CEI"))
                {
                    CheckCase = 4;
                    if (CheckCase > highestOfficerDesignation)
                    {
                        highestOfficerDesignation = CheckCase;
                        AssignToOfficer = Assignedoff;
                    }
                }

                //if (AssignToOfficer.StartsWith("CEI"))
                //{
                //    AssignToOfficer = "Admin@123";
                //}
            }
            catch { }
        }
        private void AddSubTotalRow(GridView gridView, int rowIndex)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

            // Create a cell for the subtotal label
            TableCell cell = new TableCell();
            cell.Text = "Sub Total";
            cell.Font.Bold = true;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.ColumnSpan = 3;
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
        private int GetAffectedRowsCount(string cartId)
        {
            int count = 0;
            count = CEI.GetAffectedRowsCountByCartId(cartId);

            return count;
        }
    }
}