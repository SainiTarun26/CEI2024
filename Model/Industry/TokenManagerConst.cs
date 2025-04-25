using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using CEI_PRoject;

namespace CEIHaryana.Model.Industry
{
    public class TokenManagerConst
    {
        private static readonly string clientId = "KarLGm7E";
         private static readonly string clientSecret = "mON0xp";  //TestServer Token Commented on 24 jan 2025 
		//private static readonly string clientSecret = "H5cWdzDv";
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

        public static string GetAccessToken(Industry_Api_Post_DataformatModel ApiPostformatresult)
        {

            var tokens = GetTokensFromDatabase();

            if (tokens == null || tokens.RefreshTokenExpiry <= DateTime.Now)
            {
                tokens = RefreshTokens(ApiPostformatresult);
                SaveTokensToDatabase(tokens, true);
            }

            if (tokens.AccessTokenExpiry <= DateTime.Now)
            {
                tokens.AccessToken = FetchAccessToken(tokens.RefreshToken, ApiPostformatresult);
                tokens.AccessTokenExpiry = DateTime.Now.AddSeconds(30);
                SaveTokensToDatabase(tokens, false);
            }

            return tokens.AccessToken;
        }

        private static TokenInfo RefreshTokens(Industry_Api_Post_DataformatModel ApiPostformatresult)
        {
            var refreshToken = FetchRefreshToken(clientId, clientSecret, ApiPostformatresult);
            var accessToken = FetchAccessToken(refreshToken, ApiPostformatresult);

            return new TokenInfo
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiry = DateTime.Now.AddDays(15),
                AccessToken = accessToken,
                AccessTokenExpiry = DateTime.Now.AddSeconds(30)
            };
        }

        private static string FetchRefreshToken(string clientId, string clientSecret, Industry_Api_Post_DataformatModel ApiPostformatresult)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var requestBody = new
            {
                clientId = clientId,
                clientSecret = clientSecret
            };
            var inputJson = JsonConvert.SerializeObject(requestBody);
            string result = null;

            try
            {
                string response = client.UploadString("https://staging.investharyana.in/api/getrefresh-token", inputJson);
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);
                result = jsonResponse.token;

