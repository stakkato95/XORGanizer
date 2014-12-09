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

        private static string listOfEventsPath = Environment.CurrentDirectory;

        public MainForm()
        {
            InitializeComponent();
        }

        public void EventsLoadMetod(ref StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split('|');

                //starting parameters for the event
                string[] fullStartingDate = values[3].Split(' ');
                string[] startingDayMonthYear = fullStartingDate[0].Split('.');
                int[] parsedStartingDayMonthYear =
                    startingDayMonthYear.OfType<string>().Select(str => int.Parse(str)).ToArray();

                string[] startingHourMinuteSecond = fullStartingDate[1].Split(':');
                int[] parsedStartingHourMinute =
                    startingHourMinuteSecond.OfType<string>().Select(str => int.Parse(str)).ToArray();

                //ending parameters for the event
                string[] fullEndingDate = values[4].Split(' ');
                string[] enfdingDayMonthYear = fullEndingDate[0].Split('.');
                int[] parsedEndingDayMonthYear =
                    enfdingDayMonthYear.OfType<string>().Select(str => int.Parse(str)).ToArray();

                string[] endingHourMinuteSecond = fullEndingDate[1].Split(':');
                int[] parsedEndingHourMinute =
                    endingHourMinuteSecond.OfType<string>().Select(str => int.Parse(str)).ToArray();

                //importance parameter for the event
                EventImportance levelOfImportance =
                    (EventImportance)Enum.Parse(typeof(EventImportance), values[2], true);

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(listOfEventsPath + "\\List.txt"))
            {
                StreamReader reader = new StreamReader(listOfEventsPath + "\\List.txt");
                EventsLoadMetod(ref reader);
            }
            else
            {
                FileStream FS2 = new FileStream(listOfEventsPath + "\\List.txt", FileMode.Create);
                FS2.Close();
            }

            eventsListView.Columns.Add("Описание", 120);
            eventsListView.Columns.Add("Важность", 80);
            eventsListView.Columns.Add("Начало", 120);
            eventsListView.Columns.Add("Окончание", 120);

            System.Windows.Forms.ContextMenu listViewContextMenu = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem();

            listViewContextMenu.MenuItems.Add(menuItem);
            menuItem.Index = 0;
            menuItem.Text = "Удалить";
            menuItem.Click += eventsListView_MouseUp;
            eventsListView.ContextMenu = listViewContextMenu;

            DateRangeEventArgs args = new DateRangeEventArgs(
                new DateTime(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString()),
                    int.Parse(DateTime.Now.Day.ToString())), DateTime.Now);
            monthCalendar_Click(null, args);
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm();
            eventConfiguringForm.ShowDialog();
            DialogResult dialogResult = eventConfiguringForm.DialogResult;

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (listOfDays.ContainsKey(eventConfiguringForm.TimeForNewDay))
                    {
                        listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                        MessageBox.Show("Событие успешно добавлено");
                    }
                    else
                    {
                        listOfDays.AddDay(eventConfiguringForm.TimeForNewDay,
                            new Day(eventConfiguringForm.TimeForNewDay));
                        listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                        MessageBox.Show("Событие успешно добавлено");
                    }

                    DateRangeEventArgs args = new DateRangeEventArgs(eventConfiguringForm.TimeForNewDay, DateTime.Now);
                    monthCalendar.SelectionStart = eventConfiguringForm.TimeForNewDay;
                    monthCalendar.SelectionEnd = eventConfiguringForm.TimeForNewDay;
                    monthCalendar_Click(null, args);

                }
                catch (InvalidTimeZoneException)
                {
                    MessageBox.Show("Время начала события больше времени его окончания",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Время начала события совпадает со временем начала уже существующего события",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
            }
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
                    importance = selectedDayEvent.Value.Importance == EventImportance.Middle
                        ? "Средняя"
                        : (selectedDayEvent.Value.Importance == EventImportance.Low ? "Низкая" : "Высокая");

                    item = new ListViewItem(selectedDayEvent.Value.Description.ToString());
                    item.SubItems.Add(importance);
                    item.SubItems.Add(selectedDayEvent.Value.Starting.ToShortTimeString());
                    item.SubItems.Add(selectedDayEvent.Value.Ending.ToShortTimeString());
                    eventsListView.Items.Add(item);
                }
            }
        }

        private void StreamWritingBeforeClose()
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWritingBeforeClose();
        }

        private void eventsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = eventsListView.SelectedItems[0];
            string description = selectedItem.SubItems[0].Text;
            EventImportance importance = selectedItem.SubItems[1].Text == "Средняя"
                ? EventImportance.Middle
                : selectedItem.SubItems[1].Text == "Низкая" ? EventImportance.Low : EventImportance.High;

            DateTime timeOfEditedEvent = monthCalendar.SelectionStart;
            int[] beginningHourMinute =
                selectedItem.SubItems[2].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();
            int[] endingHourMinute =
                selectedItem.SubItems[3].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();

            Event editedEvent = new Event(timeOfEditedEvent.Year, timeOfEditedEvent.Month, timeOfEditedEvent.Day,
                beginningHourMinute[0], beginningHourMinute[1], timeOfEditedEvent.Year, timeOfEditedEvent.Month,
                timeOfEditedEvent.Day, endingHourMinute[0], endingHourMinute[1], importance, description);

            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm();
            eventConfiguringForm.EditedEvent = editedEvent;
            eventConfiguringForm.EditingMod = true;
            eventConfiguringForm.ShowDialog();
            DialogResult dialogResult = eventConfiguringForm.DialogResult;

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (listOfDays.ContainsKey(eventConfiguringForm.TimeForNewDay))
                    {
                        listOfDays[timeOfEditedEvent].DeleteEvent(eventConfiguringForm.EditedEvent);
                        listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                        MessageBox.Show("Событие успешно отредактировано");
                    }
                    else
                    {
                        listOfDays.AddDay(eventConfiguringForm.TimeForNewDay,
                            new Day(eventConfiguringForm.TimeForNewDay));
                        listOfDays[timeOfEditedEvent].DeleteEvent(eventConfiguringForm.EditedEvent);
                        listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                        MessageBox.Show("Событие успешно отредактировано");
                    }

                    DateRangeEventArgs args = new DateRangeEventArgs(eventConfiguringForm.TimeForNewDay, DateTime.Now);
                    monthCalendar.SelectionStart = eventConfiguringForm.TimeForNewDay;
                    monthCalendar.SelectionEnd = eventConfiguringForm.TimeForNewDay;
                    monthCalendar_Click(null, args);

                }
                catch (InvalidTimeZoneException)
                {
                    MessageBox.Show("Время начала события больше времени его окончания",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Время начала события совпадает со временем начала уже существующего события",
                        "Невозможно добавить событие", MessageBoxButtons.OK);
                }
            }
        }

        private void добавитьСобытияИзФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Файлы txt|*.txt";


            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {


                StreamReader reader = new StreamReader(OpenFileDialog.OpenFile());

                EventsLoadMetod(ref reader);

            }

            DateRangeEventArgs args =
                new DateRangeEventArgs(
                    new DateTime(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString()),
                        int.Parse(DateTime.Now.Day.ToString())), DateTime.Now);
            monthCalendar_Click(null, args);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWritingBeforeClose();
            this.Close();
        }

        private void eventsListView_MouseUp(object sender, EventArgs e)
        {
            while (eventsListView.SelectedItems.Count > 0)
            {
                int[] deletedEventYearMonthDay = monthCalendar.SelectionStart.ToString().Substring(0, 10).Split('.').OfType<string>().Select(str => int.Parse(str)).ToArray();
                int[] deletedEventHourMinute = eventsListView.SelectedItems[0].SubItems[2].ToString().Substring(18, 5).Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();
                DateTime deletedEventDate = new DateTime(deletedEventYearMonthDay[2], deletedEventYearMonthDay[1], deletedEventYearMonthDay[0], deletedEventHourMinute[0], deletedEventHourMinute[1], 0);

                DateTime dayOfDeletedEvent = new DateTime(deletedEventYearMonthDay[2], deletedEventYearMonthDay[1], deletedEventYearMonthDay[0], 0, 0, 0);
                listOfDays[dayOfDeletedEvent].DeleteEvent(deletedEventDate);

                eventsListView.Items.Remove(eventsListView.SelectedItems[0]);
            }
        }

    }
}
