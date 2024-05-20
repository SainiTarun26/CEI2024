using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class SubstationTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string currentSessionName = string.Empty;
        string Type = string.Empty;
        string SubStationID = string.Empty;
        private static string _PrimaryVoltage, _SecondaryVoltage;

        string IdUpdate = string.Empty;
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

                        ddlEarthingSubstation();
                        SessionValue();
                        PageWorking();
                        ddlPrimaryVoltage();
                        ddlSecondarVoltage();
                        if (Convert.ToString(Session["ValueId"]) == null || Convert.ToString(Session["ValueId"]) == "")
                        {

                        }
                        else
                        {
                            SubStationID = Session["SubStationID"].ToString().Trim();
                            GetHistoryDataById();
                        }
                        if (Convert.ToString(Session["Approval"]) == "Reject")
                        {



                            SubStationID = Session["SubStationID"].ToString().Trim();

                            Session["Application"] = Session["ApplicationForTestReport"].ToString().Trim();
                            Session["Typs"] = Session["TypeOf"].ToString().Trim();
                            Session["Intimations"] = Session["ID"].ToString().Trim();
                            Session["IHID"] = Session["IHIDs"].ToString().Trim();
                            Session["NoOfInstallations"] = Session["NoOfInstallation"].ToString().Trim();

                            GetHistoryDataById();
                            //BtnBack.Visible = true;

                        }
                        if (Convert.ToString(Session["ContractorID"]) == null || Convert.ToString(Session["ContractorID"]) == "")
                        {

                        }
                        else
                        {
                            BtnBack.Visible = false;
                            btnVerify.Visible = false;
                            BtnSubmitSubstation.Visible = false;
                        }

                        txtapplication.Text = Session["Application"].ToString().Trim();
                        txtInstallation.Text = Session["Typs"].ToString().Trim();
                        txtid.Text = Session["Intimations"].ToString().Trim();
                        txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                        BtnBack.Visible = true;
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
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (Session["TestReportHistory"] != null)
            {
                Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
            }
            else if (Session["TestReportHistory"] == null)
            {
                Response.Redirect("/Supervisor/InstallationDetails.aspx", false);
            }
            else
            {
                Response.Redirect("/Admin/TestHistoryReport.aspx", false);

            }
        }
        public void GetHistoryDataById()
        {
            try
            {
                //if (Convert.ToString(Session["Value"]) == null || Convert.ToString(Session["Value"]) == "")
                //{

                //}
                //else
                //{
                //    Type = Session["Value"].ToString();
                //}
                //if (Convert.ToString(Session["Approval"]) == "Reject")
                //{
                //    Type = "Substation Transformer";
                //}
                Type = "Substation Transformer";
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataForUpdate(Type, SubStationID);
                if (ds.Tables.Count > 0)
                {
                    Session["Contact"] = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    txtTransformerSerialNumber.Text = ds.Tables[0].Rows[0]["TransformerSerialNumber"].ToString();
                    string TransformerCapacity = ds.Tables[0].Rows[0]["TransformerCapacityType"].ToString();
                    ddltransformerCapacity.SelectedIndex = ddltransformerCapacity.Items.IndexOf(ddltransformerCapacity.Items.FindByText(TransformerCapacity));
                    txtTransformerCapacity.Text = ds.Tables[0].Rows[0]["TransformerCapacity"].ToString();
                    string TypeOfTransformer = ds.Tables[0].Rows[0]["TranformerType"].ToString();
                    ddltransformerType.SelectedIndex = ddltransformerType.Items.IndexOf(ddltransformerType.Items.FindByText(TypeOfTransformer));
                    if (TypeOfTransformer != null)
                    {
                        InCaseOfOil.Visible = true;
                        string Voltage = ds.Tables[0].Rows[0]["PrimaryVoltage"].ToString();
                        PrimaryVoltage.SelectedIndex = PrimaryVoltage.Items.IndexOf(PrimaryVoltage.Items.FindByText(Voltage));
                        string Voltage2 = ds.Tables[0].Rows[0]["SecondoryVoltage"].ToString();
                        ddlSecondaryVoltage.SelectedIndex = ddlSecondaryVoltage.Items.IndexOf(ddlSecondaryVoltage.Items.FindByText(Voltage2));
                        if (TypeOfTransformer == "Oil")
                        {
                            Capacity.Visible = true;
                            BDV.Visible = true;
                            txtOilCapacity.Text = ds.Tables[0].Rows[0]["OilCapacity"].ToString();
                            txtOilBDV.Text = ds.Tables[0].Rows[0]["BreakDownVoltageofOil"].ToString();
                        }

                        txtHTsideInsulation.Text = ds.Tables[0].Rows[0]["HtInsulationHVEarth"].ToString();
                        txtLTSideInsulation.Text = ds.Tables[0].Rows[0]["LtInsulationLVEarth"].ToString();
                        txtLowestValue.Text = ds.Tables[0].Rows[0]["LowestvaluebetweenHTLTSide"].ToString();
                        string LALocation = ds.Tables[0].Rows[0]["LightningArrestorLocation"].ToString();
                        ddlLghtningArrestor.SelectedIndex = ddlLghtningArrestor.Items.IndexOf(ddlLghtningArrestor.Items.FindByText(LALocation));
                        if (LALocation.Trim() == "Other")
                        {
                            OtherLaDiv.Visible = true;
                        }
                        txtLightningArrestor.Text = ds.Tables[0].Rows[0]["OtherLALocation"].ToString();
                        string TypeOfHT = ds.Tables[0].Rows[0]["TypeofHTPrimarySideSwitch"].ToString();

                        if (TypeOfHT == "Breaker")
                        {
                            ddlHTType.SelectedIndex = ddlHTType.Items.IndexOf(ddlHTType.Items.FindByText(TypeOfHT));
                            TypeOfHTBreaker.Visible = true;
                            txtBreakerCapacity.Text = ds.Tables[0].Rows[0]["LoadBreakingCapacityOfBreakerInKA"].ToString();

                            string TypeOfLtProtection = ds.Tables[0].Rows[0]["TypeOfLTProtection"].ToString();
                            ddlLTProtection.SelectedIndex = ddlLTProtection.Items.IndexOf(ddlLTProtection.Items.FindByText(TypeOfLtProtection));
                            if (TypeOfLtProtection == "Fuse Unit")
                            {
                                FuseUnit.Visible = true;
                                txtIndividualCapacity.Text = ds.Tables[0].Rows[0]["CapacityOfIndividualFuseInAMPS"].ToString();

                            }
                            else
                            {
                                Breaker.Visible = true;
                                txtLTBreakerCapacity.Text = ds.Tables[0].Rows[0]["CapacityOfLTBreakerInAMPS"].ToString();
                                txtLoadBreakingCapacity.Text = ds.Tables[0].Rows[0]["LoadBreakingCapacityOfBreakerInAMPS"].ToString();
                            }
                            MeanSeaPlinth.Visible = true;
                            txtSealLevelPlinth.Text = ds.Tables[0].Rows[0]["SeaLevelOfTransformerInMeters"].ToString();
                        }
                        else
                        {
                            ddlHTType.Items.Add(new ListItem("GO Switch", "1"));
                            ddlHTType.Items.Add(new ListItem("3Pole Linked Switch(GODO)", "2"));
                            ddlHTType.SelectedIndex = ddlHTType.Items.IndexOf(ddlHTType.Items.FindByText(TypeOfHT));
                        }
                        string NoOfErathing = ds.Tables[0].Rows[0]["NumberOfEarthing"].ToString();
                        ddlEarthingsubstation.SelectedIndex = ddlEarthingsubstation.Items.IndexOf(ddlEarthingsubstation.Items.FindByText(NoOfErathing));
                        if (NoOfErathing != null || NoOfErathing != "")
                        {
                            SubstationEarthingDiv.Visible = true;

                            if (NoOfErathing == "4")
                            {
                                EarthingSubstation4.Visible = true;
                            }
                            else if (NoOfErathing == "5")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                            }
                            else if (NoOfErathing == "6")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                                EathingSubstation6.Visible = true;
                            }
                            else if (NoOfErathing == "7")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                                EathingSubstation6.Visible = true;
                                EathingSubstation7.Visible = true;
                            }
                            else if (NoOfErathing == "8")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                                EathingSubstation6.Visible = true;
                                EathingSubstation7.Visible = true;
                                EathingSubstation8.Visible = true;
                            }
                            else if (NoOfErathing == "9")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                                EathingSubstation6.Visible = true;
                                EathingSubstation7.Visible = true;
                                EathingSubstation8.Visible = true;
                                EathingSubstation9.Visible = true;
                            }
                            else if (NoOfErathing == "10")
                            {
                                EarthingSubstation4.Visible = true;
                                EathingSubstation5.Visible = true;
                                EathingSubstation6.Visible = true;
                                EathingSubstation7.Visible = true;
                                EathingSubstation8.Visible = true;
                                EathingSubstation9.Visible = true;
                                EathingSubstation10.Visible = true;
                            }
                            else if (NoOfErathing == "11")
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
                            else if (NoOfErathing == "12")
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
                            else if (NoOfErathing == "13")
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
                            else if (NoOfErathing == "14")
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
                            else if (NoOfErathing == "15")
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
                            else if (NoOfErathing == "16")
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
                            else if (NoOfErathing == "17")
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
                            else if (NoOfErathing == "18")
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
                            else if (NoOfErathing == "19")
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
                            else if (NoOfErathing == "20")
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


                            string EarthingType1 = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                            ddlSubstationEarthing1.SelectedIndex = ddlSubstationEarthing1.Items.IndexOf(ddlSubstationEarthing1.Items.FindByText(EarthingType1));
                            txtSubstationEarthing1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();
                            string UsedFor1 = ds.Tables[0].Rows[0]["UsedFor1"].ToString();
                            ddlUsedFor1.SelectedIndex = ddlUsedFor1.Items.IndexOf(ddlUsedFor1.Items.FindByText(UsedFor1));
                            if (UsedFor1 == "Other")
                            {
                                txtOtherEarthing1.Visible = true;
                                txtOtherEarthing1.Text = ds.Tables[0].Rows[0]["OtherEarthing1"].ToString();
                            }
                            string EarthingType2 = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                            ddlSubstationEarthing2.SelectedIndex = ddlSubstationEarthing2.Items.IndexOf(ddlSubstationEarthing2.Items.FindByText(EarthingType2));
                            txtSubstationEarthing2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
                            string UsedFor2 = ds.Tables[0].Rows[0]["UsedFor2"].ToString();
                            ddlUsedFor2.SelectedIndex = ddlUsedFor2.Items.IndexOf(ddlUsedFor2.Items.FindByText(UsedFor2));
                            if (UsedFor2 == "Other")
                            {
                                txtOtherEarthing2.Visible = true;
                                txtOtherEarthing2.Text = ds.Tables[0].Rows[0]["OtherEarthing2"].ToString();
                            }

                            string EarthingType3 = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                            ddlSubstationEarthing3.SelectedIndex = ddlSubstationEarthing3.Items.IndexOf(ddlSubstationEarthing3.Items.FindByText(EarthingType3));
                            txtSubstationEarthing3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
                            string UsedFor3 = ds.Tables[0].Rows[0]["UsedFor3"].ToString();
                            ddlUsedFor3.SelectedIndex = ddlUsedFor3.Items.IndexOf(ddlUsedFor3.Items.FindByText(UsedFor3));
                            if (UsedFor3 == "Other")
                            {
                                txtOtherEarthing3.Visible = true;
                                txtOtherEarthing3.Text = ds.Tables[0].Rows[0]["OtherEarthing3"].ToString();
                            }

                            string EarthingType4 = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                            ddlSubstationEarthing4.SelectedIndex = ddlSubstationEarthing4.Items.IndexOf(ddlSubstationEarthing4.Items.FindByText(EarthingType4));
                            txtSubstationEarthing4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
                            string UsedFor4 = ds.Tables[0].Rows[0]["UsedFor4"].ToString();
                            ddlUsedFor4.SelectedIndex = ddlUsedFor4.Items.IndexOf(ddlUsedFor4.Items.FindByText(UsedFor4));
                            if (UsedFor4 == "Other")
                            {
                                txtOtherEarthing4.Visible = true;
                                txtOtherEarthing4.Text = ds.Tables[0].Rows[0]["OtherEarthing4"].ToString();
                            }

                            string EarthingType5 = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                            ddlSubstationEarthing5.SelectedIndex = ddlSubstationEarthing5.Items.IndexOf(ddlSubstationEarthing5.Items.FindByText(EarthingType5));
                            txtSubstationEarthing5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
                            string UsedFor5 = ds.Tables[0].Rows[0]["UsedFor5"].ToString();
                            ddlUsedFor5.SelectedIndex = ddlUsedFor5.Items.IndexOf(ddlUsedFor5.Items.FindByText(UsedFor5));
                            if (UsedFor5 == "Other")
                            {
                                txtOtherEarthing5.Visible = true;
                                txtOtherEarthing5.Text = ds.Tables[0].Rows[0]["OtherEarthing5"].ToString();
                            }

                            string EarthingType6 = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                            ddlSubstationEarthing6.SelectedIndex = ddlSubstationEarthing6.Items.IndexOf(ddlSubstationEarthing6.Items.FindByText(EarthingType6));
                            txtSubstationEarthing6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
                            string UsedFor6 = ds.Tables[0].Rows[0]["UsedFor6"].ToString();
                            ddlUsedFor6.SelectedIndex = ddlUsedFor6.Items.IndexOf(ddlUsedFor6.Items.FindByText(UsedFor6));
                            if (UsedFor6 == "Other")
                            {
                                txtOtherEarthing6.Visible = true;
                                txtOtherEarthing6.Text = ds.Tables[0].Rows[0]["OtherEarthing6"].ToString();
                            }

                            string EarthingType7 = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                            ddlSubstationEarthing7.SelectedIndex = ddlSubstationEarthing7.Items.IndexOf(ddlSubstationEarthing7.Items.FindByText(EarthingType7));
                            txtSubstationEarthing7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
                            string UsedFor7 = ds.Tables[0].Rows[0]["UsedFor7"].ToString();
                            ddlUsedFor7.SelectedIndex = ddlUsedFor7.Items.IndexOf(ddlUsedFor7.Items.FindByText(UsedFor7));
                            if (UsedFor7 == "Other")
                            {
                                txtOtherEarthing7.Visible = true;
                                txtOtherEarthing7.Text = ds.Tables[0].Rows[0]["OtherEarthing7"].ToString();
                            }

                            string EarthingType8 = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                            ddlSubstationEarthing8.SelectedIndex = ddlSubstationEarthing8.Items.IndexOf(ddlSubstationEarthing8.Items.FindByText(EarthingType8));
                            txtSubstationEarthing8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();
                            string UsedFor8 = ds.Tables[0].Rows[0]["UsedFor8"].ToString();
                            ddlUsedFor8.SelectedIndex = ddlUsedFor8.Items.IndexOf(ddlUsedFor8.Items.FindByText(UsedFor8));
                            if (UsedFor8 == "Other")
                            {
                                txtOtherEarthing8.Visible = true;
                                txtOtherEarthing8.Text = ds.Tables[0].Rows[0]["OtherEarthing8"].ToString();
                            }

                            string EarthingType9 = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                            ddlSubstationEarthing9.SelectedIndex = ddlSubstationEarthing9.Items.IndexOf(ddlSubstationEarthing9.Items.FindByText(EarthingType6));
                            txtSubstationEarthing9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
                            string UsedFor9 = ds.Tables[0].Rows[0]["UsedFor9"].ToString();
                            ddlUsedFor9.SelectedIndex = ddlUsedFor9.Items.IndexOf(ddlUsedFor9.Items.FindByText(UsedFor9));
                            if (UsedFor9 == "Other")
                            {
                                txtOtherEarthing9.Visible = true;
                                txtOtherEarthing9.Text = ds.Tables[0].Rows[0]["OtherEarthing9"].ToString();
                            }

                            string EarthingType10 = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                            ddlSubstationEarthing10.SelectedIndex = ddlSubstationEarthing10.Items.IndexOf(ddlSubstationEarthing10.Items.FindByText(EarthingType10));
                            txtSubstationEarthing10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
                            string UsedFor10 = ds.Tables[0].Rows[0]["UsedFor10"].ToString();
                            ddlUsedFor10.SelectedIndex = ddlUsedFor10.Items.IndexOf(ddlUsedFor10.Items.FindByText(UsedFor10));
                            if (UsedFor10 == "Other")
                            {
                                txtOtherEarthing10.Visible = true;
                                txtOtherEarthing10.Text = ds.Tables[0].Rows[0]["OtherEarthing10"].ToString();
                            }


                            string EarthingType11 = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                            ddlSubstationEarthing11.SelectedIndex = ddlSubstationEarthing11.Items.IndexOf(ddlSubstationEarthing11.Items.FindByText(EarthingType11));
                            txtSubstationEarthing11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();
                            string UsedFor11 = ds.Tables[0].Rows[0]["UsedFor11"].ToString();
                            ddlUsedFor11.SelectedIndex = ddlUsedFor11.Items.IndexOf(ddlUsedFor11.Items.FindByText(UsedFor11));
                            if (UsedFor11 == "Other")
                            {
                                txtOtherEarthing11.Visible = true;
                                txtOtherEarthing11.Text = ds.Tables[0].Rows[0]["OtherEarthing11"].ToString();
                            }

                            string EarthingType12 = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                            ddlSubstationEarthing12.SelectedIndex = ddlSubstationEarthing12.Items.IndexOf(ddlSubstationEarthing12.Items.FindByText(EarthingType12));
                            txtSubstationEarthing12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();
                            string UsedFor12 = ds.Tables[0].Rows[0]["UsedFor12"].ToString();
                            ddlUsedFor12.SelectedIndex = ddlUsedFor12.Items.IndexOf(ddlUsedFor12.Items.FindByText(UsedFor12));
                            if (UsedFor12 == "Other")
                            {
                                txtOtherEarthing12.Visible = true;
                                txtOtherEarthing12.Text = ds.Tables[0].Rows[0]["OtherEarthing12"].ToString();
                            }

                            string EarthingType13 = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                            ddlSubstationEarthing12.SelectedIndex = ddlSubstationEarthing12.Items.IndexOf(ddlSubstationEarthing12.Items.FindByText(EarthingType13));
                            txtSubstationEarthing12.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();
                            string UsedFor13 = ds.Tables[0].Rows[0]["UsedFor13"].ToString();
                            ddlUsedFor12.SelectedIndex = ddlUsedFor12.Items.IndexOf(ddlUsedFor12.Items.FindByText(UsedFor13));
                            if (UsedFor13 == "Other")
                            {
                                txtOtherEarthing13.Visible = true;
                                txtOtherEarthing13.Text = ds.Tables[0].Rows[0]["OtherEarthing13"].ToString();
                            }

                            string EarthingType14 = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                            ddlSubstationEarthing14.SelectedIndex = ddlSubstationEarthing14.Items.IndexOf(ddlSubstationEarthing14.Items.FindByText(EarthingType14));
                            txtSubstationEarthing14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();
                            string UsedFor14 = ds.Tables[0].Rows[0]["UsedFor14"].ToString();
                            ddlUsedFor14.SelectedIndex = ddlUsedFor14.Items.IndexOf(ddlUsedFor14.Items.FindByText(UsedFor14));
                            if (UsedFor14 == "Other")
                            {
                                txtOtherEarthing14.Visible = true;
                                txtOtherEarthing14.Text = ds.Tables[0].Rows[0]["OtherEarthing14"].ToString();
                            }

                            string EarthingType15 = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                            ddlSubstationEarthing15.SelectedIndex = ddlSubstationEarthing15.Items.IndexOf(ddlSubstationEarthing15.Items.FindByText(EarthingType15));
                            txtSubstationEarthing15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();
                            string UsedFor15 = ds.Tables[0].Rows[0]["UsedFor15"].ToString();
                            ddlUsedFor15.SelectedIndex = ddlUsedFor15.Items.IndexOf(ddlUsedFor15.Items.FindByText(UsedFor15));
                            if (UsedFor15 == "Other")
                            {
                                txtOtherEarthing15.Visible = true;
                                txtOtherEarthing15.Text = ds.Tables[0].Rows[0]["OtherEarthing15"].ToString();
                            }

                            string EarthingType16 = ds.Tables[0].Rows[0]["EarthingType16"].ToString();
                            ddlSubstationEarthing16.SelectedIndex = ddlSubstationEarthing16.Items.IndexOf(ddlSubstationEarthing16.Items.FindByText(EarthingType16));
                            txtSubstationEarthing16.Text = ds.Tables[0].Rows[0]["Valueinohms16"].ToString();
                            string UsedFor16 = ds.Tables[0].Rows[0]["UsedFor16"].ToString();
                            ddlUsedFor16.SelectedIndex = ddlUsedFor16.Items.IndexOf(ddlUsedFor16.Items.FindByText(UsedFor16));
                            if (UsedFor16 == "Other")
                            {
                                txtOtherEarthing16.Visible = true;
                                txtOtherEarthing16.Text = ds.Tables[0].Rows[0]["OtherEarthing16"].ToString();
                            }

                            string EarthingType17 = ds.Tables[0].Rows[0]["EarthingType17"].ToString();
                            ddlSubstationEarthing17.SelectedIndex = ddlSubstationEarthing17.Items.IndexOf(ddlSubstationEarthing17.Items.FindByText(EarthingType17));
                            txtSubstationEarthing17.Text = ds.Tables[0].Rows[0]["Valueinohms17"].ToString();
                            string UsedFor17 = ds.Tables[0].Rows[0]["UsedFor17"].ToString();
                            ddlUsedFor17.SelectedIndex = ddlUsedFor17.Items.IndexOf(ddlUsedFor17.Items.FindByText(UsedFor17));
                            if (UsedFor17 == "Other")
                            {
                                txtOtherEarthing17.Visible = true;
                                txtOtherEarthing17.Text = ds.Tables[0].Rows[0]["OtherEarthing17"].ToString();
                            }

                            string EarthingType18 = ds.Tables[0].Rows[0]["EarthingType18"].ToString();
                            ddlSubstationEarthing18.SelectedIndex = ddlSubstationEarthing12.Items.IndexOf(ddlSubstationEarthing12.Items.FindByText(EarthingType18));
                            txtSubstationEarthing18.Text = ds.Tables[0].Rows[0]["Valueinohms18"].ToString();
                            string UsedFor18 = ds.Tables[0].Rows[0]["UsedFor18"].ToString();
                            ddlUsedFor12.SelectedIndex = ddlUsedFor12.Items.IndexOf(ddlUsedFor12.Items.FindByText(UsedFor18));
                            if (UsedFor18 == "Other")
                            {
                                txtOtherEarthing18.Visible = true;
                                txtOtherEarthing18.Text = ds.Tables[0].Rows[0]["OtherEarthing18"].ToString();
                            }

                            string EarthingType19 = ds.Tables[0].Rows[0]["EarthingType19"].ToString();
                            ddlSubstationEarthing19.SelectedIndex = ddlSubstationEarthing19.Items.IndexOf(ddlSubstationEarthing19.Items.FindByText(EarthingType19));
                            txtSubstationEarthing19.Text = ds.Tables[0].Rows[0]["Valueinohms19"].ToString();
                            string UsedFor19 = ds.Tables[0].Rows[0]["UsedFor19"].ToString();
                            ddlUsedFor19.SelectedIndex = ddlUsedFor19.Items.IndexOf(ddlUsedFor19.Items.FindByText(UsedFor19));
                            if (UsedFor19 == "Other")
                            {
                                txtOtherEarthing19.Visible = true;
                                txtOtherEarthing19.Text = ds.Tables[0].Rows[0]["OtherEarthing19"].ToString();
                            }

                            string EarthingType20 = ds.Tables[0].Rows[0]["EarthingType20"].ToString();
                            ddlSubstationEarthing20.SelectedIndex = ddlSubstationEarthing20.Items.IndexOf(ddlSubstationEarthing20.Items.FindByText(EarthingType20));
                            txtSubstationEarthing20.Text = ds.Tables[0].Rows[0]["Valueinohms20"].ToString();
                            string UsedFor20 = ds.Tables[0].Rows[0]["UsedFor20"].ToString();
                            ddlUsedFor20.SelectedIndex = ddlUsedFor20.Items.IndexOf(ddlUsedFor20.Items.FindByText(UsedFor20));
                            if (UsedFor20 == "Other")
                            {
                                txtOtherEarthing20.Visible = true;
                                txtOtherEarthing20.Text = ds.Tables[0].Rows[0]["OtherEarthing20"].ToString();
                            }

                        }
                    }


                    if (Session["Approval"].ToString().Trim() == "Reject")
                    {

                        BtnSubmitSubstation.Text = "Update";
                    }
                    else
                    {
                        BtnSubmitSubstation.Visible = false;
                        BtnBack.Visible = true;

                    }


                }
            }
            catch (Exception ex)
            {
                // throw;
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
        private void ddlPrimaryVoltage()
        {
            string Volts = string.Empty;
            Volts = Session["VoltageLevel"].ToString();
            DataSet dsPrimaryVoltage = new DataSet();
            dsPrimaryVoltage = CEI.GetddlPrimaryVotlage(Volts);
            PrimaryVoltage.DataSource = dsPrimaryVoltage;
            PrimaryVoltage.DataTextField = "Volts";
            PrimaryVoltage.DataValueField = "Volts";
            PrimaryVoltage.DataBind();
            PrimaryVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsPrimaryVoltage.Clear();

        }
        protected void ddlLghtningArrestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLghtningArrestor.SelectedValue == "3")
            {
                OtherLaDiv.Visible = true;
            }
            else
            {
                OtherLaDiv.Visible = false;

            }

        }
        private void ddlSecondarVoltage()
        {
            string Volts = string.Empty;
            Volts = Session["VoltageLevel"].ToString();
            DataSet dsSecondaryVoltage = new DataSet();
            dsSecondaryVoltage = CEI.GetddlSecondaryVotlage(Volts);
            ddlSecondaryVoltage.DataSource = dsSecondaryVoltage;
            ddlSecondaryVoltage.DataTextField = "Volts";
            ddlSecondaryVoltage.DataValueField = "Volts";
            ddlSecondaryVoltage.DataBind();
            ddlSecondaryVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsSecondaryVoltage.Clear();

        }
        protected void ddltransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["VoltageLevel"]) == "upto 650 V" && ddltransformerType.SelectedValue == "1")
                {
                    PrimaryVoltageLevel.Visible = false;
                    InCaseOfOil.Visible = true;
                    Capacity.Visible = true;
                    BDV.Visible = true;

                }
                else if (Convert.ToString(Session["VoltageLevel"]) != null && ddltransformerType.SelectedValue == "1")
                {
                    PrimaryVoltageLevel.Visible = true;
                    InCaseOfOil.Visible = true;
                    Capacity.Visible = true;
                    BDV.Visible = true;
                }
                else if (Convert.ToString(Session["VoltageLevel"]) == "upto 650 V" && ddltransformerType.SelectedValue == "2")
                {
                    PrimaryVoltageLevel.Visible = false;
                    InCaseOfOil.Visible = true;
                    Capacity.Visible = false;
                    BDV.Visible = false;
                }
                else if (Convert.ToString(Session["VoltageLevel"]) != null && ddltransformerType.SelectedValue == "2")
                {
                    PrimaryVoltageLevel.Visible = true;
                    InCaseOfOil.Visible = true;
                    Capacity.Visible = false;
                    BDV.Visible = false;
                }
                else
                {
                }
            }
            catch (Exception ex) { }
        }
        protected void txtTransformerCapacity_TextChanged(object sender, EventArgs e)
        {
            int capacity = Convert.ToInt32(txtTransformerCapacity.Text.ToString());
            if (capacity >= 1000)
            {
                ddlHTType.Items.Clear();
                ddlHTType.Items.Add(new ListItem("Select", "0"));
                ddlHTType.Items.Add(new ListItem("Breaker", "3"));
            }
            else
            {
                ddlHTType.Items.Add(new ListItem("GO Switch", "1"));
                ddlHTType.Items.Add(new ListItem("3Pole Linked Switch(GODO)", "2"));
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
                Breaker.Visible = false;
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
            if (ddlLTProtection.SelectedValue != "0")
            {
                MeanSeaPlinth.Visible = true;
            }
            else
            {
                MeanSeaPlinth.Visible = false;
            }
        }
        protected void BtnSubmitSubstation_Click(object sender, EventArgs e)
        {

            try
            {
                //if (BtnSubmitSubstation.Text.Trim() == "Update")
                //{
                //    IdUpdate = Session["ValueId"].ToString();
                //}


                if (Declaration.Visible == true && CheckBox2.Checked == false)
                {

                    labelVerification.Visible = true;

                }

                else
                {
                    if (Check.Checked == true)
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
                        string TestReportId = Session["id"].ToString();
                        string IntimationId = Session["id"].ToString();
                        string CreatedBy = Session["SupervisorID"].ToString();
                        string installationNo = Session["IHID"].ToString();
                        string count = Session["NoOfInstallations"].ToString();
                        //Modiefied this for storing only voltage(11000) digit
                        string Primaryvoltage, SecondaryVoltage;
                         Primaryvoltage = PrimaryVoltage.SelectedItem.ToString().Trim();
                        _PrimaryVoltage = Primaryvoltage.Substring(0, Primaryvoltage.Length - 6);
                        
                         SecondaryVoltage = ddlSecondaryVoltage.SelectedValue.ToString().Trim();
                        _SecondaryVoltage = SecondaryVoltage.Substring(0, SecondaryVoltage.Length - 6);                      
                        //

                        CEI.InsertSubstationData(IdUpdate, count, SubstationId, TestReportId, IntimationId, txtTransformerSerialNumber.Text, ddltransformerCapacity.SelectedItem.ToString(), txtTransformerCapacity.Text, ddltransformerType.SelectedItem.ToString(),
                          _PrimaryVoltage,_SecondaryVoltage, txtOilCapacity.Text, txtOilBDV.Text, txtHTsideInsulation.Text, txtLTSideInsulation.Text,
                           txtLowestValue.Text, ddlLghtningArrestor.SelectedItem.ToString(), txtLightningArrestor.Text, ddlHTType.SelectedItem.ToString(), ddlEarthingsubstation.SelectedItem.ToString(),
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
                        CEI.UpdateInstallations(installationNo, IntimationId);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);

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
            catch (Exception ex)
            {

                DataSaved.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                return;
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
                        //if (nextSessionName == "Line")
                        //{
                        //    Response.Redirect("LineTestReport.aspx");
                        //}
                        //else if (nextSessionName == "Generating Station")
                        //{
                        //    Response.Redirect("GeneratingSetTestReport.aspx");
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been submitted and is under review by the Contractor for final submission')", true);

                        //}
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
                    BtnSubmitSubstation.Attributes.Add("disabled", "true");
                    btnVerify.Visible = true;
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
            PrimaryVoltage.SelectedValue = "0";
            ddlSecondaryVoltage.SelectedValue = "0"; txtOilCapacity.Text = ""; txtOilBDV.Text = ""; txtHTsideInsulation.Text = ""; txtLTSideInsulation.Text = "";
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
            txtOtherEarthing1.Visible = false; txtOtherEarthing6.Visible = false; txtOtherEarthing11.Visible = false; txtOtherEarthing16.Visible = false;
            txtOtherEarthing2.Visible = false; txtOtherEarthing7.Visible = false; txtOtherEarthing12.Visible = false; txtOtherEarthing17.Visible = false;
            txtOtherEarthing3.Visible = false; txtOtherEarthing8.Visible = false; txtOtherEarthing13.Visible = false; txtOtherEarthing18.Visible = false;
            txtOtherEarthing4.Visible = false; txtOtherEarthing9.Visible = false; txtOtherEarthing14.Visible = false; txtOtherEarthing19.Visible = false;
            txtOtherEarthing5.Visible = false; txtOtherEarthing10.Visible = false; txtOtherEarthing15.Visible = false; txtOtherEarthing20.Visible = false;


            InCaseOfOil.Visible = false;
            Capacity.Visible = false;
            BDV.Visible = false;

            SubstationEarthingDiv.Visible = false;
            TypeOfHTBreaker.Visible = false;

            FuseUnit.Visible = true;
            Breaker.Visible = false;
        }

        protected void ddlUsedFor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor1.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing1.Visible = true;
                RequiredFieldValidator99.Visible = true;
            }
            else
            {
                txtOtherEarthing1.Visible = false;
                RequiredFieldValidator99.Visible = false;

            }
        }

        protected void ddlUsedFor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor2.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing2.Visible = true;
                RequiredFieldValidator98.Visible = true;
            }
            else
            {
                txtOtherEarthing2.Visible = false;
                RequiredFieldValidator98.Visible = false;
            }
        }

        protected void ddlUsedFor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor3.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing3.Visible = true;
                RequiredFieldValidator97.Visible = true;
            }
            else
            {
                txtOtherEarthing3.Visible = false;
                RequiredFieldValidator97.Visible = false;
            }
        }

        protected void ddlUsedFor4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor4.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing4.Visible = true;
                RequiredFieldValidator96.Visible = false;
            }
            else
            {
                txtOtherEarthing4.Visible = false;
                RequiredFieldValidator96.Visible = false;
            }
        }

        protected void ddlUsedFor5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor5.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing5.Visible = true;
                RequiredFieldValidator95.Visible = true;
            }
            else
            {
                txtOtherEarthing5.Visible = false;
                RequiredFieldValidator95.Visible = false;
            }
        }

        protected void ddlUsedFor6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor6.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing6.Visible = true;
                RequiredFieldValidator79.Visible = true;
            }
            else
            {
                txtOtherEarthing6.Visible = false;
                RequiredFieldValidator79.Visible = false;
            }
        }
        protected void ddlUsedFor7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor7.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing7.Visible = true;
                RequiredFieldValidator75.Visible = true;
            }
            else
            {
                txtOtherEarthing7.Visible = false;
                RequiredFieldValidator75.Visible = false;
            }
        }

        protected void ddlUsedFor8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor8.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing8.Visible = true;
                RequiredFieldValidator71.Visible = true;
            }
            else
            {
                txtOtherEarthing8.Visible = false;
                RequiredFieldValidator71.Visible = false;
            }
        }

        protected void ddlUsedFor9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor9.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing9.Visible = true;
                RequiredFieldValidator67.Visible = true;
            }
            else
            {
                txtOtherEarthing9.Visible = false;
                RequiredFieldValidator67.Visible = false;
            }
        }

        protected void ddlUsedFor10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor10.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing10.Visible = true;
                RequiredFieldValidator63.Visible = true;
            }
            else
            {
                txtOtherEarthing10.Visible = false;
                RequiredFieldValidator63.Visible = false;
            }

        }

        protected void ddlUsedFor11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor11.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing11.Visible = true;
                RequiredFieldValidator59.Visible = true;
            }
            else
            {
                txtOtherEarthing11.Visible = false;
                RequiredFieldValidator59.Visible = false;
            }
        }

        protected void ddlUsedFor12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor12.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing12.Visible = true;
                RequiredFieldValidator55.Visible = true;
            }
            else
            {
                txtOtherEarthing12.Visible = false;
                RequiredFieldValidator55.Visible = false;
            }
        }

        protected void ddlUsedFor13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor13.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing13.Visible = true;
                RequiredFieldValidator51.Visible = true;
            }
            else
            {
                txtOtherEarthing13.Visible = false;
                RequiredFieldValidator51.Visible = false;
            }
        }

        protected void ddlUsedFor14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor14.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing14.Visible = true;
                RequiredFieldValidator47.Visible = true;
            }
            else
            {
                txtOtherEarthing14.Visible = false;
                RequiredFieldValidator47.Visible = false;
            }
        }

        protected void ddlUsedFor15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor15.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing15.Visible = true;
                RequiredFieldValidator23.Visible = true;
            }
            else
            {
                txtOtherEarthing15.Visible = false;
                RequiredFieldValidator23.Visible = false;
            }

        }

        protected void ddlUsedFor16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor16.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing16.Visible = true;
                RequiredFieldValidator25.Visible = true;
            }
            else
            {
                txtOtherEarthing16.Visible = false;
                RequiredFieldValidator25.Visible = false;
            }
        }

        protected void ddlUsedFor17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor17.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing17.Visible = true;
                RequiredFieldValidator28.Visible = true;
            }
            else
            {
                txtOtherEarthing17.Visible = false;
                RequiredFieldValidator28.Visible = false;
            }
        }

        protected void ddlUsedFor18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor18.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing18.Visible = true;
                RequiredFieldValidator35.Visible = true;
            }
            else
            {
                txtOtherEarthing18.Visible = false;
                RequiredFieldValidator35.Visible = false;
            }

        }

        protected void ddlUsedFor19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor19.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing19.Visible = true;
                RequiredFieldValidator39.Visible = true;
            }
            else
            {
                txtOtherEarthing19.Visible = false;
                RequiredFieldValidator39.Visible = false;
            }
        }

        protected void ddlUsedFor20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor20.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing20.Visible = true;
                RequiredFieldValidator43.Visible = true;
            }
            else
            {
                txtOtherEarthing20.Visible = false;
                RequiredFieldValidator43.Visible = false;
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
                    string mobilenumber = Contact.Trim();
                    Session["OTP"] = CEI.ValidateOTP(mobilenumber);
                }
                else
                {
                    if (Session["OTP"].ToString() == txtOTP.Text.Trim())
                    {
                        BtnSubmitSubstation.Attributes.Remove("disabled");
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
    }
}