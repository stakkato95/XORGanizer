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
      
        public void Set(EventConfiguringForm of)
        {
            this.eventConfiguringForm = of;
        }

        public static string listOfEventsPath = Environment.CurrentDirectory;
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
                        values[0]);

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


          

            //такая конструкция красивее. надо переделать под неё
            //eventsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            //listViewItem1});

            //if (listOfEventsPath != null)
            //{
            //    line = reader.ReadToEnd();
            //    string[] values = line.Split('|');

            //    eventsListView.Items.Add(new ListViewItem(values));
            //}

       //     eventsListView.Items.Add(listLoad);

            //  reader.Close();

            //вот тут я бы поспорил чей код лучше

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
            eventConfiguringForm.SetMainForm(this);
            eventConfiguringForm.Show();

            //monthCalendar.TodayDate = monthCalendar.TodayDate;

            ArrayList A = new ArrayList();
            A.Add(beginningDateTimePicker.Value);
            A.Add(endingDateTimePicker.Value);
            A.Add(descriptionTextBox.Text);
            //A.Add(importanceGroupBox);

            //ListViewItem lol = new ListViewItem(new string[] { EventConfiguringForm.sharedEvent.Description, EventConfiguringForm.sharedEvent.Starting.ToString(), EventConfiguringForm.sharedEvent.Ending.ToString(), EventConfiguringForm.sharedEvent.Importance.ToString() });
            //eventsListView.Items.Add(lol);


            //  //eventsListView.Items.Add(addedEvent.Description);
            //  //eventsListView.Items.Add(addedEvent.Starting.ToString());
            //  //eventsListView.Items.Add(addedEvent.Ending.ToString());
            //  //eventsListView.Items.Add(addedEvent.isUrgent.ToString());
            //  //добаляем листвью наши строки


            //  //запишем это дело в файл
            //  FileStream FS = new FileStream("D:\\lol.txt", FileMode.Append);
            //  StreamWriter WR = new StreamWriter(FS);
            //  WR.Write(addedEvent.Description + "|");
            //  WR.Write(addedEvent.Starting + "|");
            //  WR.Write(addedEvent.Ending + "|");
            //  //WR.Write(addedEvent.Fulfillment);
            //  WR.WriteLine();
            //  WR.Close();
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
    }
}
