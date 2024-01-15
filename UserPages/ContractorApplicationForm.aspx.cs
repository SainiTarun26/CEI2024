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
using System.Web.UI.HtmlControls;


namespace CEIHaryana.UserPages
{
    public partial class ContractorApplicationForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        HtmlTableRow newRow = new HtmlTableRow();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlLoadBindState(ddlState);
                   // AddNewRow();
                }
                else
                {
                    // Recreate dynamic controls on postback
                    //AddNewRow();
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlState = (DropDownList)sender;
            string selectedState = ddlState.SelectedItem.ToString().Trim();

            HtmlTableRow row = (HtmlTableRow)ddlState.Parent.Parent;

            // Find the ddlDistrict DropDownList within the current row
            DropDownList ddlDistrict = null;
            foreach (Control control in ParteneDirector.Controls)
            {
                if (control is HtmlTableRow && ((HtmlTableRow)control).ID == row.ID)
                {
                    // Iterate through the controls in the current row to find ddlDistrict
                    foreach (Control rowControl in control.Controls)
                    {
                        if (rowControl is DropDownList && rowControl.ID.StartsWith("ddlDistrict"))
                        {
                            ddlDistrict = (DropDownList)rowControl;
                            break;
                        }
                    }
                    break; // Stop searching after finding the correct row
                }
            }

           
                ddlLoadBindDistrict(ddlDistrict, selectedState); // Bind the district dropdown
            



        }

        private void ddlLoadBindState(DropDownList ddl)
        {
            try
            {
                DataSet dsState = CEI.GetddlDrawState();
                ddl.DataSource = dsState;
                ddl.DataTextField = "StateName";
                ddl.DataValueField = "StateID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
                // Handle the exception
            }
        }

        private void ddlLoadBindDistrict(DropDownList ddlDistrict, string state)
        {
            try
            {
                DataSet dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                // Handle the exception
            }
        }
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            // Add a new row when the "Add More" button is clicked
            AddNewRow();
        }
        protected void choicesMultipleRemoveButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }

        private int rowCount = 1;
        private void AddNewRow()
        {
            
            HtmlTableCell cell1 = new HtmlTableCell();
            DropDownList ddlAuthorityType = new DropDownList();
            ddlAuthorityType.ID = "ddlAuthorityType_" + rowCount; // Assign a unique ID
            cell1.Controls.Add(ddlAuthorityType);

            HtmlTableCell cell2 = new HtmlTableCell();
            TextBox txtFullName = new TextBox();
            txtFullName.ID = "txtFullName_" + rowCount; // Assign a unique ID
            cell2.Controls.Add(txtFullName);

            HtmlTableCell cell3 = new HtmlTableCell();
            TextBox txtAddress = new TextBox();
            txtAddress.ID = "txtAddress_" + rowCount; // Assign a unique ID
            cell3.Controls.Add(txtAddress);

            HtmlTableCell cell4 = new HtmlTableCell();
            DropDownList ddlState = new DropDownList();
            ddlState.ID = "ddlState_" + rowCount; // Assign a unique ID
            ddlState.AutoPostBack = true;
            ddlState.SelectedIndexChanged += ddlState_SelectedIndexChanged; // Handle the event
            cell4.Controls.Add(ddlState);

            HtmlTableCell cell5 = new HtmlTableCell();
            DropDownList ddlDistrict = new DropDownList();
            ddlDistrict.ID = "ddlDistrict_" + rowCount; // Assign a unique ID
            cell5.Controls.Add(ddlDistrict);

            HtmlTableCell cell6 = new HtmlTableCell();
            TextBox txtPincode = new TextBox();
            txtPincode.ID = "txtPincode_" + rowCount; // Assign a unique ID
            cell6.Controls.Add(txtPincode);

            newRow.Cells.Add(cell1);
            newRow.Cells.Add(cell2);
            newRow.Cells.Add(cell3);
            newRow.Cells.Add(cell4);
            newRow.Cells.Add(cell5);
            newRow.Cells.Add(cell6);
            ParteneDirector.Rows.Add(newRow);
            ddlLoadBindState(ddlState);
            rowCount++; // Increment the counter for the next row
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string CreatedBy = Session["ContractorID"].ToString();

                //CEI.ContractorApplicationData(txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(), ddlRegisterdOffice.SelectedItem.ToString(),
                //    DdlPartnerOrDirector.SelectedItem.ToString(), txtCompanyPenalities.Text, ddlLibraryAvailable.SelectedItem.ToString(),
                //    txtAgentName.Text, ddlFirmOrUnit.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(), txtIssuingAuthorityName.Text, txtDOB.Text,
                //    txtLicenseExpiryDate.Text, ddlTypofEmployee1.SelectedItem.ToString(), txtLicenseNumber1.Text, txtIssueDate1.Text, txtValidityDate1.Text,
                //    txtQualification1.Text, ddlTypofEmployee2.SelectedItem.ToString(), txtLicenseNumber2.Text, txtIssueDate2.Text, txtValidityDate2.Text,
                //    txtQualification2.Text, "Admin");

                foreach (HtmlTableRow row in ParteneDirector.Rows)
                {
                    DropDownList ddlAuthorityType = (DropDownList)row.FindControl("ddlAuthorityType_" + row.ID.Split('_')[1]);
                    DropDownList ddlState = (DropDownList)row.FindControl("ddlState_" + row.ID.Split('_')[1]);
                    string selectedState = ddlState.SelectedItem?.ToString().Trim() ?? string.Empty;
                    TextBox txtFullName = (TextBox)row.FindControl("txtFullName_" + row.ID.Split('_')[1]);
                    TextBox txtAddress = (TextBox)row.FindControl("txtAddress_" + row.ID.Split('_')[1]);
                    DropDownList ddlDistrict = (DropDownList)row.FindControl("ddlDistrict_" + row.ID.Split('_')[1]);
                    TextBox txtPincode = (TextBox)row.FindControl("txtPincode_" + row.ID.Split('_')[1]);

                    // Use a Dictionary to store data for each row
                    Dictionary<string, string> rowData = new Dictionary<string, string>
        {
            { "TypeOfAuthority", ddlAuthorityType.SelectedValue },
            { "Name", txtFullName.Text },
            { "Address", txtAddress.Text },
            { "State", selectedState },
            { "District", ddlDistrict.SelectedValue },
            { "Pincode", txtPincode.Text },
            { "CreatedBy", CreatedBy }  
        };

                    // Call the method in your DataAccess class to insert the data
                    CEI.ContractorPartners(rowData);
                }
            }
            catch 
            { 

            }
        }




    }
}