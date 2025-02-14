using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                    GetEodb_ServiceInformationDetailsAndBindGrid();
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
                DateTime? fromDate = null;
                DateTime? toDate = null;

                if (!string.IsNullOrEmpty(txtFromDate.Text))
                {
                    fromDate = DateTime.Parse(txtFromDate.Text);  
                }

                if (!string.IsNullOrEmpty(txtToDate.Text))
                {
                    toDate = DateTime.Parse(txtToDate.Text);  
                }


                DataSet ds = new DataSet();
                ds = CEI.GetEodb_ServiceInformation_Data_Lift_Escalator_OnLoad(fromDate, toDate);

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


        private void GetEodb_ServiceInformationDetailsAndBindGrid()
        {

            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (!string.IsNullOrEmpty(txtFromDate.Text))
            {
                fromDate = DateTime.Parse(txtFromDate.Text);
            }

            if (!string.IsNullOrEmpty(txtToDate.Text))
            {
                toDate = DateTime.Parse(txtToDate.Text);
            }

            gvInspection.DataSource = null;
            gvInspection.DataBind();

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "Sp_Lift_Escalator_EODB_ServiceInformation_CountCalculate_Details";

            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters if fromDate and toDate are provided
                    if (fromDate.HasValue)
                    {
                        command.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime) { Value = fromDate.Value });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime) { Value = DBNull.Value });
                    }

                    if (toDate.HasValue)
                    {
                        command.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime) { Value = toDate.Value });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime) { Value = DBNull.Value });
                    }

                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds.Tables.Count > 0)
            {
                gvInspection.DataSource = ds.Tables[0];
                gvInspection.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetEodb_ServiceInformation_Data();
            GetEodb_ServiceInformationDetailsAndBindGrid();
        }
    }
}