using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private List<Event> events;
        private readonly string filePath = "calendarEvents.json";
        private readonly string namePlaceholder = "Event Name";
        private readonly string descriptionPlaceholder = "Event Description";

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
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                .Where(ev => ev.StartDate <= endDate && ev.EndDate >= startDate)
                .OrderBy(ev => ev.StartDate)
                .ToList();

            listBoxEvents.Items.Clear();

            DateTime? currentDay = null;

            foreach (var ev in filteredEvents)
            {
                if (currentDay != ev.StartDate.Date)
                {
                    currentDay = ev.StartDate.Date;

                    listBoxEvents.Items.Add($"-- {currentDay:dddd, dd MMMM yyyy} --");
                }

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

            nameEvent.Focus();
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

                TextBoxPlaceholder.SetPlaceholder(nameEvent, namePlaceholder);
                TextBoxPlaceholder.SetPlaceholder(descriptionEvent, descriptionPlaceholder);

                addPanel.Visible = true;
            }
            else
            {
                addPanel.Visible = false;
            }
        }

        private void SaveEventButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEvent.Text) || nameEvent.Text == namePlaceholder)
            {
                MessageBox.Show("Event name cannot be empty.");
                return;
            }


            if (nameEvent == null || descriptionEvent == null || startTimePicker == null || endTimePicker == null)
            {
                MessageBox.Show("One of the event fields is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            descriptionEvent.Text = descriptionEvent.Text == descriptionPlaceholder 
                ? "" : descriptionEvent.Text;

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
            this.nameEvent.Text = "";
            TextBoxPlaceholder.SetPlaceholder(this.nameEvent, namePlaceholder);

            startTimePicker.Value = DateTime.Now;
            endTimePicker.Value = DateTime.Now.AddMinutes(30);

            this.descriptionEvent.Text = "";
            TextBoxPlaceholder.SetPlaceholder(this.descriptionEvent, descriptionPlaceholder);
        }
        
        private void SetSearchPickersToDefault()
        {
            DateTime today = DateTime.Now;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            startTimeSearchPicker.Value = startOfWeek;
            endTimeSearchPicker.Value = endOfWeek;

            startTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (isEditing) 
            {
                isEditing = false;
                addPanel.Visible = false;
                ClearAddEventForm();
            }

            startTimeSearchPicker.ValueChanged -= TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged -= TimeSearchPicker_ValueChanged;

            startTimeSearchPicker.Value = monthCalendar.SelectionRange.Start.Date;
            endTimeSearchPicker.Value = monthCalendar.SelectionRange.End.Date.AddDays(1).AddTicks(-1);

            startTimePicker.Value = monthCalendar.SelectionRange.Start.Date
                .AddHours(DateTime.Now.Hour)
                .AddMinutes(DateTime.Now.Minute)
                .AddSeconds(DateTime.Now.Second); ;
            endTimePicker.Value = startTimePicker.Value.AddMinutes(30);

            startTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;
            endTimeSearchPicker.ValueChanged += TimeSearchPicker_ValueChanged;

            FilterEvents();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSearchPickersToDefault();
            ClearAddEventForm();
            LoadEvents();
            FilterEvents();
        }
    }
}
