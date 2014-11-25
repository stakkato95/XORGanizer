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
        public Event EditedEvent;
        public bool EditingMod;

        MainForm MainForm;

        public void SetMainForm(MainForm mainForm) { MainForm = mainForm; }

        public EventConfiguringForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Event addedEvent = null;
            DateTime timeForNewDay = new DateTime();

            if (EditingMod)
            {
                PrimaryEventSetting(ref addedEvent, ref timeForNewDay);

                try
                {
                    if (MainForm.listOfDays.ContainsKey(timeForNewDay))
                    {
                        MainForm.listOfDays[timeForNewDay].DeleteEvent(EditedEvent);
                        MainForm.listOfDays[timeForNewDay].AddEvent(addedEvent);

                        this.Close();
                        MessageBox.Show("Событие успешно отредактированио");
                    }
                    else
                    {
                        MainForm.listOfDays.AddDay(timeForNewDay, new Day(timeForNewDay));
                        MainForm.listOfDays[timeForNewDay].DeleteEvent(EditedEvent);
                        MainForm.listOfDays[timeForNewDay].AddEvent(addedEvent);

                        this.Close();
                        MessageBox.Show("Событие успешно отредактированио");
                    }
                }
                catch (InvalidTimeZoneException)
                {
                    MessageBox.Show("Время начала редактируемого события больше времени его окончания",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Время начала редактируемого события совпадает со временем начала уже существующего события",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
            }
            else
            {
                PrimaryEventSetting(ref addedEvent, ref timeForNewDay);

                try
                {
                    if (MainForm.listOfDays.ContainsKey(timeForNewDay))
                    {
                        MainForm.listOfDays[timeForNewDay].AddEvent(addedEvent);

                        this.Close();
                        MessageBox.Show("Событие успешно добавлено");
                        descriptionTextBox.Text = "";
                    }
                    else
                    {
                        MainForm.listOfDays.AddDay(timeForNewDay, new Day(timeForNewDay));
                        MainForm.listOfDays[timeForNewDay].AddEvent(addedEvent);

                        this.Close();
                        MessageBox.Show("Событие успешно добавлено");
                        descriptionTextBox.Text = "";
                    }
                }
                catch (InvalidTimeZoneException)
                {
                    MessageBox.Show("Время начала добавляемого события больше времени его окончания",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Время начала добавляемого события совпадает со временем начала уже существующего события",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
            }



            


            DateRangeEventArgs args = new DateRangeEventArgs(timeForNewDay, DateTime.Now);
            MainForm.monthCalendar.SelectionStart = timeForNewDay;
            MainForm.monthCalendar.SelectionEnd = timeForNewDay;
            MainForm.monthCalendar_Click(null, args);
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
