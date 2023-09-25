using CEI_PRoject;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportForm1 : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                //{
                ddlLoadBindVoltage();
                ddlEarthing();
                ddlEarthingSubstation();
                //VisibleDiv()
                //  ddlEarthingGeneratingSet();
                //}
            }
        }
        private void VisibleDiv()
        {
            if (Session["installationType1"].ToString() == "Line")
            {
                Response.Redirect("LineTestReport");
            }
        }
        private void ddlEarthingSubstation()
        {

            DataSet dsEarthing = new DataSet();
            dsEarthing = CEI.GetddlEarthingSubstation();
            ddlEarthingsubstation.DataSource = dsEarthing;
            ddlEarthingsubstation.DataTextField = "NumberOfEarthing";
            ddlEarthingsubstation.DataValueField = "NumberOfEarthing";
            ddlEarthingsubstation.DataBind();
            ddlEarthingsubstation.Items.Insert(0, new ListItem("Select", "0"));
            dsEarthing.Clear();

        }
        #region Bind Earthing
        private void ddlEarthing()
        {
            try
            {
                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthing();
                ddlNoOfEarthing.DataSource = dsEarthing;
                ddlNoOfEarthing.DataTextField = "Numbers";
                ddlNoOfEarthing.DataValueField = "Id";
                ddlNoOfEarthing.DataBind();
                ddlGeneratingEarthing.Items.Insert(0, new ListItem("Select", "0"));

                ddlGeneratingEarthing.DataSource = dsEarthing;
                ddlGeneratingEarthing.DataTextField = "Numbers";
                ddlGeneratingEarthing.DataValueField = "Id";
                ddlGeneratingEarthing.DataBind();
                ddlGeneratingEarthing.Items.Insert(0, new ListItem("Select", "0"));

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
        #endregion
        protected void ddlLineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userInput = TxtOthervoltage.Text;
            Earthing.Visible = true;
            if (ddlLineType.SelectedValue == "1")
            {
                LineTypeOverhead.Visible = true;
                LineTypeUnderground.Visible = false;
                if (userInput.EndsWith("kV", StringComparison.OrdinalIgnoreCase))
                {

                    if (int.TryParse(userInput.TrimEnd('k', 'K', 'v', 'V'), out int value))
                    {

                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;

                    }
                }

                else if (userInput.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                {
                    // Input ends with "v", perform the "v" check
                    if (int.TryParse(userInput.TrimEnd('v', 'V'), out int value))
                    {
                        if (value > 440)
                        {
                            Insulation220vAbove.Visible = true;
                            Insulation440vAbove.Visible = false;
                        }
                        else if (value > 220)
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }

                    }

                }
            }
            else if (ddlLineType.SelectedValue == "2")
            {

                LineTypeUnderground.Visible = true;
                LineTypeOverhead.Visible = false;
                if (userInput.EndsWith("kV", StringComparison.OrdinalIgnoreCase))
                {

                    if (int.TryParse(userInput.TrimEnd('k', 'K', 'v', 'V'), out int value))
                    {

                        UndergroundInsulation220vAbove.Visible = false;
                        UndergroundInsulation440vAbove.Visible = true;

                    }
                }

                else if (userInput.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                {
                    // Input ends with "v", perform the "v" check
                    if (int.TryParse(userInput.TrimEnd('v', 'V'), out int value))
                    {
                        if (value > 440)
                        {
                            UndergroundInsulation220vAbove.Visible = true;
                            UndergroundInsulation440vAbove.Visible = false;
                        }
                        else if (value > 220)
                        {
                            UndergroundInsulation440vAbove.Visible = true;
                            UndergroundInsulation220vAbove.Visible = false;
                        }

                    }

                }
            }
            else
            {
                LineTypeOverhead.Visible = false;
                LineTypeUnderground.Visible = false;
                UndergroundInsulation220vAbove.Visible = false;
                UndergroundInsulation440vAbove.Visible = false;
                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;
                Earthing.Visible = false;
            }
        }
        protected void ddlGeneratingSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingSetType.SelectedItem.ToString() == "Solar Panel")
            {
                SolarPanelGeneratingSet.Visible = true;
            }
            else
            {
                SolarPanelGeneratingSet.Visible = false;
            }

        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false)
            {
                labelVerification.Visible = true;
            }
            else
            {
                labelVerification.Visible = false;
            }
        }
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == false)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == false)
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
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
        protected void ddlConductorType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlConductorType.SelectedValue == "1")
            {

                OverheadBare.Visible = true;
                OverheadCable.Visible = false;

            }
            else if (ddlConductorType.SelectedValue == "2")
            {

                OverheadCable.Visible = true;
                OverheadBare.Visible = false;
            }
            else
            {
                OverheadBare.Visible = false;
                OverheadCable.Visible = false;
            }
        }
        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageForLine();
            ddlLineVoltage.DataSource = dsVoltage;
            ddlLineVoltage.DataTextField = "Voltage";
            ddlLineVoltage.DataValueField = "Id";
            ddlLineVoltage.DataBind();
            ddlLineVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLineVoltage.SelectedItem.ToString() == "Other")
            {
                OtherVoltage.Visible = true;
            }
            else
            {
                OtherVoltage.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox1.Checked == false)
                {
                    labelVerification.Visible = true;
                }

                else
                {
                    string TestReportId = string.Empty;
                    TestReportId = Session["TestReportId"].ToString();
                    CEI.InsertLineData(TestReportId, txtLineLength.Text, ddlLineVoltage.SelectedItem.ToString(), txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
                   ddlNmbrOfCircuit.SelectedItem.ToString(), ddlConductorType.SelectedItem.ToString(), txtPoleTower.Text, txtConductorSize.Text,
                  txtGroundWireSize.Text, txtRailwayCrossingNo.Text, txtRoadCrossingNo.Text, txtRiverCanalCrossing.Text, txtPowerLineCrossing.Text,
                   ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), txtearthingValue1.Text, ddlEarthingtype2.SelectedItem.ToString(),
                   txtEarthingValue2.Text, ddlEarthingtype3.SelectedItem.ToString(), txtEarthingValue3.Text, ddlEarthingtype4.SelectedItem.ToString(),
                  txtEarthingValue4.Text, ddlEarthingtype5.SelectedItem.ToString(), txtEarthingValue5.Text, ddlEarthingtype6.SelectedItem.ToString(),
                 txtEarthingValue6.Text, ddlEarthingtype7.SelectedItem.ToString(), txtEarthingValue7.Text, ddlEarthingtype8.SelectedItem.ToString(),
                 txtEarthingValue8.Text, ddlEarthingtype9.SelectedItem.ToString(), txtEarthingValue9.Text, ddlEarthingtype10.SelectedItem.ToString(),
                 txtEarthingValue10.Text, ddlEarthingtype11.SelectedItem.ToString(), txtEarthingValue11.Text, ddlEarthingtype12.SelectedItem.ToString(),
                 txtEarthingValue12.Text, ddlEarthingtype13.SelectedItem.ToString(), txtEarthingValue13.Text, ddlEarthingtype14.SelectedItem.ToString(),
                 txtEarthingValue14.Text, ddlEarthingtype15.SelectedItem.ToString(), txtEarthingValue15.Text, txtPoleTowerNo.Text, txtCableSize1.Text,
                 txtRailwayCrossingNmbr.Text, txtRoadCrossingNmbr.Text, txtRiverCanalCrossingNmber.Text, txtPowerLineCrossingNmbr.Text, txtRedEarthWire.Text,
                 txtYellowEarthWire.Text, txtBlueEarthWire.Text, txtRedYellowPhase.Text, txtRedBluePhase.Text, txtBlueYellowPhase.Text, txtNeutralWire.Text,
               txtEarthWire.Text, txtNeutralWireEarth.Text, ddlCableType.SelectedItem.ToString(), txtCableSize.Text, ddlCableLaid.SelectedItem.ToString(),
               txtRedWire.Text, txtYellowWire.Text, txtBlueWire.Text, txtRedYellowWire.Text, txtRedBlueWire.Text, txtBlueYellowWire.Text,
               txtNeutralPhaseWire.Text, txtPhaseWireEarth.Text, txtNeutralWireEarthUnderground.Text);

                    DataSaved.Visible = true;
                    labelVerification.Visible = false;
                }
            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }
        protected void BtnSubmitSubstation_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox2.Checked == false)
                {
                    label1.Visible = true;
                }

                else
                {
                    string TestReportId = string.Empty;
                    TestReportId = Session["TestReportId"].ToString();
                    CEI.InsertSubstationData(TestReportId, txtTransformerSerialNumber.Text, txtTransformerCapacity.Text, ddltransformerType.SelectedItem.ToString(),
                        txtPrimaryVoltage.Text, txtSecondryVoltage.Text, txtOilCapacity.Text, txtOilBDV.Text, txtHTsideInsulation.Text, txtLTSideInsulation.Text,
                        txtLowestValue.Text, txtLightningArrestor.Text, ddlHTType.SelectedItem.ToString(), ddlEarthingsubstation.SelectedItem.ToString(),
                        ddlSubstationEarthing1.SelectedItem.ToString(), txtSubstationEarthing1.Text, ddlUsedFor1.SelectedItem.ToString(), ddlSubstationEarthing2.SelectedItem.ToString(),
                        txtSubstationEarthing2.Text, ddlUsedFor2.SelectedItem.ToString(), ddlSubstationEarthing3.SelectedItem.ToString(), txtSubstationEarthing3.Text, ddlUsedFor3.SelectedItem.ToString(),
                        ddlSubstationEarthing4.SelectedItem.ToString(), txtSubstationEarthing4.Text, ddlUsedFor4.SelectedItem.ToString(), ddlSubstationEarthing5.SelectedItem.ToString(), txtSubstationEarthing5.Text,
                        ddlUsedFor5.SelectedItem.ToString(), ddlSubstationEarthing6.SelectedItem.ToString(), txtSubstationEarthing6.Text, ddlUsedFor6.SelectedItem.ToString(),
                        ddlSubstationEarthing7.SelectedItem.ToString(), txtSubstationEarthing7.Text, ddlUsedFor7.SelectedItem.ToString(), ddlSubstationEarthing8.SelectedItem.ToString(),
                        txtSubstationEarthing8.Text, ddlUsedFor8.SelectedItem.ToString(), ddlSubstationEarthing9.SelectedItem.ToString(), txtSubstationEarthing9.Text, ddlUsedFor9.SelectedItem.ToString(),
                        ddlSubstationEarthing10.SelectedItem.ToString(), txtSubstationEarthing10.Text, ddlUsedFor10.SelectedItem.ToString(), ddlSubstationEarthing11.SelectedItem.ToString(),
                        txtSubstationEarthing11.Text, ddlUsedFor11.SelectedItem.ToString(), ddlSubstationEarthing12.SelectedItem.ToString(), txtSubstationEarthing12.Text,
                        ddlUsedFor12.SelectedItem.ToString(), ddlSubstationEarthing13.SelectedItem.ToString(), txtSubstationEarthing13.Text, ddlUsedFor13.SelectedItem.ToString(),
                        ddlSubstationEarthing14.SelectedItem.ToString(), txtSubstationEarthing14.Text, ddlUsedFor14.SelectedItem.ToString(), ddlSubstationEarthing15.SelectedItem.ToString(),
                        txtSubstationEarthing15.Text, ddlUsedFor15.SelectedItem.ToString(), ddlSubstationEarthing16.SelectedItem.ToString(), txtSubstationEarthing16.Text, ddlUsedFor16.SelectedItem.ToString(),
                        ddlSubstationEarthing17.SelectedItem.ToString(), txtSubstationEarthing17.Text, ddlUsedFor17.SelectedItem.ToString(), ddlSubstationEarthing18.SelectedItem.ToString(), txtSubstationEarthing18.Text,
                        ddlUsedFor18.SelectedItem.ToString(), ddlSubstationEarthing19.SelectedItem.ToString(),
                        txtSubstationEarthing19.Text, ddlUsedFor19.SelectedItem.ToString(), ddlSubstationEarthing20.SelectedItem.ToString(),
                        txtSubstationEarthing20.Text, ddlUsedFor20.SelectedItem.ToString(), txtBreakerCapacity.Text, ddlLTProtection.SelectedItem.ToString(), txtIndividualCapacity.Text,
                        txtLTBreakerCapacity.Text, txtLoadBreakingCapacity.Text, txtSealLevelPlinth.Text);

                    DataSaved.Visible = true;
                    labelVerification.Visible = false;
                }
            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }

        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;
            if (ddlNoOfEarthing.SelectedItem.ToString() == "1")
            {
                Earthingtype1.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "2")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "3")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "4")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "5")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "6")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "7")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "8")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "9")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "10")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "11")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "12")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "13")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype13.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "14")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype14.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "15")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype15.Style.Add("display", "table-row");

            }
        }

        public void Reset()
        {
            txtLineLength.Text = "";
            ddlLineVoltage.SelectedValue = "0";
            txtLineLength.Text = ""; ddlLineType.SelectedValue = "0"; ddlNmbrOfCircuit.SelectedValue = "0"; ddlConductorType.SelectedValue = "0"; txtPoleTower.Text = ""; txtConductorSize.Text = "";
            txtGroundWireSize.Text = ""; txtRailwayCrossingNo.Text = ""; txtRoadCrossingNo.Text = ""; txtRiverCanalCrossing.Text = ""; txtPowerLineCrossing.Text = "";
            ddlNoOfEarthing.SelectedValue = "0"; ddlEarthingtype1.SelectedValue = "0"; txtearthingValue1.Text = ""; ddlEarthingtype2.SelectedValue = "0";
            txtEarthingValue2.Text = ""; ddlEarthingtype3.SelectedValue = "0"; txtEarthingValue3.Text = ""; ddlEarthingtype4.SelectedValue = "0";
            txtEarthingValue4.Text = ""; ddlEarthingtype5.SelectedValue = "0"; txtEarthingValue5.Text = ""; ddlEarthingtype6.SelectedValue = "0";
            txtEarthingValue6.Text = ""; ddlEarthingtype7.SelectedValue = "0"; txtEarthingValue7.Text = "";
            ddlEarthingtype8.SelectedValue = "0"; txtEarthingValue8.Text = ""; ddlEarthingtype9.SelectedValue = "0";
            txtEarthingValue9.Text = ""; ddlEarthingtype10.SelectedValue = "0"; txtEarthingValue10.Text = ""; ddlEarthingtype11.SelectedValue = "0";
            txtEarthingValue11.Text = ""; ddlEarthingtype12.SelectedValue = "0"; txtEarthingValue12.Text = ""; ddlEarthingtype13.SelectedValue = "0";
            txtEarthingValue13.Text = ""; ddlEarthingtype14.SelectedValue = "0"; txtEarthingValue14.Text = ""; ddlEarthingtype15.SelectedValue = "0";
            txtEarthingValue15.Text = ""; txtPoleTowerNo.Text = ""; txtCableSize1.Text = ""; txtRailwayCrossingNmbr.Text = ""; txtRoadCrossingNmbr.Text = "";
            txtRiverCanalCrossingNmber.Text = ""; txtPowerLineCrossingNmbr.Text = ""; txtRedEarthWire.Text = ""; txtYellowEarthWire.Text = "";
            txtBlueEarthWire.Text = ""; txtRedYellowPhase.Text = ""; txtRedBluePhase.Text = ""; txtBlueYellowPhase.Text = ""; txtNeutralWire.Text = "";
            txtEarthWire.Text = ""; txtNeutralWireEarth.Text = ""; ddlCableType.SelectedValue = "0"; txtCableSize.Text = ""; ddlCableLaid.SelectedValue = "0"; txtRedWire.Text = ""; txtYellowWire.Text = ""; txtBlueWire.Text = ""; txtRedYellowWire.Text = "";
            txtRedBlueWire.Text = ""; txtBlueYellowWire.Text = ""; txtNeutralPhaseWire.Text = ""; txtPhaseWireEarth.Text = ""; txtNeutralWireEarthUnderground.Text = "";
        }
        protected void ddltransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltransformerType.SelectedValue == "1")
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = true;
            }
            else
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = false;
            }
        }
        protected void ddlEarthingsubstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubstationEarthingDiv.Visible = true;
            if (ddlEarthingsubstation.SelectedItem.ToString() == "4")
            {
                EarthingSubstation4.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "5")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "6")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "7")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "8")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "9")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "10")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "11")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "12")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "13")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "14")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "15")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "16")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "17")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "18")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "19")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible = true;
                EathingSubstation19.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "20")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible = true;
                EathingSubstation19.Visible = true;
                EathingSubstation20.Visible = true;
            }
            else
            {
                EarthingSubstation4.Visible = false;
                EathingSubstation5.Visible = false;
                EathingSubstation6.Visible = false;
                EathingSubstation7.Visible = false;
                EathingSubstation8.Visible = false;
                EathingSubstation9.Visible = false;
                EathingSubstation10.Visible = false;
                EathingSubstation11.Visible = false;
                EathingSubstation12.Visible = false;
                EathingSubstation13.Visible = false;
                EathingSubstation14.Visible = false;
                EathingSubstation15.Visible = false;
                EathingSubstation16.Visible = false;
                EathingSubstation17.Visible = false;
                EathingSubstation18.Visible = false;
                EathingSubstation19.Visible = false;
                EathingSubstation20.Visible = false;
            }

        }

        protected void ddlHTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHTType.SelectedValue == "3")
            {
                Breaker.Visible = true;
                FuseUnit.Visible = false;
            }
            else
            {
                FuseUnit.Visible = false;
                Breaker.Visible = false;
            }
        }
        protected void ddlLTProtection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLTProtection.SelectedValue == "1")
            {
                FuseUnit.Visible = true;
                Breaker.Visible = false;
            }
            else if (ddlLTProtection.SelectedValue == "2")
            {
                FuseUnit.Visible = false;
                Breaker.Visible = true;
            }
            else
            {
                FuseUnit.Visible = false;
                Breaker.Visible = false;
            }
        }

        protected void ddlGeneratingEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneratingEarthing.Visible = true;
            if (ddlGeneratingEarthing.SelectedValue == "1" || ddlGeneratingEarthing.SelectedValue == "2" || ddlGeneratingEarthing.SelectedValue == "3" || ddlGeneratingEarthing.SelectedValue == "4")
            {
                Limit.Visible = true;
                GeneratingEarthing.Visible = false;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "4")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "5")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "6")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "7")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "8")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "9")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "10")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "11")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "12")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "13")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "14")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "15")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
                GeneratingEarthing15.Visible = true;
            }

            else
            {
                GeneratingEarthing4.Visible = false;
                GeneratingEarthing5.Visible = false;
                GeneratingEarthing6.Visible = false;
                GeneratingEarthing7.Visible = false;
                GeneratingEarthing8.Visible = false;
                GeneratingEarthing9.Visible = false;
                GeneratingEarthing10.Visible = false;
                GeneratingEarthing11.Visible = false;
                GeneratingEarthing12.Visible = false;
                GeneratingEarthing13.Visible = false;
                GeneratingEarthing14.Visible = false;
                GeneratingEarthing15.Visible = false;
                Limit.Visible = false;
            }

        }
        protected void BtnSubmitGeneratingSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox3.Checked == false)
                {
                    label2.Visible = true;
                }
                else
                {
                    string TestReportId = string.Empty;
                    TestReportId = Session["TestReportId"].ToString();
                    CEI.InsertGeneratingSetData(TestReportId, ddlCapacity.SelectedItem.ToString(), txtCapacity.Text, txtSerialNoOfGenerator.Text, ddlGeneratingSetType.SelectedItem.ToString(),
               txtGeneratorVoltage.Text, txtCurrentCapacity.Text, txtBreakingCapacity.Text, ddlPlantType.SelectedItem.ToString(), ddlPlantCapacity.SelectedItem.ToString(),
              txtPlantCapacity.Text, txtDCString.Text, txtLowestInsulation.Text, txtPCVOrSolar.Text, txtLTACCapacity.Text, txtLowestInsulationAC.Text,
              ddlGeneratingEarthing.SelectedItem.ToString(), ddlGeneratingEarthing1.SelectedItem.ToString(), txtGeneratingEarthing1.Text, ddlGeneratingEarthingUsed1.SelectedItem.ToString(),
              ddlGeneratingEarthing2.SelectedItem.ToString(), txtGeneratingEarthing2.Text, ddlGeneratingEarthingUsed2.SelectedItem.ToString(), ddlGeneratingEarthing3.SelectedItem.ToString(), txtGeneratingEarthing3.Text, ddlGeneratingEarthingUsed3.SelectedItem.ToString(),
             ddlGeneratingEarthing4.SelectedItem.ToString(), txtGeneratingEarthing4.Text, ddlGeneratingEarthingUsed4.SelectedItem.ToString(), ddlGeneratingEarthing5.SelectedItem.ToString(), txtGeneratingEarthing5.Text, ddlGeneratingEarthingUsed5.SelectedItem.ToString(),
          ddlGeneratingEarthing6.SelectedItem.ToString(), txtGeneratingEarthing6.Text, ddlGeneratingEarthingUsed6.SelectedItem.ToString(), ddlGeneratingEarthing7.SelectedItem.ToString(), txtGeneratingEarthing7.Text, ddlGeneratingEarthingUsed7.SelectedItem.ToString(),
          ddlGeneratingEarthing8.SelectedItem.ToString(), txtGeneratingEarthing8.Text, ddlGeneratingEarthingUsed8.SelectedItem.ToString(), ddlGeneratingEarthing9.SelectedItem.ToString(), txtGeneratingEarthing9.Text, ddlGeneratingEarthingUsed9.SelectedItem.ToString(),
           ddlGeneratingEarthing10.SelectedItem.ToString(), txtGeneratingEarthing10.Text, ddlGeneratingEarthingUsed10.SelectedItem.ToString(), ddlGeneratingEarthing11.SelectedItem.ToString(), txtGeneratingEarthing11.Text, ddlGeneratingEarthingUsed11.SelectedItem.ToString(),
            ddlGeneratingEarthing12.SelectedItem.ToString(), txtGeneratingEarthing12.Text, ddlGeneratingEarthingUsed12.SelectedItem.ToString(), ddlGeneratingEarthing13.SelectedItem.ToString(), txtGeneratingEarthing13.Text, ddlGeneratingEarthingUsed13.SelectedItem.ToString(),
           ddlGeneratingEarthing14.SelectedItem.ToString(), txtGeneratingEarthing14.Text, ddlGeneratingEarthingUsed14.SelectedItem.ToString(), ddlGeneratingEarthing15.SelectedItem.ToString(), txtGeneratingEarthing15.Text, ddlGeneratingEarthingUsed15.SelectedItem.ToString());

                    DataSaved.Visible = true;
                    label2.Visible = false;

                }

            }
            catch (Exception)
            {

                DataSaved.Visible = false;
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
    }
}