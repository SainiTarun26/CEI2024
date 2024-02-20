using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class SupervisorLicenceUpgradation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    ddlLoadBindState();
                    GetSupervisorDataForUpgradeation();
                }
            }
        }
        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                DdlState.DataSource = dsState;
                DdlState.DataTextField = "StateName";
                DdlState.DataValueField = "StateID";
                DdlState.DataBind();
                DdlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                DdlDistrict.DataSource = dsDistrict;
                DdlDistrict.DataTextField = "District";
                DdlDistrict.DataValueField = "District";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        private void GetSupervisorDataForUpgradeation()
        {
            string SuperviserId= Session["SupervisorID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetSupervisorDataForRenewal(SuperviserId);
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0)
            {
                txtName.Text = ds.Tables[0].Rows[0][""].ToString();
            }            
        }

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlState.SelectedValue != null && DdlState.SelectedValue=="0")
            {
                ddlLoadBindDistrict(DdlState.SelectedItem.ToString());
            }
        }
    }
}