                CEI CEI = new CEI();
                //CEI.LogToIndustryApiErrorDatabase("https://staging.investharyana.in/api/getrefresh-token", "POST", client.Headers.ToString(), "application/json", inputJson, "200", client.ResponseHeaders.ToString(), response, ApiPostformatresult);
            }
            catch (WebException ex)
            {
                string response = null;
                if (ex.Response != null)
                {
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }

                    throw new TokenManagerException(
                        //ex.Message + " | SSL/TLS Error: " + ex.Status.ToString()
                        ex.Message + " | " + ex.Status.ToString(),
                        "https://staging.investharyana.in/api/getrefresh-token",
                        "POST",
                        client.Headers.ToString(),
                        "application/json",
                        inputJson,
                        ex.Status.ToString(),
                        ex.Response?.Headers.ToString(),
                        response,
                        ApiPostformatresult.PremisesType.ToString(),
                        ApiPostformatresult.InspectionId,
                        ApiPostformatresult.InspectionLogId,
                        ApiPostformatresult.IncomingJsonId,
                        ApiPostformatresult.ActionTaken,
                        ApiPostformatresult.CommentByUserLogin,
                        ApiPostformatresult.CommentDate,
                        ApiPostformatresult.Comments,
                        ApiPostformatresult.Id,
                        ApiPostformatresult.ProjectId,
                        ApiPostformatresult.ServiceId
                    );
                }
                else
                {
                    // Handle cases where there's no response, such as server down, DNS failure, etc.
                    throw new TokenManagerException(
                        $"Failed to connect to server: {ex.Message}",
                        "https://staging.investharyana.in/api/getaccess-token",
                        "POST",
                        client.Headers.ToString(),
                        "application/json",
                        inputJson,
                        ex.Status.ToString(),
                        null, // No response headers
                        null, // No response body
                        ApiPostformatresult.PremisesType.ToString(),
                        ApiPostformatresult.InspectionId,
                        ApiPostformatresult.InspectionLogId,
                        ApiPostformatresult.IncomingJsonId,
                        ApiPostformatresult.ActionTaken,
                        ApiPostformatresult.CommentByUserLogin,
                        ApiPostformatresult.CommentDate,
                        ApiPostformatresult.Comments,
                        ApiPostformatresult.Id,
                        ApiPostformatresult.ProjectId,
                        ApiPostformatresult.ServiceId
                    );
                }
            }

            return result;
        }

        private static string FetchAccessToken(string refreshToken, Industry_Api_Post_DataformatModel ApiPostformatresult)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var requestBody = new
            {
                refresh_token = refreshToken
            };
            var inputJson = JsonConvert.SerializeObject(requestBody);
            string result = null;

            try
            {
                string response = client.UploadString("https://staging.investharyana.in/api/getaccess-token", inputJson);
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);
                result = jsonResponse.token;

                CEI CEI = new CEI();
                //CEI.LogToIndustryApiErrorDatabase("https://staging.investharyana.in/api/getaccess-token", "POST", client.Headers.ToString(), "application/json", inputJson, "200", client.ResponseHeaders.ToString(), response, ApiPostformatresult);
            }
            catch (WebException ex)
            {
                string response = null;
                if (ex.Response != null)
                {
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                    }

                    // If there's a response, handle it as before
                    throw new TokenManagerException(
                        ex.Message,
                        "https://staging.investharyana.in/api/getaccess-token",
                        "POST",
                        client.Headers.ToString(),
                        "application/json",
                        inputJson,
                        ex.Status.ToString(),
                        ex.Response.Headers.ToString(),
                        response,
                        ApiPostformatresult.PremisesType.ToString(),
                        ApiPostformatresult.InspectionId,
                        ApiPostformatresult.InspectionLogId,
                        ApiPostformatresult.IncomingJsonId,
                        ApiPostformatresult.ActionTaken,
                        ApiPostformatresult.CommentByUserLogin,
                        ApiPostformatresult.CommentDate,
                        ApiPostformatresult.Comments,
                        ApiPostformatresult.Id,
                        ApiPostformatresult.ProjectId,
                        ApiPostformatresult.ServiceId
                    );
                }
                else
                {
                    // Handle cases where there's no response, such as server down, DNS failure, etc.
                    throw new TokenManagerException(
                        $"Failed to connect to server: {ex.Message}",
                        "https://staging.investharyana.in/api/getaccess-token",
                        "POST",
                        client.Headers.ToString(),
                        "application/json",
                        inputJson,
                        ex.Status.ToString(),
                        null, // No response headers
                        null, // No response body
                        ApiPostformatresult.PremisesType.ToString(),
                        ApiPostformatresult.InspectionId,
                        ApiPostformatresult.InspectionLogId,
                        ApiPostformatresult.IncomingJsonId,
                        ApiPostformatresult.ActionTaken,
                        ApiPostformatresult.CommentByUserLogin,
                        ApiPostformatresult.CommentDate,
                        ApiPostformatresult.Comments,
                        ApiPostformatresult.Id,
                        ApiPostformatresult.ProjectId,
                        ApiPostformatresult.ServiceId
                    );
                }
            }


            return result;
        }
        //server down
        //private static string FetchAccessToken(string refreshToken, Industry_Api_Post_DataformatModel ApiPostformatresult)
        //{
        //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    var client = new WebClient();
        //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
        //    var requestBody = new
        //    {
        //        refresh_token = refreshToken
        //    };
        //    var inputJson = JsonConvert.SerializeObject(requestBody);
        //    string result = null;

        //    try
        //    {
        //        string response = client.UploadString("https://staging.investharyana.in/api/getaccess-token", inputJson);
        //        dynamic jsonResponse = JsonConvert.DeserializeObject(response);
        //        result = jsonResponse.token;

        //        CEI CEI = new CEI();
        //        //CEI.LogToIndustryApiErrorDatabase("https://staging.investharyana.in/api/getaccess-token", "POST", client.Headers.ToString(), "application/json", inputJson, "200", client.ResponseHeaders.ToString(), response, ApiPostformatresult);
        //    }
        //    catch (WebException ex)
        //    {
        //        //string response = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
        //        string response = null;
        //        if (ex.Response != null)
        //        {
        //            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
        //            {
        //                response = reader.ReadToEnd();
        //            }
        //        }

        //        throw new TokenManagerException(
        //            ex.Message,
        //            "https://staging.investharyana.in/api/getaccess-token",
        //            "POST",
        //            client.Headers.ToString(),
        //            "application/json",
        //            inputJson,
        //            ex.Status.ToString(),
        //            ex.Response.Headers.ToString(),
        //            response,
        //            ApiPostformatresult.PremisesType.ToString(),
        //            ApiPostformatresult.InspectionId,
        //            ApiPostformatresult.InspectionLogId,
        //            ApiPostformatresult.IncomingJsonId,
        //            ApiPostformatresult.ActionTaken,
        //            ApiPostformatresult.CommentByUserLogin,
        //            ApiPostformatresult.CommentDate,
        //            ApiPostformatresult.Comments,
        //            ApiPostformatresult.Id,
        //            ApiPostformatresult.ProjectId,
        //            ApiPostformatresult.ServiceId
        //        );
        //    }

        //    return result;
        //}

        private static TokenInfo GetTokensFromDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 * FROM Tokens ORDER BY Id DESC", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TokenInfo
                            {
                                RefreshToken = reader["RefreshToken"].ToString(),
                                RefreshTokenExpiry = Convert.ToDateTime(reader["RefreshTokenExpiry"]),
                                AccessToken = reader["AccessToken"].ToString(),
                                AccessTokenExpiry = Convert.ToDateTime(reader["AccessTokenExpiry"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        private static void SaveTokensToDatabase(TokenInfo tokens, bool isNewRefreshToken)
        {
            string query;
            if (isNewRefreshToken)
            {
                query = "INSERT INTO Tokens (RefreshToken, RefreshTokenExpiry, AccessToken, AccessTokenExpiry) VALUES (@RefreshToken, @RefreshTokenExpiry, @AccessToken, @AccessTokenExpiry)";
            }
            else
            {
                query = "UPDATE Tokens SET AccessToken = @AccessToken, AccessTokenExpiry = @AccessTokenExpiry WHERE RefreshToken = @RefreshToken";
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RefreshToken", tokens.RefreshToken);
                    command.Parameters.AddWithValue("@RefreshTokenExpiry", tokens.RefreshTokenExpiry);
                    command.Parameters.AddWithValue("@AccessToken", tokens.AccessToken);
                    command.Parameters.AddWithValue("@AccessTokenExpiry", tokens.AccessTokenExpiry);
                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
