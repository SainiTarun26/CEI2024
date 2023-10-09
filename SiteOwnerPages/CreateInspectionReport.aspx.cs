using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class CreateInspectionReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ddlLoadBindPremises();
                ddlLoadBindVoltage();
                if (Convert.ToString(Session["LineID"]) != null)
                {
                    txtWorkType.Text = "Line";
                   
                }
                else if (Convert.ToString(Session["SubStationID"]) != null)
                {
                    txtWorkType.Text = "Substation Transformer";

                }
                else if (Convert.ToString(Session["GeneratingSetId"]) != null)
                {
                    txtWorkType.Text = "Generating Station";

                }
            }
        }

        private void ddlLoadBindPremises()
        {
            try
            {

                DataSet dsPremises = new DataSet();
                dsPremises = CEI.GetddlPremises();
                ddlPremises.DataSource = dsPremises;
                ddlPremises.DataTextField = "Premises";
                ddlPremises.DataValueField = "ID";
                ddlPremises.DataBind();
                ddlPremises.Items.Insert(0, new ListItem("Select", "0"));
                dsPremises.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        } 
        private void ddlLoadBindVoltage()
        {
            try
            {

                DataSet dsVoltage = new DataSet();
                dsVoltage = CEI.GetddlTestReportVoltage();
                ddlVoltage.DataSource = dsVoltage;
                ddlVoltage.DataTextField = "Voltage";
                ddlVoltage.DataValueField = "Id";
                ddlVoltage.DataBind();
                ddlVoltage.Items.Insert(0, new ListItem("Select", "0"));
                dsVoltage.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uploads.Visible = true;
            if (txtWorkType.Text == "Line")
            {
                if (ddlworktype.SelectedValue == "1")
                {
                    LineSubstationSupplier.Visible = true;
                    SupplierSub.Visible = true;
                }
                else if (ddlworktype.SelectedValue == "2")
                {
                    LinePersonal.Visible = true;
                    SupplierSub.Visible = true;
                }
            }
            else if (txtWorkType.Text == "Substation Transformer")
            {
                if (ddlworktype.SelectedValue == "1")
                {
                    LineSubstationSupplier.Visible = true;
                }
                else if (ddlworktype.SelectedValue == "2")
                {
                    PersonalSub.Visible = true;
                }
            } 
            else if (txtWorkType.Text == "Generating Set")
            {
                 if (ddlworktype.SelectedValue == "2")
                {
                    PersonalGenerating.Visible = true;
                }
                else
                {
                    PersonalGenerating.Visible = false;
                }
            }
            else
            {
                LineSubstationSupplier.Visible = false;
                SupplierSub.Visible = false;
                PersonalGenerating.Visible = false;
            }

        }
    }
}