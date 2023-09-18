using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                    ddlLoadBindState();
                //}
            }
        }
       
        private void ddlLoadBindState()
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
                SqlCommand cmd = new SqlCommand("sp_InserLineData");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    con.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;

             //cmd.Parameters.AddWithValue("@SanctionLoadContractDemad", txtSanctionLoad.Text);
                cmd.Parameters.AddWithValue("@LineVoltage", ddlLineVoltage.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@LineLength", txtLineLength.Text);
                cmd.Parameters.AddWithValue("@LineType", ddlLineType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@NoOfCircuit", ddlNmbrOfCircuit.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Conductortype", ddlConductorType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@NumberofPoleTower", txtPoleTower.Text);
                cmd.Parameters.AddWithValue("@ConductorSize", txtConductorSize.Text);
                cmd.Parameters.AddWithValue("@GroundWireSize", txtGroundWireSize.Text);
                cmd.Parameters.AddWithValue("@NmbrofRailwayCrossing", txtRailwayCrossingNo.Text);
                cmd.Parameters.AddWithValue("@NmbrofRoadCrossing", txtRoadCrossingNo.Text);
                cmd.Parameters.AddWithValue("@NmbrofRiverCanalCrossing", txtRiverCanalCrossing.Text);
                cmd.Parameters.AddWithValue("@NmbrofPowerLineCrossing", txtPowerLineCrossing.Text);
                cmd.Parameters.AddWithValue("@NmbrofEarthing", ddlNoOfEarthing.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@EarthingType1", ddlEarthingtype1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms1", txtearthingValue1.Text);
                cmd.Parameters.AddWithValue("@EarthingType2", ddlEarthingtype2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms2", txtEarthingValue2.Text);
                cmd.Parameters.AddWithValue("@EarthingType3", ddlEarthingtype3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms3", txtEarthingValue3.Text);
                cmd.Parameters.AddWithValue("@EarthingType4", ddlEarthingtype4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms4", txtEarthingValue4.Text);
                cmd.Parameters.AddWithValue("@EarthingType5", ddlEarthingtype5.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms5", txtEarthingValue5.Text);
                cmd.Parameters.AddWithValue("@EarthingType6", ddlEarthingtype6.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms6", txtEarthingValue6.Text);
                cmd.Parameters.AddWithValue("@EarthingType7", ddlEarthingtype7.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms7", txtEarthingValue7.Text);
                cmd.Parameters.AddWithValue("@EarthingType8", ddlEarthingtype8.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms8", txtEarthingValue8.Text);
                cmd.Parameters.AddWithValue("@EarthingType9", ddlEarthingtype9.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms9", txtEarthingValue9.Text);
                cmd.Parameters.AddWithValue("@EarthingType10", ddlEarthingtype10.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms10", txtEarthingValue10.Text);
                cmd.Parameters.AddWithValue("@EarthingType11", ddlEarthingtype11.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms11", txtEarthingValue11.Text);
                cmd.Parameters.AddWithValue("@EarthingType12", ddlEarthingtype12.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms12", txtEarthingValue12.Text);
                cmd.Parameters.AddWithValue("@EarthingType13", ddlEarthingtype13.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms13", txtEarthingValue13.Text);
                cmd.Parameters.AddWithValue("@EarthingType14", ddlEarthingtype14.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms14", txtEarthingValue14.Text);
                cmd.Parameters.AddWithValue("@EarthingType15", ddlEarthingtype15.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Valueinohms15", txtEarthingValue15.Text);
                cmd.Parameters.AddWithValue("@NoofPoleTowerForOverheadCable", txtPoleTowerNo.Text);
                cmd.Parameters.AddWithValue("@CableSize", txtCableSize1.Text);
                cmd.Parameters.AddWithValue("@RailwayCrossingNoForOC", txtRailwayCrossingNmbr.Text);
                cmd.Parameters.AddWithValue("@RoadCrossingNoForOC", txtRoadCrossingNmbr.Text);
                cmd.Parameters.AddWithValue("@RiverCanalCrossingNoForOC", txtRiverCanalCrossingNmber.Text);
                cmd.Parameters.AddWithValue("@PowerLineCrossingNoForOc", txtPowerLineCrossingNmbr.Text);
                cmd.Parameters.AddWithValue("@RedPhaseEarthWire", txtRedEarthWire.Text);
                cmd.Parameters.AddWithValue("@YellowPhaseEarth", txtYellowEarthWire.Text);
                cmd.Parameters.AddWithValue("@BluePhaseEarthWire", txtBlueEarthWire.Text);
                cmd.Parameters.AddWithValue("@RedPhaseYellowPhase", txtRedYellowPhase.Text);
                cmd.Parameters.AddWithValue("@RedPhaseBluePhase", txtRedBluePhase.Text);
                cmd.Parameters.AddWithValue("@BluePhaseYellowPhase", txtBlueYellowPhase.Text);
                cmd.Parameters.AddWithValue("@PhasewireNeutralwire", txtNeutralWire.Text);
                cmd.Parameters.AddWithValue("@PhasewireEarth", txtEarthWire.Text);
                cmd.Parameters.AddWithValue("@NeutralwireEarth", txtNeutralWireEarth.Text);
                cmd.Parameters.AddWithValue("@TypeofCable", ddlCableType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@SizeofCable", txtCableSize.Text);
                cmd.Parameters.AddWithValue("@Cablelaidin", ddlCableLaid.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@RedPhaseEarthWirefor440orAbove", txtRedWire.Text);
                cmd.Parameters.AddWithValue("@YellowPhaseEarthWire440orAbove", txtYellowWire.Text);
                cmd.Parameters.AddWithValue("@BluePhaseEarthWire440orAbove", txtBlueWire.Text);
                cmd.Parameters.AddWithValue("@RedPhaseYellowPhase440orAbove", txtRedYellowWire.Text);
                cmd.Parameters.AddWithValue("@RedPhaseBluePhase440orAbove", txtRedBlueWire.Text);
                cmd.Parameters.AddWithValue("@BluePhaseYellowPhase440orAbove", txtBlueYellowWire.Text);
                cmd.Parameters.AddWithValue("@PhasewireNeutralwire220OrAbove", txtNeutralPhaseWire.Text);
                cmd.Parameters.AddWithValue("@PhasewireEarth220OrAbove", txtPhaseWireEarth.Text);
                cmd.Parameters.AddWithValue("@NeutralwireEarth220OrAbove", txtNeutralWireEarthUnderground.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                DataSaved.Visible = true;

            }
            catch (Exception Ex)
            {

                if (Ex.Message.StartsWith("Violation of UNIQUE KEY constraint"))
                {
                    string alertScript = "alert('Error: License Number Incorrect\\n\\nThe provided license number is already in use. Please provide a different license number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }
                else if (Ex.Message.StartsWith("The INSERT statement conflicted"))
                {
                    string sanitizedErrorMessage = Ex.Message.Replace("'", "\\'");
                    string alertScript = "alert('Error: License Number Incorrect\\n\\nLicense number old and new are the same. Please provide a different license number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }

                DataSaved.Visible = false;
            }
        }

        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;
            if (ddlNoOfEarthing.SelectedItem.ToString() == "1")
            {
                Earthingtype1.Visible= true;
            } 
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "2")
            {
                Earthingtype1.Visible= true;
                Earthingtype2.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "3")
            {
                Earthingtype1.Visible= true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "4")
            {
                Earthingtype1.Visible= true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "5")
            {
                Earthingtype1.Visible= true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");

            }else if (ddlNoOfEarthing.SelectedItem.ToString() == "6")
            {
                Earthingtype1.Visible= true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");

            }else if (ddlNoOfEarthing.SelectedItem.ToString() == "7")
            {
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
                Earthingtype1.Visible= true;
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
    }
}