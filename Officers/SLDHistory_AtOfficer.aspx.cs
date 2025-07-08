using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class SLDHistory_AtOfficer : System.Web.UI.Page
    {
        //Page created by aslam 7-July-2025

        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                {
                    BindGrid();
                }
                else
                {
                    Session["StaffID"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }

        }
        public void BindGrid(string searchText = null)
        {
            string LoginID = string.Empty;
            LoginID = Session["StaffID"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldHistoryForOfficer(LoginID, searchText);
            if (ds.Rows.Count > 0)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Select1")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Print")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

                LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");
                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                string RequestLetter = DataBinder.Eval(e.Row.DataItem, "RequestLetter").ToString();
                LinkButton Lnkbtn = (LinkButton)e.Row.FindControl("Lnkbtn");
                linkButton1.Visible = true;
                if (status == "Approved")
                {
                    // linkButton1.Visible = false;
                    lnkDocumemtPath.Visible = true;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
                else if (status == "Rejected" || status == "Returned")
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    lnkDocumemtPath.Visible = false;
                }
                else
                {

                    // linkButton1.Visible = true;
                    lnkDocumemtPath.Visible = false;
                }
                if (RequestLetter != null && RequestLetter != "")
                {
                    Lnkbtn.Visible = true;
                }
                else
                {
                    Lnkbtn.Visible = false;
                }
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                BindGrid(searchText);
            }
            else
            {
                BindGrid();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void GetPopUpDetails(string sldId)
        {
            try
            {
                DataSet ds = CEI.SldTransfer_GetSiteOwnerDetails_OnPopup(Convert.ToInt32(sldId));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    txtApplicant.Text = row["ApplicantType"].ToString();
                    txtContractorType.Text = row["ContractorType"].ToString();
                    txtPanNoOrTanNo.Text = row["UserId"].ToString();

                    if (!string.IsNullOrEmpty(row["NameOfOwner"].ToString()))
                    {
                        txtNameOfOwner.Text = row["NameOfOwner"].ToString();
                        OwnerNameDiv.Visible = true;
                        AgencyNameDiv.Visible = false;
                    }
                    else
                    {
                        txtNameOfAgency.Text = row["NameOfAgency"].ToString();
                        AgencyNameDiv.Visible = true;
                        OwnerNameDiv.Visible = false;
                    }


                    txtAddress.Text = row["Address"].ToString();
                    txtContactNo.Text = row["ContactNo"].ToString();
                    txtEmail.Text = row["Email"].ToString();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void lnkOwnerName_Command(object sender, CommandEventArgs e)
        {
            string sldId = e.CommandArgument.ToString();
            // Fetch owner details
            GetPopUpDetails(sldId);
            // Show the modal using Bootstrap (after data is filled)
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowOwnerModal", "$('#ownerModal').modal('show');", true);
        }

    }
}