﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class Attach_DeAttach_Staff : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = (MasterPage)Master;
                var loginTypeLabel = (Label)master.FindControl("LoginType");
                if (loginTypeLabel != null)
                {
                    loginTypeLabel.Text = "Contractor / AttachedORDeattach";
                }


                if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                {
                    GetGridDataToDeattachStaff();
                    GetGridDataForAttachStaff();
                }
            }
        }
        public void GetGridDataForAttachStaff()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["ContractorID"].ToString();

                DataSet ds = new DataSet();
                ds = CEI.WorkIntimationGridDataForDeAttach(LoginID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch { }
        }
        public void GetGridDataToDeattachStaff()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["ContractorID"].ToString();

                DataSet ds = new DataSet();
                ds = CEI.WorkIntimationGridData(LoginID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
            }
            catch { }
        }
    }
}