using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calendar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.Button editEventButton;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.TextBox nameEvent;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Button saveEventButton;
        private System.Windows.Forms.Panel addPanel;
        private bool isEditing = false;
        private int editingIndex = -1;

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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.editEventButton = new System.Windows.Forms.Button();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.nameEvent = new System.Windows.Forms.TextBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveEventButton = new System.Windows.Forms.Button();
            this.addPanel = new System.Windows.Forms.Panel();
            this.descriptionEvent = new System.Windows.Forms.RichTextBox();
            this.addPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(3, 2);
            this.monthCalendar.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Font = new System.Drawing.Font("Arial", 12F);
            this.listBoxEvents.ItemHeight = 27;
            this.listBoxEvents.Location = new System.Drawing.Point(710, 12);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(414, 598);
            this.listBoxEvents.TabIndex = 1;
            // 
            // AddEventButton
            // 
            this.AddEventButton.Location = new System.Drawing.Point(12, 349);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(231, 45);
            this.AddEventButton.TabIndex = 2;
            this.AddEventButton.Text = "Add New Event";
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // editEventButton
            // 
            this.editEventButton.Location = new System.Drawing.Point(12, 413);
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Size = new System.Drawing.Size(231, 45);
            this.editEventButton.TabIndex = 3;
            this.editEventButton.Text = "Edit Selected Event";
            this.editEventButton.Click += new System.EventHandler(this.EditEventButton_Click);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Location = new System.Drawing.Point(12, 475);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(231, 45);
            this.deleteEventButton.TabIndex = 3;
            this.deleteEventButton.Text = "Delete Selected Event";
            this.deleteEventButton.Click += new System.EventHandler(this.DeleteEventButton_Click);
            // 
            // nameEvent
            // 
            this.nameEvent.Font = new System.Drawing.Font("Arial", 12F);
            this.nameEvent.Location = new System.Drawing.Point(20, 20);
            this.nameEvent.Name = "nameEvent";
            this.nameEvent.Size = new System.Drawing.Size(300, 35);
            this.nameEvent.TabIndex = 4;
            TextBoxPlaceholder.SetPlaceholder(nameEvent, "name");
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(20, 70);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(300, 26);
            this.startTimePicker.TabIndex = 5;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "dd MMM yyyy HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(20, 110);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(300, 26);
            this.endTimePicker.TabIndex = 6;
            // 
            // saveEventButton
            // 
            this.saveEventButton.Location = new System.Drawing.Point(20, 270);
            this.saveEventButton.Name = "saveEventButton";
            this.saveEventButton.Size = new System.Drawing.Size(300, 30);
            this.saveEventButton.TabIndex = 8;
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
            this.addPanel.Location = new System.Drawing.Point(303, 349);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(340, 320);
            this.addPanel.TabIndex = 9;
            this.addPanel.Visible = false;
            // 
            // descriptionEvent
            // 
            this.descriptionEvent.Font = new System.Drawing.Font("Arial", 12F);
            this.descriptionEvent.Location = new System.Drawing.Point(20, 142);
            this.descriptionEvent.Name = "descriptionEvent";
            this.descriptionEvent.Size = new System.Drawing.Size(300, 100);
            this.descriptionEvent.TabIndex = 7;
            this.descriptionEvent.Text = "";
            RichTextBoxPlaceholder.SetPlaceholder(descriptionEvent, "description");
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1138, 747);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.AddEventButton);
            this.Controls.Add(this.editEventButton);
            this.Controls.Add(this.deleteEventButton);
            this.Controls.Add(this.addPanel);
            this.Name = "Form1";
            this.Text = "Enhanced Calendar";
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private RichTextBox descriptionEvent;
    }
}
