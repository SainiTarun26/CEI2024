using CEI_PRoject;
using CEIHaryana.Officers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class InspectionRenewalCart : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1;
        int dblSubTotalCapacity = 0;
        double dblSubHighestVoltage = 0;
        int dblGrandTotalCapacity = 0;
        double dblHighestVoltage = 0;
        string InstallationTypeId = string.Empty;
        private int TotalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Request.Cookies["SiteOwnerId"] != null)
                    {
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
                FilterAddress = CEI.GetAddressToFilterCart(CreatedBy);
                ddlAddress.DataSource = FilterAddress;
                ddlAddress.DataTextField = "Address";
                ddlAddress.DataValueField = "Address";
                ddlAddress.DataBind();
                ddlAddress.Items.Insert(0, new ListItem("Select", "0"));
                FilterAddress.Clear();
            }
            catch (Exception ex)
            {
            }
        }
        protected void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtAddressFilter.Visible = true;
                txtAddressFilter.Text = ddlAddress.SelectedItem.Text;

                DivGrid.Visible = true;
                BindGrid();
            }
            catch (Exception ex)
            {
            }
        }
        private void BindGrid()
        {
            string address = txtAddressFilter.Text;
            DataSet ds = new DataSet();
            ds = CEI.ShowDataToCart(address);
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label LblCount = e.Row.FindControl("LblCount") as Label;
                    Label LblInstallationName = e.Row.FindControl("LblInstallationName") as Label;                    
                    Label LblIntimationId = e.Row.FindControl("LblIntimationId") as Label;
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

                    Session["TotalCapacity"] = dblGrandTotalCapacity;
                    Session["HighestVoltage"] = dblHighestVoltage;
                }
            }
            catch (Exception ex) { }
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
                    string GrandTotalCapacity = Session["TotalCapacity"].ToString();
                    string HighestVoltage = Session["HighestVoltage"].ToString();
                    string address = txtAddressFilter.Text;
                    DataSet ds = new DataSet();
                    ds = CEI.ToGetDatafromCart(address);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string CartId = row["CartId"].ToString();
                            string Division = row["Division"].ToString();
                            string District = row["District"].ToString();
                        }
                    }
                    //foreach (GridViewRow row in GridView1.Rows)
                    //    if (row != null)
                    //    {    
                    //        Label LblDivision = (Label)row.FindControl("LblDivision");
                    //        string Division = LblDivision.Text;
                    //        Label LblDistrict = (Label)row.FindControl("LblDistrict");
                    //        string District = LblDistrict.Text;
                    //    }


                    Response.Redirect("/SiteOwnerPages/ProcessInspectionRenewalCart.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}