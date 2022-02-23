namespace OblivionSaveReaderGUI
{
    partial class OblivionSaveUploader
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ShareCodeLabel = new System.Windows.Forms.Label();
            this.shareCodeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.shareKeyLabel = new System.Windows.Forms.Label();
            this.forceRefreshCheckbox = new System.Windows.Forms.CheckBox();
            this.shareCodeTextbox = new System.Windows.Forms.TextBox();
            this.shareKeyTextbox = new System.Windows.Forms.TextBox();
            this.loggingTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.logLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.saveFileDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.saveFilePathLabel = new System.Windows.Forms.Label();
            this.jsonDataUrlLabel = new System.Windows.Forms.Label();
            this.uploadUrlLabel = new System.Windows.Forms.Label();
            this.jsonDataUrlTextbox = new System.Windows.Forms.TextBox();
            this.uploadUrlTextbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oblivion Save Uploader";
            // 
            // ShareCodeLabel
            // 
            this.ShareCodeLabel.AutoSize = true;
            this.ShareCodeLabel.Location = new System.Drawing.Point(5, 10);
            this.ShareCodeLabel.Name = "ShareCodeLabel";
            this.ShareCodeLabel.Size = new System.Drawing.Size(67, 15);
            this.ShareCodeLabel.TabIndex = 1;
            this.ShareCodeLabel.Text = "Share Code";
            this.shareCodeTooltip.SetToolTip(this.ShareCodeLabel, "6-character share code, shown on the website");
            // 
            // shareKeyLabel
            // 
            this.shareKeyLabel.AutoSize = true;
            this.shareKeyLabel.Location = new System.Drawing.Point(5, 46);
            this.shareKeyLabel.Name = "shareKeyLabel";
            this.shareKeyLabel.Size = new System.Drawing.Size(58, 15);
            this.shareKeyLabel.TabIndex = 3;
            this.shareKeyLabel.Text = "Share Key";
            this.shareCodeTooltip.SetToolTip(this.shareKeyLabel, "DO NOT SHARE WITH OTHERS. On website, in console. enter \"settings.shareKey\" and p" +
        "aste the result in this box (minus the start and end quotes).");
            // 
            // forceRefreshCheckbox
            // 
            this.forceRefreshCheckbox.AutoSize = true;
            this.forceRefreshCheckbox.Location = new System.Drawing.Point(11, 142);
            this.forceRefreshCheckbox.Name = "forceRefreshCheckbox";
            this.forceRefreshCheckbox.Size = new System.Drawing.Size(97, 19);
            this.forceRefreshCheckbox.TabIndex = 7;
            this.forceRefreshCheckbox.Text = "Force Refresh";
            this.shareCodeTooltip.SetToolTip(this.forceRefreshCheckbox, "Force redownload of json files instead of using cached ones");
            this.forceRefreshCheckbox.UseVisualStyleBackColor = true;
            // 
            // shareCodeTextbox
            // 
            this.shareCodeTextbox.Location = new System.Drawing.Point(78, 7);
            this.shareCodeTextbox.Name = "shareCodeTextbox";
            this.shareCodeTextbox.Size = new System.Drawing.Size(100, 23);
            this.shareCodeTextbox.TabIndex = 2;
            this.shareCodeTextbox.TextChanged += new System.EventHandler(this.shareCodeTextbox_TextChanged);
            // 
            // shareKeyTextbox
            // 
            this.shareKeyTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shareKeyTextbox.Location = new System.Drawing.Point(78, 43);
            this.shareKeyTextbox.Name = "shareKeyTextbox";
            this.shareKeyTextbox.Size = new System.Drawing.Size(423, 23);
            this.shareKeyTextbox.TabIndex = 4;
            this.shareKeyTextbox.UseSystemPasswordChar = true;
            this.shareKeyTextbox.TextChanged += new System.EventHandler(this.shareKeyTextbox_TextChanged);
            // 
            // loggingTextBox
            // 
            this.loggingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggingTextBox.Location = new System.Drawing.Point(16, 292);
            this.loggingTextBox.Multiline = true;
            this.loggingTextBox.Name = "loggingTextBox";
            this.loggingTextBox.Size = new System.Drawing.Size(515, 103);
            this.loggingTextBox.TabIndex = 5;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 243);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start Monitoring";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logLabel
            // 
            this.logLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(16, 269);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(32, 15);
            this.logLabel.TabIndex = 7;
            this.logLabel.Text = "Logs";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Location = new System.Drawing.Point(12, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 195);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.shareKeyTextbox);
            this.tabPageBasic.Controls.Add(this.ShareCodeLabel);
            this.tabPageBasic.Controls.Add(this.shareKeyLabel);
            this.tabPageBasic.Controls.Add(this.shareCodeTextbox);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 24);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(507, 167);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Options";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.forceRefreshCheckbox);
            this.tabPageAdvanced.Controls.Add(this.saveFileDirectoryTextbox);
            this.tabPageAdvanced.Controls.Add(this.saveFilePathLabel);
            this.tabPageAdvanced.Controls.Add(this.jsonDataUrlLabel);
            this.tabPageAdvanced.Controls.Add(this.uploadUrlLabel);
            this.tabPageAdvanced.Controls.Add(this.jsonDataUrlTextbox);
            this.tabPageAdvanced.Controls.Add(this.uploadUrlTextbox);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(507, 167);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // saveFileDirectoryTextbox
            // 
            this.saveFileDirectoryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileDirectoryTextbox.Location = new System.Drawing.Point(118, 100);
            this.saveFileDirectoryTextbox.Name = "saveFileDirectoryTextbox";
            this.saveFileDirectoryTextbox.PlaceholderText = "Leave blank for auto detect";
            this.saveFileDirectoryTextbox.Size = new System.Drawing.Size(383, 23);
            this.saveFileDirectoryTextbox.TabIndex = 5;
            // 
            // saveFilePathLabel
            // 
            this.saveFilePathLabel.AutoSize = true;
            this.saveFilePathLabel.Location = new System.Drawing.Point(12, 108);
            this.saveFilePathLabel.Name = "saveFilePathLabel";
            this.saveFilePathLabel.Size = new System.Drawing.Size(100, 15);
            this.saveFilePathLabel.TabIndex = 4;
            this.saveFilePathLabel.Text = "Save file directory";
            // 
            // jsonDataUrlLabel
            // 
            this.jsonDataUrlLabel.AutoSize = true;
            this.jsonDataUrlLabel.Location = new System.Drawing.Point(13, 71);
            this.jsonDataUrlLabel.Name = "jsonDataUrlLabel";
            this.jsonDataUrlLabel.Size = new System.Drawing.Size(80, 15);
            this.jsonDataUrlLabel.TabIndex = 3;
            this.jsonDataUrlLabel.Text = "JSON Data Url";
            // 
            // uploadUrlLabel
            // 
            this.uploadUrlLabel.AutoSize = true;
            this.uploadUrlLabel.Location = new System.Drawing.Point(11, 29);
            this.uploadUrlLabel.Name = "uploadUrlLabel";
            this.uploadUrlLabel.Size = new System.Drawing.Size(69, 15);
            this.uploadUrlLabel.TabIndex = 2;
            this.uploadUrlLabel.Text = "Upload URL";
            // 
            // jsonDataUrlTextbox
            // 
            this.jsonDataUrlTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonDataUrlTextbox.Location = new System.Drawing.Point(94, 67);
            this.jsonDataUrlTextbox.Name = "jsonDataUrlTextbox";
            this.jsonDataUrlTextbox.Size = new System.Drawing.Size(407, 23);
            this.jsonDataUrlTextbox.TabIndex = 1;
            // 
            // uploadUrlTextbox
            // 
            this.uploadUrlTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadUrlTextbox.Location = new System.Drawing.Point(94, 25);
            this.uploadUrlTextbox.Name = "uploadUrlTextbox";
            this.uploadUrlTextbox.Size = new System.Drawing.Size(407, 23);
            this.uploadUrlTextbox.TabIndex = 0;
            // 
            // OblivionSaveUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 407);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.loggingTextBox);
            this.Controls.Add(this.label1);
            this.Name = "OblivionSaveUploader";
            this.Text = "Oblivion Save Uploader";
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label ShareCodeLabel;
        private ToolTip shareCodeTooltip;
        private TextBox shareCodeTextbox;
        private Label shareKeyLabel;
        private TextBox shareKeyTextbox;
        private TextBox loggingTextBox;
        private Button startButton;
        private Label logLabel;
        private TabControl tabControl1;
        private TabPage tabPageBasic;
        private TabPage tabPageAdvanced;
        private TextBox jsonDataUrlTextbox;
        private TextBox uploadUrlTextbox;
        private Label uploadUrlLabel;
        private TextBox saveFileDirectoryTextbox;
        private Label saveFilePathLabel;
        private Label jsonDataUrlLabel;
        private CheckBox forceRefreshCheckbox;
    }
}