using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class SLD_request : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty && Convert.ToString(Session["district_Temp"]) != null && Convert.ToString(Session["district_Temp"]) != string.Empty)
                {
                    //Session["SiteOwnerId_Sld_Indus"] = "ABCDG1234G";
                    string District = Session["district_Temp"].ToString();
                    string ownerId = Session["SiteOwnerId_Sld_Indus"].ToString();
                   
                    bool distExist = false;

                    DataSet ds1 = CEI.checkDistrict(ownerId,District);
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        distExist = true;
                        string statusType = ds1.Tables[0].Rows[0]["Status_type"].ToString();
                        if(statusType == "Returned")
                        {
                            BindGrid();
                            BindAdress();
                        }
                        else
                        {
                            Response.Redirect("SLD_Status.aspx");
                        }
                        
                    }
                    else
                    {
                        BindGrid();
                        BindAdress();
                    }
                    //BindGrid();
                    //BindAdress();
                }
                else
                {

                }
            }

        }
        private void BindAdress()
        {
            try
            {
                string id = Session["SiteOwnerId_Sld_Indus"].ToString();
                string district = Session["district_Temp"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetOwnerAdressForIndustry(id, district);
                string OwnerName = dsAdress.Tables[0].Rows[0]["OwnerName"].ToString();
                Session["OwnerName"] = OwnerName;
                ddlSiteOwnerAddress.DataSource = dsAdress;
                ddlSiteOwnerAddress.DataTextField = "FullAddress";
                ddlSiteOwnerAddress.DataValueField = "District";
                ddlSiteOwnerAddress.DataBind();
                ddlSiteOwnerAddress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch(Exception ex)
            {

            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_Sld_Indus"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldReturnHistory(LoginID);
            if (ds.Rows.Count > 0)
            {
                Gridview1.DataSource = ds;
                Gridview1.DataBind();
            }

            else
            {
                Gridview1.DataSource = null;
                Gridview1.DataBind();
                //Documents.Visible = true;
                //btnSubmit.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

     

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();


                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                BtnSubmit.Visible = true;
                if (status == "Returned")
                {
                    Document.Visible = false;
                    Document.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Rejected")
                {
                    Document.Visible = false;
                    BtnSubmit.Visible = false;
                }



            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblId = (Label)row.FindControl("LblId");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                if (lblStatus.Text.Trim().Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    // Show an alert if StatusType is Rejected
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cannot upload SLD document.');", true);
                }
                else
                {
                    Session["Sld_id"] = LblId.Text;
                    Response.Redirect("/Industry_Master/SLDReturn.aspx", false);
                }
            }

        }

        protected void BtnSubmit_Click1(object sender, EventArgs e)
        {
            string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"].ToString();
            string SiteOwnerName = Session["OwnerName"].ToString();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";

            if (CustomFile.HasFile && CustomFile.PostedFile != null && CustomFile.PostedFile.ContentLength <= maxFileSize)
            {
                try
                {
                    string FilName = string.Empty;
                    FilName = Path.GetFileName(CustomFile.PostedFile.FileName);


                    if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
                    }

                    string ext = Path.GetExtension(CustomFile.FileName);
                    string path = "/Attachment/" + SiteOwnerId + "/Sld Document/";
                    string fileName = "Sld Document" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                    string filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                    CustomFile.SaveAs(filePathInfo2);
                    filePathInfo = path + fileName;

                }
                catch (Exception ex)
                {
                    //throw new Exception("Please Upload Pdf Files 1 Mb Only");
                }
            }
            else
            {
                throw new Exception("Please Upload Pdf Files 2 Mb Only");
            }
            CEI.UploadSldDocument(SiteOwnerId, filePathInfo, SiteOwnerId, ddlSiteOwnerAddress.SelectedItem.ToString(), SiteOwnerName, "Industry", ddlSiteOwnerAddress.SelectedValue.Trim());
            string script = $"alert('SLD Document submitted successfully.'); window.location='SLD_Status.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

        }
    }
}