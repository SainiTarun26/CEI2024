using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Serialization;
using CEI_PRoject;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;
using CEI_PRoject.Admin;
using AjaxControlToolkit;

namespace CEIHaryana.Admin
{
    public partial class StaffDetailsData : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string category = string.Empty;
        string loginType = string.Empty;
        string ID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        { 
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["AdminID"])!= null || Convert.ToString(Session["AdminID"]) != string.Empty || Request.Cookies["AdminID"] != null)
                    {
                        if (Convert.ToString(Session["logintype"]) != null || Convert.ToString(Session["logintype"]) != string.Empty || Request.Cookies["logintype"] != null)
                        {
                            if (Request.Cookies["AdminID"] != null && Request.Cookies["logintype"] != null)
                            {
                                 loginType = Request.Cookies["logintype"].Value;
                                ID = Request.Cookies["AdminID"].Value;
                            }
                            else
                            {
                                loginType = Convert.ToString(Session["logintype"]);
                                ID = Convert.ToString(Session["AdminID"]);
                            }
                           
                            string str = Request.Params.ToString();
                            category = Request.Params["category"].ToString();
                            lblData.Text = category + " Data";

                            if (category == "Contractor")
                            {
                                GridView1.Columns[5].Visible = true;  
                                GridView1.Columns[4].Visible = true;
                                GridView1.Columns[6].Visible = true;
                                getContractorData(loginType, ID);
                            }
                            else if (category == "Supervisor" || category == "Wireman")
                            {
                                getWiremanorSuperwiserData(category, loginType, ID);
                            }
                        }

                    }
                    else
                    {
                        Session["AdminID"] = "";
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch(Exception Ex)
            {
                Session["AdminID"] = "";
                Response.Redirect("/Login.aspx");
            }
        }


        private void getContractorData(string loginType, string ID)
        {
            DataTable ds = new DataTable();
            ds = cei.GetContractorDataforgrid(loginType, ID);
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


        private void getWiremanorSuperwiserData(string category, string loginType, string ID)
        {
            DataTable ds = new DataTable();
            ds = cei.GetWiremanorSuperwiserData(category, loginType, ID);
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
                Control ctrl = e.CommandSource as Control;
                if (ctrl != null)
                {
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label RowID = (Label)row.FindControl("lblRowID");
                    string ID = RowID.Text;
                    string category = Request.Params["category"].ToString();
                    if (category == "Contractor")
                    {
                        Session["ID"] = ID;
                        Response.Redirect("AddContractorDetails.aspx", false);

                    }
                    else if (category == "Supervisor")
                    {
                        Session["ID"] = ID;
                        Response.Redirect("AddSupervisorDetails.aspx");
                    }
                    else if (category == "Wireman")
                    {
                        Session["ID"] = ID;
                        Response.Redirect("AddWiremanDetails.aspx");

                    }
                }

            }
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            category = Request.Params["category"].ToString();
            if (Request.Cookies["AdminID"] != null && Request.Cookies["logintype"] != null)
            {
                loginType = Request.Cookies["logintype"].Value;
                ID = Request.Cookies["AdminID"].Value;
            }
            else
            {
                loginType = Convert.ToString(Session["logintype"]);
                ID = Convert.ToString(Session["AdminID"]);
            }
            if (category == "Contractor")
            {
                getContractorData(loginType, ID);
                
            }
            else if (category == "Supervisor" || category == "Wireman")
            {
                getWiremanorSuperwiserData(category, loginType, ID);
            }
           


        }
        //else if (e.CommandName == "Drop")
        //{
        //    Control ctrl = e.CommandSource as Control;
        //    if (ctrl != null)
        //    {
        //        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //        Label RowID = (Label)row.FindControl("lblRowID");
        //        string ID = RowID.Text;
        //        string category = Request.Params["category"].ToString();
        //        if (category == "Contractor")
        //        {
        //            SqlCommand cmd = new SqlCommand("DropContractorData");
        //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //            cmd.Connection = con;
        //            if (con.State == ConnectionState.Closed)
        //            {
        //                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //                con.Open();
        //            }

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@ContractorID", ID);
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Deleted Successfully !!!')", true);
        //            string loginType = Convert.ToString(Session["logintype"]);

        //            getContractorData(loginType, ID);
        //        }
        //        else
        //        {
        //            SqlCommand cmd = new SqlCommand("DeleteData");
        //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //            cmd.Connection = con;
        //            if (con.State == ConnectionState.Closed)
        //            {
        //                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //                con.Open();
        //            }

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@REID", ID);
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Deleted Successfully !!!')", true);
        //            string loginType = Convert.ToString(Session["logintype"]);
        //            getWiremanorSuperwiserData(category, loginType, ID);

        //        }
        //    }
        //}

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            if (lblData.Text == "Contractor Data")
            {
                Response.Redirect("AddContractorDetails.aspx", false);
            }
            else if(lblData.Text == "Supervisor Data")
            {
                Response.Redirect("AddSupervisorDetails.aspx");
            }
            else
            {
                Response.Redirect("AddWiremanDetails.aspx");
            }
        }


    }
}