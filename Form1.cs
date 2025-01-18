using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private Dictionary<DateTime, List<Event>> events = new Dictionary<DateTime, List<Event>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            var selectedDate = monthCalendar.SelectionStart.Date;
            Event actual_event = new Event(txtEvent.Text);

            if (!string.IsNullOrWhiteSpace(actual_event.name))
            {
                if (!events.ContainsKey(selectedDate))
                    events[selectedDate] = new List<Event>();

                events[selectedDate].Add(actual_event);
                txtEvent.Clear();
                UpdateEventList();
            }
            else
            {
                MessageBox.Show("Enter desription for event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateEventList();
        }

        private void UpdateEventList()
        {
            var selectedDate = monthCalendar.SelectionStart.Date;
            listBoxEvents.Items.Clear();

            if (events.ContainsKey(selectedDate))
            {
                foreach (var iter_event in events[selectedDate])
                    listBoxEvents.Items.Add(iter_event.name);
            }
        }
    }
}
