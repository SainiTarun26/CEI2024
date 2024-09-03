using CEI_PRoject;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    if (Convert.ToString(Session["AdminID"]) != null || Convert.ToString(Session["AdminID"]) != string.Empty || Request.Cookies["AdminID"] != null)
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
                                var master = (MasterPage)Master;
                                var loginTypeLabel = (Label)master.FindControl("LoginType");
                                if (loginTypeLabel != null)
                                {
                                    loginTypeLabel.Text = "Admin / Contractor Details";
                                }

                                GridView1.Columns[5].Visible = true;
                                GridView1.Columns[4].Visible = true;
                                GridView1.Columns[6].Visible = true;
                                getContractorData(loginType, ID);
                            }
                            else if (category == "Supervisor")
                            {
                                var master = (MasterPage)Master;
                                var loginTypeLabel = (Label)master.FindControl("LoginType");
                                if (loginTypeLabel != null)
                                {
                                    loginTypeLabel.Text = "Admin / Supervisior Details";
                                }

                                getWiremanorSuperwiserData(category, loginType, ID);
                            }
                            else if (category == "Wireman")
                            {
                                var master = (MasterPage)Master;
                                var loginTypeLabel = (Label)master.FindControl("LoginType");
                                if (loginTypeLabel != null)
                                {
                                    loginTypeLabel.Text = "Admin / Wireman Details";
                                }

                                getWiremanorSuperwiserData(category, loginType, ID);
                            }
                            else if (category == "SiteOwner")
                            {
                                var master = (MasterPage)Master;
                                var loginTypeLabel = (Label)master.FindControl("LoginType");

                                if (loginTypeLabel.Text == "Admin")
                                {
                                    loginTypeLabel.Text = "Admin / SiteOwner Details";
                                }

                                getSiteOwnerData();
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
            catch (Exception Ex)
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
                GridView1.Columns[8].Visible=false;
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
            else if (lblData.Text == "Supervisor Data")
            {
                Response.Redirect("AddSupervisorDetails.aspx");
            }
            else
            {
                Response.Redirect("AddWiremanDetails.aspx");
            }
            string Category= Request.Params["category"].ToString();
        }
        public void SearchSupervisororWiremen(string searchterm,string categary)
        {
            DataTable dt = new DataTable();
            dt = cei.SearchSupervisororWiremen(searchterm, categary);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }       

        public void BindFullGrid()
        {
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
            if (category == "Contractor" && loginType != null && ID != null)
            {
                getContractorData(loginType, ID);

            }
            else if (category == "Supervisor" || category == "Wireman" && loginType != null && ID != null)
            {
                getWiremanorSuperwiserData(category, loginType, ID);
            }
        }
        protected string WrapText(string text, int wrapAfter)
        {
            if (string.IsNullOrEmpty(text) || wrapAfter <= 0)
                return text;

            for (int i = wrapAfter; i < text.Length; i += wrapAfter + 1)
            {
                text = text.Insert(i, " ");
            }

            return text;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindFullGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                category = Request.Params["category"].ToString();

                if (!string.IsNullOrEmpty(searchText))
                {
                    DataTable searchResult = cei.SearchContractorData(searchText, category);

                    if (searchResult.Rows.Count > 0)
                    {
                        GridView1.DataSource = searchResult;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        string script = "alert(\"No Record Found\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                }
                else // If searchText is blank
                {
                    BindFullGrid();
                    //if (Request.Cookies["AdminID"] != null && Request.Cookies["logintype"] != null)
                    //{
                    //    loginType = Request.Cookies["logintype"].Value;
                    //    ID = Request.Cookies["AdminID"].Value;
                    //}
                    //else
                    //{
                    //    loginType = Convert.ToString(Session["logintype"]);
                    //    ID = Convert.ToString(Session["AdminID"]);
                    //}
                    //if (category == "Contractor")
                    //{
                    //    getContractorData(loginType, ID);

                    //}
                    //else if (category == "Supervisor" || category == "Wireman")
                    //{
                    //    getWiremanorSuperwiserData(category, loginType, ID);
                    //}
                }


            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
            }
        }

        private void getSiteOwnerData()
        {
            DataTable ds = new DataTable();
            ds = cei.GetSiteOwnerData();
            if (ds.Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            getSiteOwnerData();
        }
    }
}