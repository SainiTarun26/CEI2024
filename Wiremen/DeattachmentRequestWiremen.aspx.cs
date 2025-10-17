using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Wiremen
{
    public partial class DeattachmentRequestWiremen : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != string.Empty)
                    {
                        hdnId.Value = Session["WiremanId"].ToString();
                        GridBind(hdnId.Value);


                    }
                    else
                    {
                        Session["WiremanId"] = "";
                        Response.Redirect("/SupervisorLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void GridBind(string Wiremen)
        {
            try
            {

                DataTable ds = new DataTable();
                ds = CEI.GetSupervisiorRequest(Wiremen);
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No any Request For Attachment-DeAttachment.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Label lblRequestFor = (Label)row.FindControl("lblRequestFor");

            if (e.CommandName == "Select")
            {
                if (lblRequestFor.Text == "DeAttached")
                {
                    Session["Id"] = lblID.Text;
                    Response.Redirect("/Wiremen/DeAttachedRequestViewWiremen.aspx", false);
                }
                else if (lblRequestFor.Text == "Attached")
                {
                    Session["Id"] = lblID.Text;
                    Response.Redirect("/Wiremen/AttachedRequestViewDetailsWiremen.aspx", false);
                }
            }

        }
    }
}