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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LiftId"] != null) 
                    {

                        ddlLoadBindApplicantState();
                        ddlLoadBindAgentState();
                        ddlLoadBindLiftState();
                    }
                    else
                    {

                    }
                }
            }
            catch 
            {
                Response.Redirect("/Login.aspx");
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

                throw;
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

                throw;
            }

        }

        protected void ddlApplicantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindapplicantdistrict(ddlApplicantState.SelectedItem.ToString());
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
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
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }

        }
        protected void ddlAgentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindAgentDistrict(ddlAgentState.SelectedItem.ToString());
            }
            catch { }
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
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }

        }

        protected void ddlLiftState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindLiftDistrict(ddlLiftState.SelectedItem.ToString());
            }
            catch { }
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
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {


                string userId = Session["LiftID"].ToString();

                CEI.InsertListAndEscalators(userId, ddlApplicantType.SelectedItem.ToString(), txtNameOfApplicant.Text.Trim(), txtPhoneNo.Text.Trim(),
                  txtOfficeAddress.Text.Trim(), ddlApplicantState.SelectedItem.ToString(), ddlapplicantdistrict.SelectedItem.ToString(), txtPinCode.Text.Trim(),
                  txtAgentName.Text.Trim(), txtAgentContactNo.Text.Trim(), txtAgentAddress.Text.Trim(), ddlAgentState.SelectedValue == "0" ? null : ddlAgentState.SelectedItem.ToString(),
                  dllAgentdistrict.SelectedValue == "0" ? null : dllAgentdistrict.SelectedItem.ToString(), txtAgentPincode.Text.Trim(), txtOwnerName.Text.Trim(),
                  txtLiftAddress.Text.Trim(), ddlLiftState.SelectedItem.ToString(), ddlLiftDistrict.SelectedItem.ToString(), txtLiftPincode.Text.Trim(), txtDateOfErection.Text.Trim(),
                  txtTypeOfLift.Text.Trim(), txtMakerName.Text.Trim(), txtMakerLocalAgent.Text.Trim(), txtMakerAddress.Text.Trim(), txtLiftSpeed.Text.Trim(), txtLiftLoad.Text.Trim(),
                  txtPersonLoad.Text.Trim(), txtLiftWeight.Text.Trim(), txtCounterWeight.Text.Trim(), txtNumberSuspension.Text.Trim(), txtDiscription.Text.Trim(), txtWeight.Text.Trim(),
                  txtSize.Text.Trim(), txtPitDepth.Text.Trim(), txtTotalFloors.Text.Trim(), txtConstructionDetails.Text.Trim()
                    );
            }
            catch
            {

            }
        }
    }
}