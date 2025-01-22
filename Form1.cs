using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private List<Event> events;
        private readonly string filePath = "calendarEvents.json";

        public void LoadEvents()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    events = JsonConvert.DeserializeObject<List<Event>>(json) ?? new List<Event>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    events = new List<Event>();
                }

            }
            else
            {
                events = new List<Event>();
            }
        }

        public void SaveEvents()
        {
            try
            {
                string json = JsonConvert.SerializeObject(events, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void FilterEvents()
        {
            DateTime startDate = startTimeSearchPicker.Value;
            DateTime endDate = endTimeSearchPicker.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("The start date must be earlier than the end date.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredEvents = events
                .Where(ev => ev.StartDate >= startDate && ev.EndDate <= endDate)
                .ToList();

            listBoxEvents.Items.Clear();

            foreach (var ev in filteredEvents)
            {
                listBoxEvents.Items.Add(ev);
            }
        }

        private void TimeSearchPicker_ValueChanged(object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            addPanel.Visible = isEditing || !addPanel.Visible;

            if (isEditing)
            {
                isEditing = false;
                ClearAddEventForm();
            }

            //nameEvent.Focus();
        }

        private void PreviewEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is Event selectedEvent)
            {
                isEditing = true;
                nameEvent.Text = selectedEvent.Name;
                startTimePicker.Value = selectedEvent.StartDate;
                endTimePicker.Value = selectedEvent.EndDate;
                descriptionEvent.Text = selectedEvent.Description;

                addPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Can not found the Event.");
                addPanel.Visible = false;
            }
        }

        private void SaveEventButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEvent.Text))
            {
                MessageBox.Show("Event name cannot be empty.");
                return;
            }

            if (startTimePicker.Value > endTimePicker.Value)
            {
                MessageBox.Show("Start time must be earlier than end time.");
                return;
            }

            if (isEditing && listBoxEvents.SelectedItem is Event selectedEvent)
            {
                selectedEvent.Name = nameEvent.Text;
                selectedEvent.StartDate = startTimePicker.Value;
                selectedEvent.EndDate = endTimePicker.Value;
                selectedEvent.Description = descriptionEvent.Text;
            }
            else
            {
                events.Add(new Event(
                    nameEvent.Text,
                    startTimePicker.Value,
                    endTimePicker.Value,
                    descriptionEvent.Text
                ));
            }

            isEditing = false;

            startTimeSearchPicker.Value = startTimeSearchPicker.Value < startTimePicker.Value 
                ? startTimeSearchPicker.Value : startTimePicker.Value;

            FilterEvents();

            addPanel.Visible = false;
            ClearAddEventForm();

            SaveEvents();
        }

        private void DeleteEventButton_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is Event selectedEvent)
            {
                events.Remove(selectedEvent);
                FilterEvents();
                ClearAddEventForm();
                addPanel.Visible = false;
                SaveEvents();
            }
            else
            {
                MessageBox.Show("Please select an event to delete.", "No Selection");
            }
        }

        private void ClearAddEventForm()
        {
            nameEvent.Text = "";
            startTimePicker.Value = DateTime.Now;
            endTimePicker.Value = DateTime.Now;
            descriptionEvent.Text = "";
        }
        
        private void SetPickersToDefault()
        {
            DateTime today = DateTime.Now;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            startTimePicker.Value = today;
            endTimePicker.Value = today.AddMinutes(30);

            startTimeSearchPicker.Value = startOfWeek;
            endTimeSearchPicker.Value = endOfWeek;

            startTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            startTimeSearchPicker.ValueChanged -= TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged -= TimeSearchPicker_ValueChanged;

            endTimeSearchPicker.Value = monthCalendar.SelectionRange.End.Date.AddDays(1).AddTicks(-1);
            startTimeSearchPicker.Value = monthCalendar.SelectionRange.Start.Date;

            startTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;

            FilterEvents();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPickersToDefault();
            LoadEvents();
            FilterEvents();
        }
    }
}
