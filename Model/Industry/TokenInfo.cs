using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEIHaryana.Model.Industry
{
    public class TokenInfo
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiry { get; set; }
    }
}