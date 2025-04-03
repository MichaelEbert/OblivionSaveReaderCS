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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OblivionSaveUploader));
            label1 = new Label();
            ShareCodeLabel = new Label();
            shareCodeTooltip = new ToolTip(components);
            shareKeyLabel = new Label();
            forceRefreshCheckbox = new CheckBox();
            shareCodeTextbox = new TextBox();
            syncButton = new Button();
            shareKeyTextbox = new TextBox();
            loggingTextBox = new TextBox();
            startButton = new Button();
            logLabel = new Label();
            tabControl1 = new TabControl();
            tabPageBasic = new TabPage();
            tabPageAdvanced = new TabPage();
            importSettingsButton = new Button();
            saveFileDirectoryTextbox = new TextBox();
            saveFilePathLabel = new Label();
            jsonDataUrlLabel = new Label();
            uploadUrlLabel = new Label();
            jsonDataUrlTextbox = new TextBox();
            uploadUrlTextbox = new TextBox();
            tabControl1.SuspendLayout();
            tabPageBasic.SuspendLayout();
            tabPageAdvanced.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.Location = new Point(22, 19);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(493, 57);
            label1.TabIndex = 0;
            label1.Text = "Oblivion Save Uploader";
            // 
            // ShareCodeLabel
            // 
            ShareCodeLabel.AutoSize = true;
            ShareCodeLabel.Location = new Point(9, 21);
            ShareCodeLabel.Margin = new Padding(6, 0, 6, 0);
            ShareCodeLabel.Name = "ShareCodeLabel";
            ShareCodeLabel.Size = new Size(137, 32);
            ShareCodeLabel.TabIndex = 1;
            ShareCodeLabel.Text = "Share Code";
            shareCodeTooltip.SetToolTip(ShareCodeLabel, Properties.Resources.ShareCodeTooltip);
            // 
            // shareKeyLabel
            // 
            shareKeyLabel.AutoSize = true;
            shareKeyLabel.Location = new Point(9, 98);
            shareKeyLabel.Margin = new Padding(6, 0, 6, 0);
            shareKeyLabel.Name = "shareKeyLabel";
            shareKeyLabel.Size = new Size(120, 32);
            shareKeyLabel.TabIndex = 3;
            shareKeyLabel.Text = "Share Key";
            shareCodeTooltip.SetToolTip(shareKeyLabel, Properties.Resources.ShareKeyTooltip);
            // 
            // forceRefreshCheckbox
            // 
            forceRefreshCheckbox.AutoSize = true;
            forceRefreshCheckbox.Location = new Point(17, 220);
            forceRefreshCheckbox.Margin = new Padding(6);
            forceRefreshCheckbox.Name = "forceRefreshCheckbox";
            forceRefreshCheckbox.Size = new Size(190, 36);
            forceRefreshCheckbox.TabIndex = 7;
            forceRefreshCheckbox.Text = "Force Refresh";
            shareCodeTooltip.SetToolTip(forceRefreshCheckbox, "Force redownload of json files instead of using cached ones");
            forceRefreshCheckbox.UseVisualStyleBackColor = true;
            // 
            // shareCodeTextbox
            // 
            shareCodeTextbox.Location = new Point(145, 15);
            shareCodeTextbox.Margin = new Padding(6);
            shareCodeTextbox.Name = "shareCodeTextbox";
            shareCodeTextbox.PlaceholderText = "Auto generate";
            shareCodeTextbox.Size = new Size(182, 39);
            shareCodeTextbox.TabIndex = 2;
            shareCodeTooltip.SetToolTip(shareCodeTextbox, Properties.Resources.ShareCodeTooltip);
            shareCodeTextbox.TextChanged += shareCodeTextbox_TextChanged;
            // 
            // syncButton
            // 
            syncButton.Location = new Point(267, 205);
            syncButton.Margin = new Padding(6);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(258, 53);
            syncButton.TabIndex = 10;
            syncButton.Text = "Allow Edit On Website";
            shareCodeTooltip.SetToolTip(syncButton, "Allow website to edit the same progress info");
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // shareKeyTextbox
            // 
            shareKeyTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            shareKeyTextbox.Location = new Point(145, 92);
            shareKeyTextbox.Margin = new Padding(6);
            shareKeyTextbox.Name = "shareKeyTextbox";
            shareKeyTextbox.PlaceholderText = "Leave blank to auto generate";
            shareKeyTextbox.Size = new Size(615, 39);
            shareKeyTextbox.TabIndex = 4;
            shareKeyTextbox.UseSystemPasswordChar = true;
            shareKeyTextbox.TextChanged += shareKeyTextbox_TextChanged;
            // 
            // loggingTextBox
            // 
            loggingTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggingTextBox.Location = new Point(22, 531);
            loggingTextBox.Margin = new Padding(6);
            loggingTextBox.Multiline = true;
            loggingTextBox.Name = "loggingTextBox";
            loggingTextBox.ScrollBars = ScrollBars.Vertical;
            loggingTextBox.Size = new Size(786, 224);
            loggingTextBox.TabIndex = 5;
            // 
            // startButton
            // 
            startButton.Location = new Point(22, 437);
            startButton.Margin = new Padding(6);
            startButton.Name = "startButton";
            startButton.Size = new Size(222, 49);
            startButton.TabIndex = 6;
            startButton.Text = "Start Monitoring";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // logLabel
            // 
            logLabel.AutoSize = true;
            logLabel.Location = new Point(22, 493);
            logLabel.Margin = new Padding(6, 0, 6, 0);
            logLabel.Name = "logLabel";
            logLabel.Size = new Size(63, 32);
            logLabel.TabIndex = 7;
            logLabel.Text = "Logs";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageBasic);
            tabControl1.Controls.Add(tabPageAdvanced);
            tabControl1.Location = new Point(22, 90);
            tabControl1.Margin = new Padding(6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(789, 335);
            tabControl1.TabIndex = 9;
            // 
            // tabPageBasic
            // 
            tabPageBasic.Controls.Add(shareKeyTextbox);
            tabPageBasic.Controls.Add(ShareCodeLabel);
            tabPageBasic.Controls.Add(shareKeyLabel);
            tabPageBasic.Controls.Add(shareCodeTextbox);
            tabPageBasic.Location = new Point(8, 46);
            tabPageBasic.Margin = new Padding(6);
            tabPageBasic.Name = "tabPageBasic";
            tabPageBasic.Padding = new Padding(6);
            tabPageBasic.Size = new Size(773, 281);
            tabPageBasic.TabIndex = 0;
            tabPageBasic.Text = "Options";
            tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // tabPageAdvanced
            // 
            tabPageAdvanced.Controls.Add(syncButton);
            tabPageAdvanced.Controls.Add(importSettingsButton);
            tabPageAdvanced.Controls.Add(forceRefreshCheckbox);
            tabPageAdvanced.Controls.Add(saveFileDirectoryTextbox);
            tabPageAdvanced.Controls.Add(saveFilePathLabel);
            tabPageAdvanced.Controls.Add(jsonDataUrlLabel);
            tabPageAdvanced.Controls.Add(uploadUrlLabel);
            tabPageAdvanced.Controls.Add(jsonDataUrlTextbox);
            tabPageAdvanced.Controls.Add(uploadUrlTextbox);
            tabPageAdvanced.Location = new Point(8, 46);
            tabPageAdvanced.Margin = new Padding(6);
            tabPageAdvanced.Name = "tabPageAdvanced";
            tabPageAdvanced.Padding = new Padding(6);
            tabPageAdvanced.Size = new Size(773, 281);
            tabPageAdvanced.TabIndex = 1;
            tabPageAdvanced.Text = "Advanced";
            tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // importSettingsButton
            // 
            importSettingsButton.Location = new Point(537, 205);
            importSettingsButton.Margin = new Padding(6);
            importSettingsButton.Name = "importSettingsButton";
            importSettingsButton.Size = new Size(223, 53);
            importSettingsButton.TabIndex = 8;
            importSettingsButton.Text = "Import Settings";
            shareCodeTooltip.SetToolTip(importSettingsButton, "Import settings from previous version of oblivion save uploader");
            importSettingsButton.UseVisualStyleBackColor = true;
            importSettingsButton.Click += importSettingsButton_Click;
            // 
            // saveFileDirectoryTextbox
            // 
            saveFileDirectoryTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            saveFileDirectoryTextbox.Location = new Point(208, 137);
            saveFileDirectoryTextbox.Margin = new Padding(6);
            saveFileDirectoryTextbox.Name = "saveFileDirectoryTextbox";
            saveFileDirectoryTextbox.PlaceholderText = "Leave blank for auto detect";
            saveFileDirectoryTextbox.Size = new Size(552, 39);
            saveFileDirectoryTextbox.TabIndex = 5;
            saveFileDirectoryTextbox.TextChanged += saveFileDirectoryTextbox_TextChanged;
            // 
            // saveFilePathLabel
            // 
            saveFilePathLabel.AutoSize = true;
            saveFilePathLabel.Location = new Point(6, 143);
            saveFilePathLabel.Margin = new Padding(6, 0, 6, 0);
            saveFilePathLabel.Name = "saveFilePathLabel";
            saveFilePathLabel.Size = new Size(205, 32);
            saveFilePathLabel.TabIndex = 4;
            saveFilePathLabel.Text = "Save file directory";
            // 
            // jsonDataUrlLabel
            // 
            jsonDataUrlLabel.AutoSize = true;
            jsonDataUrlLabel.Location = new Point(6, 81);
            jsonDataUrlLabel.Margin = new Padding(6, 0, 6, 0);
            jsonDataUrlLabel.Name = "jsonDataUrlLabel";
            jsonDataUrlLabel.Size = new Size(165, 32);
            jsonDataUrlLabel.TabIndex = 3;
            jsonDataUrlLabel.Text = "JSON Data Url";
            // 
            // uploadUrlLabel
            // 
            uploadUrlLabel.AutoSize = true;
            uploadUrlLabel.Location = new Point(6, 19);
            uploadUrlLabel.Margin = new Padding(6, 0, 6, 0);
            uploadUrlLabel.Name = "uploadUrlLabel";
            uploadUrlLabel.Size = new Size(138, 32);
            uploadUrlLabel.TabIndex = 2;
            uploadUrlLabel.Text = "Upload URL";
            // 
            // jsonDataUrlTextbox
            // 
            jsonDataUrlTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            jsonDataUrlTextbox.Location = new Point(175, 75);
            jsonDataUrlTextbox.Margin = new Padding(6);
            jsonDataUrlTextbox.Name = "jsonDataUrlTextbox";
            jsonDataUrlTextbox.Size = new Size(585, 39);
            jsonDataUrlTextbox.TabIndex = 1;
            // 
            // uploadUrlTextbox
            // 
            uploadUrlTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uploadUrlTextbox.Location = new Point(175, 13);
            uploadUrlTextbox.Margin = new Padding(6);
            uploadUrlTextbox.Name = "uploadUrlTextbox";
            uploadUrlTextbox.Size = new Size(585, 39);
            uploadUrlTextbox.TabIndex = 0;
            // 
            // OblivionSaveUploader
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 785);
            Controls.Add(tabControl1);
            Controls.Add(startButton);
            Controls.Add(logLabel);
            Controls.Add(loggingTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "OblivionSaveUploader";
            Text = "Oblivion Save Uploader";
            tabControl1.ResumeLayout(false);
            tabPageBasic.ResumeLayout(false);
            tabPageBasic.PerformLayout();
            tabPageAdvanced.ResumeLayout(false);
            tabPageAdvanced.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private Button importSettingsButton;
        private Button syncButton;
    }
}