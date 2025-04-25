﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Print_Forms
{
    public partial class EscalatorApprovalCertificate : System.Web.UI.Page
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

                        if (Session["SiteOwnerId"] != null || Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
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
                        else
                        {
                            Session["SiteOwnerId"] = "";
                            Session["AdminId"] = "";
                            Session["StaffID"] = "";
                            Response.Redirect("/LogOut.aspx", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/SiteOwnerLogout.aspx");
                }
            }

        }
        public void GetData()
        {
            try
            {
                if (Session["InProcessInspectionId"] != null)
                {
                    InspectionId = Session["InProcessInspectionId"].ToString();

                }
                else if (Session["InspectionId"] != null)
                {
                    InspectionId = Session["InspectionId"].ToString();

                }
                ID = Session["LiftTestReportID"].ToString();
                DataTable dt = new DataTable();
                dt = CEI.GetLiftCertificateData(InspectionId, ID);
                if (dt.Rows.Count > 0)
                {
                    lblAddress1.Text = dt.Rows[0]["Header1"].ToString();
                    lblAdress2.Text = dt.Rows[0]["Header2"].ToString();
                    lblAdress3.Text = dt.Rows[0]["Header3"].ToString();
                    //lblEmail.Text = dt.Rows[0]["Header4"].ToString();
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
                    //lblstamp3.Text = dt.Rows[0]["Stamp3"].ToString();
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
                ID = Session["LiftTestReportID"].ToString();      
                DataSet ds = new DataSet();
                ds = CEI.getDataforLift(ID);
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
                    object signatureData = DataBinder.Eval(e.Row.DataItem, "Signature");
                    if (signatureData != DBNull.Value && signatureData is byte[])
                    {
                        byte[] signatureBytes = (byte[])signatureData;
                        if (signatureBytes.Length > 0)
                        {
                            ImgSignature.Visible = true;
                            ImgSignature.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(signatureBytes);
                        }
                        else
                        {
                            ImgSignature.Visible = false;
                        }
                    }
                    else
                    {
                        ImgSignature.Visible = false;
                    }
                    if (lblTypeOfInspection.Text == "New")
                    {
                        ImgSignature.Visible = true;
                    }
                    else
                    {

                        ImgSignature.Visible = true;
                    }
                }
            }
            catch { }
        }


        


    }
}