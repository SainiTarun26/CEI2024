﻿using CEI_PRoject;
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
            try
            {
                string SuperviserId = Session["SupervisorID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetSupervisorDataForRenewal(SuperviserId);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtCertificate.Text = ds.Tables[0].Rows[0]["CertificateNo"].ToString();
                    string issueDate = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
                    txtIssueDate.Text = DateTime.Parse(issueDate).ToString("yyyy-MM-dd");
                    string ExpiryDate = ds.Tables[0].Rows[0]["DateofExpiry"].ToString();
                    txtExpiryDate.Text = DateTime.Parse(ExpiryDate).ToString("yyyy-MM-dd");
                    txtVoltageLevel.Text = ds.Tables[0].Rows[0]["votagelevel"].ToString();
                    string DOB = ds.Tables[0].Rows[0]["Age"].ToString();
                    txtDOB.Text = DateTime.Parse(DOB).ToString("yyyy-MM-dd");
                    if (txtDOB.Text != null)
                    {
                        if (DateTime.TryParse(txtDOB.Text, out DateTime BirthDate))
                        {
                            DateTime CurrentDate = DateTime.Now;
                            DivAge.Visible = true;
                            txtAge.Text = CEI.CalculateDate(CurrentDate, BirthDate);
                        }
                    }
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                    ddlLoadBindState();
                    string State = ds.Tables[0].Rows[0]["State"].ToString();
                    DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(State));
                    DdlState.Enabled = false;
                    string District = ds.Tables[0].Rows[0]["District"].ToString();
                    ddlLoadBindDistrict(State);
                    DdlDistrict.SelectedValue = District;
                    DdlDistrict.Enabled = false;
                    TextAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    TextAddress.ReadOnly = true;
                    txtpincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    txtpincode.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
                       
        }

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlState.SelectedValue != null && DdlState.SelectedValue !="0")
            {
                
                ddlLoadBindDistrict(DdlState.SelectedItem.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check.Checked == true)
                {
                    if (Session["SupervisorID"] != null)
                    {
                        string SupervisorId = Session["SupervisorID"].ToString();
                        DataTable dt = new DataTable();

                        dt = CEI.GetSupervisorLiceceUpgradationData(SupervisorId);
                        if (dt.Rows.Count > 0 && dt != null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('You Already Applied for Licence Upgradation ');", true);
                            return;
                        } 
                        //forDocument pdf                        
                        int maxFileSize = 2 * 1024 * 1024;
                        string FileName = string.Empty;
                        string flpPhotourl = string.Empty;
                        if(ExpCertificate.PostedFile.FileName.Length >0)
                        {
                            if(ExpCertificate.PostedFile.ContentLength > maxFileSize)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Upload pdf Less then 2 MB');", true);
                                return;
                            }
                            FileName = Path.GetFileName(ExpCertificate.PostedFile.FileName);
                            string ext = Path.GetExtension(ExpCertificate.PostedFile.FileName).ToLower();
                            if (ext != ".pdf")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Experience Certificate document must be a PDF file.')", true);
                                return;
                            }
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/ExpCertificate/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/ExpCertificate/"));
                            }
                            //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                            string path = "/Attachment/" + SupervisorId + "/ExpCertificate/";
                            string fileName = "ExpCertificate " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + "pdf";
                            string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/ExpCertificate/" + fileName);
                            ExpCertificate.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl = path + fileName;
                        }
                        CEI.InsertUpgradationSupervisorData(
                        txtName.Text.Trim(), txtCertificate.Text.Trim(), txtIssueDate.Text.Trim(), txtExpiryDate.Text.Trim(),txtVoltageLevel.Text.Trim(), txtDOB.Text.Trim(), txtAge.Text.Trim(),
                        txtEmail.Text.Trim(), txtContactNo.Text.Trim(), TextAddress.Text.Trim(), DdlState.SelectedItem.ToString(), DdlDistrict.SelectedItem.ToString(), 
                        txtpincode.Text.Trim(),
                        textExp.Text.Trim(), txtInterviewDate.Text, txtVoltage.Text.Trim(),                        
                        flpPhotourl,SupervisorId
                        );
                        DataSaved.Visible = true;
                        Reset();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please tick the declartion');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Some Error Occured,Please Login Again');", true);
                //throw;
            }            
        }
        private void Reset()
        {
            txtName.Text = ""; txtCertificate.Text = ""; txtIssueDate.Text = ""; txtExpiryDate.Text = "";
            txtVoltageLevel.Text = ""; txtDOB.Text = ""; txtAge.Text = ""; txtEmail.Text = ""; txtContactNo.Text = "";
            TextAddress.Text = ""; DdlState.SelectedValue = "0"; DdlDistrict.SelectedValue = "0"; txtpincode.Text = "";
            textExp.Text = ""; txtInterviewDate.Text = ""; txtVoltage.Text = ""; txtExpCertificate.Text = "";            
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedValue == "0")
            {
                DdlState.Enabled = true;
                DdlDistrict.Enabled = true;
                txtpincode.ReadOnly = false;
                TextAddress.ReadOnly = false;
            }
            else
            {
                DdlState.Enabled = false;
                DdlDistrict.Enabled = false;
                txtpincode.ReadOnly = true;
                TextAddress.ReadOnly = true;
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList2.SelectedValue=="0")
            {
                DivUpgradationEarlier.Visible = true;
            }
            else
            {
                DivUpgradationEarlier.Visible = false;
            }
        }
    }
}