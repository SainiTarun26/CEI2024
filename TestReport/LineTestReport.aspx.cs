using CEI_PRoject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CEIHaryana.TestReport
{
    public partial class LineTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string currentSessionName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;
                ddlLoadBindVoltage();
                ddlEarthing();
                SessionValue();
                PageWorking();

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
        protected void ddlCableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCableType.SelectedItem.ToString()== "Other")
            {
                OtherCable.Visible = true;
            }
            else
            {
                OtherCable.Visible = false;
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
                else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V" )
                {
                    Insulation220vAbove.Visible = true;
                    Insulation440vAbove.Visible = false;
                }  
                else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible =true;
                }
                else if (ddlLineVoltage.SelectedValue == "0")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible =false;
                }
                else
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
                                Insulation440vAbove.Visible = true;
                                Insulation220vAbove.Visible = false;
                            }

                        }
                    }
                }
                else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
                {
                    Insulation220vAbove.Visible = true;
                    Insulation440vAbove.Visible = false;
                }
                else if ( ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible = true;
                }
                else if (ddlLineVoltage.SelectedValue == "0")
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible = false;
                }
                else
                {
                    Insulation220vAbove.Visible = false;
                    Insulation440vAbove.Visible = true;
                }

            }
            else
            {

                LineTypeOverhead.Visible = false;
                LineTypeUnderground.Visible = false;
                Insulation440vAbove.Visible = true;
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
                if (Declaration.Visible == true && CheckBox1.Checked == false)
                {

                    labelVerification.Visible = true;

                }
                else 
                { 
                string LineId = string.Empty;
                if (Convert.ToString(Session["LineId"]) == null || Convert.ToString(Session["LineId"]) == "")
                {
                    LineId = CEI.GenerateUniqueID();
                    Session["LineId"] = LineId;

                }
                else
                {

                    LineId = Session["LineId"].ToString();
                }
                string TestReportId = Session["TestReportId"].ToString();
                string IntimationId = Session["id"].ToString();
                string CreatedBy = Session["AdminID"].ToString();
                CEI.InsertLineData(LineId, TestReportId, IntimationId, ddlLineVoltage.SelectedItem.ToString(), ddlOtherVoltage.SelectedItem.ToString(),TxtOthervoltage.Text, txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
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
           txtEarthWire.Text, txtNeutralWireEarth.Text, ddlCableType.SelectedItem.ToString(), txtOtherCable.Text, txtCableSize.Text, ddlCableLaid.SelectedItem.ToString(),
           txtRedWire.Text, txtYellowWire.Text, txtBlueWire.Text, txtRedYellowWire.Text, txtRedBlueWire.Text, txtBlueYellowWire.Text,
           txtNeutralPhaseWire.Text, txtPhaseWireEarth.Text, txtNeutralWireEarthUnderground.Text, CreatedBy);
                    Session["Page"] = Convert.ToInt32(Session["Page"]) + 1;
                    Reset();
                DataSaved.Visible = true;
                labelVerification.Visible = false;
                PageWorking();
                    int currentValue = Convert.ToInt32(Session["Page"]);
                    if (currentValue == Convert.ToInt32(sessionValue))
                    {
                        Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
                        btnSubmit.Visible = false;
                        Session["SubmittedValue2"] = sessionValue;
                        divLine.Visible = false;
                        Session["LineId"] = "";
                        if (nextSessionName == "Substation Transformer")
                        {
                            Response.Redirect("SubstationTransformer.aspx", false);
                        }
                        else if (nextSessionName == "Generating Station")
                        {
                            Response.Redirect("GeneratingSetTestReport.aspx", false);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Form Submitted Successfully')", true);

                        }
                        //NextSessionValueAndName();
                    }
            }

                
            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }
        public void SessionValue()
        {
            string[] installationTypes = { "installationType1", "installationType2", "installationType3", "installationType4", "installationType5", "installationType7", "installationType8", "installationNo8" };

            string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };

            int count = Convert.ToInt32(Session["Count"]);
            for (int i = count; i < installationNumbers.Length; i++)
            {
                sessionName = Session[installationTypes[i]] as string;
                sessionValue = Session[installationNumbers[i]] as string;
                if (!string.IsNullOrEmpty(sessionName))
                {
                    nextSessionName = Session[installationTypes[i + 1]] as string;
                    nextSessionValue = Session[installationNumbers[i + 1]] as string;
                    break;
                }
            }
        }
        public void NextSessionValueAndName()
        {
            SessionValue();
            string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };
            for (int i = 0; i < installationNumbers.Length; i++)
            {
                sessionName = Session["installationType" + (i + 1)] as string;
                sessionValue = Session[installationNumbers[i]] as string;

                if (!string.IsNullOrEmpty(sessionName))
                {
                    if (i < installationNumbers.Length - 1) 
                    {
                        nextSessionName = Session["installationType" + (i + 1)] as string;
                        nextSessionValue = Session[installationNumbers[i + 1]] as string;
                        if (nextSessionName == "Substation Transformer")
                        {
                            Response.Redirect("SubstationTransformer.aspx");
                        }
                        else if (nextSessionName == "Generating Station")
                        {
                            Response.Redirect("GeneratingSetTestReport.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Form Submitted Successfully')", true);

                        }
                    }
                }
            }
        }

        
        public void PageWorking()
        {
            try
            {
                SessionValue();
                x = Convert.ToInt32(Session["Page"]);
                if (x + 1 == int.Parse(sessionValue) && nextSessionName == "")
                {
                    Declaration.Visible = true;
                    btnSubmit.Text = "Submit";
                }
                else
                {
                    Declaration.Visible = false;
                    btnSubmit.Text = "Next";
                }
            }
            catch (Exception ex) { }

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
            OtherCable.Visible = false;
            Earthing.Visible = false;
            Insulation440vAbove.Visible = false;
            Insulation220vAbove.Visible = false;
            LineTypeUnderground.Visible = false;
            UndergroundInsulation440vAbove.Visible = false;
            UndergroundInsulation220vAbove.Visible = false;
        }

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
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

        protected void ddlCableType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(ddlCableType.SelectedItem.ToString().Trim() == "Other")
            {
                OtherCable.Visible = true;
            }
            else
            {
                OtherCable.Visible = false;
            }
        }
    }
}