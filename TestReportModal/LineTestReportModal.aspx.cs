using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class LineTestReportModal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ContractorID"] != null)
                {
                    GetDetailswithId();
                }
            }


        }

        public void GetDetailswithId()
        {
            try
            {
                ID = Session["LineID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.LineDataWithId(ID);
                txtLineVoltage.Text = ds.Tables[0].Rows[0]["LineVoltage"].ToString();
                if (txtLineVoltage.Text == "Other")
                {
                    divOtherVoltages.Visible = true;
                    OtherVoltage.Visible = true;
                }
                txtVotalgeType.Text = ds.Tables[0].Rows[0]["OtherVoltageType"].ToString();
                TxtOthervoltage.Text = ds.Tables[0].Rows[0]["OtherVoltage"].ToString();
                txtLineLength.Text = ds.Tables[0].Rows[0]["LineLength"].ToString();
                txtLineType.Text = ds.Tables[0].Rows[0]["LineType"].ToString();
                if (txtLineType.Text.Trim() == "Overhead")
                {
                    Earthing.Visible = true;
                    LineEarthingdiv.Visible = true;
                    LineTypeOverhead.Visible = true;
                    LineTypeUnderground.Visible = false;
                }
                else if (txtLineType.Text.Trim() == "Underground")
                {
                    Earthing.Visible = true;
                    LineEarthingdiv.Visible = true;
                    LineTypeUnderground.Visible = true;
                    LineTypeOverhead.Visible = false;
                }
                if (txtVotalgeType.Text =="V") {
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
                else if (txtVotalgeType.Text == "KV")
                {
                    Insulation440vAbove.Visible = true;
                    Insulation220vAbove.Visible = false;
                }
                else
                {
                    Insulation440vAbove.Visible = false;
                    Insulation220vAbove.Visible = false;
                }
                txtCircuit.Text = ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
                txtConductorType.Text = ds.Tables[0].Rows[0]["Conductortype"].ToString();
                if (txtConductorType.Text.Trim() == "Bare")
                {

                    OverheadBare.Visible = true;
                    OverheadCable.Visible = false;

                }
                else if (txtConductorType.Text.Trim() == "Cable")
                {

                    OverheadCable.Visible = true;
                    OverheadBare.Visible = false;
                }
                else
                {
                    OverheadBare.Visible = false;
                    OverheadCable.Visible = false;
                }
                txtPoleTower.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
                txtConductorSize.Text = ds.Tables[0].Rows[0]["ConductorSize"].ToString();
                txtGroundWireSize.Text = ds.Tables[0].Rows[0]["GroundWireSize"].ToString();
                txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRailwayCrossing"].ToString();
                txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRoadCrossing"].ToString();
                txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["NmbrofRiverCanalCrossing"].ToString();
                txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["NmbrofPowerLineCrossing"].ToString();
                txtEarthing.Text = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
                if (txtEarthing.Text == "1")
                {
                    Earthingtype1.Visible = true;
                }
                else if (txtEarthing.Text == "2")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "3")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");
                    Earthingtype3.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "4")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");
                    Earthingtype3.Style.Add("display", "table-row");
                    Earthingtype4.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "5")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");
                    Earthingtype3.Style.Add("display", "table-row");
                    Earthingtype4.Style.Add("display", "table-row");
                    Earthingtype5.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "6")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");
                    Earthingtype3.Style.Add("display", "table-row");
                    Earthingtype4.Style.Add("display", "table-row");
                    Earthingtype5.Style.Add("display", "table-row");
                    Earthingtype6.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "7")
                {
                    Earthingtype1.Visible = true;
                    Earthingtype2.Style.Add("display", "table-row");
                    Earthingtype3.Style.Add("display", "table-row");
                    Earthingtype4.Style.Add("display", "table-row");
                    Earthingtype5.Style.Add("display", "table-row");
                    Earthingtype6.Style.Add("display", "table-row");
                    Earthingtype7.Style.Add("display", "table-row");

                }
                else if (txtEarthing.Text == "8")
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
                else if (txtEarthing.Text == "9")
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
                else if (txtEarthing.Text == "10")
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
                else if (txtEarthing.Text == "11")
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
                else if (txtEarthing.Text == "12")
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
                else if (txtEarthing.Text == "13")
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
                else if (txtEarthing.Text == "14")
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
                else if (txtEarthing.Text == "15")
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
                txtEarthingType1.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();
                txtEarthingType2.Text = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
                txtEarthingType3.Text = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
                txtEarthingType4.Text = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
                txtEarthingType5.Text = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
                txtEarthingType6.Text = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
                txtEarthingType7.Text = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
                txtEarthingType8.Text = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();
                txtEarthingType9.Text = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
                txtEarthingType10.Text = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
                txtEarthingType11.Text = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();
                txtEarthingType12.Text = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();
                txtEarthingType13.Text = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();
                txtEarthingType14.Text = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();
                txtEarthingType15.Text = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();
                txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                txtCableSize1.Text = ds.Tables[0].Rows[0]["CableSize"].ToString();
                txtRailwayCrossingNmbr.Text = ds.Tables[0].Rows[0]["RailwayCrossingNoForOC"].ToString();
                txtRoadCrossingNmbr.Text = ds.Tables[0].Rows[0]["RoadCrossingNoForOC"].ToString();
                txtRiverCanalCrossingNmber.Text = ds.Tables[0].Rows[0]["RiverCanalCrossingNoForOC"].ToString();
                txtPowerLineCrossingNmbr.Text = ds.Tables[0].Rows[0]["PowerLineCrossingNoForOc"].ToString();
                txtRedEarthWire.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWire"].ToString();
                txtYellowEarthWire.Text = ds.Tables[0].Rows[0]["YellowPhaseEarth"].ToString();
                txtBlueEarthWire.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWire"].ToString();
                txtRedYellowPhase.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhase"].ToString();
                txtBlueYellowPhase.Text = ds.Tables[0].Rows[0]["BluePhaseYellowPhase"].ToString();
                txtRedBluePhase.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhase"].ToString();
                txtNeutralWire.Text = ds.Tables[0].Rows[0]["PhasewireNeutralwire"].ToString();
                txtEarthWire.Text = ds.Tables[0].Rows[0]["PhasewireEarth"].ToString();
                txtNeutralWireEarth.Text = ds.Tables[0].Rows[0]["NeutralwireEarth"].ToString();
                txtCableType.Text = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                txtCableSize.Text = ds.Tables[0].Rows[0]["SizeofCable"].ToString();
                txtCableLaid.Text = ds.Tables[0].Rows[0]["Cablelaidin"].ToString();
            }
            catch
            {

            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Rejection.Visible = true;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string id = Session["LineID"].ToString();
            CEI.UpdateLineData(id, ddlType.SelectedItem.ToString(), txtRejection.Text);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlType.SelectedValue == "2")
            {
                Rejection.Visible =true;
            }
            else
            {
                Rejection.Visible = false;
            }
        }
    }
}