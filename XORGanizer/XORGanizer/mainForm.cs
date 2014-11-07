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
    public partial class Form1 : Form
    {
        SortedList<DateTime, Day> listOfDays = new SortedList<DateTime, Day>();

        private const string pathfile = "E:\\lol.txt"; // можно путь в переменную записать
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //загружаем наш файл, если его нет, то создаём его

            if (File.Exists("E:\\lol.txt"))
            {
                StreamReader reader = new StreamReader(pathfile);
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
                FileStream FS2 = new FileStream("E:\\lol.txt", FileMode.Create);
            }



            //if ("E:\\lol.txt" != null)
            //{
            //    line = reader.ReadToEnd();
            //    string[] values = line.Split('|');

            //    eventsListView.Items.Add(new ListViewItem(values));
            //}

            //   ListViewItem loll = new ListViewItem(new string[] { this.Description, addedEvent.Starting.ToString(), addedEvent.Ending.ToString(), addedEvent.isUrgent.ToString() });
            //  eventsListView.Items.Add(loll);

            //  reader.Close();

            eventsListView.View = View.Details;
            eventsListView.Columns.Add("descr", 200);
            eventsListView.Columns.Add("start", 120);
            eventsListView.Columns.Add("end", 120);
            eventsListView.Columns.Add("isurgent", 50);

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

            DateTime timeForNewDay = new DateTime(
                int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()));
            int.Parse(beginningDateTimePicker.Value.Hour.ToString());
            int.Parse(beginningDateTimePicker.Value.Minute.ToString()
          );

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
            }//не правильно организовали логику проверки если 2 события в один день, то кидает экзепшн с ошибкой



            ListViewItem lol = new ListViewItem(new string[] { addedEvent.Description, addedEvent.Starting.ToString(), addedEvent.Ending.ToString(), addedEvent.isUrgent.ToString() });
            eventsListView.Items.Add(lol);



            //eventsListView.Items.Add(addedEvent.Description);
            //eventsListView.Items.Add(addedEvent.Starting.ToString());
            //eventsListView.Items.Add(addedEvent.Ending.ToString());
            //eventsListView.Items.Add(addedEvent.isUrgent.ToString());
            //добаляем листвью наши строки


            //запишем это дело в файл
            FileStream FS = new FileStream("E:\\lol.txt", FileMode.Append);
            StreamWriter WR = new StreamWriter(FS);
            WR.Write(addedEvent.Description + "|");
            WR.Write(addedEvent.Starting + "|");
            WR.Write(addedEvent.Ending + "|");
            WR.Write(addedEvent.Fulfillment);
            WR.WriteLine();

            WR.Close();


        }


        private void monthCalendar_Click(object sender, DateRangeEventArgs e)
        {

            //TODO реагирует список eventsListView
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
