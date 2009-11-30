using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Moq;
using It=Machine.Specifications.It;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("with coffee dispenser base (moq container)")]
    public class Example06_when_starting_coffee_machine : with_moq_coffee_machine
    {
        Establish context = () => Hopper.Setup(x=>x.IsEmpty()).Returns(true);

        Because of = () => ClassUnderTest.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.Verify();
        It should_grind_coffee = () => Grinder.Verify(x=>x.Grind(12));

    }

    public class with_moq_coffee_machine : SpecificationFor<CoffeeMachine>
    {
        public with_moq_coffee_machine() : base(AutoMockType.Moq)
        {
        }


        protected static Mock<IGrinder> Grinder;
        protected static Mock<IHopper> Hopper;

        Establish context = () =>
        {
            Grinder = Mock.Get(Factory.Get<IGrinder>());
            Hopper = Mock.Get(Factory.Get<IHopper>());
        };
    }
}