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
    public partial class GeneratingSetTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlEarthing();
                SessionValue();
                PageWorking();

            }
        }
        private void ddlEarthing()
        {
            try
            {

                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthingSubstation();
                ddlGeneratingEarthing.DataSource = dsEarthing;
                ddlGeneratingEarthing.DataTextField = "NumberOfEarthing";
                ddlGeneratingEarthing.DataValueField = "NumberOfEarthing";
                ddlGeneratingEarthing.DataBind();
                ddlGeneratingEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void ddlGeneratingSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingSetType.SelectedValue == "3")
            {
                SolarPanelGeneratingSet.Visible = true;
               // ddlGeneratingEarthing.SelectedValue = "0";             
                GeneratingEarthing.Visible = false;
            }
            else
            {
                SolarPanelGeneratingSet.Visible = false;
            }

        }
        protected void ddlGeneratingEarthing_SelectedIndexChanged(object sender, EventArgs e)

        {
            GeneratingEarthing.Visible = true;
            GeneratingEarthing4.Visible = false;
            GeneratingEarthing5.Visible = false;
            GeneratingEarthing6.Visible = false;
            GeneratingEarthing7.Visible = false;
            GeneratingEarthing8.Visible = false;
            GeneratingEarthing9.Visible = false;
            GeneratingEarthing10.Visible = false;
            GeneratingEarthing11.Visible = false;
            GeneratingEarthing12.Visible = false;
            GeneratingEarthing13.Visible = false;
            GeneratingEarthing14.Visible = false;
            GeneratingEarthing15.Visible = false;
            Limit.Visible = false;
            if (ddlGeneratingEarthing.SelectedItem.ToString() == "4")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "5")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "6")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "7")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "8")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "9")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "10")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "11")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "12")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "13")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "14")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "15")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
                GeneratingEarthing15.Visible = true;
            }

            
               
            

        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == false)
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }
        protected void BtnSubmitGeneratingSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (Declaration.Visible == true && CheckBox3.Checked == false)
                {
                    
                        label2.Visible = true;
                    
                }
                else
                {
                    string GeneratingSetId = string.Empty;
                    if (Convert.ToString(Session["GeneratingSetId"]) == null || Convert.ToString(Session["GeneratingSetId"]) == "")
                    {
                        GeneratingSetId = CEI.GenerateUniqueGeneratingSetId();
                        Session["GeneratingSetId"] = GeneratingSetId;

                    }
                    else
                    {

                        GeneratingSetId = Session["GeneratingSetId"].ToString();
                    }
                    string TestReportId = Session["TestReportId"].ToString();
                    string IntimationId = Session["id"].ToString();
                    string CreatedBy = Session["SupervisorID"].ToString();
                    CEI.InsertGeneratingSetData(GeneratingSetId, TestReportId, IntimationId,
                        ddlCapacity.SelectedItem.ToString(), txtCapacity.Text, txtSerialNoOfGenerator.Text, ddlGeneratingSetType.SelectedItem.ToString(),
               txtGeneratorVoltage.Text, txtCurrentCapacity.Text, txtBreakingCapacity.Text, ddlPlantType.SelectedItem.ToString(), ddlPlantCapacity.SelectedItem.ToString(),
              txtPlantCapacity.Text, txtDCString.Text, txtLowestInsulation.Text, txtPCVOrSolar.Text, txtLTACCapacity.Text, txtLowestInsulationAC.Text,
              ddlGeneratingEarthing.SelectedItem.ToString(), ddlGeneratingEarthing1.SelectedItem.ToString(), txtGeneratingEarthing1.Text, ddlGeneratingEarthingUsed1.SelectedItem.ToString(), txtOtherEarthing1.Text,
              ddlGeneratingEarthing2.SelectedItem.ToString(), txtGeneratingEarthing2.Text, ddlGeneratingEarthingUsed2.SelectedItem.ToString(), txtOtherEarthing2.Text, ddlGeneratingEarthing3.SelectedItem.ToString(), txtGeneratingEarthing3.Text, ddlGeneratingEarthingUsed3.SelectedItem.ToString(), txtOtherEarthing3.Text,
             ddlGeneratingEarthing4.SelectedItem.ToString(), txtGeneratingEarthing4.Text, ddlGeneratingEarthingUsed4.SelectedItem.ToString(), txtOtherEarthing4.Text, ddlGeneratingEarthing5.SelectedItem.ToString(), txtGeneratingEarthing5.Text, ddlGeneratingEarthingUsed5.SelectedItem.ToString(), txtOtherEarthing5.Text,
          ddlGeneratingEarthing6.SelectedItem.ToString(), txtGeneratingEarthing6.Text, ddlGeneratingEarthingUsed6.SelectedItem.ToString(), txtOtherEarthing6.Text, ddlGeneratingEarthing7.SelectedItem.ToString(), txtGeneratingEarthing7.Text, ddlGeneratingEarthingUsed7.SelectedItem.ToString(), txtOtherEarthing7.Text,
          ddlGeneratingEarthing8.SelectedItem.ToString(), txtGeneratingEarthing8.Text, ddlGeneratingEarthingUsed8.SelectedItem.ToString(), txtOtherEarthing8.Text, ddlGeneratingEarthing9.SelectedItem.ToString(), txtGeneratingEarthing9.Text, ddlGeneratingEarthingUsed9.SelectedItem.ToString(), txtOtherEarthing9.Text,
           ddlGeneratingEarthing10.SelectedItem.ToString(), txtGeneratingEarthing10.Text, ddlGeneratingEarthingUsed10.SelectedItem.ToString(), txtOtherEarthing10.Text, ddlGeneratingEarthing11.SelectedItem.ToString(), txtGeneratingEarthing11.Text, ddlGeneratingEarthingUsed11.SelectedItem.ToString(), txtOtherEarthing11.Text,
            ddlGeneratingEarthing12.SelectedItem.ToString(), txtGeneratingEarthing12.Text, ddlGeneratingEarthingUsed12.SelectedItem.ToString(), txtOtherEarthing12.Text, ddlGeneratingEarthing13.SelectedItem.ToString(), txtGeneratingEarthing13.Text, ddlGeneratingEarthingUsed13.SelectedItem.ToString(), txtOtherEarthing13.Text,
           ddlGeneratingEarthing14.SelectedItem.ToString(), txtGeneratingEarthing14.Text, ddlGeneratingEarthingUsed14.SelectedItem.ToString(), txtOtherEarthing14.Text, ddlGeneratingEarthing15.SelectedItem.ToString(), txtGeneratingEarthing15.Text, ddlGeneratingEarthingUsed15.SelectedItem.ToString(), txtOtherEarthing15.Text, CreatedBy);
                    Session["Page"] = Convert.ToInt32(Session["Page"]) + 1;
                    Reset();
                    DataSaved.Visible = true;
                    label2.Visible = false;
                    PageWorking();
                    int currentValue = Convert.ToInt32(Session["Page"]);
                    if (currentValue == Convert.ToInt32(sessionValue))
                    {
                        Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
                        BtnSubmitGeneratingSet.Visible = false;
                        Session["SubmittedValue3"] = sessionValue;
                        divGeneratingSet.Visible = false;
                        Session["GeneratingSetId"] = "";
                        Session["TestReportId"] = TestReportId;
                        Page.Session["Page"] = 0;
                        NextSessionValueAndName();
                        if (nextSessionName.Trim() == "Line")
                        {
                            Response.Redirect("LineTestReport.aspx");
                        }
                        else if (nextSessionName.Trim() == "Substation Transformer")
                        {
                            Response.Redirect("SubstationTransformer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been submitted and is under review by the Contractor for final submission')", true);

                        }
                    }
                }

            }
            catch (Exception)
            {

                DataSaved.Visible = false;
            }
        }
        public void Reset()
        {
            ddlCapacity.SelectedValue = "0"; txtCapacity.Text = ""; txtSerialNoOfGenerator.Text = ""; ddlGeneratingSetType.SelectedValue = "0";
            txtGeneratorVoltage.Text = ""; txtCurrentCapacity.Text = ""; txtBreakingCapacity.Text = ""; ddlPlantType.SelectedValue = "0"; ddlPlantCapacity.SelectedValue = "0";
            txtPlantCapacity.Text = ""; txtDCString.Text = ""; txtLowestInsulation.Text = ""; txtPCVOrSolar.Text = ""; txtLTACCapacity.Text = ""; txtLowestInsulationAC.Text = "";
            ddlGeneratingEarthing.SelectedValue = "0"; ddlGeneratingEarthing1.SelectedValue = "0"; txtGeneratingEarthing1.Text = ""; ddlGeneratingEarthingUsed1.SelectedValue = "0"; txtOtherEarthing1.Text = "";
            ddlGeneratingEarthing2.SelectedValue = "0"; txtGeneratingEarthing2.Text = ""; ddlGeneratingEarthingUsed2.SelectedValue = "0"; txtOtherEarthing2.Text = ""; ddlGeneratingEarthing3.SelectedValue = "0"; txtGeneratingEarthing3.Text = ""; ddlGeneratingEarthingUsed3.SelectedValue = "0"; txtOtherEarthing3.Text = "";
            ddlGeneratingEarthing4.SelectedValue = "0"; txtGeneratingEarthing4.Text = ""; ddlGeneratingEarthingUsed4.SelectedValue = "0"; txtOtherEarthing4.Text = ""; ddlGeneratingEarthing5.SelectedValue = "0"; txtGeneratingEarthing5.Text = ""; ddlGeneratingEarthingUsed5.SelectedValue = "0"; txtOtherEarthing5.Text = "";
            ddlGeneratingEarthing6.SelectedValue = "0"; txtGeneratingEarthing6.Text = ""; ddlGeneratingEarthingUsed6.SelectedValue = "0"; txtOtherEarthing6.Text = ""; ddlGeneratingEarthing7.SelectedValue = "0"; txtGeneratingEarthing7.Text = ""; ddlGeneratingEarthingUsed7.SelectedValue = "0"; txtOtherEarthing7.Text = "";
            ddlGeneratingEarthing8.SelectedValue = "0"; txtGeneratingEarthing8.Text = ""; ddlGeneratingEarthingUsed8.SelectedValue = "0"; txtOtherEarthing8.Text = ""; ddlGeneratingEarthing9.SelectedValue = "0"; txtGeneratingEarthing9.Text = ""; ddlGeneratingEarthingUsed9.SelectedValue = "0"; txtOtherEarthing9.Text = "";
            ddlGeneratingEarthing10.SelectedValue = "0"; txtGeneratingEarthing10.Text = ""; ddlGeneratingEarthingUsed10.SelectedValue = "0"; txtOtherEarthing10.Text = ""; ddlGeneratingEarthing11.SelectedValue = "0"; txtGeneratingEarthing11.Text = ""; ddlGeneratingEarthingUsed11.SelectedValue = "0"; txtOtherEarthing11.Text = "";
            ddlGeneratingEarthing12.SelectedValue = "0"; txtGeneratingEarthing12.Text = ""; ddlGeneratingEarthingUsed12.SelectedValue = "0"; txtOtherEarthing12.Text = ""; ddlGeneratingEarthing13.SelectedValue = "0"; txtGeneratingEarthing13.Text = ""; ddlGeneratingEarthingUsed13.SelectedValue = "0"; txtOtherEarthing13.Text = "";
            ddlGeneratingEarthing14.SelectedValue = "0"; txtGeneratingEarthing14.Text = ""; ddlGeneratingEarthingUsed14.SelectedValue = "0"; txtOtherEarthing14.Text = ""; ddlGeneratingEarthing15.SelectedValue = "0"; txtGeneratingEarthing15.Text = ""; ddlGeneratingEarthingUsed15.SelectedValue = "0"; txtOtherEarthing15.Text = "";

            txtOtherEarthing3.Visible = false; txtOtherEarthing11.Visible = false; txtOtherEarthing2.Visible = false; txtOtherEarthing10.Visible = false;
            txtOtherEarthing5.Visible = false; txtOtherEarthing13.Visible = false; txtOtherEarthing4.Visible = false; txtOtherEarthing12.Visible = false;
            txtOtherEarthing7.Visible = false; txtOtherEarthing15.Visible = false; txtOtherEarthing6.Visible = false; txtOtherEarthing14.Visible = false;
            txtOtherEarthing9.Visible = false; txtOtherEarthing8.Visible = false; txtOtherEarthing1.Visible = false;

            SolarPanelGeneratingSet.Visible = false;
            GeneratingEarthing.Visible = false;

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
                     
                    }
                    else
                    {
                        nextSessionName = "";
                        nextSessionValue = "";
                    }

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
        public void PageWorking()
        {
            SessionValue();
            x = Convert.ToInt32(Session["Page"]);
            if (x + 1 == int.Parse(sessionValue) && nextSessionName == "")
            {
                Declaration.Visible = true;
                BtnSubmitGeneratingSet.Text = "Submit";
                BtnSubmitGeneratingSet.Attributes.Add("disabled", "true");
                btnVerify.Visible = true;
            }
            else
            {
                Declaration.Visible = false;
                BtnSubmitGeneratingSet.Text = "Next";
            }
        }
        protected void ddlGeneratingEarthingUsed1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed1.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing1.Visible = true;
            }
            else
            {
                txtOtherEarthing1.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed2.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing2.Visible = true;
            }
            else
            {
                txtOtherEarthing2.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed3.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing3.Visible = true;
            }
            else
            {
                txtOtherEarthing3.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed4.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing4.Visible = true;
            }
            else
            {
                txtOtherEarthing4.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed5.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing5.Visible = true;
            }
            else
            {
                txtOtherEarthing5.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed6.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing6.Visible = true;
            }
            else
            {
                txtOtherEarthing6.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed7.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing7.Visible = true;
            }
            else
            {
                txtOtherEarthing7.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed8.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing8.Visible = true;
            }
            else
            {
                txtOtherEarthing8.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed10.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing10.Visible = true;
            }
            else
            {
                txtOtherEarthing10.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed11.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing11.Visible = true;
            }
            else
            {
                txtOtherEarthing11.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed12.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing12.Visible = true;
            }
            else
            {
                txtOtherEarthing12.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed13.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing13.Visible = true;
            }
            else
            {
                txtOtherEarthing13.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed14.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing14.Visible = true;
            }
            else
            {
                txtOtherEarthing14.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed15.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing15.Visible = true;
            }
            else
            {
                txtOtherEarthing15.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed9.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing9.Visible = true;
            }
            else
            {
                txtOtherEarthing9.Visible = false;
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
                        BtnSubmitGeneratingSet.Attributes.Remove("disabled");
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