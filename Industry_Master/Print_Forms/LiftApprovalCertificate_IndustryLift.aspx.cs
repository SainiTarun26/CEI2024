﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Industry_Master.Print_Forms
{
    public partial class LiftApprovalCertificate_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string InspectionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        if (Session["SiteOwnerId_IndustryLift"] != null || Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != string.Empty)
                        {
                            GetData();
                        }
                        else if (Session["AdminId"] != null || Convert.ToString(Session["AdminId"]) != string.Empty)
                        {
                            GetData();
                        }
                        else if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                        {
                            GetData();
                        }
                        else if (Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != null || Convert.ToString(Session["InProcessInspectionId_IndustryLift"]) != string.Empty)
                        {
                            GetData();
                        }
                        else
                        {
                            Session["SiteOwnerId_IndustryLift"] = "";
                            Session["AdminId"] = "";
                            Session["StaffID"] = "";
                            Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                    return;
                }
            }

        }
        public void GetData()
        {
            try
            {
                if (Session["InProcessInspectionId_IndustryLift"] != null)
                {
                    InspectionId = Session["InProcessInspectionId_IndustryLift"].ToString();

                }
                else if (Session["InspectionId_IndustryLift"] != null)
                {
                    InspectionId = Session["InspectionId_IndustryLift"].ToString();

                }
                ID = Session["LiftTestReportID_IndustryLift"].ToString();
                DataTable dt = new DataTable();
                dt = CEI.GetLiftCertificateData_IndustryLift(InspectionId, ID);
                if (dt.Rows.Count > 0)
                {
                    lblAddress1.Text = dt.Rows[0]["Header1"].ToString();
                    lblAdress2.Text = dt.Rows[0]["Header2"].ToString();
                    lblAdress3.Text = dt.Rows[0]["Header3"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["Header4"].ToString()))
                    {
                        lblEmail.Visible = false;
                    }
                    else
                    {
                        lblEmail.Visible = true;
                        lblEmail.Text = dt.Rows[0]["Header4"].ToString();
                    }
                    lblRegNo.Text = dt.Rows[0]["RegistrationNo"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["Maker"].ToString();
                    lblAddress.Text = dt.Rows[0]["SiteAddress"].ToString();
                    DateTime createdDate1 = Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]);
                    lblInspectionDate.Text = createdDate1.ToString("dd/MM/yyyy");
                    lblOwnerName.Text = dt.Rows[0]["OwnerName"].ToString();
                    lblMakerName.Text = dt.Rows[0]["Maker"].ToString();
                    lblSrNo.Text = dt.Rows[0]["RegistrationSrNo"].ToString();
                    lblTypeOflift.Text = dt.Rows[0]["TypeOfLift"].ToString();
                    lblDistrict.Text = dt.Rows[0]["District"].ToString().Trim().ToUpper();
                    lblTypeControl.Text = dt.Rows[0]["TypeOfControl"].ToString();
                    lblCapacity.Text = dt.Rows[0]["Capacity"].ToString();
                    lblMemoNo.Text = dt.Rows[0]["MemoNo"].ToString();
                    DateTime ErectedDate = Convert.ToDateTime(dt.Rows[0]["ErectionDate"]);
                    lblErectionDate.Text = ErectedDate.ToString("dd/MM/yyyy");
                    DateTime createdDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    lblDated.Text = createdDate.ToString("dd/MM/yyyy");
                    string dp_Id6 = dt.Rows[0]["TypeOfInspection"].ToString();
                    if (dp_Id6 == "Periodic")
                    {
                        txtSD.Visible = true;
                        myImage.Visible = false;
                    }
                    else
                    {
                        txtSD.Visible = false;

                    }
                    myImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                    lblstamp1.Text = dt.Rows[0]["Stamp1"].ToString();
                    lblstamp2.Text = dt.Rows[0]["Stamp2"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["Stamp3"].ToString()))
                    {
                        lblstamp3.Visible = false;
                    }
                    else
                    {
                        lblstamp3.Visible = true;
                        lblstamp3.Text = dt.Rows[0]["Stamp3"].ToString();
                    }
                }

                GridBind();

                string script = "<script type=\"text/javascript\">printDiv('printableDiv');</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintOnLoad", script, false);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        protected void GridBind()
        {
            try
            {
                ID = Session["LiftTestReportID_IndustryLift"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.getDataforLift_IndustryLift(ID);
                if (ds.Tables.Count > 0)
                {
                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }


        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblTypeOfInspection = e.Row.FindControl("lblTypeOfInspection") as Label;
                    Image ImgSignature = e.Row.FindControl("ImgSignature") as Image;

                    // Ensure controls exist
                    if (lblTypeOfInspection == null || ImgSignature == null)
                        return;

                    // Get the Signature value safely
                    object signatureData = DataBinder.Eval(e.Row.DataItem, "Signature");

                    // Debugging - Log what type of data is retrieved
                    System.Diagnostics.Debug.WriteLine($"Signature Type: {signatureData?.GetType().FullName}");

                    if (signatureData == DBNull.Value || signatureData == null)
                    {
                        // If the signature is NULL, display an empty image (or leave it hidden)
                        ImgSignature.ImageUrl = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw=="; // 1x1 transparent GIF
                        ImgSignature.Visible = true; // Or false if you don't want empty images
                    }
                    else if (signatureData is byte[] signatureBytes && signatureBytes.Length > 0)
                    {
                        ImgSignature.Visible = true;
                        ImgSignature.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(signatureBytes);
                    }
                    else
                    {
                        ImgSignature.Visible = false;
                    }

                    // Ensure "New" type inspections always display the image (even if NULL)
                    if (lblTypeOfInspection.Text.Trim() == "New")
                    {
                        ImgSignature.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GridView1_RowDataBound: " + ex.Message);
            }
        }



    }
}