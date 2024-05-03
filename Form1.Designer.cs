
using System.Net;

namespace ModioSnowrunner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxEmail = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxApi = new TextBox();
            label4 = new Label();
            textBoxAuthCode = new TextBox();
            buttonGetAuthCode = new Button();
            buttonAuthToken = new Button();
            buttonShowMods = new Button();
            label5 = new Label();
            label6 = new Label();
            buttonGetMods = new Button();
            pictureBox1 = new PictureBox();
            buttonsaveedit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(193, 170);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(391, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 177);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 205);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 3;
            label3.Text = "Api Key";
            // 
            // textBoxApi
            // 
            textBoxApi.Location = new Point(193, 198);
            textBoxApi.Name = "textBoxApi";
            textBoxApi.Size = new Size(391, 23);
            textBoxApi.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 289);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 5;
            label4.Text = "Auth Code";
            // 
            // textBoxAuthCode
            // 
            textBoxAuthCode.Location = new Point(193, 281);
            textBoxAuthCode.Name = "textBoxAuthCode";
            textBoxAuthCode.Size = new Size(391, 23);
            textBoxAuthCode.TabIndex = 6;
            // 
            // buttonGetAuthCode
            // 
            buttonGetAuthCode.ForeColor = SystemColors.Info;
            buttonGetAuthCode.Location = new Point(325, 226);
            buttonGetAuthCode.Name = "buttonGetAuthCode";
            buttonGetAuthCode.Size = new Size(110, 35);
            buttonGetAuthCode.TabIndex = 7;
            buttonGetAuthCode.Text = "Get Auth Code";
            buttonGetAuthCode.UseVisualStyleBackColor = true;
            buttonGetAuthCode.Click += ButtonGetAuthCode_Click;
            // 
            // buttonAuthToken
            // 
            buttonAuthToken.ForeColor = SystemColors.Info;
            buttonAuthToken.Location = new Point(590, 281);
            buttonAuthToken.Name = "buttonAuthToken";
            buttonAuthToken.Size = new Size(119, 22);
            buttonAuthToken.TabIndex = 8;
            buttonAuthToken.Text = "Get Auth Token";
            buttonAuthToken.UseVisualStyleBackColor = true;
            buttonAuthToken.Click += buttonAuthToken_Click;
            // 
            // buttonShowMods
            // 
            buttonShowMods.ForeColor = SystemColors.Info;
            buttonShowMods.Location = new Point(163, 342);
            buttonShowMods.Name = "buttonShowMods";
            buttonShowMods.Size = new Size(119, 51);
            buttonShowMods.TabIndex = 9;
            buttonShowMods.Text = "Show Subscribed Mods";
            buttonShowMods.UseVisualStyleBackColor = true;
            buttonShowMods.Click += buttonShowMods_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(262, 152);
            label5.Name = "label5";
            label5.Size = new Size(238, 15);
            label5.TabIndex = 10;
            label5.Text = "Please Enter Your Mod.io Email And Api Key";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(258, 263);
            label6.Name = "label6";
            label6.Size = new Size(242, 15);
            label6.TabIndex = 11;
            label6.Text = "Check Your Email And Enter The Code Below";
            // 
            // buttonGetMods
            // 
            buttonGetMods.ForeColor = SystemColors.Info;
            buttonGetMods.Location = new Point(325, 342);
            buttonGetMods.Name = "buttonGetMods";
            buttonGetMods.Size = new Size(119, 51);
            buttonGetMods.TabIndex = 12;
            buttonGetMods.Text = "Get Subscribed Mods";
            buttonGetMods.UseVisualStyleBackColor = true;
            buttonGetMods.Click += buttonGetMods_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(193, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(391, 109);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // buttonsaveedit
            // 
            buttonsaveedit.ForeColor = SystemColors.ControlText;
            buttonsaveedit.Location = new Point(490, 342);
            buttonsaveedit.Name = "buttonsaveedit";
            buttonsaveedit.Size = new Size(119, 51);
            buttonsaveedit.TabIndex = 14;
            buttonsaveedit.Text = "Edit Gamesave";
            buttonsaveedit.UseVisualStyleBackColor = true;
            buttonsaveedit.Click += buttonsaveedit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(784, 432);
            Controls.Add(buttonsaveedit);
            Controls.Add(pictureBox1);
            Controls.Add(buttonGetMods);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(buttonShowMods);
            Controls.Add(buttonAuthToken);
            Controls.Add(buttonGetAuthCode);
            Controls.Add(textBoxAuthCode);
            Controls.Add(label4);
            Controls.Add(textBoxApi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxEmail);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.InfoText;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxEmail;
        private Label label2;
        private Label label3;
        private TextBox textBoxApi;
        private Label label4;
        private TextBox textBoxAuthCode;
        private Button buttonGetAuthCode;
        private Button buttonAuthToken;
        private Button buttonShowMods;
        private Label label5;
        private Label label6;
        private Button buttonGetMods;
        private PictureBox pictureBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonsaveedit;
    }
}
