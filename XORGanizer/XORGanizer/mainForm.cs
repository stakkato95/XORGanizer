using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class Form1 : Form
    {
        SortedList<DateTime, Day> listOfDays = new SortedList<DateTime, Day>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void addEventButton_Click(object sender, EventArgs e)
        {
            Event addedEvent = new Event(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()),
                int.Parse(beginningDateTimePicker.Value.Hour.ToString()),
                int.Parse(beginningDateTimePicker.Value.Minute.ToString()),
                int.Parse(beginningDateTimePicker.Value.Second.ToString()),
                int.Parse(endingDateTimePicker.Value.Year.ToString()),
                int.Parse(endingDateTimePicker.Value.Month.ToString()),
                int.Parse(endingDateTimePicker.Value.Day.ToString()),
                int.Parse(endingDateTimePicker.Value.Hour.ToString()),
                int.Parse(endingDateTimePicker.Value.Minute.ToString()),
                int.Parse(endingDateTimePicker.Value.Second.ToString()),
                isUrgentCheckBox.Checked,
                descriptionTextBox.Text);

            DateTime timeForNewDay = new DateTime(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()));

            Day addedDay = new Day(timeForNewDay);

            try
            {
                if (listOfDays.ContainsValue(addedDay))
                {
                    listOfDays[timeForNewDay].addEvent(addedEvent);

                    MessageBox.Show("Событие успешно добавлено");
                    descriptionTextBox.Text = "";
                }
                else
                {
                    listOfDays.Add(timeForNewDay, new Day(timeForNewDay));
                    listOfDays[timeForNewDay].addEvent(addedEvent);

                    MessageBox.Show("Событие успешно добавлено");
                    descriptionTextBox.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Время начал добавляемого события совпадает со временем начала уже добавленного события",
                    "Невозможно добавить событие", MessageBoxButtons.OK);
            }
        }

        private void monthCalendar_Click(object sender, DateRangeEventArgs e)
        {
            //TODO реагирует список eventsListView
        }

    }
}
