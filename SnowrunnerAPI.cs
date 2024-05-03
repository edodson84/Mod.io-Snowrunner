using ModioSnowrunner;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Mod.io_Snowrunner
{
    public static class SnowrunnerAPI
    {
        public static void terms(string api, string email)
        {
            // Create RestClient and RestRequest
            RestClient client = new RestClient(GlobalVariables.ModioApi);
            RestRequest req = new RestRequest("authenticate/terms", Method.Get);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("api_key", api);

            // Execute the request
            RestResponse resp = client.Execute(req);
            dynamic respcon = JsonConvert.DeserializeObject(resp.Content);
            DialogResult result = MessageBox.Show((string)respcon.plaintext, "Terms", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

            // Check which button was clicked
            if (result == DialogResult.OK)
            {
                SnowrunnerAPI.getauthcode(api, email);
            }

        }
        public static void getauthcode(string api, string email)
        {
            // Create RestClient and RestRequest
            RestClient client = new RestClient(GlobalVariables.ModioApi);
            RestRequest req = new RestRequest("oauth/emailrequest", Method.Post);
            req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            req.AddParameter("api_key", api);
            req.AddParameter("email", email);

            // Execute the request
            RestResponse resp = client.Execute(req);

            // Check if the request was successful
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {

                // After receiving the response
                string responseContent = resp.Content;

                // Parse the JSON response to extract the title and message
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                string title = jsonResponse.code;
                string message = jsonResponse.message;
                GlobalVariables.apikey = api;
                GlobalVariables.Email = email;

                // Display the message in a MessageBox
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Handle the case where the request was not successful
                MessageBox.Show($"Error: {resp.StatusCode}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void getauthToken(string authcode)
        {
            try
            {
                // Create RestClient and RestRequest
                RestClient client = new RestClient(GlobalVariables.ModioApi);
                RestRequest req = new RestRequest("oauth/emailexchange", Method.Post);
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddParameter("api_key", GlobalVariables.apikey);
                req.AddParameter("security_code", authcode);

                // Execute the request
                RestResponse resp = client.Execute(req);

                // Check if the request was successful
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // After receiving the response
                    string responseContent = resp.Content;

                    // Parse the JSON response to extract the title and message
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    GlobalVariables.tokenexpires = jsonResponse.date_expires;
                    GlobalVariables.AuthToken = jsonResponse.access_token;
                    // Convert Unix timestamp to DateTime
                    DateTime dateTimeExpires = DateTimeOffset.FromUnixTimeSeconds(GlobalVariables.tokenexpires).DateTime;
                    // Display the message in a MessageBox
                    MessageBox.Show(dateTimeExpires.ToString(), "Token Expiration", MessageBoxButtons.OK);

                }
                else
                {
                    // Handle the case where the request was not successful
                    MessageBox.Show($"Error: {resp.StatusCode}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the execution of the request
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GetMods()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Please select game save folder";
                dialog.UseDescriptionForTitle = true;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    GlobalVariables.profile_directory = dialog.SelectedPath;
                    string jsonFilePath = Path.Combine(GlobalVariables.profile_directory, "user_profile.cfg");

                    if (File.Exists(jsonFilePath))
                    {
                        string jsonContent = File.ReadAllText(jsonFilePath);
                        // Parse the JSON data
                        JObject contentObject = JObject.Parse(jsonContent);
                        contentObject.Merge(GlobalVariables.user_profile);
                        jsonContent = contentObject.ToString();
                        GlobalVariables.authjson["access_token"] = GlobalVariables.AuthToken;
                        GlobalVariables.authjson["expiration_date"] = GlobalVariables.tokenexpires;
                    }
                    else
                    {
                        Console.WriteLine("The JSON file does not exist in the selected folder.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("You didn't select any folder.");
                    return;
                }
            }
            RestClientOptions options = new RestClientOptions(GlobalVariables.ModioApi)
            {
                Authenticator = new RestSharp.Authenticators.JwtAuthenticator(GlobalVariables.AuthToken)
            };
            RestClient client = new RestClient(options);
            RestRequest req = new RestRequest("/me/subscribed", Method.Get);
            req.AddHeader("Accept", "application/json");
            req.AddHeader("X-Modio-Platform", "windows");
            req.AddParameter("game_id", 306);
            RestResponse resp = client.Execute(req);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                GlobalVariables.Mod = JsonConvert.DeserializeObject(resp.Content);
            }
        }
    }
}
