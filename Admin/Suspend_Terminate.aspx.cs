using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using System.IO;
using Org.BouncyCastle.Crypto.Tls;
using StackExchange.Redis;

namespace CEIHaryana.Admin
{
    public partial class Suspend_Terminate : System.Web.UI.Page
    {
        //page created by kalapana
        string filePathInfo2 = "";
        CEI CEI = new CEI();
        string loginid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    hdnId.Value = Convert.ToString(Session["AdminId"]);
                    GridBind();

                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

        public void GridBind()
        {
            try
            {
                string Category = ddlCategory.SelectedItem.ToString();
                if (Category == "Select")
                {
                    Category = null;
                }
                string Search = txtSearch.Text;
                DataSet ds = new DataSet();
                ds = CEI.GridForSuspensionAndTermination(Category, Search);
                if (ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }


                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridBind();
        }

        protected void rblAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblAction.SelectedValue == "Terminate")
            {
                FromDate.Visible = true;
                ToDate.Visible = false;
            }
            else
            {
                FromDate.Visible = true;
                ToDate.Visible = true;
            }
        }
        //file saved by navneet
        protected string Filepathe(string Type, string category, string userid)
        {
            string filePathInfo = "";
            string fileName = "";

            // Clean userId to remove invalid chars
            string safeUserId = string.Concat(userid.Split(Path.GetInvalidFileNameChars()));

            if (fileUpload.HasFile)
            {
                string extension = Path.GetExtension(fileUpload.FileName).ToLower();

                if (extension == ".pdf")
                {
                    if (fileUpload.PostedFile.ContentLength <= 1048576) // 1MB
                    {
                        // Generate unique file name
                        fileName = safeUserId + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + extension;

                        // Build folder path
                        string folderPath = Server.MapPath($"~/Attachment/{Type}/{category}/{safeUserId}/");

                        // Ensure directory exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        // Full physical path
                        filePathInfo = Path.Combine(folderPath, fileName);

                        // Save file
                        fileUpload.PostedFile.SaveAs(filePathInfo);
                    }
                    else
                    {
                        throw new Exception("Please upload PDF files less than 1 MB only");
                    }
                }
                else
                {
                    throw new Exception("Please upload PDF files only");
                }
            }
            else
            {
                throw new Exception("Please upload a PDF");
            }

            return filePathInfo;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAnyRowSelected = false;
                Label lblUserId;
                Label lblCategory;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("chkSelect") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        isAnyRowSelected = true;
                        lblUserId = (Label)row.FindControl("lblApplicantFor");
                        lblCategory = (Label)row.FindControl("lblContractorName");
                        filePathInfo2 = Filepathe(rblAction.SelectedValue, lblCategory.Text, lblUserId.Text);
                        if (filePathInfo2 != null && filePathInfo2 != "")
                        {
                            CEI.InsertSuspensionAndTerminationData(lblUserId.Text, lblCategory.Text, rblAction.SelectedValue, hdnId.Value, txtFromDate.Text, txtdateto.Text, filePathInfo2, hdnId.Value);

                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (!isAnyRowSelected)
                {
                    // Show error message
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert", "alert('Please select at least one record.');", true);
                }
                else
                {
                    Reset();
                    string script = "alert(\"Response updated successfully\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {

                string script = ex.Message + "alert(\"Please Fill Form Correctly\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }
        protected void Reset()
        {
            txtdateto.Text = "";
            txtFromDate.Text = "";
            rblAction.ClearSelection();
            GridBind();
        }

    }
}
