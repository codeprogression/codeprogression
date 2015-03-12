using NUnit.Framework;
using StructureMap;

namespace AdventureMVC.Data.FluentNHibernate.Tests
{
    [TestFixture]
    public class When_saving_an_employee_record
    {
        [SetUp]
        public void SetUp()
        {
           ObjectFactory.Initialize(x => x.Scan(s =>
            {
                s.Assembly("AdventureMVC.Data.FluentNHibernate");
                s.Assembly("AdventureMVC.Core");
                s.WithDefaultConventions();
            }));
        }
        [Test]
        public void Should_update_all_changed_columns()
        {
            var repository = ObjectFactory.GetInstance<EmployeeRepository>();
            var employee = repository.GetEmployee(1);
            var sickLeaveHours = employee.SickLeaveHours+1;
            employee.SickLeaveHours++;
            repository.SaveEmployee(employee);
            var savedEmployee = repository.GetEmployee(1);
            Assert.AreEqual(sickLeaveHours,savedEmployee.SickLeaveHours);
        }
    }
}