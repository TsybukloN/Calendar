namespace Calendar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.DateTimePicker timePicker;

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
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(23, 24);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(12);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(420, 23);
            this.txtEvent.Margin = new System.Windows.Forms.Padding(4);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(256, 26);
            this.txtEvent.TabIndex = 1;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(420, 71);
            this.btnAddEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(257, 31);
            this.btnAddEvent.TabIndex = 2;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(420, 110);
            this.listBoxEvents.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(256, 244);
            this.listBoxEvents.TabIndex = 3;
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(718, 24);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(200, 26);
            this.timePicker.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 421);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.txtEvent);
            this.Controls.Add(this.monthCalendar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Calendar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
