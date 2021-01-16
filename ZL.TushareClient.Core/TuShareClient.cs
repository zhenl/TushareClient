using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using ZL.TushareClient.Core.Models;

namespace ZL.TushareClient.Core
{
    public class TuShareClient
    {
        private string token { get; set; }

        public TuShareClient(string token)
        {
            this.token = token;
        }

        public async Task<string> CallApi(string apiName, Dictionary<string, string> paras, List<string> fields)
        {
            var httpClient = new HttpClient();
            var apipara = new ApiPara
            {
                ApiName=apiName,
                Token=token,
                Paras=paras,
                Fields=fields
            };
            var content = apipara.ToJson();
            var response= await httpClient.PostAsync("http://api.waditu.com", new StringContent(content));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<JObject> CallApiJson(string apiName, Dictionary<string, string> paras, List<string> fields)
        {
            var res = await CallApi(apiName, paras, fields);
            if (string.IsNullOrEmpty(res))
            {
                return (JObject)JsonConvert.DeserializeObject(res);
            }

            return null;
        }

        public async Task<ResponseData> CallApiData(string apiName, Dictionary<string, string> paras, List<string> fields)
        {
            var res = await CallApi(apiName, paras, fields);
            if (!string.IsNullOrEmpty(res))
            {
                return (ResponseData)JsonConvert.DeserializeObject(res,typeof (ResponseData));
            }

            return null;
        }

        public async Task<DataTable> CallApiDataTable(string apiName, Dictionary<string, string> paras, List<string> fields)
        {
            var dt = new DataTable();
            var resp = await CallApiData(apiName, paras, fields);
            if (resp != null)
            {
                if (resp.MainData != null)
                {
                    foreach (var str in resp.MainData.Fields)
                    {
                        dt.Columns.Add(str);
                    }
                    foreach (var lst in resp.MainData.Items)
                    {
                        var row = dt.NewRow();
                        for (var i = 0; i < lst.Count; i++)
                        {
                            var val = lst[i];
                            row[i] = val;
                        }
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    throw new Exception(resp.Message);
                }
                
            }
            else
            {
                throw new Exception("获取数据出现错误");
            }
            return dt;
        }
    }
}
