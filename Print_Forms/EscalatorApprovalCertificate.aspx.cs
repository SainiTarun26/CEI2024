using CEI_PRoject;
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


                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/Login.aspx");
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

                    lblMakerName.Text = dt.Rows[0]["Maker"].ToString();
                    lblSrNo.Text = dt.Rows[0]["RegistrationSrNo"].ToString();
                    lblTypeOflift.Text = dt.Rows[0]["TypeOfLift"].ToString();

                    lblTypeControl.Text = dt.Rows[0]["TypeOfControl"].ToString();
                    lblCapacity.Text = dt.Rows[0]["Capacity"].ToString();
                    lblMemoNo.Text = dt.Rows[0]["MemoNo"].ToString();
                    lblErectionDate.Text = dt.Rows[0]["ErectionDate"].ToString();
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
                else
                {
                    DataSet ds = new DataSet();
                    ds = CEI.PrintDetailsFor_LiftCertificate(InspectionId, ID);
                    lblAddress1.Text = ds.Tables[0].Rows[0]["Header1"].ToString();
                    lblAdress2.Text = ds.Tables[0].Rows[0]["Header2"].ToString();
                    lblAdress3.Text = ds.Tables[0].Rows[0]["Header3"].ToString();
                    //lblEmail.Text = ds.Tables[0].Rows[0]["Header4"].ToString();
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Header4"].ToString()))
                    {
                        lblEmail.Visible = false;
                    }
                    else
                    {
                        lblEmail.Visible = true;
                        lblEmail.Text = ds.Tables[0].Rows[0]["Header4"].ToString();
                    }
                    //string dp1 = ds.Tables[0].Rows[0]["InstallationType"].ToString();

                    lblRegNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    lblCompanyName.Text = ds.Tables[0].Rows[0]["Maker"].ToString();

                    lblAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    DateTime createdDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApprovedDate"]);
                    lblInspectionDate.Text = createdDate1.ToString("dd/MM/yyyy");

                    lblMakerName.Text = ds.Tables[0].Rows[0]["Maker"].ToString();
                    lblSrNo.Text = ds.Tables[0].Rows[0]["RegistrationSrNo"].ToString();
                    lblTypeOflift.Text = ds.Tables[0].Rows[0]["TypeOfLift"].ToString();

                    lblTypeControl.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                    lblCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    lblMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                    lblErectionDate.Text = ds.Tables[0].Rows[0]["ErectionDate"].ToString();
                    DateTime createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                    lblDated.Text = createdDate.ToString("dd/MM/yyyy");
                    string dp_Id6 = ds.Tables[0].Rows[0]["TypeOfInspection"].ToString();
                    if (dp_Id6 == "Periodic")
                    {
                        txtSD.Visible = true;
                        myImage.Visible = false;
                    }
                    else
                    {
                        txtSD.Visible = false;

                    }
                    myImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Signature"]);
                    lblstamp1.Text = ds.Tables[0].Rows[0]["Stamp1"].ToString();
                    lblstamp2.Text = ds.Tables[0].Rows[0]["Stamp2"].ToString();
                    //lblstamp3.Text = ds.Tables[0].Rows[0]["Stamp3"].ToString();
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stamp3"].ToString()))
                    {
                        lblstamp3.Visible = false;
                    }
                    else
                    {
                        lblstamp3.Visible = true;
                        lblstamp3.Text = ds.Tables[0].Rows[0]["Stamp3"].ToString();
                    }
                    CEI.UpdateLiftApprovedCertificatedata(ID);
                }
                GridBind();
                //Session["StaffID"] = "";
                //Session["SiteOwnerId"] = "";
                //Session["AdminId"] = "";
                //Session["InProcessInspectionId"] = "";
                // Session["InspectionId"]= "";
                string script = "<script type=\"text/javascript\">printDiv('printableDiv');</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintOnLoad", script, false);

            }

            catch (Exception ex)
            {
                throw;
            }

        }
        protected void GridBind()
        {
            try
            {
                ID = Session["LiftTestReportID"].ToString();
                //if (Session["InProcessInspectionId"] != null)
                //{
                //    ID = Session["InProcessInspectionId"].ToString();
                //}
                //else if (Session["InspectionId"] != null)
                //{
                //   // ID = Session["InspectionId"].ToString();
                //    ID = Session["LiftTestReportID"].ToString();

                //}
                //ID = Session["InspectionId"].ToString();
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
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
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