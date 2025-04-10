using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SelfCertification : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
                    {
                        hdnOwnerId.Value = Session["SiteOwnerId"].ToString();
                        ddlLoadBindVoltage();
                    }
                }
            }
            catch
            { }
        }

        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageLevel();
            ddlVoltage.DataSource = dsVoltage;
            ddlVoltage.DataTextField = "Voltagelevel";
            ddlVoltage.DataValueField = "VoltageID";
            ddlVoltage.DataBind();
            ddlVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }
        protected void chkOtherOption_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOtherOption.Checked)
            {
                OtherInstallation.Visible = true;
            }
            else
            {
                OtherInstallation.Visible = false;
            }
        }
    }
}