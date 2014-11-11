﻿using System;
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
        public SortedList<DateTime, Day> listOfDays = new SortedList<DateTime, Day>();

        EventConfiguringForm eventConfiguringForm;
      
        public void Set(EventConfiguringForm of)
        {
            this.eventConfiguringForm = of;
        }
    
        //   private const string listOfEventsPath = "C:\\List_of_events.txt";
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("E:\\List_of_events.txt"))
            {
                StreamReader reader = new StreamReader("E:\\List_of_events.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split('|');

                    eventsListView.Items.Add(new ListViewItem(values));
                }
                reader.Close();
            }
            else
            {
                FileStream FS2 = new FileStream("E:\\List_of_events.txt", FileMode.Create);
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

            eventsListView.View = View.Details;
            eventsListView.Columns.Add("descr", 200);
            eventsListView.Columns.Add("start", 120);
            eventsListView.Columns.Add("end", 120);
            eventsListView.Columns.Add("isurgent", 50);

            eventsListView.Columns.Add(columnHeadeIndex);
            eventsListView.Columns.Add(columnHeadeDescription);
            eventsListView.Columns.Add(columnHeadeImportance);
            eventsListView.Columns.Add(columnHeadeBeginningTime);
            eventsListView.Columns.Add(columnHeadeEndingTime);
        }


        private void addEventButton_Click(object sender, EventArgs e)
        {
            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm();
            eventConfiguringForm.SetMainForm(this);
            eventConfiguringForm.Show();


            ArrayList A = new ArrayList();
            A.Add(beginningDateTimePicker.Value);
            A.Add(endingDateTimePicker.Value);
            A.Add(descriptionTextBox.Text);
            A.Add(importanceGroupBox)

            //ListViewItem lol = new ListViewItem(new string[] { addedEvent.Description, addedEvent.Starting.ToString(), addedEvent.Ending.ToString(), addedEvent.isUrgent.ToString() });
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


        private void monthCalendar_Click(object sender, DateRangeEventArgs e)
        {
            int index = 1;
            ListViewItem item = null;
            string importance = null;

            if (listOfDays.ContainsKey(e.Start))
            {
                foreach (KeyValuePair<DateTime, Event> selectedDayEvent in listOfDays[e.Start])
                {
                    importance = selectedDayEvent.Value.Importance == EventImportance.Middle ? "Средняя" : (selectedDayEvent.Value.Importance == EventImportance.Low ? "Низкая" : "Высокая");

                    item = new ListViewItem(index.ToString());
                    item.SubItems.Add(selectedDayEvent.Value.Description.ToString());
                    item.SubItems.Add(importance);
                    item.SubItems.Add(selectedDayEvent.Value.Starting.ToShortTimeString());
                    item.SubItems.Add(selectedDayEvent.Value.Ending.ToShortTimeString());
                    eventsListView.Items.Add(item);
                    index++;
                }
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
           
           // FileStream fs = new FileStream("E:\\lol.txt", FileMode.Open, FileAccess.Read);
           // StreamReader sr = new StreamReader(fs);
           // string str;
           // List<string> ls = new List<string>();

           // while ((str = sr.ReadLine()) != null)
           // {
           //     ls.Add(str);
           // }

           //int d = int.Parse(monthCalendar.SelectionStart.Day.ToString());
           //int y = int.Parse(monthCalendar.SelectionStart.Year.ToString());
           //int m = int.Parse(monthCalendar.SelectionStart.Month.ToString());
        }
    }
}
