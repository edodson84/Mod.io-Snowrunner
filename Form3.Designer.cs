namespace Mod.io_Snowrunner
{
    partial class saveeditform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxmoney = new TextBox();
            buttonsave = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxrank = new TextBox();
            labelmoney = new Label();
            labelrank = new Label();
            buttonopen = new Button();
            SuspendLayout();
            // 
            // textBoxmoney
            // 
            textBoxmoney.Location = new Point(76, 41);
            textBoxmoney.Name = "textBoxmoney";
            textBoxmoney.Size = new Size(215, 23);
            textBoxmoney.TabIndex = 0;
            // 
            // buttonsave
            // 
            buttonsave.ForeColor = SystemColors.ControlText;
            buttonsave.Location = new Point(118, 250);
            buttonsave.Name = "buttonsave";
            buttonsave.Size = new Size(120, 56);
            buttonsave.TabIndex = 1;
            buttonsave.Text = "Save";
            buttonsave.UseVisualStyleBackColor = true;
            buttonsave.Click += buttonsave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Money";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 93);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "Rank";
            // 
            // textBoxrank
            // 
            textBoxrank.Location = new Point(76, 93);
            textBoxrank.Name = "textBoxrank";
            textBoxrank.Size = new Size(215, 23);
            textBoxrank.TabIndex = 4;
            // 
            // labelmoney
            // 
            labelmoney.AutoSize = true;
            labelmoney.Location = new Point(118, 23);
            labelmoney.Name = "labelmoney";
            labelmoney.Size = new Size(0, 15);
            labelmoney.TabIndex = 5;
            labelmoney.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelrank
            // 
            labelrank.AutoSize = true;
            labelrank.Location = new Point(118, 75);
            labelrank.Name = "labelrank";
            labelrank.Size = new Size(0, 15);
            labelrank.TabIndex = 6;
            // 
            // buttonopen
            // 
            buttonopen.ForeColor = SystemColors.Info;
            buttonopen.Location = new Point(118, 162);
            buttonopen.Name = "buttonopen";
            buttonopen.Size = new Size(120, 56);
            buttonopen.TabIndex = 7;
            buttonopen.Text = "Open Save File";
            buttonopen.UseVisualStyleBackColor = true;
            buttonopen.Click += buttonopen_Click;
            // 
            // saveeditform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(349, 366);
            Controls.Add(buttonopen);
            Controls.Add(labelrank);
            Controls.Add(labelmoney);
            Controls.Add(textBoxrank);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonsave);
            Controls.Add(textBoxmoney);
            ForeColor = SystemColors.InfoText;
            Name = "saveeditform";
            Text = "saveeditform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxmoney;
        private Button buttonsave;
        private Label label1;
        private Label label2;
        private TextBox textBoxrank;
        private Label labelmoney;
        private Label labelrank;
        private Button buttonopen;
    }
}