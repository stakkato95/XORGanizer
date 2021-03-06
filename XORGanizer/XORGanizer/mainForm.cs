﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class MainForm : Form
    {
        public bool CheckForIntersection(EventConfiguringForm childForm)
        {
            try
            {
                listOfDays[childForm.TimeForNewDay].AddEvent(childForm.NewEvent);
            }
            catch
            {
                MessageBox.Show("Пересечение событий", "Невозможно добавить событие", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private Calendar listOfDays;
        private static string listOfEventsPath = Environment.CurrentDirectory;

        public MainForm()
        {
            InitializeComponent();

            //initializing custom components
            eventsListView.Columns.Add("Описание", 120);
            eventsListView.Columns.Add("Важность", 80);
            eventsListView.Columns.Add("Начало", 120);
            eventsListView.Columns.Add("Окончание", 120);
            eventsListView.Columns.Add("Выполненность", 120);
            Disposed += MainForm_Disposed;
        }

        public void EventsLoadMetod(ref StreamReader reader)
        {
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] values = line.Split('|');

                    //   parsing ticks string to long
                    long startTime = long.Parse(values[3]);
                    long endTime = long.Parse(values[4]);

                    //importance parameter for the event
                    EventImportance levelOfImportance =
                        (EventImportance) Enum.Parse(typeof (EventImportance), values[2], true);


                    bool completeness = false;
                    int comp = Convert.ToInt32(values[5]);

                    if (comp == 1)
                    {
                        completeness = true;
                    }
                    else if (comp == 0)
                    {
                        completeness = false;
                    }

                    Event addedEvent = new Event(startTime, endTime, levelOfImportance, values[1], completeness);

                    DateTime timeForNewDay = new DateTime(addedEvent.Starting.Year, addedEvent.Starting.Month,
                        addedEvent.Starting.Day);

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
            catch (Exception)
            {
                MessageBox.Show("Несоответствие файла", "Нежданчик", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listOfDays = new Calendar();

            if (File.Exists(listOfEventsPath + "\\List.txt"))
            {
                FileStream FS = new FileStream(MainForm.listOfEventsPath + "\\List.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader SR = new StreamReader(FS);
                EventsLoadMetod(ref SR);
            }

            DateRangeEventArgs args = new DateRangeEventArgs(
                new DateTime(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString()),
                    int.Parse(DateTime.Now.Day.ToString())), DateTime.Now);
            monthCalendar_Click(null, args);
        }

        private void addEventMetod()
        {

            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm(this) { SetExprctedDay = monthCalendar.SelectionStart };

            DialogResult dialogResult = eventConfiguringForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                //try
                //{
                //    if (listOfDays.ContainsKey(eventConfiguringForm.TimeForNewDay))
                //    {
                //        listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                        MessageBox.Show("Событие успешно добавлено");
                    //}
                    //else
                    //{
                    //    listOfDays.AddDay(eventConfiguringForm.TimeForNewDay, new Day(eventConfiguringForm.TimeForNewDay));
                    //    listOfDays[eventConfiguringForm.TimeForNewDay].AddEvent(eventConfiguringForm.NewEvent);
                    //    MessageBox.Show("Событие успешно добавлено");
                    //}

                    DateRangeEventArgs args = new DateRangeEventArgs(eventConfiguringForm.TimeForNewDay, DateTime.Now);
                    monthCalendar.SelectionStart = eventConfiguringForm.TimeForNewDay;
                    monthCalendar.SelectionEnd = eventConfiguringForm.TimeForNewDay;
                    monthCalendar_Click(null, args);

                //}

                //catch (Exception)
                //{
                //    MessageBox.Show("Пересечение событий", "Невозможно добавить событие", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            addEventMetod();
        }

        public void monthCalendar_Click(object sender, DateRangeEventArgs e)
        {
            eventsListView.Items.Clear();

            ListViewItem item = null;
            string importance = null;

            beginningDateTimePicker.Value = e.Start;

            if (listOfDays.ContainsKey(e.Start))
            {
                foreach (KeyValuePair<DateTime, Event> selectedDayEvent in listOfDays[e.Start])
                {
                    importance = selectedDayEvent.Value.Importance == EventImportance.Middle
                        ? "Средняя"
                        : (selectedDayEvent.Value.Importance == EventImportance.Low ? "Низкая" : "Высокая");

                 
                    string completeness = selectedDayEvent.Value.Сompleteness ? "Выполнено" : "Не выполнено";

                    item = new ListViewItem(selectedDayEvent.Value.Description);
                    item.SubItems.Add(importance);
                    item.SubItems.Add(selectedDayEvent.Value.Starting.ToShortTimeString());
                    item.SubItems.Add(selectedDayEvent.Value.Ending.ToShortTimeString());
                    item.SubItems.Add(completeness);
                    eventsListView.Items.Add(item);
                }
            }
        }



        private void StreamWritingBeforeClose()
        {
            File.Delete(MainForm.listOfEventsPath + "\\List.txt");

            FileStream FS = new FileStream(MainForm.listOfEventsPath + "\\List.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter WR = new StreamWriter(FS);

            foreach (KeyValuePair<DateTime, Day> day in listOfDays)
            {
                foreach (KeyValuePair<DateTime, Event> evnt in day.Value)
                {
                    WR.Write("" + "|");
                    WR.Write(evnt.Value.Description + "|");
                    WR.Write(evnt.Value.Importance + "|");
                    WR.Write(evnt.Value.Starting.Ticks + "|");
                    WR.Write(evnt.Value.Ending.Ticks + "|");

                    if (evnt.Value.Сompleteness == true)
                    {
                        WR.Write(1+"|");
                    }
                    else
                    {
                        WR.Write(0 + "|");
                    }

            //        WR.Write(evnt.Value.Сompleteness + "|");

                    WR.WriteLine();
                }
            }

           
            
            WR.Close();
            FS.Close();
        }

        private void editEventsMetod()
        {
            ListViewItem selectedItem = eventsListView.SelectedItems[0];
            string description = selectedItem.SubItems[0].Text;
            EventImportance importance = selectedItem.SubItems[1].Text == "Средняя"
                ? EventImportance.Middle
                : selectedItem.SubItems[1].Text == "Низкая" ? EventImportance.Low : EventImportance.High;

            //string comp = selectedItem.SubItems[4].Text;

            //bool copec = false;

            //if (comp  == "Выполнено")
            //{
            //    copec = true;
            //}
            //if (comp == "Не выполнено")
            //{
            //    copec = false;
              
            //}
            
            DateTime timeOfEditedEvent = monthCalendar.SelectionStart;
            int[] beginningHourMinute =
                selectedItem.SubItems[2].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();
            int[] endingHourMinute =
                selectedItem.SubItems[3].Text.Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();

            
            Event editedEvent = new Event(timeOfEditedEvent.Year, timeOfEditedEvent.Month, timeOfEditedEvent.Day,
                beginningHourMinute[0], beginningHourMinute[1], timeOfEditedEvent.Year, timeOfEditedEvent.Month,
                timeOfEditedEvent.Day, endingHourMinute[0], endingHourMinute[1], importance, description, completeness:true);

            EventConfiguringForm eventConfiguringForm = new EventConfiguringForm(this);
            eventConfiguringForm.EditedEvent = editedEvent;
            eventConfiguringForm.EditingMod = true;
            eventConfiguringForm.ShowDialog();
            DialogResult dialogResult = eventConfiguringForm.DialogResult;

            if (dialogResult == DialogResult.OK)
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

        private void eventsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            editEventsMetod();
        }

        private void добавитьСобытияИзФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Файлы txt|*.txt";


            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream FS = new FileStream(OpenFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader SR = new StreamReader(FS);
                FS.Close();
                SR.Close();
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


        //delete metod 
        private void deteleEventMetod()
        {
            while (eventsListView.SelectedItems.Count > 0)
            {
                int[] deletedEventYearMonthDay = monthCalendar.SelectionStart.ToString().Substring(0, 10).Split('.').OfType<string>().Select(str => int.Parse(str)).ToArray();
                int[] deletedEventHourMinute = eventsListView.SelectedItems[0].SubItems[2].ToString().Count() == 24 ? eventsListView.SelectedItems[0].SubItems[2].ToString().Substring(18, 5).Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray() : eventsListView.SelectedItems[0].SubItems[2].ToString().Substring(18, 4).Split(':').OfType<string>().Select(str => int.Parse(str)).ToArray();

                DateTime deletedEventDate = new DateTime(deletedEventYearMonthDay[2], deletedEventYearMonthDay[1], deletedEventYearMonthDay[0], deletedEventHourMinute[0], deletedEventHourMinute[1], 0);

                DateTime dayOfDeletedEvent = new DateTime(deletedEventYearMonthDay[2], deletedEventYearMonthDay[1], deletedEventYearMonthDay[0], 0, 0, 0);
                listOfDays[dayOfDeletedEvent].DeleteEvent(deletedEventDate);

                eventsListView.Items.Remove(eventsListView.SelectedItems[0]);
            }
        }

        private void eventsListView_MouseUp(object sender, EventArgs e)
        {
            deteleEventMetod();
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            StreamWritingBeforeClose();
        }

        //  events func
        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            deteleEventMetod();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deteleEventMetod();
        }

        private void editEventButton_Click(object sender, EventArgs e)
        {
            editEventsMetod();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editEventsMetod();
        }

        private void eventsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextMenu listViewContextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();

            listViewContextMenu.MenuItems.Add(menuItem);
            menuItem.Index = 0;
            menuItem.Text = "Удалить";
            menuItem.Click += eventsListView_MouseUp;
            eventsListView.ContextMenu = listViewContextMenu;


            menuItem.Enabled = true;

            deleteEventButton.Enabled = true;
            удалитьToolStripMenuItem.Enabled = true;
            изменитьToolStripMenuItem.Enabled = true;
            editEventButton.Enabled = true;
            

            if (eventsListView.SelectedItems.Count == 0)
            {
                deleteEventButton.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
                изменитьToolStripMenuItem.Enabled = false;
                editEventButton.Enabled = false;
            
                menuItem.Visible = false;
            }
        }

        private void добавитьНовоеСобытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addEventMetod();
        }

        private void delKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete)
            {
                DialogResult userChoice = MessageBox.Show("Вы действительно хотите удалить событие?", "Удаление события", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (userChoice == System.Windows.Forms.DialogResult.Yes)
                {
                    deteleEventMetod();
                }
            }
        }

    


    }
}
