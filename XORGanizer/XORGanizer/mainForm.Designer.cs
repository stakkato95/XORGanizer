namespace XORGanizer
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.eventsListView = new System.Windows.Forms.ListView();
            this.addEventButton = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.beginningDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.beginningLabel = new System.Windows.Forms.Label();
            this.endingLabel = new System.Windows.Forms.Label();
            this.endingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.isUrgentCheckBox = new System.Windows.Forms.CheckBox();
            this.eventsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(702, 46);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 4;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_Click);
            // 
            // eventsListView
            // 
            this.eventsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.eventsListView.Location = new System.Drawing.Point(412, 46);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(278, 196);
            this.eventsListView.TabIndex = 5;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.List;
            // 
            // addEventButton
            // 
            this.addEventButton.AutoSize = true;
            this.addEventButton.Location = new System.Drawing.Point(12, 226);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(95, 23);
            this.addEventButton.TabIndex = 6;
            this.addEventButton.Text = "Новое событие";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(110, 18);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(267, 20);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // beginningDateTimePicker
            // 
            this.beginningDateTimePicker.CustomFormat = "dd.MM.yyyy - HH.mm.ss";
            this.beginningDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginningDateTimePicker.Location = new System.Drawing.Point(110, 45);
            this.beginningDateTimePicker.Name = "beginningDateTimePicker";
            this.beginningDateTimePicker.Size = new System.Drawing.Size(267, 20);
            this.beginningDateTimePicker.TabIndex = 8;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(12, 18);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(83, 20);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Описание";
            // 
            // beginningLabel
            // 
            this.beginningLabel.AutoSize = true;
            this.beginningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginningLabel.Location = new System.Drawing.Point(12, 47);
            this.beginningLabel.Name = "beginningLabel";
            this.beginningLabel.Size = new System.Drawing.Size(67, 20);
            this.beginningLabel.TabIndex = 10;
            this.beginningLabel.Text = "Начало";
            // 
            // endingLabel
            // 
            this.endingLabel.AutoSize = true;
            this.endingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endingLabel.Location = new System.Drawing.Point(12, 76);
            this.endingLabel.Name = "endingLabel";
            this.endingLabel.Size = new System.Drawing.Size(92, 20);
            this.endingLabel.TabIndex = 17;
            this.endingLabel.Text = "Окончание";
            // 
            // endingDateTimePicker
            // 
            this.endingDateTimePicker.CustomFormat = "dd.MM.yyyy - HH.mm.ss";
            this.endingDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endingDateTimePicker.Location = new System.Drawing.Point(110, 75);
            this.endingDateTimePicker.Name = "endingDateTimePicker";
            this.endingDateTimePicker.Size = new System.Drawing.Size(267, 20);
            this.endingDateTimePicker.TabIndex = 16;
            // 
            // isUrgentCheckBox
            // 
            this.isUrgentCheckBox.AutoSize = true;
            this.isUrgentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isUrgentCheckBox.Location = new System.Drawing.Point(16, 99);
            this.isUrgentCheckBox.Name = "isUrgentCheckBox";
            this.isUrgentCheckBox.Size = new System.Drawing.Size(93, 24);
            this.isUrgentCheckBox.TabIndex = 22;
            this.isUrgentCheckBox.Text = "Срочное";
            this.isUrgentCheckBox.UseVisualStyleBackColor = true;
            // 
            // eventsLabel
            // 
            this.eventsLabel.AutoSize = true;
            this.eventsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eventsLabel.Location = new System.Drawing.Point(504, 16);
            this.eventsLabel.Name = "eventsLabel";
            this.eventsLabel.Size = new System.Drawing.Size(109, 20);
            this.eventsLabel.TabIndex = 23;
            this.eventsLabel.Text = "События дня";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 261);
            this.Controls.Add(this.eventsLabel);
            this.Controls.Add(this.isUrgentCheckBox);
            this.Controls.Add(this.endingLabel);
            this.Controls.Add(this.endingDateTimePicker);
            this.Controls.Add(this.beginningLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.beginningDateTimePicker);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.eventsListView);
            this.Controls.Add(this.monthCalendar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ListView eventsListView;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker beginningDateTimePicker;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label beginningLabel;
        private System.Windows.Forms.Label endingLabel;
        private System.Windows.Forms.DateTimePicker endingDateTimePicker;
        private System.Windows.Forms.CheckBox isUrgentCheckBox;
        private System.Windows.Forms.Label eventsLabel;

    }
}

