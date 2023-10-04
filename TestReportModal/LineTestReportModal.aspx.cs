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
                //if (Session["ContractorID"] != null)
                //{
                //    GetDetailswithId();
                //}
            }


        }

        public void GetDetailswithId()
        {
            ID = Session["LineID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.LineDataWithId(ID);
            txtLineVoltage.Text= ds.Tables[0].Rows[0]["LineVoltage"].ToString();
            txtLineVoltage.Text = ds.Tables[0].Rows[0]["LineVoltage"].ToString();
            txtVotalgeType.Text= ds.Tables[0].Rows[0]["OtherVoltageType"].ToString();
            TxtOthervoltage.Text = ds.Tables[0].Rows[0]["OtherVoltage"].ToString();
            txtLineLength.Text= ds.Tables[0].Rows[0]["LineLength"].ToString();
            txtLineType.Text = ds.Tables[0].Rows[0]["LineType"].ToString();
            txtCircuit.Text= ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
            txtConductorType.Text = ds.Tables[0].Rows[0]["Conductortype"].ToString();
            txtPoleTower.Text= ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
            txtConductorSize.Text = ds.Tables[0].Rows[0]["ConductorSize"].ToString();
            txtGroundWireSize.Text= ds.Tables[0].Rows[0]["GroundWireSize"].ToString();
            txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRailwayCrossing"].ToString();

            txtRoadCrossingNo.Text= ds.Tables[0].Rows[0]["NmbrofRoadCrossing"].ToString();
            txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["NmbrofRiverCanalCrossing"].ToString();
            txtPowerLineCrossing.Text= ds.Tables[0].Rows[0]["NmbrofPowerLineCrossing"].ToString();
            txtEarthing.Text = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
            txtEarthingType1.Text= ds.Tables[0].Rows[0]["EarthingType1"].ToString();
            txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();
            txtEarthingType2.Text= ds.Tables[0].Rows[0]["EarthingType2"].ToString();
            txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
            txtEarthingType3.Text= ds.Tables[0].Rows[0]["EarthingType3"].ToString();
            txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
            txtEarthingType4.Text= ds.Tables[0].Rows[0]["EarthingType4"].ToString();
            txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
            txtEarthingType5.Text= ds.Tables[0].Rows[0]["EarthingType5"].ToString();
            txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
            txtEarthingType6.Text= ds.Tables[0].Rows[0]["EarthingType6"].ToString();
            txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
            txtEarthingType7.Text= ds.Tables[0].Rows[0]["EarthingType7"].ToString();
            txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
            txtEarthingType8.Text= ds.Tables[0].Rows[0]["EarthingType8"].ToString();
            txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();
            txtEarthingType9.Text= ds.Tables[0].Rows[0]["EarthingType9"].ToString();
            txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
            txtEarthingType10.Text= ds.Tables[0].Rows[0]["EarthingType10"].ToString();
            txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
            txtEarthingType11.Text= ds.Tables[0].Rows[0]["EarthingType11"].ToString();
            txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();
            txtEarthingType12.Text= ds.Tables[0].Rows[0]["EarthingType12"].ToString();
            txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();
            txtEarthingType13.Text= ds.Tables[0].Rows[0]["EarthingType13"].ToString();
            txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();
            txtEarthingType14.Text= ds.Tables[0].Rows[0]["EarthingType14"].ToString();
            txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();
            txtEarthingType15.Text= ds.Tables[0].Rows[0]["EarthingType15"].ToString();
            txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();
            txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
            txtCableSize1.Text = ds.Tables[0].Rows[0]["CableSize"].ToString();
            txtRailwayCrossingNmbr.Text = ds.Tables[0].Rows[0]["RailwayCrossingNoForOC"].ToString();
            txtRoadCrossingNmbr.Text = ds.Tables[0].Rows[0]["RoadCrossingNoForOC"].ToString();

            txtRiverCanalCrossingNmber.Text = ds.Tables[0].Rows[0]["RiverCanalCrossingNoForOC"].ToString();
            txtPowerLineCrossingNmbr.Text = ds.Tables[0].Rows[0]["PowerLineCrossingNoForOc"].ToString();
        }
    }
}