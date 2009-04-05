using NUnit.Framework;
using StructureMap;

namespace AdventureMVC.Data.FluentNHibernate.Tests
{
    [TestFixture]
    public class When_retrieving_an_employee_record
    {

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                s.Assembly("AdventureMVC.Data.FluentNHibernate");
                s.Assembly("AdventureMVC.Core");
                s.WithDefaultConventions();
            }));
        }
        [Test]
        public void Should_retrieve_correct_record()
        {

            var repository = ObjectFactory.GetInstance<EmployeeRepository>();
            var employee = repository.GetEmployee(1);
            Assert.AreEqual(1209,employee.ContactID);
        }

    }
}