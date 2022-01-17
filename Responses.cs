using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstoolTechRestFullAPI.Models
{
    public class Responses
    {
        public string tiltl { get; set; }
        public string message { get; set; }
    }

    public class ResponsesLogin
    {
        public string scritkey { get; set; }
        public string username { get; set; }
    }


    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("client_id")]
        public string clientid { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty(".issued")]
        public string issued { get; set; }

        [JsonProperty(".expires")]
        public string expires { get; set; }

    }



    public class Responselogin
    {

        public string AccessToken { get; set; }
    
        public string TokenType { get; set; }
     
        public int ExpiresIn { get; set; }
   
        public string RefreshToken { get; set; }
   
        public string Error { get; set; }

     
        public string clientid { get; set; }

     
        public string userName { get; set; }

      
        public string issued { get; set; }

      
        public string expires { get; set; }

    }
}