using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Event
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public Event() { }

        public Event(String name, DateTime start_time, DateTime end_time)
        {
            this.Name = name;
            this.Description = null;
            this.StartDate = start_time;
            this.EndDate = end_time;
        }
        public Event(String name, DateTime start_time, DateTime end_time, String decsiption) { 
            this.Name = name;
            this.Description = decsiption;
            this.StartDate = start_time;
            this.EndDate = end_time;
        }
        
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
