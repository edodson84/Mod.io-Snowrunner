
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace ModioSnowrunner
{
    public partial class ShowModsForm : Form
    {
        public ShowModsForm()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            // Access the array of mods
            JArray modsArray = (JArray)GlobalVariables.Mod["data"];
            JArray modtagArray = (JArray)GlobalVariables.user_profile["modStateList"];
            // Access the array of mods
            for (int i = 0; i < modsArray.Count; i++)
            {

                PictureBox pictureBox1 = new PictureBox();
                Label label1 = new Label();
                Label label2 = new Label();
                Label label3 = new Label();
                Button button1 = new Button();
                Button button2 = new Button();
                ProgressBar progressBar1 = new ProgressBar();

                // pictureBox1
                // 
                pictureBox1.Name = "pictureBox";
                pictureBox1.Size = new Size(100, 50);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.TabIndex = i;
                pictureBox1.TabStop = false;
                pictureBox1.Location = new Point(3, 3 + 90 * i);

                // Access a nested key (for example, "submitted_by" -> "username")
                JToken logo = GlobalVariables.Mod["data"][i]["logo"]["thumb_320x180"];
                pictureBox1.Image = LoadImageFromUrl(logo.Value<string>());


                pictureBox1.Click += (sender, e) =>
                {
                    // Get the PictureBox control that triggered the event
                    PictureBox pictureBox = sender as PictureBox;

                    // Create a new form to display the full image
                    Form imageForm = new Form();
                    imageForm.Text = "Full Image";
                    imageForm.StartPosition = FormStartPosition.CenterScreen;
                    imageForm.Size = new Size(600, 400); // Adjust size as needed

                    // Create a PictureBox to display the full image
                    PictureBox fullPictureBox = new PictureBox();
                    fullPictureBox.Dock = DockStyle.Fill;
                    fullPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    // Assign the same image to the full PictureBox
                    fullPictureBox.Image = pictureBox.Image;

                    // Add the full PictureBox to the new form
                    imageForm.Controls.Add(fullPictureBox);

                    // Show the new form with the full image
                    imageForm.ShowDialog();
                };
                // 
                // label1
                // 
                // Access a nested key (for example, "submitted_by" -> "username")
                JToken name = GlobalVariables.Mod["data"][i]["name"];
                label1.Text = name.Value<string>();
                label1.AutoSize = true;
                label1.Location = new Point(109, 3 + 90 * i);
                label1.Name = "label1";
                label1.Size = new Size(38, 15);
                label1.TabIndex = 1;
                // 
                // label2
                // 
                // Access a nested key (for example, "submitted_by" -> "username")
                JToken filesize = GlobalVariables.Mod["data"][i]["modfile"]["filesize"];
                label2.Text = "Filesize: " + FormatFileSize(filesize.Value<long>());
                label2.AutoSize = true;
                label2.Location = new Point(109, 18 + 90 * i);
                label2.Name = "label2";
                label2.Size = new Size(38, 15);
                label2.TabIndex = 2;
                // 
                // label3
                // 
                // Access a nested key (for example, "submitted_by" -> "username")
                JToken downloads = GlobalVariables.Mod["data"][i]["stats"]["downloads_total"];
                label3.Text = "Downloads: " + FormatDownloads(downloads.Value<long>());
                label3.AutoSize = true;
                label3.Location = new Point(109, 33 + 90 * i);
                label3.Name = "label3";
                label3.Size = new Size(38, 15);
                label3.TabIndex = 3;
                // 
                // button1
                // 
                button1.ForeColor = SystemColors.Info;
                button1.Location = new Point(309, 3 + 90 * i);
                button1.Name = "button1";
                button1.Size = new Size(75, 23);
                button1.TabIndex = 4;
                button1.Text = "Download";
                button1.UseVisualStyleBackColor = true;
                // Get the URL of the file from the JSON data
                string fileUrl = GlobalVariables.Mod["data"][i]["modfile"]["download"]["binary_url"].Value<string>();
                var modidstring = GlobalVariables.Mod["data"][i]["id"].ToString();
                var modidint = GlobalVariables.Mod["data"][i]["id"];
                var modiojson = GlobalVariables.Mod["data"][i].ToString();
                button1.Click += (sender, e) =>
                {

                    string myGamesFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\SnowRunner\base\Mods\.modio\mods\" + modidstring;
                    string authjsonFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\SnowRunner\base\Mods\.modio\";
                    
                    string authFilePath = Path.Combine(authjsonFolderPath, "authentication.json");
                    File.WriteAllText(authFilePath, GlobalVariables.authjson.ToString());

                    if (Directory.Exists(myGamesFolderPath))
                    {
                        Directory.Delete(myGamesFolderPath, true);
                    }
                    // Start downloading the file asynchronously
                    // Specify the file name
                    string downloadfileName = "download.zip";
                    string modiofileName = "modio.json";
                    Directory.CreateDirectory(myGamesFolderPath);
                    // Combine the directory path and file name to get the full file path
                    string filePath = Path.Combine(myGamesFolderPath, downloadfileName);
                    string filePath3 = Path.Combine(myGamesFolderPath, modiofileName);
                    // Create a WebClient to download the file
                    using (WebClient client = new WebClient())
                    {
                        try
                        {



                            // Subscribe to the DownloadProgressChanged event to update the progress bar
                            client.DownloadProgressChanged += (sender, downloadEventArgs) =>
                            {
                                // Update the progress bar value
                                progressBar1.Value = downloadEventArgs.ProgressPercentage;
                            };

                            // Subscribe to the DownloadFileCompleted event to handle completion or errors
                            client.DownloadFileCompleted += (sender, downloadEventArgs) =>
                            {
                                if (downloadEventArgs.Error != null)
                                {
                                    MessageBox.Show("An error occurred while downloading the file: " + downloadEventArgs.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("File downloaded successfully to Desktop.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    JArray modStateList = (JArray)GlobalVariables.user_profile["UserProfile"]["modStateList"];


                                    if ((JObject)GlobalVariables.user_profile["UserProfile"]["modDependencies"]["SslValue"]["dependencies"] != null)
                                    {
                                        // Check if the modidstring key exists in the modDependenciesList
                                        if (!((JObject)GlobalVariables.user_profile["UserProfile"]["modDependencies"]["SslValue"]["dependencies"]).ContainsKey(modidstring))
                                        {
                                            // ModId not found, create a new JArray for dependencies
                                            JArray newDependencyArray = new JArray();

                                            // Add the new modidstring key with the empty dependency array
                                            ((JObject)GlobalVariables.user_profile["UserProfile"]["modDependencies"]["SslValue"]["dependencies"]).Add(new JProperty(modidstring, newDependencyArray));
                                        }
                                        else
                                        {
                                            // ModId already exists, do something
                                        }
                                    }


                                    // Search for user by iterating through the keys
                                    foreach (var user in GlobalVariables.user_profile["UserProfile"]["modFilter"])
                                    {
                                        string userId = ((JProperty)user).Name;
                                        JObject userDetails = (JObject)user.First;

                                        // Check if this is the user you're looking for
                                        if (userId.StartsWith("use"))
                                        {
                                            // Replace the SslValue and SslType for the found user
                                            userDetails["SslType"] = "ModBrowserConfigData";
                                            userDetails["SslValue"] = JObject.FromObject(new
                                            {
                                                tags = new string[] { },
                                                isEnabledMode = false,
                                                isConsoleForbiddenMode = false,
                                                isSubscriptionsMode = false,
                                                isConsoleApprovedMode = false,
                                                sortField = "popular",
                                                sortIsAsc = false
                                            });
                                        }
                                    }
                                    if (modStateList != null)
                                    {
                                        var idx = -1;

                                        foreach (var item in modStateList)
                                        {
                                            if (item["modId"].Value<string>() == modidstring)
                                            {
                                                idx = modStateList.IndexOf(item);
                                                break;
                                            }
                                        }

                                        if (idx >= 0)
                                        {
                                            // If modId exists in modStateList, update modState
                                            modStateList[idx]["modState"] = true;
                                        }
                                        else
                                        {
                                            // If modId does not exist in modStateList, add a new item
                                            var newItem = new JObject();
                                            newItem["modId"] = modidint;
                                            newItem["modState"] = true;
                                            modStateList.Add(newItem);


                                        }
                                    }

                                    // Convert the modified JObject to a JSON string
                                    string jsonString = GlobalVariables.user_profile.ToString();


                                    // Write the JSON string to the file
                                    //File.WriteAllText(filePath, jsonString);
                                    string jsonFilePath = Path.Combine(GlobalVariables.profile_directory, "user_profile.cfg");

                                    // Write the JSON string to the file using FileStream
                                    using (FileStream fs = new FileStream(jsonFilePath, FileMode.Create))
                                    {
                                        // Convert the JSON string to bytes
                                        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

                                        // Write the JSON bytes to the file
                                        fs.Write(jsonBytes, 0, jsonBytes.Length);

                                        // Append the null terminator (0x00)
                                        fs.WriteByte(0x00);
                                    }
                                    // Extract the contents of the ZIP file to the target directory

                                    ZipFile.ExtractToDirectory(filePath, myGamesFolderPath);

                                    // Delete the ZIP file
                                    File.Delete(filePath);

                                    File.WriteAllText(filePath3, modiojson);

                                }
                            };

                            client.DownloadFileAsync(new Uri(fileUrl), filePath);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while starting the download: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                };
                // 
                // button2
                // 
                button2.ForeColor = SystemColors.Info;
                button2.Location = new Point(309, 29 + 90 * i);
                button2.Name = "Enable";
                button2.Size = new Size(75, 23);
                button2.TabIndex = 5;
                button2.Text = "Enable";
                button2.UseVisualStyleBackColor = true;
                // 
                // progressBar1
                // 
                progressBar1.Location = new Point(3, 59 + 90 * i);
                progressBar1.Name = "progressBar1";
                progressBar1.Size = new Size(381, 23);
                progressBar1.TabIndex = 6;
                button2.Click += (sender, e) =>
                {


                };

                panel1.Controls.Add(progressBar1);
                panel1.Controls.Add(button2);
                panel1.Controls.Add(button1);
                panel1.Controls.Add(label3);
                panel1.Controls.Add(label2);
                panel1.Controls.Add(label1);
                panel1.Controls.Add(pictureBox1);

            }
        }



        static void UpdateJson(JObject existingJson, JObject defaultJson)
        {
            // Loop through each property in defaultJson
            foreach (var property in defaultJson.Properties())
            {
                // Check if property exists in existingJson
                if (!existingJson.ContainsKey(property.Name))
                {
                    // If property doesn't exist, add it to existingJson
                    existingJson[property.Name] = property.Value;
                }
                else
                {
                    // If property exists and is an object, recursively update its properties
                    if (property.Value.Type == JTokenType.Object)
                    {
                        UpdateJson((JObject)existingJson[property.Name], (JObject)property.Value);
                    }
                }
            }
        }
        // Method to load image from URL
        static Image LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] data = client.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., URL not found, invalid image format)
                Console.WriteLine("Error loading image: " + ex.Message);
                return null;
            }
        }

        private string FormatFileSize(double fileSize)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            while (fileSize >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                fileSize /= 1024;
                suffixIndex++;
            }
            return $"{fileSize:#,##0.#} {suffixes[suffixIndex]}";
        }

        private string FormatDownloads(double downloads)
        {
            if (downloads >= 1000000)
            {
                return $"{downloads / 1000000:#,##0.#}M";
            }
            else if (downloads >= 1000)
            {
                return $"{downloads / 1000:#,##0.#}K";
            }
            else
            {
                return $"{downloads:#,##0}";
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
