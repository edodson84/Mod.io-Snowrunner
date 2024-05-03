using ModioSnowrunner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.io_Snowrunner
{
    public static class Settings
    {
        public static void readsettings()
        {
            // Read the JSON content from the file
            string filePath = "Settings.json";
            string jsonContent = File.ReadAllText(filePath);

            // Parse the JSON response to extract the settings
            dynamic settings = JsonConvert.DeserializeObject(jsonContent);
            // Extract settings values
            GlobalVariables.AuthToken = settings.access_token;
            GlobalVariables.tokenexpires = settings.date_expires;
            GlobalVariables.apikey = settings.api_key;
            GlobalVariables.Email = settings.email;
            GlobalVariables.profile_directory = settings.profile_directory;
        }

        public static void writesettings()
        {
            // Create a dictionary to hold the settings dynamically
            Dictionary<string, string> dynamicSettings = new Dictionary<string, string>
                {
                { "profile_directory", GlobalVariables.profile_directory },
                { "api_key", GlobalVariables.apikey },
                { "date_expires", GlobalVariables.tokenexpires.ToString() },
                { "access_token", GlobalVariables.AuthToken },
                { "email", GlobalVariables.Email }
                };
            // Serialize the settings dictionary to JSON format
            string jsonContent = JsonConvert.SerializeObject(dynamicSettings);
            // Specify the file path where you want to write the settings
            string filePath = "Settings.json";

            // Write the JSON content to the file
            File.WriteAllText(filePath, jsonContent);

            Console.WriteLine("Settings successfully written to file.");

        }

    }
}
