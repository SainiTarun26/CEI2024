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
    public partial class SiteOwner : System.Web.UI.MasterPage
    {

        CEI CEI = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //GetContractorNotifications();
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty && Request.Cookies["SiteOwnerId"] != null)
                {
                    GetContractorNotifications();
                    if (Request.Cookies["SiteOwnerId"] != null)
                    {
                        DataSet ds = new DataSet();
                        ds = CEI.GetDataAtSiteOwnerPowerutility(Convert.ToString(Session["SiteOwnerId"]));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            powerutilitySiteowner1.Visible = true;
                            powerutilitySiteowner2.Visible = true;
                            SelfCertification.Visible = false;
                            SelfStatus.Visible = false;
                            //Added by  neeraj 29-May-2025
                            DisconnectionRequest.Visible = true;
                            DisconnectionStatus.Visible = true;
                            //Added by gurmeet 29-May-2025
                            Cinema_Sidebar.Visible = false;
                        }
                        lblName.Text = Request.Cookies["SiteOwnerId"].Value;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = CEI.GetDataAtSiteOwnerPowerutility(Convert.ToString(Session["SiteOwnerId"]));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            powerutilitySiteowner1.Visible = true;
                            powerutilitySiteowner2.Visible = true;
                            SelfCertification.Visible = false;
                            SelfStatus.Visible = false;
                            //Added by neeraj 29-May-2025
                            DisconnectionRequest.Visible = true;
                            DisconnectionStatus.Visible = true;
                            //Added by gurmeet 29-May-2025
                            Cinema_Sidebar.Visible = false;
                        }
                        lblName.Text = Convert.ToString(Session["SiteOwnerId"]);
                    }

                }
                else if (Session["SiteOwnerId"] == null)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.Cache.SetNoStore();
                    Response.Redirect("/SiteOwnerLogout.aspx");
                }
                else
                {

                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx");
                }
            }
            catch (Exception Ex)
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["SiteOwnerId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/SiteOwnerLogout.aspx");
        }
        public void GetContractorNotifications()
        {
            REID = Session["SiteOwnerId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetSiteOwnerNotifications(REID);
            TextBoxPlaceholder.Controls.Clear();

            int rowIndex = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string dynamicData = row["InspectionGeneratedId"].ToString();
                    string dynamicData2 = row["ReasonForRejection"].ToString();
                    string dynamicData3 = row["ApplicationStatus"].ToString();

                    // Create a new TextBox control for each data item
                    TextBox textBox = new TextBox
                    {
                        ID = "TextBox_" + rowIndex,
                        CssClass = "form-control notification-box font-weight-light small-text mb-0 text-muted",
                        Text = dynamicData + " Inspection is : " + dynamicData3,
                        TextMode = TextBoxMode.MultiLine,
                        Rows = 2,
                        ReadOnly = true
                        // WStyle = "font-size: 12px;"
                    };

                    // Add the TextBox to the placeholder
                    TextBoxPlaceholder.Controls.Add(textBox);
                    textBox.Attributes["style"] = "width: 250px;";
                    // Add a line break between TextBoxes
                    TextBoxPlaceholder.Controls.Add(new LiteralControl("<br />"));

                    rowIndex++;

                }
            }


            else
            {
                TextBox textBox = new TextBox
                {
                    ID = "TextBox_" + rowIndex,
                    CssClass = "form-control notification-box font-weight-light small-text mb-0 text-muted",
                    Text = "No New Notifications",
                    TextMode = TextBoxMode.MultiLine,
                    Rows = 2,
                    ReadOnly = true
                };
                TextBoxPlaceholder.Controls.Add(textBox);
                textBox.Attributes["style"] = "width: 250px;";
                TextBoxPlaceholder.Controls.Add(new LiteralControl("<br />"));

                rowIndex++;

            }

        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string UserId = Session["SiteOwnerId"].ToString();
            Response.Redirect("/ChangePassword.aspx");
        }
    }
}