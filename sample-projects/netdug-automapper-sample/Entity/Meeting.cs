using System;
using System.Collections.Generic;

namespace NETDUGSample.Entity
{
    public class Meeting
    {
        public string Title { get; set; }
        public DateTime Begins { get; set; }
        public DateTime End { get; set; }
        public IList<Attendee> Attendees { get; set; }
    }
}