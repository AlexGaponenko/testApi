using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectApi.Tests
{
    public class TestData
    {
        #region Text
        public readonly Dictionary<string, string> filters = new Dictionary<string, string> 
        { 
            { "region", "Dorne" },
            { "haswords", "true" } 
        };
        public readonly Dictionary<string, int> filtersIncorrect = new Dictionary<string, int>
        {
            { "region", 1 },
        };

        public readonly string filterRegion = "Dorne";
        public readonly string words= "words";

        #endregion

    }
}
