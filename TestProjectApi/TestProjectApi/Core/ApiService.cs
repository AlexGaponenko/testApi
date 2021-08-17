using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace TestProjectApi.Core
{
    public class ApiService : IApiService
    {
        public IRestResponse GetMethod<T>(string uri, string endpoint,  Dictionary<string, string> headers = null, object requestObject = null)
        {
            var client = new RestClient(uri + endpoint);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddParameter(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            return client.Execute(request);

        }

        public IRestResponse GetMethodWrong<T>(string uri, string endpoint, Dictionary<string, int> headers = null, object requestObject = null)
        {
            var client = new RestClient(uri + endpoint);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddParameter(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            return client.Execute(request);

        }

        public int GetStatusCode<T>(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            return numericStatusCode;
        }
        public  List<T> GetResult<T>(IRestResponse restResponse)
        {
            return JsonConvert.DeserializeObject<List<T>>(restResponse.Content, 
            new JsonSerializerSettings 
            { 
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented 
            });
        }
    }
}
