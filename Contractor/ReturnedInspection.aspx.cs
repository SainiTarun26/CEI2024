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

namespace CEIHaryana.Contractor
{
    public partial class ReturnedInspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {

                    GetGridData();
                    GetinspectionGridData();
                    GetAssigenedGridData();
                }
            }
        }
        public void GetGridData()
        {
            try
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {
                    ContractorId = Session["ContractorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.WorkIntimationGridData(ContractorId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlAssignSupervisor.DataSource = ds;
                        ddlAssignSupervisor.DataValueField = "LicenseNo";
                        ddlAssignSupervisor.DataTextField = "LicenseNoText";
                        ddlAssignSupervisor.DataBind();
                        ddlAssignSupervisor.Items.Insert(0, new ListItem("--Select--", "-1"));
                        ds.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void GetAssigenedGridData()
        {
            try
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {
                    ContractorId = Convert.ToString(Session["ContractorID"]);
                    ContractorId = Session["ContractorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.GetAssignedGridDataForContractor(ContractorId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();                       
                    }
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void GetinspectionGridData()
        {
            if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
            {
                ContractorId = Convert.ToString(Session["ContractorID"]);
                //string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                //using (SqlConnection connection = new SqlConnection(connectionstring))
                //{                   
                //    SqlCommand command = new SqlCommand("Sp_ReturnedInspection_PendingAssignment_AtContractor", connection);
                //    command.Parameters.AddWithValue("@ContractorLoginId", ContractorId);
                //    SqlDataAdapter adapter = new SqlDataAdapter(command);

                //    DataSet dataSet = new DataSet();
                //    connection.Open();
                //    adapter.Fill(dataSet);
                //    GridView1.DataSource = dataSet.Tables[0];
                //    GridView1.DataBind();
                //
                //}
                DataSet ds = new DataSet();
                ds = CEI.GetReturnInspectionForContractor(ContractorId);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();                    
                }

            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
            {
                string AssignSupervisor = ddlAssignSupervisor.SelectedValue;
                ContractorId = Convert.ToString(Session["ContractorID"]);
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    con.Open();
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            Label lblIntimation = (Label)row.FindControl("lblIntimation");
                            Label TestReportCount = (Label)row.FindControl("lblTestReportCount");
                            int Count = Convert.ToInt32(TestReportCount.Text);

                            int inspectionId = Convert.ToInt32(row.Cells[1].Text);
                            string TestReportId = row.Cells[2].Text;
                            string InstallationType = row.Cells[3].Text;

                            SqlCommand cmd = new SqlCommand("sp_InsertReturnInspectionAssignByContractor", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@InspectionId", inspectionId);
                            cmd.Parameters.AddWithValue("@IntimationId", lblIntimation.Text);
                            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                            cmd.Parameters.AddWithValue("@Count", Count);
                            cmd.Parameters.AddWithValue("@TestReportId", TestReportId);
                            cmd.Parameters.AddWithValue("@AssignedSupervisore", AssignSupervisor);
                            cmd.Parameters.AddWithValue("@CreatedBy", ContractorId);
                           // cmd.ExecuteNonQuery();
                        }
                    }
                }
                GetinspectionGridData();
                GetAssigenedGridData();
                ddlAssignSupervisor.SelectedValue = "-1";
            }
        }
    }
}