using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectApi.Core.Helper
{
    /// <summary>
    /// The class contains static API control fields   
    /// </summary>
    public class Constant
    {
        public static string baseUrl => TestDataInitializing.InitializingData().baseUrl;
        public static string housesEndpoint => TestDataInitializing.InitializingData().housesEndpoint;
    }
}
