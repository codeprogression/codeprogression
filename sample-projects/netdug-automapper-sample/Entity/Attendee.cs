using System;

namespace NETDUGSample.Entity
{
    public class Attendee
    {
       
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Webpage { get; set; }
        public virtual AttendanceStatus Status { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", FirstName, LastName, Status);
        }
    }
}