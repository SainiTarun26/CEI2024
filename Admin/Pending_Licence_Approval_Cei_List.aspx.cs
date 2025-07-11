﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class Pending_Licence_Approval_Cei_List : System.Web.UI.Page
    {
        //Page Created by aslam 18-June-2025
        CEI CEI = new CEI();
        string LoginID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null || Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {
                        Session["AdminId"] = null;
                        Response.Redirect("/AdminLogout.aspx", false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = null;
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        public void GridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Licence_CEI_Pending_FinalRecommendationList();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Session["Application_Id"] = lblApplicationId.Text.ToString();
                Response.Redirect("Pending_Licence_Approval_Cei.aspx", false);
                return;
            }
            else
            {

            }
        }
    }
}