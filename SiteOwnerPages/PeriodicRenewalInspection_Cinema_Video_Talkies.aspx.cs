using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class PeriodicRenewalInspection_Cinema_Video_Talkies : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int totalQuantity = 0;
        decimal totalAmountSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        String ownerID = Convert.ToString(Session["SiteOwnerId"]);
                        HFOwnerID.Value = ownerID;
                        BindAddress(ownerID);
                    }
                    else
                    {
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
            }
            catch
            {
                Response.Redirect("LogOut.aspx", false);
            }
        }

        private void BindAddress(string ownerID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetSiteAddress_ForCinemaTalkies(ownerID);
                ddlAddress.DataSource = ds;
                ddlAddress.DataTextField = "Address";
                ddlAddress.DataValueField = "Address";
                ddlAddress.DataBind();
                ddlAddress.Items.Insert(0, new ListItem("Select", "0"));
                ds.Clear();
            }
            catch (Exception)
            {
                Response.Redirect("LogOut.aspx", false);
            }
        }

        protected void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.Visible = true;
            GridViewBind();
            PaymentDetails.Visible = true;
        }

        private void GridViewBind()
        {
            string OwnerId = HFOwnerID.Value;
            string Address = ddlAddress.SelectedItem.Text;
            DataSet ds = new DataSet();
            ds = CEI.GetDetails_ForCinemaTalkies(Address, OwnerId);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
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

        protected void PaymentGridViewBind(string InspectionType, int CinemaCount)
        {
            try
            {

                DataTable ds = new DataTable();
                //ds = CEI.Payment_Lift(selectedType, LiftCount, EscaltorCount);
                ds = CEI.Payment_CinemaInspection(InspectionType, CinemaCount);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Check atleast one CheckBox. \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);                    
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
            }
        }


        protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                decimal totalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                // Update the footer totals
                totalQuantity += quantity;
                totalAmountSum += totalAmount;
            }
            // Check if the row is a footer row to display the totals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblFooterQuantity = (Label)e.Row.FindControl("lblFooterQuantity");
                Label lblFooterAmount = (Label)e.Row.FindControl("lblFooterAmount");

                lblFooterQuantity.Text = totalQuantity.ToString();
                lblFooterAmount.Text = totalAmountSum.ToString();
                Session["CinemaAmount"] = totalAmountSum.ToString();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int CinemaCount = 0;
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                    if (chk != null && chk.Checked)
                    {
                        CinemaCount++;
                    }
                }

                PaymentGridViewBind("Periodic", CinemaCount);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

