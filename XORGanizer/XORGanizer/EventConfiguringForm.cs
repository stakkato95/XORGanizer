using System;
using System.Windows.Forms;

namespace XORGanizer
{
    public partial class EventConfiguringForm : Form
    {
        internal Event EditedEvent { get { return editedEvent; } set { editedEvent = value; } }
        private Event editedEvent;
        internal Event NewEvent { get { return newEvent; } private set { newEvent = value; } }
        private Event newEvent;
        internal bool EditingMod { get { return editingMod; } set { editingMod = value; } }
        private bool editingMod;
        internal DateTime TimeForNewDay { get { return timeForNewDay; } private set { timeForNewDay = value; } }
        private DateTime timeForNewDay;
        internal DateTime TimeForEditedEvent { get { return timeForEditedEvent; } private set { timeForEditedEvent = value; } }
        private DateTime timeForEditedEvent;
        internal DateTime SetExprctedDay { set { beginningDateTimePicker.Value = value; endingDateTimePicker.Value = value; } }

        private MainForm MainOwner;

        public EventConfiguringForm(MainForm mainForm)
        {
            InitializeComponent();
            MainOwner = mainForm;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!EditingMod)
            {
                PrimaryEventSetting(ref newEvent, ref timeForNewDay);
            }
            else
            {
                PrimaryEventSetting(ref newEvent, ref timeForNewDay);
            }
            okButton.DialogResult = MainOwner.CheckForIntersection(this) ? DialogResult.OK : DialogResult.None;
        }

        private void PrimaryEventSetting(ref Event addedEvent, ref DateTime timeForNewDay)
        {
            int intValueOfImportance = 0;
            for (int i = 0; i < importanceGroupBox.Controls.Count; i++)
            {
                if (((RadioButton) importanceGroupBox.Controls[i]).Checked)
                {
                    intValueOfImportance = i;
                    break;
                }
            }


                EventImportance levelOfImportance =
                    (EventImportance) Enum.Parse(typeof (EventImportance), intValueOfImportance.ToString(), true);

            addedEvent = new Event(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
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
                descriptionTextBox.Text, radioButton1.Checked);
                timeForNewDay = new DateTime(int.Parse(beginningDateTimePicker.Value.Year.ToString()),
                    int.Parse(beginningDateTimePicker.Value.Month.ToString()),
                    int.Parse(beginningDateTimePicker.Value.Day.ToString()));
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EventConfiguringForm_Load(object sender, EventArgs e)
        {
            if (EditingMod)
            {
                beginningDateTimePicker.Value = EditedEvent.Starting;
                endingDateTimePicker.Value = EditedEvent.Ending;
                descriptionTextBox.Text = EditedEvent.Description;
                if (EditedEvent.Importance == EventImportance.Middle)
                    middleImportanceRadioButton.Select();
                else if (EditedEvent.Importance == EventImportance.Low)
                    lowImportanceRadioButton.Select();
                else if (EditedEvent.Importance == EventImportance.High)
                    highImportanceRadioButton.Select();
            }
        }

        private void beginningDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //doesn't allow to set time of beginning greater than time of ending
            if (beginningDateTimePicker.Value > endingDateTimePicker.Value)
            {
                endingDateTimePicker.Value = new DateTime(beginningDateTimePicker.Value.Year, beginningDateTimePicker.Value.Month, beginningDateTimePicker.Value.Day, beginningDateTimePicker.Value.Hour, beginningDateTimePicker.Value.Minute, 0);
            }

            
        }

        private void endingDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //doesn't allow to set time of ending smaller than time of beginning
            if (endingDateTimePicker.Value < beginningDateTimePicker.Value)
            {
                beginningDateTimePicker.Value = new DateTime(endingDateTimePicker.Value.Year, endingDateTimePicker.Value.Month, endingDateTimePicker.Value.Day, endingDateTimePicker.Value.Hour, endingDateTimePicker.Value.Minute, 0);
            }
        }

    }
}
