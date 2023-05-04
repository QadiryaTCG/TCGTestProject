using System;
using System.Collections;
using System.IO;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;

namespace Framework.Config
{
    public class ConfigReaders
    {

        public static string LoadConfig()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Console.WriteLine("Environment variable: ASPNETCORE_ENVIRONMENT={0}", env);

            string value = Environment.GetEnvironmentVariable("runningAs");

            Console.WriteLine("Environment variable: runningAs ={0}", value);

            if (env == null)
            {
                Console.WriteLine("ASPNETCORE_ENVIRONMENT='', setting to {0} by default", "Prod");
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Prod");
                env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            }

            if (value == null)
            {
                Console.WriteLine("runningAs='', setting to {0} by default", "user");
                Environment.SetEnvironmentVariable("runningAs", "user");
                value = Environment.GetEnvironmentVariable("runningAs");

            }

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile($"appsettings.{env}.json");

            IConfigurationRoot configurationRoot = builder.Build();
           
         //   ConfigProperties.Browser = configurationRoot.GetSection("testSettings").Get<ConfigModel>().Browser;
            ConfigProperties.Environment = configurationRoot.GetSection("testSettings").Get<ConfigModel>().Environment;
            ConfigProperties.RunningAs = configurationRoot.GetSection("testSettings").Get<ConfigModel>().RunningAs;
            return env;
        }
    }
}
