using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class StaticPage3 : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetEodb_ServiceInformation_Data();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        public void GetEodb_ServiceInformation_Data()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetEodb_ServiceInformation_Data_Lift_Escalator_OnLoad();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblAllLiftEscalatorInspection.Text = ds.Tables[0].Rows[0]["TotoalNoApplicationReceived"].ToString();
                    lblTotalApprovedLiftEscalatorInspection.Text = ds.Tables[0].Rows[0]["TotoalNoApplicationApproved"].ToString();
                    lblAvgTimeTakenForRegs.Text = ds.Tables[0].Rows[0]["AverageTimeTakenForRegistraion"].ToString();
                    lblMinTimeTakenForRegs.Text = ds.Tables[0].Rows[0]["MinTimeTakenForRegistraion"].ToString();
                    lblMaxTimeTakenForRegs.Text = ds.Tables[0].Rows[0]["MaxTimeTakenForRegistraion"].ToString();
                    lblAverageFees.Text = ds.Tables[0].Rows[0]["AverageFeesTakenForRegistraion"].ToString();
                    lblMedianTimeTakenForRegs.Text = ds.Tables[0].Rows[0]["MedianTimeTakenForRegistration"].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}