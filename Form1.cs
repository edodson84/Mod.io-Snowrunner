using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using ModioSnowrunner;
using Mod.io_Snowrunner;
using System.Drawing;
using SkiaSharp;




namespace ModioSnowrunner
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Get the directory where the executable is located
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the directory and file name to get the full path
            string filePath = Path.Combine(executableDirectory, "logo.svg");
            // Load the SVG file
            using (var stream = File.OpenRead(filePath))
            {
                var svg = new SKSvg();
                svg.Load(stream);

                // Render SVG to a bitmap
                var bitmap = new SKBitmap((int)svg.Picture.CullRect.Width,
                                          (int)svg.Picture.CullRect.Height);
                var canvas = new SKCanvas(bitmap);
                canvas.Clear(SKColors.Transparent);
                canvas.DrawPicture(svg.Picture);

                // Convert bitmap to MemoryStream
                using (MemoryStream memStream = new MemoryStream())
                {
                    bitmap.Encode(SKEncodedImageFormat.Png, 100).SaveTo(memStream);
                    pictureBox1.Image = Image.FromStream(memStream);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            Mod.io_Snowrunner.Settings.readsettings();
            textBoxApi.Text = GlobalVariables.apikey;
            textBoxEmail.Text = GlobalVariables.Email;
        }

        private void ButtonGetAuthCode_Click(object sender, EventArgs e)
        {
            Mod.io_Snowrunner.SnowrunnerAPI.terms(textBoxApi.Text, textBoxEmail.Text);
            Mod.io_Snowrunner.Settings.writesettings();
        }

        private void buttonAuthToken_Click(object sender, EventArgs e)
        {
            Mod.io_Snowrunner.SnowrunnerAPI.getauthToken(textBoxAuthCode.Text);
            Mod.io_Snowrunner.Settings.writesettings();
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
            Mod.io_Snowrunner.SnowrunnerAPI.GetMods();
            Mod.io_Snowrunner.Settings.writesettings();
        }

        private void buttonsaveedit_Click(object sender, EventArgs e)
        {
            saveeditform form3 = new saveeditform();
            // Set the start position of Form2 to manual
            form3.StartPosition = FormStartPosition.Manual;

            // Calculate the location to position Form2
            int form3X = this.Location.X + this.Width; // Position to the right of Form1
            int form3Y = this.Location.Y; // Align with the top of Form1

            // Set the location of Form2
            form3.Location = new Point(form3X, form3Y);
            form3.Show();
        }
    }
}
