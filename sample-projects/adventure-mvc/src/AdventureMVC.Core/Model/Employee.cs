using System;

namespace AdventureMVC.Core.Model
{
    public class Employee : Contact
    {
        public virtual int EmployeeID { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int VacationHours { get; set; }
        public virtual int SickLeaveHours { get; set; }
    }
}