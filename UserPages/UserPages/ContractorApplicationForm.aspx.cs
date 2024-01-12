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
    public partial class ContractorApplicationForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlLoadBindState();
            }
        }

        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
               DropDownList6.DataSource = dsState;
               DropDownList6.DataTextField = "StateName";
               DropDownList6.DataValueField = "StateID";
               DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindDistrict(DropDownList6.SelectedItem.ToString());
            }
            catch { }

        }

        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                DropDownList5.DataSource = dsDistrict;
                DropDownList5.DataTextField = "District";
                DropDownList5.DataValueField = "District";
                DropDownList5.DataBind();
                DropDownList5.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }




    }
}