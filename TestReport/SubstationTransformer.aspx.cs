using CEI_PRoject;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReport
{
    public partial class SubstationTransformer : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEarthingSubstation();
                // SessionCheck();
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
                    labelVerification.Visible = true;
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
                    x = x + 1;
                    Reset();
                    DataSaved.Visible = true;
                    labelVerification.Visible = false;
                    PageWorking();
                }
            }
            catch (Exception)
            {

                DataSaved.Visible = false;
            }
        }
        //public void SessionCheck()
        //{
        //    try
        //    {
        //        if (Session["installationNo1"].ToString() != null && Session["installationNo1"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo1"] as string;
        //        }
        //        else if (Session["installationNo2"].ToString() != null && Session["installationNo2"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo2"] as string;
        //        }
        //        else if (Session["installationNo3"].ToString() != null && Session["installationNo3"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo3"] as string;
        //        }
        //        else if (Session["installationNo4"].ToString() != null && Session["installationNo4"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo4"] as string;
        //        }
        //        else if (Session["installationNo5"].ToString() != null && Session["installationNo5"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo5"] as string;
        //        }
        //        else if (Session["installationNo6"].ToString() != null && Session["installationNo6"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo6"] as string;
        //        }
        //        else if (Session["installationNo7"].ToString() != null && Session["installationNo7"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo7"] as string;

        //        }
        //        else if (Session["installationNo8"].ToString() != null && Session["installationNo8"].ToString() != string.Empty)
        //        {
        //            sessionValue = Session["installationNo8"] as string;
        //        }
        //        if (Session["SubmittedValue"].ToString() == sessionValue)
        //        {
        //            BtnSubmitSubstation.Visible = false;
        //        }
        //        else
        //        {
        //            BtnSubmitSubstation.Visible = true;
        //        }
        //    }
        //    catch
        //    {
        //    }

        //}
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

            string currentValue = Convert.ToString(x);
            if (currentValue == sessionValue)
            {
                BtnSubmitSubstation.Visible = false;
                Session["SubmittedValue"] = sessionValue;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Form Submitted Successfully')", true);
                divtrasformer.Visible = false;
            }
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
            txtLowestValue.Text = ""; txtLightningArrestor.Text = ""; ddlHTType.SelectedValue = "0"; ddlEarthingsubstation.SelectedValue = "0";
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
        }
    }
}