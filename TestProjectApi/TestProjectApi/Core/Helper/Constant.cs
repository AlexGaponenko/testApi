using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectApi.Core.Helper
{
    public class Constant
    {
        public static string baseUrl => TestDataInitializing.InitializingLoginData().baseUrl;
        public static string housesEndpoint => TestDataInitializing.InitializingLoginData().housesEndpoint;
    }
}
