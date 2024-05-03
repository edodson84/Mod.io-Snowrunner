using ModioSnowrunner;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod.io_Snowrunner
{
    public partial class saveeditform : Form
    {
        public saveeditform()
        {
            InitializeComponent();
        }
        string selectedFile;
        dynamic gamesave;
        private void buttonopen_Click(object sender, EventArgs e)
        {
            // Display a folder browser dialog to select the directory
            string directoryPath = SelectDirectory();
            if (directoryPath == null)
            {
                Console.WriteLine("No directory selected.");
                return;
            }

            string searchKey = "CompleteSave";

            // Get all files in the directory
            string[] allFiles = Directory.GetFiles(directoryPath);

            foreach (string file in allFiles)
            {
                try
                {
                    // Check if the file is a JSON file
                    if (IsJsonFile(file))
                    {
                        textBoxmoney.Text = "99999999";
                        textBoxrank.Text = "30";
                        // Read the JSON file
                        string jsonText = File.ReadAllText(file);

                        // Parse JSON text into a JObject
                        JObject jsonData = JObject.Parse(jsonText);

                        // Check if the key exists in the JSON object
                        if (jsonData.ContainsKey(searchKey))
                        {
                            selectedFile = file;
                            // Parse JSON string into a dynamic object
                            gamesave = JsonConvert.DeserializeObject(jsonText);
                            labelmoney.Text = "Money: " + gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["money"];
                            labelrank.Text = "Rank: " + gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["rank"];
                        }
                        else
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["money"] = int.Parse(textBoxmoney.Text);
            gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["rank"] = int.Parse(textBoxrank.Text);
            labelmoney.Text = "Current Money: " + gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["money"];
            labelrank.Text = "Current Rank: " + gamesave["CompleteSave"]["SslValue"]["persistentProfileData"]["rank"];
            string newsave = JsonConvert.SerializeObject(gamesave);
            using (FileStream fs = new FileStream(selectedFile, FileMode.Create))
            {
                // Convert the JSON string to bytes
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(newsave);

                // Write the JSON bytes to the file
                fs.Write(jsonBytes, 0, jsonBytes.Length);

                // Append the null terminator (0x00)
                fs.WriteByte(0x00);
            }
        }
        static string SelectDirectory()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select Gamesave Directory";
                folderBrowserDialog.UseDescriptionForTitle = true;
                folderBrowserDialog.AddToRecent = true;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    return folderBrowserDialog.SelectedPath;
                }
                else
                {
                    return null;
                }
            }
        }

        static bool IsJsonFile(string filePath)
        {
            try
            {
                // Read a portion of the file to check if it starts with a JSON object or array
                string firstCharacters = File.ReadAllText(filePath).TrimStart();
                return firstCharacters.StartsWith("{") || firstCharacters.StartsWith("[");
            }
            catch
            {
                // If there is any error reading the file, assume it's not a JSON file
                return false;
            }
        }
    }
}
