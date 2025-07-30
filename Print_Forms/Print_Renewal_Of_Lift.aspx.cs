using CEI_PRoject;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Print_Forms
{
    public partial class Print_Renewal_Of_Lift : System.Web.UI.Page
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
                        else if (Convert.ToString(Session["InProcessInspectionId"]) != null || Convert.ToString(Session["InProcessInspectionId"]) != string.Empty)
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
                DataSet ds = new DataSet();
                ds = CEI.GetRenewalLiftData(InspectionId, ID);
                if (ds.Tables.Count > 0)
                {
                    lbltype.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    lbltype2.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    lblAddress1.Text = ds.Tables[0].Rows[0]["Header1"].ToString();
                    lblAdress2.Text = ds.Tables[0].Rows[0]["Header2"].ToString();
                    lblAdress3.Text = ds.Tables[0].Rows[0]["Header3"].ToString();
                    lblInspectionId.Text = ds.Tables[0].Rows[0]["InspectionId"].ToString();
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Header4"].ToString()))
                    {
                        lblEmail.Visible = false;
                    }
                    else
                    {
                        lblEmail.Visible = true;
                        lblEmail.Text = ds.Tables[0].Rows[0]["Header4"].ToString();
                    }
                    lblRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    lblMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                    lblApprovedDate.Text = ds.Tables[0].Rows[0]["InspectionCreatedDate"].ToString();
                    ImgSignature2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Signature"]);
                    lblstamp1.Text = ds.Tables[0].Rows[0]["Stamp1"].ToString();
                    lblstamp2.Text = ds.Tables[0].Rows[0]["Stamp2"].ToString();
                    lblstamp3.Text = ds.Tables[0].Rows[0]["Stamp3"].ToString();
                    //lblApprovedDate.Text = DateTime.Parse(createdDate1).ToString("dd/MM/yyyy");


                }

                GridBind(InspectionId, ID);

                string script = "<script type=\"text/javascript\">printDiv('printableDiv');</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintOnLoad", script, false);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        protected void GridBind(string InspectionId, string ID)
        {
            try
            {
                ID = Session["LiftTestReportID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetRenewalLiftData(InspectionId, ID);

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    Gridview1.DataSource = ds.Tables[1];  // ✅ Bind to 2nd table
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
                // Optional: Log or display error
                Response.Write("Error: " + ex.Message);
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
                System.Diagnostics.Debug.WriteLine("Error in GridView1_RowDataBound: " + ex.ToString());
            }
        }
    }
}