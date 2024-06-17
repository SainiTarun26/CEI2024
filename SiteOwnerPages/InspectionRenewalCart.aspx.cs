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
        private decimal totalCapacity = 0;
        private decimal maxVoltage = 0;
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
                DataSet FilterAddress = new DataSet();
                FilterAddress = CEI.GetAddressToFilterCart();
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
            catch { }
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label capacity = (Label)e.Row.FindControl("LblCapacity");

                    if (capacity != null)
                    {
                        int capacityValue;
                        if (int.TryParse(capacity.Text, out capacityValue))
                        {
                            totalCapacity += capacityValue;
                        }
                    }
                    decimal voltage = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Voltage"));
                    if (voltage > maxVoltage)
                    {
                        maxVoltage = voltage;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalCapacity = (Label)e.Row.FindControl("lblTotalCapacity");
                    Label lblMaxVoltage = (Label)e.Row.FindControl("lblMaxVoltage");

                    //lblTotalCapacity.Text = "Total Capacity: " + totalCapacity.ToString("N2") + "KVA";
                    lblTotalCapacity.Text = "Total Capacity: " + totalCapacity.ToString("N0") + "KVA";


                    lblMaxVoltage.Text = "Max Voltage: " + maxVoltage.ToString("N0");
                }
            }
            catch (Exception ex) { }
        }
    }
}