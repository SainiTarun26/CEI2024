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
    public partial class LineTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string sessionValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;
                ddlLoadBindVoltage();
                ddlEarthing();

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
                ddlNoOfEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
   
        protected void ddlLineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userInput = TxtOthervoltage.Text;
            Earthing.Visible = true;
            if (ddlLineType.SelectedValue == "1")
            {
                LineTypeOverhead.Visible = true;
                LineTypeUnderground.Visible = false;
                if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
                {
                    if (ddlOtherVoltage.SelectedValue == "2")
                    {

                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {

                            Insulation220vAbove.Visible = false;
                            Insulation440vAbove.Visible = true;

                        }
                    }

                    else if (ddlOtherVoltage.SelectedValue == "1")
                    {
                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {
                            if (value > 440)
                            {
                                Insulation220vAbove.Visible = false;
                                Insulation440vAbove.Visible = true;
                            }
                            else if (value > 220)
                            {
                                Insulation440vAbove.Visible = false;
                                Insulation220vAbove.Visible = true;
                            }
                            else
                            {
                                Insulation440vAbove.Visible = false;
                                Insulation220vAbove.Visible = false;
                            }

                        }
                    }
                }
                else if(ddlLineVoltage.SelectedItem.ToString().Trim() != "220V" || ddlLineVoltage.SelectedItem.ToString().Trim() != "440V")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible = true;
                }

            }
            else if (ddlLineType.SelectedValue == "2")
            {

                LineTypeUnderground.Visible = true;
                LineTypeOverhead.Visible = false;
                if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
                {
                    if (ddlOtherVoltage.SelectedValue == "2")
                    {

                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {

                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;

                        }
                    }

                    else if (ddlOtherVoltage.SelectedValue == "1")
                    {
                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {
                            if (value > 440)
                            {
                                Insulation440vAbove.Visible = true;
                                Insulation220vAbove.Visible = false;
                            }
                            else if (value > 220)
                            {
                                Insulation440vAbove.Visible = false;
                                Insulation220vAbove.Visible = true;
                            }
                            else
                            {
                                Insulation440vAbove.Visible = false;
                                Insulation220vAbove.Visible = false;
                            }

                        }
                    }
                }
                else if (ddlLineVoltage.SelectedItem.ToString().Trim() != "220V" || ddlLineVoltage.SelectedItem.ToString().Trim() != "440V")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible = true;
                }

            }
            else
            {

                LineTypeOverhead.Visible = false;
                LineTypeUnderground.Visible = false;
                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;
                Earthing.Visible = false;
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
                    Reset();
                    DataSaved.Visible = true;
                    labelVerification.Visible = false;
                    PageWorking();
                }
            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }
        public void PageWorking()
        {
            if (Session["installationNo1"].ToString() != null && Session["installationNo1"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo1"] as string;
            }
            else if (Session["installationNo2"].ToString() != null && Session["installationNo2"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo2"] as string;
            }
            else if (Session["installationNo3"].ToString() != null && Session["installationNo3"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo3"] as string;
            }
            else if (Session["installationNo4"].ToString() != null && Session["installationNo4"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo4"] as string;
            }
            else if (Session["installationNo5"].ToString() != null && Session["installationNo5"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo5"] as string;
            }
            else if (Session["installationNo6"].ToString() != null && Session["installationNo6"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo6"] as string;
            }
            else if (Session["installationNo7"].ToString() != null && Session["installationNo7"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo7"] as string;
            }
            else if (Session["installationNo8"].ToString() != null && Session["installationNo8"].ToString() != string.Empty)
            {
                sessionValue = Session["installationNo8"] as string;
            }

            int currentValue = Convert.ToInt32(hdn.Value);
            currentValue += 1;
            hdn.Value = currentValue.ToString();
            if (hdn.Value == sessionValue)
            {
                btnSubmit.Visible = false;
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

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
            {
                divOtherVoltages.Visible = true;
                OtherVoltage.Visible = true;
            }
            else
            {
                divOtherVoltages.Visible = false;
                OtherVoltage.Visible = false;
            }
        }
    }
}