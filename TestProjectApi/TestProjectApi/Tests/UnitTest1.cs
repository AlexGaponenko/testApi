using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TestProjectApi.BaserTestLogic;
using TestProjectApi.Core;
using TestProjectApi.Core.Helper;
using TestProjectApi.Tests;

namespace TestProjectApi
{
    public class TestsApiTests
    {
        BaseLogic logic => new BaseLogic();
        TestData data => new TestData();
        IApiService client = new ApiService();

        [SetUp]
        public void Setup()
        {
            //var getResult = client.GetMethod<DTO>(Constant.baseUrl, Constant.housesEndpoint);
        }

        [Test, Order(1)]
        public void Test1()
        {
            IRestResponse getResult = client.GetMethod<DTO>(Constant.baseUrl, Constant.housesEndpoint, data.filters);

            Assert.AreEqual(client.GetStatusCode<DTO>(getResult), 200, "Request server is correct");
            List<DTO> getListObj = client.GetResult<DTO>(getResult);
            Assert.True(logic.checkFilterByParam(data.filterRegion, "Region", getListObj), "The filter is not working correct");
            Assert.True(logic.checkIsNotEmpty(data.words, getListObj), "The filter is not working correct");
        }
    }
}