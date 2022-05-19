using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Framework.Helpers
{
    public class JsonHelpers
    {
        public static Dictionary<string, string> GetJsonDataEnv(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env == null)
            {
                env = "QA";
            }
            string projectDirectoryEnv = projectDirectory + $"//Data//{env}";
            string path = Path.Combine(projectDirectoryEnv, fileName);
            string jsonString = File.ReadAllText(path);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            return jsonData;
        }
        public static Dictionary<string, string> GetJsonData(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string projectDirectoryEnv = projectDirectory + $"//Data//";
            string path = Path.Combine(projectDirectoryEnv, fileName);
            string jsonString = File.ReadAllText(path);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            return jsonData;
        }

    }
}