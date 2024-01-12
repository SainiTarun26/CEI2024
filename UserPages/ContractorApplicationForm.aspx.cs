using CEI_PRoject;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class ContractorApplicationForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlLoadBindState();
                    AddNewRow();
                }
            }
            catch
            { }

        }

        protected void ddlPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlPartnerOrDirector.SelectedValue =="1")
            {
                ParteneDirector.Visible = true;
            }
            else
            {
                ParteneDirector.Visible = false;

            }
        }

        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlState.DataSource = dsState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
            }
            catch { }

        }

        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            // Add a new row when the "Add More" button is clicked
            AddNewRow();
        }

        private void AddNewRow()
        {
            // Create a new row
            TableRow newRow = new TableRow();

            // Create cells and controls similar to the template row
            TableCell cell1 = new TableCell();
            DropDownList ddlAuthorityType = new DropDownList();
            // Set properties for ddlAuthorityType
            cell1.Controls.Add(ddlAuthorityType);

            TableCell cell2 = new TableCell();
            TextBox txtFullName = new TextBox();
            // Set properties for txtFullName
            cell2.Controls.Add(txtFullName);

            TableCell cell3 = new TableCell();
            TextBox txtAddress = new TextBox();
            // Set properties for txtAddress
            cell3.Controls.Add(txtAddress);

            TableCell cell4 = new TableCell();
            DropDownList ddlState = new DropDownList();
            // Set properties for ddlState
            cell4.Controls.Add(ddlState);

            TableCell cell5 = new TableCell();
            DropDownList ddlDistrict = new DropDownList();
            // Set properties for ddlDistrict
            cell5.Controls.Add(ddlDistrict);

            TableCell cell6 = new TableCell();
            TextBox txtPincode = new TextBox();
            // Set properties for txtPincode
            cell6.Controls.Add(txtPincode);

            // Add cells to the new row
            newRow.Cells.Add(cell1);
            newRow.Cells.Add(cell2);
            newRow.Cells.Add(cell3);
            newRow.Cells.Add(cell4);
            newRow.Cells.Add(cell5);
            newRow.Cells.Add(cell6);

            // Add the new row to the placeholder control
            //placeholder.Rows.Add(newRow);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        //CEI.ContractorApplicationData(txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(), ddlRegisterdOffice.SelectedItem.ToString(),
                        //    DdlPartnerOrDirector.SelectedItem.ToString(), ddlAuthorityType.SelectedItem.ToString(), txtFullName.Text, txtAddress.Text,
                        //    ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPin.Text, txtCompanyPenalities.Text, ddlLibraryAvailable.SelectedItem.ToString(),
                        //    txtAgentName.Text, ddlFirmOrUnit.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(), txtIssuingAuthorityName.Text, txtDOB.Text,
                        //    txtLicenseExpiryDate.Text, ddlTypofEmployee1.SelectedItem.ToString(), txtLicenseNumber1.Text, txtIssueDate1.Text, txtValidityDate1.Text,
                        //    txtQualification1.Text, ddlTypofEmployee2.SelectedItem.ToString(), txtLicenseNumber2.Text, txtIssueDate2.Text, txtValidityDate2.Text,
                        //    txtQualification2.Text, "Admin");

                        con.Open();
                    }
                }
            }
            catch { }
        }




    }
}