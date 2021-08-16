using RestSharp;
using System.Collections.Generic;

namespace TestProjectApi.Core
{
    public interface IApiService
    {
        IRestResponse GetMethod<T>(string uri, string endpoint, Dictionary<string, string> headers = null, object requestObject = null);
        List<T> GetResult<T>(IRestResponse response);
        int GetStatusCode<T>(IRestResponse response);
    }
}
