﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class CertificateOfWiremanPermitRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["Application_Id"] = "App-103";
                if (Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                {
                    hdnApplicationId.Value = Session["Application_Id"].ToString();
                    GetData(hdnApplicationId.Value);
                }

            }
        }
        public void GetData(string ApplicationId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetCertificateDataCon_Sup_Wir(ApplicationId);
                if (dt.Rows.Count > 0)
                {
                    lblCertificateNo.Text = dt.Rows[0]["CertificateNo"].ToString();
                    lblDOB.Text = dt.Rows[0]["DOB"].ToString();
                    lblname.Text = dt.Rows[0]["Name"].ToString();
                    lblfatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblApproveDate.Text = dt.Rows[0]["ApprovedDate"].ToString();
                    Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["Signature"]);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
    }
}