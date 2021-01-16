using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZL.TushareClient.Core.Models
{
    public class ResponseMainData
    {
        [JsonProperty("fields")]

        public List<string> Fields { get; set; }

        [JsonProperty("items")]
        public List<List<string>> Items { get; set; }
        public ResponseMainData()
        {
            Fields = new List<string>();
            Items = new List<List<string>>();
        }
    }
}
