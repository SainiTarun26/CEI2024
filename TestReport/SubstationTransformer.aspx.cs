using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReport
{
    public partial class SubstationTransformer : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
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

                    //DataSaved.Visible = true;
                    //labelVerification.Visible = false;
                }
            }
            catch (Exception Ex)
            {

               // DataSaved.Visible = false;
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
    }
}