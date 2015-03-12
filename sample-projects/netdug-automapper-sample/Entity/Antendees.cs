using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NETDUGSample.Entity
{
    public class AttendeeRepository : IList<Attendee>
    {
        readonly IList<Attendee> _list = new List<Attendee>();

        public AttendeeRepository()
        {
            Add(new Attendee
            {
                Id = 1,
                FirstName = "Ward",
                LastName = "Cleaver",
                EmailAddress = "ward@cleaverfamily.org",
                Webpage = "www.cleaverfamily.org",
                Status = AttendanceStatus.Confirmed
            });
            Add(new Attendee
            {
                Id = 2,
                FirstName = "June",
                LastName = "Cleaver",
                EmailAddress = "june@cleaverfamily.org",
                Webpage = "www.cleaverfamily.org",
                Status = AttendanceStatus.Confirmed
            });
            Add(
                new Attendee
                {
                    Id = 3,
                    FirstName = "Wally",
                    LastName = "Cleaver",
                    EmailAddress = "wally@cleaverfamily.org",
                    Webpage = "www.existentialist.org",
                    Status = AttendanceStatus.Pending
                });
            Add(
                new Attendee
                {
                    Id = 4,
                    FirstName = "Beaver",
                    LastName = "Cleaver",
                    EmailAddress = "beaver@cleaverfamily.org",
                    Status = AttendanceStatus.Rejected
                });
        }

        #region IList<Attendee> Members

        public IEnumerator<Attendee> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(Attendee item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(Attendee item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Attendee[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Attendee item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public int IndexOf(Attendee item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Attendee item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public Attendee this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public ReadOnlyCollection<Attendee> GetAll()
        {
            return _list.ToList().AsReadOnly();
        }

        public Attendee GetById(int id)
        {
            return _list.SingleOrDefault(x => x.Id == id);
        }
    }
}