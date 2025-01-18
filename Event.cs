using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Event
    {
        public Event(String name)
        {
            this.name = name;
            this.desription = null;
        }
        public Event(String name, String decsiption) { 
            this.name = name;
            this.desription = decsiption;
        }
        public TimeSpan timeSpan { get; set; }
        public String name { get; set; }
        public String desription { get; set; }
    }
}
