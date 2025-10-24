using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class Deattatch_Supervisor : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != null
                        && Convert.ToString(Session["SupervisorRequestId_Deattachment"]) != null && Convert.ToString(Session["SupervisorRequestId_Deattachment"]) != null)
                    {
                        hdnSupervisorRequestID.Value = Convert.ToString(Session["SupervisorRequestId_Deattachment"]);
                        GetDataSUpervisor(Convert.ToString(Session["SupervisorRequestId_Deattachment"]));
                        Page.Session["DoubleClick_Btn"] = "1";
                    }
                    else
                    {
                        Response.Redirect("/Logout.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void GetDataSUpervisor(string RequestId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cei.GetDetailsForDeattachedSupervisor(RequestId);
                if (dt.Rows.Count > 0)
                {
                    txtSupervisorName.Text = dt.Rows[0]["Name"].ToString();
                    txtSupervisorLicence.Text = dt.Rows[0]["SupervisorLicence"].ToString();              
                    lblCategory.Text  = dt.Rows[0]["Category"].ToString();
                    txtLicenceExpiry.Text = dt.Rows[0]["DateofExpiry"].ToString();
                    txtLicenceIssue.Text = dt.Rows[0]["DateofIntialissue"].ToString();
                    txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    txtvotagelevel.Text = dt.Rows[0]["votagelevel"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtvoltageWithEffect.Text = dt.Rows[0]["voltageWithEffect"].ToString();
                    txtRemarks.Text= dt.Rows[0]["Remarks"].ToString();
                    string RequestFor = dt.Rows[0]["RequestFor"].ToString();
                    HdnContractorEmail.Value= dt.Rows[0]["ContractorEmail"].ToString();
                    HdnSupervisorEmail.Value = dt.Rows[0]["Email"].ToString();

                    if (RequestFor== "Attached")
                    {
                        btnToDeattach.Text = "Attached";
                        lblrequest.Text = "Attachment Request";
                    }
                    else
                    {
                        btnToDeattach.Text = "DeAttached";
                        lblrequest.Text = "DeAttachment Request";
                    }                 
                    hdnFeildDocumnet.Value= dt.Rows[0]["Attachment"].ToString();
                    //hdnfeildRequestFor.Value = RequestFor;



                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        protected void btnToDeattach_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != null)
                {
                    if (Convert.ToString(Session["DoubleClick_Btn"]) == "1")
                    {
                        string UserId = Convert.ToString(Session["ContractorID"]);
                        if (hdnSupervisorRequestID.Value != null && hdnSupervisorRequestID.Value != ""
                            && HdnContractorEmail.Value != null && HdnContractorEmail.Value != ""
                            && HdnSupervisorEmail.Value != null && HdnSupervisorEmail.Value != "")
                        {
                            string ContractorId = string.Empty;
                            string SupervisorREID = string.Empty;

                            DataTable dt = new DataTable();
                            dt = cei.GetDetailsForDeattachedSupervisor(hdnSupervisorRequestID.Value.ToString());
                            if (dt.Rows.Count > 0)
                            {
                                SupervisorREID = dt.Rows[0]["SupervisiorReId"].ToString();
                                ContractorId = dt.Rows[0]["contractorId"].ToString();
                            }
                            int x = 0;
                            string AlertMessage = string.Empty;
                            if (btnToDeattach.Text == "Attached")
                            {
                                x = cei.AttachedbyContractor(ContractorId, SupervisorREID, UserId);
                                AlertMessage = "Attached";
                            }
                            else
                            {
                                x = cei.DeattachedbyContractor(ContractorId, SupervisorREID, UserId);
                                AlertMessage = "DeAttached";
                            }

                            if (x > 0)  
                            {
                                cei.EmailForDeattachmentRequestContractor(AlertMessage, HdnContractorEmail.Value, HdnSupervisorEmail.Value);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Supervisor Sucessfully " + AlertMessage + " '); window.location.href = '/Contractor/Supervisor_Requests.aspx'; ", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('there is some Error');", true);
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Missing Email of supervisor/Contractor. Please contact admin to Update email');", true);
                        }
                    }
                    Session["DoubleClick_Btn"] = "0";
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('"+ ex.Message +"');", true);
                //throw;
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = hdnFeildDocumnet.Value.ToString();
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
    }
}