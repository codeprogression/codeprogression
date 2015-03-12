using AdventureMVC.Core.Model;
using FluentNHibernate.Mapping;

namespace AdventureMVC.Data.FluentNHibernate.Maps
{
    public class EmployeeMap : ClassMap<Contact>
    {
        public EmployeeMap()
        {
            CreateMap();
        }

        protected  void CreateMap()
        {
            LazyLoad();
            
            WithTable("Person.Contact");
            Id(x => x.ContactID).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.EmailAddress);
            Map(x => x.Phone);
            

            JoinedSubClass<Employee>("ContactID", e =>
            {
                e.WithTableName("HumanResources.Employee");
                e.Map(x => x.EmployeeID).ReadOnly();
                e.Map(x => x.Title);
                e.Map(x => x.BirthDate);
                e.Map(x => x.VacationHours);
                e.Map(x => x.SickLeaveHours);
                
            });
        }
    }

}
