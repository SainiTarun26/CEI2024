using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadData2();
            }
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "SELECT * FROM tbl_Industry_Error_ApiLog"; // Replace with your table name

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log the error, display a message)
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void LoadData2()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "SELECT * FROM tokens"; // Replace with your table name

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        GridView2.DataSource = dataTable;
                        GridView2.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log the error, display a message)
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}