using Newtonsoft.Json;
using System.IO;
using TestProjectApi.Core.Helper.DataObject;
using TestProjectApi.Core.Utilites;

namespace TestProjectApi.Core.Helper
{
    /// <summary>
    /// Initializing data for worcking with API
    /// </summary>
    public class TestDataInitializing
    {
        private static string nameJsonFile = "Settings.json";

        public static AppSettingsObj InitializingData()
        {
            var pathToSettings = PathBuilder.GetExsistingPathToSettings();
            string objectJsonFile = File.ReadAllText(pathToSettings + nameJsonFile);
            var loginData = JsonConvert.DeserializeObject<AppSettingsObj>(objectJsonFile);
            return loginData;
        }
    }
}
