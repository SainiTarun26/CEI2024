using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class ApplicationForLiftEscalators : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        string TypeOfApplicant, ApplicantName, Contact, OfficeAddress, ApplicantState, District, PinCode, LocalAgentName, AgentContact, AgentAddress, AgentState, AgentDistrict,
            AgentPinCode, LiftOwnerName, OwnerAddress, OwnerState, OwnerDistrict, OwnerPincode, DateOfEraction, TypeOfLift,
            MakerName, MakerLocalAgent, MakerAddress, ContractSpeed, ContractLoad, NumberofPersonCarring, TotalWightOfLift, CounterWeight,
            NumberOfSupensionRoops, SuspensionDiscription, SuspensionWeight, SuspensionSize, DepthOfPit, TravelNumberOfFloors, ConstrucationDetails;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Session["LiftId"] != null && Session["LiftId"].ToString() != "")
                    //{
                        ddlLoadBindApplicantState();
                        ddlLoadBindAgentState();
                        ddlLoadBindLiftState();
                   // }
                    //else
                    //{
                    //    Response.Redirect("/Login.aspx");
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ddlLoadBindApplicantState()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetddlDrawState();
                ddlApplicantState.DataSource = ds;
                ddlApplicantState.DataTextField = "StateName";
                ddlApplicantState.DataValueField = "StateID";
                ddlApplicantState.DataBind();
                ddlApplicantState.Items.Insert(0, new ListItem("Select", "0"));
                ds.Clear();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void ddlLoadBindAgentState()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetddlDrawState();
                ddlAgentState.DataSource = ds;
                ddlAgentState.DataTextField = "StateName";
                ddlAgentState.DataValueField = "StateID";
                ddlAgentState.DataBind();
                ddlAgentState.Items.Insert(0, new ListItem("Select", "0"));
                ds.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ddlLoadBindLiftState()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetddlDrawState();
                ddlLiftState.DataSource = ds;
                ddlLiftState.DataTextField = "StateName";
                ddlLiftState.DataValueField = "StateID";
                ddlLiftState.DataBind();
                ddlLiftState.Items.Insert(0, new ListItem("Select", "0"));
                ds.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void ddlApplicantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindapplicantdistrict(ddlApplicantState.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ddlLoadBindapplicantdistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlapplicantdistrict.DataSource = dsDistrict;
                ddlapplicantdistrict.DataTextField = "District";
                ddlapplicantdistrict.DataValueField = "District";
                ddlapplicantdistrict.DataBind();
                ddlapplicantdistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected void ddlAgentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindAgentDistrict(ddlAgentState.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ddlLoadBindAgentDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                dllAgentdistrict.DataSource = dsDistrict;
                dllAgentdistrict.DataTextField = "District";
                dllAgentdistrict.DataValueField = "District";
                dllAgentdistrict.DataBind();
                dllAgentdistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void ddlLiftState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindLiftDistrict(ddlLiftState.SelectedItem.ToString());
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ddlLoadBindLiftDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlLiftDistrict.DataSource = dsDistrict;
                ddlLiftDistrict.DataTextField = "District";
                ddlLiftDistrict.DataValueField = "District";
                ddlLiftDistrict.DataBind();
                ddlLiftDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {


                string userId = Session["LiftID"].ToString();
                if (userId != null)
                {
                    GetFormData();
                    //CEI.InsertListAndEscalators(userId, ddlApplicantType.SelectedItem.ToString(), txtNameOfApplicant.Text.Trim(), txtPhoneNo.Text.Trim(),
                    //  txtOfficeAddress.Text.Trim(), ddlApplicantState.SelectedItem.ToString(), ddlapplicantdistrict.SelectedItem.ToString(), txtPinCode.Text.Trim(),
                    //  txtAgentName.Text.Trim(), txtAgentContactNo.Text.Trim(), txtAgentAddress.Text.Trim(), ddlAgentState.SelectedValue == "0" ? null : ddlAgentState.SelectedItem.ToString(),
                    //  dllAgentdistrict.SelectedValue == "0" ? null : dllAgentdistrict.SelectedItem.ToString(), txtAgentPincode.Text.Trim(), txtOwnerName.Text.Trim(),
                    //  txtLiftAddress.Text.Trim(), ddlLiftState.SelectedItem.ToString(), ddlLiftDistrict.SelectedItem.ToString(), txtLiftPincode.Text.Trim(), txtDateOfErection.Text.Trim(),
                    //  txtTypeOfLift.Text.Trim(), txtMakerName.Text.Trim(), txtMakerLocalAgent.Text.Trim(), txtMakerAddress.Text.Trim(), txtLiftSpeed.Text.Trim(), txtLiftLoad.Text.Trim(),
                    //  txtPersonLoad.Text.Trim(), txtLiftWeight.Text.Trim(), txtCounterWeight.Text.Trim(), txtNumberSuspension.Text.Trim(), txtDiscription.Text.Trim(), txtWeight.Text.Trim(),
                    //  txtSize.Text.Trim(), txtPitDepth.Text.Trim(), txtTotalFloors.Text.Trim(), txtConstructionDetails.Text.Trim());

                    CEI.InsertListAndEscalators(userId, TypeOfApplicant, ApplicantName, Contact,
                      OfficeAddress, ApplicantState, District, PinCode,
                      LocalAgentName, AgentContact, AgentAddress, AgentState,
                      AgentDistrict, AgentPinCode, LiftOwnerName,
                      OwnerAddress, OwnerState, OwnerDistrict, OwnerPincode, DateOfEraction,
                      TypeOfLift, MakerName, MakerLocalAgent,MakerAddress, ContractSpeed, ContractLoad,
                      NumberofPersonCarring,TotalWightOfLift, CounterWeight, SuspensionWeight, SuspensionDiscription, SuspensionWeight,
                      SuspensionSize, DepthOfPit, TravelNumberOfFloors, ConstrucationDetails);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert('Application for Lift and Escalators added successfully!! ')", true);                   
                    Response.Redirect("DocumentsForLift.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetFormData()
        {
            TypeOfApplicant = ddlApplicantType.SelectedItem.ToString();
            ApplicantName = txtNameOfApplicant.Text.Trim();
            Contact = txtPhoneNo.Text.Trim();
            OfficeAddress = txtOfficeAddress.Text.Trim();
            ApplicantState = ddlApplicantState.SelectedItem.ToString();
            District = ddlapplicantdistrict.SelectedItem.ToString();
            PinCode = txtPinCode.Text.Trim();

            LocalAgentName = txtAgentName.Text.Trim();
            AgentContact = txtAgentContactNo.Text.Trim();
            AgentAddress = txtAgentAddress.Text.Trim();
            AgentState = ddlAgentState.SelectedItem.ToString();
            AgentDistrict = dllAgentdistrict.SelectedItem.ToString();
            AgentPinCode = txtAgentPincode.Text.Trim(); 

            LiftOwnerName = txtOwnerName.Text.Trim();
            OwnerAddress = txtLiftAddress.Text.Trim();
            OwnerState = ddlLiftState.SelectedItem.ToString();
            OwnerDistrict = ddlLiftDistrict.SelectedItem.ToString();
            OwnerPincode = txtLiftPincode.Text.Trim();
            DateOfEraction = txtDateOfErection.Text.Trim();
            TypeOfLift = txtTypeOfLift.Text.Trim();

            MakerName = txtMakerName.Text.Trim();
            MakerLocalAgent = txtMakerLocalAgent.Text.Trim();
            MakerAddress = txtMakerAddress.Text.Trim();
            ContractSpeed = txtLiftSpeed.Text.Trim();
            ContractLoad = txtLiftLoad.Text.Trim();
            NumberofPersonCarring = txtPersonLoad.Text.Trim();
            TotalWightOfLift = txtLiftWeight.Text.Trim();
            CounterWeight = txtCounterWeight.Text.Trim();

            NumberOfSupensionRoops = txtNumberSuspension.Text.Trim();
            SuspensionDiscription = txtDiscription.Text.Trim();
            SuspensionWeight = txtWeight.Text.Trim();
            SuspensionSize = txtSize.Text.Trim();
            DepthOfPit = txtPitDepth.Text.Trim();
            TravelNumberOfFloors = txtTotalFloors.Text.Trim();
            ConstrucationDetails = txtConstructionDetails.Text.Trim();

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["LiftId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/AdminLogout.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdminLogout.aspx", false);
        }
    }
}