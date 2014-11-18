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
        MainForm MainForm;

        public static Event sharedEvent;

        public void SetMainForm(MainForm mainForm) { MainForm = mainForm; }

        public EventConfiguringForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
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

            Event addedEvent = new Event(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
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

            sharedEvent = addedEvent;

            DateTime timeForNewDay = new DateTime(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()));

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
                //return;
            }
            catch (Exception)
            {
                MessageBox.Show("Время начала добавляемого события совпадает со временем начала уже добавленного события",
                    "Невозможно добавить событие", MessageBoxButtons.OK);
                //return;
            }


            DateRangeEventArgs args = new DateRangeEventArgs(timeForNewDay, DateTime.Now);
            MainForm.monthCalendar.SelectionStart = timeForNewDay;
            MainForm.monthCalendar.SelectionEnd = timeForNewDay;
            MainForm.monthCalendar_Click(null, args);

            //запишем это дело в файл
            FileStream FS = new FileStream(MainForm.listOfEventsPath + "\\List.txt", FileMode.Append);
            StreamWriter WR = new StreamWriter(FS);
            WR.Write( "" +"|");
            WR.Write(addedEvent.Description + "|");
            WR.Write(addedEvent.Importance + "|");
            WR.Write(addedEvent.Starting + "|");
            WR.Write(addedEvent.Ending + "|");
            
            WR.WriteLine();
            WR.Close();
        }
    }
}
