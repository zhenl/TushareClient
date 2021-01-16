using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZL.TushareClient.Core
{
    public class ApiPara
    {
        [JsonProperty("api_name")]
        public string ApiName { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("params")]
        public Dictionary<string,string> Paras { get; set; }

        [JsonProperty("fields")]
        public List<string> Fields { get; set; }
        
        public ApiPara()
        {
            Paras = new Dictionary<string, string>();
            Fields = new List<string>();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
