using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class LineTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string type = string.Empty;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string currentSessionName = string.Empty;
        string IdUpdate = string.Empty;
        string LineId = string.Empty;
        List<(string IntimationId, string RowNumber, string EarthingType, string Valueinohms)> EarthingData = new List<(string, string, string, string)>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                {

                    if (!IsPostBack)
                    {
                        var master = (MasterPage)Master;
                        var loginTypeLabel = (Label)master.FindControl("LoginType");
                        if (loginTypeLabel != null)
                        {
                            loginTypeLabel.Text = "Supervisor / Create New Test Report / Installation Details / Test Report";
                        }

                        // GetHistoryDataById();
                        ddlLoadBindVoltage();
                        ddlEarthing();
                        Insulation440vAbove.Visible = false;
                        Insulation220vAbove.Visible = false;
                        // BtnBack.Visible = false;
                        if (Convert.ToString(Session["ValueId"]) == null || Convert.ToString(Session["ValueId"]) == "")
                        {
                            // GetHistoryDataById();
                        }
                        else
                        {
                            LineId = Session["LineID"].ToString().Trim();
                            GetHistoryDataById();
                        }
                        if (Convert.ToString(Session["Approval"]) == "Reject")
                        {
                            LineId = Session["LineID"].ToString().Trim();//
                            Session["Application"] = Session["ApplicationForTestReport"].ToString().Trim();//
                            Session["Typs"] = Session["TypeOf"].ToString().Trim();                       //
                            Session["Intimations"] = Session["ID"].ToString().Trim();
                            Session["IHID"] = Session["IHIDs"].ToString().Trim();   //
                            Session["NoOfInstallations"] = Session["NoOfInstallation"].ToString().Trim();  //
                            //BtnBack.Visible = true;
                            GetHistoryDataById();
                        }
                        if (Session["TypeOfInspection"]?.ToString() == "Periodic")
                        {
                            txtapplication.Text = Session["TypeOfInspection"].ToString().Trim();
                            txtInstallation.Text = Session["Installation"].ToString().Trim();
                            txtid.Text = Session["Intimation"].ToString().Trim();
                            txtNOOfInstallation.Text = Session["Count"].ToString();

                            BtnBack.Visible = true;
                        }
                        else
                        {
                            txtapplication.Text = Session["Application"].ToString().Trim();
                            txtInstallation.Text = Session["Typs"].ToString().Trim();
                            txtid.Text = Session["Intimations"].ToString().Trim();
                            txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                            BtnBack.Visible = true;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");

                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        private void GetHistoryDataById()
        {
            try
            {
                //if (Convert.ToString(Session["Value"]) == null || Convert.ToString(Session["Value"]) == "")
                //{
                //    //
                //}
                //else
                //{
                //    type = Session["Value"].ToString();
                //}
                if (Convert.ToString(Session["Approval"]) == "Reject")
                {
                    type = "line";
                }
                type = "line";//Session["Value"].ToString();
                LineId = Session["LineId"].ToString().Trim();

                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataForUpdate(type, LineId);

                if (ds.Tables.Count > 0)
                {
                    Session["Contact"] = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    Session["GeneratedLineId"] = ds.Tables[0].Rows[0]["LineId"].ToString().Trim();
                    Session["TestReportId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString().Trim();
                    Session["id"] = ds.Tables[0].Rows[0]["IntimationId"].ToString().Trim();
                    string lineVoltage = ds.Tables[0].Rows[0]["LineVoltage"].ToString();

                    ddlLoadBindVoltage();
                    ddlLineVoltage.SelectedIndex = ddlLineVoltage.Items.IndexOf(ddlLineVoltage.Items.FindByText(lineVoltage));
                    if (lineVoltage == "Other")
                    {
                        divOtherVoltages.Visible = true;
                        OtherVoltage.Visible = true;

                        ddlOtherVoltage.SelectedItem.Text = ds.Tables[0].Rows[0]["OtherVoltageType"].ToString();
                        TxtOthervoltage.Text = ds.Tables[0].Rows[0]["OtherVoltage"].ToString();

                        if (ddlOtherVoltage.SelectedItem.Text.Trim() == "KV")
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }
                        else if (ddlOtherVoltage.SelectedItem.Text.Trim() == "V")
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
                    else if (lineVoltage == "11kV" || lineVoltage == "66kV" ||
                       lineVoltage == "132kV" || lineVoltage == "220kV")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (lineVoltage == "440V")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (lineVoltage == "220V")
                    {
                        Insulation220vAbove.Visible = true;
                        Insulation440vAbove.Visible = false;
                    }


                    txtLineLength.Text = ds.Tables[0].Rows[0]["LineLength"].ToString();
                    string LineType = ds.Tables[0].Rows[0]["LineType"].ToString();
                    ddlLineType.SelectedIndex = ddlLineType.Items.IndexOf(ddlLineType.Items.FindByText(LineType));
                    //440v
                    txtRedEarthWire.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWire"].ToString();
                    txtYellowEarthWire.Text = ds.Tables[0].Rows[0]["YellowPhaseEarth"].ToString();
                    txtBlueEarthWire.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWire"].ToString();
                    txtRedYellowPhase.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhase"].ToString();
                    txtBlueYellowPhase.Text = ds.Tables[0].Rows[0]["BluePhaseYellowPhase"].ToString();
                    txtRedBluePhase.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhase"].ToString();

                    //220v
                    txtNeutralWire.Text = ds.Tables[0].Rows[0]["PhasewireNeutralwire"].ToString();
                    txtEarthWire.Text = ds.Tables[0].Rows[0]["PhasewireEarth"].ToString();
                    txtNeutralWireEarth.Text = ds.Tables[0].Rows[0]["NeutralwireEarth"].ToString();


                    if (LineType == "Overhead")
                    {
                        LineTypeOverhead.Visible = true;

                        ddlNmbrOfCircuit.SelectedItem.Text = ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
                        string ConductorType = ds.Tables[0].Rows[0]["Conductortype"].ToString();

                        ddlConductorType.SelectedIndex = ddlConductorType.Items.IndexOf(ddlConductorType.Items.FindByText(ConductorType));
                        if (ddlConductorType.SelectedItem.Text == "Bare")
                        {
                            OverheadBare.Visible = true;
                            OverheadCable.Visible = false;
                            txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
                            txtConductorSize.Text = ds.Tables[0].Rows[0]["ConductorSize"].ToString();
                            txtGroundWireSize.Text = ds.Tables[0].Rows[0]["GroundWireSize"].ToString();
                            txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRailwayCrossing"].ToString();
                            txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRoadCrossing"].ToString();
                            txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["NmbrofRiverCanalCrossing"].ToString();
                            txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["NmbrofPowerLineCrossing"].ToString();
                        }
                        else
                        {
                            OverheadBare.Visible = false;
                            OverheadCable.Visible = true;
                            txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                            txtCableSize1.Text = ds.Tables[0].Rows[0]["CableSize"].ToString();
                            txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["RailwayCrossingNoForOC"].ToString();
                            txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["RoadCrossingNoForOC"].ToString();
                            txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["RiverCanalCrossingNoForOC"].ToString();
                            txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["PowerLineCrossingNoForOc"].ToString();
                        }

                    }
                    else if (LineType == "Underground")
                    {
                        LineTypeUnderground.Visible = true;

                        string cableType = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                        ddlCableType.SelectedIndex = ddlCableType.Items.IndexOf(ddlCableType.Items.FindByText(cableType));
                        if (cableType == "Other")
                        {
                            OtherCable.Visible = true;
                            txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                        }
                        txtCableSize.Text = ds.Tables[0].Rows[0]["SizeofCable"].ToString();

                        string cablelaidIn = ds.Tables[0].Rows[0]["Cablelaidin"].ToString();
                        ddlCableLaid.SelectedIndex = ddlCableLaid.Items.IndexOf(ddlCableLaid.Items.FindByText(cablelaidIn));
                    }

                    string NoOfEarthing = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
                    ddlEarthing();
                    ddlNoOfEarthing.SelectedIndex = ddlNoOfEarthing.Items.IndexOf(ddlNoOfEarthing.Items.FindByText(NoOfEarthing));
                    if (NoOfEarthing != "" && NoOfEarthing != null)
                    {
                        Earthing.Visible = true;
                        LineEarthingdiv.Visible = true;

                        if (NoOfEarthing == "1")
                        {
                            Earthingtype1.Visible = true;
                        }
                        else if (NoOfEarthing == "2")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                        }
                        else if (NoOfEarthing == "3")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                        }
                        else if (NoOfEarthing == "4")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                        }
                        else if (NoOfEarthing == "5")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                        }
                        else if (NoOfEarthing == "6")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                        }
                        else if (NoOfEarthing == "7")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                        }
                        else if (NoOfEarthing == "8")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                        }
                        else if (NoOfEarthing == "9")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;

                        }
                        else if (NoOfEarthing == "10")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;

                        }
                        else if (NoOfEarthing == "11")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                        }
                        else if (NoOfEarthing == "12")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                        }
                        else if (NoOfEarthing == "13")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;

                        }
                        else if (NoOfEarthing == "14")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;
                            Earthingtype14.Visible = true;

                        }
                        else if (NoOfEarthing == "15")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;
                            Earthingtype14.Visible = true;
                            Earthingtype15.Visible = true;
                        }

                        string EarthingType1 = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                        ddlEarthingtype1.SelectedIndex = ddlEarthingtype1.Items.IndexOf(ddlEarthingtype1.Items.FindByText(EarthingType1));
                        txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();

                        string EarthingType2 = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                        ddlEarthingtype2.SelectedIndex = ddlEarthingtype2.Items.IndexOf(ddlEarthingtype2.Items.FindByText(EarthingType2));
                        txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();

                        string EarthingType3 = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                        ddlEarthingtype3.SelectedIndex = ddlEarthingtype3.Items.IndexOf(ddlEarthingtype3.Items.FindByText(EarthingType3));
                        txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();

                        string EarthingType4 = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                        ddlEarthingtype4.SelectedIndex = ddlEarthingtype4.Items.IndexOf(ddlEarthingtype4.Items.FindByText(EarthingType4));
                        txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();

                        string EarthingType5 = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                        ddlEarthingtype5.SelectedIndex = ddlEarthingtype5.Items.IndexOf(ddlEarthingtype5.Items.FindByText(EarthingType5));
                        txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();

                        string EarthingType6 = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                        ddlEarthingtype6.SelectedIndex = ddlEarthingtype6.Items.IndexOf(ddlEarthingtype6.Items.FindByText(EarthingType6));
                        txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();

                        string EarthingType7 = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                        ddlEarthingtype7.SelectedIndex = ddlEarthingtype7.Items.IndexOf(ddlEarthingtype7.Items.FindByText(EarthingType7));
                        txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();

                        string EarthingType8 = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                        ddlEarthingtype8.SelectedIndex = ddlEarthingtype8.Items.IndexOf(ddlEarthingtype8.Items.FindByText(EarthingType8));
                        txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();

                        string EarthingType9 = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                        ddlEarthingtype9.SelectedIndex = ddlEarthingtype9.Items.IndexOf(ddlEarthingtype9.Items.FindByText(EarthingType9));
                        txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();

                        string EarthingType10 = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                        ddlEarthingtype10.SelectedIndex = ddlEarthingtype10.Items.IndexOf(ddlEarthingtype10.Items.FindByText(EarthingType10));
                        txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();

                        string EarthingType11 = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                        ddlEarthingtype11.SelectedIndex = ddlEarthingtype11.Items.IndexOf(ddlEarthingtype11.Items.FindByText(EarthingType11));
                        txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();

                        string EarthingType12 = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                        ddlEarthingtype12.SelectedIndex = ddlEarthingtype12.Items.IndexOf(ddlEarthingtype12.Items.FindByText(EarthingType12));
                        txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();

                        string EarthingType13 = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                        ddlEarthingtype13.SelectedIndex = ddlEarthingtype13.Items.IndexOf(ddlEarthingtype13.Items.FindByText(EarthingType13));
                        txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();

                        string EarthingType14 = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                        ddlEarthingtype14.SelectedIndex = ddlEarthingtype14.Items.IndexOf(ddlEarthingtype14.Items.FindByText(EarthingType14));
                        txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();

                        string EarthingType15 = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                        ddlEarthingtype15.SelectedIndex = ddlEarthingtype15.Items.IndexOf(ddlEarthingtype15.Items.FindByText(EarthingType15));
                        txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();

                    }


                    if (Session["Approval"].ToString().Trim() == "Reject")
                    {

                        btnSubmit.Text = "Update";
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                        //BtnBack.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                //abc
            }
        }
        private void ddlLoadBindVoltage()
        {
            string Voltage = string.Empty;
            Voltage = Session["VoltageLevel"].ToString();
            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageForLine(Voltage);
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
            if (ddlCableType.SelectedItem.ToString() == "Other")
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
            LineTypeOverhead.Visible = false;
            LineTypeUnderground.Visible = false;
            string userInput = TxtOthervoltage.Text;
            Earthing.Visible = true;
            ddlNoOfEarthing.SelectedValue = "0";
            LineEarthingdiv.Visible = false;
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
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
                //{
                //    Insulation220vAbove.Visible = true;
                //    Insulation440vAbove.Visible = false;
                //}  
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible =true;
                //}
                //else if (ddlLineVoltage.SelectedValue == "0")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible =false;
                //}
                //else
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}

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
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
                //{
                //    Insulation220vAbove.Visible = true;
                //    Insulation440vAbove.Visible = false;
                //}
                //else if ( ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}
                //else if (ddlLineVoltage.SelectedValue == "0")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = false;
                //}
                //else
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}
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
            OverheadCable.Visible = false;
            OverheadBare.Visible = false;

            if (ddlConductorType.SelectedValue == "1")
            {

                OverheadBare.Visible = true;
                OverheadCable.Visible = false;
                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;

            }
            else if (ddlConductorType.SelectedValue == "2")
            {

                OverheadCable.Visible = true;
                OverheadBare.Visible = false;
                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;
            }
            else
            {
                OverheadBare.Visible = false;
                OverheadCable.Visible = false;

                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;
            }
        }
        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;
            Earthingtype1.Visible = false;
            Earthingtype2.Visible = false;
            Earthingtype3.Visible = false;
            Earthingtype4.Visible = false;
            Earthingtype5.Visible = false;
            Earthingtype6.Visible = false;
            Earthingtype7.Visible = false;
            Earthingtype8.Visible = false;
            Earthingtype9.Visible = false;
            Earthingtype10.Visible = false;
            Earthingtype11.Visible = false;
            Earthingtype12.Visible = false;
            Earthingtype13.Visible = false;
            Earthingtype14.Visible = false;
            Earthingtype15.Visible = false;
            Earthingtype16.Visible = false;
            Earthingtype17.Visible = false;
            Earthingtype18.Visible = false;
            Earthingtype19.Visible = false;
            Earthingtype20.Visible = false;
            Earthingtype21.Visible = false;
            Earthingtype22.Visible = false;
            Earthingtype23.Visible = false;
            Earthingtype24.Visible = false;
            Earthingtype25.Visible = false;
            Earthingtype26.Visible = false;
            Earthingtype27.Visible = false;
            Earthingtype28.Visible = false;
            Earthingtype29.Visible = false;
            Earthingtype30.Visible = false;
            Earthingtype31.Visible = false;
            Earthingtype32.Visible = false;
            Earthingtype33.Visible = false;
            Earthingtype34.Visible = false;
            Earthingtype35.Visible = false;
            Earthingtype36.Visible = false;
            Earthingtype37.Visible = false;
            Earthingtype38.Visible = false;
            Earthingtype39.Visible = false;
            Earthingtype40.Visible = false;
            Earthingtype41.Visible = false;
            Earthingtype42.Visible = false;
            Earthingtype43.Visible = false;
            Earthingtype45.Visible = false;
            Earthingtype46.Visible = false;
            Earthingtype47.Visible = false;
            Earthingtype48.Visible = false;
            Earthingtype49.Visible = false;
            Earthingtype50.Visible = false;

            if (ddlNoOfEarthing.SelectedValue.Trim() == "1")
            {
                Earthingtype1.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "2")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "3")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "4")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "5")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "6")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "7")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "8")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "9")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "10")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "11")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "12")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "13")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "14")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "15")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "16")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "17")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "18")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "19")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "20")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "21")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "22")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "23")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "24")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "25")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "26")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "27")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "28")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "29")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "30")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "31")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "32")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "33")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "34")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "35")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "36")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "37")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "38")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "39")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "40")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "41")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "42")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "43")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "44")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "45")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "46")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
                Earthingtype46.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "47")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
                Earthingtype46.Visible = true;
                Earthingtype47.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "48")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
                Earthingtype46.Visible = true;
                Earthingtype47.Visible = true;
                Earthingtype48.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "49")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
                Earthingtype46.Visible = true;
                Earthingtype47.Visible = true;
                Earthingtype48.Visible = true;
                Earthingtype49.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "50")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;
                Earthingtype14.Visible = true;
                Earthingtype15.Visible = true;
                Earthingtype16.Visible = true;
                Earthingtype17.Visible = true;
                Earthingtype18.Visible = true;
                Earthingtype19.Visible = true;
                Earthingtype20.Visible = true;
                Earthingtype21.Visible = true;
                Earthingtype22.Visible = true;
                Earthingtype23.Visible = true;
                Earthingtype24.Visible = true;
                Earthingtype25.Visible = true;
                Earthingtype26.Visible = true;
                Earthingtype27.Visible = true;
                Earthingtype28.Visible = true;
                Earthingtype29.Visible = true;
                Earthingtype30.Visible = true;
                Earthingtype31.Visible = true;
                Earthingtype32.Visible = true;
                Earthingtype33.Visible = true;
                Earthingtype34.Visible = true;
                Earthingtype35.Visible = true;
                Earthingtype36.Visible = true;
                Earthingtype37.Visible = true;
                Earthingtype38.Visible = true;
                Earthingtype39.Visible = true;
                Earthingtype40.Visible = true;
                Earthingtype41.Visible = true;
                Earthingtype42.Visible = true;
                Earthingtype43.Visible = true;
                Earthingtype44.Visible = true;
                Earthingtype45.Visible = true;
                Earthingtype46.Visible = true;
                Earthingtype47.Visible = true;
                Earthingtype48.Visible = true;
                Earthingtype49.Visible = true;
                Earthingtype50.Visible = true;
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    //if (btnSubmit.Text.Trim() == "Update")
                    //{
                    //    IdUpdate = Session["Id"].ToString();
                    //}

                    if (Declaration.Visible == true && CheckBox1.Checked == false)
                    {
                        labelVerification.Visible = true;
                    }
                    else
                    {
                        if (Check.Checked == true)
                        {

                            //string GeneratedLineId = string.Empty;
                            //if (Convert.ToString(Session["GeneratedLineId"]) == null || Convert.ToString(Session["GeneratedLineId"]) == "")
                            //{
                            //    GeneratedLineId = CEI.GenerateUniqueID();
                            //    Session["GeneratedLineId"] = LineId;
                            //}
                            //else
                            //{
                            //    GeneratedLineId = Session["GeneratedLineId"].ToString();
                            //}
                            //string TestReportId = Session["TestReportId"].ToString();
                            string IntimationId = Session["id"].ToString();
                            string CreatedBy = Session["SupervisorID"].ToString();
                            string installationNo = Session["IHID"].ToString();
                            string count = Session["NoOfInstallations"].ToString();

                            CEI.InsertLineData(LineId, count, IntimationId, ddlLineVoltage.SelectedItem.ToString(), ddlOtherVoltage.SelectedItem.ToString(), TxtOthervoltage.Text, txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
                           ddlNmbrOfCircuit.SelectedItem.ToString(), ddlConductorType.SelectedItem.ToString(), txtPoleTower.Text, txtConductorSize.Text,
                          txtGroundWireSize.Text, txtRailwayCrossingNo.Text, txtRoadCrossingNo.Text, txtRiverCanalCrossing.Text, txtPowerLineCrossing.Text,
                           ddlNoOfEarthing.SelectedItem.ToString(),
                         //  ddlEarthingtype1.SelectedItem.ToString(), txtearthingValue1.Text, ddlEarthingtype2.SelectedItem.ToString(),
                         //  txtEarthingValue2.Text, ddlEarthingtype3.SelectedItem.ToString(), txtEarthingValue3.Text, ddlEarthingtype4.SelectedItem.ToString(),
                         // txtEarthingValue4.Text, ddlEarthingtype5.SelectedItem.ToString(), txtEarthingValue5.Text, ddlEarthingtype6.SelectedItem.ToString(),
                         //txtEarthingValue6.Text, ddlEarthingtype7.SelectedItem.ToString(), txtEarthingValue7.Text, ddlEarthingtype8.SelectedItem.ToString(),
                         //txtEarthingValue8.Text, ddlEarthingtype9.SelectedItem.ToString(), txtEarthingValue9.Text, ddlEarthingtype10.SelectedItem.ToString(),
                         //txtEarthingValue10.Text, ddlEarthingtype11.SelectedItem.ToString(), txtEarthingValue11.Text, ddlEarthingtype12.SelectedItem.ToString(),
                         //txtEarthingValue12.Text, ddlEarthingtype13.SelectedItem.ToString(), txtEarthingValue13.Text, ddlEarthingtype14.SelectedItem.ToString(),
                         //txtEarthingValue14.Text, ddlEarthingtype15.SelectedItem.ToString(), txtEarthingValue15.Text, 
                         txtPoleTowerNo.Text, txtCableSize1.Text,
                         txtRailwayCrossingNmbr.Text, txtRoadCrossingNmbr.Text, txtRiverCanalCrossingNmber.Text, txtPowerLineCrossingNmbr.Text, txtRedEarthWire.Text,
                         txtYellowEarthWire.Text, txtBlueEarthWire.Text, txtRedYellowPhase.Text, txtRedBluePhase.Text, txtBlueYellowPhase.Text, txtNeutralWire.Text,
                       txtEarthWire.Text, txtNeutralWireEarth.Text, ddlCableType.SelectedItem.ToString(), txtOtherCable.Text, txtCableSize.Text, ddlCableLaid.SelectedItem.ToString(),
                       txtRedWire.Text, txtYellowWire.Text, txtBlueWire.Text, txtRedYellowWire.Text, txtRedBlueWire.Text, txtBlueYellowWire.Text,
                       txtNeutralPhaseWire.Text, txtPhaseWireEarth.Text, txtNeutralWireEarthUnderground.Text, CreatedBy, transaction);

                            CEI.UpdateInstallations(installationNo, IntimationId, transaction);

                            //int maxEarthingCount;
                            // if (int.TryParse(ddlNoOfEarthing.SelectedItem.Value, out maxEarthingCount))
                            // {

                            //     foreach (HtmlTableRow row in tbl.Rows)
                            //     {

                            //         for (int i = 1; i <= maxEarthingCount; i++)
                            //         {
                            //             DropDownList ddlEarthingType = (DropDownList)row.FindControl("ddlEarthingtype" + i);
                            //             TextBox txtEarthingValue = (TextBox)row.FindControl("txtearthingValue" + i);

                            //             if (ddlEarthingType != null && txtEarthingValue != null)
                            //             {
                            //                 string earthingType = ddlEarthingType.SelectedValue;
                            //                 string earthingValue = txtEarthingValue.Text;


                            //                 if (earthingType != "0" && !string.IsNullOrEmpty(earthingValue))
                            //                 {

                            //                     EarthingData.Add((IntimationId, i.ToString(), earthingType, earthingValue));
                            //                 }
                            //             }
                            //         }

                            //     }

                            // }
                            int maxEarthingCount;
                            if (int.TryParse(ddlNoOfEarthing.SelectedItem.Value, out maxEarthingCount))
                            {
                                bool shouldBreak = false;

                                foreach (HtmlTableRow row in tbl.Rows)
                                {
                                    if (shouldBreak) break;

                                    for (int i = 1; i <= maxEarthingCount; i++)
                                    {
                                        DropDownList ddlEarthingType = (DropDownList)row.FindControl("ddlEarthingtype" + i);
                                        TextBox txtEarthingValue = (TextBox)row.FindControl("txtearthingValue" + i);

                                        if (ddlEarthingType != null && txtEarthingValue != null)
                                        {
                                            string earthingType = ddlEarthingType.SelectedItem.ToString();
                                            string earthingValue = txtEarthingValue.Text;

                                            if (earthingType != "0" && !string.IsNullOrEmpty(earthingValue))
                                            {
                                                EarthingData.Add((IntimationId, i.ToString(), earthingType, earthingValue));
                                            }
                                        }


                                        if (i == maxEarthingCount)
                                        {
                                            shouldBreak = true;
                                            break;
                                        }
                                    }
                                }
                            }


                            //string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                            //using (SqlConnection connection = new SqlConnection(connectionString))
                            //{
                            //    connection.Open();

                            foreach (var file in EarthingData)
                            {
                                string query = "sp_InsertEarthingData";

                                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@IntimationId", file.IntimationId);
                                    command.Parameters.AddWithValue("@RowNumber", file.RowNumber);
                                    command.Parameters.AddWithValue("@EarthingType", file.EarthingType);
                                    command.Parameters.AddWithValue("@Valueinohms", file.Valueinohms);
                                    command.ExecuteNonQuery();
                                }
                                //}
                            }
                            transaction.Commit();

                            //Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                            //Response.Redirect("/Supervisor/InstallationDetails.aspx", false);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('You have to check the declaration first !!!')", true);
                        }
                    }



                }
                //catch (Exception ex)
                //{

                //    DataSaved.Visible = false;
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                //    return;
                //}
                catch (Exception ex)
                {
                    // Rollback transaction in case of an error
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
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
            OtherCable.Visible = false;
            Earthing.Visible = false;
            Insulation440vAbove.Visible = false;
            Insulation220vAbove.Visible = false;
            LineTypeUnderground.Visible = false;
            UndergroundInsulation440vAbove.Visible = false;
            UndergroundInsulation220vAbove.Visible = false;
            OtherCable.Visible = false;
            LineTypeOverhead.Visible = false;
            OverheadBare.Visible = false;
            OverheadCable.Visible = false;
            Earthing.Visible = false;
            LineEarthingdiv.Visible = false;
            Insulation440vAbove.Visible = false;
            Insulation220vAbove.Visible = false;
            LineTypeUnderground.Visible = false;
            UndergroundInsulation440vAbove.Visible = false;
            UndergroundInsulation220vAbove.Visible = false;
        }

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            divOtherVoltages.Visible = false;
            OtherVoltage.Visible = false;

            if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
            {
                Insulation220vAbove.Visible = true;
                Insulation440vAbove.Visible = false;
            }
            else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = true;
            }
            else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
            {
                divOtherVoltages.Visible = true;
                OtherVoltage.Visible = true;

                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;

            }
            else if (ddlLineVoltage.SelectedValue == "0")
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = false;
                divOtherVoltages.Visible = false;
                OtherVoltage.Visible = false;
            }
            else
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = true;
                divOtherVoltages.Visible = false;
                OtherVoltage.Visible = false;
            }

        }

        protected void ddlCableType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlCableType.SelectedItem.ToString().Trim() == "Other")
            {
                OtherCable.Visible = true;
            }
            else
            {
                OtherCable.Visible = false;
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["OTP"]) == null || Convert.ToString(Session["OTP"]) == "")
                {
                    OTP.Visible = true;
                    string id = Session["SupervisorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.GetSuperVisorContact(id);
                    string Contact = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                    string mobilenumber = Contact.Trim(); ;
                    Session["OTP"] = CEI.ValidateOTP(mobilenumber);
                }
                else
                {
                    if (Session["OTP"].ToString() == txtOTP.Text.Trim())
                    {
                        btnSubmit.Attributes.Remove("disabled");
                        btnVerify.Attributes.Add("disabled", "true");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('InvalidOTP Please Try Again')", true);

                    }

                }
            }
            catch
            {

            }


        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (Session["TestReportHistory"] == null)
            {
                if (Session["TypeOfInspection"]?.ToString() == "Periodic")
                {
                    Response.Redirect("/Supervisor/IntimationDataForPeriodic.aspx", false);
                }
                else
                {
                    Response.Redirect("/Supervisor/InstallationDetails.aspx", false);
                }
            }
            else
            {
                // Response.Redirect("/Admin/TestHistoryReport.aspx", false);

            }
        }
    }
}