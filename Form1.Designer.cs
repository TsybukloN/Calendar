using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Calendar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.DateTimePicker startTimeSearchPicker;
        private System.Windows.Forms.DateTimePicker endTimeSearchPicker;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.TextBox nameEvent;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;       
        private System.Windows.Forms.Button saveEventButton;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.RichTextBox descriptionEvent;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private Label searchLabel;
        private bool isEditing;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.startTimeSearchPicker = new System.Windows.Forms.DateTimePicker();
            this.endTimeSearchPicker = new System.Windows.Forms.DateTimePicker();
            this.addEventButton = new System.Windows.Forms.Button();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.nameEvent = new System.Windows.Forms.TextBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveEventButton = new System.Windows.Forms.Button();
            this.addPanel = new System.Windows.Forms.Panel();
            this.descriptionEvent = new System.Windows.Forms.RichTextBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.searchLabel = new System.Windows.Forms.Label();
            this.addPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Font = new System.Drawing.Font("Arial", 12F);
            this.listBoxEvents.ItemHeight = 27;
            this.listBoxEvents.Location = new System.Drawing.Point(771, 107);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(420, 382);
            this.listBoxEvents.TabIndex = 7;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.PreviewEventList_SelectedIndexChanged);
            // 
            // startTimeSearchPicker
            // 
            this.startTimeSearchPicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.startTimeSearchPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimeSearchPicker.Location = new System.Drawing.Point(771, 60);
            this.startTimeSearchPicker.Name = "startTimeSearchPicker";
            this.startTimeSearchPicker.Size = new System.Drawing.Size(200, 26);
            this.startTimeSearchPicker.TabIndex = 2;
            // 
            // endTimeSearchPicker
            // 
            this.endTimeSearchPicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.endTimeSearchPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimeSearchPicker.Location = new System.Drawing.Point(991, 60);
            this.endTimeSearchPicker.Name = "endTimeSearchPicker";
            this.endTimeSearchPicker.Size = new System.Drawing.Size(200, 26);
            this.endTimeSearchPicker.TabIndex = 3;
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(17, 205);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(180, 40);
            this.addEventButton.TabIndex = 4;
            this.addEventButton.Text = "Add New Event";
            this.addEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Location = new System.Drawing.Point(17, 262);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(180, 40);
            this.deleteEventButton.TabIndex = 6;
            this.deleteEventButton.Text = "Delete Selected Event";
            this.deleteEventButton.Click += new System.EventHandler(this.DeleteEventButton_Click);
            // 
            // nameEvent
            // 
            this.nameEvent.Font = new System.Drawing.Font("Arial", 12F);
            this.nameEvent.Location = new System.Drawing.Point(20, 20);
            this.nameEvent.Name = "nameEvent";
            this.nameEvent.Size = new System.Drawing.Size(500, 35);
            this.nameEvent.TabIndex = 0;
            TextBoxPlaceholder.SetPlaceholder(this.nameEvent, "name");
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(20, 70);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(250, 26);
            this.startTimePicker.TabIndex = 1;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(20, 110);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(250, 26);
            this.endTimePicker.TabIndex = 2;
            // 
            // saveEventButton
            // 
            this.saveEventButton.Location = new System.Drawing.Point(20, 260);
            this.saveEventButton.Name = "saveEventButton";
            this.saveEventButton.Size = new System.Drawing.Size(500, 30);
            this.saveEventButton.TabIndex = 4;
            this.saveEventButton.Text = "Save Event";
            this.saveEventButton.Click += new System.EventHandler(this.SaveEventButton_Click);
            // 
            // addPanel
            // 
            this.addPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addPanel.Controls.Add(this.nameEvent);
            this.addPanel.Controls.Add(this.startTimePicker);
            this.addPanel.Controls.Add(this.endTimePicker);
            this.addPanel.Controls.Add(this.descriptionEvent);
            this.addPanel.Controls.Add(this.saveEventButton);
            this.addPanel.Location = new System.Drawing.Point(203, 205);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(539, 312);
            this.addPanel.TabIndex = 8;
            this.addPanel.Visible = false;
            // 
            // descriptionEvent
            // 
            this.descriptionEvent.Font = new System.Drawing.Font("Arial", 12F);
            this.descriptionEvent.Location = new System.Drawing.Point(20, 150);
            this.descriptionEvent.Name = "descriptionEvent";
            this.descriptionEvent.Size = new System.Drawing.Size(500, 100);
            this.descriptionEvent.TabIndex = 3;
            TextBoxPlaceholder.SetPlaceholder(this.descriptionEvent, "description");
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.monthCalendar.Location = new System.Drawing.Point(17, 11);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.MaxSelectionCount = 30;
            this.monthCalendar.DateChanged += this.monthCalendar_DateChanged;
            // 
            // searchLabel
            // 
            this.searchLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.searchLabel.Location = new System.Drawing.Point(767, 22);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(200, 20);
            this.searchLabel.TabIndex = 1;
            this.searchLabel.Text = "Search events between:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1210, 529);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.startTimeSearchPicker);
            this.Controls.Add(this.endTimeSearchPicker);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.deleteEventButton);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.addPanel);
            this.Name = "Form1";
            this.Text = "Korovnic Inc. Calendar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
