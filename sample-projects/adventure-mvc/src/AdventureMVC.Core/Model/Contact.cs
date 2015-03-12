namespace AdventureMVC.Core.Model
{
    public class Contact
    {
        public virtual int ContactID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Phone { get; set; }
        public virtual string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }        
    }
}