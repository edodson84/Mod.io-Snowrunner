using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Svg;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using ModioSnowrunner;




namespace ModioSnowrunner
{

    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
            // URL of the SVG image
            string svgUrl = "https://docs.mod.io/images/logo.svg";

            // Download the SVG file
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(svgUrl);

                // Load the SVG data
                using (MemoryStream stream = new MemoryStream(data))
                {
                    SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(stream);

                    // Convert the SVG document to a bitmap
                    Bitmap bitmap = svgDocument.Draw();

                    // Display the bitmap in the PictureBox
                    pictureBox1.Image = bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            readsettings();
        }

        private void ButtonGetAuthCode_Click(object sender, EventArgs e)
        {
            getauthcode();
        }

        private void buttonAuthToken_Click(object sender, EventArgs e)
        {
            getauthToken();
        }

        private void buttonShowMods_Click(object sender, EventArgs e)
        {
            ShowModsForm form2 = new ShowModsForm();
            // Set the start position of Form2 to manual
            form2.StartPosition = FormStartPosition.Manual;

            // Calculate the location to position Form2
            int form2X = this.Location.X + this.Width; // Position to the right of Form1
            int form2Y = this.Location.Y; // Align with the top of Form1

            // Set the location of Form2
            form2.Location = new Point(form2X, form2Y);
            form2.Show();
        }

        private void buttonGetMods_Click(object sender, EventArgs e)
        {
            GetMods();
        }

        void readsettings()
        {
            try
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


                textBoxApi.Text = GlobalVariables.apikey;
                textBoxEmail.Text = GlobalVariables.Email;

                // Log success message
                Debug.WriteLine("Settings loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                // Handle file not found exception
                Debug.WriteLine("Settings file not found. Please make sure the file exists.");
            }
            catch (JsonException)
            {
                // Handle JSON parsing exception
                Debug.WriteLine("Error parsing JSON. Please check the format of the settings file.");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                Debug.WriteLine("An error occurred while loading settings: " + ex.Message);
            }


        }

        void writesettings()
        {
            try
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
            catch (Exception ex)
            {
                // Handle any errors that might occur during file writing or JSON serialization
                Console.WriteLine("Error writing settings: " + ex.Message);
            }
        }

        void getauthcode()
        {
            try
            {
                // Create RestClient and RestRequest
                RestClient client = new RestClient(GlobalVariables.ModioApi);
                RestRequest req = new RestRequest("oauth/emailrequest", Method.Post);
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddParameter("api_key", textBoxApi.Text);
                req.AddParameter("email", textBoxEmail.Text);

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
                    GlobalVariables.apikey = textBoxApi.Text;
                    GlobalVariables.Email = textBoxEmail.Text;
                    writesettings();

                    // Display the message in a MessageBox
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void getauthToken()
        {
            try
            {
                // Create RestClient and RestRequest
                RestClient client = new RestClient(GlobalVariables.ModioApi);
                RestRequest req = new RestRequest("oauth/emailexchange", Method.Post);
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddParameter("api_key", GlobalVariables.apikey);
                req.AddParameter("security_code", textBoxAuthCode.Text);

                // Execute the request
                RestResponse resp = client.Execute(req);
                // Specify the file path where you want to save the response
                string filePath = "TokenRes.json";

                // Write the response content to the file
                // using (StreamWriter writer = new StreamWriter(filePath))
                // {
                //     writer.Write(resp.Content);
                // }

                // Check if the request was successful
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // After receiving the response
                    string responseContent = resp.Content;

                    // Parse the JSON response to extract the title and message
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string title = jsonResponse.code;
                    GlobalVariables.tokenexpires = jsonResponse.date_expires;
                    GlobalVariables.AuthToken = jsonResponse.access_token;
                    // Convert Unix timestamp to DateTime
                    DateTime dateTimeExpires = DateTimeOffset.FromUnixTimeSeconds(GlobalVariables.tokenexpires).DateTime;
                    writesettings();
                    // Display the message in a MessageBox
                    MessageBox.Show(dateTimeExpires.ToString(), title, MessageBoxButtons.OK);

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



        void GetMods()
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
                        writesettings();
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

            // Configure RestClientOptions with the API base URL and JWT authentication
            RestClientOptions options = new RestClientOptions(GlobalVariables.ModioApi)
            {
                Authenticator = new RestSharp.Authenticators.JwtAuthenticator(GlobalVariables.AuthToken)
            };

            // Create RestClient with configured options
            RestClient client = new RestClient(options);

            // Create RestRequest for the GET endpoint "/me/subscribed"
            RestRequest req = new RestRequest("/me/subscribed", Method.Get);

            // Add header to specify the desired response format
            req.AddHeader("Accept", "application/json");
            //X-Modio-Platform: xboxseriesx
            req.AddHeader("X-Modio-Platform", "windows");

            // Add query parameter for the game ID
            req.AddParameter("game_id", 306);

            // Execute the request
            RestResponse resp = client.Execute(req);



            // If the response status code is OK, proceed to handle the response content
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                // Get the response content
                string responseContent = resp.Content;

                // Specify the file path where you want to save the response
                string filePath = "mods.json";


                GlobalVariables.Mod = JObject.Parse(responseContent);


                writesettings();

            }
        }

    }
}
