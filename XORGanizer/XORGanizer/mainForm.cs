using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class MainForm : Form
    {
        public Calendar listOfDays = new Calendar();

        EventConfiguringForm eventConfiguringForm;

        public static string listOfEventsPath = Environment.CurrentDirectory;
      
        public void Set(EventConfiguringForm of)
        {
            this.eventConfiguringForm = of;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(listOfEventsPath + "\\List.txt"))
            {
                StreamReader reader = new StreamReader(listOfEventsPath + "\\List.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split('|');

                    //starting parameters for the event
                    string[] fullStartingDate = values[3].Split(' ');
                    string[] startingDayMonthYear = fullStartingDate[0].Split('.');
                    int[] parsedStartingDayMonthYear = startingDayMonthYear.OfType<string>().Select(str => int.Parse(str)).ToArray();

                    string[] startingHourMinuteSecond= fullStartingDate[1].Split(':');
                    int[] parsedStartingHourMinute = startingHourMinuteSecond.OfType<string>().Select(str => int.Parse(str)).ToArray();

                    //ending parameters for the event
                    string[] fullEndingDate = values[4].Split(' ');
                    string[] enfdingDayMonthYear = fullEndingDate[0].Split('.');
                    int[] parsedEndingDayMonthYear = enfdingDayMonthYear.OfType<string>().Select(str => int.Parse(str)).ToArray();

                    string[] endingHourMinuteSecond = fullEndingDate[1].Split(':');
                    int[] parsedEndingHourMinute = endingHourMinuteSecond.OfType<string>().Select(str => int.Parse(str)).ToArray();

                    //importance parameter for the event
                    EventImportance levelOfImportance = (EventImportance)Enum.Parse(typeof(EventImportance), values[2], true);

                    Event addedEvent = new Event(parsedStartingDayMonthYear[2],
                        parsedStartingDayMonthYear[1],
                        parsedStartingDayMonthYear[0],
                        parsedStartingHourMinute[0],
                        parsedStartingHourMinute[1],
                        parsedEndingDayMonthYear[2],
                        parsedEndingDayMonthYear[1],
                        parsedEndingDayMonthYear[0],
                        parsedEndingHourMinute[0],
                        parsedEndingHourMinute[1],
                        levelOfImportance,
                        values[1]);

                    DateTime timeForNewDay = new DateTime(parsedStartingDayMonthYear[2],
                        parsedStartingDayMonthYear[1],
                        parsedStartingDayMonthYear[0]);

                    if (listOfDays.ContainsKey(timeForNewDay))
                    {
                        listOfDays[timeForNewDay].AddEvent(addedEvent);
                    }
                    else
                    {
                        listOfDays.AddDay(timeForNewDay, new Day(timeForNewDay));
                        listOfDays[timeForNewDay].AddEvent(addedEvent);
                    }
                }
                reader.Close();
            }
            else
            {
                FileStream FS2 = new FileStream(listOfEventsPath + "\\List.txt", FileMode.Create);
                FS2.Close();
            }

            eventsListView.Columns.Add("Описание");
            eventsListView.Columns.Add("Важность");
            eventsListView.Columns.Add("Начало");
            eventsListView.Columns.Add("Окончание");

            DateRangeEventArgs args = new DateRangeEventArgs(new DateTime(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Day.ToString())), DateTime.Now);
            monthCalendar_Click(null, args);
        }


        private void addEventButton_Click(object sender, EventArgs e)
        {
            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm();
            eventConfiguringForm.SetListOfDays(ref listOfDays);
            eventConfiguringForm.Show();
        }


        public void monthCalendar_Click(object sender, DateRangeEventArgs e)
        {
            eventsListView.Items.Clear();

            ListViewItem item = null;
            string importance = null;

            if (listOfDays.ContainsKey(e.Start))
            {
                foreach (KeyValuePair<DateTime, Event> selectedDayEvent in listOfDays[e.Start])
                {
                    importance = selectedDayEvent.Value.Importance == EventImportance.Middle ? "Средняя" : (selectedDayEvent.Value.Importance == EventImportance.Low ? "Низкая" : "Высокая");

                    item = new ListViewItem(selectedDayEvent.Value.Description.ToString());
                    item.SubItems.Add(importance);
                    item.SubItems.Add(selectedDayEvent.Value.Starting.ToShortTimeString());
                    item.SubItems.Add(selectedDayEvent.Value.Ending.ToShortTimeString());
                    eventsListView.Items.Add(item);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete(MainForm.listOfEventsPath + "\\List.txt");

            FileStream FS = new FileStream(MainForm.listOfEventsPath + "\\List.txt", FileMode.Create);
            StreamWriter WR = new StreamWriter(FS);

            foreach (KeyValuePair<DateTime, Day> day in listOfDays)
            {
                foreach (KeyValuePair<DateTime, Event> evnt in day.Value)
                {
                    WR.Write("" + "|");
                    WR.Write(evnt.Value.Description + "|");
                    WR.Write(evnt.Value.Importance + "|");
                    WR.Write(evnt.Value.Starting + "|");
                    WR.Write(evnt.Value.Ending + "|");

                    WR.WriteLine();
                }
            }

            WR.Close();
            FS.Close();
        }

        private void eventsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = eventsListView.SelectedItems[0];
            string description = selectedItem.SubItems[0].Text;
            EventImportance importance = selectedItem.SubItems[1].Text == "Средняя" ? EventImportance.Middle : selectedItem.SubItems[1].Text == "Низкая" ? EventImportance.Low : EventImportance.High;

            DateTime yearMonthDay = monthCalendar.SelectionStart;
            int[] beginningHourMinute = selectedItem.SubItems[2].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();
            int[] endingHourMinute = selectedItem.SubItems[3].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();

            Event editedEvent = new Event(yearMonthDay.Year, yearMonthDay.Month, yearMonthDay.Day, beginningHourMinute[0], beginningHourMinute[1], yearMonthDay.Year, yearMonthDay.Month, yearMonthDay.Day, endingHourMinute[0], endingHourMinute[1], importance, description);

            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm();
            eventConfiguringForm.SetListOfDays(ref listOfDays);
            eventConfiguringForm.EditingMod = true;
            eventConfiguringForm.EditedEvent = editedEvent;
            eventConfiguringForm.Show();
        }
    }
}
