using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReport
{
    public partial class Single_Three_Phase : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEarthing();
            }
        }
        private void ddlEarthing()
        {
            try
            {
                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthing();
                ddlPhaseEarthing.DataSource = dsEarthing;
                ddlPhaseEarthing.DataTextField = "Numbers";
                ddlPhaseEarthing.DataValueField = "Id";
                ddlPhaseEarthing.DataBind();
                ddlPhaseEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void ddlPhaseEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhaseEarthing.Visible = true;
            if (ddlPhaseEarthing.SelectedItem.ToString() == "1")
            {
                PhaseEarthing1.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "2")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "3")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "4")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "5")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "6")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "7")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "8")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "9")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "10")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "11")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
                PhaseEarthing11.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "12")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
                PhaseEarthing11.Visible = true;
                PhaseEarthing12.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "13")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
                PhaseEarthing11.Visible = true;
                PhaseEarthing12.Visible = true;
                PhaseEarthing13.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "14")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
                PhaseEarthing11.Visible = true;
                PhaseEarthing12.Visible = true;
                PhaseEarthing13.Visible = true;
                PhaseEarthing14.Visible = true;
            }
            else if (ddlPhaseEarthing.SelectedItem.ToString() == "15")
            {
                PhaseEarthing1.Visible = true;
                PhaseEarthing2.Visible = true;
                PhaseEarthing3.Visible = true;
                PhaseEarthing4.Visible = true;
                PhaseEarthing5.Visible = true;
                PhaseEarthing6.Visible = true;
                PhaseEarthing7.Visible = true;
                PhaseEarthing8.Visible = true;
                PhaseEarthing9.Visible = true;
                PhaseEarthing10.Visible = true;
                PhaseEarthing11.Visible = true;
                PhaseEarthing12.Visible = true;
                PhaseEarthing13.Visible = true;
                PhaseEarthing14.Visible = true;
                PhaseEarthing15.Visible = true;
            }

            else
            {
                PhaseEarthing1.Visible = false;
                PhaseEarthing2.Visible = false;
                PhaseEarthing3.Visible = false;
                PhaseEarthing4.Visible = false;
                PhaseEarthing5.Visible = false;
                PhaseEarthing6.Visible = false;
                PhaseEarthing7.Visible = false;
                PhaseEarthing8.Visible = false;
                PhaseEarthing9.Visible = false;
                PhaseEarthing10.Visible = false;
                PhaseEarthing11.Visible = false;
                PhaseEarthing12.Visible = false;
                PhaseEarthing13.Visible = false;
                PhaseEarthing14.Visible = false;
                PhaseEarthing15.Visible = false;
            }
        }
        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.Checked == false)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }
        protected void btnPhaseSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox4.Checked == false)
                {
                    label3.Visible = true;
                }
                else
                {

                    string TestReportId = string.Empty;
                    TestReportId = Session["TestReportId"].ToString();
                    CEI.InsertPhaseData(TestReportId, ddlTypeOfInstallation.SelectedItem.ToString(), ddlVoltageLevel.SelectedItem.ToString(), txtMainSwitch.Text, ddlPhaseEarthing.SelectedItem.ToString(),
                        ddlPhaseEarthing1.SelectedItem.ToString(), txtPhaseEarthing1.Text, ddlPhaseEarthingUsed1.SelectedItem.ToString(),
                        ddlPhaseEarthing2.SelectedItem.ToString(), txtPhaseEarthing2.Text, ddlPhaseEarthingUsed2.SelectedItem.ToString(), ddlPhaseEarthing3.SelectedItem.ToString(),
                        txtPhaseEarthing3.Text, ddlPhaseEarthingUsed3.SelectedItem.ToString(), ddlPhaseEarthing4.SelectedItem.ToString(), txtPhaseEarthing4.Text,
                        ddlPhaseEarthingUsed4.SelectedItem.ToString(), ddlPhaseEarthing5.SelectedItem.ToString(), txtPhaseEarthing5.Text, ddlPhaseEarthingUsed5.SelectedItem.ToString(),
                        ddlPhaseEarthing6.SelectedItem.ToString(), txtPhaseEarthing6.Text, ddlPhaseEarthingUsed6.SelectedItem.ToString(), ddlPhaseEarthing7.SelectedItem.ToString(),
                        txtPhaseEarthing7.Text, ddlPhaseEarthingUsed7.SelectedItem.ToString(), ddlPhaseEarthing8.SelectedItem.ToString(), txtPhaseEarthing8.Text,
                        ddlPhaseEarthingUsed8.SelectedItem.ToString(), ddlPhaseEarthing9.SelectedItem.ToString(), txtPhaseEarthing9.Text, ddlPhaseEarthingUsed9.SelectedItem.ToString(),
                        ddlPhaseEarthing10.SelectedItem.ToString(), txtPhaseEarthing10.Text, ddlPhaseEarthingUsed10.SelectedItem.ToString(),
                        ddlPhaseEarthing11.SelectedItem.ToString(), txtPhaseEarthing11.Text, ddlPhaseEarthingUsed11.SelectedItem.ToString(), ddlPhaseEarthing12.SelectedItem.ToString(),
                        txtPhaseEarthing12.Text, ddlPhaseEarthingUsed12.SelectedItem.ToString(), ddlPhaseEarthing13.SelectedItem.ToString(), txtPhaseEarthing13.Text,
                        ddlPhaseEarthingUsed13.SelectedItem.ToString(), ddlPhaseEarthing14.SelectedItem.ToString(), txtPhaseEarthing14.Text, ddlPhaseEarthingUsed14.SelectedItem.ToString(),
                        ddlPhaseEarthing15.SelectedItem.ToString(), txtPhaseEarthing15.Text, ddlPhaseEarthingUsed15.SelectedItem.ToString(), txtMinIRValue.Text, txtNoOfRCCB.Text, txtRCCBRating.Text,
                        txtCurrentCarryingCapacity.Text, txtNoOfCircuits.Text, txtNoOfMotors.Text);

                    DataSaved.Visible = true;
                    label3.Visible = false;

                }

            }
            catch (Exception)
            {

                DataSaved.Visible = false;
            }
        }
    }
}