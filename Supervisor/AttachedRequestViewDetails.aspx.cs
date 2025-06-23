using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class AttachedRequestViewDetails : System.Web.UI.Page
    {
        //Page created y Neeraj on 23-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != string.Empty && Convert.ToString(Session["Id"]) != null && Convert.ToString(Session["Id"]) != string.Empty)
                    {
                        hdnSupervisiorId.Value = Session["SupervisorID"].ToString();
                        hdnId.Value = Session["Id"].ToString();
                        GetContractorDetails(hdnId.Value);
                    }
                    else
                    {
                        Session["SupervisorID"] = "";
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
        public void GetContractorDetails(string Id)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetContractorDetailsForAttachedRequest(Id);
            if (dt.Rows.Count > 0)
            {
                txtContractorName.Text = dt.Rows[0]["Name"].ToString();
                txtLicenceNo.Text = dt.Rows[0]["UserId"].ToString();
                txtFirmName.Text = dt.Rows[0]["FirmName"].ToString();
                TxtEmailId.Text = dt.Rows[0]["Email"].ToString();
                TxtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                hdnFile.Value = dt.Rows[0]["Attachment"].ToString();
            }
            else
            {
                //  btnToDeattach.Visible = false;
                string script = $"alert('Not attached any Contractor.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                return;
            }

        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = hdnFile.Value.ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);


            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Supervisor/DeattachmentRequest.aspx", false);
        }
    }
}