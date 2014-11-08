using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class EventConfiguringForm : Form
    {
        MainForm MainForm;

        public void SetMainForm(MainForm mainForm) { MainForm = mainForm; }

        public EventConfiguringForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int levelOfImportance = 0;
            for (int i = 0; i < importanceGroupBox.Controls.Count; i++)
            {
                if (((RadioButton)importanceGroupBox.Controls[i]).Checked)
                {
                    levelOfImportance = i;
                    break;
                }
            }

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

            DateTime timeForNewDay = new DateTime(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                int.Parse(beginningDateTimePicker.Value.Day.ToString()));

            try
            {
                if (MainForm.listOfDays.ContainsKey(timeForNewDay))
                {
                    MainForm.listOfDays[timeForNewDay].addEvent(addedEvent);

                    this.Close();
                    MessageBox.Show("Событие успешно добавлено");
                    descriptionTextBox.Text = "";
                }
                else
                {
                    MainForm.listOfDays.Add(timeForNewDay, new Day(timeForNewDay));
                    MainForm.listOfDays[timeForNewDay].addEvent(addedEvent);

                    this.Close();
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
    }
}
