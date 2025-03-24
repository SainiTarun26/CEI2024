using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class InProcessRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        public void GridBind()
        {

            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InProcessRequest(LoginID);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            ds.Dispose();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {  
            try
              {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblInstallationfor = (Label)row.FindControl("lblInstallationfor");
                    Label LblInspectionCount = (Label)row.FindControl("LblInspectionCount");
                    string id = lblID.Text;
                    Session["InProcessInspectionId"] = id;
                    if (e.CommandName == "Select")
                    {
                        if (lblInstallationfor.Text.Trim() == "Lift" || lblInstallationfor.Text.Trim() == "Escalator" || lblInstallationfor.Text.Trim() == "MultiLift" || lblInstallationfor.Text.Trim() == "MultiEscalator" || lblInstallationfor.Text.Trim() == "Lift/Escalator")
                        {
                            if (int.TryParse(LblInspectionCount.Text, out int count) && count > 1)
                            {

                                Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                                return;

                            }
                            else
                            {
                                Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                                return;
                            }
                        }
                        //if (int.TryParse(LblInspectionCount.Text, out int count) && count > 1)
                        //{

                        //    Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                        //    return;

                        //}

                        //else   if (lblInstallationfor.Text.Trim() == "Lift" || lblInstallationfor.Text.Trim() == "Escalator" || lblInstallationfor.Text.Trim() == "MultiLift" || lblInstallationfor.Text.Trim() == "MultiEscalator" || lblInstallationfor.Text.Trim() == "Lift/Escalator")
                        //{
                        //    Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                        //    return;
                        //}

                        else
                        {
                            Response.Redirect("/Officers/InProcessInspection.aspx", false);
                        }


                    }
                }
            }
            catch (Exception ex) 
            {
            //
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}