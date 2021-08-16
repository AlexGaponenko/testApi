using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProjectApi.Core.Helper.DataObject;
using TestProjectApi.Core.Utilites;

namespace TestProjectApi.Core.Helper
{
    public class TestDataInitializing
    {
        private static string nameJsonFile = "Settings.json";

        public static AppSettingsObj InitializingLoginData()
        {
            var pathToSettings = PathBuilder.GetExsistingUserPath();
            string objectJsonFile = File.ReadAllText(pathToSettings + nameJsonFile);
            //loginData = System.Text.Json.JsonSerializer.Deserialize<LoginData>(objectJsonFile);
            var loginData = JsonConvert.DeserializeObject<AppSettingsObj>(objectJsonFile);
            return loginData;
        }
    }
}
