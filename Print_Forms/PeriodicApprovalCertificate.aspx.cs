using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class PeriodicApprovalCertificate : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                {
                    GetData();
                }
                else if (Session["SiteOwnerId"] != null)
                {
                    GetData();
                    abandonsession();
                }
                else if (Session["AdminId"] != null)
                {
                    GetData();
                }


            }

        }
        public void GetData()
        {
            try
            {

                if (Session["InProcessInspectionId"] != null)
                {
                    ID = Session["InProcessInspectionId"].ToString();
                }
                else if (Session["InspectionId"] != null)
                {
                    ID = Session["InspectionId"].ToString();

                }
                else if (Session["InspectionIdforNew"] != null)
                {
                    ID = Session["InspectionIdforNew"].ToString();

                }
                else if (Session["InspectionIdNew"] != null)
                {
                    ID = Session["InspectionIdNew"].ToString();

                }
                string url = ID + "&name=" + "Print_Forms/PeriodicApprovalCertificate.aspx";

                byte[] qrBytes = CEI.GenerateQrCode(url);

                string base64Image = Convert.ToBase64String(qrBytes);

                imgQR.ImageUrl = "data:image/png;base64," + base64Image;
                DataTable dt = new DataTable();
                dt = CEI.GetCertificateData(ID);
                if (dt.Rows.Count>0) 
                {
                    lblAddress1.Text = dt.Rows[0]["Header1"].ToString();
                    lblAdress2.Text = dt.Rows[0]["Header2"].ToString();
                    lblAdress3.Text = dt.Rows[0]["Header3"].ToString();
                    lblAdress4.Text = dt.Rows[0]["Header4"].ToString();
                    TxtName.Text = dt.Rows[0]["OwnerName"].ToString().ToUpper();
                    TextAdress.Text = dt.Rows[0]["Location"].ToString().ToUpper();
                    TextLocation.Text = dt.Rows[0]["CompleteAdress"].ToString().ToUpper();
                    txtApplicationNo.Text = dt.Rows[0]["ReferenceNo"].ToString();
                    txtCreatedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    TxtMemo.Text = dt.Rows[0]["MemoNo"].ToString();
                    txtMemoDate.Text = dt.Rows[0]["ApprovedDate"].ToString();
                    string[] str = dt.Rows[0]["Suggestion"].ToString().Split('\n');
                    suggestion1.Visible = false;
                    suggestion2.Visible = false;
                    suggestion3.Visible = false;
                    suggestion4.Visible = false;
                    if (str.Length > 0)
                    {
                        suggestion1.InnerText = str[0];
                        suggestion1.Visible = true;
                    }
                    if (str.Length > 1)
                    {
                        suggestion2.InnerText = str[1];
                        suggestion2.Visible = true;
                    }
                    if (str.Length > 2)
                    {
                        suggestion3.InnerText = str[2];
                        suggestion3.Visible = true;
                    }
                    if (str.Length > 3)
                    {
                        suggestion4.InnerText = str[3];
                        suggestion4.Visible = true;
                    }
                    
                    myImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                    lblstamp1.Text = dt.Rows[0]["Stamp1"].ToString();
                    lblstamp2.Text = dt.Rows[0]["Stamp2"].ToString();
                    lblstamp3.Text = dt.Rows[0]["Stamp3"].ToString();
                    lblNote.Text = dt.Rows[0]["Note"].ToString();
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = CEI.PrintApprovalLetter(ID);
                    lblAddress1.Text = ds.Tables[1].Rows[0]["Header1"].ToString();
                    lblAdress2.Text = ds.Tables[1].Rows[0]["Header2"].ToString();
                    lblAdress3.Text = ds.Tables[1].Rows[0]["Header3"].ToString();
                    lblAdress4.Text = ds.Tables[1].Rows[0]["Header4"].ToString();
                    TxtName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString().ToUpper();
                    TextAdress.Text = ds.Tables[0].Rows[0]["Location"].ToString().ToUpper();
                    TextLocation.Text = ds.Tables[0].Rows[0]["CompleteAdress"].ToString().ToUpper();
                    txtApplicationNo.Text = ds.Tables[1].Rows[0]["ReferenceNo"].ToString();
                    txtCreatedDate.Text = ds.Tables[1].Rows[0]["CreatedDate"].ToString();
                    TxtMemo.Text = ds.Tables[1].Rows[0]["MemoNo"].ToString();
                    txtMemoDate.Text = ds.Tables[1].Rows[0]["ApprovedDate"].ToString();
                    string Suggestion = ds.Tables[1].Rows[0]["Suggestion"].ToString();
                    string[] str = ds.Tables[1].Rows[0]["Suggestion"].ToString().Split('\n');
                    suggestion1.Visible = false;
                    suggestion2.Visible = false;
                    suggestion3.Visible = false;
                    suggestion4.Visible = false;
                    if (str.Length > 0)
                    {
                        suggestion1.InnerText = str[0];
                        suggestion1.Visible = true;
                    }
                    if (str.Length > 1)
                    {
                        suggestion2.InnerText = str[1];
                        suggestion2.Visible = true;
                    }
                    if (str.Length > 2)
                    {
                        suggestion3.InnerText = str[2];
                        suggestion3.Visible = true;
                    }
                    if (str.Length > 3)
                    {
                        suggestion4.InnerText = str[3];
                        suggestion4.Visible = true;
                    }                
                    myImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])ds.Tables[1].Rows[0]["Signature"]);
                    lblstamp1.Text = ds.Tables[1].Rows[0]["Stamp1"].ToString();
                    lblstamp2.Text = ds.Tables[1].Rows[0]["Stamp2"].ToString();
                    lblstamp3.Text = ds.Tables[1].Rows[0]["Stamp3"].ToString();
                    lblNote.Text = ds.Tables[1].Rows[0]["Note"].ToString();

                }
                GridBind();
            }
            catch(Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void GridBind()
        {
            try
            {
                if (Session["InProcessInspectionId"] != null)
                {
                    ID = Session["InProcessInspectionId"].ToString();
                }
                else if (Session["InspectionId"] != null)
                {
                    ID = Session["InspectionId"].ToString();

                }
               
                DataSet ds = new DataSet();
                ds = CEI.getInstallationsForPeriodic(ID);
                if (ds.Tables.Count > 0)
                {
                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();
                    string script = "alert(\"No Record Found\");";
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

        #region navneet for qr scanning
        public void abandonsession()
        {
            if (Convert.ToString(Session["SiteOwnerId"]) == "12345")
            {
                Session["SiteOwnerId"] = "";
                Session["InspectionId"] = "";
            }
        }
        #endregion

    }
}