using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CEIHaryana.Model
{
    public class HttpRequestExampleTesting
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public string PostJsonData(string url, object inputObject)
        {
            string result;
            var inputJson = JsonConvert.SerializeObject(inputObject);

            ServicePointManager.Expect100Continue = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ProtocolVersion = HttpVersion.Version11;

            // Convert JSON string to bytes using UTF8 encoding
            byte[] data = Encoding.UTF8.GetBytes(inputJson);
            request.ContentLength = data.Length;

            LogToResponse($"Request URL: {url}");
            LogToResponse($"Request Method: {request.Method}");
            LogToResponse($"Request Headers: {request.Headers}");
            LogToResponse($"Request Content Type: {request.ContentType}");
            LogToResponse($"Request Body: {inputJson}");

            string requestHeaders = string.Join(", ", request.Headers.AllKeys.Select(k => $"{k}: {request.Headers[k]}"));
            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                // Get the response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = new StreamReader(response.GetResponseStream()))
                    {
                        result = responseStream.ReadToEnd();
                    }

                    string responseHeaders = string.Join(", ", response.Headers.AllKeys.Select(k => $"{k}: {response.Headers[k]}"));
                    LogToDatabase(url, request.Method, requestHeaders, request.ContentType, inputJson, response.StatusCode.ToString(), responseHeaders, result);

                    LogToResponse($"Response Status Code: {response.StatusCode}");
                    LogToResponse($"Response Headers: {response.Headers}");
                    LogToResponse($"Response Body: {result}");
                }
            }
            //catch (WebException webEx)
            //{
            //    // Handle web exceptions (e.g., 404, 500 errors)
            //    using (var errorResponse = (HttpWebResponse)webEx.Response)
            //    {
            //        using (var responseStream = new StreamReader(errorResponse.GetResponseStream()))
            //        {
            //            result = responseStream.ReadToEnd();
            //        }

            //        //Log.Error("WebException Status: {Status}", webEx.Status);
            //        //Log.Error("Error Response Status Code: {StatusCode}", errorResponse.StatusCode);
            //        //Log.Error("Error Response Headers: {Headers}", errorResponse.Headers);
            //        //Log.Error("Error Response Body: {Body}", result);

            //        // Log error response information
            //        LogToResponse($"WebException Status: {webEx.Status}");
            //        LogToResponse($"Error Response Status Code: {errorResponse.StatusCode}");
            //        LogToResponse($"Error Response Headers: {errorResponse.Headers}");
            //        LogToResponse($"Error Response Body: {result}");

            //        string errorResponseHeaders = string.Join(", ", errorResponse.Headers.AllKeys.Select(k => $"{k}: {errorResponse.Headers[k]}"));
            //        LogToDatabase(url, request.Method, requestHeaders, request.ContentType, inputJson, errorResponse.StatusCode.ToString(), errorResponseHeaders, result);
            //    }
            //}
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
                //Console.WriteLine("Exception: " + ex.Message);
                //Log.Error("Exception: {Message}", ex.Message);
                LogToResponse($"Exception: {ex.Message}");
                LogToDatabase(url, request.Method, requestHeaders, request.ContentType, inputJson, "Exception", ex.Message, result);
            }

            return result;
        }
        //commented on 12 dec 2024 for converting in procedure and applying update on processed records 
        //private void LogToDatabase(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        string query = "INSERT INTO ApiLog (RequestUrl, RequestMethod, RequestHeaders, RequestContentType, RequestBody, ResponseStatusCode, ResponseHeaders, ResponseBody) " +
        //                       "VALUES (@RequestUrl, @RequestMethod, @RequestHeaders, @RequestContentType, @RequestBody, @ResponseStatusCode, @ResponseHeaders, @ResponseBody)";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@RequestUrl", requestUrl);
        //        command.Parameters.AddWithValue("@RequestMethod", requestMethod);
        //        command.Parameters.AddWithValue("@RequestHeaders", requestHeaders ?? (object)DBNull.Value);
        //        command.Parameters.AddWithValue("@RequestContentType", requestContentType ?? (object)DBNull.Value);
        //        command.Parameters.AddWithValue("@RequestBody", requestBody ?? (object)DBNull.Value);
        //        command.Parameters.AddWithValue("@ResponseStatusCode", responseStatusCode ?? (object)DBNull.Value);
        //        command.Parameters.AddWithValue("@ResponseHeaders", responseHeaders ?? (object)DBNull.Value);
        //        command.Parameters.AddWithValue("@ResponseBody", responseBody ?? (object)DBNull.Value);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}

        private void LogToDatabase(string requestUrl, string requestMethod, string requestHeaders, string requestContentType, string requestBody, string responseStatusCode, string responseHeaders, string responseBody)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_LogApiRequestResponse_Saral", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RequestUrl", requestUrl);
                    command.Parameters.AddWithValue("@RequestMethod", requestMethod);
                    command.Parameters.AddWithValue("@RequestHeaders", requestHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestContentType", requestContentType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RequestBody", requestBody ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseStatusCode", responseStatusCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseHeaders", responseHeaders ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResponseBody", responseBody ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private void LogToResponse(string message)
        {
            try
            {
                HttpContext.Current.Response.Write($"{DateTime.Now}: {message}<br />");
                HttpContext.Current.Response.Flush(); // Ensure the log is written immediately
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"Error logging message: {ex.Message}<br />");
            }
        }
    }
}