using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Event
    {
        public Event(String name, TimeSpan start_time, TimeSpan end_time)
        {
            this.name = name;
            this.desription = null;
            this.start_time = start_time;
            this.end_time = end_time;
        }
        public Event(String name, TimeSpan start_time, TimeSpan end_time, String decsiption) { 
            this.name = name;
            this.desription = decsiption;
            this.start_time = start_time;
            this.end_time = end_time;
        }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public String name { get; set; }
        public String desription { get; set; }
    }
}
