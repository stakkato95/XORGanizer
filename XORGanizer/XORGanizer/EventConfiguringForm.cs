using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class EventConfiguringForm : Form
    {
        private Calendar listOfDays;
        public Event EditedEvent;
        public Event NewEvent;
        public bool EditingMod;
        public DateTime TimeForNewDay;
        public DateTime TimeForEditedEvent;

        public void SetListOfDays(ref Calendar listOfDays) { this.listOfDays = listOfDays; }

        public EventConfiguringForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(!EditingMod)
                PrimaryEventSetting(ref NewEvent, ref TimeForNewDay);
            else
                PrimaryEventSetting(ref NewEvent, ref TimeForNewDay);

            //ДАЛЬШЕ ПОПРОБОВАТЬ ЗАПИЛИТЬ ТАКУЮ КОНСТРУКЦИЮ
            //((MainForm)sender).listOfDays;
            //PrimaryEventSetting(ref ((MainForm)sender).NewEvent, ref ((MainForm)sender).TimeForNewDay);
        }

        private void PrimaryEventSetting(ref Event addedEvent, ref DateTime timeForNewDay)
        {
            int intValueOfImportance = 0;
            for (int i = 0; i < importanceGroupBox.Controls.Count; i++)
            {
                if (((RadioButton)importanceGroupBox.Controls[i]).Checked)
                {
                    intValueOfImportance = i;
                    break;
                }
            }

            EventImportance levelOfImportance = (EventImportance)Enum.Parse(typeof(EventImportance), intValueOfImportance.ToString(), true);

            addedEvent = new Event(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()),
                int.Parse(beginningDateTimePicker.Value.Hour.ToString()),
                int.Parse(beginningDateTimePicker.Value.Minute.ToString()),
                int.Parse(endingDateTimePicker.Value.Year.ToString()),
                int.Parse(endingDateTimePicker.Value.Month.ToString()),
                int.Parse(endingDateTimePicker.Value.Day.ToString()),
                int.Parse(endingDateTimePicker.Value.Hour.ToString()),
                int.Parse(endingDateTimePicker.Value.Minute.ToString()),
                levelOfImportance,
                descriptionTextBox.Text);

            timeForNewDay = new DateTime(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                                            int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                                            int.Parse(beginningDateTimePicker.Value.Day.ToString()));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EventConfiguringForm_Load(object sender, EventArgs e)
        {
            if (EditingMod)
            {
                beginningDateTimePicker.Value = EditedEvent.Starting;
                endingDateTimePicker.Value = EditedEvent.Ending;
                descriptionTextBox.Text = EditedEvent.Description;
                if (EditedEvent.Importance == EventImportance.Middle)
                    middleImportanceRadioButton.Select();
                else if (EditedEvent.Importance == EventImportance.Low)
                    lowImportanceRadioButton.Select();
                else if (EditedEvent.Importance == EventImportance.High)
                    highImportanceRadioButton.Select();
            }
        }
    }
}
