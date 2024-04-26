using System.Windows.Forms;

namespace ModioSnowrunner
{
    partial class ShowModsForm
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
            components = new System.ComponentModel.Container();
            datumBindingSource = new BindingSource(components);
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)datumBindingSource).BeginInit();
            SuspendLayout();
            // 
            // datumBindingSource
            // 
            datumBindingSource.DataSource = typeof(Datum);
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(439, 552);
            panel1.TabIndex = 0;
            // 
            // ShowModsForm
            // 
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(463, 576);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.InfoText;
            MaximizeBox = false;
            Name = "ShowModsForm";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)datumBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource datumBindingSource;
        private Panel panel1;
    }
}