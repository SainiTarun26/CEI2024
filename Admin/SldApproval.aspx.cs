using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class SingleLineDiagram : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["AdminID"] != null)
                {
                    GridBind();
                }
            }


        }

        private void GridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.ViewSldDocuments();
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReview.SelectedValue == "Returned")
            {
                Rejection.Visible = true;
               // Remarks.Visible = false;
            }
            else if (ddlReview.SelectedValue == "InProcess")
            {
                //Remarks.Visible = true;
                Rejection.Visible = false;

            }
            if (ddlReview.SelectedValue == "0")
            {
                Rejection.Visible = false;
               // Remarks.Visible = false;
            }
          
           

        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.CheckedChanged += chkSelect_CheckedChanged;
                chkSelect.Attributes.Add("onclick", "SelectCheckbox(this);");
            }

        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkSelect.NamingContainer;

            Label lblSldId = (Label)row.FindControl("lblSldId");

            Label lblSiteOwnerId = (Label)row.FindControl("lblSiteOwnerId");




            foreach (GridViewRow rows in grd_Documemnts.Rows)
            {
                if (rows.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = rows.FindControl("chkSelect") as CheckBox;

                    if (chk != null && chk.ClientID != chkSelect.ClientID)
                    {
                        chk.Checked = false;
                    }

                }
            }


            if (chkSelect.Checked)
            {

                ApproveDocument.Visible = true;
                Session["lblSldId"] = lblSldId.Text;
                Session["lblSiteOwnerId"] = lblSiteOwnerId.Text;
            }
            else
            {


                ApproveDocument.Visible = false;
                TxtRejectionReason.Text = "";
               // TxtRemarks.Text = "";
                ddlReview.SelectedValue = "0";

            }



        }
     

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SLDID = Session["lblSldId"].ToString().Trim();
            //string SiteOwnerId = Session["lblSiteOwnerId"].ToString().Trim();
            string AdminId = Session["AdminID"].ToString();
            
            CEI.SldRequestForAdmin(SLDID, ddlReview.SelectedValue.ToString(), AdminId,TxtRejectionReason.Text.Trim());
            string script = $"alert('SLD Document submitted successfully.'); window.location='AdminMaster.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
        }
    
    }
}