using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestProjectApi.Core.Utilites
{
    public class PathBuilder
    {
        private static string _exsistSetingsPath = @"..\..\..\Core\";

        /// <summary>
        /// Get local path
        /// </summary>
        /// <returns>Return the local path to the working directory</returns>
        internal static string GetLocalPath()
        {
            string path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            string fullPath = Path.GetDirectoryName(path) + @"\";
            return fullPath;
        }

        /// <summary>
        /// Get exsisting path to settings
        /// </summary>
        /// <returns>Return the local path to the settings directory</returns>
        public static string GetExsistingPathToSettings()
        {
            string fullPath = GetLocalPath() + _exsistSetingsPath;
            if (!Directory.Exists(fullPath))
            {
                throw new Exception("No settings folder '" + fullPath + "' was found.");
            }
            return fullPath;
        }
    }
}
