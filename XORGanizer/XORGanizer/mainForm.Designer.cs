namespace XORGanizer
{
    partial class MainForm
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСобытияИзФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.monthCalendar.Location = new System.Drawing.Point(18, 33);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 4;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_Click);
            // 
            // eventsListView
            // 
            this.eventsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewItem1.StateImageIndex = 0;
            this.eventsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.eventsListView.Location = new System.Drawing.Point(194, 34);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(450, 195);
            this.eventsListView.TabIndex = 5;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.Details;
            this.eventsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.eventsListView_DoubleClick);
            // 
            // addEventButton
            // 
            this.addEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEventButton.AutoSize = true;
            this.addEventButton.Location = new System.Drawing.Point(18, 206);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(164, 23);
            this.addEventButton.TabIndex = 6;
            this.addEventButton.Text = "Новое событие";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // beginningDateTimePicker
            // 
            this.beginningDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.beginningDateTimePicker.Name = "beginningDateTimePicker";
            this.beginningDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.beginningDateTimePicker.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel.TabIndex = 0;
            // 
            // beginningLabel
            // 
            this.beginningLabel.Location = new System.Drawing.Point(0, 0);
            this.beginningLabel.Name = "beginningLabel";
            this.beginningLabel.Size = new System.Drawing.Size(100, 23);
            this.beginningLabel.TabIndex = 0;
            // 
            // endingLabel
            // 
            this.endingLabel.Location = new System.Drawing.Point(0, 0);
            this.endingLabel.Name = "endingLabel";
            this.endingLabel.Size = new System.Drawing.Size(100, 23);
            this.endingLabel.TabIndex = 0;
            // 
            // endingDateTimePicker
            // 
            this.endingDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.endingDateTimePicker.Name = "endingDateTimePicker";
            this.endingDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endingDateTimePicker.TabIndex = 0;
            // 
            // isUrgentCheckBox
            // 
            this.isUrgentCheckBox.Location = new System.Drawing.Point(0, 0);
            this.isUrgentCheckBox.Name = "isUrgentCheckBox";
            this.isUrgentCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isUrgentCheckBox.TabIndex = 0;
            // 
            // eventsLabel
            // 
            this.eventsLabel.Location = new System.Drawing.Point(0, 0);
            this.eventsLabel.Name = "eventsLabel";
            this.eventsLabel.Size = new System.Drawing.Size(100, 23);
            this.eventsLabel.TabIndex = 0;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСобытияИзФайлToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьСобытияИзФайлToolStripMenuItem
            // 
            this.добавитьСобытияИзФайлToolStripMenuItem.Name = "добавитьСобытияИзФайлToolStripMenuItem";
            this.добавитьСобытияИзФайлToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.добавитьСобытияИзФайлToolStripMenuItem.Text = "Добавить события из файла";
            this.добавитьСобытияИзФайлToolStripMenuItem.Click += new System.EventHandler(this.добавитьСобытияИзФайлToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 241);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.eventsListView);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(672, 265);
            this.Name = "MainForm";
            this.Text = "XORGanizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСобытияИзФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;

    }
}

