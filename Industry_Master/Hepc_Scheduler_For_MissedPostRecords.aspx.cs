using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace CEIHaryana.Industry_Master
{
    public partial class Hepc_Scheduler_For_MissedPostRecords : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetList_Industry_MissedRecords_ToHepcPortal();
                hfTaskCompleted.Value = "true";
            }
        }
        public void GetList_Industry_MissedRecords_ToHepcPortal()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("sp_Hepc_GetListOf_Missed_PostRecords", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    DataTable inspectionLogTable = dataSet.Tables[0];
                    int[] inspectionIds = inspectionLogTable.AsEnumerable()
                                                             .Select(row => row.Field<int>("InspectionId"))
                                                             .ToArray();

                    DataTable sldHistoryTable = dataSet.Tables[1];
                    int[] sldIds = sldHistoryTable.AsEnumerable()
                                                  .Select(row => row.Field<int>("InspectionId"))
                                                  .ToArray();

                    if (inspectionIds != null && inspectionIds.Length > 0)
                    {
                        ProcessInspectionIds(inspectionIds);
                    }

                    if (sldIds != null && sldIds.Length > 0)
                    {
                        ProcessSldIds(sldIds);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{ex.Message}')", true);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void ProcessInspectionIds(int[] inspectionIds)
        {
            foreach (var id in inspectionIds)
            {
                try
                {
                    string actiontype = "All";

                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(id), actiontype);
                    foreach (var ApiPostformatresult in ApiPostformatResults)
                    {
                        if (ApiPostformatresult.PremisesType == "Industry")
                        {
                            string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            // string accessToken = "dfsfdsfsfsdf";

                            logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                          "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                          new Industry_Inspection_StageWise_JsonDataFormat_Model
                                          {
                                              actionTaken = ApiPostformatresult.ActionTaken,
                                              commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                              //commentDate = ApiPostformatresult.CommentDate,
                                              commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                              comments = ApiPostformatresult.Comments,
                                              id = ApiPostformatresult.Id,
                                              projectid = ApiPostformatresult.ProjectId,
                                              serviceid = ApiPostformatresult.ServiceId
                                              //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                              //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                          }, ApiPostformatresult, accessToken);

                            if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                            {
                                throw new Exception(logDetails.ErrorMessage);
                            }


                            CEI.LogToIndustryApiSuccessDatabase(
                            logDetails.Url,
                            logDetails.Method,
                            logDetails.RequestHeaders,
                            logDetails.ContentType,
                            logDetails.RequestBody,
                            logDetails.ResponseStatusCode,
                            logDetails.ResponseHeaders,
                            logDetails.ResponseBody,

                            new Industry_Api_Post_DataformatModel
                            {
                                InspectionId = ApiPostformatresult.InspectionId,
                                InspectionLogId = ApiPostformatresult.InspectionLogId,
                                IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                ActionTaken = ApiPostformatresult.ActionTaken,
                                CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                CommentDate = ApiPostformatresult.CommentDate,

                                Comments = ApiPostformatresult.Comments,
                                Id = ApiPostformatresult.Id,
                                ProjectId = ApiPostformatresult.ProjectId,
                                ServiceId = ApiPostformatresult.ServiceId,
                            }

                        );

                        }
                    }
                }
                catch (TokenManagerException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,
                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );
                    string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (IndustryApiException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,

                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );

                    //   string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.ResponseBody.ToString() + "')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (Exception ex)
                {

                    //Commented below to raise errors as per backend
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                }
                finally
                {

                }

            }
        }

        private void ProcessSldIds(int[] sldIds)
        {
            foreach (var id in sldIds)
            {
                try
                {
                    string actiontype = "All";

                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat_Sld(Convert.ToInt32(id), actiontype);
                    foreach (var ApiPostformatresult in ApiPostformatResults)
                    {
                        if (ApiPostformatresult.PremisesType == "Industry")
                        {
                            // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            // string accessToken = "dfsfdsfsfsdf";

                            logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                          "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                          new Industry_Inspection_StageWise_JsonDataFormat_Model
                                          {
                                              actionTaken = ApiPostformatresult.ActionTaken,
                                              commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                              //commentDate = ApiPostformatresult.CommentDate,
                                              commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                              comments = ApiPostformatresult.Comments,
                                              id = ApiPostformatresult.Id,
                                              projectid = ApiPostformatresult.ProjectId,
                                              serviceid = ApiPostformatresult.ServiceId
                                              //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                              //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                          }, ApiPostformatresult, accessToken);

                            if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                            {
                                throw new Exception(logDetails.ErrorMessage);
                            }


                            CEI.LogToIndustryApiSuccessDatabase_Sld(
                            logDetails.Url,
                            logDetails.Method,
                            logDetails.RequestHeaders,
                            logDetails.ContentType,
                            logDetails.RequestBody,
                            logDetails.ResponseStatusCode,
                            logDetails.ResponseHeaders,
                            logDetails.ResponseBody,

                            new Industry_Api_Post_DataformatModel
                            {
                                InspectionId = ApiPostformatresult.InspectionId,
                                InspectionLogId = ApiPostformatresult.InspectionLogId,
                                IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                ActionTaken = ApiPostformatresult.ActionTaken,
                                CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                CommentDate = ApiPostformatresult.CommentDate,

                                Comments = ApiPostformatresult.Comments,
                                Id = ApiPostformatresult.Id,
                                ProjectId = ApiPostformatresult.ProjectId,
                                ServiceId = ApiPostformatresult.ServiceId,
                            }

                        );

                        }
                    }

                }
                catch (TokenManagerException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase_Sld(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,
                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );
                    // string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (IndustryApiException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase_Sld(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,

                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );

                    // string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.ResponseBody.ToString() + "')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (Exception ex)
                {

                    //Commented below to raise errors as per backend
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                }
                finally
                {

                    //connection.Close();
                }
            }
        }

        //public void GetList_Industry_MissedRecords_ToHepcPortal()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        try
        //        {
        //            SqlCommand command = new SqlCommand("sp_Industry_GetListOf_HepcErrorLogs", connection);
        //            command.CommandType = CommandType.StoredProcedure;

        //            SqlDataReader reader = command.ExecuteReader();
        //            List<Industry_Api_Post_DataformatModel> errorLogs = new List<Industry_Api_Post_DataformatModel>();

        //            while (reader.Read())
        //            {
        //                Industry_Api_Post_DataformatModel log = new Industry_Api_Post_DataformatModel
        //                {
        //                    PremisesType = reader["PremisesType"].ToString(),
        //                    InspectionId = Convert.ToInt32(reader["InspectionId"]),
        //                    InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
        //                    IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
        //                    ActionTaken = reader["actionTaken"].ToString(),
        //                    CommentByUserLogin = reader["commentByUserLogin"].ToString(),
        //                    CommentDate = Convert.ToDateTime(reader["commentDate"]),
        //                    Comments = reader["comments"].ToString(),
        //                    Id = reader["id"].ToString(),
        //                    ProjectId = reader["projectid"].ToString(),
        //                    ServiceId = reader["serviceid"].ToString()
        //                };

        //                errorLogs.Add(log);
        //            }
        //            reader.Close();

        //            foreach (var errorLog in errorLogs)
        //            {
        //                ProcessErrorLog(errorLog);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{ex.Message}')", true);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}



        //private void ProcessErrorLog(Industry_Api_Post_DataformatModel ApiPostformatresult)
        //{
        //    try
        //    {

        //        if (ApiPostformatresult.PremisesType == "Industry")
        //        {
        //            string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
        //            //string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
        //            //string accessToken = "dfsfdsfsfsdf";

        //            logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
        //                          "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
        //                          new Industry_Inspection_StageWise_JsonDataFormat_Model
        //                          {
        //                              actionTaken = ApiPostformatresult.ActionTaken,
        //                              commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
        //                              //commentDate = ApiPostformatresult.CommentDate,
        //                              commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        //                              comments = ApiPostformatresult.Comments,
        //                              id = ApiPostformatresult.Id,
        //                              projectid = ApiPostformatresult.ProjectId,
        //                              serviceid = ApiPostformatresult.ServiceId
        //                              //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
        //                              //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
        //                          }, ApiPostformatresult, accessToken);

        //            if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
        //            {
        //                throw new Exception(logDetails.ErrorMessage);
        //            }


        //            CEI.LogToIndustryApiSuccessDatabase_Scheduler(
        //            logDetails.Url,
        //            logDetails.Method,
        //            logDetails.RequestHeaders,
        //            logDetails.ContentType,
        //            logDetails.RequestBody,
        //            logDetails.ResponseStatusCode,
        //            logDetails.ResponseHeaders,
        //            logDetails.ResponseBody,

        //            new Industry_Api_Post_DataformatModel
        //            {
        //                InspectionId = ApiPostformatresult.InspectionId,
        //                InspectionLogId = ApiPostformatresult.InspectionLogId,
        //                IncomingJsonId = ApiPostformatresult.IncomingJsonId,
        //                ActionTaken = ApiPostformatresult.ActionTaken,
        //                CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
        //                CommentDate = ApiPostformatresult.CommentDate,

        //                Comments = ApiPostformatresult.Comments,
        //                Id = ApiPostformatresult.Id,
        //                ProjectId = ApiPostformatresult.ProjectId,
        //                ServiceId = ApiPostformatresult.ServiceId,
        //            }

        //        );

        //        }

        //    }
        //    catch (TokenManagerException ex)
        //    {
        //        CEI.LogToIndustryApiErrorDatabase_Scheduler(
        //            ex.RequestUrl,
        //            ex.RequestMethod,
        //            ex.RequestHeaders,
        //            ex.RequestContentType,
        //            ex.RequestBody,
        //            ex.ResponseStatusCode,
        //            ex.ResponseHeaders,
        //            ex.ResponseBody,
        //            new Industry_Api_Post_DataformatModel
        //            {
        //                InspectionId = ex.InspectionId,
        //                InspectionLogId = ex.InspectionLogId,
        //                IncomingJsonId = ex.IncomingJsonId,
        //                ActionTaken = ex.ActionTaken,
        //                CommentByUserLogin = ex.CommentByUserLogin,
        //                CommentDate = ex.CommentDate,
        //                Comments = ex.Comments,
        //                Id = ex.Id,
        //                ProjectId = ex.ProjectId,
        //                ServiceId = ex.ServiceId,
        //            }
        //        );
        //        // string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
        //    }
        //    catch (IndustryApiException ex)
        //    {
        //        CEI.LogToIndustryApiErrorDatabase_Scheduler(
        //            ex.RequestUrl,
        //            ex.RequestMethod,
        //            ex.RequestHeaders,
        //            ex.RequestContentType,
        //            ex.RequestBody,
        //            ex.ResponseStatusCode,
        //            ex.ResponseHeaders,
        //            ex.ResponseBody,
        //            new Industry_Api_Post_DataformatModel
        //            {
        //                InspectionId = ex.InspectionId,
        //                InspectionLogId = ex.InspectionLogId,
        //                IncomingJsonId = ex.IncomingJsonId,
        //                ActionTaken = ex.ActionTaken,
        //                CommentByUserLogin = ex.CommentByUserLogin,
        //                CommentDate = ex.CommentDate,

        //                Comments = ex.Comments,
        //                Id = ex.Id,
        //                ProjectId = ex.ProjectId,
        //                ServiceId = ex.ServiceId,
        //            }
        //        );

        //        ///string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
        //    }
        //    finally
        //    {

        //    }

        //}
    }
}