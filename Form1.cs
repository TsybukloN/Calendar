using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private List<Event> events = new List<Event>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            isEditing = false;
            addPanel.Visible = !addPanel.Visible;
            if (!addPanel.Visible)
            {
                ClearAddEventForm();
            }
        }

        private void EditEventButton_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an event to edit.");
                return;
            }

            if (listBoxEvents.SelectedItem is Event selectedEvent)
            {
                isEditing = true;
                editingIndex = listBoxEvents.SelectedIndex;

                nameEvent.Text = selectedEvent.Name;
                startTimePicker.Value = selectedEvent.StartDate;
                endTimePicker.Value = selectedEvent.EndDate;
                descriptionEvent.Text = selectedEvent.Description;

                addPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Failed to retrieve the selected event. Please try again.");
            }
        }

        private void SaveEventButton_Click(object sender, EventArgs e)
        {
            Event actual_event = new Event(
                nameEvent.Text,
                startTimePicker.Value,
                endTimePicker.Value,
                descriptionEvent.Text
            );

            if (isEditing && editingIndex >= 0)
            {
                events[editingIndex] = actual_event;
                isEditing = false;
                editingIndex = -1;
            }
            else
            {
                events.Add(actual_event);
            }

            UpdateListBox();

            addPanel.Visible = false;
            ClearAddEventForm();
        }

        private void DeleteEventButton_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is Event selectedEvent)
            {
                events.Remove(selectedEvent);
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Please select an event to delete.", "No Selection");
            }
        }

        private void UpdateListBox()
        {
            listBoxEvents.Items.Clear();
            foreach (var ev in events)
            {
                listBoxEvents.Items.Add(ev);
            }
        }

        private void ClearAddEventForm()
        {
            nameEvent.Text = "";
            startTimePicker.Value = DateTime.Now;
            endTimePicker.Value = DateTime.Now;
            descriptionEvent.Text = "";
        }
    }
}
