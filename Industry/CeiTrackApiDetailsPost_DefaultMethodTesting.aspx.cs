using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using CEIHaryana.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Threading.Tasks;

namespace CEIHaryana.Industry
{
    public partial class CeiTrackApiDetailsPost_DefaultMethodTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SaralTrackingModal> inputObject = GetSaralTrackingDataFromDatabase();
            var inputArray = inputObject.ToArray();
            var httpRequestExample = new HttpRequestExampleTesting();

            // var httpRequestExample = new HttpRequestExampleTesting_LogEachRecord();

            if (inputArray.Length > 0)
            {
                string url = "http://ws.edisha.gov.in/api/Values/SaralBulkUpload";
                string response = httpRequestExample.PostJsonData(url, inputObject);
                // string response = httpRequestExample.PostJsonData(url, inputObject.Cast<SaralTrackingModal>().ToList());
            }
        }

        private List<SaralTrackingModal> GetSaralTrackingDataFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "sp_GetSaralTrackingDataToSend_Nic_Saral";
            List<SaralTrackingModal> saralTrackingList = new List<SaralTrackingModal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CreatedBy", "createdBy");
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var modal = new SaralTrackingModal
                            {
                                DeptCode = reader["DeptCode"].ToString(),
                                ApplicationCode = reader["ApplicationCode"].ToString(),
                                ServiceCode = reader["ServiceCode"].ToString(),
                                SubserviceCode = reader["SubserviceCode"].ToString(),
                                FileReferenceNo = reader["FileReferenceNo"].ToString(),
                                ReceiptDate = reader["ReceiptDate"].ToString(),
                                Name = reader["Name"].ToString(),
                                Father_HusbandName = reader["Father_HusbandName"].ToString(),
                                gender = reader["gender"].ToString(),
                                Address = reader["Address"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                email_id = reader["email_id"].ToString(),
                                RTSDueDate = reader["RTSDueDate"].ToString(),
                                DistrictCode = reader["DistrictCode"].ToString(),
                                LocationCode = reader["LocationCode"].ToString(),
                                LocationType = reader["LocationType"].ToString(),
                                LocationName = reader["LocationName"].ToString(),
                                SourceCode = reader["SourceCode"].ToString(),
                                LastActionBy = reader["LastActionBy"].ToString(),
                                LastActionDate = reader["LastActionDate"].ToString(),
                                Remarks_Eng = reader["Remarks_Eng"].ToString(),
                                Level = reader["Level"].ToString(),
                                FileWithUser = reader["FileWithUser"].ToString(),
                                LastAction = reader["LastAction"].ToString(),
                                LastStatusDescription = reader["LastStatusDescription"].ToString(),
                                Saral_Id = reader["Saral_Id"].ToString(),
                                Family_ID = reader["Family_ID"].ToString(),
                                Member_ID = reader["Member_ID"].ToString(),
                                HEPC_Caf_No = reader["HEPC_Caf_No"].ToString(),
                                NatureOfBenefit = reader["NatureOfBenefit"].ToString(),
                                AmountOfBenefit = reader["AmountOfBenefit"].ToString(),
                                BenefitDetailsInKind = reader["BenefitDetailsInKind"].ToString(),
                                UnitOfBenefit = reader["UnitOfBenefit"].ToString(),
                                DateOfBenefit = reader["DateOfBenefit"].ToString()
                            };
                            saralTrackingList.Add(modal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return saralTrackingList;
        }
    }
}