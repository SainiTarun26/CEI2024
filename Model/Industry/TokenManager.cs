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
    public class TokenManager
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        private static readonly string clientId = "cei";
        private static readonly string clientSecret = "KarLGm7E";

        public static string GetAccessToken(SqlTransaction transaction)
        {
            var tokens = GetTokensFromDatabase(transaction);

            if (tokens == null || tokens.RefreshTokenExpiry <= DateTime.Now)
            {
                tokens = RefreshTokens();
                SaveTokensToDatabase(tokens, true, transaction); // Create new row for new refresh token
            }

            if (tokens.AccessTokenExpiry <= DateTime.Now)
            {
                tokens.AccessToken = FetchAccessToken(tokens.RefreshToken);
                tokens.AccessTokenExpiry = DateTime.Now.AddSeconds(30); // Assuming 30s expiry
                SaveTokensToDatabase(tokens, false, transaction); // Update existing row for new access token
            }

            return tokens.AccessToken;
        }

        private static TokenInfo RefreshTokens()
        {
            var refreshToken = FetchRefreshToken(clientId, clientSecret);
            var accessToken = FetchAccessToken(refreshToken);

            return new TokenInfo
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiry = DateTime.Now.AddDays(15), // Assuming 15 days expiry
                AccessToken = accessToken,
                AccessTokenExpiry = DateTime.Now.AddSeconds(30) // Assuming 30s expiry
            };
        }

        private static string FetchRefreshToken(string clientId, string clientSecret)
        {
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
                result = jsonResponse.refresh_token;

                CEI CEI = new CEI();
                CEI.LogToIndustryApiErrorDatabase("https://staging.investharyana.in/api/getrefresh-token", "POST", client.Headers.ToString(), "application/json", inputJson, "200", client.ResponseHeaders.ToString(), response);
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
                }

                throw new TokenManagerException(
                    ex.Message,
                    "https://staging.investharyana.in/api/getrefresh-token",
                    "POST",
                    client.Headers.ToString(),
                    "application/json",
                    inputJson,
                    ex.Status.ToString(),
                    ex.Response?.Headers.ToString(),
                    response
                );
            }

            return result;
        }

        private static string FetchAccessToken(string refreshToken)
        {
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
                result = jsonResponse.access_token;

                CEI CEI = new CEI();
                CEI.LogToIndustryApiErrorDatabase("https://staging.investharyana.in/api/getaccess-token", "POST", client.Headers.ToString(), "application/json", inputJson, "200", client.ResponseHeaders.ToString(), response);
            }
            catch (WebException ex)
            {
                string response = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                throw new TokenManagerException(
                    ex.Message,
                    "https://staging.investharyana.in/api/getaccess-token",
                    "POST",
                    client.Headers.ToString(),
                    "application/json",
                    inputJson,
                    ex.Status.ToString(),
                    ex.Response.Headers.ToString(),
                    response
                );
            }

            return result;
        }

        private static TokenInfo GetTokensFromDatabase(SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Tokens ORDER BY Id DESC", transaction.Connection, transaction))
            {
                using (SqlDataReader reader = command.ExecuteReader())
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
            return null;
        }

        //private static TokenInfo GetTokensFromDatabase(SqlTransaction transaction)
        //{
        //    using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Tokens ORDER BY Id DESC", transaction.Connection, transaction))
        //    {
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            return new TokenInfo
        //            {
        //                RefreshToken = reader["RefreshToken"].ToString(),
        //                RefreshTokenExpiry = Convert.ToDateTime(reader["RefreshTokenExpiry"]),
        //                AccessToken = reader["AccessToken"].ToString(),
        //                AccessTokenExpiry = Convert.ToDateTime(reader["AccessTokenExpiry"])
        //            };
        //        }
        //    }
        //    return null;
        //}

        private static void SaveTokensToDatabase(TokenInfo tokens, bool isNewRefreshToken, SqlTransaction transaction)
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

            using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
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
