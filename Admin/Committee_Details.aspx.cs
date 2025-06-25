using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class Committee_Details : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Session["AdminId"].ToString() != "")
                    {
                        CommitteeGridViewBind();
                        //GridViewBind();
                        hdnFieldCommitteeId.Value = "";
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private void CommitteeGridViewBind()
        {
            DataTable dt = new DataTable();
            dt = cei.GetCommitteeDetails();
            if (dt.Rows.Count > 0 && dt != null)
            {

                Grdview_Committee.DataSource = dt;
                Grdview_Committee.DataBind();
                CommitteDetails_Div.Visible = true;
                DivCard_CommiteeText.Visible = false;
            }
            else
            {
                Grdview_Committee.DataSource = null;
                Grdview_Committee.DataBind();
            }
        }
        private void GridViewBind()
        {            
            DataTable dt = new DataTable();
            dt = cei.GetCommiteMembers();
            if (dt.Rows.Count > 0 && dt != null)
            {
                Grdview_Members.DataSource = dt;
                Grdview_Members.DataBind();
                btnsubmit.Visible = true;
            }
            else
            {
                btnsubmit.Visible = false;
                Grdview_Members.DataSource = null;
                Grdview_Members.DataBind();
            }
        }
        private void MembersDetails_GridViewBind(string CommitteeId)
        {
            DataTable dt = new DataTable();
            dt = cei.GetCommitteeMemebersDetails(CommitteeId);
            if (dt.Rows.Count > 0 && dt != null)
            {
                GridView_EditMember.DataSource = dt;
                GridView_EditMember.DataBind();
                Div_CommitteEditMembers.Visible = true;
            }
            else
            {
                GridView_EditMember.DataSource = null;
                GridView_EditMember.DataBind();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {
                    string CreatedBy = Session["AdminId"].ToString();
                    bool isAnySelected = false;
                    int NumberOfMembers = 0;
                    foreach (GridViewRow row in Grdview_Members.Rows)
                    {
                        CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                        if (cb != null && cb.Checked)
                        {
                            isAnySelected = true;
                            NumberOfMembers++;
                        }
                    }
                    if (isAnySelected)
                    {

                        string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connStr);
                        SqlTransaction transaction = null;                        
                        try
                        {
                            conn.Open();
                            transaction = conn.BeginTransaction();                           
                            string newCommitteeId = "";

                            string committeeId = hdnFieldCommitteeId.Value;

                            newCommitteeId = cei.InsertCommitteDetail(committeeId,NumberOfMembers, CreatedBy,transaction);

                            //Insert Members from GridView
                            string MemberName, designation, DivisionName,StaffUserId = "";
                            foreach (GridViewRow row in Grdview_Members.Rows)
                            {
                                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                                if (chk != null && chk.Checked)
                                {
                                    Label lblMemberName = (Label)row.FindControl("lblStaffName");
                                     MemberName = lblMemberName.Text;
                                    Label lbldesignation = (Label)row.FindControl("lblDesignation");
                                     designation = lbldesignation.Text;
                                    Label lblDivisionName = (Label)row.FindControl("lblDivisionName");
                                     DivisionName = lblDivisionName.Text;
                                    Label LblstaffUserId = (Label)row.FindControl("LblstaffUserId");
                                    StaffUserId = LblstaffUserId.Text;
                                    cei.InsertCommitteMembersDetail(newCommitteeId, MemberName, designation, DivisionName, StaffUserId, CreatedBy, transaction);
                                }
                            }
                            transaction.Commit();
                            CommitteeGridViewBind();
                            Div_ADDCommitte.Visible = false;
                            Div_CommitteEditMembers.Visible = false;
                            //GridViewBind();
                            if (hdnFieldCommitteeId.Value != "")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Committee Update successfully!');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Committee created successfully!');", true);
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            if (transaction != null)
                            {
                                transaction.Rollback();
                            }
                            ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('Error: {ex.Message}');", true);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                       "alert('Please select Checkbox ');", true);
                        return;
                    }
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void Grdview_Committee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ( e.CommandName=="Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                //Label lblID = (Label)row.FindControl("lblID");
                Label LblCommitedId =(Label)row.FindControl("lblCommitteeId");
                hdnFieldCommitteeId.Value = LblCommitedId.Text;
                if (LblCommitedId.Text != null && LblCommitedId.Text != "")
                {
                    MembersDetails_GridViewBind(LblCommitedId.Text);
                    btnUpdate.Visible = true;
                }               
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {
                    Div_ADDCommitte.Visible = true;
                    btnUpdate.Visible = false;
                    GridViewBind();
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }        

        protected void lnkButtonDeleteMemberId_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDelete = (LinkButton)sender;
                string memberId = lnkDelete.CommandArgument;
                int x = cei.DeleteCommitteeMember(memberId);
                if (x>1)
                {
                    if (hdnFieldCommitteeId.Value != "" && hdnFieldCommitteeId.Value != null)
                    {
                        MembersDetails_GridViewBind(hdnFieldCommitteeId.Value);
                        CommitteeGridViewBind();
                        btnUpdate.Visible = true;
                        if (GridView_EditMember.Rows.Count < 1)
                        {
                            Div_CommitteEditMembers.Visible = false;
                            Div_ADDCommitte.Visible = false; 
                            Div_ADDCommitte.Visible = false;
                            CommitteDetails_Div.Visible = false;
                            DivCard_CommiteeText.Visible = true;
                        }
                    }                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ALert", "alert('Member delete');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ALert", "alert('Member not delete');", true);
                }

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
                string script = $"alert('{errorMessage}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", script, true);
            }


        }
        #region Navneet 25-June-2025

        protected void lnkButtonDeleteCommitte_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDelete = (LinkButton)sender;
                string Committee_Id = lnkDelete.CommandArgument;
                cei.DeleteCommitteeAtAdminEnd(Committee_Id);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ALert", "alert('Committe Deleted Successfully');", true);

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
                string script = $"alert('{errorMessage}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", script, true);
            }


        }
        #endregion
        protected void lnkShowCreate_Click(object sender, EventArgs e)
        {
            hdnFieldCommitteeId.Value = "";
            Div_ADDCommitte.Visible = true;
            GridViewBind();
            CommitteeGridViewBind();
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            hdnFieldCommitteeId.Value = "";
            Div_ADDCommitte.Visible = true;
            GridViewBind();
            CommitteeGridViewBind();
        }
    }
}