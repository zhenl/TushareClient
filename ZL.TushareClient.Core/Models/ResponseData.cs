using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZL.TushareClient.Core.Models
{
    public class ResponseData
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ResponseMainData MainData { get; set; }


    }
}
