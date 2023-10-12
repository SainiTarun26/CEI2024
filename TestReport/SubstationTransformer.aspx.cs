using CEI_PRoject;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.TestReport
{
    public partial class SubstationTransformer : System.Web.UI.Page
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
                ddlEarthingSubstation();
                SessionValue();
                PageWorking();
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
        protected void ddltransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltransformerType.SelectedValue == "1")
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = true;
                BDV.Visible = true;
            }
            else
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = false;
                BDV.Visible = false;
            }
            if (ddltransformerCapacity.SelectedValue == "1")
            {
                if (int.TryParse(txtTransformerCapacity.Text, out int value))
                {
                    if (value >= 1000)
                    {
                        TypeOfHTBreaker.Visible = true;
                        ddlBreaker.Visible= true;
                        ddlHTType.Visible = false;
                    }
                    else
                    {
                        ddlBreaker.Visible = false;
                        ddlHTType.Visible = true;
                        TypeOfHTBreaker.Visible = false;
                    }

                }
            }
            else
            {
                ddlBreaker.Visible = false;
                ddlHTType.Visible = true;
            }
        }
        protected void ddlHTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHTType.SelectedValue == "3")
            {
                TypeOfHTBreaker.Visible = true;
            }
            else
            {
                TypeOfHTBreaker.Visible = false;
            }
        }
        protected void ddlEarthingsubstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubstationEarthingDiv.Visible = true;

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
        protected void BtnSubmitSubstation_Click(object sender, EventArgs e)
        {
            if (ddlLineType.SelectedValue == "0")
            {
                ddlLineTypeError.Visible = true;
            }
            else if (ddlOtherVoltage.SelectedValue == "0")
            {
                ddlOtherVoltageError.Visible = true;
            }
            else if (TxtOthervoltage.Text == "")
            {
                TxtOthervoltageError.Visible = true;
            }
            else if (txtLineLength.Text == "")
            {
                txtLineLengthError.Visible = true;
            }
            else if (ddlLineType.SelectedValue == "")
            {
                ddlLineTypeError.Visible = true;
            }
            // else if (LineTypeOverhead.Visible == true)


            if (ddlNmbrOfCircuit.SelectedValue == "0")
            {
                ddlNmbrOfCircuitError.Visible = true;
            }
            if (ddlConductorType.SelectedValue == "0")
            {
                ddlConductorTypeError.Visible = true;
            }
            if (txtPoleTower.Text == "")
            {
                txtPoleTowerError.Visible = true;
            }
            if (txtConductorSize.Text == "")
            {
                txtConductorSizeError.Visible = true;
            }
            if (txtGroundWireSize.Text == "")
            {
                txtGroundWireSizeError.Visible = true;
            }

            if (txtRailwayCrossingNo.Text == "")
            {
                txtRailwayCrossingNoError.Visible = true;
            }
            if (txtRoadCrossingNo.Text == "")
            {
                txtRoadCrossingNoError.Visible = true;
            }
            if (txtRiverCanalCrossing.Text == "")
            {
                txtRiverCanalCrossingError.Visible = true;
            }
            if (txtPowerLineCrossing.Text == "")
            {
                txtPowerLineCrossingError.Visible = true;
            }


            // else if (OverheadCable.Visible == true)
            //{
            if (txtPoleTowerNo.Text == "")
            {
                txtPoleTowerNoError.Visible = true;
            }
            if (txtCableSize1.Text == "")
            {
                txtCableSize1Error.Visible = true;
            }
            if (txtRailwayCrossingNmbr.Text == "")
            {
                txtRailwayCrossingNmbrError.Visible = true;
            }
            if (txtRoadCrossingNmbr.Text == "")
            {
                txtRoadCrossingNmbrError.Visible = true;
            }
            if (txtRiverCanalCrossingNmber.Text == "")
            {
                txtRiverCanalCrossingNmberError.Visible = true;
            }
            if (txtPowerLineCrossingNmbr.Text == "")
            {
                txtPowerLineCrossingNmbrError.Visible = true;
            }


            //  else if (Earthing.Visible == true)
            // {             
            if (ddlNoOfEarthing.SelectedValue == "0")
            {
                ddlNoOfEarthingError.Visible = true;
            }
            if (ddlEarthingtype1.SelectedValue == "0" && Earthingtype1.Visible == true)
            {
                ddlEarthingtype1Error.Visible = true;
            }
            if (txtearthingValue1.Text == "")
            {
                txtearthingValue1Error.Visible = true;
            }
            if (ddlEarthingtype2.SelectedValue == "0" && Earthingtype2.Visible == true)
            {
                ddlEarthingtype2Error.Visible = true;
            }
            if (txtEarthingValue2.Text == "")
            {
                txtEarthingValue2Error.Visible = true;
            }
            if (ddlEarthingtype3.SelectedValue == "0" && Earthingtype3.Visible == true)
            {
                ddlEarthingtype3Error.Visible = true;
                if (txtEarthingValue3.Text == "")
                {
                    txtEarthingValue3Error.Visible = true;
                }
                if (ddlEarthingtype4.SelectedValue == "0" && Earthingtype4.Visible == true)
                {
                    ddlEarthingtype4Error.Visible = true;
                }
                if (txtEarthingValue4.Text == "")
                {
                    txtEarthingValue4Error.Visible = true;
                }
                if (ddlEarthingtype5.SelectedValue == "0" && Earthingtype5.Visible == true)
                {
                    ddlEarthingtype5Error.Visible = true;
                }
                if (txtEarthingValue5.Text == "")
                {
                    txtEarthingValue5Error.Visible = true;
                }
                if (ddlEarthingtype6.SelectedValue == "0" && Earthingtype6.Visible == true)
                {
                    ddlEarthingtype6Error.Visible = true;
                }
                if (txtEarthingValue6.Text == "")
                {
                    txtEarthingValue6Error.Visible = true;
                }
                if (ddlEarthingtype7.SelectedValue == "0" && Earthingtype7.Visible == true)
                {
                    ddlEarthingtype7Error.Visible = true;
                }
                if (txtEarthingValue7.Text == "")
                {
                    txtEarthingValue7Error.Visible = true;
                }
                if (ddlEarthingtype8.SelectedValue == "0" && Earthingtype8.Visible == true)
                {
                    ddlEarthingtype8Error.Visible = true;
                }
                if (txtEarthingValue8.Text == "")
                {
                    txtEarthingValue8Error.Visible = true;
                }
                if (ddlEarthingtype9.SelectedValue == "0" && Earthingtype9.Visible == true)
                {
                    ddlEarthingtype9Error.Visible = true;
                }
                if (txtEarthingValue9.Text == "")
                {
                    txtEarthingValue9Error.Visible = true;
                }
                if (ddlEarthingtype10.SelectedValue == "0" && Earthingtype10.Visible == true)
                {
                    ddlEarthingtype10Error.Visible = true;
                }
                if (txtEarthingValue10.Text == "")
                {
                    txtEarthingValue10Error.Visible = true;
                }
                if (ddlEarthingtype11.SelectedValue == "0" && Earthingtype11.Visible == true)
                {
                    ddlEarthingtype11Error.Visible = true;
                }
                if (txtEarthingValue11.Text == "")
                {
                    txtEarthingValue11Error.Visible = true;
                }
                if (ddlEarthingtype12.SelectedValue == "0" && Earthingtype12.Visible == true)
                {
                    ddlEarthingtype12Error.Visible = true;
                }
                if (txtEarthingValue12.Text == "")
                {
                    txtEarthingValue12Error.Visible = true;
                }
                if (ddlEarthingtype13.SelectedValue == "0" && Earthingtype13.Visible == true)
                {
                    ddlEarthingtype13Error.Visible = true;

                }

                //if (txtEarthingValue13.Text == "")
                //{
                //    txtEarthingValue13Error.Visible = true;
                //}
                if (ddlEarthingtype14.SelectedValue == "0" && Earthingtype14.Visible == true)
                {
                    ddlEarthingtype14Error.Visible = true;
                }
                if (txtEarthingValue14.Text == "")
                {
                    txtEarthingValue14Error.Visible = true;
                }
                if (ddlEarthingtype15.SelectedValue == "0" && Earthingtype15.Visible == true)
                {
                    ddlEarthingtype15Error.Visible = true;
                }
                if (txtEarthingValue15.Text == "")
                {
                    txtEarthingValue15Error.Visible = true;
                }

            }
            else
            {

                try
                {

               
                if (Declaration.Visible == true && CheckBox2.Checked == false)
                {
                    
                        labelVerification.Visible = true;
                    
                }

                else
                {
                    string SubstationId = string.Empty;
                    if (Convert.ToString(Session["SubstationId"]) == null || Convert.ToString(Session["SubstationId"]) == "")
                    {
                        SubstationId = CEI.GenerateUniqueSubstation();
                        Session["SubstationId"] = SubstationId;

                    }
                    else
                    {

                        SubstationId = Session["SubstationId"].ToString();
                    }
                    string TestReportId = Session["TestReportId"].ToString();
                    string IntimationId = Session["id"].ToString();
                    string CreatedBy = Session["AdminID"].ToString();
                    CEI.InsertSubstationData(SubstationId, TestReportId, IntimationId, txtTransformerSerialNumber.Text, ddltransformerCapacity.SelectedItem.ToString(), txtTransformerCapacity.Text, ddltransformerType.SelectedItem.ToString(),
                       txtPrimaryVoltage.Text, txtSecondryVoltage.Text, txtOilCapacity.Text, txtOilBDV.Text, txtHTsideInsulation.Text, txtLTSideInsulation.Text,
                       txtLowestValue.Text, txtLightningArrestor.Text, ddlHTType.SelectedItem.ToString(), ddlEarthingsubstation.SelectedItem.ToString(),
                       ddlSubstationEarthing1.SelectedItem.ToString(), txtSubstationEarthing1.Text, ddlUsedFor1.SelectedItem.ToString(), txtOtherEarthing1.Text, ddlSubstationEarthing2.SelectedItem.ToString(),
                       txtSubstationEarthing2.Text, ddlUsedFor2.SelectedItem.ToString(), txtOtherEarthing2.Text, ddlSubstationEarthing3.SelectedItem.ToString(), txtSubstationEarthing3.Text, ddlUsedFor3.SelectedItem.ToString(), txtOtherEarthing3.Text,
                       ddlSubstationEarthing4.SelectedItem.ToString(), txtSubstationEarthing4.Text, ddlUsedFor4.SelectedItem.ToString(), txtOtherEarthing4.Text, ddlSubstationEarthing5.SelectedItem.ToString(), txtSubstationEarthing5.Text,
                       ddlUsedFor5.SelectedItem.ToString(), txtOtherEarthing5.Text, ddlSubstationEarthing6.SelectedItem.ToString(), txtSubstationEarthing6.Text, ddlUsedFor6.SelectedItem.ToString(), txtOtherEarthing6.Text,
                       ddlSubstationEarthing7.SelectedItem.ToString(), txtSubstationEarthing7.Text, ddlUsedFor7.SelectedItem.ToString(), txtOtherEarthing7.Text, ddlSubstationEarthing8.SelectedItem.ToString(),
                       txtSubstationEarthing8.Text, ddlUsedFor8.SelectedItem.ToString(), txtOtherEarthing8.Text, ddlSubstationEarthing9.SelectedItem.ToString(), txtSubstationEarthing9.Text, ddlUsedFor9.SelectedItem.ToString(), txtOtherEarthing9.Text,
                       ddlSubstationEarthing10.SelectedItem.ToString(), txtSubstationEarthing10.Text, ddlUsedFor10.SelectedItem.ToString(), txtOtherEarthing10.Text, ddlSubstationEarthing11.SelectedItem.ToString(),
                       txtSubstationEarthing11.Text, ddlUsedFor11.SelectedItem.ToString(), txtOtherEarthing11.Text, ddlSubstationEarthing12.SelectedItem.ToString(), txtSubstationEarthing12.Text,
                       ddlUsedFor12.SelectedItem.ToString(), txtOtherEarthing12.Text, ddlSubstationEarthing13.SelectedItem.ToString(), txtSubstationEarthing13.Text, ddlUsedFor13.SelectedItem.ToString(), txtOtherEarthing13.Text,
                       ddlSubstationEarthing14.SelectedItem.ToString(), txtSubstationEarthing14.Text, ddlUsedFor14.SelectedItem.ToString(), txtOtherEarthing14.Text, ddlSubstationEarthing15.SelectedItem.ToString(),
                       txtSubstationEarthing15.Text, ddlUsedFor15.SelectedItem.ToString(), txtOtherEarthing15.Text, ddlSubstationEarthing16.SelectedItem.ToString(), txtSubstationEarthing16.Text, ddlUsedFor16.SelectedItem.ToString(), txtOtherEarthing16.Text,
                       ddlSubstationEarthing17.SelectedItem.ToString(), txtSubstationEarthing17.Text, ddlUsedFor17.SelectedItem.ToString(), txtOtherEarthing17.Text, ddlSubstationEarthing18.SelectedItem.ToString(), txtSubstationEarthing18.Text,
                       ddlUsedFor18.SelectedItem.ToString(), txtOtherEarthing18.Text, ddlSubstationEarthing19.SelectedItem.ToString(),
                       txtSubstationEarthing19.Text, ddlUsedFor19.SelectedItem.ToString(), txtOtherEarthing19.Text, ddlSubstationEarthing20.SelectedItem.ToString(),
                       txtSubstationEarthing20.Text, ddlUsedFor20.SelectedItem.ToString(), txtOtherEarthing20.Text, txtBreakerCapacity.Text, ddlLTProtection.SelectedItem.ToString(), txtIndividualCapacity.Text,
                       txtLTBreakerCapacity.Text, txtLoadBreakingCapacity.Text, txtSealLevelPlinth.Text, CreatedBy);

                    Session["Page"] = Convert.ToInt32(Session["Page"]) + 1;
                    Reset();
                    DataSaved.Visible = true;
                    labelVerification.Visible = false;
                    PageWorking();
                    int currentValue = Convert.ToInt32(Session["Page"]);
                    if (currentValue == Convert.ToInt32(sessionValue))
                    {
                        Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
                        BtnSubmitSubstation.Visible = false;
                        Session["SubmittedValue"] = sessionValue;
                        divtrasformer.Visible = false;
                        Session["SubstationId"] = "";
                        //NextSessionValueAndName();
                        if (nextSessionName == "Line")
                        {
                            Response.Redirect("LineTestReport.aspx", false);
                        }
                        else if (nextSessionName == "Generating Station")
                        {
                            Response.Redirect("GeneratingSetTestReport.aspx", false);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Form Submitted Successfully')", true);

                        }
                    }
                }
            }
            catch (Exception)
            {

                DataSaved.Visible = false;
            }
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
            string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };

            for (int i = 0; i < installationNumbers.Length; i++)
            {
                sessionName = Session["installationType" + (i + 1)] as string;
                sessionValue = Session[installationNumbers[i]] as string;

                if (!string.IsNullOrEmpty(sessionName))
                {
                    if (i < installationNumbers.Length - 1) // Check if there are more sessions left
                    {
                        nextSessionName = Session["installationType" + (i + 2)] as string;
                        nextSessionValue = Session[installationNumbers[i + 1]] as string;
                        if (nextSessionName == "Line")
                        {
                            Response.Redirect("LineTestReport.aspx");
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
                    else
                    {
                        nextSessionName = "";
                        nextSessionValue = "";
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
                    BtnSubmitSubstation.Text = "Submit";
                }
                else
                {
                    Declaration.Visible = false;
                    BtnSubmitSubstation.Text = "Next";
                }
            }
            catch { }

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == false)
            {
                labelVerification.Visible = true;
            }
            else
            {
                labelVerification.Visible = false;
            }
        }

        public void Reset()
        {
            txtTransformerSerialNumber.Text = "";
            txtTransformerCapacity.Text = "";
            ddltransformerType.SelectedValue = "0";
            txtPrimaryVoltage.Text = "";
            txtSecondryVoltage.Text = ""; txtOilCapacity.Text = ""; txtOilBDV.Text = ""; txtHTsideInsulation.Text = ""; txtLTSideInsulation.Text = "";
            txtLowestValue.Text = ""; txtLightningArrestor.Text = ""; ddlHTType.SelectedValue = "0"; ddlEarthingsubstation.SelectedValue = "0"; txtOtherEarthing1.Text = "";
            txtOtherEarthing2.Text = ""; txtOtherEarthing3.Text = ""; txtOtherEarthing4.Text = ""; txtOtherEarthing5.Text = ""; txtOtherEarthing6.Text = ""; txtOtherEarthing7.Text = "";
            txtOtherEarthing8.Text = ""; txtOtherEarthing9.Text = ""; txtOtherEarthing10.Text = ""; txtOtherEarthing11.Text = ""; txtOtherEarthing12.Text = ""; txtOtherEarthing13.Text = "";
            txtOtherEarthing14.Text = ""; txtOtherEarthing15.Text = ""; txtOtherEarthing16.Text = ""; txtOtherEarthing17.Text = ""; txtOtherEarthing18.Text = "";
            txtOtherEarthing19.Text = ""; txtOtherEarthing20.Text = "";
            ddlSubstationEarthing1.SelectedValue = "0"; txtSubstationEarthing1.Text = ""; ddlUsedFor1.SelectedValue = "0"; ddlSubstationEarthing2.SelectedValue = "0";
            txtSubstationEarthing2.Text = ""; ddlUsedFor2.SelectedValue = "0"; ddlSubstationEarthing3.SelectedValue = "0"; txtSubstationEarthing3.Text = ""; ddlUsedFor3.SelectedValue = "0";
            ddlSubstationEarthing4.SelectedValue = "0"; txtSubstationEarthing4.Text = ""; ddlUsedFor4.SelectedValue = "0"; ddlSubstationEarthing5.SelectedValue = "0"; txtSubstationEarthing5.Text = "";
            ddlUsedFor5.SelectedValue = "0"; ddlSubstationEarthing6.SelectedValue = "0"; txtSubstationEarthing6.Text = ""; ddlUsedFor6.SelectedValue = "0";
            ddlSubstationEarthing7.SelectedValue = "0"; txtSubstationEarthing7.Text = ""; ddlUsedFor7.SelectedValue = "0"; ddlSubstationEarthing8.SelectedValue = "0";
            txtSubstationEarthing8.Text = ""; ddlUsedFor8.SelectedValue = "0"; ddlSubstationEarthing9.SelectedValue = "0"; txtSubstationEarthing9.Text = ""; ddlUsedFor9.SelectedValue = "0";
            ddlSubstationEarthing10.SelectedValue = "0"; txtSubstationEarthing10.Text = ""; ddlUsedFor10.SelectedValue = "0"; ddlSubstationEarthing11.SelectedValue = "0";
            txtSubstationEarthing11.Text = ""; ddlUsedFor11.SelectedValue = "0"; ddlSubstationEarthing12.SelectedValue = "0"; txtSubstationEarthing12.Text = "";
            ddlUsedFor12.SelectedValue = "0"; ddlSubstationEarthing13.SelectedValue = "0"; txtSubstationEarthing13.Text = ""; ddlUsedFor13.SelectedValue = "0";
            ddlSubstationEarthing14.SelectedValue = "0"; txtSubstationEarthing14.Text = ""; ddlUsedFor14.SelectedValue = "0"; ddlSubstationEarthing15.SelectedValue = "0";
            txtSubstationEarthing15.Text = ""; ddlUsedFor15.SelectedValue = "0"; ddlSubstationEarthing16.SelectedValue = "0"; txtSubstationEarthing16.Text = ""; ddlUsedFor16.SelectedValue = "0";
            ddlSubstationEarthing17.SelectedValue = "0"; txtSubstationEarthing17.Text = ""; ddlUsedFor17.SelectedValue = "0"; ddlSubstationEarthing18.SelectedValue = "0"; txtSubstationEarthing18.Text = "";
            ddlUsedFor18.SelectedValue = "0"; ddlSubstationEarthing19.SelectedValue = "0";
            txtSubstationEarthing19.Text = ""; ddlUsedFor19.SelectedValue = "0"; ddlSubstationEarthing20.SelectedValue = "0";
            txtSubstationEarthing20.Text = ""; ddlUsedFor20.SelectedValue = "0"; txtBreakerCapacity.Text = ""; ddlLTProtection.SelectedValue = "0"; txtIndividualCapacity.Text = "";
            txtLTBreakerCapacity.Text = ""; txtLoadBreakingCapacity.Text = ""; txtSealLevelPlinth.Text = "";
            InCaseOfOil.Visible = false;
            SubstationEarthingDiv.Visible = false;
            Breaker.Visible = false;
            TypeOfHTBreaker.Visible = false;
        }

        protected void ddlUsedFor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor1.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing1.Visible = true;
            }
            else
            {
                txtOtherEarthing1.Visible = false;
            }
        }

        protected void ddlUsedFor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor2.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing2.Visible = true;
            }
            else
            {
                txtOtherEarthing2.Visible = false;
            }
        }

        protected void ddlUsedFor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor3.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing3.Visible = true;
            }
            else
            {
                txtOtherEarthing3.Visible = false;
            }
        }

        protected void ddlUsedFor4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor4.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing4.Visible = true;
            }
            else
            {
                txtOtherEarthing4.Visible = false;
            }
        }

        protected void ddlUsedFor5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor5.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing5.Visible = true;
            }
            else
            {
                txtOtherEarthing5.Visible = false;
            }
        }

        protected void ddlUsedFor6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor6.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing6.Visible = true;
            }
            else
            {
                txtOtherEarthing6.Visible = false;
            }
        }

        protected void ddlUsedFor7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor7.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing7.Visible = true;
            }
            else
            {
                txtOtherEarthing7.Visible = false;
            }
        }

        protected void ddlUsedFor8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor8.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing8.Visible = true;
            }
            else
            {
                txtOtherEarthing8.Visible = false;
            }
        }

        protected void ddlUsedFor9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor9.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing9.Visible = true;
            }
            else
            {
                txtOtherEarthing9.Visible = false;
            }
        }

        protected void ddlUsedFor10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor10.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing10.Visible = true;
            }
            else
            {
                txtOtherEarthing10.Visible = false;
            }
        }

        protected void ddlUsedFor11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor11.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing11.Visible = true;
            }
            else
            {
                txtOtherEarthing11.Visible = false;
            }
        }

        protected void ddlUsedFor12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor12.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing12.Visible = true;
            }
            else
            {
                txtOtherEarthing12.Visible = false;
            }
        }

        protected void ddlUsedFor13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor13.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing13.Visible = true;
            }
            else
            {
                txtOtherEarthing13.Visible = false;
            }
        }

        protected void ddlUsedFor14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor14.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing14.Visible = true;
            }
            else
            {
                txtOtherEarthing14.Visible = false;
            }
        }

        protected void ddlUsedFor15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor15.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing15.Visible = true;
            }
            else
            {
                txtOtherEarthing15.Visible = false;
            }
        }

        protected void ddlUsedFor16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor16.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing16.Visible = true;
            }
            else
            {
                txtOtherEarthing16.Visible = false;
            }
        }

        protected void ddlUsedFor17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor17.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing17.Visible = true;
            }
            else
            {
                txtOtherEarthing17.Visible = false;
            }
        }

        protected void ddlUsedFor18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor18.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing18.Visible = true;
            }
            else
            {
                txtOtherEarthing18.Visible = false;
            }
        }

        protected void ddlUsedFor19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor19.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing19.Visible = true;
            }
            else
            {
                txtOtherEarthing19.Visible = false;
            }
        }

        protected void ddlUsedFor20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor20.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing20.Visible = true;
            }
            else
            {
                txtOtherEarthing20.Visible = true;
            }
        }
    }
}