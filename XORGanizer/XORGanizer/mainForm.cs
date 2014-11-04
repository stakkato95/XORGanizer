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
            Event added = new Event(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
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

            if (listOfDays.ContainsValue(new Day(added.Starting)))
            {
                listOfDays[added.Starting].addEvent(added);
            }
            else
            {
                listOfDays.Add(added.Starting, new Day(added.Starting));
                listOfDays[added.Starting].addEvent(added);
            }
        }



    }
}
