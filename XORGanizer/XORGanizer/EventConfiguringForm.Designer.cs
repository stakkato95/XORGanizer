namespace XORGanizer
{
    partial class EventConfiguringForm
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
            this.beginningDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.beginningLabel = new System.Windows.Forms.Label();
            this.endingLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.importanceGroupBox = new System.Windows.Forms.GroupBox();
            this.lowImportanceRadioButton = new System.Windows.Forms.RadioButton();
            this.middleImportanceRadioButton = new System.Windows.Forms.RadioButton();
            this.highImportanceRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importanceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // beginningDateTimePicker
            // 
            this.beginningDateTimePicker.CustomFormat = "dd.MM.yyyy - HH.mm";
            this.beginningDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginningDateTimePicker.Location = new System.Drawing.Point(80, 12);
            this.beginningDateTimePicker.Name = "beginningDateTimePicker";
            this.beginningDateTimePicker.Size = new System.Drawing.Size(292, 20);
            this.beginningDateTimePicker.TabIndex = 9;
            this.beginningDateTimePicker.ValueChanged += new System.EventHandler(this.beginningDateTimePicker_ValueChanged);
            // 
            // endingDateTimePicker
            // 
            this.endingDateTimePicker.CustomFormat = "dd.MM.yyyy - HH.mm";
            this.endingDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endingDateTimePicker.Location = new System.Drawing.Point(80, 38);
            this.endingDateTimePicker.Name = "endingDateTimePicker";
            this.endingDateTimePicker.Size = new System.Drawing.Size(292, 20);
            this.endingDateTimePicker.TabIndex = 17;
            this.endingDateTimePicker.ValueChanged += new System.EventHandler(this.endingDateTimePicker_ValueChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 64);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(57, 13);
            this.descriptionLabel.TabIndex = 18;
            this.descriptionLabel.Text = "Описание";
            // 
            // beginningLabel
            // 
            this.beginningLabel.AutoSize = true;
            this.beginningLabel.Location = new System.Drawing.Point(12, 12);
            this.beginningLabel.Name = "beginningLabel";
            this.beginningLabel.Size = new System.Drawing.Size(44, 13);
            this.beginningLabel.TabIndex = 19;
            this.beginningLabel.Text = "Начало";
            // 
            // endingLabel
            // 
            this.endingLabel.AutoSize = true;
            this.endingLabel.Location = new System.Drawing.Point(12, 38);
            this.endingLabel.Name = "endingLabel";
            this.endingLabel.Size = new System.Drawing.Size(62, 13);
            this.endingLabel.TabIndex = 20;
            this.endingLabel.Text = "Окончание";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(80, 64);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(292, 46);
            this.descriptionTextBox.TabIndex = 21;
            // 
            // importanceGroupBox
            // 
            this.importanceGroupBox.Controls.Add(this.lowImportanceRadioButton);
            this.importanceGroupBox.Controls.Add(this.middleImportanceRadioButton);
            this.importanceGroupBox.Controls.Add(this.highImportanceRadioButton);
            this.importanceGroupBox.Location = new System.Drawing.Point(80, 116);
            this.importanceGroupBox.Name = "importanceGroupBox";
            this.importanceGroupBox.Size = new System.Drawing.Size(292, 43);
            this.importanceGroupBox.TabIndex = 22;
            this.importanceGroupBox.TabStop = false;
            this.importanceGroupBox.Text = "Важность";
            // 
            // lowImportanceRadioButton
            // 
            this.lowImportanceRadioButton.AutoSize = true;
            this.lowImportanceRadioButton.Location = new System.Drawing.Point(6, 16);
            this.lowImportanceRadioButton.Name = "lowImportanceRadioButton";
            this.lowImportanceRadioButton.Size = new System.Drawing.Size(63, 17);
            this.lowImportanceRadioButton.TabIndex = 3;
            this.lowImportanceRadioButton.TabStop = true;
            this.lowImportanceRadioButton.Text = "Низкая";
            this.lowImportanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // middleImportanceRadioButton
            // 
            this.middleImportanceRadioButton.AutoSize = true;
            this.middleImportanceRadioButton.Checked = true;
            this.middleImportanceRadioButton.Location = new System.Drawing.Point(117, 16);
            this.middleImportanceRadioButton.Name = "middleImportanceRadioButton";
            this.middleImportanceRadioButton.Size = new System.Drawing.Size(68, 17);
            this.middleImportanceRadioButton.TabIndex = 1;
            this.middleImportanceRadioButton.TabStop = true;
            this.middleImportanceRadioButton.Text = "Средняя";
            this.middleImportanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // highImportanceRadioButton
            // 
            this.highImportanceRadioButton.AutoSize = true;
            this.highImportanceRadioButton.Location = new System.Drawing.Point(216, 16);
            this.highImportanceRadioButton.Name = "highImportanceRadioButton";
            this.highImportanceRadioButton.Size = new System.Drawing.Size(70, 17);
            this.highImportanceRadioButton.TabIndex = 0;
            this.highImportanceRadioButton.TabStop = true;
            this.highImportanceRadioButton.Text = "Высокая";
            this.highImportanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(13, 166);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(175, 23);
            this.okButton.TabIndex = 23;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(197, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(175, 23);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EventConfiguringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.importanceGroupBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.endingLabel);
            this.Controls.Add(this.beginningLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.endingDateTimePicker);
            this.Controls.Add(this.beginningDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EventConfiguringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка события";
            this.Load += new System.EventHandler(this.EventConfiguringForm_Load);
            this.importanceGroupBox.ResumeLayout(false);
            this.importanceGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker beginningDateTimePicker;
        private System.Windows.Forms.DateTimePicker endingDateTimePicker;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label beginningLabel;
        private System.Windows.Forms.Label endingLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.GroupBox importanceGroupBox;
        private System.Windows.Forms.RadioButton lowImportanceRadioButton;
        private System.Windows.Forms.RadioButton middleImportanceRadioButton;
        private System.Windows.Forms.RadioButton highImportanceRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}