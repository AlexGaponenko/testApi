using Allure.Commons;
using NUnit.Framework;
using System;
using System.IO;
using TestProjectApi.Core.Utilites;

namespace TestProjectApi.Core
{
    public class AllureFixture
    {
        [OneTimeSetUp]
        public void oneTimeSetUp()
        {
            var a = PathBuilder.GetLocalPathToAllureConfig();

            Environment.SetEnvironmentVariable(
                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(a, AllureConstants.CONFIG_FILENAME));

            var config = AllureLifecycle.Instance.JsonConfiguration;
            var cccc = AllureLifecycle.Instance.AllureConfiguration;
            var b = AllureLifecycle.Instance.ResultsDirectory;
        }

        //[TearDown]
        //public void RemoveEnvVariable()
        //{
        //    Environment.SetEnvironmentVariable(
        //        AllureConstants.ALLURE_CONFIG_ENV_VARIABLE, null);
        //}
    }
}
