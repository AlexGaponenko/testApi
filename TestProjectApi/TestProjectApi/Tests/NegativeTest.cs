using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TestProjectApi.Core;
using TestProjectApi.Core.Helper;

namespace TestProjectApi.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("NegativeTest")]
    public class NegativeTest : AllureFixture
    {
        private TestData dataSome => new TestData();
        IApiService client = new ApiService();
        IRestResponse myResponse;
        [SetUp]
        public void Setup()
        {
            myResponse = client.GetMethodWrong<DTO>(Constant.baseUrl, Constant.housesEndpoint, dataSome.filtersIncorrect);
        }

        [Test, Order(1)]
        [Description("Negative test")]
        public void Test1()
        {
            List<DTO> getListObj = client.GetResult<DTO>(myResponse);
            Assert.AreEqual(getListObj.Count, 0, "Respomse is not empty");
        }
    }
}
