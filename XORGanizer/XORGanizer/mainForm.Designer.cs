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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
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
            //headers for eventsListView
            this.columnHeadeIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()
            {
                Text = "№",
                Width = 40,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Right,
            }));
            this.columnHeadeDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()
            {
                Text = "Описание",
                Width = 221,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            }));
            this.columnHeadeImportance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()
            {
                Text = "Важность",
                Width = 65,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            }));
            this.columnHeadeBeginningTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()
            {
                Text = "Начало",
                Width = 50,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            }));
            this.columnHeadeEndingTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()
            {
                Text = "Окончание",
                Width = 70,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            }));

            // 
            // monthCalendar
            // 
            this.monthCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.monthCalendar.Location = new System.Drawing.Point(18, 17);
            this.eventsListView.CheckBoxes = true;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 4;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_Click);
            // 
            // eventsListView
            // 
            this.eventsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.eventsListView.Location = new System.Drawing.Point(194, 17);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(450, 196);
            this.eventsListView.TabIndex = 5;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.Details;
            // 
            // addEventButton
            // 
            this.addEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEventButton.AutoSize = true;
            this.addEventButton.Location = new System.Drawing.Point(18, 191);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(164, 23);
            this.addEventButton.TabIndex = 6;
            this.addEventButton.Text = "Новое событие";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 226);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.eventsListView);
            this.Controls.Add(this.monthCalendar);
            this.Name = "MainForm";
            this.Text = "XORGanizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        //custom columnHeades
        private System.Windows.Forms.ColumnHeader columnHeadeImportance;
        private System.Windows.Forms.ColumnHeader columnHeadeIndex;
        private System.Windows.Forms.ColumnHeader columnHeadeDescription;
        private System.Windows.Forms.ColumnHeader columnHeadeBeginningTime;
        private System.Windows.Forms.ColumnHeader columnHeadeEndingTime;

    }
}

