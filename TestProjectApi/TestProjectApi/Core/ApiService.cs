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
        /// <summary>
        /// Get method with parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="endpoint"></param>
        /// <param name="headers">Not required</param>
        /// <param name="requestObject">Not required</param>
        /// <returns>IRestResponse</returns>
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

        /// <summary>
        /// Not correct Get method with parameters 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="endpoint"></param>
        /// <param name="headers">Not required</param>
        /// <param name="requestObject">Not required</param>
        /// <returns>IRestResponse</returns>
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

        /// <summary>
        /// Get method without parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns>Status code</returns>
        public int GetStatusCode<T>(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            return numericStatusCode;
        }

        /// <summary>
        /// Parse response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restResponse"></param>
        /// <returns>List objects of a given type</returns>
        public List<T> GetResult<T>(IRestResponse restResponse)
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
