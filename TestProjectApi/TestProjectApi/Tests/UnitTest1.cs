using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TestProjectApi.BaserTestLogic;
using TestProjectApi.Core;
using TestProjectApi.Core.Helper;
using TestProjectApi.Tests;

namespace TestProjectApi
{
    public class PositiveTest
    {
        BaseLogic logic => new BaseLogic();
        private TestData dataSome => new TestData();
        IApiService client = new ApiService();
        IRestResponse myResponse;
        [SetUp]
        public void Setup()
        {
            myResponse = client.GetMethod<DTO>(Constant.baseUrl, Constant.housesEndpoint, dataSome.filters);
        }

        [Test, Order(1)]
        [Description("Checking the filtering")]
        public void Test1()
        {
            Assert.AreEqual(client.GetStatusCode<DTO>(myResponse), 200, "Request server is correct");
            List<DTO> getListObj = client.GetResult<DTO>(myResponse);
            Assert.True(logic.checkFilterByParam(dataSome.filterRegion, "Region", getListObj), "The filter is not working correct");
            Assert.True(logic.checkIsNotEmpty(dataSome.words, getListObj), "The filter is not working correct");
        }

        [Test, Order(2)]
        [Description("Checking the schema")]
        public void Test2()
        {
            Assert.True(logic.IsJsonValid<SchemaClass>(myResponse), "Json schema is not correct");
        }
    }
}